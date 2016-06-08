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
    public partial class Invitation : Form
    {
        String chco;
        private OleDbConnection co = new OleDbConnection();


        public Invitation(String chco)
        {
            InitializeComponent();
            this.chco = chco;
        }


        private void toutcocher(object sender, EventArgs e)
        {
            if (chxTtSelectionner.Checked)
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

        private void Invitation_Load(object sender, EventArgs e)
        {
            co.Open();
            OleDbCommand cmd = new OleDbCommand();
            cmd.Connection = co;
            string req = @"SELECT nomPart , prenomPart FROM  ";           
            cmd.CommandType = CommandType.Text;
        }


    }
}
