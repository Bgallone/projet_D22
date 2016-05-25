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
            this.btn_Accueil = new System.Windows.Forms.Button();
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
            this.btn_RAZ = new System.Windows.Forms.Button();
            this.btn_Quit = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.checkedListBox1 = new System.Windows.Forms.CheckedListBox();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.label12 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.lvl_nomEvent = new System.Windows.Forms.Label();
            this.grbSection.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            this.SuspendLayout();
            // 
            // btn_Accueil
            // 
            this.btn_Accueil.Location = new System.Drawing.Point(35, 105);
            this.btn_Accueil.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btn_Accueil.Name = "btn_Accueil";
            this.btn_Accueil.Size = new System.Drawing.Size(53, 55);
            this.btn_Accueil.TabIndex = 11;
            this.btn_Accueil.Text = "button1";
            this.btn_Accueil.UseVisualStyleBackColor = true;
            this.btn_Accueil.Click += new System.EventHandler(this.btn_Accueil_Click);
            // 
            // btn_event
            // 
            this.btn_event.Location = new System.Drawing.Point(33, 209);
            this.btn_event.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btn_event.Name = "btn_event";
            this.btn_event.Size = new System.Drawing.Size(53, 55);
            this.btn_event.TabIndex = 12;
            this.btn_event.Text = "button2";
            this.btn_event.UseVisualStyleBackColor = true;
            this.btn_event.Click += new System.EventHandler(this.btn_event_Click);
            // 
            // btn_part
            // 
            this.btn_part.Location = new System.Drawing.Point(33, 310);
            this.btn_part.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btn_part.Name = "btn_part";
            this.btn_part.Size = new System.Drawing.Size(53, 55);
            this.btn_part.TabIndex = 12;
            this.btn_part.Text = "button3";
            this.btn_part.UseVisualStyleBackColor = true;
            this.btn_part.Click += new System.EventHandler(this.btn_part_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(31, 475);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(72, 17);
            this.label4.TabIndex = 15;
            this.label4.Text = "Dépenses";
            // 
            // btn_bilan
            // 
            this.btn_bilan.Location = new System.Drawing.Point(33, 527);
            this.btn_bilan.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btn_bilan.Name = "btn_bilan";
            this.btn_bilan.Size = new System.Drawing.Size(53, 55);
            this.btn_bilan.TabIndex = 16;
            this.btn_bilan.Text = "button5";
            this.btn_bilan.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(33, 368);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(82, 17);
            this.label3.TabIndex = 13;
            this.label3.Text = "Participants";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(33, 267);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(86, 17);
            this.label2.TabIndex = 10;
            this.label2.Text = "Evénements";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(29, 162);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 17);
            this.label1.TabIndex = 7;
            this.label1.Text = "Accueil";
            // 
            // btn_dep
            // 
            this.btn_dep.Location = new System.Drawing.Point(33, 417);
            this.btn_dep.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btn_dep.Name = "btn_dep";
            this.btn_dep.Size = new System.Drawing.Size(53, 55);
            this.btn_dep.TabIndex = 14;
            this.btn_dep.Text = "button4";
            this.btn_dep.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(32, 585);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(39, 17);
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
            this.grbSection.Location = new System.Drawing.Point(-7, -9);
            this.grbSection.Margin = new System.Windows.Forms.Padding(0);
            this.grbSection.Name = "grbSection";
            this.grbSection.Padding = new System.Windows.Forms.Padding(0);
            this.grbSection.Size = new System.Drawing.Size(137, 626);
            this.grbSection.TabIndex = 11;
            this.grbSection.TabStop = false;
            // 
            // lbl_nvldepense
            // 
            this.lbl_nvldepense.AccessibleRole = System.Windows.Forms.AccessibleRole.TitleBar;
            this.lbl_nvldepense.AutoSize = true;
            this.lbl_nvldepense.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_nvldepense.Location = new System.Drawing.Point(324, 11);
            this.lbl_nvldepense.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl_nvldepense.Name = "lbl_nvldepense";
            this.lbl_nvldepense.Size = new System.Drawing.Size(464, 46);
            this.lbl_nvldepense.TabIndex = 13;
            this.lbl_nvldepense.Text = "Création d\'une dépense";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btn_RAZ);
            this.groupBox1.Controls.Add(this.btn_Quit);
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.checkedListBox1);
            this.groupBox1.Controls.Add(this.richTextBox1);
            this.groupBox1.Controls.Add(this.numericUpDown1);
            this.groupBox1.Controls.Add(this.label12);
            this.groupBox1.Controls.Add(this.textBox1);
            this.groupBox1.Controls.Add(this.comboBox2);
            this.groupBox1.Controls.Add(this.comboBox1);
            this.groupBox1.Controls.Add(this.checkBox1);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.dateTimePicker1);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.lvl_nomEvent);
            this.groupBox1.Location = new System.Drawing.Point(121, 60);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox1.Size = new System.Drawing.Size(903, 558);
            this.groupBox1.TabIndex = 14;
            this.groupBox1.TabStop = false;
            // 
            // btn_RAZ
            // 
            this.btn_RAZ.Location = new System.Drawing.Point(704, 462);
            this.btn_RAZ.Margin = new System.Windows.Forms.Padding(4);
            this.btn_RAZ.Name = "btn_RAZ";
            this.btn_RAZ.Size = new System.Drawing.Size(100, 28);
            this.btn_RAZ.TabIndex = 19;
            this.btn_RAZ.Text = "R-A-Z";
            this.btn_RAZ.UseVisualStyleBackColor = true;
            this.btn_RAZ.Click += new System.EventHandler(this.btn_RAZ_Click);
            // 
            // btn_Quit
            // 
            this.btn_Quit.Location = new System.Drawing.Point(704, 498);
            this.btn_Quit.Margin = new System.Windows.Forms.Padding(4);
            this.btn_Quit.Name = "btn_Quit";
            this.btn_Quit.Size = new System.Drawing.Size(100, 28);
            this.btn_Quit.TabIndex = 18;
            this.btn_Quit.Text = "Quitter";
            this.btn_Quit.UseVisualStyleBackColor = true;
            this.btn_Quit.Click += new System.EventHandler(this.btn_Quit_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(704, 426);
            this.button1.Margin = new System.Windows.Forms.Padding(4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(100, 28);
            this.button1.TabIndex = 17;
            this.button1.Text = "Valider";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // checkedListBox1
            // 
            this.checkedListBox1.FormattingEnabled = true;
            this.checkedListBox1.Location = new System.Drawing.Point(64, 421);
            this.checkedListBox1.Margin = new System.Windows.Forms.Padding(4);
            this.checkedListBox1.Name = "checkedListBox1";
            this.checkedListBox1.Size = new System.Drawing.Size(447, 106);
            this.checkedListBox1.TabIndex = 16;
            // 
            // richTextBox1
            // 
            this.richTextBox1.BackColor = System.Drawing.SystemColors.Window;
            this.richTextBox1.Location = new System.Drawing.Point(63, 194);
            this.richTextBox1.Margin = new System.Windows.Forms.Padding(4);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(775, 117);
            this.richTextBox1.TabIndex = 15;
            this.richTextBox1.Text = "";
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Location = new System.Drawing.Point(175, 126);
            this.numericUpDown1.Margin = new System.Windows.Forms.Padding(4);
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(96, 22);
            this.numericUpDown1.TabIndex = 14;
            this.numericUpDown1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(279, 128);
            this.label12.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(16, 17);
            this.label12.TabIndex = 13;
            this.label12.Text = "€";
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.SystemColors.Window;
            this.textBox1.Location = new System.Drawing.Point(175, 82);
            this.textBox1.Margin = new System.Windows.Forms.Padding(4);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(336, 22);
            this.textBox1.TabIndex = 11;
            // 
            // comboBox2
            // 
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Location = new System.Drawing.Point(175, 358);
            this.comboBox2.Margin = new System.Windows.Forms.Padding(4);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(336, 24);
            this.comboBox2.TabIndex = 10;
            // 
            // comboBox1
            // 
            this.comboBox1.BackColor = System.Drawing.SystemColors.Window;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(175, 48);
            this.comboBox1.Margin = new System.Windows.Forms.Padding(4);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(336, 24);
            this.comboBox1.TabIndex = 9;
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(175, 399);
            this.checkBox1.Margin = new System.Windows.Forms.Padding(4);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(140, 21);
            this.checkBox1.TabIndex = 8;
            this.checkBox1.Text = "Tout selectionner";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(68, 400);
            this.label11.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(89, 17);
            this.label11.TabIndex = 7;
            this.label11.Text = "Bénéficiaires";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(68, 362);
            this.label10.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(73, 17);
            this.label10.TabIndex = 6;
            this.label10.Text = "Payé par :";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(59, 174);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(91, 17);
            this.label9.TabIndex = 5;
            this.label9.Text = "Commentaire";
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(572, 68);
            this.dateTimePicker1.Margin = new System.Windows.Forms.Padding(4);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(265, 22);
            this.dateTimePicker1.TabIndex = 4;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(671, 48);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(38, 17);
            this.label8.TabIndex = 3;
            this.label8.Text = "Date";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(60, 128);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(45, 17);
            this.label7.TabIndex = 2;
            this.label7.Text = "Coût :";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(60, 89);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(104, 17);
            this.label6.TabIndex = 1;
            this.label6.Text = "Nom dépense :";
            // 
            // lvl_nomEvent
            // 
            this.lvl_nomEvent.AutoSize = true;
            this.lvl_nomEvent.Location = new System.Drawing.Point(60, 52);
            this.lvl_nomEvent.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lvl_nomEvent.Name = "lvl_nomEvent";
            this.lvl_nomEvent.Size = new System.Drawing.Size(87, 17);
            this.lvl_nomEvent.TabIndex = 0;
            this.lvl_nomEvent.Text = "Evénement :";
            // 
            // FrmLancement
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(1021, 614);
            this.Controls.Add(this.lbl_nvldepense);
            this.Controls.Add(this.grbSection);
            this.Controls.Add(this.groupBox1);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FrmLancement";
            this.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.grbSection.ResumeLayout(false);
            this.grbSection.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
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
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.ComboBox comboBox2;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button btn_RAZ;
        private System.Windows.Forms.Button btn_Quit;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.CheckedListBox checkedListBox1;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
        private System.Windows.Forms.Label label12;
    }
}

