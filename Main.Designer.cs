using System.Drawing;

namespace MorrisvilleIT
{
    partial class Main
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.msc_password = new System.Windows.Forms.TextBox();
            this.msc_username = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.connectionstatus = new System.Windows.Forms.GroupBox();
            this.connectionstatus_text = new System.Windows.Forms.TextBox();
            this.checkBoxRememberMe = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.connectionstatus.SuspendLayout();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(53, 289);
            this.button1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(103, 36);
            this.button1.TabIndex = 4;
            this.button1.Text = "Login";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.Button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 190);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(108, 25);
            this.label1.TabIndex = 2;
            this.label1.Text = "Username:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(12, 229);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(104, 25);
            this.label2.TabIndex = 3;
            this.label2.Text = "Password:";
            // 
            // msc_password
            // 
            this.msc_password.Location = new System.Drawing.Point(149, 233);
            this.msc_password.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.msc_password.Name = "msc_password";
            this.msc_password.PasswordChar = '*';
            this.msc_password.Size = new System.Drawing.Size(225, 22);
            this.msc_password.TabIndex = 2;
            this.msc_password.TextChanged += new System.EventHandler(this.msc_password_TextChanged);
            // 
            // msc_username
            // 
            this.msc_username.Location = new System.Drawing.Point(149, 192);
            this.msc_username.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.msc_username.Name = "msc_username";
            this.msc_username.Size = new System.Drawing.Size(225, 22);
            this.msc_username.TabIndex = 1;
            this.msc_username.TextChanged += new System.EventHandler(this.msc_username_TextChanged);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(177, 289);
            this.button2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(103, 36);
            this.button2.TabIndex = 5;
            this.button2.Text = "Clear";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.Button2_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(12, 12);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(363, 162);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 5;
            this.pictureBox1.TabStop = false;
            // 
            // connectionstatus
            // 
            this.connectionstatus.Controls.Add(this.connectionstatus_text);
            this.connectionstatus.Location = new System.Drawing.Point(12, 334);
            this.connectionstatus.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.connectionstatus.Name = "connectionstatus";
            this.connectionstatus.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.connectionstatus.Size = new System.Drawing.Size(363, 100);
            this.connectionstatus.TabIndex = 6;
            this.connectionstatus.TabStop = false;
            this.connectionstatus.Text = "Connection Status";
            // 
            // connectionstatus_text
            // 
            this.connectionstatus_text.BackColor = System.Drawing.Color.White;
            this.connectionstatus_text.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.connectionstatus_text.Location = new System.Drawing.Point(5, 22);
            this.connectionstatus_text.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.connectionstatus_text.Multiline = true;
            this.connectionstatus_text.Name = "connectionstatus_text";
            this.connectionstatus_text.ReadOnly = true;
            this.connectionstatus_text.Size = new System.Drawing.Size(352, 71);
            this.connectionstatus_text.TabIndex = 0;
            this.connectionstatus_text.Text = "Enter your username to login";
            // 
            // checkBoxRememberMe
            // 
            this.checkBoxRememberMe.AutoSize = true;
            this.checkBoxRememberMe.Location = new System.Drawing.Point(12, 262);
            this.checkBoxRememberMe.Margin = new System.Windows.Forms.Padding(4);
            this.checkBoxRememberMe.Name = "checkBoxRememberMe";
            this.checkBoxRememberMe.Size = new System.Drawing.Size(119, 20);
            this.checkBoxRememberMe.TabIndex = 3;
            this.checkBoxRememberMe.Text = "Remember Me";
            this.checkBoxRememberMe.UseVisualStyleBackColor = true;
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(387, 446);
            this.Controls.Add(this.checkBoxRememberMe);
            this.Controls.Add(this.connectionstatus);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.msc_username);
            this.Controls.Add(this.msc_password);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MaximizeBox = false;
            this.Name = "Main";
            this.Text = "SUNY Morrisville Net";
            this.Load += new System.EventHandler(this.Main_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.connectionstatus.ResumeLayout(false);
            this.connectionstatus.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox msc_password;
        private System.Windows.Forms.TextBox msc_username;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.GroupBox connectionstatus;
        private System.Windows.Forms.TextBox connectionstatus_text;
        private System.Windows.Forms.CheckBox checkBoxRememberMe;
    }
}

