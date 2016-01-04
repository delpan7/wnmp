using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Windows.Forms;
using Wnmp.Forms;

namespace Wnmp
{
    public class WnmpNginxProgram : WnmpProgram
    {
        public WnmpNginxProgram(Label Label_name, CheckBox chekbox_name)
        {
            baseDir = Main.StartupPath.Replace(@"\", "/") + "/nginx/";
            exeName = baseDir + "nginx.exe";
            procName = "nginx";
            progName = "Nginx";
            progLogSection = Log.LogSection.WNMP_NGINX;
            startArgs = "";
            stopArgs = "-s stop";
            killStop = false;
            statusLabel = Label_name;
            statusChecked = chekbox_name;
            confDir = baseDir + "conf/";
            logDir = baseDir + "logs/";
            
            if (!File.Exists(baseDir + "nginx.exe"))
                Log.wnmp_log_error("Error: Nginx Not Found", Log.LogSection.WNMP_NGINX);

            this.DirFiles(baseDir + "conf", "*.conf", configContextMenu);
            this.DirFiles(logDir, "*.log", logContextMenu);

            this.SetStatusLabel();
        }

        public void UpdatePHPngxCfg()
        {
            int i;
            int port = (int)Options.settings.PHP_Port;
            int PHPProcesses = (int)Options.settings.PHP_Processes;

            using (var sw = new StreamWriter(confDir + "php_processes.conf"))
            {
                sw.WriteLine("# DO NOT MODIFY!!! THIS FILE IS MANAGED BY THE WNMP CONTROL PANEL.\r\n");
                sw.WriteLine("upstream php_processes {");
                for (i = 1; i <= PHPProcesses; i++)
                {
                    sw.WriteLine("    server 127.0.0.1:" + port + " weight=1;");
                    port++;
                }
                sw.WriteLine("}");
            }
        }
    }
}
