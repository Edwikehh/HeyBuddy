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
            btnWebConfirm.Text = "Activate HeyBuddy!";
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

            if (file1 == file2)
            {
                return true;
            }

            fs1 = new FileStream(file1, FileMode.Open, FileAccess.Read);
            fs2 = new FileStream(file2, FileMode.Open, FileAccess.Read);


            if (fs1.Length != fs2.Length)
            {
                fs1.Close();
                fs2.Close();

                return false;
            }

            do
            {
                file1byte = fs1.ReadByte();
                file2byte = fs2.ReadByte();
            }
            while ((file1byte == file2byte) && (file1byte != -1));

            fs1.Close();
            fs2.Close();

            return ((file1byte - file2byte) == 0);
        }

        private int GetLineNum(string file1, string search)
        {
            int counter = 0;
            int counter_line = 0;
            string search_line;

            System.IO.StreamReader file = new System.IO.StreamReader(file1);

            while ((search_line = file.ReadLine()) != null)
            {
                if (search_line.Contains(search))
                {
                    Console.WriteLine(counter.ToString() + ": " + search_line);
                    counter_line = counter;
                }

                counter++;
            }
            file.Close();
            return counter_line;
        }

        private void DelRow(string file1, string search)
        {
            var tempFile = Path.GetTempFileName();
            var linesToKeep = File.ReadLines(file1).Where(l => l != search);

            File.WriteAllLines(tempFile, linesToKeep);

            File.Delete(file1);
            File.Move(tempFile, file1);
            
        }

        private void DelNumRow(string file1, int line_to_delete)
        {

            System.IO.StreamReader file = new System.IO.StreamReader(file1);
            string sourcefile = System.IO.Path.Combine(folder, file1);
            string destFile = System.IO.Path.Combine(folder, "checkme.txt");
            System.IO.File.Copy(sourcefile, destFile, true);
            file.Close();

            string line = null;
            int line_number = 0;

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
        }

        private void btnWebConfirm_Click(object sender, EventArgs e)
        {
            buddyactive = true;

            Notification_Info("Activated!", "Please do NOT close the main window!");


            while (buddyactive)
            {
                
                this.Hide();

                Wait(20000); // 1 sec = 1000
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

                string timedel = "            " + span + cat + userbar + cat + eV + day + "/" + month + "/" + year + br + time + span2 + cat + font + cat + cet;

                DelRow(file1, timedel);


                //<tr bgcolor="#E3E0DD">
                string tr1 = "<tr bgcolor=";
                tr1 = tr1 + cat + "#E3E0DD" + cat + ">";

                int delete = GetLineNum(file1, tr1) + 1;
                DelNumRow(file1, delete);
                delete = GetLineNum(file1, tr1) + 1;
                DelNumRow(file1, delete);



                //<tr bgcolor="#F5F4F3">
                string tr2 = tr1 + cat + "#F5F4F3" + cat + ">";
                delete = GetLineNum(file1, tr2) + 2;


                //<script id="" type="text/javascript">!function(b,e,f,g,a,c,d){b.fbq||(a=b.fbq=function(){a.callMethod?a.callMethod.apply(a,arguments):a.queue.push(arguments)},b._fbq||(b._fbq=a),a.push=a,a.loaded=!0,a.version="2.0",a.queue=[],c=e.createElement(f),c.async=!0,c.src=g,d=e.getElementsByTagName(f)[0],d.parentNode.insertBefore(c,d))}(window,document,
                //"script","//connect.facebook.net/en_US/fbevents.js");fbq("init","760967900616418");fbq("track","PageView");</script>
                string script = "<script id=";
                string type = "type=";
                string js = "text/javascript";
                string jss = ">!function(b,e,f,g,a,c,d){b.fbq||(a=b.fbq=function(){a.callMethod?a.callMethod.apply(a,arguments):a.queue.push(arguments)},b._fbq||(b._fbq=a),a.push=a,a.loaded=!0,a.version="; 
                string version = "2.0"; 
                string njss = ",a.queue=[],c=e.createElement(f),c.async=!0,c.src=g,d=e.getElementsByTagName(f)[0],d.parentNode.insertBefore(c,d))}(window,document,"; 
                string scrp = "script";
                string ves = ",";
                string fb = "//connect.facebook.net/en_US/fbevents.js"; 
                string fb2 = ");fbq("; 
                string fb3 = "init";
                string fb31 = "760967900616418";
                string fb4 = "track"; 
                string fb5 = "PageView"; 
                string fb6 = ");</script>";

                string allinone = script + cat + cat + " " + type + cat + js + cat + jss + cat + version + cat + njss + cat + scrp + cat + ves + cat + fb + cat + fb2 + cat + fb3 + cat + ves + cat + fb31 + cat + fb2 + cat + fb4 + cat + ves + cat + fb5 + cat + fb6;

                delete = GetLineNum(file1, allinone) + 3;
                DelNumRow(file1, delete);
                DelRow(file1, timedel);




                if (filenum > 4)
                {
                    geckoWebBrowser1.Navigate(textBox1.Text);


                    if (FileCompare(file1, file2))
                    {

                    }
                    else
                    {
                        Notification_Info("HeyBuddy! - New ticket!", "New ticket available on ESL Admin Tickets page!");
                    }
                }


            }


        }

    }
}
