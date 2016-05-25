using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Projet_fin
{
    public partial class événement : Form
    {
        public événement()
        {
            InitializeComponent();
        }
        int NumReq=1;
        int NbPage = 5;
        private void button3_Click(object sender, EventArgs e)
        {
            if (NumReq != NbPage)
            {
                NumReq++;
                lblNumChange.Text = "" + NumReq + " ";
                pgb_Prog.Value += 25;
            }

        }

        private void btnPre_Click(object sender, EventArgs e)
        {
            if (NumReq != 1 )
            {
                NumReq--;
                lblNumChange.Text = "" + NumReq + " ";
                pgb_Prog.Value -= 25;
            }
        }

        private void BtnDebut_Click(object sender, EventArgs e)
        {
            NumReq = 1;
            lblNumChange.Text = "" + NumReq + " ";
            pgb_Prog.Value = 0;
        }

        private void btnFin_Click(object sender, EventArgs e)
        {
            NumReq = NbPage;
            lblNumChange.Text = "" + NumReq + " ";
            pgb_Prog.Value = 100;
        }



    }
}
