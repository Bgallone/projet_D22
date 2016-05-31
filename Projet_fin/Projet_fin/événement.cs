using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Projet_fin
{
    public partial class événement : Form
    {

        String chco = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=./Resources/bdEvents.mdb";
        OleDbConnection co = new OleDbConnection();
        DataSet ds = new DataSet();

        public événement()
        {
            InitializeComponent();
        }
        int NumReq=1;
        int NbPage = 5;
        private void événement_Load(object sender, EventArgs e)
        {
            string res = "";
            co.ConnectionString = chco;
            co.Open();
            OleDbCommand cmd = new OleDbCommand();
            cmd.Connection = co;
            cmd.CommandType = CommandType.Text;
            string req = @"SELECT [titreEvent] 
                            FROM Evenements
                WHERE codeEvent = '"+NumReq+"';";
            cmd.CommandText = req;
            res = cmd.ExecuteScalar().ToString();
            LblEveInt.Text = res;
        
        }
        private void button3_Click(object sender, EventArgs e)
        {
            if (NumReq != NbPage)
            {
                NumReq++;
                lblNumChange.Text = "" + NumReq + " ";
                pgb_Prog.Value += 100/(NbPage-1);
            }

        }

        private void btnPre_Click(object sender, EventArgs e)
        {
            if (NumReq != 1 )
            {
                NumReq--;
                lblNumChange.Text = "" + NumReq + " ";
                pgb_Prog.Value -= 100/(NbPage-1);
            }
        }

        private void BtnDebut_Click(object sender, EventArgs e)
        {
            NumReq = 1;
            lblNumChange.Text = "" + NumReq + " ";
            pgb_Prog.Value = 0;
        }

        private void btnFin_Click(object sender, EventArgs e)
        {
            NumReq = NbPage;
            lblNumChange.Text = "" + NumReq + " ";
            pgb_Prog.Value = 100;
        }




    }
}
