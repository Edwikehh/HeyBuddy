namespace HeyBuddy
{
    partial class Settings
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.stgSec = new System.Windows.Forms.Label();
            this.stgSecBox = new System.Windows.Forms.TextBox();
            this.stgWebLogin = new System.Windows.Forms.Button();
            this.stgLogin = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // stgSec
            // 
            this.stgSec.AutoSize = true;
            this.stgSec.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.stgSec.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(47)))), ((int)(((byte)(61)))));
            this.stgSec.Location = new System.Drawing.Point(39, 27);
            this.stgSec.Name = "stgSec";
            this.stgSec.Size = new System.Drawing.Size(52, 18);
            this.stgSec.TabIndex = 0;
            this.stgSec.Text = "label1";
            // 
            // stgSecBox
            // 
            this.stgSecBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(213)))), ((int)(((byte)(216)))), ((int)(((byte)(220)))));
            this.stgSecBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.stgSecBox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(47)))), ((int)(((byte)(61)))));
            this.stgSecBox.Location = new System.Drawing.Point(42, 48);
            this.stgSecBox.Multiline = true;
            this.stgSecBox.Name = "stgSecBox";
            this.stgSecBox.Size = new System.Drawing.Size(142, 27);
            this.stgSecBox.TabIndex = 2;
            // 
            // stgWebLogin
            // 
            this.stgWebLogin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.stgWebLogin.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(47)))), ((int)(((byte)(61)))));
            this.stgWebLogin.Location = new System.Drawing.Point(42, 140);
            this.stgWebLogin.Name = "stgWebLogin";
            this.stgWebLogin.Size = new System.Drawing.Size(142, 27);
            this.stgWebLogin.TabIndex = 3;
            this.stgWebLogin.Text = "button1";
            this.stgWebLogin.UseVisualStyleBackColor = true;
            this.stgWebLogin.Click += new System.EventHandler(this.stgWebLogin_Click);
            // 
            // stgLogin
            // 
            this.stgLogin.AutoSize = true;
            this.stgLogin.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.stgLogin.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(47)))), ((int)(((byte)(61)))));
            this.stgLogin.Location = new System.Drawing.Point(39, 119);
            this.stgLogin.Name = "stgLogin";
            this.stgLogin.Size = new System.Drawing.Size(52, 18);
            this.stgLogin.TabIndex = 4;
            this.stgLogin.Text = "label1";
            // 
            // Settings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(213)))), ((int)(((byte)(216)))), ((int)(((byte)(220)))));
            this.Controls.Add(this.stgLogin);
            this.Controls.Add(this.stgWebLogin);
            this.Controls.Add(this.stgSecBox);
            this.Controls.Add(this.stgSec);
            this.Name = "Settings";
            this.Size = new System.Drawing.Size(619, 454);
            this.Load += new System.EventHandler(this.Settings_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label stgSec;
        private System.Windows.Forms.TextBox stgSecBox;
        private System.Windows.Forms.Button stgWebLogin;
        private System.Windows.Forms.Label stgLogin;
    }
}
