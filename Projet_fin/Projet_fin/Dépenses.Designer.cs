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
            this.cbxParticipant = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDepense)).BeginInit();
            this.SuspendLayout();
            // 
            // cbxEvenement
            // 
            this.cbxEvenement.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxEvenement.FormattingEnabled = true;
            this.cbxEvenement.Location = new System.Drawing.Point(120, 50);
            this.cbxEvenement.Name = "cbxEvenement";
            this.cbxEvenement.Size = new System.Drawing.Size(221, 24);
            this.cbxEvenement.TabIndex = 0;
            this.cbxEvenement.SelectedIndexChanged += new System.EventHandler(this.cbxEvenement_SelectedIndexChanged);
            this.cbxEvenement.SelectionChangeCommitted += new System.EventHandler(this.cbxEvenement_SelectionChangeCommitted);
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
            // dgvDepense
            // 
            this.dgvDepense.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDepense.Location = new System.Drawing.Point(7, 22);
            this.dgvDepense.Name = "dgvDepense";
            this.dgvDepense.RowTemplate.Height = 24;
            this.dgvDepense.Size = new System.Drawing.Size(629, 305);
            this.dgvDepense.TabIndex = 0;
            // 
            // chxAll
            // 
            this.chxAll.AutoSize = true;
            this.chxAll.Location = new System.Drawing.Point(38, 92);
            this.chxAll.Name = "chxAll";
            this.chxAll.Size = new System.Drawing.Size(213, 21);
            this.chxAll.TabIndex = 8;
            this.chxAll.Text = "Tous évenements confondus";
            this.chxAll.UseVisualStyleBackColor = true;
            this.chxAll.CheckedChanged += new System.EventHandler(this.chxAll_CheckedChanged);
            // 
            // cbxParticipant
            // 
            this.cbxParticipant.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxParticipant.FormattingEnabled = true;
            this.cbxParticipant.Location = new System.Drawing.Point(428, 50);
            this.cbxParticipant.Name = "cbxParticipant";
            this.cbxParticipant.Size = new System.Drawing.Size(221, 24);
            this.cbxParticipant.TabIndex = 9;
            this.cbxParticipant.SelectionChangeCommitted += new System.EventHandler(this.cbxParticipant_SelectionChangeCommitted);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(347, 53);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(75, 17);
            this.label2.TabIndex = 10;
            this.label2.Text = "Participant";
            // 
            // Dépenses
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(660, 546);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cbxParticipant);
            this.Controls.Add(this.chxAll);
            this.Controls.Add(this.cbxEvenement);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label1);
            this.Name = "Dépenses";
            this.Text = "Dépenses";
            this.Load += new System.EventHandler(this.Dépenses_Load);
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
        private System.Windows.Forms.CheckBox chxAll;
        private System.Windows.Forms.ComboBox cbxParticipant;
        private System.Windows.Forms.Label label2;
    }
}