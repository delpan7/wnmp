using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Windows.Forms;
using Wnmp.Forms;
using System.Diagnostics;

namespace Wnmp
{
    public class PHP : Wnmp
    {
        public PHP()
        {
            ps.StartInfo.EnvironmentVariables.Add("PHP_FCGI_MAX_REQUESTS", "0"); // Disable auto killing PHP
            progLogSection = Log.LogSection.WNMP_PHP;

            optionContextMenu = CreateMenuItem("PHP 配置");
            options[confDir] = "php.ini";
            options[logDir] = "*.log";
            SetOption(optionContextMenu);
        }

        public override void Start()
        {
            int i;
            int ProcessCount = Options.settings.PHP_Processes;
            short port = Options.settings.PHP_Port;
            string phpini = confDir + "php.ini";
            
            try {
                if (isRunning() == false) {
                    for (i = 1; i <= ProcessCount; i++) {
                        StartProcess(exeName, String.Format("-b localhost:{0} -c {1}", port, phpini));
                        Log.wnmp_log_notice("Starting PHP " + i + "/" + ProcessCount + " On port: " + port, progLogSection);
                        port++;
                    }
                }
                Log.wnmp_log_notice("PHP started", progLogSection);
            }catch (Exception ex){
                Log.wnmp_log_error(ex.Message, progLogSection);
            }
        }
    }
}
