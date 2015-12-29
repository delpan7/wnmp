using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Wnmp
{
    class WnmpNginxProgram : WnmpProgram
    {
        public WnmpNginxProgram()
        {
            baseDir = "nginx/";
            exeName = "nginx.exe";
            procName = "nginx";
            progName = "Nginx";
            progLogSection = Log.LogSection.WNMP_NGINX;
            startArgs = "";
            stopArgs = "-s stop";
            killStop = false;
            statusLabel = ngx_name;
            statusChecked = ngx_check_box;
            confDir = "conf/";
            logDir = "logs/";
        }
    }
}
