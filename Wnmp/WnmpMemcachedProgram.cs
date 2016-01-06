using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Windows.Forms;
using Wnmp.Forms;
using System.ServiceProcess;

namespace Wnmp
{
    class WnmpMemcachedProgram : WnmpProgram
    {
        private string installArgs = "-d install";
        public WnmpMemcachedProgram(Label Label_name, CheckBox chekbox_name) {
            baseDir = Main.StartupPath.Replace(@"\", "/") + "/memcached/";
            exeName = baseDir + "memcached.exe";
            procName = "memcached";
            progName = "Memcached";
            progLogSection = Log.LogSection.WNMP_MEMCACHED;
            startArgs = "-d start"; // Special handling see StartPHP() in the WnmpProgram class
            stopArgs = "-d stop";
            killStop = false;
            statusLabel = Label_name;
            statusChecked = chekbox_name;

            if (!Directory.Exists(baseDir))
                Log.wnmp_log_error("Error: Memcached Not Found", Log.LogSection.WNMP_MEMCACHED);

            if (!isInstall()) install();

            this.SetStatusLabel();
        }

        private void install() {
            try {
                StartProcess(exeName, installArgs);
                Log.wnmp_log_notice("Install " + progName, progLogSection);
            } catch (Exception ex) {
                Log.wnmp_log_error(ex.Message, progLogSection);
            }
        }

        private bool isInstall() {
            return IsServiceIsExisted("memcached");
        }

        public bool IsServiceIsExisted(string NameService) {
            ServiceController[] services = ServiceController.GetServices();
            foreach (ServiceController s in services) {
                if (s.ServiceName.ToLower() == NameService.ToLower()) {
                    return true;
                }
            }
            return false;
        }
    }
}
