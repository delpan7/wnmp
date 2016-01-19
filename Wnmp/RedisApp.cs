using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Windows.Forms;
using Wnmp.Forms;

namespace Wnmp
{
    class RedisApp : WnmpApp
    {
        public RedisApp(Main wnmpForm) {
            baseDir = Main.StartupPath + "/redis/";
            exeName = baseDir + "redis-server.exe";
            procName = "redis-server";
            progName = "Redis";
            progLogSection = Log.LogSection.WNMP_REDIS;
            startArgs = ""; // Special handling see StartPHP() in the WnmpProgram class
            stopArgs = "";
            killStop = true;
            statusLabel = wnmpForm.rds_name;
            statusChecked = wnmpForm.rds_check_box;
            confDir = baseDir;

            if (!Directory.Exists(baseDir))
                Log.wnmp_log_error("Error: Redis Not Found", Log.LogSection.WNMP_REDIS);

            this.SetStatusLabel();
        }
    }
}
