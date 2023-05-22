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
    public partial class EditScreen : Form
    {
        Connect C = new Connect();
        int mov, movX, movY;
        int i = 0;
        public DataTable Dt;
        public EditScreen()
        {
            InitializeComponent();
            try
            {
                labFullName.Text = LoginScreen.prenom + " " + LoginScreen.nom + "⬇️";
                labEtablissement.Text = HomeScreen.etablissement;
                btnParametres.Visible = false;
                btnDeconnecter.Visible = false;
                txtCin.Text = HomeScreen.studentcin;

                Dt = new DataTable();
                C.Connection("SELECT n_ID, n_nationalite FROM Nationalite");
                C.Dr = C.Cmd.ExecuteReader();
                Dt.Load(C.Dr);
                C.Deconnection();

                combosNatio.DataSource = Dt;
                combosNatio.DisplayMember = "n_nationalite";
                combosNatio.ValueMember = "n_ID";


                Dt = new DataTable();
                C.Connection("SELECT g_ID, g_genre FROM Genre");
                C.Dr = C.Cmd.ExecuteReader();
                Dt.Load(C.Dr);
                C.Deconnection();

                combosGenre.DataSource = Dt;
                combosGenre.DisplayMember = "g_genre";
                combosGenre.ValueMember = "g_ID";


                Dt = new DataTable();
                C.Connection("SELECT v_ID, v_ville FROM Ville");
                C.Dr = C.Cmd.ExecuteReader();
                Dt.Load(C.Dr);
                C.Deconnection();

                CombosVille.DataSource = Dt;
                CombosVille.DisplayMember = "v_ville";
                CombosVille.ValueMember = "v_ID";


                Dt = new DataTable();
                C.Connection("SELECT s_ID, s_scolarite FROM Scolarite");
                C.Dr = C.Cmd.ExecuteReader();
                Dt.Load(C.Dr);
                C.Deconnection();

                CombosScolarite.DataSource = Dt;
                CombosScolarite.DisplayMember = "s_scolarite";
                CombosScolarite.ValueMember = "s_ID";


                Dt = new DataTable();
                C.Connection("SELECT v_ID, v_ville FROM Ville");
                C.Dr = C.Cmd.ExecuteReader();
                Dt.Load(C.Dr);
                C.Deconnection();

                CombosVille1.DataSource = Dt;
                CombosVille1.DisplayMember = "v_ville";
                CombosVille1.ValueMember = "v_ID";


                Dt = new DataTable();
                C.Connection("SELECT c_ID, c_categorie FROM Categorie");
                C.Dr = C.Cmd.ExecuteReader();
                Dt.Load(C.Dr);
                C.Deconnection();

                CombosCategorie.DataSource = Dt;
                CombosCategorie.DisplayMember = "c_categorie";
                CombosCategorie.ValueMember = "c_ID";


                Dt = new DataTable();
                C.Connection("SELECT b_ID, b_branche FROM Branche");
                C.Dr = C.Cmd.ExecuteReader();
                Dt.Load(C.Dr);
                C.Deconnection();

                CombosBranche.DataSource = Dt;
                CombosBranche.DisplayMember = "b_branche";
                CombosBranche.ValueMember = "b_ID";


                Dt = new DataTable();
                C.Connection("SELECT e_ID, e_etablissement FROM Etablissement");
                C.Dr = C.Cmd.ExecuteReader();
                Dt.Load(C.Dr);
                C.Deconnection();

                CombosEtablissement.DataSource = Dt;
                CombosEtablissement.DisplayMember = "e_etablissement";
                CombosEtablissement.ValueMember = "e_ID";


                Dt = new DataTable();
                C.Connection("SELECT tf_ID, tf_typeformation FROM TypeFormation");
                C.Dr = C.Cmd.ExecuteReader();
                Dt.Load(C.Dr);
                C.Deconnection();

                CombosTypeFormation.DataSource = Dt;
                CombosTypeFormation.DisplayMember = "tf_typeformation";
                CombosTypeFormation.ValueMember = "tf_ID";


                Dt = new DataTable();
                C.Connection("SELECT nvf_ID, nvf_nvformation FROM NvFormation");
                C.Dr = C.Cmd.ExecuteReader();
                Dt.Load(C.Dr);
                C.Deconnection();

                CombosNvFormation.DataSource = Dt;
                CombosNvFormation.DisplayMember = "nvf_nvformation";
                CombosNvFormation.ValueMember = "nvf_ID";


                Dt = new DataTable();
                C.Connection("SELECT ch_id, ch_choix FROM Choix");
                C.Dr = C.Cmd.ExecuteReader();
                Dt.Load(C.Dr);
                C.Deconnection();

                CombosFirstChoice.DataSource = Dt;
                CombosFirstChoice.DisplayMember = "ch_choix";
                CombosFirstChoice.ValueMember = "ch_id";


                Dt = new DataTable();
                C.Connection("SELECT ch_id, ch_choix FROM Choix");
                C.Dr = C.Cmd.ExecuteReader();
                Dt.Load(C.Dr);
                C.Deconnection();

                CombosSecondChoice.DataSource = Dt;
                CombosSecondChoice.DisplayMember = "ch_choix";
                CombosSecondChoice.ValueMember = "ch_id";


                Dt = new DataTable();
                C.Connection("SELECT ch_id, ch_choix FROM Choix");
                C.Dr = C.Cmd.ExecuteReader();
                Dt.Load(C.Dr);
                C.Deconnection();

                CombosThirdChoice.DataSource = Dt;
                CombosThirdChoice.DisplayMember = "ch_choix";
                CombosThirdChoice.ValueMember = "ch_id";


                C.Connection("SELECT U.u_pass, U.u_cne, U.u_dtnaiss, U.u_email, U.u_nom, U.u_prenom, U.u_nomAr, U.u_prenomAr, U.u_tel, U.u_adresse, U.n_ID, U.g_ID, U.u_moyennegenbac, UI.ui_nompere, UI.ui_prenompere, UI.ui_cinpere, UI.ui_nommere, UI.ui_prenommere, UI.ui_cinmere, UI.v_ID, UC.s_ID, UC.c_ID, UC.b_ID, UC.v_ID, UC.e_ID, UC.tf_ID, UC.nvf_ID, UC.FirstChoice, UC.SecondChoice, UC.ThirdChoice FROM Users U, UserChoice UC, UserInformations UI WHERE U.u_cin='" + HomeScreen.studentcin + "' AND UC.u_cin=U.u_cin AND UI.u_cin=U.u_cin");
                C.Dr = C.Cmd.ExecuteReader();
                while (C.Dr.Read())
                {
                    txtPass.Text = C.Dr[0].ToString();
                    txtCne.Text = C.Dr[1].ToString();
                    datenaiss.Value = Convert.ToDateTime(C.Dr[2].ToString());
                    txtEmail.Text = C.Dr[3].ToString();
                    txtNom.Text = C.Dr[4].ToString();
                    txtPrenom.Text = C.Dr[5].ToString();
                    txtNomAr.Text = C.Dr[6].ToString();
                    txtPrenomAr.Text = C.Dr[7].ToString();
                    txtNumTel.Text = C.Dr[8].ToString();
                    txtAdresse.Text = C.Dr[9].ToString();
                    combosNatio.SelectedValue = Convert.ToInt32(C.Dr[10].ToString());
                    combosGenre.SelectedValue = Convert.ToInt32(C.Dr[11].ToString());
                    txtMoyenneGen.Text = C.Dr[12].ToString();
                    txtNomPere.Text = C.Dr[13].ToString();
                    txtPrenomPere.Text = C.Dr[14].ToString();
                    txtCinPere.Text = C.Dr[15].ToString();
                    txtNomMere.Text = C.Dr[16].ToString();
                    txtPrenomMere.Text = C.Dr[17].ToString();
                    txtCinMere.Text = C.Dr[18].ToString();
                    CombosVille.SelectedValue = Convert.ToInt32(C.Dr[19].ToString());
                    CombosScolarite.SelectedValue = Convert.ToInt32(C.Dr[20].ToString());
                    CombosCategorie.SelectedValue = Convert.ToInt32(C.Dr[21].ToString());
                    CombosBranche.SelectedValue = Convert.ToInt32(C.Dr[22].ToString());
                    CombosVille1.SelectedValue = Convert.ToInt32(C.Dr[23].ToString());
                    CombosEtablissement.SelectedValue = Convert.ToInt32(C.Dr[24].ToString());
                    CombosTypeFormation.SelectedValue = Convert.ToInt32(C.Dr[25].ToString());
                    CombosNvFormation.SelectedValue = Convert.ToInt32(C.Dr[26].ToString());
                    CombosFirstChoice.SelectedValue = Convert.ToInt32(C.Dr[27].ToString());
                    CombosSecondChoice.SelectedValue = Convert.ToInt32(C.Dr[28].ToString());
                    CombosThirdChoice.SelectedValue = Convert.ToInt32(C.Dr[29].ToString());
                }
                C.Deconnection();

                C.Connection("SELECT COUNT(UC.u_cin) FROM UserChoice UC, Users U WHERE U.r_ID='1' AND UC.u_cin=U.u_cin AND UC.e_ID=(SELECT e_ID FROM UserChoice WHERE u_cin='" + LoginScreen.cin + "') AND U.IsDeleted='FALSE'");
                int NbTotal = Convert.ToInt32(C.Cmd.ExecuteScalar().ToString());
                NbTotalEtudiant.Text = NbTotal.ToString();
                loading_totalstudent.Value = NbTotal;
                C.Deconnection();

                this.Location = Screen.AllScreens[1].WorkingArea.Location;
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
        private void btnValiderEtudiant_Click(object sender, EventArgs e)
        {
            try
            {
                if (i == 0)
                {
                    i++;
                    MessageBox.Show("Pour valider un etudiant il faut selectionner son choix dans son premier choix et puis appuyer sur le button (Valider L'Etudiant)");
                }
                else
                {
                    C.Connection("UPDATE Users SET IsCompleted='Oui' WHERE u_cin='" + HomeScreen.studentcin + "'");
                    C.Cmd.ExecuteNonQuery();
                    C.Deconnection();

                    C.Connection("UPDATE UserChoice SET ChoixAccepter='" + CombosFirstChoice.SelectedValue.ToString() + "'");
                    C.Cmd.ExecuteNonQuery();
                    C.Deconnection();
                    MessageBox.Show("L'etudiant a ete valider avec succee");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void btnModifierEtudiant_Click(object sender, EventArgs e)
        {
            try
            {
                C.Connection("UPDATE Users SET u_pass='" + txtCin.Text + "', u_cne='" + txtCne.Text + "', u_dtnaiss='" + datenaiss.Value + "', u_email='" + txtEmail.Text + "', u_nom='" + txtNom.Text + "', u_prenom='" + txtPrenom.Text + "', u_nomAr=N'" + txtNomAr.Text + "', u_prenomAr=N'" + txtPrenomAr.Text + "', u_adresse='" + txtAdresse.Text + "', u_tel='" + txtNumTel.Text + "', n_ID='" + combosNatio.SelectedValue.ToString() + "', g_ID='" + combosGenre.SelectedValue.ToString() + "', u_moyennegenbac='" + txtMoyenneGen.Text + "' WHERE u_cin='" + HomeScreen.studentcin + "'");
                C.Cmd.ExecuteNonQuery();
                C.Deconnection();

                C.Connection("UPDATE UserInformations SET ui_nompere='" + txtNomPere.Text + "', ui_prenompere='" + txtPrenomPere.Text + "', ui_cinpere='" + txtCinPere.Text + "', ui_nommere='" + txtNomMere.Text + "', ui_prenommere='" + txtPrenomMere.Text + "', ui_cinmere='" + txtCinMere.Text + "', v_ID='" + CombosVille.SelectedValue.ToString() + "' WHERE u_cin='" + HomeScreen.studentcin + "'");
                C.Cmd.ExecuteNonQuery();
                C.Deconnection();

                C.Connection("UPDATE UserChoice SET s_ID='" + CombosScolarite.SelectedValue.ToString() + "', c_ID='" + CombosCategorie.SelectedValue.ToString() + "', b_ID='" + CombosBranche.SelectedValue.ToString() + "', v_ID='" + CombosVille1.SelectedValue.ToString() + "', e_ID='" + CombosEtablissement.SelectedValue.ToString() + "', tf_ID='" + CombosTypeFormation.SelectedValue.ToString() + "', nvf_ID='" + CombosNvFormation.SelectedValue.ToString() + "', FirstChoice='" + CombosFirstChoice.SelectedValue.ToString() + "', SecondChoice='" + CombosSecondChoice.SelectedValue.ToString() + "', ThirdChoice='" + CombosThirdChoice.SelectedValue.ToString() + "' WHERE u_cin='" + HomeScreen.studentcin + "'");
                C.Cmd.ExecuteNonQuery();
                C.Deconnection();

                MessageBox.Show("L'Etudiant a ete modifier avec succee");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
