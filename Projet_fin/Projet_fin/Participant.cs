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

        public Participant()
        {
            InitializeComponent();
        }

        private void Participant_Load(object sender, EventArgs e)
        {
            co.ConnectionString = chco;
            co.Open();
            OleDbCommand cmd = new OleDbCommand();
            cmd.Connection = co;
            cmd.CommandType = CommandType.Text;
            string req = @"SELECT [titreEvent] 
                            FROM Evenements;";
            cmd.CommandText = req;
            Remplir(req, "events");
            cbxEvent.DataSource = ds.Tables["events"];
            cbxEvent.DisplayMember = "titreEvent";
            aff_info();
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
            String rqt = @"SELECT p.nomPart, p.prenomPart 
                           FROM Invites i,Participants p 
                           WHERE i.codePart = p.codeParticipant 
                           AND i.codeEvent = ( SELECT codeEvent
                                               FROM Evenements
                                               WHERE titreEvent = " + evnt + ");";

            OleDbCommand cmd = new OleDbCommand();
            cmd.CommandText = rqt;
            cmd.Connection = co;
            OleDbDataReader dr = cmd.ExecuteReader();
            dataGridView1.DataSource = dr;
            MessageBox.Show(dr.ToString());
        }

        private void cbxEvent_SelectedIndexChanged(object sender, EventArgs e)
        {
            aff_info();
        }

    }
}
