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
            this.cbxFiltre = new System.Windows.Forms.ComboBox();
            this.chxFiltre = new System.Windows.Forms.CheckBox();
            this.dgvDepense = new System.Windows.Forms.DataGridView();
            this.btnChercher = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDepense)).BeginInit();
            this.SuspendLayout();
            // 
            // cbxEvenement
            // 
            this.cbxEvenement.FormattingEnabled = true;
            this.cbxEvenement.Location = new System.Drawing.Point(136, 50);
            this.cbxEvenement.Name = "cbxEvenement";
            this.cbxEvenement.Size = new System.Drawing.Size(221, 24);
            this.cbxEvenement.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(35, 53);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(79, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = "Evenement";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dgvDepense);
            this.groupBox1.Location = new System.Drawing.Point(13, 201);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(722, 333);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            // 
            // cbxFiltre
            // 
            this.cbxFiltre.FormattingEnabled = true;
            this.cbxFiltre.Location = new System.Drawing.Point(570, 53);
            this.cbxFiltre.Name = "cbxFiltre";
            this.cbxFiltre.Size = new System.Drawing.Size(165, 24);
            this.cbxFiltre.TabIndex = 3;
            // 
            // chxFiltre
            // 
            this.chxFiltre.AutoSize = true;
            this.chxFiltre.Location = new System.Drawing.Point(451, 53);
            this.chxFiltre.Name = "chxFiltre";
            this.chxFiltre.Size = new System.Drawing.Size(114, 21);
            this.chxFiltre.TabIndex = 5;
            this.chxFiltre.Text = "Filtrage  par :";
            this.chxFiltre.UseVisualStyleBackColor = true;
            // 
            // dgvDepense
            // 
            this.dgvDepense.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDepense.Location = new System.Drawing.Point(7, 22);
            this.dgvDepense.Name = "dgvDepense";
            this.dgvDepense.RowTemplate.Height = 24;
            this.dgvDepense.Size = new System.Drawing.Size(709, 305);
            this.dgvDepense.TabIndex = 0;
            // 
            // btnChercher
            // 
            this.btnChercher.Location = new System.Drawing.Point(635, 166);
            this.btnChercher.Name = "btnChercher";
            this.btnChercher.Size = new System.Drawing.Size(100, 29);
            this.btnChercher.TabIndex = 6;
            this.btnChercher.Text = "Rechercher";
            this.btnChercher.UseVisualStyleBackColor = true;
            // 
            // Dépenses
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(747, 546);
            this.Controls.Add(this.btnChercher);
            this.Controls.Add(this.chxFiltre);
            this.Controls.Add(this.cbxFiltre);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cbxEvenement);
            this.Name = "Dépenses";
            this.Text = "Dépenses";
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDepense)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cbxEvenement;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView dgvDepense;
        private System.Windows.Forms.ComboBox cbxFiltre;
        private System.Windows.Forms.CheckBox chxFiltre;
        private System.Windows.Forms.Button btnChercher;
    }
}