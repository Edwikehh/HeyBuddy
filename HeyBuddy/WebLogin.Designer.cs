namespace HeyBuddy
{
    partial class WebLogin
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.geckoWebBrowser1 = new Gecko.GeckoWebBrowser();
            this.btnWebLogin = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.popUp = new System.Windows.Forms.NotifyIcon(this.components);
            this.btnWebConfirm = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // geckoWebBrowser1
            // 
            this.geckoWebBrowser1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.geckoWebBrowser1.FrameEventsPropagateToMainWindow = false;
            this.geckoWebBrowser1.Location = new System.Drawing.Point(0, 34);
            this.geckoWebBrowser1.Name = "geckoWebBrowser1";
            this.geckoWebBrowser1.Size = new System.Drawing.Size(750, 422);
            this.geckoWebBrowser1.TabIndex = 0;
            this.geckoWebBrowser1.UseHttpActivityObserver = false;
            // 
            // btnWebLogin
            // 
            this.btnWebLogin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnWebLogin.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(47)))), ((int)(((byte)(61)))));
            this.btnWebLogin.Location = new System.Drawing.Point(12, 6);
            this.btnWebLogin.Name = "btnWebLogin";
            this.btnWebLogin.Size = new System.Drawing.Size(354, 23);
            this.btnWebLogin.TabIndex = 1;
            this.btnWebLogin.Text = "button1";
            this.btnWebLogin.UseVisualStyleBackColor = true;
            this.btnWebLogin.Click += new System.EventHandler(this.btnWebLogin_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(638, 8);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 20);
            this.textBox1.TabIndex = 2;
            // 
            // popUp
            // 
            this.popUp.Text = "notifyIcon1";
            this.popUp.Visible = true;
            // 
            // btnWebConfirm
            // 
            this.btnWebConfirm.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnWebConfirm.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnWebConfirm.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(47)))), ((int)(((byte)(61)))));
            this.btnWebConfirm.Location = new System.Drawing.Point(384, 5);
            this.btnWebConfirm.Name = "btnWebConfirm";
            this.btnWebConfirm.Size = new System.Drawing.Size(354, 23);
            this.btnWebConfirm.TabIndex = 3;
            this.btnWebConfirm.Text = "button1";
            this.btnWebConfirm.UseVisualStyleBackColor = true;
            this.btnWebConfirm.Click += new System.EventHandler(this.btnWebConfirm_Click);
            // 
            // WebLogin
            // 
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(213)))), ((int)(((byte)(216)))), ((int)(((byte)(220)))));
            this.ClientSize = new System.Drawing.Size(750, 454);
            this.Controls.Add(this.btnWebConfirm);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.geckoWebBrowser1);
            this.Controls.Add(this.btnWebLogin);
            this.Name = "WebLogin";
            this.Text = "HeyBuddy! - ESL Login";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Gecko.GeckoWebBrowser geckoWebBrowser1;
        private System.Windows.Forms.Button btnWebLogin;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.NotifyIcon popUp;
        private System.Windows.Forms.Button btnWebConfirm;
    }
}