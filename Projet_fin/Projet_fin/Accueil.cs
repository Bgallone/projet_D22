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

        //private String chco = @"Provider = Microsoft.Jet.OLEDB.4.0; Data Source = C:\Users\bgallone\Source\Repos\projet_D22\Projet_fin\Projet_fin\Resources\bdEvents.mdb;Persist Security Info=True";
        //private string chco = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=C:\Users\Arthur\Desktop\Cours\S2\D21\bdEvents.mdb";
       private String chco = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=C:\Users\Gladmir\Source\Repos\projet_D22\Projet_fin\Projet_fin\Resources\bdEvents.mdb;Persist Security Info=True";
        //String chco = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source =.\Resources\bdEvents.mdb";
        private OleDbConnection co = new OleDbConnection();
        private DataSet ds = new DataSet();
        private int noevent;
        




        public FrmLancement()
        {
            InitializeComponent();

        }

        public void FrmLancement_Load(object sender, EventArgs e)
        {
            refresh();
           
        }

        public void refresh()
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
            Init();
            co.Close();
        }

        private void Init()
        {
            txtDepense.Enabled = false;
            txtMontant.Enabled = false;
            txtCommentaire.Enabled = false;
            cbxPayePar.Enabled = false;
            clbBeneficiaires.Enabled = false;
            chxToutCocher.Enabled = false;
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
            //Sélection des participants à l'événement sélectionné
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
            Form1.ShowDialog();
        }






        private void btn_event_Click(object sender, EventArgs e)
        {
            Form Form1 = new événement(chco);
            Form1.ShowDialog();
        }





        private void btn_RAZ_Click(object sender, EventArgs e)
        {
            txtCommentaire.Clear();
            txtDepense.Clear();
            txtMontant.Clear();
            clbBeneficiaires.Items.Clear();
            Init();

            
        }

        private void btn_Quit_Click(object sender, EventArgs e)
        {
            Application.Exit();
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
            //Sélection des participants ainsi que leur codePart pour l'événement sélectionné
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
            txtDepense.Enabled = true;


        }

        private void cbxEvenement_Click(object sender, EventArgs e)
        {

        }

        private void toutcocher(object sender, EventArgs e)
        {
            if (
                chxToutCocher.Checked)
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
            if(txtDepense.Text == "")
            {
                MessageBox.Show("Veuillez saisir un nom pour la dépense");
            }
            if(txtMontant.Text == ""){
                MessageBox.Show("Veuillez saisir un montant pour la dépense");
            }
            if(txtCommentaire.Text == "")
            {
                MessageBox.Show("Veuillez saisir un commentaire pour l'événement");
            }
            co.Open();
            string req = @"SELECT codeParticipant FROM Participants WHERE nomPart = '" + cbxPayePar.Text + "';";
            
            
            OleDbCommand cmd = new OleDbCommand(req, co);
            
           int codePart = int.Parse(cmd.ExecuteScalar().ToString());

            req = @"Select count(*) from Depenses;";
            cmd.CommandText = req;
            int numDep = int.Parse(cmd.ExecuteScalar().ToString()) + 1;
            
            req = @"INSERT INTO Depenses(numDepense,description,montant, dateDepense, codeEvent, commentaire,codePart) 
                            VALUES('" + numDep + "', '" + txtDepense.Text + "', '" + double.Parse(txtMontant.Text) +"', '" + dateTimePicker1.Value.Date +
                                      "','" + noevent + "', '" + txtCommentaire.Text + "', '"+ codePart +"');";

            cmd.CommandText = req;
            
            
            int n = cmd.ExecuteNonQuery();
            if(n == 1)
            {
                MessageBox.Show("La dépense a bien été ajoutée");
            }
            else
            {
                MessageBox.Show("Erreur lors de l'ajout de la dépense");
            }
          

            for(int i = 0; i < clbBeneficiaires.Items.Count;i++)
            {
                if (clbBeneficiaires.GetItemChecked(i))
                {
                    string nom = clbBeneficiaires.Items[i].ToString();
                    string reqid = @"SELECT codeParticipant
                                     FROM Participants
                                     WHERE nomPart = '" + nom + "';";
                    cmd.CommandText = reqid;
                    int id = int.Parse(cmd.ExecuteScalar().ToString());

                    string reqinsert = @"INSERT INTO Beneficiaires(numDepense, codePart)
                                         VALUES(" + numDep + ", " + id + ");";
                    cmd.CommandText = reqinsert;
                    int j = cmd.ExecuteNonQuery();
                 
                }
            }

            co.Close();

   
        }

        private void btn_dep_Click(object sender, EventArgs e)
        {
            Form Form1 = new Dépenses(chco);
            Form1.ShowDialog();
        }

        private void btn_bilan_Click(object sender, EventArgs e)
        {
            Form Form1 = new Bilan(chco);
            Form1.ShowDialog();
        }

        private void txtDepense_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (txtDepense.Text.Length == 0)
            {
                txtMontant.Enabled = true;
            }
            else
            {
                txtMontant.Enabled = false;
            }

            if (char.IsLetter(e.KeyChar) || e.KeyChar == (char) Keys.Space || e.KeyChar == (char) Keys.Back)
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        private void txtMontant_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (txtMontant.Text.Length == 0)
            {
                txtCommentaire.Enabled = true;
            }
            else
            {
                txtCommentaire.Enabled = false;
            }

            if (char.IsNumber(e.KeyChar) || e.KeyChar == (char) Keys.Back)
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        private void txtCommentaire_TextChanged(object sender, EventArgs e)
        {
            cbxPayePar.Enabled = true;
        }

        private void cbxPayePar_SelectedIndexChanged(object sender, EventArgs e)
        {
            clbBeneficiaires.Enabled = true;
            chxToutCocher.Enabled = true;
        }

        private void txtCommentaire_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(e.KeyChar == (char) Keys.Back || e.KeyChar == (char) Keys.Space || char.IsLetter(e.KeyChar))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            ds.Clear();
            this.refresh();
        }
    }
}
    

