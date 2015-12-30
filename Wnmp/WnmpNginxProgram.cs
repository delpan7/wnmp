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
            baseDir = Main.StartupPath + "/nginx/";
            exeName = "nginx.exe";
            procName = "nginx";
            progName = "Nginx";
            progLogSection = Log.LogSection.WNMP_NGINX;
            startArgs = "";
            stopArgs = "-s stop";
            killStop = false;
            statusLabel = Label_name;
            statusChecked = chekbox_name;
            confDir = "conf/";
            logDir = "logs/";

            if (!File.Exists(baseDir + "nginx.exe"))
                Log.wnmp_log_error("Error: Nginx Not Found", Log.LogSection.WNMP_NGINX);

            this.DirFiles(baseDir + "conf", "*.conf", configContextMenu);
            this.DirFiles(baseDir + "logs", "*.log", logContextMenu);

            this.SetStatusLabel();
        }
    }
}
