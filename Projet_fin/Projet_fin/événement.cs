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
        DataTable Liaison;
        BindingSource BS = new BindingSource();
        public événement()
        {
            InitializeComponent();
        }
        int NumReq=1;
        int NbPage;

 
        private void événement_Load(object sender, EventArgs e)
        {
            string requete = @"SELECT e.*,[p.nomPart] FROM Evenements e , Participants p
                            WHERE p.codeParticipant =e.codeCreateur;";
           
            co = new OleDbConnection(chco);
            OleDbCommand cmd = new OleDbCommand(requete, co);
            OleDbDataAdapter da = new OleDbDataAdapter(cmd);
            DataSet resultat = new DataSet();
            
            da.SelectCommand = cmd;

            da.Fill(resultat,"TableDeLiaison");
            
            //nous donne le nombre d'événement.
            Liaison = resultat.Tables["TableDeLiaison"];

            NbPage = Liaison.Rows.Count;


            BS.DataSource = Liaison;

            LblCréateur.DataBindings.Add("Text", BS, "codeCreateur");
            LblEveInt.DataBindings.Add("Text", BS, "titreEvent");
            rtbEveDescri.DataBindings.Add("Text", BS, "description");
            lblDeb.DataBindings.Add("Text", BS, "dateDebut");
            lblFin.DataBindings.Add("Text", BS, "dateFin");
            cckRegle.DataBindings.Add("Checked", BS, "soldeON");

            // met en place tout les participant dans la cboCreateur
            OleDbCommand cmd1 = new OleDbCommand();
            cmd1.Connection = co;
            co.ConnectionString = chco;
            co.Open();
            string req = @"SELECT [nomPart],[prenomPart]
                   FROM Participants ;";

            cmd.CommandText = req;
            OleDbDataReader dr = cmd.ExecuteReader();
            while(dr.Read())
            {
                cboCreateur.Items.Add(dr.GetString(0) +" "+ dr.GetString(1));
            }

            // on ferme la connections
            co.Close();
            

        
        }
        private void button3_Click(object sender, EventArgs e)
        {
            if (NumReq != NbPage)
            {
                NumReq++;
                cckRegle.Checked = false;
               /* //remplir(NumReq,Liaison);
                LblCréateur.DataBindings.
                LblEveInt.DataBindings.
                rtbEveDescri.DataBindings.
                lblDeb.DataBindings.
                lblFin.DataBindings.
                cckRegle.DataBindings.*/

                lblNumChange.Text = "" + NumReq + " ";
            }

        }

        private void btnPre_Click(object sender, EventArgs e)
        {
            if (NumReq != 1 )
            {
                NumReq--;
                cckRegle.Checked = false;
                //remplir(NumReq,Liaison);
                lblNumChange.Text = "" + NumReq + " ";
            }
        }

        private void BtnDebut_Click(object sender, EventArgs e)
        {
            if (NumReq != 1)
            {
                NumReq = 1;
                cckRegle.Checked = false;
                //remplir(NumReq, Liaison);
                lblNumChange.Text = "" + NumReq + " ";
            }
        }

        private void btnFin_Click(object sender, EventArgs e)
        {
            NumReq = NbPage;
            cckRegle.Checked = false;
            //remplir(NumReq, Liaison);
            lblNumChange.Text = "" + NumReq + " ";
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
            Form inv = new Invitation();
            inv.ShowDialog();
            
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
