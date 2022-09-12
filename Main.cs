using System;
using System.Diagnostics;
using System.DirectoryServices.Protocols;
using System.IO;
using System.Net;
using System.Net.NetworkInformation;
using System.Reflection;
using System.Text;
using System.Windows.Forms;

namespace MorrisvilleIT
{
    public partial class Main : Form
    {
        public static string mscuser, mscpass;
        public static string domain = "csntprod.morrisville.edu";

        public Main()
        {
            InitializeComponent();
            isFortiClientInstalled();
            VpnCheck();
        }

        private void Main_Load(object sender, EventArgs e)
        {
            Updater updater = new Updater();
            if (Properties.Settings.Default.UserName != string.Empty)
            {
                msc_username.Text = Properties.Settings.Default.UserName;
                msc_password.Text = Properties.Settings.Default.Password;
                checkBoxRememberMe.Checked = true;
            }
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            msc_username.Text = "";
            msc_password.Text = "";
            mscuser = "";
            mscpass = "";
            connectionstatus_text.Text = "Enter your username to login";
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            mscuser = msc_username.Text;
            mscpass = msc_password.Text;
            //MessageBox.Show(msc_password.Text);
            //So Passwords with Special Characters besides . or ! so far aren't liked by cmd doing a powershell.exe to start the vpn
            //MessageBox.Show(mscpass);
            if (mscuser != "" || mscpass != "")
            {
                if (!PingTest())
                {
                    var vpnstart = new Process
                    {
                        StartInfo = new ProcessStartInfo
                        {
                            FileName = "rasdial.exe",
                            Arguments = "\"Morrisville\" \"" + mscuser + "\" \"" + mscpass + "\"",
                            UseShellExecute = false,
                            RedirectStandardOutput = true,
                            CreateNoWindow = true
                        }
                    };
                    vpnstart.Start();
                    connectionstatus_text.Text = "Connecting to Morrisville...";
                    connectionstatus_text.Text = "Verifying username and password...";
                    string vpntext = vpnstart.StandardOutput.ReadToEnd();
                    vpnstart.WaitForExit();
                    //MessageBox.Show(vpntext);
                    if (vpntext.Contains("Successfully connected to"))
                    {
                        LDAPConnect(domain, mscuser, mscpass);
                    }
                    else
                    {
                        connectionstatus_text.Text = "Invalid Login. Please check your username and password.";
                    }
                }
                else
                {
                    LDAPConnect(domain, mscuser, mscpass);
                }
            }
            else
            {
                connectionstatus_text.Text = "Invalid Login. Please check your username and password.";
            }
        }

        private bool PingTest()
        {
            var ping = new Ping();
            try
            {
                var result = ping.Send("csntprod.morrisville.edu");
                if (result.Status == System.Net.NetworkInformation.IPStatus.Success)
                    return true;
                else
                    return false;
            }
            catch
            {
                return false;
            }
        }

        private void msc_username_TextChanged(object sender, EventArgs e)
        {
            if (msc_username.Text.Length > 0)
            {
                connectionstatus_text.Text = "Enter your password to login";
            }
            else
            {
                connectionstatus_text.Text = "Enter your username to login";
            }
        }

        private void msc_password_TextChanged(object sender, EventArgs e)
        {
            if (msc_password.Text.Length > 0)
            {
                connectionstatus_text.Text = "Press Login to proceed";
            }
            else
            {
                connectionstatus_text.Text = "Enter your password to login";
            }
        }

        private void isFortiClientInstalled()
        {
            var proc = new Process
            {
                StartInfo = new ProcessStartInfo
                {
                    FileName = "powershell.exe",
                    Arguments = "Get-AppxPackage -Name FortinetInc.FortiClient",
                    UseShellExecute = false,
                    RedirectStandardOutput = true,
                    CreateNoWindow = true
                }
            };
            proc.Start();
            string result = proc.StandardOutput.ReadToEnd();
            if (result == "")
            {
                // Need a way to host the Forticlient.appxbundle on Morrisville's webserver that can be accessed from the outside as link expires an hour from making from https://store.rg-adguard.net/
                // Using https://www.microsoft.com/en-us/p/forticlient/9wzdncrdh6mc as url and set to Retail
                //Hosting the stupid AppxBundle on github works pretty well. Neat

                var FortiInst = new Process
                {
                    StartInfo = new ProcessStartInfo
                    {
                        FileName = "powershell.exe",
                        Arguments = "Add-AppxPackage -Path 'https://github.com/colin0998/MorrisvilleIT/raw/master/FortinetInc.AppxBundle'",
                        UseShellExecute = false,
                        RedirectStandardOutput = true,
                        RedirectStandardError = true,
                        CreateNoWindow = true
                    }
                };
                FortiInst.Start();
                string well = FortiInst.StandardOutput.ReadToEnd();
                string well1 = FortiInst.StandardError.ReadToEnd();
                FortiInst.WaitForExit();
                if (well.Length > 0 || well1.Length > 0)
                {
                    MessageBox.Show("FortiClient Failed to Install. Please check your internet connection and try again later");
                    Application.Exit();
                }
            }
        }

        private void LDAPConnect(string domain, string mscuser, string mscpass)
        {
            try
            {
                LdapConnection connection = new LdapConnection(domain);
                NetworkCredential credential = new NetworkCredential(mscuser, mscpass);
                connection.Credential = credential;
                connection.Bind();
                if (checkBoxRememberMe.Checked == true)
                {
                    Properties.Settings.Default.UserName = mscuser;
                    Properties.Settings.Default.Password = mscpass;
                    Properties.Settings.Default.Save();
                }
                else
                {
                    Properties.Settings.Default.UserName = "";
                    Properties.Settings.Default.Password = "";
                    Properties.Settings.Default.Save();
                }
                //MessageBox.Show("Login Successful");
                Configure config = new Configure(this);
                this.Hide();
                config.Show();
            }
            catch (LdapException lexc)
            {
                String error = lexc.ServerErrorMessage;
                if (error.Contains("52e"))
                {
                    connectionstatus_text.Text = "Invalid Login. Please check your username and password.";
                }
                else if (error.Contains("530") || error.Contains("531"))
                {
                    connectionstatus_text.Text = "Unable to Login at this time. Contact the Help Desk for assistance.";
                }
                else if (error.Contains("532"))
                {
                    connectionstatus_text.Text = "Your password has expired. Please login to WebForStudents and change your password.";
                }
                else if (error.Contains("533"))
                {
                    connectionstatus_text.Text = "Your account is disabled. Contact the Help Desk for assistance.";
                }
                else if (error.Contains("701"))
                {
                    connectionstatus_text.Text = "Your account has expired. Contact the Help Desk for assistance.";
                }
                else if (error.Contains("773"))
                {
                    connectionstatus_text.Text = "You must reset your password. Please login to Office 365 to reset it.";
                }
                else if (error.Contains("775"))
                {
                    connectionstatus_text.Text = "Your account is locked. Contact the Help Desk for assistance.";
                }
            }
            catch (Exception exc)
            {
                connectionstatus_text.Text = "Error: " + exc.Message;
            }
        }

        private void VpnCheck()
        {
            var VpnCheck = new Process
            {
                StartInfo = new ProcessStartInfo
                {
                    FileName = "powershell.exe",
                    Arguments = "Get-VpnConnection -Name 'Morrisville'",
                    UseShellExecute = false,
                    RedirectStandardError = true,
                    CreateNoWindow = true
                }
            };
            VpnCheck.Start();
            string VpnCheckError = VpnCheck.StandardError.ReadToEnd();
            VpnCheck.WaitForExit();
            //MessageBox.Show(VpnCheckError);
            if (VpnCheckError.Contains("VPN connection Morrisville was not found"))
            {
                var vpnadd = new Process
                {
                    StartInfo = new ProcessStartInfo
                    {
                        FileName = "powershell.exe",
                        Arguments = "Add-VpnConnection -Name 'Morrisville' -ServerAddress 'mustangvpn.morrisville.edu' -PlugInApplicationID 'FortinetInc.FortiClient_sq9g7krz3c65j' -CustomConfiguration '<xml></xml>' -SplitTunneling -RememberCredential",
                        UseShellExecute = false,
                        RedirectStandardOutput = true,
                        CreateNoWindow = true
                    }
                };
                vpnadd.Start();
            }
        }
    }
}