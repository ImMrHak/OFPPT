using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OFPPT_Directeur
{
    public partial class LoginScreen : Form
    {
        Connect C = new Connect();
        public static string cin, nom, prenom, role;
        int mov, movX, movY;
        public LoginScreen()
        {
            InitializeComponent();
            try
            {
                HidePass.Hide();
                txtCIN.Text = Properties.Settings.Default.CIN;
                txtPass.Text = Properties.Settings.Default.PASS;
                this.Location = Screen.AllScreens[1].WorkingArea.Location;
            }
            catch(Exception ex)
            {
                
            }
        }
        private void SeePass_Click(object sender, EventArgs e)
        {
            txtPass.PasswordChar = '\0';
            SeePass.Hide();
            HidePass.Show();
        }
        private void panelGrabMov_MouseDown(object sender, MouseEventArgs e)
        {
            mov = 1;
            movX = e.X;
            movY = e.Y;
        }
        private void panelGrabMov_MouseMove(object sender, MouseEventArgs e)
        {
            if (mov == 1)
            {
                this.SetDesktopLocation(MousePosition.X - movX, MousePosition.Y - movY);
            }
        }
        private void panelGrabMov_MouseUp(object sender, MouseEventArgs e)
        {
            mov = 0;
        }
        private void HidePass_Click(object sender, EventArgs e)
        {
            txtPass.PasswordChar = '*';
            HidePass.Hide();
            SeePass.Show();
        }
        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void btnMinimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
        private void btnConnecter_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtCIN.Text == "" || txtPass.Text == "")
                {
                    MessageBox.Show("Veuillez remplir les champs");
                }
                else
                {
                    C.Connection("SELECT COUNT(*) FROM Users WHERE u_cin='" + txtCIN.Text + "' AND u_pass='" + txtPass.Text + "' AND r_ID='3' AND IsDeleted='FALSE'");
                    int resultquery = Convert.ToInt32(C.Cmd.ExecuteScalar().ToString());
                    C.Deconnection();
                    if (resultquery == 1)
                    {
                        C.Connection("SELECT U.u_nom, U.u_prenom, R.r_role FROM Users U, Roles R WHERE U.u_cin ='" + txtCIN.Text + "' AND u_pass='" + txtPass.Text + "' AND U.r_ID=R.r_ID");
                        C.Dr = C.Cmd.ExecuteReader();
                        while (C.Dr.Read())
                        {
                            cin = txtCIN.Text;
                            nom = C.Dr[0].ToString();
                            prenom = C.Dr[1].ToString();
                            role = C.Dr[2].ToString();
                        }
                        C.Deconnection();
                        if (checkRememberMe.Checked)
                        {
                            Properties.Settings.Default.CIN = txtCIN.Text;
                            Properties.Settings.Default.PASS = txtPass.Text;
                            Properties.Settings.Default.Save();
                            HomeScreen HS = new HomeScreen();
                            this.Hide();
                            HS.Show();
                        }
                        else
                        {
                            Properties.Settings.Default.CIN = "";
                            Properties.Settings.Default.PASS = "";
                            Properties.Settings.Default.Save();
                            HomeScreen HS = new HomeScreen();
                            this.Hide();
                            HS.Show();
                        }
                    }
                    else
                    {
                        MessageBox.Show("Votre cin ou mot de passe est incorrecte !");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
