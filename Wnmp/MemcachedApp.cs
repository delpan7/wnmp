﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Windows.Forms;
using Wnmp.Forms;
using System.ServiceProcess;

namespace Wnmp
{
    class MemcachedApp : WnmpApp
    {
        private string installexeName = "-d install";
        private string installArgs = "-d install";
        public MemcachedApp(Label Label_name, CheckBox chekbox_name) {
            baseDir = Main.StartupPath.Replace(@"\", "/") + "/memcached/";
            exeName = "cmd.exe";
            procName = "memcached";
            progName = "Memcached";
            progLogSection = Log.LogSection.WNMP_MEMCACHED;
            startArgs = "/c net start memcached"; // Special handling see StartPHP() in the WnmpProgram class
            stopArgs = "/c net stop memcached";
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
                StartProcess(installexeName, installArgs);
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

        //public virtual void Start() { }
    }
}