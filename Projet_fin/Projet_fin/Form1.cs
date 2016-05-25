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
     
        String chco = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=./Resources/bdEvents.mdb";
        OleDbConnection co = new OleDbConnection();
        DataSet ds = new DataSet();


        public FrmLancement()
        {
            InitializeComponent();
            
        }

        private void FrmLancement_Load(object sender, EventArgs e)
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
            cbxEvenement.DataSource = ds.Tables["events"];
            cbxEvenement.DisplayMember = "titreEvent";
            cbxEvenement.ValueMember = "codeEvent";

            
        }

        private void btn_part_Click(object sender, EventArgs e)
        {

        }

        private void Remplir(String requete, String nomTable)
        {

            OleDbCommand cmd = new OleDbCommand(requete, co);
            OleDbDataAdapter da = new OleDbDataAdapter();
            da.SelectCommand = cmd;

            da.Fill(ds, nomTable);
            // MessageBox.Show(ds.Tables[nomTable].Rows.Count.ToString());             
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

       


    }
}
