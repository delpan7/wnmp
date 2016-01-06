using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Windows.Forms;
using Wnmp.Forms;

namespace Wnmp
{
    class WnmpRedisProgram : WnmpProgram
    {
        public WnmpRedisProgram(Label Label_name, CheckBox chekbox_name) {
            baseDir = Main.StartupPath + "/redis/";
            exeName = baseDir + "redis-server.exe";
            procName = "redis-server";
            progName = "Redis";
            progLogSection = Log.LogSection.WNMP_REDIS;
            startArgs = ""; // Special handling see StartPHP() in the WnmpProgram class
            stopArgs = "";
            killStop = true;
            statusLabel = Label_name;
            statusChecked = chekbox_name;
            confDir = baseDir;

            if (!Directory.Exists(baseDir))
                Log.wnmp_log_error("Error: Redis Not Found", Log.LogSection.WNMP_REDIS);

            this.SetStatusLabel();
        }
    }
}
