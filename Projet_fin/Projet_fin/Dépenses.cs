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
    public partial class Dépenses : Form
    {

        private String chco = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=C:\Users\Arthur\Desktop\Cours\S2\D21\bdEvents.mdb";
       // private String chco = @"Provider = Microsoft.Jet.OLEDB.4.0; Data Source = C:\Users\bgallone\Source\Repos\projet_D22\Projet_fin\Projet_fin\Resources\bdEvents.mdb;Persist Security Info=True";
        private OleDbConnection co = new OleDbConnection();
        private DataSet ds = new DataSet();
        private DataSet ds2 = new DataSet();
        static int evtcourant;
        string reqdgv = @"SELECT p.nomPart, p.prenomPart, d.description , d.montant
                            FROM Participants p, Depenses d
                            WHERE p.codeParticipant = d.codePart
                            AND d.codeEvent = " + evtcourant + ";";


       

        public Dépenses(String chco)
        {
            InitializeComponent();
            this.chco = chco;
            
        }

        private void Dépenses_Load(object sender, EventArgs e)
        {
          
            OleDbCommand cmd = new OleDbCommand();
            cmd.Connection = co;
            co.ConnectionString = chco;
            co.Open();

            cmd.CommandType = CommandType.Text;
            string req = @"SELECT [titreEvent], [codeEvent]
                            FROM Evenements;";
           
            cmd.CommandText = req;
            co.Close();
            Remplir(req, "events");
            
            co.Open();
            cbxEvenement.DataSource = ds.Tables["events"];
            cbxEvenement.DisplayMember = "titreEvent";
            cbxEvenement.ValueMember = "codeEvent";

            remplirDataGridView(reqdgv);

            co.Close();
        }

        private void Remplir(String requete, String nomTable)
        {
            co.Open();
            OleDbCommand cmd = new OleDbCommand(requete, co);
            OleDbDataAdapter da = new OleDbDataAdapter();
            da.SelectCommand = cmd;

            da.Fill(ds, nomTable);
            co.Close();
        }

        private void remplirDataGridView(string reqdgv)
        {
            
            OleDbDataAdapter da = new OleDbDataAdapter(reqdgv, co);
            da.Fill(ds2);
            dgvDepense.DataSource = ds2.Tables[0];
        }

      

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void cbxEvenement_SelectedIndexChanged(object sender, EventArgs e)
        {

          
        }

        private void chxAll_CheckedChanged(object sender, EventArgs e)
        {
            if (chxAll.Checked)
            {
                string req = @"SELECT p.nomPart, p.prenomPart, d.description , d.montant
                            FROM Participants p, Depenses d
                            WHERE p.codeParticipant = d.codePart";
                

            }
            else
            {
                remplirDataGridView(reqdgv);
            }
        }

        private void cbxEvenement_SelectionChangeCommitted(object sender, EventArgs e)
        {
            co.Open();
            ds2.Clear();

/*
            string req = @"SELECT codeEvent 
                            FROM Evenements
                            WHERE titreEvent = '" + cbxEvenement.Text + "';";*/
           

//            evtcourant = int.Parse(cmd.ExecuteScalar().ToString());
           

            string req1 = @"SELECT p.nomPart, p.prenomPart, d.description , d.montant
                            FROM Participants p, Depenses d
                            WHERE p.codeParticipant = d.codePart 
                            AND codeEvent = " + cbxEvenement.SelectedValue + ";";
            OleDbCommand cmd = new OleDbCommand(req1, co);
            remplirDataGridView(req1);
            co.Close();
        }
    }
}
