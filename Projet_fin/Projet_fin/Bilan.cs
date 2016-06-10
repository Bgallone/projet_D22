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
using sharpPDF;
using sharpPDF.Enumerators;
using sharpPDF.Fonts;
using sharpPDF.Elements;
using sharpPDF.Bookmarks;
using sharpPDF.Collections;
using sharpPDF.PDFControls;
using sharpPDF.Tables;
using sharpPDF.Exceptions;

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

           //création table qui doit quoi a qui 
            DataTable dtBilanPart = ds.Tables.Add("dtBilanPart");

            dtBilanPart.Columns.Add("codeEvt", typeof(Int32));
            dtBilanPart.Columns.Add("codeDonneur", typeof(Int32));
            dtBilanPart.Columns.Add("codeReceveur", typeof(Int32));
            dtBilanPart.Columns.Add("sommeAVerser", typeof(Double));

            

     
            
            //on récup le n° de l'évé 
            string rqtCodePart=@"SELECT codeEvent FROM Evenements
                                                     WHERE titreEvent = '"+cbxEvenement.Text+"' ";


            cmd.CommandText = rqtCodePart;

            int NumEve = int.Parse(cmd.ExecuteScalar().ToString());

            //on récup tout les num de part
            string rqtNumPart = @"SELECT i.codePart , (p.nomPart + p.prenomPart), p.nbParts 
                                   FROM Invites i , Participants p 
                                   WHERE codeEvent =" + NumEve +" AND i.codePart = p.codeParticipant";

            cmd.CommandText = rqtNumPart;
            OleDbDataReader dr = cmd.ExecuteReader();


            
            
           
            while (dr.Read())
            {
                int NumPart = dr.GetInt32(0);
                
                double Plus =DepenseCredit(NumEve,NumPart) ;
               
                double Moins=DepensesDebit(NumEve, NumPart);

                string NomPre = dr.GetString(1);
                int nbPart = dr.GetInt32(2);
                Moins = Moins * nbPart;
               
                dtBilan.Rows.Add(NumPart,NomPre, Plus, Moins, Plus-Moins);
            }

            // Algorithme
            while((double)dtBilan.Compute("Max(Solde)", "") !=0){



                   DataRow[] rows = dtBilan.Select();
                double donneur = Math.Round((double)dtBilan.Compute("Min(Solde)", ""),2);
                double receveur = Math.Round((double)dtBilan.Compute("Max(Solde)", ""),2);


                if (Math.Abs(donneur) < Math.Abs(receveur))
                {

                    bool rep = false ;int codedonneur = 0; int codereceveur = 0;int i=0;
                    while(rep != true)
                    {
                        
                        if (Math.Round((double)rows[i]["Solde"],2) == donneur)
                        {
                            codedonneur = (int)rows[i]["CodePart"];
                            rows[i]["Solde"] = 0;
                            rep=true; 
                        }
                        i++;
                    }
                    rep= false;
                    i=0;
                    while(rep != true)
                    { 
                          
                        if(Math.Round((double)rows[i]["Solde"],2) == receveur)
                        {
                            codereceveur = (int)rows[i]["CodePart"];

                            rows[i]["Solde"] = receveur+donneur;
                            rep = true;
                        }
                        i++;
                    }

                   if (codedonneur != 0 && codereceveur != 0)
                   {
                       
                        dtBilanPart.Rows.Add(NumEve, codedonneur, codereceveur, Math.Abs(donneur));
                    }
                    
                }


                else if(Math.Abs(donneur) >Math.Abs(receveur) )
                {

                    bool rep = false ;int codedonneur = 0; int codereceveur = 0;int i=0;
                    while(rep != true)
                    {
         
                        if (Math.Round((double)rows[i]["Solde"],2) == donneur)
                        {
                            codedonneur = (int)rows[i]["CodePart"];
                            rows[i]["Solde"] = donneur + receveur;
                               rep=true; 
                        }
                        i++;
                    }
                    rep= false;
                    i=0;
                    while(rep != true)
                    { 
                          if (Math.Round((double)rows[i]["Solde"],2) == receveur)
                        {
                            codereceveur = (int)rows[i]["CodePart"];
                            rows[i]["Solde"] = 0;
                            rep = true;
                        }
                        i++;
                    }

                        if (codedonneur != 0 && codereceveur != 0)
                        {
                            dtBilanPart.Rows.Add(NumEve, codedonneur, codereceveur, Math.Abs(donneur));
                        }


                }


                else
                {
                    bool rep = false; int codedonneur = 0; int codereceveur = 0; int i = 0;
                    while (rep != true)
                    {
                        if (Math.Round((double)rows[i]["Solde"],2) == donneur)
                        {
                             codedonneur = (int)rows[i]["CodePart"];
                            rows[i]["Solde"] = 0;
                            rep = true;

                        }
                            i++;
                    } 
                    rep = false;
                    i = 0;
                    while (rep != true)
                    {
                        if (Math.Round((double)rows[i]["Solde"], 2) == receveur)
                        {
                             codereceveur = (int)rows[i]["CodePart"];
                            rows[i]["Solde"] = 0;
                            rep = true;

                        }
                        i++;
                    }
                    if (codedonneur != 0 && codereceveur != 0)
                        {
                            dtBilanPart.Rows.Add(NumEve, codedonneur, codereceveur, Math.Abs(donneur));
                        }
                    }
            }


            co.Close();




            // VALEUR PDF 
            co.Open();

            String nom = cbxParticipant.Text;

            cmd.CommandText = @"SELECT codeParticipant FROM Participants
                                WHERE nomPart ='" + nom + "'";
          
            int NumPart1 = int.Parse(cmd.ExecuteScalar().ToString());

            cmd.CommandText = @"SELECT titreEvent FROM Evenements 
                                WHERE codeEvent=" + NumEve + ";";
            string TitreEve = cmd.ExecuteScalar().ToString();

            cmd.CommandText = @"SELECT count(*) FROM Depenses 
                                WHERE codeEvent=" + NumEve + " and codePart = (SELECT codePart FROM Participants WHERE nomPart = '" + nom + "')";
            int nddepeff = int.Parse(cmd.ExecuteScalar().ToString());

            cmd.CommandText = @"SELECT description, montant FROM Depenses 
                                WHERE codeEvent=" + NumEve + " and codePart = (SELECT codePart FROM Participants WHERE nomPart = '" + nom + "')";

            String[,] tabdépenseeff = new String[nddepeff,2];
            String[,] tabreceveur = new String[nddepeff, 2];
            int d =0;
            DataRow[] rows2 = dtBilanPart.Select();
            for (int i = 0; i < rows2.Length; i++)
            {
                // Nom du donneur pas kebab
                int codeDonne = (int)rows2[i]["codeDonneur"];
                cmd.CommandText = @"SELECT (nomPart +' '+prenomPart) FROM Participants 
                                WHERE codeParticipant=" + codeDonne+ ";";
                string NomDonneur = cmd.ExecuteScalar().ToString();

                //Somme du 
                double SommeDu =(double)rows2[i]["sommeAVerser"];


                //Nom du receveur pas bicraveur
                int codeRecev = (int)rows2[i]["codeReceveur"];
                cmd.CommandText = @"SELECT (nomPart +' '+prenomPart) FROM Participants 
                                WHERE codeParticipant=" + codeRecev + ";";
                string NomDuRecev = cmd.ExecuteScalar().ToString();

                MessageBox.Show(NomDonneur+" doit "+SommeDu +"à "+ NomDuRecev);

                if(codeRecev == NumPart1)
                {
                    tabreceveur[d, 0] = NomDonneur;
                    tabreceveur[d, 1] = SommeDu.ToString();
                    d++;
                }
            }
            

            string req = @"UPDATE Evenements
                           SET soldeON = True
                           WHERE titreEvent = '" + cbxEvenement.Text + "';";
             cmd.CommandText =req;
            MessageBox.Show(cmd.ExecuteNonQuery().ToString());

            cmd.CommandText = @"SELECT dateDebut FROM Evenements 
                      WHERE codeEvent = " + NumEve + ";";
            string datedeb = cmd.ExecuteScalar().ToString();

            cmd.CommandText = @"SELECT dateFin FROM Evenements 
                      WHERE codeEvent = " + NumEve + ";";
            string datefin = cmd.ExecuteScalar().ToString();

            

            cmd.CommandText = @"SELECT prenomPart FROM Participants 
                      WHERE nomPart = '" + nom + "';";
            string prenom = cmd.ExecuteScalar().ToString();

            cmd.CommandText = @"SELECT description FROM Evenements 
                      WHERE codeEvent = " + NumEve + ";";
            string description = cmd.ExecuteScalar().ToString();

            cmd.CommandText = @"SELECT count(*) FROM Invites
                      WHERE codeEvent = " + NumEve + ";";
            int participant = int.Parse(cmd.ExecuteScalar().ToString());

            co.Close();

            string rqtnumero = @"SELECT codePart FROM Invites
                                   WHERE codeEvent =" + NumEve +";";

            cmd.CommandText = rqtnumero;






            CreatePDF(TitreEve, nom, prenom, datedeb, datefin, description, participant, tabdépenseeff, tabreceveur);


           
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

            double res = 0 ;
            //nbpart
            double nbPart;
            object totalPart; string partTot;

            //somme
            double somme;
            object somPart ; string partSom;

            DataRow[] rows = dt.Select();
            for (int i = 0; i < rows.Length; i++)
            {
                totalPart = rows[i]["SommeDenbParts"];
                partTot = totalPart.ToString();
                if (!double.TryParse(partTot, out nbPart))
                {
                    nbPart = 0;
                }

                somPart = rows[i]["montant"];
                partSom = somPart.ToString();
                if(!double.TryParse(partSom,out somme))
                {
                    somme = 0;
                }

                res += somme / nbPart;

            }

 
            return res;

        }

        public void CreatePDF(String nomEvent, String nom, String prenom, String datedeb, String datefin, String description, int participant, String[,] tab1, String[,] tab2)
        {
            int taille;
            pdfDocument myDoc = new pdfDocument("BonCompte", "BonCompte");
            pdfPage myPage = myDoc.addPage(2339, 1654);
            myPage.addText("Récapitulatif de l'événement : " + nomEvent, 80, 2250, myDoc.getFontReference("Helvetica"), 40);
            myPage.addText("- Date de début : " + datedeb, 100, 2200, myDoc.getFontReference("Helvetica"), 40);
            myPage.addText("- Date de FIN : " + datefin, 100, 2150, myDoc.getFontReference("Helvetica"), 40);
            myPage.addText("- Description : " + description, 100, 2100, myDoc.getFontReference("Helvetica"), 40);

            myPage.drawLine(100, 2000, 1550, 2000, predefinedLineStyle.csNormal, new pdfColor(0, 0, 255), 3);
            myPage.addText("Récapitulatif des participants : " + nom, 80, 1950, myDoc.getFontReference("Helvetica"), 40);
            myPage.addText("- Prénom : " + prenom, 100, 1900, myDoc.getFontReference("Helvetica"), 40);
            myPage.addText("- Nombre de particiants : " + participant, 100, 1850, myDoc.getFontReference("Helvetica"), 40);
            myPage.addText("Les dépenses effectées par : " + nom, 100, 1750, myDoc.getFontReference("Helvetica"), 40);
            myPage.addText("Description ", 250, 1655, myDoc.getFontReference("Helvetica"), 40);
            myPage.addText("Montant ", 850, 1655, myDoc.getFontReference("Helvetica"), 40);
            taille = 1700;
            for (int i = 0; i < tab1.Length +1; i++)
            {
                myPage.drawLine(200, 1700 - 50 * i, 1450, 1700 - 50 * i, predefinedLineStyle.csNormal, new pdfColor(0, 0, 0), 3);
                taille -= 50;
            }
            for (int y = 0; y < 3; y++)
            {
                myPage.drawLine(200 + y * (1250 / 2), 1700, 200 + y * (1250 / 2), 1700 - 50 * tab1.Length, predefinedLineStyle.csNormal, new pdfColor(0, 0, 0), 3);
            }
            taille -= 50;
            myPage.drawLine(100, taille, 1550, taille, predefinedLineStyle.csNormal, new pdfColor(0, 0, 255), 3);
            myPage.addText("Les dépense dont a bénéficiées " + nom , 80, taille -50, myDoc.getFontReference("Helvetica"), 40);
            taille -= 100;
            myPage.addText("Description ", 250, taille -45, myDoc.getFontReference("Helvetica"), 40);
            myPage.addText("Montant ", 850, taille -45, myDoc.getFontReference("Helvetica"), 40);
            for (int i = 0; i < tab1.Length +1; i++)
            {
                myPage.drawLine(200, taille - 50 * i, 1450, taille - 50 * i, predefinedLineStyle.csNormal, new pdfColor(0, 0, 0), 3);
                
            }
            for (int y = 0; y < 3; y++)
            {
                myPage.drawLine(200 + y * (1250 / 2), taille, 200 + y * (1250 / 2), taille - 50 * tab1.Length, predefinedLineStyle.csNormal, new pdfColor(0, 0, 0), 3);
            }
            taille -= 50 * tab1.Length + 1;

            myPage.drawLine(100, taille-50, 1550, taille-50, predefinedLineStyle.csNormal, new pdfColor(0, 0, 255), 3);

            pdfPage myPage2 = myDoc.addPage(2339, 1654);
            taille = 2200;
            myPage2.addText(nom + " doit payer à :", 80, taille - 50, myDoc.getFontReference("Helvetica"), 40);
            taille -= 100;
            myPage2.addText("Nom ", 250, taille - 45, myDoc.getFontReference("Helvetica"), 40);
            myPage2.addText("Montant ", 850, taille - 45, myDoc.getFontReference("Helvetica"), 40);
            for (int i = 0; i < tab2.Length +1; i++)
            {
                myPage2.drawLine(200, taille - 50 * i, 1450, taille - 50 * i, predefinedLineStyle.csNormal, new pdfColor(0, 0, 0), 3);
                if (i < tab2.Length)
                {
                    myPage2.addText(tab2[i,0], 250, taille - (45 + i*50), myDoc.getFontReference("Helvetica"), 40);
                    myPage2.addText(tab2[i, 1], 850, taille - (45 + i * 50), myDoc.getFontReference("Helvetica"), 40);
                }
            }
            for (int y = 0; y < 3; y++)
            {
                myPage2.drawLine(200 + y * (1250 / 2), taille, 200 + y * (1250 / 2), taille - 50 * tab1.Length , predefinedLineStyle.csNormal, new pdfColor(0, 0, 0), 3);
            }
            taille -= 50 * tab2.Length;
            myPage2.drawLine(100, taille - 50, 1550, taille - 50, predefinedLineStyle.csNormal, new pdfColor(0, 0, 255), 3);
            taille -= 100; 
            myPage2.addText(nom + " doit recevoir de :", 80, taille - 50, myDoc.getFontReference("Helvetica"), 40);
            taille -= 100;
            myPage2.addText("Nom ", 250, taille - 45, myDoc.getFontReference("Helvetica"), 40);
            myPage2.addText("Montant ", 850, taille - 45, myDoc.getFontReference("Helvetica"), 40);
            for (int i = 0; i < tab1.Length + 1; i++)
            {
                myPage2.drawLine(200, taille - 50 * i, 1450, taille - 50 * i, predefinedLineStyle.csNormal, new pdfColor(0, 0, 0), 3);

            }
            for (int y = 0; y < 3; y++)
            {
                myPage2.drawLine(200 + y * (1250 / 2), taille, 200 + y * (1250 / 2), taille - 50 * tab1.Length, predefinedLineStyle.csNormal, new pdfColor(0, 0, 0), 3);
            }
            taille -= 50 * tab1.Length;
            myPage2.drawLine(100, taille - 50, 1550, taille - 50, predefinedLineStyle.csNormal, new pdfColor(0, 0, 255), 3);

            String path = System.Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            myDoc.createPDF(@"" + path + "/test.pdf");
            myPage = null;
            myDoc = null;
        }
    }
}
