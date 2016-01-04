﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Windows.Forms;
using Wnmp.Forms;

namespace Wnmp
{
    class WnmpMemcachedProgram : WnmpProgram
    {
        public WnmpMemcachedProgram(Label Label_name, CheckBox chekbox_name)
        {
            baseDir = Main.StartupPath + "/memcached/";
            exeName = baseDir + "memcached.exe";
            procName = "memcached";
            progName = "Memcached";
            progLogSection = Log.LogSection.WNMP_MEMCACHED;
            startArgs = "-d start"; // Special handling see StartPHP() in the WnmpProgram class
            stopArgs = "-d stop";
            killStop = true;
            statusLabel = Label_name;
            statusChecked = chekbox_name;

            if (!Directory.Exists(baseDir))
                Log.wnmp_log_error("Error: Memcached Not Found", Log.LogSection.WNMP_MEMCACHED);

            this.SetStatusLabel();
        }
    }
}
