using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Windows.Forms;
using Wnmp.Forms;

namespace Wnmp
{
    public class WnmpPHPProgram : WnmpProgram
    {
        public WnmpPHPProgram(Label Label_name, CheckBox chekbox_name)
        {
            baseDir = Main.StartupPath + "/php/" + Options.settings.phpBin + "/";
            exeName = "php-cgi.exe";
            procName = "php-cgi";
            progName = "PHP";
            progLogSection = Log.LogSection.WNMP_PHP;
            startArgs = ""; // Special handling see StartPHP() in the WnmpProgram class
            stopArgs = "";
            killStop = true;
            statusLabel = Label_name;
            statusChecked = chekbox_name;
            confDir = "";
            logDir = "logs/";

            if (!Directory.Exists(Application.StartupPath + "/php"))
                Log.wnmp_log_error("Error: PHP Not Found", Log.LogSection.WNMP_PHP);

            DirFiles(baseDir, "php.ini", configContextMenu);
            DirFiles(baseDir + "logs", "*.log", logContextMenu);

            this.SetStatusLabel();
        }

        public void Start()
        {
            SetStartedLabel();
            return;
            int i;
            int ProcessCount = Options.settings.PHP_Processes;
            short port = Options.settings.PHP_Port;
            string phpini = baseDir + confDir + "php.ini";

            try
            {
                for (i = 1; i <= ProcessCount; i++)
                {
                    StartProcess(exeName, String.Format("-b localhost:{0} -c {1}", port, phpini));
                    Log.wnmp_log_notice("Starting PHP " + i + "/" + ProcessCount + " On port: " + port, progLogSection);
                    port++;
                }
                Log.wnmp_log_notice("PHP started", progLogSection);
                SetStartedLabel();
            }
            catch (Exception ex)
            {
                Log.wnmp_log_error(ex.Message, progLogSection);
            }
        }
    }
}
