using System.Drawing;

namespace MorrisvilleIT
{
    partial class Updater
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Updater));
            this.CurrentVersion = new System.Windows.Forms.Label();
            this.LatestVersion = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.ReleaseNotesText = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnDownload = new System.Windows.Forms.Button();
            this.DownloadProgress = new System.Windows.Forms.ProgressBar();
            this.DownloadURL = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // CurrentVersion
            // 
            this.CurrentVersion.AutoSize = true;
            this.CurrentVersion.Location = new System.Drawing.Point(12, 20);
            this.CurrentVersion.Name = "CurrentVersion";
            this.CurrentVersion.Size = new System.Drawing.Size(90, 16);
            this.CurrentVersion.TabIndex = 0;
            this.CurrentVersion.Text = "Your Version: ";
            // 
            // LatestVersion
            // 
            this.LatestVersion.AutoSize = true;
            this.LatestVersion.Location = new System.Drawing.Point(12, 48);
            this.LatestVersion.Name = "LatestVersion";
            this.LatestVersion.Size = new System.Drawing.Size(98, 16);
            this.LatestVersion.TabIndex = 1;
            this.LatestVersion.Text = "Latest Version: ";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.ReleaseNotesText);
            this.groupBox1.Location = new System.Drawing.Point(15, 88);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(472, 228);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Release Notes";
            // 
            // ReleaseNotesText
            // 
            this.ReleaseNotesText.BackColor = System.Drawing.Color.White;
            this.ReleaseNotesText.Enabled = false;
            this.ReleaseNotesText.Location = new System.Drawing.Point(6, 21);
            this.ReleaseNotesText.Multiline = true;
            this.ReleaseNotesText.Name = "ReleaseNotesText";
            this.ReleaseNotesText.ReadOnly = true;
            this.ReleaseNotesText.Size = new System.Drawing.Size(460, 201);
            this.ReleaseNotesText.TabIndex = 0;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnDownload);
            this.groupBox2.Controls.Add(this.DownloadProgress);
            this.groupBox2.Controls.Add(this.DownloadURL);
            this.groupBox2.Location = new System.Drawing.Point(15, 322);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(472, 116);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Download";
            // 
            // btnDownload
            // 
            this.btnDownload.Location = new System.Drawing.Point(363, 72);
            this.btnDownload.Name = "btnDownload";
            this.btnDownload.Size = new System.Drawing.Size(109, 23);
            this.btnDownload.TabIndex = 2;
            this.btnDownload.Text = "Download";
            this.btnDownload.UseVisualStyleBackColor = true;
            this.btnDownload.Click += new System.EventHandler(this.btnDownload_Click);
            // 
            // DownloadProgress
            // 
            this.DownloadProgress.Location = new System.Drawing.Point(7, 72);
            this.DownloadProgress.Name = "DownloadProgress";
            this.DownloadProgress.Size = new System.Drawing.Size(350, 23);
            this.DownloadProgress.TabIndex = 1;
            // 
            // DownloadURL
            // 
            this.DownloadURL.Location = new System.Drawing.Point(7, 22);
            this.DownloadURL.Name = "DownloadURL";
            this.DownloadURL.ReadOnly = true;
            this.DownloadURL.Size = new System.Drawing.Size(459, 22);
            this.DownloadURL.TabIndex = 0;
            // 
            // Updater
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(499, 450);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.LatestVersion);
            this.Controls.Add(this.CurrentVersion);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Updater";
            this.Text = "Check for Updates";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label CurrentVersion;
        private System.Windows.Forms.Label LatestVersion;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox ReleaseNotesText;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnDownload;
        private System.Windows.Forms.ProgressBar DownloadProgress;
        private System.Windows.Forms.TextBox DownloadURL;
    }
}