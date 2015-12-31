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
using System.Windows.Forms;
using Microsoft.Win32;

using Wnmp.Configuration;
using System.Linq;

namespace Wnmp.Forms
{
    /// <summary>
    /// Form that allows configuring Wnmp options.
    /// </summary>
    public partial class Options : Form
    {
        public static Ini settings = new Ini();
        public static Main mainForm;
        private string Editor;

        public Options()
        {
            InitializeComponent();
        }

        protected override CreateParams CreateParams
        {
            get {
                var myCp = base.CreateParams;
                myCp.Style = myCp.Style; // Remove WS_THICKFRAME (Disables resizing)
                return myCp;
            }
        }

        private void SetEditor()
        {
            string input = "";
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "executable files (*.exe)|*.exe|All files (*.*)|*.*";
            dialog.Title  = "Select a text editor";
            if (dialog.ShowDialog() == DialogResult.OK)
                input = dialog.FileName;

            editorTB.Text = dialog.FileName;
            Editor = dialog.FileName;

            if (input == "")
                Editor = "notepad.exe";
            editorTB.Text = Editor;
        }

        private void Options_Load(object sender, EventArgs e)
        {
            settings.ReadSettings();
            UpdateOptions();
        }

        private void selecteditor_Click(object sender, EventArgs e)
        {
            SetEditor();
        }

        private void Save_Click(object sender, EventArgs e)
        {
            SetSettings();
            settings.UpdateSettings();
            
            /* 切换PHP版本 */
            mainForm.ReloadSetupPHP();
            //更新PHP进程配置文件
            mainForm.UpdatePHPngxCfg();

            this.Close();
        }

        private void SetSettings()
        {
            settings.Editor = Editor;
            settings.StartWithWindows = StartWnmpWithWindows.Checked;
            settings.RunAppsAtLaunch = StartAllProgramsOnLaunch.Checked;
            settings.MinimizeWnmpToTray = MinimizeWnmpToTray.Checked;
            settings.PHP_Processes = (int)PHP_PROCESSES.Value;
            settings.PHP_Port = (short)PHP_PORT.Value;
            settings.phpBin = phpBin.Text;
        }

        /// <summary>
        /// Populates the options with there saved values
        /// </summary>
        private void UpdateOptions()
        {
            editorTB.Text = settings.Editor;
            StartWnmpWithWindows.Checked = settings.StartWithWindows;
            StartAllProgramsOnLaunch.Checked = settings.RunAppsAtLaunch;
            MinimizeWnmpToTray.Checked = settings.MinimizeWnmpToTray;
            PHP_PROCESSES.Value = settings.PHP_Processes;
            PHP_PORT.Value = settings.PHP_Port;
            //phpBin.Items.Add("Default");
            foreach (string str in settings.phpVersions()) {
                phpBin.Items.Add(str);
            }
            
            if (settings.phpBin.Length > 0)
            {
                phpBin.SelectedIndex = phpBin.Items.IndexOf(settings.phpBin);
            }
            else
            {
                phpBin.SelectedIndex = 0;
            }
            Console.WriteLine("{0}", settings.phpBin.ToString());
        }

        

        private void StartWithWindows()
        {
            RegistryKey root;
            const string key = "SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run";
            if (StartWnmpWithWindows.Checked) {
                root = Registry.CurrentUser.OpenSubKey(key, true);
                if (root.GetValue("Wnmp") == null)
                    root.SetValue("Wnmp", "\"" + Application.ExecutablePath + "\"");
            } else {
                root = Registry.CurrentUser.OpenSubKey(key, true);
                if (root.GetValue("Wnmp") != null)
                    root.DeleteValue("Wnmp");
            }
        }

        private void Cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void editorTB_DoubleClick(object sender, EventArgs e)
        {
            SetEditor();
        }
    }
}