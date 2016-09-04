using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Wnmp.Forms;

namespace Wnmp.Configuration
{
    class Config
    {
        public Dictionary<string, Dictionary<string, string>> operatingParam = new Dictionary<string, Dictionary<string, string>>();
        public  Config()
        {
            operatingParam["Nginx"] =new Dictionary<string, string> {
                { "base_dir", "/nginx/" },
                { "exe_name", "nginx.exe" },
                { "proc_name", "nginx" },
                { "start_args", "" },
                { "stop_args", "-s stop" },
                { "restart_args", "-s reload"},
                { "conf_dir", "conf/" },
                { "log_dir", "/logs/nginx/" },
            };
            operatingParam["PHP"] = new Dictionary<string, string> {
                { "base_dir", "/php/" + Options.settings.phpBin + "/" },
                { "exe_name", "php-cgi.exe" },
                { "proc_name", "php-cgi" },
                { "start_args", "" },
                { "stop_args", "" },
                { "restart_args", ""},
                { "conf_dir", "" },
                { "log_dir", "/logs/php/" },
            };
            operatingParam["Memcached"] = new Dictionary<string, string> {
                { "base_dir", "/memcached/" },
                { "exe_name", "memcached.exe" },
                { "proc_name", "memcached" },
                { "start_args", "" },
                { "stop_args", "" },
                { "restart_args", ""},
                { "conf_dir", "" },
                { "log_dir", "/" },
            };
            operatingParam["Redis"] = new Dictionary<string, string> {
                { "base_dir", "/redis/" },
                { "exe_name", "redis-server.exe" },
                { "proc_name", "redis-server" },
                { "start_args", "" },
                { "stop_args", "" },
                { "restart_args", ""},
                { "conf_dir", "" },
                { "log_dir", "/" },
            };
            operatingParam["MariaDB"] = new Dictionary<string, string> {
                { "base_dir", "/mariadb/" },
                { "exe_name", "/bin/mysqld.exe" },
                { "proc_name", "mysqld" },
                { "start_args", "" },
                { "stop_args", "" },
                { "restart_args", ""},
                { "conf_dir", "" },
                { "log_dir", "/logs/mysql/" },
            };
        }
    }
}
