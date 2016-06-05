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

        String chco = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=./Resources/bdEvents.mdb";
        OleDbConnection co = new OleDbConnection();
        DataSet ds = new DataSet();
        bool load = false;

        public Participant()
        {
            InitializeComponent();
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
            da.Fill(participants,"participants");
            dataGridView1.DataSource = participants.Tables[0];
        }

        private void cbxEvent_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (load){
                aff_info();
            }else{
                load = true;
            }
        }

        private void btnInv_Click(object sender, EventArgs e)
        {
            gbxAdd.Visible = true;
            cbxAdd.Visible = true;
            btnAdd.Visible = true;
            lblAdd.Visible = true;

            String evt = cbxEvent.Text;
            String reqt = @"
                           SELECT p.prenomPart + ' ' + p.nomPart as nom
                           FROM Participants p 
                          ;";
            DataSet invite = new DataSet();

            OleDbDataAdapter dt = new OleDbDataAdapter();
            OleDbCommand cmd = new OleDbCommand(reqt, co);
            dt.SelectCommand = cmd;
           
            dt.Fill(invite, "invite");
            cbxAdd.DataSource = invite.Tables["invite"];
            cbxAdd.DisplayMember = "nom";
        }


    }
}
