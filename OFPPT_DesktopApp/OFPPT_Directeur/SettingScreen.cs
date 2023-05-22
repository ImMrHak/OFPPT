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
    public partial class SettingScreen : Form
    {
        Connect C = new Connect();
        int mov, movX, movY;
        public SettingScreen()
        {
            InitializeComponent();
            try
            {
                labFullName.Text = LoginScreen.prenom + " " + LoginScreen.nom;
            }
            catch (Exception ex)
            {

            }
        }
        private void panelGrabMov_MouseDown(object sender, MouseEventArgs e)
        {
            try
            {
                mov = 1;
                movX = e.X;
                movY = e.Y;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void btnExits_Click(object sender, EventArgs e)
        {
            try
            {
                Application.Exit();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void btnMinimized_Click(object sender, EventArgs e)
        {
            try
            {
                this.WindowState = FormWindowState.Minimized;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void btnRetour_Click(object sender, EventArgs e)
        {
            try
            {
                HomeScreen HS = new HomeScreen();
                this.Hide();
                HS.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void btnModifierMotPass_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtMotPass.Text != txtNVMotPass.Text)
                {
                    MessageBox.Show("Votre mot de passe n'est pas identique");
                }
                else if(txtMotPass.Text == "" || txtNVMotPass.Text == "")
                {
                    MessageBox.Show("Veuillez remplir les champs");
                }
                else
                {
                    C.Connection("UPDATE Users SET u_pass='" + txtNVMotPass.Text + "' WHERE u_cin='" + LoginScreen.cin + "'");
                    C.Cmd.ExecuteNonQuery();
                    C.Deconnection();
                    MessageBox.Show("Votre mot de passe a ete modifier");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void panelGrabMov_MouseMove(object sender, MouseEventArgs e)
        {
            try
            {
                if (mov == 1)
                {
                    this.SetDesktopLocation(MousePosition.X - movX, MousePosition.Y - movY);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void panelGrabMov_MouseUp(object sender, MouseEventArgs e)
        {
            try
            {
                mov = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
