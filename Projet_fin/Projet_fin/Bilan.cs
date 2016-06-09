﻿using System;
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
            DataColumn dc1 = new DataColumn();
            dc1.DataType = System.Type.GetType("System.Int32");
            dc1.ColumnName = "Numéro Depense";
            dt.Columns.Add(dc1);
            DataColumn dc2 = new DataColumn();
            dc2.DataType = Type.GetType("System.String");
            dc2.ColumnName = "date";
            dt.Columns.Add(dc2);
            DataColumn dc3 = new DataColumn();
            dc3.DataType = Type.GetType("System.String");
            dc3.ColumnName = "description";
            dt.Columns.Add(dc3);
            DataColumn dc4 = new DataColumn();
            dc4.DataType = Type.GetType("System.Decimal");
            dc4.ColumnName = "montant";
            dt.Columns.Add(dc4);

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
            DataColumn c1 = new DataColumn();
            c1.DataType = System.Type.GetType("System.Int32");
            c1.ColumnName = "Numéro Depense";
            dt2.Columns.Add(c1);
            DataColumn c2 = new DataColumn();
            c2.DataType = Type.GetType("System.Decimal");
            c2.ColumnName = "montant";
            dt2.Columns.Add(c2);
            DataColumn c3 = new DataColumn();
            c3.DataType = Type.GetType("System.Int32");
            c3.ColumnName = "SommeDenbPart";
            dt2.Columns.Add(c3);
            

            OleDbParameter parampart = new OleDbParameter();
            parampart.ParameterName = "@pPart";
            parampart.OleDbType = OleDbType.Integer;
            parampart.Direction = ParameterDirection.Input;
            parampart.Value = nopart;
        

            OleDbParameter paramevent = new OleDbParameter();
            paramevent.ParameterName = "@pEvent";
            paramevent.OleDbType = OleDbType.Integer;
            paramevent.Direction = ParameterDirection.Input;
            paramevent.Value = noevt;
           
             
            OleDbCommand cmd2 = new OleDbCommand();
            cmd2.Connection = co;
            cmd2.CommandType = CommandType.StoredProcedure;
            cmd2.CommandText = "DepensesQuiMeConcernent";
            cmd2.Parameters.Add(paramevent);
            cmd2.Parameters.Add(parampart);
            OleDbDataAdapter da2 = new OleDbDataAdapter(cmd2);
            da.Fill(dt2);
            dgvArembourser.DataSource = dt2;

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

            DataSet ds = new DataSet("bilan");

            DataTable dtBilan = ds.Tables.Add("dtBilan");

            DataColumn dcBilan = 
                dtBilan.Columns.Add("CodePart", typeof(Int32));
            dtBilan.Columns.Add("Personne", typeof(string));
            dtBilan.Columns.Add("Plus", typeof(Int32));
            dtBilan.Columns.Add("Moins", typeof(Int32));
            dtBilan.Columns.Add("Solde", typeof(Int32));

            dtBilan.PrimaryKey = new DataColumn[] {dcBilan  };

            dgvEss.DataSource = ds;
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
            
            return -1;
        }
        private int DepensesDebit(int codeEvt, int numeroParticipant)
        {

            return -1;
        }
    }
}
