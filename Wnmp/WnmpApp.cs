using System;
using System.Collections;
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
    public delegate void PHPEventHandler();
    public class WnmpApp
    {
        public event PHPEventHandler PHPStart;

        public event PHPEventHandler PHPStop;

        public event PHPEventHandler PHPRestart;

        protected Main wnmpForm;
        public Label statusLabel { get; set; } // Label that shows the programs status
        public CheckBox statusChecked { get; set; } // CheckBox that shows the programs status
        public bool isChecked = false;
        public string baseDir { get; set; }    // Directory where all the programs configuration files are
        public string exeName { get; set; }    // Location of the executable file
        public string procName { get; set; }   // Name of the process
        public string progName { get; set; }   // User-friendly name of the program 
        public Log.LogSection progLogSection { get; set; } // LogSection of the program
        public string startArgs { get; set; }  // Start Arguments
        public string stopArgs { get; set; }   // Stop Arguments if KillStop is false
        public string restartArgs { get; set; }   // restart Arguments 
        public bool killStop { get; set; }     // Kill process instead of stopping it gracefully
        public string confDir { get; set; }    // Directory where all the programs configuration files are
        public string logDir { get; set; }     // Directory where all the programs log files are

        public int PID { get; protected set; }   // PID of process
        public ContextMenuStrip optionContextMenu { get; set; } // Displays all the programs config files in |confDir|
        public ContextMenuStrip logContextMenu { get; set; }    // Displays all the programs log files in |logDir|

        public WnmpApp() {
            optionContextMenu = new ContextMenuStrip();
            //optionContextMenu.Items.Add("Start", null, new EventHandler(start_Click));
            //optionContextMenu.Items.Add("Stop", null, new EventHandler(stop_Click));
            //optionContextMenu.Items.Add("Restart", null, new EventHandler(restart_Click));
            //logContextMenu = new ToolStripMenuItem();
            //configContextMenu.Click += new EventHandler(configContextMenu_ItemClicked);
            //logContextMenu.Click += logContextMenu_ItemClicked;
        }

        /// <summary>
        /// Changes the labels apperance to started
        /// </summary>
        protected void SetStartedLabel() {
            statusLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            statusLabel.ForeColor = Color.Lime;
        }

        /// <summary>
        /// Changes the labels apperance to stopped
        /// </summary>
        protected void SetStoppedLabel() {
            statusLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            statusLabel.ForeColor = Color.Black;
        }

        public void SetStatusLabel() {
            if (this.IsRunning() == true)
                SetStartedLabel();
            else
                SetStoppedLabel();
        }

        protected void StartProcess(string exe, string args) {
            Process ps = new Process();
            ps.StartInfo.FileName = exe;
            ps.StartInfo.Arguments = args;
            ps.StartInfo.UseShellExecute = false;
            ps.StartInfo.RedirectStandardInput = true;
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

        private bool IsPHP() {
            return (progLogSection == Log.LogSection.WNMP_PHP);
        }

        private bool IsMemcached() {
            return (progLogSection == Log.LogSection.WNMP_MEMCACHED);
        }

        public virtual void Start() {
            try {
                StartProcess(exeName, startArgs);
                Log.wnmp_log_notice("Started " + progName, progLogSection);
                SetStartedLabel();
            } catch (Exception ex) {
                Log.wnmp_log_error(ex.Message, progLogSection);
            }

            if (PHPStart != null) {
                PHPStart();
            }
        }

        public virtual void Stop() {
            try {
                if (killStop) {
                    Process[] process = Process.GetProcessesByName(procName);
                    foreach (Process currentProc in process) {
                        currentProc.Kill();
                    }
                } else {
                    StartProcess(exeName, stopArgs);
                    if (!IsMemcached()) {
                        new Thread(delegate () {
                            Thread.Sleep(2000);
                            try {
                                Process[] process = Process.GetProcessesByName(procName);
                                foreach (Process currentProc in process) {
                                    currentProc.Kill();
                                }
                            } catch (Exception ex) {
                            }
                        }).Start();
                    }
                }
                Log.wnmp_log_notice("Stopped " + progName, progLogSection);
                if(!IsPHP()) SetStoppedLabel();
            } catch (Exception ex) {
                Log.wnmp_log_error(ex.Message, progLogSection);
            }

            if (PHPStop != null) {
                PHPStop();
            }
        }

        public virtual void Restart() {
            if(restartArgs != null) {
                try {
                    StartProcess(exeName, restartArgs);
                    Log.wnmp_log_notice("Restarted " + progName, progLogSection);
                    SetStartedLabel();
                } catch (Exception ex) {
                    Log.wnmp_log_error(ex.Message, progLogSection);
                }

                if (PHPRestart != null) {
                    PHPRestart();
                }
            } else {
                Stop();
                Start();
                Log.wnmp_log_notice("Restarted " + progName, progLogSection);
            }
        }

        //public void OptionButton(object sender) {
        //    Label btnSender = (Label)sender;
        //    Point ptLowerLeft = new Point(0, btnSender.Height);
        //    ptLowerLeft = btnSender.PointToScreen(ptLowerLeft);
        //    optionContextMenu.Show(ptLowerLeft);
        //}


        protected void configContextMenu_ItemClicked(object sender, ToolStripItemClickedEventArgs e) {
            Console.WriteLine("{0}", e.ToString());

            try {
                Process.Start(Options.settings.Editor, confDir + e.ClickedItem.Text);
            } catch (Exception ex) {
                Log.wnmp_log_error(ex.Message, progLogSection);
            }
        }

        public bool IsRunning() {
            Process[] process = Process.GetProcessesByName(procName);

            return (process.Length != 0);
        }
       

        /// <summary>
        /// Adds configuration files or log files to the context menu strip
        /// </summary>
        protected void DirFiles(string path, string getFiles, ToolStripMenuItem cms) {
            DirectoryInfo dinfo = new DirectoryInfo(path);

            if (!dinfo.Exists)
                return;

            FileInfo[] Files = dinfo.GetFiles(getFiles);

            foreach (FileInfo file in Files) {
                cms.DropDownItems.Add(new ToolStripMenuItem(file.Name, null));
            }
        }

        protected void SetOption(Dictionary<string, string> options, ToolStripMenuItem cms) {
            //foreach (Dictionary option in options) {
            //}
            //DirectoryInfo dinfo = new DirectoryInfo(path);

            //if (!dinfo.Exists)
            //    return;

            //FileInfo[] Files = dinfo.GetFiles(getFiles);

            //foreach (FileInfo file in Files) {
            //    cms.DropDownItems.Add(new ToolStripMenuItem(file.Name, null));
            //}
        }

        protected ToolStripMenuItem CreateMenuItem(string text) {
            ToolStripMenuItem menu_item = new ToolStripMenuItem(text);
            return menu_item;
        }

        public void AddStart(PHPApp php) {
            PHPStart += new PHPEventHandler(php.Start);
        }

        public void AddStop(PHPApp php) {
            PHPStop += new PHPEventHandler(php.Stop);
        }

        public void AddRestart(PHPApp php) {
            PHPRestart += new PHPEventHandler(php.Restart);
        }
    }
}
