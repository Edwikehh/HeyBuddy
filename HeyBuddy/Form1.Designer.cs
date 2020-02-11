namespace HeyBuddy
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnSettings = new System.Windows.Forms.Button();
            this.btnMain = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.popUp = new System.Windows.Forms.NotifyIcon(this.components);
            this.settings1 = new HeyBuddy.Settings();
            this.welcome1 = new HeyBuddy.Welcome();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(47)))), ((int)(((byte)(61)))));
            this.panel1.Controls.Add(this.btnSettings);
            this.panel1.Controls.Add(this.btnMain);
            this.panel1.Controls.Add(this.label1);
            resources.ApplyResources(this.panel1, "panel1");
            this.panel1.Name = "panel1";
            // 
            // btnSettings
            // 
            resources.ApplyResources(this.btnSettings, "btnSettings");
            this.btnSettings.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(213)))), ((int)(((byte)(216)))), ((int)(((byte)(220)))));
            this.btnSettings.Name = "btnSettings";
            this.btnSettings.UseVisualStyleBackColor = true;
            this.btnSettings.Click += new System.EventHandler(this.btnSettings_Click);
            // 
            // btnMain
            // 
            resources.ApplyResources(this.btnMain, "btnMain");
            this.btnMain.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(213)))), ((int)(((byte)(216)))), ((int)(((byte)(220)))));
            this.btnMain.Name = "btnMain";
            this.btnMain.UseVisualStyleBackColor = true;
            this.btnMain.Click += new System.EventHandler(this.btnMain_Click);
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label1.Name = "label1";
            // 
            // popUp
            // 
            resources.ApplyResources(this.popUp, "popUp");
            // 
            // settings1
            // 
            this.settings1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(213)))), ((int)(((byte)(216)))), ((int)(((byte)(220)))));
            resources.ApplyResources(this.settings1, "settings1");
            this.settings1.Name = "settings1";
            // 
            // welcome1
            // 
            this.welcome1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(213)))), ((int)(((byte)(216)))), ((int)(((byte)(220)))));
            resources.ApplyResources(this.welcome1, "welcome1");
            this.welcome1.Name = "welcome1";
            // 
            // Form1
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(213)))), ((int)(((byte)(216)))), ((int)(((byte)(220)))));
            this.Controls.Add(this.settings1);
            this.Controls.Add(this.welcome1);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private Welcome welcome1;
        private System.Windows.Forms.Button btnMain;
        private System.Windows.Forms.Button btnSettings;
        private System.Windows.Forms.NotifyIcon popUp;
        private Settings settings1;
    }
}

