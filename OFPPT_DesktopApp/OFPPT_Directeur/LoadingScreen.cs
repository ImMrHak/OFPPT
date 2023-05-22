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
    public partial class LoadingScreen : Form
    {
        public LoadingScreen()
        {
            InitializeComponent();
        }
        private void timer_progressbar_Tick(object sender, EventArgs e)
        {
            try
            {
                loading_bar.Value = loading_bar.Value + 3;
                if (loading_bar.Value >= 100)
                {
                    timer_progressbar.Enabled = false;
                    LoginScreen LS = new LoginScreen();
                    this.Hide();
                    LS.Show();
                }
            }
            catch (Exception ex)
            {
                
            }
        }
    }
}
