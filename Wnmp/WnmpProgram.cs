using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using Wnmp.Forms;

namespace Wnmp
{
    public class WnmpProgram
    {
        protected Main wnmpForm;
        public Label statusLabel { get; set; } // Label that shows the programs status
        public CheckBox statusChecked { get; set; } // Label that shows the programs status
        public string baseDir { get; set; }    // Directory where all the programs configuration files are
        public string exeName { get; set; }    // Location of the executable file
        public string procName { get; set; }   // Name of the process
        public string progName { get; set; }   // User-friendly name of the program 
        public Log.LogSection progLogSection { get; set; } // LogSection of the program
        public string startArgs { get; set; }  // Start Arguments
        public string stopArgs { get; set; }   // Stop Arguments if KillStop is false
        public bool killStop { get; set; }     // Kill process instead of stopping it gracefully
        public string confDir { get; set; }    // Directory where all the programs configuration files are
        public string logDir { get; set; }     // Directory where all the programs log files are

        public int PID { get; protected set; }   // PID of process
        public ContextMenuStrip configContextMenu { get; set; } // Displays all the programs config files in |confDir|
        public ContextMenuStrip logContextMenu { get; set; }    // Displays all the programs log files in |logDir|

        public WnmpProgram()
        {
            configContextMenu = new ContextMenuStrip();
            logContextMenu = new ContextMenuStrip();
            configContextMenu.ItemClicked += configContextMenu_ItemClicked;
            logContextMenu.ItemClicked += logContextMenu_ItemClicked;
        }

        /// <summary>
        /// Changes the labels apperance to started
        /// </summary>
        protected void SetStartedLabel()
        {
            //statusLabel.Text = "\u221A";
            statusLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            statusLabel.ForeColor = Color.Lime;
        }

        /// <summary>
        /// Changes the labels apperance to stopped
        /// </summary>
        protected void SetStoppedLabel()
        {
            //statusLabel.Text = "X";
            statusLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            statusLabel.ForeColor = Color.Black;
        }

        public void SetStatusLabel()
        {
            if (this.IsRunning() == true)
                SetStartedLabel();
            else
                SetStoppedLabel();
        }

        protected void StartProcess(string exe, string args)
        {
            
            Process ps = new Process();
            ps.StartInfo.FileName = exe;
            ps.StartInfo.Arguments = args;
            ps.StartInfo.UseShellExecute = false;
            ps.StartInfo.RedirectStandardOutput = true;
            ps.StartInfo.WorkingDirectory = baseDir;
            ps.StartInfo.CreateNoWindow = true;
            ps.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
            if (this.IsPHP() == true) {
                ps.StartInfo.EnvironmentVariables.Add("PHP_FCGI_MAX_REQUESTS", "0"); // Disable auto killing PHP
            }
            ps.Start();
            PID = ps.Id;
        }

        private bool IsPHP()
        {
            return (progLogSection == Log.LogSection.WNMP_PHP);
        }

        public void Start()
        {
            try {
                StartProcess(exeName, startArgs);
                Log.wnmp_log_notice("Started " + progName, progLogSection);
                SetStartedLabel();
            } catch (Exception ex) {
                Log.wnmp_log_error(ex.Message, progLogSection);
            }
        }

        
        public void Stop()
        {
            try {
                if (killStop) {
                    Process[] process = Process.GetProcessesByName(procName);
                    foreach (Process currentProc in process) {
                        currentProc.Kill();
                    }
                } else {
                    StartProcess(exeName, stopArgs);
                    new Thread(delegate() {
                        Thread.Sleep(2000);
                        Process[] process = Process.GetProcessesByName(procName);
                        foreach (Process currentProc in process) {
                            currentProc.Kill();
                        }
                    }).Start();
                }
                Log.wnmp_log_notice("Stopped " + progName, progLogSection);
                SetStoppedLabel();
            } catch (Exception ex) {
                Log.wnmp_log_error(ex.Message, progLogSection);
            }
        }

        public void Restart()
        {
            this.Stop();
            this.Start();
            Log.wnmp_log_notice("Restarted " + progName, progLogSection);
        }

        public void ConfigButton(object sender)
        {
            Button btnSender = (Button)sender;
            Point ptLowerLeft = new Point(0, btnSender.Height);
            ptLowerLeft = btnSender.PointToScreen(ptLowerLeft);
            configContextMenu.Show(ptLowerLeft);
        }

        public void LogButton(object sender)
        {
            Button btnSender = (Button)sender;
            Point ptLowerLeft = new Point(0, btnSender.Height);
            ptLowerLeft = btnSender.PointToScreen(ptLowerLeft);
            logContextMenu.Show(ptLowerLeft);
        }

        private void configContextMenu_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            try {
                Process.Start(Options.settings.Editor, confDir + e.ClickedItem.Text);
            } catch (Exception ex) {
                Log.wnmp_log_error(ex.Message, progLogSection);
            }
        }

        private void logContextMenu_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            try {
                Process.Start(Options.settings.Editor, logDir + e.ClickedItem.Text);
            } catch (Exception ex) {
                Log.wnmp_log_error(ex.Message, progLogSection);
            }
        }

        public bool IsRunning()
        {
            Process[] process = Process.GetProcessesByName(procName);

            return (process.Length != 0);
        }
        public bool IsChecked()
        {
            return (statusChecked.Checked == true);
        }

        /// <summary>
        /// Adds configuration files or log files to the context menu strip
        /// </summary>
        protected void DirFiles(string path, string GetFiles, ContextMenuStrip cms)
        {
            DirectoryInfo dinfo = new DirectoryInfo(path);

            if (!dinfo.Exists)
                return;

            FileInfo[] Files = dinfo.GetFiles(GetFiles);
            foreach (FileInfo file in Files)
                cms.Items.Add(file.Name, null);
        }
    }
}
