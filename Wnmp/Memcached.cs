using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Windows.Forms;
using Wnmp.Forms;
using System.ServiceProcess;
using System.Diagnostics;
using System.Security.Principal;


namespace Wnmp
{
    class Memcached : Wnmp
    {
        private readonly ServiceController MemController = new ServiceController();
        //private string installexeName = "-d install";
        private string installArgs = "-d install";
        public Memcached(Label status_label) : base(status_label)
        {
            /* Set MariaDB service details */
            MemController.MachineName = Environment.MachineName;
            MemController.ServiceName = "memcached";
            progLogSection = Log.LogSection.WNMP_MEMCACHED;

            if (!ServiceExists()) {
                install();
            }
        }

        private void install() {
            if (!IsAdministrator()) {
                MessageBox.Show("请以管理员身份运行本程序");
                return;
            }
            try {
                StartProcess(baseDir + procName, installArgs);
                Log.wnmp_log_notice("Install " + progName, progLogSection);
            } catch (Exception ex) {
                Log.wnmp_log_error(ex.Message, progLogSection);
            }
        }

        public bool ServiceExists() {
            ServiceController[] services = ServiceController.GetServices();
            foreach (var service in services) {
                if (service.ServiceName == MemController.ServiceName) {
                    return true;
                }    
            }
            return false;
        }

        /// <summary>
        /// 管理员身份
        /// </summary>
        /// <returns></returns>
        public bool IsAdministrator() {
            WindowsIdentity current = WindowsIdentity.GetCurrent();
            WindowsPrincipal windowsPrincipal = new WindowsPrincipal(current);
            return windowsPrincipal.IsInRole(WindowsBuiltInRole.Administrator);
        }

        public override void Start() {
            try {
                if (isRunning() == false) {
                    MemController.Start();
                }
                SetStartedLabel();
                Log.wnmp_log_notice("Started " + progName, progLogSection);
            } catch (Exception ex) {
                Log.wnmp_log_error("Start(): " + ex.Message, progLogSection);
            }
        }

        public override void Stop() {
            try {
                if (isRunning() == true) {
                    MemController.Stop();
                }
                if (isRunning() == true) {
                    base.Stop();
                } else {
                    Log.wnmp_log_notice("Stopped " + progName, progLogSection);
                }
                SetStoppedLabel();
            } catch (Exception ex) {
                Log.wnmp_log_notice("Stop(): " + ex.Message, progLogSection);
            }
        }
    }
}
