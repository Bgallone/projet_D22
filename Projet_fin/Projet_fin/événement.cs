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
            //nous donne le nombre d'événement.
            string req = @"SELECT count(*)
                            FROM Evenements;";
            cmd.CommandText = req;
            NbPage = (int)cmd.ExecuteScalar();

            // met en place tout les participant dans la cboCreateur

            req = @"SELECT [nomPart],[prenomPart]
                   FROM Participants ;";

            cmd.CommandText = req;
            OleDbDataReader dr = cmd.ExecuteReader();
            while(dr.Read())
            {
                cboCreateur.Items.Add(dr.GetString(0) +" "+ dr.GetString(1));
            }

            // on ferme la connections
            co.Close();
            remplir( NumReq);

        
        }
        private void button3_Click(object sender, EventArgs e)
        {
            if (NumReq != NbPage)
            {
                NumReq++;
                cckRegle.Checked = false;
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
                cckRegle.Checked = false;
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
                cckRegle.Checked = false;
                remplir(NumReq);
                lblNumChange.Text = "" + NumReq + " ";
                pgb_Prog.Value = 0;
            }
        }

        private void btnFin_Click(object sender, EventArgs e)
        {
            NumReq = NbPage;
            cckRegle.Checked = false;
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
            rtbEveDescri.Text = res;

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

            req = @"SELECT [soldeON]
                    FROM Evenements
                    WHERE codeEvent = " + NumReq + ";";
            cmd.CommandText = req;
            res = cmd.ExecuteScalar().ToString();
            if (res == "True")
            {
                cckRegle.Checked = true;
            }

            co.Close();

        }


        private void cboCreateur_KeyPress(object sender, KeyPressEventArgs e)
        {
          
                e.Handled = true;
            
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '^' || e.KeyChar == '#' || e.KeyChar == '|' || e.KeyChar == '&' || e.KeyChar == '~' || e.KeyChar == '}' || e.KeyChar == '{' || e.KeyChar == '\\' || e.KeyChar == '@')
            {
                e.Handled = true; 
            }
            if(txtTitre.Text.Length>0)
            {
                if (txtTitre.Text.Substring(txtTitre.Text.Length-1) == " ")
                {
                    if(e.KeyChar == ' ')
                    {
                        e.Handled = true;
                    }
                }
            }
        }

        private void btnInvitation_Click(object sender, EventArgs e)
        {

        }

        private void btnEnregister_Click(object sender, EventArgs e)
        {
            btnInvitation.Enabled = true; 
        }

        private void cboCreateur_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnEnregister.Enabled = true;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (txtTitre.Text != " ") { 
            rtbDescript.Enabled = true;
            }
         
        }

        private void rtbDescript_TextChanged(object sender, EventArgs e)
        {
            if (rtbDescript.Text != " ")
            {
                cboCreateur.Enabled = true;
            }
        }

        private void rtbDescript_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (rtbDescript.Text.Length > 0)
                        {
                            if (rtbDescript.Text.Substring(rtbDescript.Text.Length - 1) == " ")
                            {
                                if (e.KeyChar == ' ')
                                {
                                    e.Handled = true;
                                }
                            }
                        }
        }

    }
}
