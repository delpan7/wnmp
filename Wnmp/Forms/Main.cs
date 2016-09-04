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
        private Nginx Nginx;
        private MariaDB MariaDB;
        private PHP PHP;
        private Memcached Memcached;
        private Redis Redis;
        public static Ini settings = new Ini();
        public static string StartupPath { get { return Application.StartupPath; } }

        public static readonly Version CPVER = new Version("3.0.2");

        private readonly NotifyIcon WnmpTrayIcon = new NotifyIcon();

        protected override CreateParams CreateParams {
            get {
                var myCp = base.CreateParams;
                myCp.Style = myCp.Style; // Remove WS_THICKFRAME (Disables resizing)
                return myCp;
            }
        }

        public Main() {
            InitializeComponent();
            
            Options.settings.UpdateSettings();
            UpdateOptions();
            Log.setLogComponent(log_rtb);
            Log.wnmp_log_notice("Checking for applications", Log.LogSection.WNMP_MAIN);
            
            Nginx = new Nginx(ngx_name);
            PHP = new PHP();

            Nginx.AddEvent(PHP);

            Memcached = new Memcached(mem_name);
            Redis = new Redis(rds_name);
            MariaDB = new MariaDB(mdb_name);
        }

        private void DoCheckIfAppsAreRunningTimer() {
            Timer timer = new Timer();
            timer.Interval = 5000; // TODO: 5 seconds sounds reasonable?
            timer.Tick += (s, e) => {
                Nginx.SetStatusLabel();
                MariaDB.SetStatusLabel();
                Memcached.SetStatusLabel();
                Redis.SetStatusLabel();
            };
            timer.Start();
        }

        private void Main_Load(object sender, EventArgs e) {
            
            WnmpTrayIcon.Click += WnmpTrayIcon_Click;
            WnmpTrayIcon.Icon = Properties.Resources.logo;
            WnmpTrayIcon.Visible = true;

            DoCheckIfAppsAreRunningTimer();

            FirstRun();

            if (Options.settings.RunAppsAtLaunch)
                start_select_Click(null, null);

            Log.wnmp_log_notice("Wnmp ready to go!", Log.LogSection.WNMP_MAIN);
        }

        private bool NotifyMinimizeWnmp = true;
        private void Main_Resize(object sender, EventArgs e) {
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

        private void Main_FormClosing(object sender, FormClosingEventArgs e) {
            /* Cleanup */
            WnmpTrayIcon.Dispose();
        }

        private void WnmpTrayIcon_Click(object sender, EventArgs e) {
            this.Show();
            this.WindowState = FormWindowState.Normal;
        }

        private void FirstRun() {
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

        private void SetSettings() {
            Nginx.isChecked = settings.appChecked["Nginx"] = ngx_check_box.Checked;
            MariaDB.isChecked = settings.appChecked["MariaDB"] = mdb_check_box.Checked;
            Memcached.isChecked = settings.appChecked["Memcached"] = mem_check_box.Checked;
            Redis.isChecked = settings.appChecked["Redis"] = rds_check_box.Checked;
        }

        private void DoCheckAppsStopTimer() {
            Timer timer = new Timer();
            timer.Interval = 500; // TODO: 5 seconds sounds reasonable?
            timer.Tick += (s, e) => {
                if (Nginx.isChecked && Nginx.isRunning()
                && PHP.isChecked && PHP.isRunning()
                && MariaDB.isChecked && MariaDB.isRunning()
                && Memcached.isChecked && Memcached.isRunning()
                && Redis.isChecked && Redis.isRunning()) {
                    
                } else {
                    start_select.Enabled = true;
                    timer.Stop();
                }
            };
            timer.Start();
        }

        private void UpdateOptions() {
            ngx_check_box.Checked = settings.appChecked["Nginx"];
            mdb_check_box.Checked = settings.appChecked["MariaDB"];
            mem_check_box.Checked = settings.appChecked["Memcached"];
            rds_check_box.Checked = settings.appChecked["Redis"];

            ngx_check_box.CheckedChanged += new System.EventHandler(this.app_check_box_CheckedChanged);
            mdb_check_box.CheckedChanged += new System.EventHandler(this.app_check_box_CheckedChanged);
            mem_check_box.CheckedChanged += new System.EventHandler(this.app_check_box_CheckedChanged);
            rds_check_box.CheckedChanged += new System.EventHandler(this.app_check_box_CheckedChanged);
        }

        /// <summary>
        /// Takes a form and displays it
        /// </summary>
        private void ShowForm(Form form) {
            form.StartPosition = FormStartPosition.CenterParent;
            form.ShowDialog(this);
            form.Focus();
        }

        /* File Menu */
        private void wnmpOptionsToolStripMenuItem_Click(object sender, EventArgs e) {
            Options form = new Options();
            ShowForm(form);
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e) {
            Application.Exit();
        }

        /* Tools Menu */

        private void hostToIPToolStripMenuItem_Click(object sender, EventArgs e) {
            HostToIPForm form = new HostToIPForm();
            ShowForm(form);
        }

        private void getHTTPHeadersToolStripMenuItem_Click(object sender, EventArgs e) {
            HttpHeaders form = new HttpHeaders();
            ShowForm(form);
        }

        /* Lone button */

        private void localhostToolStripMenuItem_Click(object sender, EventArgs e) {
            Process.Start("http://localhost");
        }

        /*  Right Hand Side */

        private void start_select_Click(object sender, EventArgs e) {
            //MessageBox.Show(settings.appChecked["MariaDB"].ToString());
            if (Nginx.isChecked) Nginx.Start();
            if (MariaDB.isChecked) MariaDB.Start();
            if (Memcached.isChecked) Memcached.Start();
            if (Redis.isChecked) Redis.Start();
        }

        private void stop_select_Click(object sender, EventArgs e) {
            start_select.Enabled = false;
            if (Nginx.isChecked) Nginx.Stop();
            if (MariaDB.isChecked) MariaDB.Stop();
            if (Memcached.isChecked) Memcached.Stop();
            if (Redis.isChecked) Redis.Stop();
            DoCheckAppsStopTimer();
        }

        private void mdb_shell_Click(object sender, EventArgs e) {
            MariaDB.Shell();
        }

        private void wnmpdir_Click(object sender, EventArgs e) {
            // If this fails.... we have a bigger problem.
            Process.Start("explorer.exe", Application.StartupPath);
        }


        private void ngx_name_MouseUp(object sender, MouseEventArgs e) {
            if (e.Button == MouseButtons.Right) {
                Nginx.Restart();
            } else {
                if (Nginx.isRunning()) {
                    Nginx.Stop();
                } else {
                    Nginx.Start();
                }
            }
        }

        private void mdb_name_MouseUp(object sender, MouseEventArgs e) {
            if (e.Button == MouseButtons.Right) {
                MariaDB.Restart();
            } else {
                if (MariaDB.isRunning()) {
                    MariaDB.Stop();
                } else {
                    MariaDB.Start();
                }
            }
        }

        private void mem_name_MouseUp(object sender, MouseEventArgs e) {
            if (e.Button == MouseButtons.Right) {
                Memcached.Restart();
            } else {
                if (Memcached.isRunning()) {
                    Memcached.Stop();
                } else {
                    Memcached.Start();
                }
            }
        }

        private void rds_name_MouseUp(object sender, MouseEventArgs e) {
            if (e.Button == MouseButtons.Right) {
                Redis.Restart();
            } else {
                if (Redis.isRunning()) {
                    Redis.Stop();
                } else {
                    Redis.Start();
                }
            }
        }

        public void app_check_box_CheckedChanged(object sender, EventArgs e) {
            SetSettings();
            settings.UpdateSettings();
        }

        private void button1_Click(object sender, EventArgs e) {
            PHP.Restart();
        }

        private void fileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            optionsFileStripMenuItem.DropDownItems.Add(Nginx.optionContextMenu);
            optionsFileStripMenuItem.DropDownItems.Add(PHP.optionContextMenu);
            optionsFileStripMenuItem.DropDownItems.Add(MariaDB.optionContextMenu);
        }
    }
}
