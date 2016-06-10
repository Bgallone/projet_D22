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
    public partial class AjouterParticipant : Form
    {
        private string chco;
        OleDbConnection co = new OleDbConnection();


        public AjouterParticipant(string chco)
        {
            co.ConnectionString = chco;
            this.chco = chco;
            InitializeComponent();
        }

        private void btnAjouter_Click(object sender, EventArgs e)
        {
            co.Open();
            string req = @"SELECT count(*) 
                           FROM Participants;";
            OleDbCommand cmd = new OleDbCommand(req, co);
            try {
                int nbpart = int.Parse(cmd.ExecuteScalar().ToString()) + 1;

                req = @"INSERT INTO Participants(codeParticipant, nomPart, prenomPart, mobile, nbParts, adresseMail)
                          VALUES(" + nbpart + ",'" + txtNom.Text + "', '" + txtPrénom.Text + "','" + txtTelephone.Text + "'," + int.Parse(txtNbParts.Text) + ",'" + txtEmail.Text + "');";

                cmd.CommandText = req;
                if (cmd.ExecuteNonQuery() == 1)
                {
                    MessageBox.Show("Le participant a bien été ajouté, vous pouvez désormais l'inviter");
                }
            }catch(FormatException x)
            {
                MessageBox.Show("Un ou plusieurs champs n'ont pas été renseignés, veuillez réessayer en renseignant tous les champs");
            }

            co.Close();
            this.Close();
        }

        private void txtNom_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(char.IsLetter(e.KeyChar) || e.KeyChar == (char)Keys.Back)
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        private void txtPrénom_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsLetter(e.KeyChar) || e.KeyChar == (char)Keys.Back)
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        private void txtTelephone_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsNumber(e.KeyChar) || e.KeyChar == (char)Keys.Back)
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        private void txtNbParts_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsNumber(e.KeyChar) || e.KeyChar == (char)Keys.Back)
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        private void txtEmail_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsLetter(e.KeyChar) || e.KeyChar == (char)Keys.Back || e.KeyChar == '@' || e.KeyChar == '.' || char.IsNumber(e.KeyChar))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }
    }
}
