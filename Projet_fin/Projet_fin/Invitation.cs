using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.Mail;
using System.Net.Mime;
using System.Threading;

namespace Projet_fin
{
    public partial class Invitation : Form
    {
        private String chco;
        private OleDbConnection co = new OleDbConnection();
        private int Evenum ; 

        public Invitation(String chco)
        {
            InitializeComponent();
            this.chco = chco;
            
        }



        private void Invitation_Load(object sender, EventArgs e)
        {   
            
            co.ConnectionString = chco;
            co.Open();
            OleDbCommand cmd = new OleDbCommand();
            cmd.Connection = co;
            //Num de l'événement 
            string req = @"SELECT count(*)  FROM Evenements";
            cmd.CommandText = req;
            Evenum = int.Parse(cmd.ExecuteScalar().ToString());

            co.Close();

            RemplirCheckListBox();

          
        }
        private void RemplirCheckListBox()
        {
            co.Open();
            OleDbCommand cmd = new OleDbCommand();
            cmd.Connection = co;

            cmd.CommandType = CommandType.Text;
            
            //Num du créateur de l'évenement 
            string req = @"SELECT codeCreateur FROM Evenements 
                           WHERE codeEvent = " + Evenum + ";";
            cmd.CommandText = req;
            int codeCrée = int.Parse(cmd.ExecuteScalar().ToString());

            //On cherche tous les autres participants. 
            req = @"SELECT nomPart , prenomPart FROM  Participants 
                    WHERE  codeParticipant NOT IN 
                    (SELECT codeParticipant FROM Participants WHERE codeParticipant =" + codeCrée + ");";

            
            cmd.CommandText = req;

            OleDbDataReader dr = cmd.ExecuteReader();
            
            while (dr.Read())
            {
                clbBeneficiaires.Items.Add(dr.GetString(0));
            }

            co.Close();
        }
        private void toutcocher(object sender, EventArgs e)
        {
            if (
                chxTtSelectionner.Checked)
            {
                for (int i = 0; i < clbBeneficiaires.Items.Count; i++)
                {
                    clbBeneficiaires.SetItemChecked(i, true);
                }
            }
            else
            {
                for (int i = 0; i < clbBeneficiaires.Items.Count; i++)
                {
                    clbBeneficiaires.SetItemChecked(i, false);
                }
            }
        }
       

        private void btnValidation_Click(object sender, EventArgs e)
        {           co.Open();
                    OleDbCommand cmd = new OleDbCommand();
                    cmd.Connection = co;

                    cmd.CommandType = CommandType.Text;

            for (int i = 0; i < clbBeneficiaires.Items.Count; i++)
            {
                if (clbBeneficiaires.GetItemChecked(i))
                {
                    //on recupére l'id du participant coché 
                    string nom = clbBeneficiaires.Items[i].ToString();
                    MessageBox.Show(nom);
                    string reqid = @"SELECT codeParticipant
                                     FROM Participants
                                     WHERE nomPart = '" + nom + "';";

                    cmd.CommandText = reqid;
                    int id = int.Parse(cmd.ExecuteScalar().ToString());


                    //On lui donne un mdp 
                    string pwd = getRandomPassword();


                    //On lui donne un id fixe 
                    cmd.CommandText = "SELECT prenomPart FROM Participants WHERE nomPart = '" + nom + "';";
                    MessageBox.Show("SELECT prenomPart FROM Participants WHERE nomPart = '" + nom + "';");
                    string login = (cmd.ExecuteScalar().ToString()).Substring(0, 1);
                    cmd.CommandText = "SELECT nomPart FROM Participants WHERE  nomPart = '" + nom + "';";
                    login += cmd.ExecuteScalar().ToString();


                    //on recupére son Email
                    string rqt = @"SELECT adresseMail 
                                    FROM Participants 
                                    WHERE nomPart = '" + nom + "';";
                    MessageBox.Show(rqt);
                    cmd.CommandText = rqt;
                    string email = cmd.ExecuteScalar().ToString();

                    

                 

                    // on recupére le nom de l'évenement 
                    string rqtNomEve = @"SELECT titreEvent 
                                         FROM Evenements
                                         WHERE codeEvent = " + Evenum + ";";
                    cmd.CommandText = rqtNomEve;

                    string evt = cmd.ExecuteScalar().ToString();

                    // description de l'évenement
                    string rqtDescriEve = @"SELECT description
                                         FROM Evenements
                                         WHERE codeEvent = " + Evenum + ";";
                    cmd.CommandText = rqtDescriEve;
                    string descriptEve = cmd.ExecuteScalar().ToString();

                    //debut de l'évenement
                    string rqtDebutEve = @"SELECT dateDebut
                                         FROM Evenements
                                         WHERE codeEvent = " + Evenum + ";";
                    cmd.CommandText = rqtDebutEve;
                    string dateDebEve = cmd.ExecuteScalar().ToString();

                    //fin de l'événement
                    string rqtFinEve = @"SELECT dateFin
                                         FROM Evenements
                                         WHERE codeEvent = " + Evenum + ";";
                    cmd.CommandText = rqtFinEve;
                    string dateFinEve = cmd.ExecuteScalar().ToString();

                    //On envoit le mail
                    SendMail(email, " Tu es invité à l'événement : " + evt, "Bonjour, \n\n Tu es invité a l'événement : " + evt + " \n Ton mot de passe est :" + pwd + "\n \n Description de l'évenement :" + descriptEve + "\n\n Du :"+dateDebEve+" Au :"+dateFinEve+"\n\n\n Mail automatique ne pas répondre svp");
                    
                    //On insert les valeurs 
                    string req = @"INSERT INTO Invites (codeEvent, codePart, login,mdp) 
                                    VALUES (" + Evenum + "," + id + ",'" + login + "','" + pwd + "');";

                    int n = 0;
                    MessageBox.Show(req);
                    cmd.CommandText = req;
                    try
                    {
                        n = cmd.ExecuteNonQuery();
                    }
                     catch (Exception et)
                    {
                        Console.WriteLine(et.Message);
                    }


                    MessageBox.Show(n + "");
                }
            }
            co.Close();
            

        }

        //Création du mdp 
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
                    */
                mail.To.Add(adresses);/*
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
