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
            
            DataTable dt = new DataTable();

            string reqpart = @"SELECT codeParticipant
                              FROM Participants
                              WHERE nomPart = '" + cbxParticipant.Text + "';";
            OleDbCommand cmd = new OleDbCommand(reqpart, co);
            int nopart = int.Parse(cmd.ExecuteScalar().ToString());

            string reqevt = @"SELECT codeEvent 
                              FROM Evenements
                              WHERE titreEvent = '" + cbxEvenement.Text + "';";
            cmd.CommandText = reqevt;
            int noevt = int.Parse(cmd.ExecuteScalar().ToString());
     
            OleDbParameter part = new OleDbParameter();
            part.OleDbType = OleDbType.Integer;
            part.ParameterName = "@pPart";
            part.Value = nopart;
            part.Direction = ParameterDirection.Input;
         
            OleDbParameter evt = new OleDbParameter();
            evt.OleDbType = OleDbType.Integer;
            evt.ParameterName = "@pEvent";
            evt.Value = noevt;
            evt.Direction = ParameterDirection.Input;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "MesDepenses";
            cmd.Parameters.Add(evt);
            cmd.Parameters.Add(part);
            OleDbDataAdapter da = new OleDbDataAdapter(cmd);
            da.Fill(dt);
            dgvDépensé.DataSource = dt;

            DataTable dt2 = new DataTable();

            OleDbParameter ppart = new OleDbParameter();
            ppart.ParameterName = "@pPart";
            ppart.OleDbType = OleDbType.Integer;
            ppart.Direction = ParameterDirection.Input;
            ppart.Value = nopart;
        

            OleDbParameter pevent = new OleDbParameter();
            pevent.ParameterName = "@pEvent";
            pevent.OleDbType = OleDbType.Integer;
            pevent.Direction = ParameterDirection.Input;
            pevent.Value = noevt;
           
            cmd.Connection = co;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "DepensesQuiMeConcernent";
            cmd.Parameters.Add(pevent);
            cmd.Parameters.Add(ppart);
            OleDbDataAdapter da2 = new OleDbDataAdapter(cmd);
            da2.Fill(dt2);
            dgvArembourser.DataSource = dt2;

            co.Close();
        }




        private void btnCloture_Click(object sender, EventArgs e)
        {
            OleDbCommand cmd = new OleDbCommand();
            cmd.Connection = co;
            co.ConnectionString = chco;
            co.Open();

            //création de la table 
            DataSet ds = new DataSet("bilan");

            DataTable dtBilan = ds.Tables.Add("dtBilan");

            DataColumn pkdtBilan = dtBilan.Columns.Add("CodePart", typeof(Int32));
            dtBilan.Columns.Add("Personne", typeof(string));
            dtBilan.Columns.Add("Plus",typeof(Double));
            dtBilan.Columns.Add("Moins",typeof(Double));
            dtBilan.Columns.Add("Solde",typeof(Double));

            dgvEss.DataSource = dtBilan;
     
            
            //on récup le n° de l'évé 
            string rqtCodePart=@"SELECT codeEvent FROM Evenements
                                                     WHERE titreEvent = '"+cbxEvenement.Text+"' ";

            MessageBox.Show(rqtCodePart);
            cmd.CommandText = rqtCodePart;

            int NumEve = int.Parse(cmd.ExecuteScalar().ToString());

            //on récup tout les num de part
            string rqtNumPart = @"SELECT codePart FROM Invites 
                                   WHERE codeEvent =" + NumEve +"";

            cmd.CommandText = rqtNumPart;
            OleDbDataReader dr = cmd.ExecuteReader();

           
            while (dr.Read())
            {
                int NumPart = dr.GetInt32(0);
                
                double Plus =DepenseCredit(NumEve,NumPart) ;
               
                double Moins=DepensesDebit(NumEve, NumPart);
      
            }
            co.Close();


            /*string req = @"UPDATE Evenements
                           SET soldeON = True
                           WHERE titreEvent = '" + cbxEvenement.Text + "';";
            OleDbCommand cmd = new OleDbCommand(req, co);
            MessageBox.Show(cmd.ExecuteNonQuery().ToString());*/
        }
        private double DepenseCredit(int codeEvt,int numeroParticipant)
        {
            //parametre
            OleDbCommand cmd = new OleDbCommand();
            cmd.Connection = co;
            DataTable dt = new DataTable();

            // on lui passe un participant
            OleDbParameter part = new OleDbParameter();
            part.OleDbType = OleDbType.Integer;
            part.ParameterName = "@pPart";
            part.Value = numeroParticipant;
            part.Direction = ParameterDirection.Input;

            // on lui passe un éve
            OleDbParameter evt = new OleDbParameter();
            evt.OleDbType = OleDbType.Integer;
            evt.ParameterName = "@pEvent";
            evt.Value = codeEvt;
            evt.Direction = ParameterDirection.Input;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "MesDepenses";
            cmd.Parameters.Add(evt);
            cmd.Parameters.Add(part);
            OleDbDataAdapter da = new OleDbDataAdapter(cmd);
            da.Fill(dt);

            object sumObject = dt.Compute("Sum(montant)", "");
            
            string total =sumObject.ToString();

            double res;

            if(!double.TryParse(total,out res))
            {
                res = 0;
            }
            
            return res;
        }
        private double DepensesDebit(int codeEvt, int numeroParticipant)
        {
            //moins
            //parametre
            OleDbCommand cmd = new OleDbCommand();
            cmd.Connection = co;
            DataTable dt = new DataTable();


            // on lui passe un participant
            OleDbParameter part = new OleDbParameter();
            part.OleDbType = OleDbType.Integer;
            part.ParameterName = "@pPart";
            part.Value = numeroParticipant;
            part.Direction = ParameterDirection.Input;

            // on lui passe un éve
            OleDbParameter evt = new OleDbParameter();
            evt.OleDbType = OleDbType.Integer;
            evt.ParameterName = "@pEvent";
            evt.Value = codeEvt;
            evt.Direction = ParameterDirection.Input;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "DepensesQuiMeConcernent";
            cmd.Parameters.Add(evt);
            cmd.Parameters.Add(part);
            OleDbDataAdapter da = new OleDbDataAdapter(cmd);
            da.Fill(dt);

    
            

            
            return -1;

        }
    }
}
