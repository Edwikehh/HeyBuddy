using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HeyBuddy
{
    public partial class Settings : UserControl
    {
        public Settings()
        {
            InitializeComponent();
        }

        private void Settings_Load(object sender, EventArgs e)
        {
            stgSec.Text = "Refresh time (sec)";
            stgSecBox.Enabled = false;
            stgWebLogin.Text = "Login";
            stgLogin.Text = "Log in with your ESL Account";
        }

        private void stgWebLogin_Click(object sender, EventArgs e)
        {
            Form weblog = new WebLogin();
            weblog.Show();
            Form form1 = new Form1();
            form1.Hide();
        }
    }
}
