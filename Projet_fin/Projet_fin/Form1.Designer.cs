namespace Projet_fin
{
    partial class FrmLancement
    {
        /// <summary>
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur Windows Form

        /// <summary>
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            this.btn_event = new System.Windows.Forms.Button();
            this.btn_part = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.btn_bilan = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btn_dep = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.grbSection = new System.Windows.Forms.GroupBox();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.lbl_nvldepense = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnRAZ = new System.Windows.Forms.Button();
            this.btnQuit = new System.Windows.Forms.Button();
            this.btnValider = new System.Windows.Forms.Button();
            this.clbBeneficiaires = new System.Windows.Forms.CheckedListBox();
            this.txtCommentaire = new System.Windows.Forms.RichTextBox();
            this.udCout = new System.Windows.Forms.NumericUpDown();
            this.label12 = new System.Windows.Forms.Label();
            this.txtDepense = new System.Windows.Forms.TextBox();
            this.cbxPayePar = new System.Windows.Forms.ComboBox();
            this.cbxEvenement = new System.Windows.Forms.ComboBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.lvl_nomEvent = new System.Windows.Forms.Label();
            this.btn_Accueil = new System.Windows.Forms.Button();
            this.grbSection.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.udCout)).BeginInit();
            this.SuspendLayout();
            // 
            // btn_event
            // 
            this.btn_event.Location = new System.Drawing.Point(25, 170);
            this.btn_event.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btn_event.Name = "btn_event";
            this.btn_event.Size = new System.Drawing.Size(40, 45);
            this.btn_event.TabIndex = 12;
            this.btn_event.Text = "button2";
            this.btn_event.UseVisualStyleBackColor = true;
            this.btn_event.Click += new System.EventHandler(this.btn_event_Click);
            // 
            // btn_part
            // 
            this.btn_part.Location = new System.Drawing.Point(25, 252);
            this.btn_part.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btn_part.Name = "btn_part";
            this.btn_part.Size = new System.Drawing.Size(40, 45);
            this.btn_part.TabIndex = 12;
            this.btn_part.Text = "button3";
            this.btn_part.UseVisualStyleBackColor = true;
            this.btn_part.Click += new System.EventHandler(this.btn_part_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(23, 386);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(55, 13);
            this.label4.TabIndex = 15;
            this.label4.Text = "Dépenses";
            // 
            // btn_bilan
            // 
            this.btn_bilan.Location = new System.Drawing.Point(25, 428);
            this.btn_bilan.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btn_bilan.Name = "btn_bilan";
            this.btn_bilan.Size = new System.Drawing.Size(40, 45);
            this.btn_bilan.TabIndex = 16;
            this.btn_bilan.Text = "button5";
            this.btn_bilan.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(25, 299);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(62, 13);
            this.label3.TabIndex = 13;
            this.label3.Text = "Participants";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(25, 217);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(66, 13);
            this.label2.TabIndex = 10;
            this.label2.Text = "Evénements";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(22, 132);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(42, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Accueil";
            // 
            // btn_dep
            // 
            this.btn_dep.Location = new System.Drawing.Point(25, 339);
            this.btn_dep.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btn_dep.Name = "btn_dep";
            this.btn_dep.Size = new System.Drawing.Size(40, 45);
            this.btn_dep.TabIndex = 14;
            this.btn_dep.Text = "button4";
            this.btn_dep.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(24, 475);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(30, 13);
            this.label5.TabIndex = 17;
            this.label5.Text = "Bilan";
            // 
            // grbSection
            // 
            this.grbSection.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.grbSection.BackColor = System.Drawing.SystemColors.WindowFrame;
            this.grbSection.Controls.Add(this.label5);
            this.grbSection.Controls.Add(this.btn_dep);
            this.grbSection.Controls.Add(this.label1);
            this.grbSection.Controls.Add(this.label2);
            this.grbSection.Controls.Add(this.label3);
            this.grbSection.Controls.Add(this.btn_bilan);
            this.grbSection.Controls.Add(this.label4);
            this.grbSection.Controls.Add(this.btn_part);
            this.grbSection.Controls.Add(this.btn_event);
            this.grbSection.Controls.Add(this.btn_Accueil);
            this.grbSection.Location = new System.Drawing.Point(-5, -7);
            this.grbSection.Margin = new System.Windows.Forms.Padding(0);
            this.grbSection.Name = "grbSection";
            this.grbSection.Padding = new System.Windows.Forms.Padding(0);
            this.grbSection.Size = new System.Drawing.Size(103, 509);
            this.grbSection.TabIndex = 11;
            this.grbSection.TabStop = false;
            // 
            // lbl_nvldepense
            // 
            this.lbl_nvldepense.AccessibleRole = System.Windows.Forms.AccessibleRole.TitleBar;
            this.lbl_nvldepense.AutoSize = true;
            this.lbl_nvldepense.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_nvldepense.Location = new System.Drawing.Point(243, 9);
            this.lbl_nvldepense.Name = "lbl_nvldepense";
            this.lbl_nvldepense.Size = new System.Drawing.Size(377, 37);
            this.lbl_nvldepense.TabIndex = 13;
            this.lbl_nvldepense.Text = "Création d\'une dépense";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnRAZ);
            this.groupBox1.Controls.Add(this.btnQuit);
            this.groupBox1.Controls.Add(this.btnValider);
            this.groupBox1.Controls.Add(this.clbBeneficiaires);
            this.groupBox1.Controls.Add(this.txtCommentaire);
            this.groupBox1.Controls.Add(this.udCout);
            this.groupBox1.Controls.Add(this.label12);
            this.groupBox1.Controls.Add(this.txtDepense);
            this.groupBox1.Controls.Add(this.cbxPayePar);
            this.groupBox1.Controls.Add(this.cbxEvenement);
            this.groupBox1.Controls.Add(this.checkBox1);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.dateTimePicker1);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.lvl_nomEvent);
            this.groupBox1.Location = new System.Drawing.Point(91, 49);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(677, 453);
            this.groupBox1.TabIndex = 14;
            this.groupBox1.TabStop = false;
            // 
            // btnRAZ
            // 
            this.btnRAZ.Location = new System.Drawing.Point(528, 375);
            this.btnRAZ.Name = "btnRAZ";
            this.btnRAZ.Size = new System.Drawing.Size(75, 23);
            this.btnRAZ.TabIndex = 19;
            this.btnRAZ.Text = "R-A-Z";
            this.btnRAZ.UseVisualStyleBackColor = true;
            this.btnRAZ.Click += new System.EventHandler(this.btn_RAZ_Click);
            // 
            // btnQuit
            // 
            this.btnQuit.Location = new System.Drawing.Point(528, 405);
            this.btnQuit.Name = "btnQuit";
            this.btnQuit.Size = new System.Drawing.Size(75, 23);
            this.btnQuit.TabIndex = 18;
            this.btnQuit.Text = "Quitter";
            this.btnQuit.UseVisualStyleBackColor = true;
            this.btnQuit.Click += new System.EventHandler(this.btn_Quit_Click);
            // 
            // btnValider
            // 
            this.btnValider.Location = new System.Drawing.Point(528, 346);
            this.btnValider.Name = "btnValider";
            this.btnValider.Size = new System.Drawing.Size(75, 23);
            this.btnValider.TabIndex = 17;
            this.btnValider.Text = "Valider";
            this.btnValider.UseVisualStyleBackColor = true;
            // 
            // clbBeneficiaires
            // 
            this.clbBeneficiaires.FormattingEnabled = true;
            this.clbBeneficiaires.Location = new System.Drawing.Point(48, 342);
            this.clbBeneficiaires.Name = "clbBeneficiaires";
            this.clbBeneficiaires.Size = new System.Drawing.Size(336, 79);
            this.clbBeneficiaires.TabIndex = 16;
            // 
            // txtCommentaire
            // 
            this.txtCommentaire.BackColor = System.Drawing.SystemColors.Window;
            this.txtCommentaire.Location = new System.Drawing.Point(47, 158);
            this.txtCommentaire.Name = "txtCommentaire";
            this.txtCommentaire.Size = new System.Drawing.Size(582, 96);
            this.txtCommentaire.TabIndex = 15;
            this.txtCommentaire.Text = "";
            // 
            // udCout
            // 
            this.udCout.Location = new System.Drawing.Point(131, 102);
            this.udCout.Name = "udCout";
            this.udCout.Size = new System.Drawing.Size(72, 20);
            this.udCout.TabIndex = 14;
            this.udCout.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(209, 104);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(13, 13);
            this.label12.TabIndex = 13;
            this.label12.Text = "€";
            // 
            // txtDepense
            // 
            this.txtDepense.BackColor = System.Drawing.SystemColors.Window;
            this.txtDepense.Location = new System.Drawing.Point(131, 67);
            this.txtDepense.Name = "txtDepense";
            this.txtDepense.Size = new System.Drawing.Size(253, 20);
            this.txtDepense.TabIndex = 11;
            // 
            // cbxPayePar
            // 
            this.cbxPayePar.FormattingEnabled = true;
            this.cbxPayePar.Location = new System.Drawing.Point(131, 291);
            this.cbxPayePar.Name = "cbxPayePar";
            this.cbxPayePar.Size = new System.Drawing.Size(253, 21);
            this.cbxPayePar.TabIndex = 10;
            // 
            // cbxEvenement
            // 
            this.cbxEvenement.BackColor = System.Drawing.SystemColors.Window;
            this.cbxEvenement.FormattingEnabled = true;
            this.cbxEvenement.Location = new System.Drawing.Point(131, 39);
            this.cbxEvenement.Name = "cbxEvenement";
            this.cbxEvenement.Size = new System.Drawing.Size(253, 21);
            this.cbxEvenement.TabIndex = 9;
            this.cbxEvenement.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(131, 324);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(108, 17);
            this.checkBox1.TabIndex = 8;
            this.checkBox1.Text = "Tout selectionner";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(51, 325);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(67, 13);
            this.label11.TabIndex = 7;
            this.label11.Text = "Bénéficiaires";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(51, 294);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(55, 13);
            this.label10.TabIndex = 6;
            this.label10.Text = "Payé par :";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(44, 141);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(68, 13);
            this.label9.TabIndex = 5;
            this.label9.Text = "Commentaire";
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(429, 55);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(200, 20);
            this.dateTimePicker1.TabIndex = 4;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(503, 39);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(30, 13);
            this.label8.TabIndex = 3;
            this.label8.Text = "Date";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(45, 104);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(35, 13);
            this.label7.TabIndex = 2;
            this.label7.Text = "Coût :";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(45, 72);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(79, 13);
            this.label6.TabIndex = 1;
            this.label6.Text = "Nom dépense :";
            // 
            // lvl_nomEvent
            // 
            this.lvl_nomEvent.AutoSize = true;
            this.lvl_nomEvent.Location = new System.Drawing.Point(45, 42);
            this.lvl_nomEvent.Name = "lvl_nomEvent";
            this.lvl_nomEvent.Size = new System.Drawing.Size(67, 13);
            this.lvl_nomEvent.TabIndex = 0;
            this.lvl_nomEvent.Text = "Evénement :";
            // 
            // btn_Accueil
            // 
            this.btn_Accueil.BackColor = System.Drawing.Color.Transparent;
            this.btn_Accueil.Location = new System.Drawing.Point(26, 85);
            this.btn_Accueil.Margin = new System.Windows.Forms.Padding(2);
            this.btn_Accueil.Name = "btn_Accueil";
            this.btn_Accueil.Size = new System.Drawing.Size(40, 45);
            this.btn_Accueil.TabIndex = 11;
            this.btn_Accueil.Text = "button1";
            this.btn_Accueil.UseVisualStyleBackColor = false;
            this.btn_Accueil.Click += new System.EventHandler(this.btn_Accueil_Click);
            // 
            // FrmLancement
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(766, 499);
            this.Controls.Add(this.lbl_nvldepense);
            this.Controls.Add(this.grbSection);
            this.Controls.Add(this.groupBox1);
            this.Name = "FrmLancement";
            this.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.Load += new System.EventHandler(this.FrmLancement_Load);
            this.grbSection.ResumeLayout(false);
            this.grbSection.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.udCout)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btn_Accueil;
        private System.Windows.Forms.Button btn_event;
        private System.Windows.Forms.Button btn_part;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btn_bilan;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btn_dep;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.GroupBox grbSection;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.Label lbl_nvldepense;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lvl_nomEvent;
        private System.Windows.Forms.TextBox txtDepense;
        private System.Windows.Forms.ComboBox cbxPayePar;
        private System.Windows.Forms.ComboBox cbxEvenement;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button btnRAZ;
        private System.Windows.Forms.Button btnQuit;
        private System.Windows.Forms.Button btnValider;
        private System.Windows.Forms.CheckedListBox clbBeneficiaires;
        private System.Windows.Forms.RichTextBox txtCommentaire;
        private System.Windows.Forms.NumericUpDown udCout;
        private System.Windows.Forms.Label label12;
    }
}

