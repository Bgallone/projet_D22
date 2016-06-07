﻿using System;
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

        String chco = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=C:\Users\Arthur\Desktop\Cours\S2\D21\bdEvents.mdb";
        //String chco = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=C:\Users\Gladmir\Source\Repos\projet_D22\Projet_fin\Projet_fin\Resources\bdEvents.mdb;Persist Security Info=True";
        //String chco = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source =.\Resources\bdEvents.mdb";
        OleDbConnection co = new OleDbConnection();
        DataSet ds = new DataSet();
        int noevent;
        




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
                            FROM Evenements WHERE soldeON = false;";
            cmd.CommandText = req;
            co.Close();
            Remplir(req, "events");
            co.Open();
            cbxEvenement.DataSource = ds.Tables["events"];
            cbxEvenement.DisplayMember = "titreEvent";
            cbxEvenement.ValueMember = "codeEvent";
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

        private void RemplirCheckListBox(int noevent, CheckedListBox clb)
        {
            co.Open();
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

            co.Close();
        }

        private void btn_part_Click(object sender, EventArgs e)
        {
            Form Form1 = new Participant(chco);
            Form1.Show();
        }






        private void btn_event_Click(object sender, EventArgs e)
        {
            Form Form1 = new événement(chco);
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
            txtCommentaire.Clear();
            txtDepense.Clear();
            txtMontant.Clear();
            clbBeneficiaires.Items.Clear();

            
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
            co.Open();
            cbxPayePar.Items.Clear();
            OleDbCommand cmd = new OleDbCommand();
            cmd.Connection = co;
            cmd.CommandType = CommandType.Text;
            clbBeneficiaires.Items.Clear();
            string evt = cbxEvenement.SelectedValue.ToString();
            noevent = int.Parse(evt);
            co.Close();
            RemplirCheckListBox(noevent, clbBeneficiaires);

            co.Open();
            string req = @"Select p.nomPart, p.codeParticipant
                           From Participants p, Invites i
                           Where p.codeParticipant = i.codePart    
                           and i.codeEvent = " + noevent + ";";
            cmd.CommandText = req;
            OleDbDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                cbxPayePar.Items.Add(dr.GetString(0));

            }

            co.Close();


        }

        private void cbxEvenement_Click(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
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

        private void btnValider_Click(object sender, EventArgs e)
        {
            co.Open();
            string req = @"SELECT codeParticipant FROM Participants WHERE nomPart = '" + cbxPayePar.Text + "';";
            MessageBox.Show(req);
            OleDbCommand cmd = new OleDbCommand(req, co);
            int codePart = int.Parse(cmd.ExecuteScalar().ToString());

            req = @"Select count(*) from Depenses;";
            cmd.CommandText = req;
            int numDep = int.Parse(cmd.ExecuteScalar().ToString());
            
            req = @"INSERT INTO Depenses(numDepense,description,montant, dateDepense, codeEvent, commentaire,codePart) 
                            VALUES('" + numDep + "', '" + txtDepense.Text + "', '" + double.Parse(txtMontant.Text) +"', '" + dateTimePicker1.Value.Date +
                                      "','" + noevent + "', '" + txtCommentaire.Text + "', '"+ codePart +"');";

            cmd.CommandText = req;
            MessageBox.Show(req);
            
            int n = cmd.ExecuteNonQuery();
            MessageBox.Show(n.ToString());

            co.Close();

   
        }

        private void btn_dep_Click(object sender, EventArgs e)
        {
            Form Form1 = Dépenses(chco);
            Form1.Show();
        }
    }
}
    

