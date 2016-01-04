﻿using System;
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
        public WnmpNginxProgram(Main wnmp_form)
        {
            wnmpForm = wnmp_form;
            baseDir = Main.StartupPath.Replace(@"\", "/") + "/nginx/";
            exeName = baseDir + "nginx.exe";
            procName = "nginx";
            progName = "Nginx";
            progLogSection = Log.LogSection.WNMP_NGINX;
            startArgs = "";
            stopArgs = "-s stop";
            killStop = false;
            statusLabel = wnmpForm.ngx_name;
            statusChecked = new System.Windows.Forms.CheckBox();
            //statusChecked.AutoSize = true;
            statusChecked.Checked = true;
            //statusChecked.CheckState = System.Windows.Forms.CheckState.Checked;
            statusChecked.Location = new System.Drawing.Point(25, 49);
            //statusChecked.Margin = new System.Windows.Forms.Padding(2);
            statusChecked.Name = "ngx_check_box";
            //statusChecked.Size = new System.Drawing.Size(15, 14);
            //statusChecked.TabIndex = 79;
            //statusChecked.UseVisualStyleBackColor = true;
            statusChecked.CheckedChanged += new System.EventHandler(this.app_check_box_CheckedChanged);

            wnmpForm.groupBox1.Controls.Add(statusChecked);
            //statusChecked = wnmpForm.ngx_check_box;
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
        public void app_check_box_CheckedChanged(object sender, EventArgs e)
        {

            //SetSettings();
            //settings.UpdateSettings();
        }
    }
}
