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
        int NbPage;
        private void événement_Load(object sender, EventArgs e)
        {
            co.ConnectionString = chco;
            co.Open();
            OleDbCommand cmd = new OleDbCommand();
            cmd.Connection = co;
            cmd.CommandType = CommandType.Text;
            string req = @"SELECT count(*)
                            FROM Evenements;";
            cmd.CommandText = req;
            NbPage = (int)cmd.ExecuteScalar();
            co.Close();
            remplir( NumReq);
        
        }
        private void button3_Click(object sender, EventArgs e)
        {
            if (NumReq != NbPage)
            {
                NumReq++;
                remplir(NumReq);
                lblNumChange.Text = "" + NumReq + " ";
                pgb_Prog.Value += 100/(NbPage-1);
            }

        }

        private void btnPre_Click(object sender, EventArgs e)
        {
            if (NumReq != 1 )
            {
                NumReq--;
                remplir(NumReq);
                lblNumChange.Text = "" + NumReq + " ";
                pgb_Prog.Value -= 100/(NbPage-1);
            }
        }

        private void BtnDebut_Click(object sender, EventArgs e)
        {
            if (NumReq != 1)
            {
                NumReq = 1;
                remplir(NumReq);
                lblNumChange.Text = "" + NumReq + " ";
                pgb_Prog.Value = 0;
            }
        }

        private void btnFin_Click(object sender, EventArgs e)
        {
            NumReq = NbPage;
            remplir(NumReq);
            lblNumChange.Text = "" + NumReq + " ";
            pgb_Prog.Value = 100;
        }

        private void remplir(int Numero_req){

            string res = "";
            co.ConnectionString = chco;
            co.Open();
            OleDbCommand cmd = new OleDbCommand();
            cmd.Connection = co;
            cmd.CommandType = CommandType.Text;
            
            // met le nom de l'événement
            string req = @"SELECT [titreEvent] 
                            FROM Evenements
                WHERE codeEvent = "+NumReq+";";

            cmd.CommandText = req;
            res = cmd.ExecuteScalar().ToString();
            LblEveInt.Text = res;

            // met le nom du créateur 
            req = @"SELECT [p.nomPart]
                    FROM Participants p
                    WHERE p.codeParticipant =(SELECT [codeCreateur]
                                            FROM Evenements
                                            WHERE codeEvent = "+NumReq+");";
            cmd.CommandText = req;
            res = cmd.ExecuteScalar().ToString();
            LblCréateur.Text = res;
            
            // met la description de l'événement 

            req = @"SELECT [description]
                    FROM Evenements
                    WHERE codeEvent = " + NumReq +";";
            cmd.CommandText = req;
            res = cmd.ExecuteScalar().ToString();
            LblEveDescri.Text = res;

            // met la date de debut 
            req = @"SELECT [dateDebut]
                    FROM Evenements
                    WHERE codeEvent = " + NumReq + ";";
            cmd.CommandText = req;
            res = cmd.ExecuteScalar().ToString();
            lblDeb.Text = res;
           
            //met la date de fin 
            req = @"SELECT [dateFin]
                    FROM Evenements
                    WHERE codeEvent = " + NumReq + ";";
            cmd.CommandText = req;
            res = cmd.ExecuteScalar().ToString();
            lblFin.Text = res;

            //coche si l'événement est réglée 

            co.Close();

        }


    }
}
