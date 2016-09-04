using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;
using Wnmp.Forms;

namespace Wnmp
{
    public class MariaDB : Wnmp
    {
        private string mdb_pidfile;
        public MariaDB(Label status_label) : base(status_label)
        {
            mdb_pidfile = baseDir + "data/" + Environment.MachineName + ".pid";
            progLogSection = Log.LogSection.WNMP_MARIADB;

            optionContextMenu = CreateMenuItem("MariaDB 配置");
            options[confDir] = "my.ini";
            options[logDir] = "*.err";
            SetOption(optionContextMenu);
        }

        public new void Stop() {
            try {
                Process process = Process.GetProcessById(PID);
                process.Kill();
                /* A hack to delete MariaDB"s PID file */
            if (File.Exists(mdb_pidfile))
                    File.Delete(mdb_pidfile);
                PID = 0;
                Log.wnmp_log_notice("Stopped " + progName, progLogSection);
                SetStoppedLabel();
            } catch (Exception ex) {
                Log.wnmp_log_error(ex.Message, progLogSection);
            }
            ps.Close();
        }
        public void Shell() {
            if (isRunning() == false)
                Start();

            try {
                Process.Start(exeName, "-u root -p");
                Log.wnmp_log_notice("Started MariaDB shell", progLogSection);
            } catch (Exception ex) {
                Log.wnmp_log_error(ex.Message, progLogSection);
            }
        }
    }
}
