using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;
using System.Windows.Forms;
using Gecko;
using Timer = System.Timers.Timer;




namespace HeyBuddy
{
    public partial class WebLogin : Form
    {
        string appLoc = ".HeyBuddy/log/";
        string appdataLoc;

        string folder
        {
            get
            {
                return Path.Combine(appdataLoc, appLoc);
            }
        }

        bool buddyactive = false;
        int filenum = 2;

        public WebLogin()
        {
            appdataLoc = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            InitializeComponent();
            textBox1.Hide();
            textBox1.Text = "https://account.eslgaming.com/login";
            Xpcom.Initialize("Firefox");
            geckoWebBrowser1.Navigate(textBox1.Text);


            btnWebLogin.Text = "Redirect to ESL Admin tickets page";
            btnWebConfirm.Text = "Active HeyBuddy! system [Please log in first]";
            btnWebConfirm.Enabled = false;


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
            btnWebConfirm.Enabled = true;
            textBox1.Text = "http://play.eslgaming.com/admin_tickets";
            geckoWebBrowser1.Navigate(textBox1.Text);
            btnWebLogin.Text = "Redirecting...";
            new System.Threading.Timer((Object stateInfo) => { Console.WriteLine("7 sec"); }, new AutoResetEvent(false), 0, 7000);
            btnWebLogin.Text = "Done! You can active it!";

        }


        private void GetHtml()
        {
            GeckoHtmlElement element = null;
            var geckoDomElement = geckoWebBrowser1.Document.DocumentElement;
            if (geckoDomElement is GeckoHtmlElement)
            {
                element = (GeckoHtmlElement)geckoDomElement;
                var innerHtml = element.InnerHtml;
            }

            System.IO.File.WriteAllText(folder + "/esl_log" + filenum + ".txt", element.InnerHtml);
            filenum += 1;
            
        }

        public void Wait(int ms)
        {
            DateTime start = DateTime.Now;
            while ((DateTime.Now - start).TotalMilliseconds < ms)
                Application.DoEvents();

        }

        private bool FileCompare(string file1, string file2)
        {
            int file1byte;
            int file2byte;
            FileStream fs1;
            FileStream fs2;

            // Determine if the same file was referenced two times.
            if (file1 == file2)
            {
                // Return true to indicate that the files are the same.
                return true;
            }

            // Open the two files.
            fs1 = new FileStream(file1, FileMode.Open, FileAccess.Read);
            fs2 = new FileStream(file2, FileMode.Open, FileAccess.Read);

            // Check the file sizes. If they are not the same, the files 
            // are not the same.
            if (fs1.Length != fs2.Length)
            {
                // Close the file
                fs1.Close();
                fs2.Close();

                // Return false to indicate files are different
                return false;
            }

            // Read and compare a byte from each file until either a
            // non-matching set of bytes is found or until the end of
            // file1 is reached.
            do
            {
                // Read one byte from each file.
                file1byte = fs1.ReadByte();
                file2byte = fs2.ReadByte();
            }
            while ((file1byte == file2byte) && (file1byte != -1));

            // Close the files.
            fs1.Close();
            fs2.Close();

            return ((file1byte - file2byte) == 0);
        }

        private void btnWebConfirm_Click(object sender, EventArgs e)
        {
            buddyactive = true;


            while(buddyactive)
            {
                Wait(5000); // 1 sec = 1000
                GetHtml();

                string logname = "esl_log";
                string file0 = folder + logname + filenum + ".txt";
                string file1 = folder + logname + (filenum - 1)+ ".txt";
                string file2 = folder + logname + (filenum - 2) + ".txt";







                if (filenum > 2)
                {
                    string line = null;
                    string line_to_delete = "<!--<![endif]";

                    using (StreamReader reader = new StreamReader(file1))
                    {
                        using (StreamWriter writer = new StreamWriter(file2))
                        {
                            while ((line = reader.ReadLine()) != null)
                            {
                                if (String.Compare(line, line_to_delete) == 0)
                                    continue;

                                writer.WriteLine(line);
                            }
                        }
                    }

                    if (FileCompare(file1, file2))
                    {

                    }
                    else
                    {
                        Notification_Info("New ticket!", "Please check out the new ticket on play.eslgaming.com/admin_tickets");
                    }
                }


            }


        }

    }
}
