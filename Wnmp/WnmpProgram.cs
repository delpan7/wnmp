﻿using System;
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

        public int PID { get; private set; }   // PID of process
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
        private void SetStartedLabel()
        {
            //statusLabel.Text = "\u221A";
            statusLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            statusLabel.ForeColor = Color.Lime;
        }

        /// <summary>
        /// Changes the labels apperance to stopped
        /// </summary>
        private void SetStoppedLabel()
        {
            //statusLabel.Text = "X";
            statusLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            statusLabel.ForeColor = Color.Black;
        }
        /// <summary>
        /// Changes the labels apperance to error
        /// </summary>
        private void SetErrorLabel() {
            statusLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            statusLabel.ForeColor = Color.DarkRed;
        }

        public void SetStatusLabel()
        {
            if (this.IsRunning() == true)
                SetStartedLabel();
            else
                SetStoppedLabel();
        }

        private void StartProcess(string exe, string args)
        {
            Process ps = new Process();
            ps.StartInfo.FileName = exe;
            ps.StartInfo.Arguments = args;
            ps.StartInfo.UseShellExecute = false;
            ps.StartInfo.RedirectStandardOutput = true;
            ps.StartInfo.WorkingDirectory = Main.StartupPath;
            ps.StartInfo.CreateNoWindow = true;
            ps.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
            if (this.IsPHP() == true) {
                ps.StartInfo.EnvironmentVariables.Add("PHP_FCGI_MAX_REQUESTS", "0"); // Disable auto killing PHP
            }
            ps.Start();
            PID = ps.Id;
        }

        private bool IsMariaDB()
        {
            return (progLogSection == Log.LogSection.WNMP_MARIADB);
        }

        private bool IsPHP()
        {
            return (progLogSection == Log.LogSection.WNMP_PHP);
        }

        /* PHP needs special handling so we have to create a seperate function */
        private void StartPHP()
        {
            int i;
            int ProcessCount = Options.settings.PHP_Processes;
            short port = Options.settings.PHP_Port;
            string phpini = confDir + "/php.ini";

            try {
                for (i = 1; i <= ProcessCount; i++) {
                    StartProcess(exeName, String.Format("-b localhost:{0} -c {1}", port, phpini));
                    Log.wnmp_log_notice("Starting PHP " + i + "/" + ProcessCount + " On port: " + port, progLogSection);
                    port++;
                }
                Log.wnmp_log_notice("PHP started", progLogSection);
                SetStartedLabel();
            } catch (Exception ex) {
                Log.wnmp_log_error(ex.Message, progLogSection);
            }
        }

        public void Start()
        {
            SetStartedLabel();
            return;
            if (IsPHP() == true) {
                StartPHP();
                return;
            }
            try {
                StartProcess(exeName, startArgs);
                Log.wnmp_log_notice("Started " + progName, progLogSection);
                SetStartedLabel();
            } catch (Exception ex) {
                Log.wnmp_log_error(ex.Message, progLogSection);
            }
        }

        private string mdb_pidfile = Main.StartupPath + "/mariadb/data/" + Environment.MachineName + ".pid";
        public void Stop()
        {
            SetStoppedLabel();
            return;
            try {
                /* Only kill our MariaDB instance (doesn't work if Wnmp is closed after starting MDB) */
                if (IsMariaDB() == true && PID != 0) {
                    Process process = Process.GetProcessById(PID);
                    process.Kill();
                    /* A hack to delete MariaDB's PID file */
                    if (File.Exists(mdb_pidfile))
                        File.Delete(mdb_pidfile);
                    PID = 0;
                    Log.wnmp_log_notice("Stopped " + progName, progLogSection);
                    SetStoppedLabel();
                    return;
                }
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
                Process.Start(Options.settings.Editor, Main.StartupPath + confDir + e.ClickedItem.Text);
            } catch (Exception ex) {
                Log.wnmp_log_error(ex.Message, progLogSection);
            }
        }

        private void logContextMenu_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            try {
                Process.Start(Options.settings.Editor, Main.StartupPath + logDir + e.ClickedItem.Text);
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
    }
}
