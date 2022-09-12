using Octokit;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Octokit;
using System.Net;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Reflection.Emit;

namespace MorrisvilleIT
{
    public partial class Updater : Form
    {
        public Updater()
        {
            InitializeComponent();
            CheckGitHubNewerVersion();

        }

        private async System.Threading.Tasks.Task CheckGitHubNewerVersion()
        {
            //Get all releases from GitHub
            //Source: https://octokitnet.readthedocs.io/en/latest/getting-started/
            GitHubClient client = new GitHubClient(new ProductHeaderValue("SomeName"));
            IReadOnlyList<Release> releases = await client.Repository.Release.GetAll("colin0998", "MorrisvilleIT");

            //Setup the versions
            Version latestGitHubVersion = new Version(releases[0].TagName);
            Version localVersion = new Version("1.0.1"); //Replace this with your local version. 
                                                         //Only tested with numeric values.

            //Compare the Versions
            //Source: https://stackoverflow.com/questions/7568147/compare-version-numbers-without-using-split-function
            int versionComparison = localVersion.CompareTo(latestGitHubVersion);
            if (versionComparison < 0)
            {
                //The version on GitHub is more up to date than this local release.
                ReleaseNotesText.Text = releases[0].Body;
                CurrentVersion.Text += localVersion.ToString();
                LatestVersion.Text += releases[0].TagName;
                DownloadURL.Text = releases[0].Assets[0].BrowserDownloadUrl;
                Show();
            }
            else if (versionComparison > 0)
            {
                //This local version is greater than the release version on GitHub.
            }
            else
            {
                //This local Version and the Version on GitHub are equal.
            }
        }

        private void btnDownload_Click(object sender, EventArgs e)
        {
            var dialog = new SaveFileDialog();
            dialog.Filter = "exe files(*.exe) | *.exe";
            dialog.FileName = "MorrisvilleIT";

            var result = dialog.ShowDialog(); //shows save file dialog
            if (result == DialogResult.OK)
            {
                Console.WriteLine("writing to: " + dialog.FileName); //prints the file to save

                var wClient = new WebClient();
                //wClient.DownloadFile(DownloadURL.Text, dialog.FileName);
                wClient.DownloadProgressChanged += new DownloadProgressChangedEventHandler(DownloadProgressChanged);
                wClient.DownloadFileAsync(new Uri(DownloadURL.Text), dialog.FileName);
            }
        }
        void DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            this.BeginInvoke((MethodInvoker)delegate {
                double bytesIn = double.Parse(e.BytesReceived.ToString());
                double totalBytes = double.Parse(e.TotalBytesToReceive.ToString());
                double percentage = bytesIn / totalBytes * 100;
                DownloadProgress.Value = int.Parse(Math.Truncate(percentage).ToString());
            });
        }
    }
}
