using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Gecko;

namespace HeyBuddy
{
    public partial class WebLogin : Form
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

        public WebLogin()
        {
            appdataLoc = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            InitializeComponent();
            textBox1.Hide();
            textBox1.Text = "https://account.eslgaming.com/login";
            Xpcom.Initialize("Firefox");
            geckoWebBrowser1.Navigate(textBox1.Text);

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

        private void WebLogin_Load(object sender, EventArgs e)
        {
            
        }

        private void btnWebLogin_Click(object sender, EventArgs e)
        {
            WebRequest req = HttpWebRequest.Create("http://play.eslgaming.com/admin_tickets");
            req.Method = "GET";

            string source;
            using (StreamReader reader = new StreamReader(req.GetResponse().GetResponseStream()))
            {
                source = reader.ReadToEnd();
            }

            int first;
            int second;



            System.IO.File.WriteAllText(folder + "/test.txt", source);
        }
    }
}
