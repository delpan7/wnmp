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
        public bool NginxChecked = false;
        public bool MariaDBChecked = false;
        public bool MemcachedChecked = false;
        public bool RedisChecked = false;
        public string phpBin = "";
        public short PHP_Port = 9001;
        public int PHP_Processes = 2;
        public bool FirstRun = true;
        private string IniFile;

        public Ini(){
            if (!File.Exists(iniPath))
                UpdateSettings(); // Update options with default values

            if (!LoadIniFile())
                return;
            Editor = ReadIniValue("editorpath", Editor);
            Boolean.TryParse(ReadIniValue("startupwithwindows", StartWithWindows), out StartWithWindows);
            Boolean.TryParse(ReadIniValue("startallapplicationsatlaunch", RunAppsAtLaunch), out RunAppsAtLaunch);
            Boolean.TryParse(ReadIniValue("minimizewnmptotray", MinimizeWnmpToTray), out MinimizeWnmpToTray);
            Boolean.TryParse(ReadIniValue("firstrun", FirstRun), out FirstRun);

            Boolean.TryParse(ReadIniValue("ngx_checked", NginxChecked), out NginxChecked);
            Boolean.TryParse(ReadIniValue("mdb_checked", MariaDBChecked), out MariaDBChecked);
            Boolean.TryParse(ReadIniValue("mem_checked", MemcachedChecked), out MemcachedChecked);
            Boolean.TryParse(ReadIniValue("rds_checked", RedisChecked), out RedisChecked);

            int.TryParse(ReadIniValue("phpprocesses", PHP_Processes), out PHP_Processes);
            short.TryParse(ReadIniValue("phpport", PHP_Port), out PHP_Port);
            phpBin = ReadIniValue("phpbin", phpBin);
            MessageBox.Show(NginxChecked.ToString());
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
                sw.WriteLine("; 勾选Nginx\r\nngx_checked=" + NginxChecked);
                sw.WriteLine("; 勾选MariaDB\r\nmdb_checked=" + MariaDBChecked);
                sw.WriteLine("; 勾选Memcached\r\nmem_checked=" + MemcachedChecked);
                sw.WriteLine("; 勾选Redis\r\nrds_checked=" + RedisChecked);
                sw.WriteLine("[PHP]");
                sw.WriteLine("; PHP 进程数\r\nphpprocesses=" + PHP_Processes);
                sw.WriteLine("; PHP 端口\r\nphpport=" + PHP_Port);
                sw.WriteLine("; PHP 使用版本\r\nphpbin=" + phpBin);
            }
        }

        public string[] phpVersions()
        {
            if (Directory.Exists(Main.StartupPath + "/php") == false)
                return new string[0];
            return Directory.GetDirectories(Main.StartupPath + "/php").Select(d => new DirectoryInfo(d).Name).ToArray();
        }
    }
}
