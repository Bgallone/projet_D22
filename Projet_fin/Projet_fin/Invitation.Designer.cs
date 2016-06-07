namespace Projet_fin
{
    partial class Invitation
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblTitreInv = new System.Windows.Forms.Label();
            this.clbBeneficiaires = new System.Windows.Forms.CheckedListBox();
            this.grbCouleur = new System.Windows.Forms.GroupBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.grbCouleur.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblTitreInv
            // 
            this.lblTitreInv.AutoSize = true;
            this.lblTitreInv.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitreInv.Location = new System.Drawing.Point(203, 74);
            this.lblTitreInv.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTitreInv.Name = "lblTitreInv";
            this.lblTitreInv.Size = new System.Drawing.Size(290, 31);
            this.lblTitreInv.TabIndex = 7;
            this.lblTitreInv.Text = "Gestion des Invitations";
            // 
            // clbBeneficiaires
            // 
            this.clbBeneficiaires.FormattingEnabled = true;
            this.clbBeneficiaires.Location = new System.Drawing.Point(13, 157);
            this.clbBeneficiaires.Margin = new System.Windows.Forms.Padding(4);
            this.clbBeneficiaires.Name = "clbBeneficiaires";
            this.clbBeneficiaires.Size = new System.Drawing.Size(611, 123);
            this.clbBeneficiaires.TabIndex = 17;
            // 
            // grbCouleur
            // 
            this.grbCouleur.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.grbCouleur.Controls.Add(this.lblTitreInv);
            this.grbCouleur.Location = new System.Drawing.Point(-45, -44);
            this.grbCouleur.Name = "grbCouleur";
            this.grbCouleur.Size = new System.Drawing.Size(729, 137);
            this.grbCouleur.TabIndex = 18;
            this.grbCouleur.TabStop = false;
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(13, 110);
            this.checkBox1.Margin = new System.Windows.Forms.Padding(4);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(140, 21);
            this.checkBox1.TabIndex = 19;
            this.checkBox1.Text = "Tout selectionner";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // Invitation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(637, 435);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.clbBeneficiaires);
            this.Controls.Add(this.grbCouleur);
            this.Name = "Invitation";
            this.Text = "Invitation";
            this.grbCouleur.ResumeLayout(false);
            this.grbCouleur.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTitreInv;
        private System.Windows.Forms.CheckedListBox clbBeneficiaires;
        private System.Windows.Forms.GroupBox grbCouleur;
        private System.Windows.Forms.CheckBox checkBox1;
    }
}