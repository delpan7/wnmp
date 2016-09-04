/*
 * Copyright (c) 2012 - 2015, Kurt Cancemi (kurt@x64architecture.com)
 *
 * This file is part of Wnmp.
 *
 *  Wnmp is free software: you can redistribute it and/or modify
 *  it under the terms of the GNU General Public License as published by
 *  the Free Software Foundation, either version 3 of the License, or
 *  (at your option) any later version.
 *
 *  Wnmp is distributed in the hope that it will be useful,
 *  but WITHOUT ANY WARRANTY; without even the implied warranty of
 *  MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
 *  GNU General Public License for more details.
 *
 *  You should have received a copy of the GNU General Public License
 *  along with Wnmp.  If not, see <http://www.gnu.org/licenses/>.
 */

using System;
using System.IO;
using System.Linq;
using Wnmp.Forms;
using System.Windows.Forms;
using System.Collections.Generic;

namespace Wnmp.Configuration
{
    /// <summary>
    /// Manages the settings
    /// </summary>
    public class Ini
    {
        // Variables that contain the default values
        private readonly string iniPath = Main.StartupPath + "/Wnmp.ini";
        public string Editor = "notepad.exe";
        public bool StartWithWindows = false;
        public bool RunAppsAtLaunch = false;
        public bool MinimizeWnmpToTray = false;
        public Dictionary<string, bool> appChecked = new Dictionary<string, bool> {
            { "Nginx", true }, { "PHP", true }, { "Memcached", true }, { "Redis", true }, { "MariaDB", false },
        };
        public string phpBin = "";
        public short PHP_Port = 9001;
        public int PHP_Processes = 2;
        public bool FirstRun = true;
        private string IniFile;

        public Ini(){
            /*
            appChecked.Add("Nginx", true);
            appChecked.Add("Memcached", true);
            appChecked.Add("Redis", true);
            appChecked.Add("MariaDB", true);
            */
            
            if (!File.Exists(iniPath))
                UpdateSettings(); // Update options with default values
            
            if (!LoadIniFile())
                return;
            Editor = ReadIniValue("editorpath", Editor);
            Boolean.TryParse(ReadIniValue("startupwithwindows", StartWithWindows), out StartWithWindows);
            Boolean.TryParse(ReadIniValue("startallapplicationsatlaunch", RunAppsAtLaunch), out RunAppsAtLaunch);
            Boolean.TryParse(ReadIniValue("minimizewnmptotray", MinimizeWnmpToTray), out MinimizeWnmpToTray);
            Boolean.TryParse(ReadIniValue("firstrun", FirstRun), out FirstRun);

            appChecked["Nginx"] = Convert.ToBoolean(ReadIniValue("ngx_checked", appChecked["Nginx"]));
            appChecked["PHP"] = Convert.ToBoolean(ReadIniValue("ngx_checked", appChecked["Nginx"]));
            appChecked["MariaDB"] = Convert.ToBoolean(ReadIniValue("mdb_checked", appChecked["MariaDB"]));
            appChecked["Memcached"] = Convert.ToBoolean(ReadIniValue("mem_checked", appChecked["Memcached"]));
            appChecked["Redis"] = Convert.ToBoolean(ReadIniValue("rds_checked", appChecked["Redis"]));

            int.TryParse(ReadIniValue("phpprocesses", PHP_Processes), out PHP_Processes);
            short.TryParse(ReadIniValue("phpport", PHP_Port), out PHP_Port);
            phpBin = ReadIniValue("phpbin", phpBin);
            //MessageBox.Show(NginxChecked.ToString());
            //UpdateSettings();
        }

        private bool LoadIniFile()
        {
            if (!File.Exists(iniPath))
                return false;

            StreamReader sr = new StreamReader(iniPath);
            IniFile = sr.ReadToEnd();
            sr.Close();

            return true;
        }

        /// <summary>
        /// Reads an ini value and returns it
        /// </summary>
        /// <param name="Option"></param>
        /// <returns></returns>
        private string ReadIniValue(string Option, object defaultValue)
        {      
            string str = Option + "=";
            using (var sr = new StringReader(IniFile)) {
                string line;
                while ((line = sr.ReadLine()) != null) {
                        if (line.StartsWith(str))
                            return line.Remove(0, str.Length);
                }
            }
            return defaultValue.ToString();
        }

        /// <summary>
        /// Updates the settings to the ini
        /// </summary>
        public void UpdateSettings()
        {
            if (phpBin.Length == 0)
                phpBin = phpVersions()[0];
            
            if (PHP_Port == 9000)
                PHP_Port++;

            using (var sw = new StreamWriter(iniPath)) {
                sw.WriteLine("[WNMP]");
                sw.WriteLine("; 编辑器路径\r\neditorpath=" + Editor);
                sw.WriteLine("; 开机启动\r\nstartupwithwindows=" + StartWithWindows);
                sw.WriteLine("; Wnmp启动时自动启动所选应用\r\nstartallapplicationsatlaunch=" + RunAppsAtLaunch);
                sw.WriteLine("; 最小化到系统托盘\r\nminimizewnmptotray=" + MinimizeWnmpToTray);
                sw.WriteLine("; 是否第一次启动\r\nfirstrun=" + FirstRun);
                sw.WriteLine("; 勾选Nginx\r\nngx_checked=" + appChecked["Nginx"]);
                sw.WriteLine("; 勾选MariaDB\r\nmdb_checked=" + appChecked["MariaDB"]);
                sw.WriteLine("; 勾选Memcached\r\nmem_checked=" + appChecked["Memcached"]);
                sw.WriteLine("; 勾选Redis\r\nrds_checked=" + appChecked["Redis"]);
                sw.WriteLine("[PHP]");
                sw.WriteLine("; PHP 进程数\r\nphpprocesses=" + PHP_Processes);
                sw.WriteLine("; PHP 端口\r\nphpport=" + PHP_Port);
                sw.WriteLine("; PHP 使用版本\r\nphpbin=" + phpBin);
            }
            UpdatePHPProcesses();
        }

        /// <summary>
        /// 返回当前可用的PHP版本列表
        /// </summary>
        /// <returns></returns>
        public string[] phpVersions()
        {
            if (Directory.Exists(Main.StartupPath + "/php") == false)
                return new string[0];
            return Directory.GetDirectories(Main.StartupPath + "/php").Select(d => new DirectoryInfo(d).Name).ToArray();
        }

        /// <summary>
        /// 更新PHP进程配置文件
        /// </summary>
        public void UpdatePHPProcesses()
        {
            int i;
            int port = PHP_Port;
            int php_processes = PHP_Processes;
            Config configs = new Config();
            string php_processes_file = Main.StartupPath + configs.operatingParam["Nginx"]["base_dir"] + configs.operatingParam["Nginx"]["conf_dir"] + "php_processes.conf";

            using (var sw = new StreamWriter(php_processes_file)) {
                sw.WriteLine("# DO NOT MODIFY!!! THIS FILE IS MANAGED BY THE WNMP CONTROL PANEL.\r\n");
                sw.WriteLine("upstream php_processes {");
                for (i = 1; i <= php_processes; i++) {
                    sw.WriteLine("    server 127.0.0.1:" + port + " weight=1;");
                    port++;
                }
                sw.WriteLine("}");
            }
        }
    }
}
