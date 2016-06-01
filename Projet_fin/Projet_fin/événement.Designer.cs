namespace Projet_fin
{
    partial class événement
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
            System.Windows.Forms.TabControl tbcEve;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(événement));
            this.tab1a1 = new System.Windows.Forms.TabPage();
            this.rtbEveDescri = new System.Windows.Forms.RichTextBox();
            this.lblFin = new System.Windows.Forms.Label();
            this.lblDeb = new System.Windows.Forms.Label();
            this.LblEveInt = new System.Windows.Forms.Label();
            this.LblCréateur = new System.Windows.Forms.Label();
            this.lblFini = new System.Windows.Forms.Label();
            this.lblau = new System.Windows.Forms.Label();
            this.lbldu = new System.Windows.Forms.Label();
            this.lblDescri = new System.Windows.Forms.Label();
            this.lblInti = new System.Windows.Forms.Label();
            this.lblCrée = new System.Windows.Forms.Label();
            this.btnFin = new System.Windows.Forms.Button();
            this.btnSuiv = new System.Windows.Forms.Button();
            this.btnPre = new System.Windows.Forms.Button();
            this.BtnDebut = new System.Windows.Forms.Button();
            this.pgb_Prog = new System.Windows.Forms.ProgressBar();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblNumChange = new System.Windows.Forms.Label();
            this.lblNévé = new System.Windows.Forms.Label();
            this.ptb_événement = new System.Windows.Forms.PictureBox();
            this.tabCréeEve = new System.Windows.Forms.TabPage();
            this.btnInvitation = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnEnregister = new System.Windows.Forms.Button();
            this.cboCreateur = new System.Windows.Forms.ComboBox();
            this.lblCreateur = new System.Windows.Forms.Label();
            this.rtbDescript = new System.Windows.Forms.RichTextBox();
            this.lblEveDescript = new System.Windows.Forms.Label();
            this.dtpEveFin = new System.Windows.Forms.DateTimePicker();
            this.dtpEveDeb = new System.Windows.Forms.DateTimePicker();
            this.lblFinEve = new System.Windows.Forms.Label();
            this.lblDebut = new System.Windows.Forms.Label();
            this.grb2 = new System.Windows.Forms.GroupBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.lblTitre = new System.Windows.Forms.Label();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.cckRegle = new System.Windows.Forms.CheckBox();
            tbcEve = new System.Windows.Forms.TabControl();
            tbcEve.SuspendLayout();
            this.tab1a1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ptb_événement)).BeginInit();
            this.tabCréeEve.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.grb2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tbcEve
            // 
            tbcEve.Appearance = System.Windows.Forms.TabAppearance.FlatButtons;
            tbcEve.Controls.Add(this.tab1a1);
            tbcEve.Controls.Add(this.tabCréeEve);
            tbcEve.Location = new System.Drawing.Point(-5, -2);
            tbcEve.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            tbcEve.Name = "tbcEve";
            tbcEve.SelectedIndex = 0;
            tbcEve.Size = new System.Drawing.Size(1239, 671);
            tbcEve.TabIndex = 1;
            // 
            // tab1a1
            // 
            this.tab1a1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.tab1a1.Controls.Add(this.cckRegle);
            this.tab1a1.Controls.Add(this.rtbEveDescri);
            this.tab1a1.Controls.Add(this.lblFin);
            this.tab1a1.Controls.Add(this.lblDeb);
            this.tab1a1.Controls.Add(this.LblEveInt);
            this.tab1a1.Controls.Add(this.LblCréateur);
            this.tab1a1.Controls.Add(this.lblFini);
            this.tab1a1.Controls.Add(this.lblau);
            this.tab1a1.Controls.Add(this.lbldu);
            this.tab1a1.Controls.Add(this.lblDescri);
            this.tab1a1.Controls.Add(this.lblInti);
            this.tab1a1.Controls.Add(this.lblCrée);
            this.tab1a1.Controls.Add(this.btnFin);
            this.tab1a1.Controls.Add(this.btnSuiv);
            this.tab1a1.Controls.Add(this.btnPre);
            this.tab1a1.Controls.Add(this.BtnDebut);
            this.tab1a1.Controls.Add(this.pgb_Prog);
            this.tab1a1.Controls.Add(this.groupBox1);
            this.tab1a1.Location = new System.Drawing.Point(4, 28);
            this.tab1a1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tab1a1.Name = "tab1a1";
            this.tab1a1.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tab1a1.Size = new System.Drawing.Size(1231, 639);
            this.tab1a1.TabIndex = 0;
            this.tab1a1.Text = "Parcours des événements 1à1";
            // 
            // rtbEveDescri
            // 
            this.rtbEveDescri.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.rtbEveDescri.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rtbEveDescri.Location = new System.Drawing.Point(345, 287);
            this.rtbEveDescri.Name = "rtbEveDescri";
            this.rtbEveDescri.ReadOnly = true;
            this.rtbEveDescri.Size = new System.Drawing.Size(544, 52);
            this.rtbEveDescri.TabIndex = 19;
            this.rtbEveDescri.Text = "";
            // 
            // lblFin
            // 
            this.lblFin.Location = new System.Drawing.Point(500, 354);
            this.lblFin.Name = "lblFin";
            this.lblFin.Size = new System.Drawing.Size(95, 14);
            this.lblFin.TabIndex = 18;
            this.lblFin.Text = "**/**/****";
            // 
            // lblDeb
            // 
            this.lblDeb.Location = new System.Drawing.Point(292, 354);
            this.lblDeb.Name = "lblDeb";
            this.lblDeb.Size = new System.Drawing.Size(96, 16);
            this.lblDeb.TabIndex = 17;
            this.lblDeb.Text = "**/**/****";
            // 
            // LblEveInt
            // 
            this.LblEveInt.AutoSize = true;
            this.LblEveInt.Location = new System.Drawing.Point(359, 239);
            this.LblEveInt.Name = "LblEveInt";
            this.LblEveInt.Size = new System.Drawing.Size(137, 17);
            this.LblEveInt.TabIndex = 15;
            this.LblEveInt.Text = "Nom de l\'événement";
            // 
            // LblCréateur
            // 
            this.LblCréateur.AutoSize = true;
            this.LblCréateur.Location = new System.Drawing.Point(359, 181);
            this.LblCréateur.Name = "LblCréateur";
            this.LblCréateur.Size = new System.Drawing.Size(238, 17);
            this.LblCréateur.TabIndex = 14;
            this.LblCréateur.Text = "Changer par le nom de l\'oganisateur";
            // 
            // lblFini
            // 
            this.lblFini.AutoSize = true;
            this.lblFini.Location = new System.Drawing.Point(252, 409);
            this.lblFini.Name = "lblFini";
            this.lblFini.Size = new System.Drawing.Size(53, 17);
            this.lblFini.TabIndex = 11;
            this.lblFini.Text = "Réglé :";
            // 
            // lblau
            // 
            this.lblau.AutoSize = true;
            this.lblau.Location = new System.Drawing.Point(461, 354);
            this.lblau.Name = "lblau";
            this.lblau.Size = new System.Drawing.Size(32, 17);
            this.lblau.TabIndex = 10;
            this.lblau.Text = "au :";
            // 
            // lbldu
            // 
            this.lbldu.AutoSize = true;
            this.lbldu.Location = new System.Drawing.Point(252, 354);
            this.lbldu.Name = "lbldu";
            this.lbldu.Size = new System.Drawing.Size(34, 17);
            this.lbldu.TabIndex = 9;
            this.lbldu.Text = "Du :";
            // 
            // lblDescri
            // 
            this.lblDescri.AutoSize = true;
            this.lblDescri.Location = new System.Drawing.Point(252, 290);
            this.lblDescri.Name = "lblDescri";
            this.lblDescri.Size = new System.Drawing.Size(87, 17);
            this.lblDescri.TabIndex = 8;
            this.lblDescri.Text = "Description :";
            // 
            // lblInti
            // 
            this.lblInti.AutoSize = true;
            this.lblInti.Location = new System.Drawing.Point(252, 239);
            this.lblInti.Name = "lblInti";
            this.lblInti.Size = new System.Drawing.Size(57, 17);
            this.lblInti.TabIndex = 7;
            this.lblInti.Text = "Intitulé :";
            // 
            // lblCrée
            // 
            this.lblCrée.AutoSize = true;
            this.lblCrée.Location = new System.Drawing.Point(252, 181);
            this.lblCrée.Name = "lblCrée";
            this.lblCrée.Size = new System.Drawing.Size(71, 17);
            this.lblCrée.TabIndex = 6;
            this.lblCrée.Text = "Créé par :";
            // 
            // btnFin
            // 
            this.btnFin.Image = ((System.Drawing.Image)(resources.GetObject("btnFin.Image")));
            this.btnFin.Location = new System.Drawing.Point(717, 473);
            this.btnFin.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnFin.Name = "btnFin";
            this.btnFin.Size = new System.Drawing.Size(80, 62);
            this.btnFin.TabIndex = 5;
            this.btnFin.UseVisualStyleBackColor = true;
            this.btnFin.Click += new System.EventHandler(this.btnFin_Click);
            // 
            // btnSuiv
            // 
            this.btnSuiv.Image = ((System.Drawing.Image)(resources.GetObject("btnSuiv.Image")));
            this.btnSuiv.Location = new System.Drawing.Point(632, 473);
            this.btnSuiv.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnSuiv.Name = "btnSuiv";
            this.btnSuiv.Size = new System.Drawing.Size(80, 62);
            this.btnSuiv.TabIndex = 4;
            this.btnSuiv.UseVisualStyleBackColor = true;
            this.btnSuiv.Click += new System.EventHandler(this.button3_Click);
            // 
            // btnPre
            // 
            this.btnPre.Image = ((System.Drawing.Image)(resources.GetObject("btnPre.Image")));
            this.btnPre.Location = new System.Drawing.Point(515, 473);
            this.btnPre.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnPre.Name = "btnPre";
            this.btnPre.Size = new System.Drawing.Size(80, 62);
            this.btnPre.TabIndex = 3;
            this.btnPre.Text = "<";
            this.btnPre.UseVisualStyleBackColor = true;
            this.btnPre.Click += new System.EventHandler(this.btnPre_Click);
            // 
            // BtnDebut
            // 
            this.BtnDebut.Image = ((System.Drawing.Image)(resources.GetObject("BtnDebut.Image")));
            this.BtnDebut.Location = new System.Drawing.Point(428, 473);
            this.BtnDebut.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.BtnDebut.Name = "BtnDebut";
            this.BtnDebut.Size = new System.Drawing.Size(80, 62);
            this.BtnDebut.TabIndex = 2;
            this.BtnDebut.UseVisualStyleBackColor = true;
            this.BtnDebut.Click += new System.EventHandler(this.BtnDebut_Click);
            // 
            // pgb_Prog
            // 
            this.pgb_Prog.Location = new System.Drawing.Point(485, 539);
            this.pgb_Prog.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pgb_Prog.Name = "pgb_Prog";
            this.pgb_Prog.Size = new System.Drawing.Size(255, 36);
            this.pgb_Prog.TabIndex = 1;
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.groupBox1.Controls.Add(this.lblNumChange);
            this.groupBox1.Controls.Add(this.lblNévé);
            this.groupBox1.Controls.Add(this.ptb_événement);
            this.groupBox1.Location = new System.Drawing.Point(-4, -36);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox1.Size = new System.Drawing.Size(1235, 176);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // lblNumChange
            // 
            this.lblNumChange.AutoSize = true;
            this.lblNumChange.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNumChange.Location = new System.Drawing.Point(555, 89);
            this.lblNumChange.Name = "lblNumChange";
            this.lblNumChange.Size = new System.Drawing.Size(42, 46);
            this.lblNumChange.TabIndex = 2;
            this.lblNumChange.Text = "1";
            // 
            // lblNévé
            // 
            this.lblNévé.AutoSize = true;
            this.lblNévé.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNévé.Location = new System.Drawing.Point(251, 89);
            this.lblNévé.Name = "lblNévé";
            this.lblNévé.Size = new System.Drawing.Size(291, 46);
            this.lblNévé.TabIndex = 1;
            this.lblNévé.Text = "Evénement n° :";
            // 
            // ptb_événement
            // 
            this.ptb_événement.ErrorImage = null;
            this.ptb_événement.Image = ((System.Drawing.Image)(resources.GetObject("ptb_événement.Image")));
            this.ptb_événement.Location = new System.Drawing.Point(165, 69);
            this.ptb_événement.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.ptb_événement.Name = "ptb_événement";
            this.ptb_événement.Size = new System.Drawing.Size(93, 86);
            this.ptb_événement.TabIndex = 0;
            this.ptb_événement.TabStop = false;
            // 
            // tabCréeEve
            // 
            this.tabCréeEve.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.tabCréeEve.Controls.Add(this.btnInvitation);
            this.tabCréeEve.Controls.Add(this.pictureBox1);
            this.tabCréeEve.Controls.Add(this.btnEnregister);
            this.tabCréeEve.Controls.Add(this.cboCreateur);
            this.tabCréeEve.Controls.Add(this.lblCreateur);
            this.tabCréeEve.Controls.Add(this.rtbDescript);
            this.tabCréeEve.Controls.Add(this.lblEveDescript);
            this.tabCréeEve.Controls.Add(this.dtpEveFin);
            this.tabCréeEve.Controls.Add(this.dtpEveDeb);
            this.tabCréeEve.Controls.Add(this.lblFinEve);
            this.tabCréeEve.Controls.Add(this.lblDebut);
            this.tabCréeEve.Controls.Add(this.grb2);
            this.tabCréeEve.ForeColor = System.Drawing.SystemColors.ControlText;
            this.tabCréeEve.Location = new System.Drawing.Point(4, 28);
            this.tabCréeEve.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabCréeEve.Name = "tabCréeEve";
            this.tabCréeEve.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabCréeEve.Size = new System.Drawing.Size(1231, 639);
            this.tabCréeEve.TabIndex = 1;
            this.tabCréeEve.Text = "Nouvel événement";
            // 
            // btnInvitation
            // 
            this.btnInvitation.Location = new System.Drawing.Point(897, 580);
            this.btnInvitation.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnInvitation.Name = "btnInvitation";
            this.btnInvitation.Size = new System.Drawing.Size(165, 37);
            this.btnInvitation.TabIndex = 13;
            this.btnInvitation.Text = "Lancer les invitations";
            this.btnInvitation.UseVisualStyleBackColor = true;
            // 
            // pictureBox1
            // 
            this.pictureBox1.ErrorImage = null;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(915, 478);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(120, 111);
            this.pictureBox1.TabIndex = 12;
            this.pictureBox1.TabStop = false;
            // 
            // btnEnregister
            // 
            this.btnEnregister.Location = new System.Drawing.Point(629, 519);
            this.btnEnregister.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnEnregister.Name = "btnEnregister";
            this.btnEnregister.Size = new System.Drawing.Size(121, 37);
            this.btnEnregister.TabIndex = 11;
            this.btnEnregister.Text = "Enregistrer";
            this.btnEnregister.UseVisualStyleBackColor = true;
            // 
            // cboCreateur
            // 
            this.cboCreateur.FormattingEnabled = true;
            this.cboCreateur.Location = new System.Drawing.Point(204, 527);
            this.cboCreateur.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cboCreateur.Name = "cboCreateur";
            this.cboCreateur.Size = new System.Drawing.Size(315, 24);
            this.cboCreateur.TabIndex = 10;
            // 
            // lblCreateur
            // 
            this.lblCreateur.AutoSize = true;
            this.lblCreateur.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCreateur.Location = new System.Drawing.Point(79, 528);
            this.lblCreateur.Name = "lblCreateur";
            this.lblCreateur.Size = new System.Drawing.Size(99, 24);
            this.lblCreateur.TabIndex = 9;
            this.lblCreateur.Text = "Créer par :";
            // 
            // rtbDescript
            // 
            this.rtbDescript.Location = new System.Drawing.Point(84, 343);
            this.rtbDescript.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.rtbDescript.Name = "rtbDescript";
            this.rtbDescript.Size = new System.Drawing.Size(760, 121);
            this.rtbDescript.TabIndex = 8;
            this.rtbDescript.Text = "";
            // 
            // lblEveDescript
            // 
            this.lblEveDescript.AutoSize = true;
            this.lblEveDescript.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEveDescript.Location = new System.Drawing.Point(79, 315);
            this.lblEveDescript.Name = "lblEveDescript";
            this.lblEveDescript.Size = new System.Drawing.Size(114, 24);
            this.lblEveDescript.TabIndex = 7;
            this.lblEveDescript.Text = "Description :";
            // 
            // dtpEveFin
            // 
            this.dtpEveFin.Location = new System.Drawing.Point(579, 254);
            this.dtpEveFin.Margin = new System.Windows.Forms.Padding(4);
            this.dtpEveFin.Name = "dtpEveFin";
            this.dtpEveFin.Size = new System.Drawing.Size(265, 22);
            this.dtpEveFin.TabIndex = 6;
            // 
            // dtpEveDeb
            // 
            this.dtpEveDeb.Location = new System.Drawing.Point(84, 254);
            this.dtpEveDeb.Margin = new System.Windows.Forms.Padding(4);
            this.dtpEveDeb.Name = "dtpEveDeb";
            this.dtpEveDeb.Size = new System.Drawing.Size(265, 22);
            this.dtpEveDeb.TabIndex = 5;
            // 
            // lblFinEve
            // 
            this.lblFinEve.AutoSize = true;
            this.lblFinEve.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFinEve.Location = new System.Drawing.Point(573, 206);
            this.lblFinEve.Name = "lblFinEve";
            this.lblFinEve.Size = new System.Drawing.Size(82, 24);
            this.lblFinEve.TabIndex = 4;
            this.lblFinEve.Text = "Date fin :";
            // 
            // lblDebut
            // 
            this.lblDebut.AutoSize = true;
            this.lblDebut.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDebut.Location = new System.Drawing.Point(79, 206);
            this.lblDebut.Name = "lblDebut";
            this.lblDebut.Size = new System.Drawing.Size(111, 24);
            this.lblDebut.TabIndex = 3;
            this.lblDebut.Text = "Date début :";
            // 
            // grb2
            // 
            this.grb2.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.grb2.Controls.Add(this.textBox1);
            this.grb2.Controls.Add(this.lblTitre);
            this.grb2.Location = new System.Drawing.Point(-4, -14);
            this.grb2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.grb2.Name = "grb2";
            this.grb2.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.grb2.Size = new System.Drawing.Size(1235, 178);
            this.grb2.TabIndex = 0;
            this.grb2.TabStop = false;
            // 
            // textBox1
            // 
            this.textBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.Location = new System.Drawing.Point(459, 71);
            this.textBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(524, 38);
            this.textBox1.TabIndex = 3;
            // 
            // lblTitre
            // 
            this.lblTitre.AutoSize = true;
            this.lblTitre.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitre.Location = new System.Drawing.Point(19, 62);
            this.lblTitre.Name = "lblTitre";
            this.lblTitre.Size = new System.Drawing.Size(400, 46);
            this.lblTitre.TabIndex = 2;
            this.lblTitre.Text = "Titre de l\'événement :";
            // 
            // tabPage1
            // 
            this.tabPage1.Location = new System.Drawing.Point(0, 0);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Size = new System.Drawing.Size(200, 100);
            this.tabPage1.TabIndex = 0;
            // 
            // tabPage2
            // 
            this.tabPage2.Location = new System.Drawing.Point(0, 0);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Size = new System.Drawing.Size(200, 100);
            this.tabPage2.TabIndex = 0;
            // 
            // cckRegle
            // 
            this.cckRegle.AutoSize = true;
            this.cckRegle.Enabled = false;
            this.cckRegle.FlatAppearance.CheckedBackColor = System.Drawing.Color.White;
            this.cckRegle.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cckRegle.ForeColor = System.Drawing.SystemColors.ButtonShadow;
            this.cckRegle.Location = new System.Drawing.Point(321, 409);
            this.cckRegle.Name = "cckRegle";
            this.cckRegle.Size = new System.Drawing.Size(18, 17);
            this.cckRegle.TabIndex = 20;
            this.cckRegle.UseVisualStyleBackColor = true;
            // 
            // événement
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(1073, 655);
            this.Controls.Add(tbcEve);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "événement";
            this.Text = "événement";
            this.Load += new System.EventHandler(this.événement_Load);
            tbcEve.ResumeLayout(false);
            this.tab1a1.ResumeLayout(false);
            this.tab1a1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ptb_événement)).EndInit();
            this.tabCréeEve.ResumeLayout(false);
            this.tabCréeEve.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.grb2.ResumeLayout(false);
            this.grb2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tab1a1;
        private System.Windows.Forms.TabPage tabCréeEve;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnFin;
        private System.Windows.Forms.Button btnSuiv;
        private System.Windows.Forms.Button btnPre;
        private System.Windows.Forms.Button BtnDebut;
        private System.Windows.Forms.ProgressBar pgb_Prog;
        private System.Windows.Forms.Label lblNumChange;
        private System.Windows.Forms.Label lblNévé;
        private System.Windows.Forms.PictureBox ptb_événement;
        private System.Windows.Forms.Label lblFini;
        private System.Windows.Forms.Label lblau;
        private System.Windows.Forms.Label lbldu;
        private System.Windows.Forms.Label lblDescri;
        private System.Windows.Forms.Label lblInti;
        private System.Windows.Forms.Label lblCrée;
        private System.Windows.Forms.Label LblEveInt;
        private System.Windows.Forms.Label LblCréateur;
        private System.Windows.Forms.Label lblFin;
        private System.Windows.Forms.Label lblDeb;
        private System.Windows.Forms.GroupBox grb2;
        private System.Windows.Forms.Label lblTitre;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label lblFinEve;
        private System.Windows.Forms.Label lblDebut;
        private System.Windows.Forms.DateTimePicker dtpEveFin;
        private System.Windows.Forms.DateTimePicker dtpEveDeb;
        private System.Windows.Forms.Button btnInvitation;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btnEnregister;
        private System.Windows.Forms.ComboBox cboCreateur;
        private System.Windows.Forms.Label lblCreateur;
        private System.Windows.Forms.RichTextBox rtbDescript;
        private System.Windows.Forms.Label lblEveDescript;
        private System.Windows.Forms.RichTextBox rtbEveDescri;
        private System.Windows.Forms.CheckBox cckRegle;
    }
}