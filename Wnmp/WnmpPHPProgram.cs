using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Wnmp
{
    class WnmpPHPProgram : WnmpProgram
    {
        public WnmpPHPProgram()
        {
            baseDir = "/php/" + Options.settings.phpBin + "/";
            exeName = "php-cgi.exe";
            procName = "php-cgi";
            progName = "PHP";
            progLogSection = Log.LogSection.WNMP_PHP;
            startArgs = ""; // Special handling see StartPHP() in the WnmpProgram class
            stopArgs = "";
            killStop = true;
            statusLabel = php_name;
            statusChecked = php_check_box;
            confDir = "";
            logDir = "logs/";
        }
    }
}
