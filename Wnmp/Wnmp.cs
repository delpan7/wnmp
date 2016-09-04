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
using Wnmp.Configuration;

namespace Wnmp
{
    public delegate void PHPEventHandler();
    public class Wnmp
    {
        public event PHPEventHandler PHPStart;

        public event PHPEventHandler PHPStop;

        public event PHPEventHandler PHPRestart;

        public Label statusLabel { get; set; } // Label that shows the programs status
        public bool isChecked = false;
        //public bool isRunning { get; protected set; }
        public string baseDir { get; set; }    // Directory where all the programs configuration files are
        public string exeName { get; set; }    // Location of the executable file
        public string procName { get; set; }   // Name of the process
        public string progName { get; set; }   // User-friendly name of the program 
        public Log.LogSection progLogSection { get; set; } // LogSection of the program
        public string startArgs { get; set; }  // Start Arguments
        public string stopArgs { get; set; }   // Stop Arguments if KillStop is false
        public string restartArgs { get; set; }   // restart Arguments 
        public string confDir { get; set; }    // Directory where all the programs configuration files are
        public string logDir { get; set; }     // Directory where all the programs log files are

        protected Dictionary<string, string> options = new Dictionary<string, string>();
        //public static Config configs = new Config();

        public int PID { get; protected set; }   // PID of process

        public ToolStripMenuItem optionContextMenu { get; set; } // Displays all the programs config files in |confDir|

        public Process ps = new Process();

        private static Config configs = new Config();

        public Wnmp()
        {
            progName = this.GetType().Name;
            Dictionary<string, string> operatingParam = configs.operatingParam[progName];
            baseDir = Main.StartupPath.Replace(@"\", "/") + operatingParam["base_dir"];
            exeName = baseDir + operatingParam["exe_name"];
            procName = operatingParam["proc_name"];
            startArgs = operatingParam["start_args"];
            stopArgs = operatingParam["stop_args"];
            restartArgs = operatingParam["restart_args"];
            confDir = baseDir + operatingParam["conf_dir"];
            logDir = Main.StartupPath.Replace(@"\", "/") + operatingParam["log_dir"];
            //MessageBox.Show(logDir);
            isChecked = Options.settings.appChecked[progName];

            if (!Directory.Exists(baseDir))
                Log.wnmp_log_error("Error: " + progName + " Not Found", progLogSection);
        }
        public Wnmp(Label status_label): this()
        {
            statusLabel = status_label;
        }

        /// <summary>
        /// Changes the labels apperance to started
        /// </summary>
        protected void SetStartedLabel()
        {
            statusLabel.ForeColor = Color.Lime;
        }

        /// <summary>
        /// Changes the labels apperance to stopped
        /// </summary>
        protected void SetStoppedLabel()
        {
            statusLabel.ForeColor = Color.Black;
        }

        public void SetStatusLabel()
        {
            if (isRunning() == true)
                SetStartedLabel();
            else
                SetStoppedLabel();
        }

        protected void StartProcess(string exe, string args)
        {
            ps.StartInfo.FileName = exe;
            ps.StartInfo.Arguments = args;
            ps.StartInfo.UseShellExecute = false;
            ps.StartInfo.RedirectStandardInput = true;
            ps.StartInfo.RedirectStandardOutput = true;
            ps.StartInfo.WorkingDirectory = baseDir;
            ps.StartInfo.CreateNoWindow = true;
            ps.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
            ps.Start();
            PID = ps.Id;
        }
        
        public virtual void Start()
        {
            try {
                if (isRunning() == false)
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

        public virtual void Stop()
        {
            try {
                if (isRunning() == true && stopArgs != "") {
                    StartProcess(exeName, stopArgs);
                }

                if (isRunning()) {
                    Process[] process = Process.GetProcessesByName(procName);
                    foreach (Process currentProc in process) {
                        currentProc.Kill();
                    }
                }
                Log.wnmp_log_notice("Stopped " + progName, progLogSection);
            } catch (Exception ex) {
                Log.wnmp_log_error(ex.Message, progLogSection);
            }

            if (PHPStop != null) {
                PHPStop();
            }
            if (progName != "PHP") {
                SetStoppedLabel();
            }
            ps.Close();
        }

        public virtual void Restart()
        {
            if (restartArgs != "") {
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
                if (isRunning() == true) {
                    Stop();
                }
                Start();
                Log.wnmp_log_notice("Restarted " + progName, progLogSection);
            }
        }

        protected void configContextMenu_ItemClicked(object sender, ToolStripItemClickedEventArgs e) 
        {
            Console.WriteLine("{0}", e.ToString());

            try {
                Process.Start(Options.settings.Editor, confDir + e.ClickedItem.Text);
            } catch (Exception ex) {
                Log.wnmp_log_error(ex.Message, progLogSection);
            }
        }

        public bool isRunning()
        {
            var processes = Process.GetProcessesByName(procName);
            return (processes.Length != 0);
        }
       

        /// <summary>
        /// Adds configuration files or log files to the context menu strip
        /// </summary>
        protected void SetOption(ToolStripMenuItem cms)
        {
            int i = 0;
            foreach (KeyValuePair<string, string> option in options) {
                if(i > 0) cms.DropDownItems.Add(new ToolStripSeparator());
                
                DirectoryInfo dinfo = new DirectoryInfo(option.Key);

                if (!dinfo.Exists)
                    return;

                FileInfo[] Files = dinfo.GetFiles(option.Value);

                foreach (FileInfo file in Files) {
                    cms.DropDownItems.Add(CreateMenuItem(file.Name));
                }
                i++;
            }
            cms.DropDownItemClicked += new ToolStripItemClickedEventHandler(configContextMenu_ItemClicked);
        }

        protected ToolStripMenuItem CreateMenuItem(string text)
        {
            ToolStripMenuItem menu_item = new ToolStripMenuItem(text);
            return menu_item;
        }

        public void AddEvent(PHP php)
        {
            PHPStart += new PHPEventHandler(php.Start);
            PHPStop += new PHPEventHandler(php.Stop);
            PHPRestart += new PHPEventHandler(php.Restart);
        }
    }
}
