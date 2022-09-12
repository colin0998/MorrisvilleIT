using System;
using System.Diagnostics;
using System.DirectoryServices;
using System.Management.Automation;
using System.Windows.Forms;

namespace MorrisvilleIT
{
    //Work Work Work Work Work
    public partial class Configure : Form
    {
        private Form opener;

        //SecureString pass = new NetworkCredential("", Main.mscpass).SecurePassword;
        private string[][] rows;

        public Configure(Form parent)
        {
            InitializeComponent();
            Shown += Configure_Shown;
            /*
            using (var client = new WebClient())
            {
                client.DownloadFile("https://raw.githubusercontent.com/colin0998/MorrisvilleIT/master/software.csv", "software.csv");
            }
            rows = File.ReadAllLines(Application.StartupPath + "\\software.csv").Select(l => l.Split(',').ToArray()).ToArray();
            for (int a = 1; a <= rows.Length - 1; a++)
            {
                softwareList.Items.Add(rows[a][0]);
            }
            */
            ldapName.Text = "Welcome " + GetUserFullName(Main.domain, Main.mscuser, Main.mscpass);

            opener = parent;
        }

        private void Configure_Shown(object sender, EventArgs e)
        {
        }


        private string GetUserFullName(string domain, string userName, string password)
        {
            DirectoryEntry deUser = new DirectoryEntry("LDAP://" + domain, userName, password);
            DirectorySearcher deSearch = new DirectorySearcher(deUser);
            deSearch.Filter = "(&(objectClass=user)(SAMAccountName=" + userName + "))";
            deSearch.PropertiesToLoad.Add("givenname");
            deSearch.PropertiesToLoad.Add("sn");
            SearchResult sr = deSearch.FindOne();
            string sFirstName = sr.Properties["givenname"][0].ToString();
            string sLastName = sr.Properties["sn"][0].ToString();
            return sFirstName;
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            drives_progressbar.Value = 0;
            MapNetworkDrive("P", @"\\cisnts1\public", Main.mscuser, Main.mscpass);
            drives_progressbar.Value += 10;
            MapNetworkDrive("Q", @"\\cisnts1\ag_nrc", Main.mscuser, Main.mscpass);
            drives_progressbar.Value += 10;
            MapNetworkDrive("R", @"\\cisnts1\business", Main.mscuser, Main.mscpass);
            drives_progressbar.Value += 10;
            MapNetworkDrive("S", @"\\cisnts1\lib_arts", Main.mscuser, Main.mscpass);
            drives_progressbar.Value += 10;
            MapNetworkDrive("T", @"\\engernt1\sci_tech", Main.mscuser, Main.mscpass);
            drives_progressbar.Value += 10;
            MapNetworkDrive("U", @"\\MyFiles\" + Main.mscuser + "$", Main.mscuser, Main.mscpass);
            drives_progressbar.Value += 10;
            MapNetworkDrive("W", @"\\MyWebFiles\" + Main.mscuser + "$", Main.mscuser, Main.mscpass);
            drives_progressbar.Value += 10;
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            drives_progressbar.Value = 0;
            UnMapNetworkDriveByLetter("P");
            drives_progressbar.Value += 10;
            UnMapNetworkDriveByLetter("Q");
            drives_progressbar.Value += 10;
            UnMapNetworkDriveByLetter("R");
            drives_progressbar.Value += 10;
            UnMapNetworkDriveByLetter("S");
            drives_progressbar.Value += 10;
            UnMapNetworkDriveByLetter("T");
            drives_progressbar.Value += 10;
            UnMapNetworkDriveByLetter("U");
            drives_progressbar.Value += 10;
            UnMapNetworkDriveByLetter("W");
            drives_progressbar.Value += 10;
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            var process = new Process
            {
                StartInfo = new ProcessStartInfo
                {
                    FileName = "net.exe",
                    Arguments = "use \\\\software /user:" + Main.mscuser + " " + Main.mscpass,
                    UseShellExecute = false,
                    RedirectStandardOutput = true,
                    CreateNoWindow = true
                }
            };
            process.Start();
            process.WaitForExit();
            string selection = softwareList.SelectedItem.ToString();
            for (int a = 1; a <= rows.Length - 1; a++)
            {
                if (rows[a][0] == selection)
                {
                    MessageBox.Show(rows[a][1]);
                    //Process.Start(rows[a][1]);
                    PowerShell powerShell = PowerShell.Create();
                    powerShell.AddCommand(rows[a][1]);
                    powerShell.Invoke();
                }
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Printers print = new Printers();
            print.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            var vpnend = new Process
            {
                StartInfo = new ProcessStartInfo
                {
                    FileName = "rasdial.exe",
                    Arguments = "\"Morrisville\" /d",
                    UseShellExecute = false,
                    RedirectStandardOutput = true,
                    CreateNoWindow = true
                }
            };
            vpnend.Start();
            vpnend.WaitForExit();
            opener.ResetText();
            opener.Show();
            this.Dispose();
            this.Close();

        }

        private void Configure_Load(object sender, EventArgs e)
        {

        }
        private void MapNetworkDrive(string DriveLetter, string UNCPath, string Username, string Password)
        {
            var map = new Process
            {
                StartInfo = new ProcessStartInfo
                {
                    FileName = "net.exe",
                    Arguments = "use " + DriveLetter + ": " + UNCPath + " /user:CSNTPROD\\" + Username + " " + Password + " /persistent:yes",
                    UseShellExecute = false,
                    CreateNoWindow = true
                }
            };
            map.Start();
            map.WaitForExit();
        }

        private void UnMapNetworkDriveByLetter(string DriveLetter)
        {
            var unmap = new Process
            {
                StartInfo = new ProcessStartInfo
                {
                    FileName = "net.exe",
                    Arguments = "use " + DriveLetter + ": /delete /y",
                    UseShellExecute = false,
                    CreateNoWindow = true
                }
            };
            unmap.Start();
            unmap.WaitForExit();
        }

        private void webmail_btn_Click(object sender, EventArgs e)
        {
            Process.Start("https://outlook.office365.com/owa/" + Main.mscuser + "@morrisville.edu");
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutBox aboutBox = new AboutBox();
            aboutBox.Show();
        }
    }
}