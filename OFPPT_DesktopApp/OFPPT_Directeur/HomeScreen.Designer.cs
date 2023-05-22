namespace OFPPT_Directeur
{
    partial class HomeScreen
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(HomeScreen));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panelGrabMov = new System.Windows.Forms.Panel();
            this.btnMinimize = new Guna.UI.WinForms.GunaButton();
            this.btnExit = new Guna.UI.WinForms.GunaButton();
            this.gunaPanel1 = new Guna.UI.WinForms.GunaPanel();
            this.btnDeconnecter = new Guna.UI.WinForms.GunaButton();
            this.btnParametres = new Guna.UI.WinForms.GunaButton();
            this.labEtablissement = new System.Windows.Forms.Label();
            this.gunaLabel2 = new Guna.UI.WinForms.GunaLabel();
            this.gunaLabel1 = new Guna.UI.WinForms.GunaLabel();
            this.loading_totalstudent = new Guna.UI.WinForms.GunaCircleProgressBar();
            this.NbTotalEtudiant = new Guna.UI.WinForms.GunaLabel();
            this.picture_user = new Guna.UI.WinForms.GunaCirclePictureBox();
            this.labFullName = new Guna.UI.WinForms.GunaLabel();
            this.combos_FullChoix = new Guna.UI.WinForms.GunaComboBox();
            this.gunaLabel3 = new Guna.UI.WinForms.GunaLabel();
            this.gunaGroupBox1 = new Guna.UI.WinForms.GunaGroupBox();
            this.gunaGroupBox2 = new Guna.UI.WinForms.GunaGroupBox();
            this.dgv_Etudiants = new Guna.UI.WinForms.GunaDataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Supprimer = new System.Windows.Forms.DataGridViewButtonColumn();
            this.panelGrabMov.SuspendLayout();
            this.gunaPanel1.SuspendLayout();
            this.loading_totalstudent.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picture_user)).BeginInit();
            this.gunaGroupBox1.SuspendLayout();
            this.gunaGroupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Etudiants)).BeginInit();
            this.SuspendLayout();
            // 
            // panelGrabMov
            // 
            this.panelGrabMov.Controls.Add(this.btnMinimize);
            this.panelGrabMov.Controls.Add(this.btnExit);
            this.panelGrabMov.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelGrabMov.Location = new System.Drawing.Point(0, 0);
            this.panelGrabMov.Name = "panelGrabMov";
            this.panelGrabMov.Size = new System.Drawing.Size(1260, 40);
            this.panelGrabMov.TabIndex = 2;
            this.panelGrabMov.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panelGrabMov_MouseDown);
            this.panelGrabMov.MouseMove += new System.Windows.Forms.MouseEventHandler(this.panelGrabMov_MouseMove);
            this.panelGrabMov.MouseUp += new System.Windows.Forms.MouseEventHandler(this.panelGrabMov_MouseUp);
            // 
            // btnMinimize
            // 
            this.btnMinimize.AnimationHoverSpeed = 0.07F;
            this.btnMinimize.AnimationSpeed = 0.03F;
            this.btnMinimize.BaseColor = System.Drawing.SystemColors.Control;
            this.btnMinimize.BorderColor = System.Drawing.Color.Black;
            this.btnMinimize.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btnMinimize.FocusedColor = System.Drawing.Color.Empty;
            this.btnMinimize.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
            this.btnMinimize.ForeColor = System.Drawing.Color.Black;
            this.btnMinimize.Image = null;
            this.btnMinimize.ImageSize = new System.Drawing.Size(20, 20);
            this.btnMinimize.Location = new System.Drawing.Point(1144, 0);
            this.btnMinimize.Name = "btnMinimize";
            this.btnMinimize.OnHoverBaseColor = System.Drawing.Color.Gray;
            this.btnMinimize.OnHoverBorderColor = System.Drawing.Color.Black;
            this.btnMinimize.OnHoverForeColor = System.Drawing.Color.White;
            this.btnMinimize.OnHoverImage = null;
            this.btnMinimize.OnPressedColor = System.Drawing.Color.Black;
            this.btnMinimize.Size = new System.Drawing.Size(55, 40);
            this.btnMinimize.TabIndex = 4;
            this.btnMinimize.Text = "-";
            this.btnMinimize.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.btnMinimize.Click += new System.EventHandler(this.btnMinimize_Click);
            // 
            // btnExit
            // 
            this.btnExit.AnimationHoverSpeed = 0.07F;
            this.btnExit.AnimationSpeed = 0.03F;
            this.btnExit.BaseColor = System.Drawing.SystemColors.Control;
            this.btnExit.BorderColor = System.Drawing.Color.Black;
            this.btnExit.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btnExit.FocusedColor = System.Drawing.Color.Empty;
            this.btnExit.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnExit.ForeColor = System.Drawing.Color.Black;
            this.btnExit.Image = null;
            this.btnExit.ImageSize = new System.Drawing.Size(20, 20);
            this.btnExit.Location = new System.Drawing.Point(1205, 0);
            this.btnExit.Name = "btnExit";
            this.btnExit.OnHoverBaseColor = System.Drawing.Color.Red;
            this.btnExit.OnHoverBorderColor = System.Drawing.Color.Black;
            this.btnExit.OnHoverForeColor = System.Drawing.Color.White;
            this.btnExit.OnHoverImage = null;
            this.btnExit.OnPressedColor = System.Drawing.Color.Black;
            this.btnExit.Size = new System.Drawing.Size(55, 40);
            this.btnExit.TabIndex = 2;
            this.btnExit.Text = "X";
            this.btnExit.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // gunaPanel1
            // 
            this.gunaPanel1.Controls.Add(this.btnDeconnecter);
            this.gunaPanel1.Controls.Add(this.btnParametres);
            this.gunaPanel1.Controls.Add(this.labEtablissement);
            this.gunaPanel1.Controls.Add(this.gunaLabel2);
            this.gunaPanel1.Controls.Add(this.gunaLabel1);
            this.gunaPanel1.Controls.Add(this.loading_totalstudent);
            this.gunaPanel1.Controls.Add(this.picture_user);
            this.gunaPanel1.Controls.Add(this.labFullName);
            this.gunaPanel1.Dock = System.Windows.Forms.DockStyle.Right;
            this.gunaPanel1.Location = new System.Drawing.Point(935, 40);
            this.gunaPanel1.Name = "gunaPanel1";
            this.gunaPanel1.Size = new System.Drawing.Size(325, 504);
            this.gunaPanel1.TabIndex = 3;
            // 
            // btnDeconnecter
            // 
            this.btnDeconnecter.AnimationHoverSpeed = 0.07F;
            this.btnDeconnecter.AnimationSpeed = 0.03F;
            this.btnDeconnecter.BackColor = System.Drawing.Color.Transparent;
            this.btnDeconnecter.BaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.btnDeconnecter.BorderColor = System.Drawing.Color.Black;
            this.btnDeconnecter.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btnDeconnecter.FocusedColor = System.Drawing.Color.Empty;
            this.btnDeconnecter.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnDeconnecter.ForeColor = System.Drawing.Color.White;
            this.btnDeconnecter.Image = null;
            this.btnDeconnecter.ImageAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.btnDeconnecter.ImageSize = new System.Drawing.Size(20, 20);
            this.btnDeconnecter.Location = new System.Drawing.Point(87, 193);
            this.btnDeconnecter.Name = "btnDeconnecter";
            this.btnDeconnecter.OnHoverBaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(151)))), ((int)(((byte)(143)))), ((int)(((byte)(255)))));
            this.btnDeconnecter.OnHoverBorderColor = System.Drawing.Color.Black;
            this.btnDeconnecter.OnHoverForeColor = System.Drawing.Color.White;
            this.btnDeconnecter.OnHoverImage = null;
            this.btnDeconnecter.OnPressedColor = System.Drawing.Color.Black;
            this.btnDeconnecter.Radius = 10;
            this.btnDeconnecter.Size = new System.Drawing.Size(160, 31);
            this.btnDeconnecter.TabIndex = 9;
            this.btnDeconnecter.Text = "Se Déconnecter";
            this.btnDeconnecter.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.btnDeconnecter.Click += new System.EventHandler(this.btnDeconnecter_Click);
            // 
            // btnParametres
            // 
            this.btnParametres.AnimationHoverSpeed = 0.07F;
            this.btnParametres.AnimationSpeed = 0.03F;
            this.btnParametres.BackColor = System.Drawing.Color.Transparent;
            this.btnParametres.BaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.btnParametres.BorderColor = System.Drawing.Color.Black;
            this.btnParametres.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btnParametres.FocusedColor = System.Drawing.Color.Empty;
            this.btnParametres.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnParametres.ForeColor = System.Drawing.Color.White;
            this.btnParametres.Image = null;
            this.btnParametres.ImageAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.btnParametres.ImageSize = new System.Drawing.Size(20, 20);
            this.btnParametres.Location = new System.Drawing.Point(87, 156);
            this.btnParametres.Name = "btnParametres";
            this.btnParametres.OnHoverBaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(151)))), ((int)(((byte)(143)))), ((int)(((byte)(255)))));
            this.btnParametres.OnHoverBorderColor = System.Drawing.Color.Black;
            this.btnParametres.OnHoverForeColor = System.Drawing.Color.White;
            this.btnParametres.OnHoverImage = null;
            this.btnParametres.OnPressedColor = System.Drawing.Color.Black;
            this.btnParametres.Radius = 10;
            this.btnParametres.Size = new System.Drawing.Size(160, 31);
            this.btnParametres.TabIndex = 8;
            this.btnParametres.Text = "Paramètres";
            this.btnParametres.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.btnParametres.Click += new System.EventHandler(this.btnParametres_Click);
            // 
            // labEtablissement
            // 
            this.labEtablissement.AutoSize = true;
            this.labEtablissement.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.7F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labEtablissement.Location = new System.Drawing.Point(3, 427);
            this.labEtablissement.Name = "labEtablissement";
            this.labEtablissement.Size = new System.Drawing.Size(128, 12);
            this.labEtablissement.TabIndex = 7;
            this.labEtablissement.Text = "Nom De L\'établissement";
            // 
            // gunaLabel2
            // 
            this.gunaLabel2.AutoSize = true;
            this.gunaLabel2.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.gunaLabel2.Location = new System.Drawing.Point(111, 390);
            this.gunaLabel2.Name = "gunaLabel2";
            this.gunaLabel2.Size = new System.Drawing.Size(112, 15);
            this.gunaLabel2.TabIndex = 6;
            this.gunaLabel2.Text = "De L\'établissement :";
            // 
            // gunaLabel1
            // 
            this.gunaLabel1.AutoSize = true;
            this.gunaLabel1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.gunaLabel1.Location = new System.Drawing.Point(89, 366);
            this.gunaLabel1.Name = "gunaLabel1";
            this.gunaLabel1.Size = new System.Drawing.Size(158, 15);
            this.gunaLabel1.TabIndex = 5;
            this.gunaLabel1.Text = "Nombres Total Des étudiants";
            // 
            // loading_totalstudent
            // 
            this.loading_totalstudent.AnimationSpeed = 0.6F;
            this.loading_totalstudent.BaseColor = System.Drawing.Color.White;
            this.loading_totalstudent.Controls.Add(this.NbTotalEtudiant);
            this.loading_totalstudent.IdleColor = System.Drawing.Color.Gainsboro;
            this.loading_totalstudent.IdleOffset = 20;
            this.loading_totalstudent.Image = null;
            this.loading_totalstudent.ImageSize = new System.Drawing.Size(52, 52);
            this.loading_totalstudent.Location = new System.Drawing.Point(103, 224);
            this.loading_totalstudent.Name = "loading_totalstudent";
            this.loading_totalstudent.ProgressMaxColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.loading_totalstudent.ProgressMinColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.loading_totalstudent.ProgressOffset = 20;
            this.loading_totalstudent.Size = new System.Drawing.Size(130, 130);
            this.loading_totalstudent.TabIndex = 4;
            // 
            // NbTotalEtudiant
            // 
            this.NbTotalEtudiant.AutoSize = true;
            this.NbTotalEtudiant.BackColor = System.Drawing.Color.White;
            this.NbTotalEtudiant.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.NbTotalEtudiant.Location = new System.Drawing.Point(59, 60);
            this.NbTotalEtudiant.Name = "NbTotalEtudiant";
            this.NbTotalEtudiant.Size = new System.Drawing.Size(13, 15);
            this.NbTotalEtudiant.TabIndex = 0;
            this.NbTotalEtudiant.Text = "0";
            // 
            // picture_user
            // 
            this.picture_user.BaseColor = System.Drawing.Color.White;
            this.picture_user.Image = ((System.Drawing.Image)(resources.GetObject("picture_user.Image")));
            this.picture_user.Location = new System.Drawing.Point(103, 9);
            this.picture_user.Name = "picture_user";
            this.picture_user.Size = new System.Drawing.Size(130, 120);
            this.picture_user.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picture_user.TabIndex = 1;
            this.picture_user.TabStop = false;
            this.picture_user.UseTransfarantBackground = false;
            // 
            // labFullName
            // 
            this.labFullName.AutoSize = true;
            this.labFullName.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.labFullName.Location = new System.Drawing.Point(102, 132);
            this.labFullName.Name = "labFullName";
            this.labFullName.Size = new System.Drawing.Size(131, 21);
            this.labFullName.TabIndex = 0;
            this.labFullName.Text = "Prénom Et Nom";
            this.labFullName.Click += new System.EventHandler(this.labFullName_Click);
            // 
            // combos_FullChoix
            // 
            this.combos_FullChoix.BackColor = System.Drawing.Color.Transparent;
            this.combos_FullChoix.BaseColor = System.Drawing.Color.White;
            this.combos_FullChoix.BorderColor = System.Drawing.Color.Silver;
            this.combos_FullChoix.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.combos_FullChoix.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.combos_FullChoix.FocusedColor = System.Drawing.Color.Empty;
            this.combos_FullChoix.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.combos_FullChoix.ForeColor = System.Drawing.Color.Black;
            this.combos_FullChoix.FormattingEnabled = true;
            this.combos_FullChoix.Location = new System.Drawing.Point(161, 40);
            this.combos_FullChoix.Name = "combos_FullChoix";
            this.combos_FullChoix.OnHoverItemBaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.combos_FullChoix.OnHoverItemForeColor = System.Drawing.Color.White;
            this.combos_FullChoix.Size = new System.Drawing.Size(756, 26);
            this.combos_FullChoix.TabIndex = 4;
            this.combos_FullChoix.SelectionChangeCommitted += new System.EventHandler(this.combos_FullChoix_SelectionChangeCommitted);
            // 
            // gunaLabel3
            // 
            this.gunaLabel3.AutoSize = true;
            this.gunaLabel3.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.gunaLabel3.Location = new System.Drawing.Point(5, 45);
            this.gunaLabel3.Name = "gunaLabel3";
            this.gunaLabel3.Size = new System.Drawing.Size(153, 15);
            this.gunaLabel3.TabIndex = 5;
            this.gunaLabel3.Text = "Veuillez Choisir La Bracnhe :";
            // 
            // gunaGroupBox1
            // 
            this.gunaGroupBox1.BackColor = System.Drawing.Color.Transparent;
            this.gunaGroupBox1.BaseColor = System.Drawing.Color.White;
            this.gunaGroupBox1.BorderColor = System.Drawing.Color.Gainsboro;
            this.gunaGroupBox1.Controls.Add(this.gunaGroupBox2);
            this.gunaGroupBox1.Controls.Add(this.combos_FullChoix);
            this.gunaGroupBox1.Controls.Add(this.gunaLabel3);
            this.gunaGroupBox1.LineColor = System.Drawing.Color.Gainsboro;
            this.gunaGroupBox1.Location = new System.Drawing.Point(12, 46);
            this.gunaGroupBox1.Name = "gunaGroupBox1";
            this.gunaGroupBox1.Size = new System.Drawing.Size(917, 495);
            this.gunaGroupBox1.TabIndex = 6;
            this.gunaGroupBox1.TextLocation = new System.Drawing.Point(10, 8);
            // 
            // gunaGroupBox2
            // 
            this.gunaGroupBox2.BackColor = System.Drawing.Color.Transparent;
            this.gunaGroupBox2.BaseColor = System.Drawing.Color.White;
            this.gunaGroupBox2.BorderColor = System.Drawing.Color.Gainsboro;
            this.gunaGroupBox2.Controls.Add(this.dgv_Etudiants);
            this.gunaGroupBox2.LineColor = System.Drawing.Color.Gainsboro;
            this.gunaGroupBox2.Location = new System.Drawing.Point(3, 72);
            this.gunaGroupBox2.Name = "gunaGroupBox2";
            this.gunaGroupBox2.Size = new System.Drawing.Size(914, 420);
            this.gunaGroupBox2.TabIndex = 6;
            this.gunaGroupBox2.Text = "Tous Les Etudiants de la branche séléctionée";
            this.gunaGroupBox2.TextLocation = new System.Drawing.Point(10, 8);
            // 
            // dgv_Etudiants
            // 
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            this.dgv_Etudiants.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgv_Etudiants.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgv_Etudiants.BackgroundColor = System.Drawing.Color.White;
            this.dgv_Etudiants.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgv_Etudiants.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgv_Etudiants.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv_Etudiants.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgv_Etudiants.ColumnHeadersHeight = 40;
            this.dgv_Etudiants.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column4,
            this.Column5,
            this.Column6,
            this.Supprimer});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgv_Etudiants.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgv_Etudiants.EnableHeadersVisualStyles = false;
            this.dgv_Etudiants.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgv_Etudiants.Location = new System.Drawing.Point(5, 38);
            this.dgv_Etudiants.Name = "dgv_Etudiants";
            this.dgv_Etudiants.RowHeadersVisible = false;
            this.dgv_Etudiants.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv_Etudiants.Size = new System.Drawing.Size(906, 379);
            this.dgv_Etudiants.TabIndex = 0;
            this.dgv_Etudiants.Theme = Guna.UI.WinForms.GunaDataGridViewPresetThemes.Guna;
            this.dgv_Etudiants.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.White;
            this.dgv_Etudiants.ThemeStyle.AlternatingRowsStyle.Font = null;
            this.dgv_Etudiants.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Empty;
            this.dgv_Etudiants.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.Empty;
            this.dgv_Etudiants.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Empty;
            this.dgv_Etudiants.ThemeStyle.BackColor = System.Drawing.Color.White;
            this.dgv_Etudiants.ThemeStyle.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgv_Etudiants.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.dgv_Etudiants.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgv_Etudiants.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            this.dgv_Etudiants.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.White;
            this.dgv_Etudiants.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            this.dgv_Etudiants.ThemeStyle.HeaderStyle.Height = 40;
            this.dgv_Etudiants.ThemeStyle.ReadOnly = false;
            this.dgv_Etudiants.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.White;
            this.dgv_Etudiants.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgv_Etudiants.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            this.dgv_Etudiants.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.dgv_Etudiants.ThemeStyle.RowsStyle.Height = 22;
            this.dgv_Etudiants.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgv_Etudiants.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.dgv_Etudiants.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_Etudiants_CellClick);
            this.dgv_Etudiants.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_Etudiants_CellContentClick);
            // 
            // Column1
            // 
            this.Column1.HeaderText = "CIN";
            this.Column1.Name = "Column1";
            // 
            // Column2
            // 
            this.Column2.HeaderText = "Nom";
            this.Column2.Name = "Column2";
            // 
            // Column3
            // 
            this.Column3.HeaderText = "Prénom";
            this.Column3.Name = "Column3";
            // 
            // Column4
            // 
            this.Column4.HeaderText = "CNE";
            this.Column4.Name = "Column4";
            // 
            // Column5
            // 
            this.Column5.HeaderText = "Email";
            this.Column5.Name = "Column5";
            // 
            // Column6
            // 
            this.Column6.HeaderText = "Numéro Téléphone";
            this.Column6.Name = "Column6";
            // 
            // Supprimer
            // 
            this.Supprimer.HeaderText = "Supprimer";
            this.Supprimer.Name = "Supprimer";
            this.Supprimer.ReadOnly = true;
            this.Supprimer.Text = "Supprimer";
            this.Supprimer.ToolTipText = "Supprimer";
            // 
            // HomeScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1260, 544);
            this.Controls.Add(this.gunaGroupBox1);
            this.Controls.Add(this.gunaPanel1);
            this.Controls.Add(this.panelGrabMov);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "HomeScreen";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "HomeScreen";
            this.panelGrabMov.ResumeLayout(false);
            this.gunaPanel1.ResumeLayout(false);
            this.gunaPanel1.PerformLayout();
            this.loading_totalstudent.ResumeLayout(false);
            this.loading_totalstudent.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picture_user)).EndInit();
            this.gunaGroupBox1.ResumeLayout(false);
            this.gunaGroupBox1.PerformLayout();
            this.gunaGroupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Etudiants)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelGrabMov;
        private Guna.UI.WinForms.GunaButton btnExit;
        private Guna.UI.WinForms.GunaButton btnMinimize;
        private Guna.UI.WinForms.GunaPanel gunaPanel1;
        private System.Windows.Forms.Label labEtablissement;
        private Guna.UI.WinForms.GunaLabel gunaLabel2;
        private Guna.UI.WinForms.GunaLabel gunaLabel1;
        private Guna.UI.WinForms.GunaCircleProgressBar loading_totalstudent;
        private Guna.UI.WinForms.GunaCirclePictureBox picture_user;
        private Guna.UI.WinForms.GunaLabel labFullName;
        private Guna.UI.WinForms.GunaComboBox combos_FullChoix;
        private Guna.UI.WinForms.GunaLabel gunaLabel3;
        private Guna.UI.WinForms.GunaGroupBox gunaGroupBox1;
        private Guna.UI.WinForms.GunaGroupBox gunaGroupBox2;
        private Guna.UI.WinForms.GunaDataGridView dgv_Etudiants;
        private Guna.UI.WinForms.GunaLabel NbTotalEtudiant;
        private Guna.UI.WinForms.GunaButton btnDeconnecter;
        private Guna.UI.WinForms.GunaButton btnParametres;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private System.Windows.Forms.DataGridViewButtonColumn Supprimer;
    }
}