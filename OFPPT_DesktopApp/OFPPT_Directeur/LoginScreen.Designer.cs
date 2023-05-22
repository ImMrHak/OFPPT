namespace OFPPT_Directeur
{
    partial class LoginScreen
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LoginScreen));
            this.gunaPictureBox1 = new Guna.UI.WinForms.GunaPictureBox();
            this.panelGrabMov = new System.Windows.Forms.Panel();
            this.btnMinimize = new Guna.UI.WinForms.GunaButton();
            this.btnExit = new Guna.UI.WinForms.GunaButton();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.txtCIN = new Guna.UI.WinForms.GunaTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtPass = new Guna.UI.WinForms.GunaTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnConnecter = new Guna.UI.WinForms.GunaButton();
            this.checkRememberMe = new Guna.UI.WinForms.GunaCheckBox();
            this.SeePass = new System.Windows.Forms.Button();
            this.HidePass = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.gunaPictureBox1)).BeginInit();
            this.panelGrabMov.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // gunaPictureBox1
            // 
            this.gunaPictureBox1.BaseColor = System.Drawing.Color.White;
            this.gunaPictureBox1.Dock = System.Windows.Forms.DockStyle.Left;
            this.gunaPictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("gunaPictureBox1.Image")));
            this.gunaPictureBox1.Location = new System.Drawing.Point(0, 0);
            this.gunaPictureBox1.Name = "gunaPictureBox1";
            this.gunaPictureBox1.Size = new System.Drawing.Size(523, 531);
            this.gunaPictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.gunaPictureBox1.TabIndex = 0;
            this.gunaPictureBox1.TabStop = false;
            // 
            // panelGrabMov
            // 
            this.panelGrabMov.Controls.Add(this.btnMinimize);
            this.panelGrabMov.Controls.Add(this.btnExit);
            this.panelGrabMov.Location = new System.Drawing.Point(0, 0);
            this.panelGrabMov.Name = "panelGrabMov";
            this.panelGrabMov.Size = new System.Drawing.Size(1000, 40);
            this.panelGrabMov.TabIndex = 1;
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
            this.btnMinimize.Location = new System.Drawing.Point(881, 0);
            this.btnMinimize.Name = "btnMinimize";
            this.btnMinimize.OnHoverBaseColor = System.Drawing.Color.Gray;
            this.btnMinimize.OnHoverBorderColor = System.Drawing.Color.Black;
            this.btnMinimize.OnHoverForeColor = System.Drawing.Color.White;
            this.btnMinimize.OnHoverImage = null;
            this.btnMinimize.OnPressedColor = System.Drawing.Color.Black;
            this.btnMinimize.Size = new System.Drawing.Size(55, 40);
            this.btnMinimize.TabIndex = 3;
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
            this.btnExit.Location = new System.Drawing.Point(942, 0);
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
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(703, 71);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(169, 119);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            // 
            // txtCIN
            // 
            this.txtCIN.BackColor = System.Drawing.Color.Transparent;
            this.txtCIN.BaseColor = System.Drawing.Color.White;
            this.txtCIN.BorderColor = System.Drawing.Color.Silver;
            this.txtCIN.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtCIN.FocusedBaseColor = System.Drawing.Color.White;
            this.txtCIN.FocusedBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.txtCIN.FocusedForeColor = System.Drawing.SystemColors.ControlText;
            this.txtCIN.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtCIN.Location = new System.Drawing.Point(664, 232);
            this.txtCIN.Name = "txtCIN";
            this.txtCIN.PasswordChar = '\0';
            this.txtCIN.Radius = 15;
            this.txtCIN.SelectedText = "";
            this.txtCIN.Size = new System.Drawing.Size(252, 40);
            this.txtCIN.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(612, 241);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 18);
            this.label1.TabIndex = 4;
            this.label1.Text = "CIN :";
            // 
            // txtPass
            // 
            this.txtPass.BackColor = System.Drawing.Color.Transparent;
            this.txtPass.BaseColor = System.Drawing.Color.White;
            this.txtPass.BorderColor = System.Drawing.Color.Silver;
            this.txtPass.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtPass.FocusedBaseColor = System.Drawing.Color.White;
            this.txtPass.FocusedBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.txtPass.FocusedForeColor = System.Drawing.SystemColors.ControlText;
            this.txtPass.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtPass.Location = new System.Drawing.Point(664, 305);
            this.txtPass.Name = "txtPass";
            this.txtPass.PasswordChar = '*';
            this.txtPass.Radius = 15;
            this.txtPass.SelectedText = "";
            this.txtPass.Size = new System.Drawing.Size(252, 38);
            this.txtPass.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(538, 314);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(120, 18);
            this.label2.TabIndex = 6;
            this.label2.Text = "Mot de passe :";
            // 
            // btnConnecter
            // 
            this.btnConnecter.AnimationHoverSpeed = 0.07F;
            this.btnConnecter.AnimationSpeed = 0.03F;
            this.btnConnecter.BackColor = System.Drawing.Color.Transparent;
            this.btnConnecter.BaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.btnConnecter.BorderColor = System.Drawing.Color.Black;
            this.btnConnecter.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btnConnecter.FocusedColor = System.Drawing.Color.Empty;
            this.btnConnecter.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnConnecter.ForeColor = System.Drawing.Color.White;
            this.btnConnecter.Image = null;
            this.btnConnecter.ImageSize = new System.Drawing.Size(20, 20);
            this.btnConnecter.Location = new System.Drawing.Point(703, 407);
            this.btnConnecter.Name = "btnConnecter";
            this.btnConnecter.OnHoverBaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(151)))), ((int)(((byte)(143)))), ((int)(((byte)(255)))));
            this.btnConnecter.OnHoverBorderColor = System.Drawing.Color.Black;
            this.btnConnecter.OnHoverForeColor = System.Drawing.Color.White;
            this.btnConnecter.OnHoverImage = null;
            this.btnConnecter.OnPressedColor = System.Drawing.Color.Black;
            this.btnConnecter.Radius = 15;
            this.btnConnecter.Size = new System.Drawing.Size(169, 49);
            this.btnConnecter.TabIndex = 10;
            this.btnConnecter.Text = "Se Connecter";
            this.btnConnecter.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.btnConnecter.Click += new System.EventHandler(this.btnConnecter_Click);
            // 
            // checkRememberMe
            // 
            this.checkRememberMe.BaseColor = System.Drawing.Color.White;
            this.checkRememberMe.Checked = true;
            this.checkRememberMe.CheckedOffColor = System.Drawing.Color.Gray;
            this.checkRememberMe.CheckedOnColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.checkRememberMe.FillColor = System.Drawing.Color.White;
            this.checkRememberMe.Location = new System.Drawing.Point(664, 359);
            this.checkRememberMe.Name = "checkRememberMe";
            this.checkRememberMe.Size = new System.Drawing.Size(138, 20);
            this.checkRememberMe.TabIndex = 11;
            this.checkRememberMe.Text = "Se Souvenir de moi ?";
            // 
            // SeePass
            // 
            this.SeePass.BackColor = System.Drawing.Color.White;
            this.SeePass.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("SeePass.BackgroundImage")));
            this.SeePass.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.SeePass.FlatAppearance.BorderSize = 0;
            this.SeePass.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.SeePass.Location = new System.Drawing.Point(881, 315);
            this.SeePass.Name = "SeePass";
            this.SeePass.Size = new System.Drawing.Size(21, 19);
            this.SeePass.TabIndex = 30;
            this.SeePass.UseVisualStyleBackColor = false;
            this.SeePass.Click += new System.EventHandler(this.SeePass_Click);
            // 
            // HidePass
            // 
            this.HidePass.BackColor = System.Drawing.Color.White;
            this.HidePass.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("HidePass.BackgroundImage")));
            this.HidePass.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.HidePass.FlatAppearance.BorderSize = 0;
            this.HidePass.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.HidePass.Location = new System.Drawing.Point(881, 315);
            this.HidePass.Name = "HidePass";
            this.HidePass.Size = new System.Drawing.Size(21, 19);
            this.HidePass.TabIndex = 29;
            this.HidePass.UseVisualStyleBackColor = false;
            this.HidePass.Click += new System.EventHandler(this.HidePass_Click);
            // 
            // LoginScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(996, 531);
            this.Controls.Add(this.SeePass);
            this.Controls.Add(this.HidePass);
            this.Controls.Add(this.checkRememberMe);
            this.Controls.Add(this.btnConnecter);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtPass);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtCIN);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.panelGrabMov);
            this.Controls.Add(this.gunaPictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "LoginScreen";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "LoginScreen";
            ((System.ComponentModel.ISupportInitialize)(this.gunaPictureBox1)).EndInit();
            this.panelGrabMov.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Guna.UI.WinForms.GunaPictureBox gunaPictureBox1;
        private System.Windows.Forms.Panel panelGrabMov;
        private Guna.UI.WinForms.GunaButton btnExit;
        private System.Windows.Forms.PictureBox pictureBox1;
        private Guna.UI.WinForms.GunaTextBox txtCIN;
        private System.Windows.Forms.Label label1;
        private Guna.UI.WinForms.GunaTextBox txtPass;
        private System.Windows.Forms.Label label2;
        private Guna.UI.WinForms.GunaButton btnConnecter;
        private Guna.UI.WinForms.GunaCheckBox checkRememberMe;
        private System.Windows.Forms.Button SeePass;
        private System.Windows.Forms.Button HidePass;
        private Guna.UI.WinForms.GunaButton btnMinimize;
    }
}