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

namespace Projet_fin
{
    public partial class Participant : Form
    {

        private String chco ;//= @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=./Resources/bdEvents.mdb";
        private OleDbConnection co = new OleDbConnection();
        private DataSet ds = new DataSet();
        private int CodeEvent = 1;
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
            String nom = cbxAdd.Text;
            String pwd = getRandomPassword();
            String req = @"INSERT INTO invite Depenses(codeEvent, codePart, login,mdp) VALUES ((SELECT codeEvent FROM Evenements WHERE titreEvent = '" + evt + "'),(SELECT codeParticipant FROM Participants WHERE (prenomPart + ' ' + nomPart) = '" + nom + "' ),(SELECT SUBSTR(prenomPart, 1, 1)+ nomPart FROM Participant WHERE (prenomPart + ' ' + nomPart) = '" + nom + "' ), '" + pwd + "'); ";
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

    }
}
