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


    public partial class FrmLancement : Form
    {

        String chco = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source =./Resources/bdEvents.mdb";
        OleDbConnection co = new OleDbConnection();
        DataSet ds = new DataSet();




        public FrmLancement()
        {
            InitializeComponent();

        }

        private void FrmLancement_Load(object sender, EventArgs e)
        {

            OleDbCommand cmd = new OleDbCommand();
            cmd.Connection = co;
            co.ConnectionString = chco;
            co.Open();

            cmd.CommandType = CommandType.Text;
            string req = @"SELECT [titreEvent], [codeEvent] 
                            FROM Evenements;";
            cmd.CommandText = req;
            Remplir(req, "events");
            cbxEvenement.DataSource = ds.Tables["events"];
            cbxEvenement.DisplayMember = "titreEvent";
            cbxEvenement.ValueMember = "codeEvent";

           

        }

        private void Remplir(String requete, String nomTable)
        {

            OleDbCommand cmd = new OleDbCommand(requete, co);
            OleDbDataAdapter da = new OleDbDataAdapter();
            da.SelectCommand = cmd;

            da.Fill(ds, nomTable);
        }

        private void RemplirCheckListBox(int noevent, CheckedListBox clb)
        {
            OleDbCommand cmd = new OleDbCommand();
            cmd.Connection = co;

            cmd.CommandType = CommandType.Text;
            string req = @"Select p.nomPart
                           From Participants p, Invites i
                           Where p.codeParticipant = i.codePart    
                           and i.codeEvent = " + noevent + ";";
            cmd.CommandText = req;

            OleDbDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                clb.Items.Add(dr.GetString(0));
            }


        }

        private void btn_part_Click(object sender, EventArgs e)
        {
            Form Form1 = new Participant();
            Form1.Show();
        }






        private void btn_event_Click(object sender, EventArgs e)
        {
            Form Form1 = new événement();
            Form1.Show();
        }

        private void btn_Accueil_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void btn_RAZ_Click(object sender, EventArgs e)
        {

        }

        private void btn_Quit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {


        }

        private void cbxEvenement_SelectionChangeCommitted(object sender, EventArgs e)
        {

           
            OleDbCommand cmd = new OleDbCommand();
            cmd.Connection = co;
            cmd.CommandType = CommandType.Text;
            clbBeneficiaires.Items.Clear();
            string evt = cbxEvenement.SelectedValue.ToString();
            int noevent = int.Parse(evt);

            RemplirCheckListBox(noevent, clbBeneficiaires);
          
            string req = @"Select p.nomPart
                           From Participants p, Invites i
                           Where p.codeParticipant = i.codePart    
                           and i.codeEvent = " + noevent + ";";
            cmd.CommandText = req;
            OleDbDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                cbxPayePar.Items.Add(dr.GetString(0));
            }



        }

        private void cbxEvenement_Click(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void btnValider_Click(object sender, EventArgs e)
        {
            double montant = 12;
            string commentaire = txtCommentaire.Text;
            string desc = txtDepense.Text;
            int codePart = cbxPayePar.SelectedIndex;
            DateTime date = dateTimePicker1.Value.Date;

            string req = @"INSERT INTO Depenses(numDepense, description,montant, dateDepense, codeEvent, commentaire,codePart) 
                            VALUES('15', 'wesh alors', '18', '" + date + "','4', 'wesh', '4'); ";
            
            MessageBox.Show(req);
            OleDbCommand cmd = new OleDbCommand(req, co);
            int n = cmd.ExecuteNonQuery();
            MessageBox.Show(n.ToString());
   
        }
    }
}
    

