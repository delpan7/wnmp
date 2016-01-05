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
using System.Windows.Forms;
using System.Diagnostics;
using System.IO;
using System.Collections.Generic;
using Wnmp.Configuration;

namespace Wnmp.Forms
{

    /// <summary>
    /// Main form of Wnmp
    /// </summary>
    public partial class Main : Form
    {
        private WnmpNginxProgram Nginx;
        private WnmpMariaDBProgram MariaDB;
        private WnmpPHPProgram PHP;
        public static Ini settings = new Ini();
        public static string StartupPath { get { return Application.StartupPath; } }

        public static readonly Version CPVER = new Version("3.0.2");

        private readonly NotifyIcon WnmpTrayIcon = new NotifyIcon();

        protected override CreateParams CreateParams
        {
            get {
                var myCp = base.CreateParams;
                myCp.Style = myCp.Style; // Remove WS_THICKFRAME (Disables resizing)
                return myCp;
            }
        }

        public Main()
        {
            InitializeComponent();
            Options.settings.ReadSettings();
            Options.settings.UpdateSettings();
            Options.mainForm = this;

            Log.setLogComponent(log_rtb);
            Log.wnmp_log_notice("Checking for applications", Log.LogSection.WNMP_MAIN);

            Nginx = new WnmpNginxProgram(this);
            MariaDB = new WnmpMariaDBProgram(mdb_name, mdb_check_box);
            PHP = new WnmpPHPProgram(php_name, php_check_box);
        }

        private void DoCheckIfAppsAreRunningTimer()
        {
            Timer timer = new Timer();
            timer.Interval = 5000; // TODO: 5 seconds sounds reasonable?
            timer.Tick += (s, e) => {
                Nginx.SetStatusLabel();
                MariaDB.SetStatusLabel();
                PHP.SetStatusLabel();
            };
            timer.Start();
        }

        private void Main_Load(object sender, EventArgs e)
        {
            WnmpTrayIcon.Click += WnmpTrayIcon_Click;
            WnmpTrayIcon.Icon = Properties.Resources.logo;
            WnmpTrayIcon.Visible = true;

            UpdateOptions();

            DoCheckIfAppsAreRunningTimer();

            FirstRun();

            if (Options.settings.RunAppsAtLaunch)
                start_select_Click(null, null);

            Log.wnmp_log_notice("Wnmp ready to go!", Log.LogSection.WNMP_MAIN);
        }

        private bool NotifyMinimizeWnmp = true;
        private void Main_Resize(object sender, EventArgs e)
        {
            if (Options.settings.MinimizeWnmpToTray == false)
                return;

            if (WindowState == FormWindowState.Minimized) {
                this.Hide();
                if (NotifyMinimizeWnmp == false)
                    return;

                NotifyMinimizeWnmp = false;
                WnmpTrayIcon.BalloonTipTitle = "Wnmp";
                WnmpTrayIcon.BalloonTipText = "Wnmp has been minimized to the tray.";
                WnmpTrayIcon.ShowBalloonTip(4000);
            }
        }

        private void Main_FormClosing(object sender, FormClosingEventArgs e)
        {
            /* Cleanup */
            WnmpTrayIcon.Dispose();
        }

        private void WnmpTrayIcon_Click(object sender, EventArgs e)
        {
            this.Show();
            this.WindowState = FormWindowState.Normal;
        }

        private void FirstRun()
        {
            if (Options.settings.FirstRun == false)
                return;

            if (!File.Exists(Main.StartupPath + "/bin/CertGen.exe"))
                return;
           if (!Directory.Exists(Main.StartupPath + "/conf"))
               Directory.CreateDirectory(Main.StartupPath + "/conf");

            using (Process ps = new Process()) {
                ps.StartInfo.FileName = Main.StartupPath + "/bin/CertGen.exe";
                ps.StartInfo.UseShellExecute = false;
                ps.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                ps.StartInfo.CreateNoWindow = true;
                ps.Start();
                Options.settings.FirstRun = false;
                Options.settings.UpdateSettings();
            }
        }

        /// <summary>
        /// 切换PHP版本
        /// </summary>
        public void ReloadSetupPHP()
        {
            bool is_runing = PHP.IsRunning();
            if (is_runing)
                PHP.Stop();

            PHP = new WnmpPHPProgram(php_name, php_check_box);

            if (is_runing)
                PHP.Start();
        }

        /// <summary>
        /// 更新PHP进程配置文件
        /// </summary>
        public void UpdatePHPngxCfg()
        {
            Nginx.UpdatePHPngxCfg();
            
        }

        private void SetSettings()
        {
            //settings.NginxChecked = ngx_check_box.Checked;
            settings.MariaDBChecked = mdb_check_box.Checked;
            settings.PHPChecked = php_check_box.Checked;
        }

        private void UpdateOptions()
        {
            //ngx_check_box.Checked = settings.NginxChecked;
            mdb_check_box.Checked = settings.MariaDBChecked;
            php_check_box.Checked = settings.PHPChecked;
        }

        /// <summary>
        /// Takes a form and displays it
        /// </summary>
        private void ShowForm(Form form)
        {
            form.StartPosition = FormStartPosition.CenterParent;
            form.ShowDialog(this);
            form.Focus();
        }

        /* File Menu */
        private void wnmpOptionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Options form = new Options();
            ShowForm(form);
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        /* Tools Menu */

        private void hostToIPToolStripMenuItem_Click(object sender, EventArgs e)
        {
            HostToIPForm form = new HostToIPForm();
            ShowForm(form);
        }

        private void getHTTPHeadersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            HttpHeaders form = new HttpHeaders();
            ShowForm(form);
        }

        /* Lone button */

        private void localhostToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Process.Start("http://localhost");
        }

        /*  Right Hand Side */

        private void start_select_Click(object sender, EventArgs e)
        {
            if (Nginx.IsChecked()) Nginx.Start();
            if (MariaDB.IsChecked()) MariaDB.Start();
            if (PHP.IsChecked()) PHP.Start();
        }

        private void stop_select_Click(object sender, EventArgs e)
        {
            if (Nginx.IsChecked()) Nginx.Stop();
            if (MariaDB.IsChecked()) MariaDB.Stop();
            if (PHP.IsChecked()) PHP.Stop();
        }

        private void mdb_shell_Click(object sender, EventArgs e)
        {
            MariaDB.Shell();
        }

        private void wnmpdir_Click(object sender, EventArgs e)
        {
            // If this fails.... we have a bigger problem.
            Process.Start("explorer.exe", Application.StartupPath);
        }

        /* Applications Section */

        private void ngx_start_Click(object sender, EventArgs e)
        {
            Nginx.Start();
        }

        private void ngx_stop_Click(object sender, EventArgs e)
        {
            Nginx.Stop();
        }

        private void ngx_reload_Click(object sender, EventArgs e)
        {
            Nginx.Restart();
        }

        private void ngx_config_Click(object sender, EventArgs e)
        {
            Nginx.ConfigButton(sender);
        }

        private void ngx_log_Click(object sender, EventArgs e)
        {
            Nginx.LogButton(sender);
        }

        private void mdb_start_Click(object sender, EventArgs e)
        {
            MariaDB.Start();
        }

        private void mdb_stop_Click(object sender, EventArgs e)
        {
            MariaDB.Stop();
        }

        private void mdb_restart_Click(object sender, EventArgs e)
        {
            MariaDB.Restart();
        }

        private void mdb_cfg_Click(object sender, EventArgs e)
        {
            MariaDB.ConfigButton(sender);
        }

        private void mdb_log_Click(object sender, EventArgs e)
        {
            MariaDB.LogButton(sender);
        }

        private void php_start_Click(object sender, EventArgs e)
        {
            PHP.Start();
        }

        private void php_stop_Click(object sender, EventArgs e)
        {
            PHP.Stop();
        }

        private void php_restart_Click(object sender, EventArgs e)
        {
            PHP.Restart();
        }

        private void php_cfg_Click(object sender, EventArgs e)
        {
            PHP.ConfigButton(sender);
        }

        private void php_log_Click(object sender, EventArgs e)
        {
            PHP.LogButton(sender);
        }

        public void app_check_box_CheckedChanged(object sender, EventArgs e)
        {
            SetSettings();
            settings.UpdateSettings();
        }
    }
}
