namespace Projet_fin
{
    partial class Bilan
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cbxEvenement = new System.Windows.Forms.ComboBox();
            this.cbxParticipant = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.dgvDépensé = new System.Windows.Forms.DataGridView();
            this.dgvArembourser = new System.Windows.Forms.DataGridView();
            this.btnBilanGlobal = new System.Windows.Forms.Button();
            this.btnBilan = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDépensé)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvArembourser)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(79, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Evénement";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 70);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(75, 17);
            this.label2.TabIndex = 1;
            this.label2.Text = "Participant";
            // 
            // cbxEvenement
            // 
            this.cbxEvenement.FormattingEnabled = true;
            this.cbxEvenement.Location = new System.Drawing.Point(99, 13);
            this.cbxEvenement.Name = "cbxEvenement";
            this.cbxEvenement.Size = new System.Drawing.Size(198, 24);
            this.cbxEvenement.TabIndex = 2;
            this.cbxEvenement.SelectionChangeCommitted += new System.EventHandler(this.cbxEvenement_SelectionChangeCommitted);
            // 
            // cbxParticipant
            // 
            this.cbxParticipant.FormattingEnabled = true;
            this.cbxParticipant.Location = new System.Drawing.Point(99, 67);
            this.cbxParticipant.Name = "cbxParticipant";
            this.cbxParticipant.Size = new System.Drawing.Size(198, 24);
            this.cbxParticipant.TabIndex = 3;
            this.cbxParticipant.SelectionChangeCommitted += new System.EventHandler(this.cbxParticipant_SelectionChangeCommitted);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 128);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 17);
            this.label3.TabIndex = 4;
            this.label3.Text = "Dépensé";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 402);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(94, 17);
            this.label4.TabIndex = 5;
            this.label4.Text = "A rembourser";
            // 
            // dgvDépensé
            // 
            this.dgvDépensé.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDépensé.Location = new System.Drawing.Point(16, 148);
            this.dgvDépensé.Name = "dgvDépensé";
            this.dgvDépensé.RowTemplate.Height = 24;
            this.dgvDépensé.Size = new System.Drawing.Size(530, 241);
            this.dgvDépensé.TabIndex = 6;
            // 
            // dgvArembourser
            // 
            this.dgvArembourser.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvArembourser.Location = new System.Drawing.Point(16, 422);
            this.dgvArembourser.Name = "dgvArembourser";
            this.dgvArembourser.RowTemplate.Height = 24;
            this.dgvArembourser.Size = new System.Drawing.Size(530, 221);
            this.dgvArembourser.TabIndex = 7;
            // 
            // btnBilanGlobal
            // 
            this.btnBilanGlobal.Location = new System.Drawing.Point(420, 12);
            this.btnBilanGlobal.Name = "btnBilanGlobal";
            this.btnBilanGlobal.Size = new System.Drawing.Size(126, 33);
            this.btnBilanGlobal.TabIndex = 8;
            this.btnBilanGlobal.Text = "Bilan global\r\n";
            this.btnBilanGlobal.UseVisualStyleBackColor = true;
            // 
            // btnBilan
            // 
            this.btnBilan.Location = new System.Drawing.Point(420, 70);
            this.btnBilan.Name = "btnBilan";
            this.btnBilan.Size = new System.Drawing.Size(126, 33);
            this.btnBilan.TabIndex = 9;
            this.btnBilan.Text = "Bilan";
            this.btnBilan.UseVisualStyleBackColor = true;
            this.btnBilan.Click += new System.EventHandler(this.btnBilan_Click);
            // 
            // Bilan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(554, 655);
            this.Controls.Add(this.btnBilan);
            this.Controls.Add(this.btnBilanGlobal);
            this.Controls.Add(this.dgvArembourser);
            this.Controls.Add(this.dgvDépensé);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cbxParticipant);
            this.Controls.Add(this.cbxEvenement);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "Bilan";
            this.Text = "Bilan";
            this.Load += new System.EventHandler(this.Bilan_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDépensé)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvArembourser)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbxEvenement;
        private System.Windows.Forms.ComboBox cbxParticipant;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DataGridView dgvDépensé;
        private System.Windows.Forms.DataGridView dgvArembourser;
        private System.Windows.Forms.Button btnBilanGlobal;
        private System.Windows.Forms.Button btnBilan;
    }
}