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
        public bool isRunning { get; protected set; }
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

        protected Dictionary<string, string> options = new Dictionary<string, string>();

        public int PID { get; protected set; }   // PID of process
        public ContextMenuStrip optionContextMenu { get; set; } // Displays all the programs config files in |confDir|

        public WnmpApp() {
            optionContextMenu = new ContextMenuStrip();
            

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
            if (isRunning == true)
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
            //MessageBox.Show("start");
            try {
                StartProcess(exeName, startArgs);
                Log.wnmp_log_notice("Started " + progName, progLogSection);
                SetIsRunning();
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
                    SetIsRunning();
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
                                SetIsRunning();
                            } catch (Exception ex) {
                            }
                        }).Start();
                    } else {
                        SetIsRunning();
                    }
                }
                Log.wnmp_log_notice("Stopped " + progName, progLogSection);
                if (!IsPHP()) SetStoppedLabel();
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

        protected void configContextMenu_ItemClicked(object sender, ToolStripItemClickedEventArgs e) {
            Console.WriteLine("{0}", e.ToString());

            try {
                Process.Start(Options.settings.Editor, confDir + e.ClickedItem.Text);
            } catch (Exception ex) {
                Log.wnmp_log_error(ex.Message, progLogSection);
            }
        }

        protected void SetIsRunning() {
            Process[] process = Process.GetProcessesByName(procName);

            isRunning = (process.Length != 0);
            SetStatusLabel();
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
            int i = 0;
            foreach (KeyValuePair<string, string> option in options) {
                if(i > 0) cms.DropDownItems.Add(new ToolStripSeparator());
                
                DirectoryInfo dinfo = new DirectoryInfo(option.Key);

                if (!dinfo.Exists)
                    return;

                FileInfo[] Files = dinfo.GetFiles(option.Value);

                foreach (FileInfo file in Files) {
                    cms.DropDownItems.Add(new ToolStripMenuItem(file.Name, null));
                }
                i++;
            }
            cms.DropDownItemClicked += new ToolStripItemClickedEventHandler(configContextMenu_ItemClicked);
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
