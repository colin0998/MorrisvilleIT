using System;
using System.Data;
using System.Diagnostics;
using System.Management;
using System.Printing;
using System.Windows.Forms;

namespace MorrisvilleIT
{
    public partial class Printers : Form
    {
        private DataTable dt = new DataTable();

        public Printers()
        {
            InitializeComponent();
        }

        private void Printers_Load(object sender, EventArgs e)
        {
            AddPrintShare(Main.mscuser, Main.mscpass);
            try
            {
                GetAllPrinterList();
            }
            catch
            {
                MessageBox.Show("It seems we are having network issues at the moment. Please try again later", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Close();
            }
        }

        private void AddPrintShare(string username, string password)
        {
            var p = new Process();
            p.StartInfo.FileName = "net";
            p.StartInfo.Arguments = "use \\\\print /user:CSNTPROD\\" + username + " " + password;
            p.StartInfo.UseShellExecute = false;
            p.StartInfo.CreateNoWindow = true;
            p.Start();
            p.WaitForExit();
        }

        private void GetAllPrinterList()
        {
            printerList.GridLines = true;// Whether the grid lines are displayed
            printerList.FullRowSelect = true;// Whether to select the entire line
            printerList.View = View.Details;// Set display mode
            printerList.Scrollable = true;// Whether to show the scroll bar automatically
            printerList.MultiSelect = false;// Is it possible to select multiple lines
            printerList.Columns.Add("Name");
            printerList.Columns.Add("Location");

            PrintServer myPrintServer = new PrintServer("\\\\print");
            dt.Columns.Add("Name", typeof(string));
            dt.Columns.Add("FullName", typeof(string));
            dt.Columns.Add("Location", typeof(string));
            // List the print server's queues
            PrintQueueCollection myPrintQueues = myPrintServer.GetPrintQueues();
            foreach (PrintQueue pq in myPrintQueues)
            {
                DataRow dr = dt.NewRow();
                dr[0] = pq.Name;
                dr[1] = pq.FullName;
                dr[2] = pq.Location;
                dt.Rows.Add(dr);
            }
            string sortColumn = dt.Columns[0].ColumnName + " ASC";
            dt.DefaultView.Sort = sortColumn;
            dt = dt.DefaultView.ToTable();
            foreach (DataRow dr in dt.Rows)
            {
                ListViewItem item = new ListViewItem();
                item.SubItems.Clear();
                item.SubItems[0].Text = dr[0].ToString();
                item.SubItems.Add(dr[2].ToString());
                printerList.Items.Add(item);
            }
            printerList.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
            printerList.Sort();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string selection = printerList.SelectedItems[0].Text;
            //MessageBox.Show(selection);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                if (dt.Rows[i]["Name"].ToString() == selection)
                {
                    AddPrinter(dt.Rows[i]["FullName"].ToString());
                    //MessageBox.Show(dt.Rows[i]["FullName"].ToString());
                }
            }
        }

        private void AddPrinter(string printer)
        {
            using (ManagementClass win32Printer = new ManagementClass("Win32_Printer"))
            {
                using (ManagementBaseObject inputParam =
                   win32Printer.GetMethodParameters("AddPrinterConnection"))
                {
                    inputParam.SetPropertyValue("Name", printer);

                    using (ManagementBaseObject result =
                        (ManagementBaseObject)win32Printer.InvokeMethod("AddPrinterConnection", inputParam, null))
                    {
                        uint errorCode = (uint)result.Properties["returnValue"].Value;
                        MessageBox.Show(errorCode.ToString());
                        switch (errorCode)
                        {
                            case 0:
                                MessageBox.Show("Successfully connected printer.");
                                break;

                            case 5:
                                MessageBox.Show("Access Denied.");
                                break;

                            case 123:
                                MessageBox.Show("The filename, directory name, or volume label syntax is incorrect.");
                                break;

                            case 1801:
                                MessageBox.Show("Invalid Printer Name: " + printer);
                                break;

                            case 1930:
                                MessageBox.Show("Incompatible Printer Driver.");
                                break;

                            default:
                                MessageBox.Show("Failed to Automatically Add the printer, Error Code: " + errorCode + "\n" + "Continue to manually add");
                                var process = new Process
                                {
                                    StartInfo = new ProcessStartInfo
                                    {
                                        FileName = "rundll32.exe",
                                        Arguments = "printui.dll,PrintUIEntry /in /n" + printer,
                                        UseShellExecute = false,
                                        RedirectStandardOutput = true,
                                        CreateNoWindow = true
                                    }
                                };
                                process.Start();
                                process.WaitForExit();
                                MessageBox.Show("Printer should now be installed Installed");
                                break;
                        }
                    }
                }
            }
        }
    }
}