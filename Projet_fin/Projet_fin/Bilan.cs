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
    public partial class Bilan : Form


    {

        private String chco;
      
        private OleDbConnection co = new OleDbConnection();
        private DataSet ds = new DataSet();
        private DataSet ds2 = new DataSet();
        private DataSet ds3 = new DataSet();
        int noevtcourant;

        public Bilan(string chco)
        {
            InitializeComponent();
            this.chco = chco;
        }

        private void Bilan_Load(object sender, EventArgs e)
        {
            OleDbCommand cmd = new OleDbCommand();
            cmd.Connection = co;
            co.ConnectionString = chco;
            co.Open();
            

            cmd.CommandType = CommandType.Text;
            string req = @"SELECT [titreEvent], [codeEvent]
                            FROM Evenements
                            WHERE soldeON = false;";

            cmd.CommandText = req;
            co.Close();
            Remplir(req, "events");

            co.Open();
            cbxEvenement.DataSource = ds.Tables["events"];
            cbxEvenement.DisplayMember = "titreEvent";
            cbxEvenement.ValueMember = "codeEvent";
            noevtcourant = int.Parse(cbxEvenement.SelectedValue.ToString());
           

            co.Close();
        }

        private void Remplir(String requete, String nomTable)
        {
            
            OleDbCommand cmd = new OleDbCommand(requete, co);
            OleDbDataAdapter da = new OleDbDataAdapter();
            da.SelectCommand = cmd;

            da.Fill(ds, nomTable);
            co.Close();
        }

        private void remplirDataGridView(string reqdgv, DataGridView d, DataSet dset)
        {

            OleDbDataAdapter da = new OleDbDataAdapter(reqdgv, co);
            da.Fill(dset);
            d.DataSource = dset.Tables[0];
        }

        private void cbxParticipant_SelectionChangeCommitted(object sender, EventArgs e)
        {
           
        }

        private void cbxEvenement_SelectionChangeCommitted(object sender, EventArgs e)
        {
            co.Open();
            cbxParticipant.Items.Clear();
            noevtcourant = int.Parse(cbxEvenement.SelectedValue.ToString());
            string reqpart = @"Select p.nomPart
                           From Participants p, Invites i
                           Where p.codeParticipant = i.codePart    
                           and i.codeEvent = " + noevtcourant + ";";
            OleDbCommand cmd = new OleDbCommand(reqpart, co);
            OleDbDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                cbxParticipant.Items.Add(dr.GetString(0));

            }

            
            co.Close();
        }

        private void btnBilan_Click(object sender, EventArgs e)
        {
            ds2.Clear();
            co.Open();
         
            string reqdgv1 = @"SELECT p.nomPart, d.description, d.dateDepense, d.montant
                              FROM Participants p, Depenses d
                              WHERE d.codePart = p.codeParticipant AND 
                              d.codeEvent = " + cbxEvenement.SelectedValue + @" 
                              AND d.codePart = (SELECT codeParticipant
                                                FROM Participants
                                                WHERE nomPart = '" + cbxParticipant.Text + "'); ";;
            remplirDataGridView(reqdgv1, dgvDépensé, ds2);
/*
            string get = @"SELECT codePart 
                           FROM Beneficiaires b, Participants p
                           WHERE b.codePart = p.codeParticipant;";



            string reqdgv2 = @"SELECT p.nomPart, d.description, d.dateDepense, d.montant
                             FROM Participants p, Depenses d
                             WHERE p.codeParticipant = d.codePart
                             AND d.codePart = (SELECT codePart 
                                               FROM Beneficiaires b, Participants p
                                               WHERE b.codePart = p.codeParticipant;
                                               AND p.nomPart = '" + cbxParticipant.Text + "');" ;
            MessageBox.Show(reqdgv2);
            remplirDataGridView(reqdgv2, dgvArembourser, ds3);*/
            co.Close();
        }

        private void btnCloture_Click(object sender, EventArgs e)
        {
            OleDbCommand cmd = new OleDbCommand();
            cmd.Connection = co;
            co.ConnectionString = chco;
            co.Open();

            //on récup le n° de l'évé 
            string rqtCodePart=@"SELECT codeEvent FROM Evenements
                                                     WHERE titreEvent = '"+cbxEvenement.Text+"' ";

            MessageBox.Show(rqtCodePart);
            cmd.CommandText = rqtCodePart;

            int NumEve = int.Parse(cmd.ExecuteScalar().ToString());

            //on récup tout les num de part
            string rqtNumPart = @"SELECT codePart FROM Invites 
                                   WHERE codeEvent =" + NumEve +"";
            MessageBox.Show(rqtNumPart);
            cmd.CommandText = rqtNumPart;
            OleDbDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                int NumPart = dr.GetInt32(0);
                DepenseCredit(NumEve,NumPart) ;
            }


            co.Close();
            /*string req = @"UPDATE Evenements
                           SET soldeON = True
                           WHERE titreEvent = '" + cbxEvenement.Text + "';";
            OleDbCommand cmd = new OleDbCommand(req, co);
            MessageBox.Show(cmd.ExecuteNonQuery().ToString());*/
        }
        private int DepenseCredit(int codeEvt,int numeroParticipant)
        {
            MessageBox.Show("Coucou"+codeEvt);
            return -1;
        }
    }
}
