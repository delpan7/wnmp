using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Wnmp
{
    class WnmpMariaDBProgram : WnmpProgram
    {
        public WnmpMariaDBProgram()
        {
            baseDir = "mariadb/";
            exeName = "/bin/mysqld.exe";
            procName = "mysqld";
            progName = "MariaDB";
            progLogSection = Log.LogSection.WNMP_MARIADB;
            startArgs = "";
            stopArgs = "";
            killStop = true;
            statusLabel = mdb_name;
            statusChecked = mdb_check_box;
            confDir = "";
            logDir = "data/";
        }
    }
}
