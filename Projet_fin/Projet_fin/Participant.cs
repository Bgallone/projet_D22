using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;
using System.Net;
using System.Net.Mail;
using System.Net.Mime;
using System.Threading;


namespace Projet_fin
{
    public partial class Participant : Form
    {

        private String chco ;//= @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=./Resources/bdEvents.mdb";
        private OleDbConnection co = new OleDbConnection();
        private DataSet ds = new DataSet();
        private bool load = false;

        public Participant(String chco)
        {
            InitializeComponent();
            this.chco = chco;
        }

        private void Participant_Load(object sender, EventArgs e)
        {
            co.ConnectionString = chco;
            co.Open();
            string req = @"SELECT [titreEvent] 
                            FROM Evenements;";
            OleDbCommand cmd = new OleDbCommand(req, co);
            OleDbDataAdapter da = new OleDbDataAdapter();
            da.SelectCommand = cmd;
            da.Fill(ds, "events");

            cbxEvent.DataSource = ds.Tables["events"];
            cbxEvent.DisplayMember = "titreEvent";
        }


        private void aff_info()
        {

            String evnt = cbxEvent.Text;
            String rqt = @"
                           SELECT p.codeParticipant as Code, p.prenomPart + ' ' + p.nomPart as [Nom et Prenom], p.mobile as [N° téléphone], p.nbParts as Parts, p.solde
                           FROM Invites i,Participants p 
                           WHERE i.codePart = p.codeParticipant 
                           AND i.codeEvent = (
                                               SELECT codeEvent
                                               FROM Evenements
                                               WHERE titreEvent = '" + evnt + "');";

            OleDbDataAdapter da = new OleDbDataAdapter();
            OleDbCommand cmd = new OleDbCommand(rqt, co);
            da.SelectCommand = cmd;
            DataSet participants = new DataSet();
            da.Fill(participants, "participants");
            dataGridView1.DataSource = participants.Tables[0];
        }

        private void cbxEvent_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (load)
            {
                aff_info();
                refresh_add();
            }
            else
            {
                load = true;
            }
        }

        private void btnInv_Click(object sender, EventArgs e)
        {
            gbxAdd.Visible = true;
            cbxAdd.Visible = true;
            btnAdd.Visible = true;
            lblAdd.Visible = true;
            refresh_add();
        }

        private void refresh_add()
        {
            String evt = cbxEvent.Text;
            String reqt = @"SELECT p.prenomPart + ' ' + p.nomPart as nom
                           FROM Participants p
                           WHERE p.codeParticipant NOT IN (                           
                                           SELECT p.codeParticipant
                                           FROM Invites i,Participants p 
                                           WHERE i.codePart = p.codeParticipant 
                                           AND i.codeEvent = (
                                                               SELECT codeEvent
                                                               FROM Evenements
                                                               WHERE titreEvent = '" + evt + "'));";
            DataSet invite = new DataSet();

            OleDbDataAdapter dt = new OleDbDataAdapter();
            OleDbCommand cmd = new OleDbCommand(reqt, co);
            dt.SelectCommand = cmd;

            dt.Fill(invite, "invite");
            cbxAdd.DataSource = invite.Tables["invite"];
            cbxAdd.DisplayMember = "nom";
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            String evt = cbxEvent.Text;
            MessageBox.Show(evt);
            String nom = cbxAdd.Text;
            String pwd = getRandomPassword();
            String rqt = @"SELECT adresseMail FROM Participants WHERE (prenomPart + ' ' + nomPart) = '" + nom + "';";
            OleDbCommand cmd = new OleDbCommand(rqt, co);
            String email = cmd.ExecuteScalar() + "";
            cmd.CommandText = "SELECT codeEvent FROM Evenements WHERE titreEvent = '" + evt + "';";
            int code = int.Parse(cmd.ExecuteScalar() + "");
            cmd.CommandText = "SELECT codeParticipant FROM Participants WHERE (prenomPart + ' ' + nomPart) = '" + nom + "';";
            int codep = int.Parse(cmd.ExecuteScalar() + "");
            cmd.CommandText = "SELECT prenomPart FROM Participants WHERE (prenomPart + ' ' + nomPart) = '" + nom + "';";
            String login = (cmd.ExecuteScalar() + "").Substring(0,1);
            cmd.CommandText = "SELECT nomPart FROM Participants WHERE (prenomPart + ' ' + nomPart) = '" + nom + "';";
            login += cmd.ExecuteScalar().ToString().Substring(0, 8);
            String req = @"INSERT INTO Invites (codeEvent, codePart, login,mdp) VALUES ("+ code +","+ codep + ",'" + login + "','" + pwd + "');";
            SendMail(email, " Tu es invité à l'événement : "+ evt , "Bonjour, \n\n Tu es invité a l'événement : "+ evt + " \n Ton mot de passe est :" +pwd+ "\n\n\n Mail automatique ne pas répondre svp");
            //baptiste.gallone@etu.unistra.fr
            //Florian.Holtzinger@etu.unistra.fr
            MessageBox.Show(req);
            cmd.CommandText = req;
            int n = 0;
            try
            {
                n = cmd.ExecuteNonQuery();
            }
            catch (Exception et)
            {
                Console.WriteLine(et.Message);
            }
            MessageBox.Show(n+ "");
        }


        private static char[] randomChars = new char[] { 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z', 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z', '9', '8', '7', '6', '5', '4', '3', '2', '1', '0' };
        private static readonly Random rand = new Random();



        private static string getRandomPassword()
        {

            char[] password = new char[10];

            for (int i = 0; i < 10; ++i)

                password[i] = randomChars[rand.Next(0, randomChars.Length)];

            return new string(password);

        }

        public static void SendMail(string adresses, string subject, string message)
        {
            
            try
            {
                MailMessage mail = new MailMessage();
                //ajouter les destinataires
                /*foreach (string adress in adresses)
                {
                    */mail.To.Add(adresses);/*
                }*/

                mail.Subject = subject;
                mail.Body = message;
                //définir l'expéditeur
                mail.From = new MailAddress("no-replay@boncompte.fr", "Invitation évènement");
                //définir les paramètres smtp pour l'envoi
                SmtpClient smtpServer = new SmtpClient
                {
                    Host = "mailserver.u-strasbg.fr",
                    Port = 587,
                    EnableSsl = true,
                    DeliveryMethod = SmtpDeliveryMethod.Network,
                    UseDefaultCredentials = false,
                    Credentials = new NetworkCredential("bgallone", "gallone67#")
                };
                //envoi du mail
                try
                {
                    smtpServer.Send(mail);
                    MessageBox.Show("email est envoyer");
                }
                catch (SmtpException ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

        }
    }
}
