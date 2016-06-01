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
            Remplir(req, "events");
            cbxEvent.DataSource = ds.Tables["events"];
            cbxEvent.DisplayMember = "titreEvent";       
        }

        private void Remplir(String requete, String nomTable)
        {
            OleDbCommand cmd = new OleDbCommand(requete, co);
            OleDbDataAdapter da = new OleDbDataAdapter();
            da.SelectCommand = cmd;
            da.Fill(ds, nomTable);
            //MessageBox.Show(ds.Tables[nomTable].Rows.Count.ToString()); //debug         
        }

        private void aff_info()
        {
            
            String evnt = cbxEvent.Text;
            MessageBox.Show(evnt);
            //String rqt = @"SELECT * FROM Evenements WHERE titreEvent = '"+ evnt +"';";
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

        private void button1_Click(object sender, EventArgs e)
        {

        }

    }
}
