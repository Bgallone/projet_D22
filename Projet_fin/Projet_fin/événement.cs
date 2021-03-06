﻿using System;
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

        String chco;//= @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=C:\Users\Arthur\Desktop\Cours\S2\D21\bdEvents.mdb";
        //String chco = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=C:\Users\Gladmir\Source\Repos\projet_D22\Projet_fin\Projet_fin\Resources\bdEvents.mdb;Persist Security Info=True";
        //String chco = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source =.\Resources\bdEvents.mdb";
        
        OleDbConnection co = new OleDbConnection();
        DataTable Liaison;
        BindingSource BS = new BindingSource();

        public événement(String chco)
        {
            InitializeComponent();
            this.chco = chco;
        }
        int NumReq = 1;
        int NbPage;


        private void événement_Load(object sender, EventArgs e)
        {
            string requete = @"SELECT e.*,[p.nomPart] as NomCrea FROM Evenements e , Participants p
                            WHERE p.codeParticipant =e.codeCreateur;";
            co = new OleDbConnection(chco);
            OleDbCommand cmd = new OleDbCommand(requete, co);
            OleDbDataAdapter da = new OleDbDataAdapter(cmd);
            DataSet resultat = new DataSet();

            da.SelectCommand = cmd;

            da.Fill(resultat, "TableDeLiaison");
            //nous donne le nombre d'événement.
            Liaison = resultat.Tables["TableDeLiaison"];

            NbPage = Liaison.Rows.Count;


            BS.DataSource = Liaison;

            LblCréateur.DataBindings.Add("Text", BS, "NomCrea");
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
            while (dr.Read())
            {
                cboCreateur.Items.Add(dr.GetString(0) + " " + dr.GetString(1));
            }

            // on ferme la connections
            co.Close();



        }
        private void button3_Click(object sender, EventArgs e)
        {
            if (NumReq != NbPage)
            {
                NumReq++;
                //change
                BS.MoveNext();
                lblNumChange.Text = "" + NumReq + " ";
            }

        }

        private void btnPre_Click(object sender, EventArgs e)
        {
            if (NumReq != 1)
            {
                NumReq--;
                //change
                BS.MovePrevious();
                lblNumChange.Text = "" + NumReq + " ";
            }
        }

        private void BtnDebut_Click(object sender, EventArgs e)
        {
            if (NumReq != 1)
            {
                NumReq = 1;
                //change
                BS.MoveFirst();
                lblNumChange.Text = "" + NumReq + " ";
            }
        }

        private void btnFin_Click(object sender, EventArgs e)
        {
            NumReq = NbPage;
            //change
            BS.MoveLast();
            lblNumChange.Text = "" + NumReq + " ";
        }



        private void cboCreateur_KeyPress(object sender, KeyPressEventArgs e)
        {

            e.Handled = true;

        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\'' || e.KeyChar == '^' || e.KeyChar == '#' || e.KeyChar == '|' || e.KeyChar == '&' || e.KeyChar == '~' || e.KeyChar == '}' || e.KeyChar == '{' || e.KeyChar == '\\' || e.KeyChar == '@')
            {
                e.Handled = true;
            }
            if (txtTitre.Text.Length > 0)
            {
                if (txtTitre.Text.Substring(txtTitre.Text.Length - 1) == " ")
                {
                    if (e.KeyChar == ' ')
                    {
                        e.Handled = true;
                    }
                }
            }
        }

        private void btnInvitation_Click(object sender, EventArgs e)
        {
            Form inv = new Invitation(chco);
            inv.ShowDialog();

        }

        private void btnEnregister_Click(object sender, EventArgs e)
        {
          
            OleDbCommand cmd = new OleDbCommand();
            cmd.Connection = co;
            co.ConnectionString = chco;
            co.Open();

            //Titre de l'éve
            string titre = txtTitre.Text;


            // on gere les dates 
            DateTime dateDeb =  ConvertToDateTime(dtpEveDeb.Text);
            
            DateTime dateFin = ConvertToDateTime(dtpEveFin.Text);

            //Si les dates sont incorrect
            if (dateDeb > dateFin)
            {
                MessageBox.Show("La date de fin ne peut pas être avant la date de début.");
            }
            //Si les dates sont justes 
            else {

            //description de l'événement 
            string description = rtbDescript.Text;

            //On recupere le nom du créateur;
            string Nom = cboCreateur.Text;
            Char delimiter = ' ';
            String[] substrings = Nom.Split(delimiter);
            Nom = substrings[0];


            string req = @"SELECT codeParticipant FROM Participants
                            WHERE nomPart ='" + Nom + "';";
                                   
            cmd.CommandText = req;
            
            int codCrea = int.Parse(cmd.ExecuteScalar().ToString());

            //Num de l'événement 
            req = @"SELECT count(*)  FROM Evenements";
            cmd.CommandText = req;
            int evenum = int.Parse(cmd.ExecuteScalar().ToString())+1;


            bool valSolde = false;

            req = @"INSERT INTO Evenements(codeEvent,titreEvent,dateDebut,dateFin,description,soldeON,codeCreateur)
                            VALUES(" + evenum + ",'" + titre + "',#" + dateDeb + "#,#" + dateFin + "#,'" + description + "'," + valSolde + "," + codCrea + ");";
            cmd.CommandText = req;

            int n = cmd.ExecuteNonQuery();
             //on ajoute le créeteur à l'événement
 
            //On lui donne un mdp 
            string pwd = getRandomPassword();


            //On lui donne un id fixe 
            cmd.CommandText = "SELECT prenomPart FROM Participants WHERE nomPart = '" + Nom + "';";

            string login = (cmd.ExecuteScalar().ToString()).Substring(0, 1);
            cmd.CommandText = "SELECT nomPart FROM Participants WHERE  nomPart = '" + Nom + "';";
            login += cmd.ExecuteScalar().ToString();
            if (login.Length > 8)
            {
                login = login.Substring(0, 8);
            }

            // On l'ajoute au invité 
            string reqInsCré = @"INSERT INTO Invites (codeEvent, codePart, login,mdp) 
                VALUES (" + evenum + "," + codCrea + ",'" + login + "','" + pwd + "');";

            cmd.CommandText = reqInsCré;
            
             n = cmd.ExecuteNonQuery();


            btnInvitation.Enabled = true;
            
            co.Close();
            }
        }

        private void cboCreateur_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnEnregister.Enabled = true;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (txtTitre.Text != " ")
            {
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
            if (e.KeyChar == '\'')
            {
                e.Handled = true; 
            }
            if (rtbDescript.Text.Length > 0)
            {
                if (rtbDescript.Text.Substring(rtbDescript.Text.Length - 1) == " ")
                {
                    if (e.KeyChar == ' ' )
                    {
                        e.Handled = true;
                    }
                }
            }
        }

        private static DateTime ConvertToDateTime(string value)
        {
            DateTime convertedDate;
            convertedDate = Convert.ToDateTime(value);
            return convertedDate;
            
        }
        
        //Création du mdp 
        private static char[] randomChars = new char[] { 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z', 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z', '9', '8', '7', '6', '5', '4', '3', '2', '1', '0' };
        private static readonly Random rand = new Random();



        private static string getRandomPassword()
        {

            char[] password = new char[10];

            for (int i = 0; i < 10; ++i)

                password[i] = randomChars[rand.Next(0, randomChars.Length)];

            return new string(password);

        }

        private void btnQuitter_Click(object sender, EventArgs e)
        {
            this.Close();
            
        }
    }
}
