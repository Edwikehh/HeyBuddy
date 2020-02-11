using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HeyBuddy
{
    public partial class Form1 : Form
    {

        string appLoc = ".HeyBuddy/log";
        string appdataLoc;

        string folder
        {
            get
            {
                return Path.Combine(appdataLoc, appLoc);
            }
        }
        
        private void Notification_Info(string Title, string Text)
        {
            popUp.Visible = true;
            popUp.Icon = SystemIcons.Exclamation;
            popUp.BalloonTipTitle = Title;
            popUp.BalloonTipText = Text;
            popUp.BalloonTipIcon = ToolTipIcon.Info;
            popUp.ShowBalloonTip(1000);
        }


        private void FolderExist()
        {
            bool exist = Directory.Exists(folder);
            if(!exist)
            {
                Notification_Info("HeyBuddy", "First time? Creating new folder...");
                Directory.CreateDirectory(folder);

            }
        }

        public Form1()
        {
            appdataLoc = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            InitializeComponent();
        }

        private void LoadBtn()
        {
            btnMain.Text = "MAIN";
            btnMain.Enabled = false;
            btnSettings.Text = "SETTINGS";
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            settings1.Hide();
            LoadBtn();
            FolderExist();
        }

        private void btnSettings_Click(object sender, EventArgs e)
        {
            btnMain.Enabled = true;
            btnSettings.Enabled = false;
            welcome1.Hide();
            settings1.Show();
            
        }

        private void btnMain_Click(object sender, EventArgs e)
        {
            btnMain.Enabled = false;
            btnSettings.Enabled = true;
            settings1.Hide();
            welcome1.Show();
        }
    }
}
