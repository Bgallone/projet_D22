namespace Projet_fin
{
    partial class Dépenses
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
            this.cbxEvenement = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dgvDepense = new System.Windows.Forms.DataGridView();
            this.chxAll = new System.Windows.Forms.CheckBox();
            this.gbxCouleur = new System.Windows.Forms.GroupBox();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDepense)).BeginInit();
            this.gbxCouleur.SuspendLayout();
            this.SuspendLayout();
            // 
            // cbxEvenement
            // 
            this.cbxEvenement.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxEvenement.FormattingEnabled = true;
            this.cbxEvenement.Location = new System.Drawing.Point(190, 69);
            this.cbxEvenement.Name = "cbxEvenement";
            this.cbxEvenement.Size = new System.Drawing.Size(221, 24);
            this.cbxEvenement.TabIndex = 0;
            this.cbxEvenement.SelectedIndexChanged += new System.EventHandler(this.cbxEvenement_SelectedIndexChanged);
            this.cbxEvenement.SelectionChangeCommitted += new System.EventHandler(this.cbxEvenement_SelectionChangeCommitted);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(105, 69);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(79, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = "Evenement";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Transparent;
            this.groupBox1.Controls.Add(this.dgvDepense);
            this.groupBox1.Location = new System.Drawing.Point(34, 182);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(708, 360);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            // 
            // dgvDepense
            // 
            this.dgvDepense.AllowUserToAddRows = false;
            this.dgvDepense.AllowUserToDeleteRows = false;
            this.dgvDepense.AllowUserToResizeColumns = false;
            this.dgvDepense.AllowUserToResizeRows = false;
            this.dgvDepense.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dgvDepense.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDepense.Location = new System.Drawing.Point(34, 21);
            this.dgvDepense.Name = "dgvDepense";
            this.dgvDepense.RowTemplate.Height = 24;
            this.dgvDepense.Size = new System.Drawing.Size(629, 305);
            this.dgvDepense.TabIndex = 0;
            // 
            // chxAll
            // 
            this.chxAll.AutoSize = true;
            this.chxAll.Location = new System.Drawing.Point(471, 72);
            this.chxAll.Name = "chxAll";
            this.chxAll.Size = new System.Drawing.Size(213, 21);
            this.chxAll.TabIndex = 8;
            this.chxAll.Text = "Tous évenements confondus";
            this.chxAll.UseVisualStyleBackColor = true;
            this.chxAll.CheckedChanged += new System.EventHandler(this.chxAll_CheckedChanged);
            // 
            // gbxCouleur
            // 
            this.gbxCouleur.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.gbxCouleur.Controls.Add(this.chxAll);
            this.gbxCouleur.Controls.Add(this.cbxEvenement);
            this.gbxCouleur.Controls.Add(this.label1);
            this.gbxCouleur.Location = new System.Drawing.Point(-40, -34);
            this.gbxCouleur.Name = "gbxCouleur";
            this.gbxCouleur.Size = new System.Drawing.Size(868, 188);
            this.gbxCouleur.TabIndex = 11;
            this.gbxCouleur.TabStop = false;
            // 
            // Dépenses
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(788, 570);
            this.Controls.Add(this.gbxCouleur);
            this.Controls.Add(this.groupBox1);
            this.Name = "Dépenses";
            this.Text = "Dépenses";
            this.Load += new System.EventHandler(this.Dépenses_Load);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDepense)).EndInit();
            this.gbxCouleur.ResumeLayout(false);
            this.gbxCouleur.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox cbxEvenement;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView dgvDepense;
        private System.Windows.Forms.CheckBox chxAll;
        private System.Windows.Forms.GroupBox gbxCouleur;
    }
}