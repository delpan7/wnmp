using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Windows.Forms;
using Wnmp.Forms;

namespace Wnmp
{
    public class PHPApp : WnmpApp
    {

        
        public PHPApp(Main wnmpForm)
        {
            baseDir = Main.StartupPath + "/php/" + Options.settings.phpBin + "/";
            exeName = baseDir + "php-cgi.exe";
            procName = "php-cgi";
            progName = "PHP";
            progLogSection = Log.LogSection.WNMP_PHP;
            startArgs = ""; // Special handling see StartPHP() in the WnmpProgram class
            stopArgs = "";
            killStop = true;
            confDir = baseDir;
            logDir = Main.StartupPath + "temp/logs/php/";

            if (!Directory.Exists(baseDir))
                Log.wnmp_log_error("Error: PHP Not Found", Log.LogSection.WNMP_PHP);

            ToolStripMenuItem php_option = CreateMenuItem("PHP 配置");
            options[confDir] = "php.ini";
            options[logDir] = "*.log";
            SetOption(options, php_option);

            wnmpForm.optionsFileStripMenuItem.DropDownItems.Add(php_option);
        }

        public override void Start()
        {
            int i;
            int ProcessCount = Options.settings.PHP_Processes;
            short port = Options.settings.PHP_Port;
            string phpini = confDir + "php.ini";

            try
            {
                for (i = 1; i <= ProcessCount; i++)
                {
                    StartProcess(exeName, String.Format("-b localhost:{0} -c {1}", port, phpini));
                    Log.wnmp_log_notice("Starting PHP " + i + "/" + ProcessCount + " On port: " + port, progLogSection);
                    port++;
                }
                Log.wnmp_log_notice("PHP started", progLogSection);
                //SetStartedLabel();
            }
            catch (Exception ex)
            {
                Log.wnmp_log_error(ex.Message, progLogSection);
            }
        }
    }
}
