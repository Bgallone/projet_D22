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
      
        DataSet ds;
        OleDbDataAdapter da;
        DataTable dt;
        String chco = @"Provider=Microsoft.Jet.OLEDB.4.0;Data 
                        Source=C:\Users\Arthur\Source\Repos\projet_D22\Projet_fin\Projet_fin\Resources\bdEvents.mdb";

        public FrmLancement()
        {
            InitializeComponent();
            
        }

        private void FrmLancement_Load(object sender, EventArgs e)
        {
            String cmd1 = @"SELECT count(*) 
                            FROM Evenements;";
            Chargement(cmd1, cbxEvenement);
            OleDbConnection co = new OleDbConnection(chco);
            co.Open();
            OleDbCommand cd = new OleDbCommand(cmd1, co);
            cd.CommandType = CommandType.Text;
        }

        private void btn_part_Click(object sender, EventArgs e)
        {

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

        private void Chargement(string requete, ComboBox cbo)
        {
            OleDbConnection co = new OleDbConnection(chco);
            co.Open();
            OleDbCommand cmd = new OleDbCommand(requete, co);

            OleDbDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                cbo.Items.Add(dr.GetString(0));
            }
            co.Close();
        }


    }
}
