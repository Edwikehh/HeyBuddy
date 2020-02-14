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
            textBox1.Text = "https://play.eslgaming.com/hungary/admin_tickets/?mytickets=t&killcache=true";
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

            Notification_Info("Activated!", "Please do NOT close the main window!");

            while(buddyactive)
            {
                
                //this.Hide();

                Wait(5000); // 1 sec = 1000
                GetHtml();

                string logname = "esl_log";
                string file0 = folder + logname + filenum + ".txt";
                string file1 = folder + logname + (filenum - 1)+ ".txt";
                string file2 = folder + logname + (filenum - 2) + ".txt";

                // <span id="userbar_timezone_time">14/02/20<br> 20:22h <span style="font-size: 9px">CET</span></span>
                string time = DateTime.Now.ToString("HH:mm");
                time = " "+ time + "h ";

                string span = "<span id=";
                const char cat = '"';
                string userbar = "userbar_timezone_time";
                string eV = ">";
                string br = "<br>";
                string span2 = "<span style=";
                string font = "font-size: 9px";
                string cet = ">CET</span></span>";
                DateTime date = DateTime.Now;
                string format = "yy";
                string year = (date.ToString(format));
                format = "dd";
                string day = (date.ToString(format));
                format = "MM";
                string month = (date.ToString(format));

                string search = "            " + span + cat + userbar + cat + eV + day + "/" + month + "/" + year + br + time + span2 + cat + font + cat + cet;
                Console.WriteLine(search);


                //<div style="display: none; visibility: hidden;"><script type="text/javascript">var axel=Math.random()+"",a=1E13*axel;document.write('\x3ciframe src\x3d"https://5663751.fls.doubleclick.net/activityi;src\x3d5663751;type\x3dview-0;cat\x3dpage-0;u1\x3dplay-eslgaming-Hungary;dc_lat\x3d;dc_rdid\x3d;tag_for_child_directed_treatment\x3d;ord\x3d'+a+'?" width\x3d"1" height\x3d"1" frameborder\x3d"0" style\x3d"display:none"\x3e\x3c/iframe\x3e');</script><iframe src="https://5663751.fls.doubleclick.net/activityi;src=5663751;type=view-0;cat=page-0;u1=play-eslgaming-Hungary;dc_lat=;dc_rdid=;tag_for_child_directed_treatment=;ord=7609103712189.395?" style="display:none" frameborder="0" height="1" width="1"></iframe>
                

                var tempFile = Path.GetTempFileName();
                var linesToKeep = File.ReadLines(file1).Where(l => l != search);

                File.WriteAllLines(tempFile, linesToKeep);

                File.Delete(file1);
                File.Move(tempFile, file1);

                string line = null;
                int line_number = 0;
                int line_to_delete = 2365;

                string sourcefile = System.IO.Path.Combine(folder, file1);
                string destFile = System.IO.Path.Combine(folder, "checkme.txt");
                System.IO.File.Copy(sourcefile, destFile, true);

                using (StreamReader reader = new StreamReader(destFile))
                {
                    using (StreamWriter writer = new StreamWriter(file1))
                    {
                        while ((line = reader.ReadLine()) != null)
                        {
                            line_number++;

                            if (line_number == line_to_delete)
                                continue;

                            writer.WriteLine(line);
                        }
                    }
                }



                if (filenum > 4)
                {
                    geckoWebBrowser1.Navigate(textBox1.Text);


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
