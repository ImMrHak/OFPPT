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
    public partial class HomeScreen : Form
    {
        Connect C = new Connect();
        public static string studentcin, cin, nom, prenom, role, etablissement;
        public DataTable Dt;
        int mov, movX, movY;
        public HomeScreen()
        {
            InitializeComponent();
            try
            {
                labFullName.Text = LoginScreen.prenom + " " + LoginScreen.nom + "⬇️";
                btnParametres.Visible = false;
                btnDeconnecter.Visible = false;

                C.Connection("SELECT e_etablissement FROM Etablissement E, UserChoice UC WHERE UC.u_cin='" + LoginScreen.cin + "' AND UC.e_ID=E.e_ID");
                C.Dr = C.Cmd.ExecuteReader();
                while (C.Dr.Read())
                {
                    labEtablissement.Text = C.Dr[0].ToString();
                }
                etablissement = labEtablissement.Text;
                C.Deconnection();

                Dt = new DataTable();
                C.Connection("SELECT ch_ID, ch_Choix FROM Choix");
                C.Dr = C.Cmd.ExecuteReader();
                Dt.Load(C.Dr);
                C.Deconnection();

                combos_FullChoix.DataSource = Dt;
                combos_FullChoix.DisplayMember = "ch_Choix";
                combos_FullChoix.ValueMember = "ch_ID";

                C.Connection("SELECT COUNT(UC.u_cin) FROM UserChoice UC, Users U WHERE U.r_ID='1' AND UC.u_cin=U.u_cin AND UC.e_ID=(SELECT e_ID FROM UserChoice WHERE u_cin='" + LoginScreen.cin + "') AND U.IsDeleted='FALSE'");
                int NbTotal = Convert.ToInt32(C.Cmd.ExecuteScalar().ToString());
                NbTotalEtudiant.Text = NbTotal.ToString();
                loading_totalstudent.Value = NbTotal;
                C.Deconnection();

                DataGridViewButtonColumn btn = new DataGridViewButtonColumn();
                btn.Text = "Click Me";

                this.Location = Screen.AllScreens[1].WorkingArea.Location;
            }
            catch (Exception ex)
            {

            }
        }
        private void combos_FullChoix_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {
                dgv_Etudiants.Rows.Clear();
                dgv_Etudiants.Refresh();
                Dt = new DataTable();
                C.Connection("SELECT DISTINCT U.u_cin, U.u_nom, U.u_prenom, U.u_cne, U.u_email, U.u_tel FROM Genre G, Nationalite N, Scolarite S, Categorie C, Branche B, Etablissement E, Choix CH, Users U, UserInformations UI, UserChoice UC WHERE U.r_ID='1' AND FirstChoice='" + combos_FullChoix.SelectedValue.ToString() + "' AND UC.u_cin=U.u_cin AND UC.e_ID=(SELECT e_ID FROM UserChoice WHERE u_cin='" + LoginScreen.cin + "') AND U.g_ID=G.g_ID AND U.n_ID=N.n_ID AND UC.s_ID=S.s_ID AND UC.c_ID=C.c_ID AND UC.b_ID=B.b_ID AND UC.e_ID=E.e_ID AND UC.FirstChoice=CH.ch_ID AND U.IsDeleted='FALSE'");
                C.Dr = C.Cmd.ExecuteReader();
                while (C.Dr.Read())
                {
                    dgv_Etudiants.Rows.Add(C.Dr[0].ToString(), C.Dr[1].ToString(), C.Dr[2].ToString(), C.Dr[3].ToString(), C.Dr[4].ToString(), C.Dr[5].ToString());
                }
                C.Deconnection();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void labFullName_Click(object sender, EventArgs e)
        {
            try
            {
                btnParametres.Visible = true;
                btnDeconnecter.Visible = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }
        }
        private void btnDeconnecter_Click(object sender, EventArgs e)
        {
            try
            {
                LoginScreen LS = new LoginScreen();
                this.Hide();
                LS.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }
        }
        private void btnParametres_Click(object sender, EventArgs e)
        {
            try
            {
                SettingScreen SS = new SettingScreen();
                this.Hide();
                SS.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
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
        private void btnExit_Click(object sender, EventArgs e)
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
        private void btnMinimize_Click(object sender, EventArgs e)
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
        private void dgv_Etudiants_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (dgv_Etudiants.Columns[e.ColumnIndex].Name != "Supprimer")
                {
                    studentcin = dgv_Etudiants.CurrentRow.Cells[0].Value.ToString();

                    EditScreen ES = new EditScreen();
                    this.Hide();
                    ES.Show();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Veuillez selectionner un etudaint");
            }
        }
        private void dgv_Etudiants_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (dgv_Etudiants.Columns[e.ColumnIndex].Name == "Supprimer")
                {
                    C.Connection("UPDATE Users SET IsDeleted='TRUE' WHERE u_cin='" + dgv_Etudiants.CurrentRow.Cells[0].Value.ToString() + "'");
                    C.Cmd.ExecuteNonQuery();
                    C.Deconnection();
                    dgv_Etudiants.Refresh();
                    MessageBox.Show("Cet etudiant a ete supprimer avec succees");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Veuillez selectionner un etudaint");
            }
        }
    }
}
