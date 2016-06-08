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
    public partial class Bilan : Form


    {

        private String chco = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=C:\Users\Arthur\Desktop\Cours\S2\D21\bdEvents.mdb";
        // private String chco = @"Provider = Microsoft.Jet.OLEDB.4.0; Data Source = C:\Users\bgallone\Source\Repos\projet_D22\Projet_fin\Projet_fin\Resources\bdEvents.mdb;Persist Security Info=True";
        private OleDbConnection co = new OleDbConnection();
        private DataSet ds = new DataSet();
        private DataSet ds2 = new DataSet();
        private DataSet ds3 = new DataSet();
        int noevtcourant;

        public Bilan()
        {
            InitializeComponent();
        }

        private void Bilan_Load(object sender, EventArgs e)
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
            noevtcourant = int.Parse(cbxEvenement.SelectedValue.ToString());
           

            co.Close();
        }

        private void Remplir(String requete, String nomTable)
        {
            
            OleDbCommand cmd = new OleDbCommand(requete, co);
            OleDbDataAdapter da = new OleDbDataAdapter();
            da.SelectCommand = cmd;

            da.Fill(ds, nomTable);
            co.Close();
        }

        private void remplirDataGridView(string reqdgv, DataGridView d, DataSet dset)
        {

            OleDbDataAdapter da = new OleDbDataAdapter(reqdgv, co);
            da.Fill(dset);
            d.DataSource = dset.Tables[0];
        }

        private void cbxParticipant_SelectionChangeCommitted(object sender, EventArgs e)
        {
           
        }

        private void cbxEvenement_SelectionChangeCommitted(object sender, EventArgs e)
        {
            co.Open();
            cbxParticipant.Items.Clear();
            noevtcourant = int.Parse(cbxEvenement.SelectedValue.ToString());
            string reqpart = @"Select p.nomPart
                           From Participants p, Invites i
                           Where p.codeParticipant = i.codePart    
                           and i.codeEvent = " + noevtcourant + ";";
            OleDbCommand cmd = new OleDbCommand(reqpart, co);
            OleDbDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                cbxParticipant.Items.Add(dr.GetString(0));

            }

            
            co.Close();
        }

        private void btnBilan_Click(object sender, EventArgs e)
        {
            ds2.Clear();
            co.Open();
         
            string reqdgv1 = @"SELECT p.nomPart, d.description, d.dateDepense, d.montant
                              FROM Participants p, Depenses d
                              WHERE d.codePart = p.codeParticipant AND 
                              d.codeEvent = " + cbxEvenement.SelectedValue + @" 
                              AND d.codePart = (SELECT codeParticipant
                                                FROM Participants
                                                WHERE nomPart = '" + cbxParticipant.Text + "'); ";;
            remplirDataGridView(reqdgv1, dgvDépensé, ds2);


            /* string reqdgv2 = @"SELECT p.nomPart, d.description, d.dateDepense, d.montant
                             FROM Participants p, Depenses d, Beneficiaires b
                             WHERE b.codePart = d.codePart
                             AND d.codePart = p.codeParticipant
                             AND d.codePart = (SELECT codeParticipant
                                               FROM Participants
                                               WHERE nomPart = '" + cbxParticipant.Text + "';";*/
            string reqdgv2 = "Select * from Participants";
            remplirDataGridView(reqdgv2, dgvArembourser, ds3);
            co.Close();
        }
    }
}
