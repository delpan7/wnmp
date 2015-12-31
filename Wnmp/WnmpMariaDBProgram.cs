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
    public class WnmpMariaDBProgram : WnmpProgram
    {
        private string mdb_pidfile;
        public WnmpMariaDBProgram(Label Label_name, CheckBox chekbox_name)
        {
            baseDir = Main.StartupPath + "/mariadb/";

            mdb_pidfile = baseDir + "data/" + Environment.MachineName + ".pid";

            exeName = baseDir + "/bin/mysqld.exe";
            procName = "mysqld";
            progName = "MariaDB";
            progLogSection = Log.LogSection.WNMP_MARIADB;
            startArgs = "";
            stopArgs = "";
            killStop = true;
            statusLabel = Label_name;
            statusChecked = chekbox_name;
            confDir = baseDir;
            logDir = baseDir + "data/";

            if (!Directory.Exists(Application.StartupPath + "/mariadb"))
                Log.wnmp_log_error("Error: MariaDB Not Found", Log.LogSection.WNMP_MARIADB);

            this.DirFiles(baseDir, "my.ini", configContextMenu);
            this.DirFiles(baseDir + "data", "*.err", logContextMenu);

            this.SetStatusLabel();
        }

        public new void Stop()
        {
            try
            {
                Process process = Process.GetProcessById(PID);
                process.Kill();
                /* A hack to delete MariaDB's PID file */
                if (File.Exists(mdb_pidfile))
                    File.Delete(mdb_pidfile);
                PID = 0;
                Log.wnmp_log_notice("Stopped " + progName, progLogSection);
                SetStoppedLabel();
            }
            catch (Exception ex)
            {
                Log.wnmp_log_error(ex.Message, progLogSection);
            }
        }
        public void Shell()
        {
            if (IsRunning() == false)
                Start();

            try
            {
                Process.Start(baseDir + "bin/mysql.exe", "-u root -p");
                Log.wnmp_log_notice("Started MariaDB shell", Log.LogSection.WNMP_MARIADB);
            }
            catch (Exception ex)
            {
                Log.wnmp_log_error(ex.Message, Log.LogSection.WNMP_MARIADB);
            }
        }
    }
}
