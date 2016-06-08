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


        public Invitation(String chco)
        {
            InitializeComponent();
            this.chco = chco;
            
        }


        private void toutcocher(object sender, EventArgs e)
        {
            if (chxTtSelectionner.Checked)
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

        private void Invitation_Load(object sender, EventArgs e)
        {   
            OleDbCommand cmd = new OleDbCommand();
            cmd.Connection = co;
            co.ConnectionString = chco;


            RemplirCheckListBox();

        }
        private void RemplirCheckListBox()
        {
            co.Open();
            OleDbCommand cmd = new OleDbCommand();
            cmd.Connection = co;

            cmd.CommandType = CommandType.Text;
            //Num de l'événement 
            string req = @"SELECT count(*)  FROM Evenements";
            cmd.CommandText = req;
            int evenum = int.Parse(cmd.ExecuteScalar().ToString());

            //Num du créateur de l'évenement 
            req = @"SELECT codeCreateur FROM Evenements 
                           WHERE codeEvent = " + evenum + ";";
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
