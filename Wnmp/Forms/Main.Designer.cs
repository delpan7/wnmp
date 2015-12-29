﻿/*
This file is part of Wnmp.

    Wnmp is free software: you can redistribute it and/or modify
    it under the terms of the GNU General Public License as published by
    the Free Software Foundation, either version 3 of the License, or
    (at your option) any later version.

    Wnmp is distributed in the hope that it will be useful,
    but WITHOUT ANY WARRANTY; without even the implied warranty of
    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
    GNU General Public License for more details.

    You should have received a copy of the GNU General Public License
    along with Wnmp.  If not, see <http://www.gnu.org/licenses/>.
*/
namespace Wnmp.Forms
{
    partial class Main
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            this.MainFormMenuStrip = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.wnmpOptionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.checkForUpdatesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.hostToIPToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.getHTTPHeadersToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.supportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.reportBugToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.websiteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.donateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.localhostToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.php_check_box = new System.Windows.Forms.CheckBox();
            this.mdb_check_box = new System.Windows.Forms.CheckBox();
            this.ngx_check_box = new System.Windows.Forms.CheckBox();
            this.php_restart = new System.Windows.Forms.Button();
            this.mdb_restart = new System.Windows.Forms.Button();
            this.ngx_restart = new System.Windows.Forms.Button();
            this.php_log = new System.Windows.Forms.Button();
            this.mdb_log = new System.Windows.Forms.Button();
            this.ngx_log = new System.Windows.Forms.Button();
            this.php_cfg = new System.Windows.Forms.Button();
            this.mdb_cfg = new System.Windows.Forms.Button();
            this.ngx_config = new System.Windows.Forms.Button();
            this.php_name = new System.Windows.Forms.Label();
            this.mdb_name = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.ngx_name = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.mdb_stop = new System.Windows.Forms.Button();
            this.mdb_start = new System.Windows.Forms.Button();
            this.php_start = new System.Windows.Forms.Button();
            this.php_stop = new System.Windows.Forms.Button();
            this.ngx_start = new System.Windows.Forms.Button();
            this.ngx_stop = new System.Windows.Forms.Button();
            this.mdb_shell = new System.Windows.Forms.Button();
            this.start_select = new System.Windows.Forms.Button();
            this.stop_select = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.wnmpdir = new System.Windows.Forms.Button();
            this.log_rtb = new System.Windows.Forms.RichTextBox();
            this.nginx_menu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.startToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.stopToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.restarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.MainFormMenuStrip.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.nginx_menu.SuspendLayout();
            this.SuspendLayout();
            // 
            // MainFormMenuStrip
            // 
            this.MainFormMenuStrip.BackColor = System.Drawing.Color.Transparent;
            this.MainFormMenuStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.MainFormMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.toolsToolStripMenuItem,
            this.helpToolStripMenuItem,
            this.localhostToolStripMenuItem});
            this.MainFormMenuStrip.Location = new System.Drawing.Point(0, 0);
            this.MainFormMenuStrip.Name = "MainFormMenuStrip";
            this.MainFormMenuStrip.Size = new System.Drawing.Size(647, 25);
            this.MainFormMenuStrip.TabIndex = 4;
            this.MainFormMenuStrip.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.wnmpOptionsToolStripMenuItem,
            this.checkForUpdatesToolStripMenuItem,
            this.toolStripSeparator1,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(39, 21);
            this.fileToolStripMenuItem.Text = "&File";
            // 
            // wnmpOptionsToolStripMenuItem
            // 
            this.wnmpOptionsToolStripMenuItem.Name = "wnmpOptionsToolStripMenuItem";
            this.wnmpOptionsToolStripMenuItem.Size = new System.Drawing.Size(187, 22);
            this.wnmpOptionsToolStripMenuItem.Text = "Wnmp Options";
            this.wnmpOptionsToolStripMenuItem.Click += new System.EventHandler(this.wnmpOptionsToolStripMenuItem_Click);
            // 
            // checkForUpdatesToolStripMenuItem
            // 
            this.checkForUpdatesToolStripMenuItem.Name = "checkForUpdatesToolStripMenuItem";
            this.checkForUpdatesToolStripMenuItem.Size = new System.Drawing.Size(187, 22);
            this.checkForUpdatesToolStripMenuItem.Text = "Check For Updates";
            this.checkForUpdatesToolStripMenuItem.Click += new System.EventHandler(this.checkForUpdatesToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(184, 6);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(187, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // toolsToolStripMenuItem
            // 
            this.toolsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.hostToIPToolStripMenuItem,
            this.getHTTPHeadersToolStripMenuItem});
            this.toolsToolStripMenuItem.Name = "toolsToolStripMenuItem";
            this.toolsToolStripMenuItem.Size = new System.Drawing.Size(52, 21);
            this.toolsToolStripMenuItem.Text = "&Tools";
            // 
            // hostToIPToolStripMenuItem
            // 
            this.hostToIPToolStripMenuItem.Name = "hostToIPToolStripMenuItem";
            this.hostToIPToolStripMenuItem.Size = new System.Drawing.Size(183, 22);
            this.hostToIPToolStripMenuItem.Text = "Host To IP";
            this.hostToIPToolStripMenuItem.Click += new System.EventHandler(this.hostToIPToolStripMenuItem_Click);
            // 
            // getHTTPHeadersToolStripMenuItem
            // 
            this.getHTTPHeadersToolStripMenuItem.Name = "getHTTPHeadersToolStripMenuItem";
            this.getHTTPHeadersToolStripMenuItem.Size = new System.Drawing.Size(183, 22);
            this.getHTTPHeadersToolStripMenuItem.Text = "Get HTTP Headers";
            this.getHTTPHeadersToolStripMenuItem.Click += new System.EventHandler(this.getHTTPHeadersToolStripMenuItem_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.supportToolStripMenuItem,
            this.reportBugToolStripMenuItem,
            this.toolStripSeparator2,
            this.websiteToolStripMenuItem,
            this.donateToolStripMenuItem,
            this.aboutToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(47, 21);
            this.helpToolStripMenuItem.Text = "&Help";
            // 
            // supportToolStripMenuItem
            // 
            this.supportToolStripMenuItem.Name = "supportToolStripMenuItem";
            this.supportToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.supportToolStripMenuItem.Text = "Support";
            this.supportToolStripMenuItem.Click += new System.EventHandler(this.SupportToolStripMenuItem_Click);
            // 
            // reportBugToolStripMenuItem
            // 
            this.reportBugToolStripMenuItem.Name = "reportBugToolStripMenuItem";
            this.reportBugToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.reportBugToolStripMenuItem.Text = "Report Bug";
            this.reportBugToolStripMenuItem.Click += new System.EventHandler(this.Report_BugToolStripMenuItem_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(149, 6);
            // 
            // websiteToolStripMenuItem
            // 
            this.websiteToolStripMenuItem.Name = "websiteToolStripMenuItem";
            this.websiteToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.websiteToolStripMenuItem.Text = "Website";
            this.websiteToolStripMenuItem.Click += new System.EventHandler(this.websiteToolStripMenuItem_Click);
            // 
            // donateToolStripMenuItem
            // 
            this.donateToolStripMenuItem.Name = "donateToolStripMenuItem";
            this.donateToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.donateToolStripMenuItem.Text = "Donate";
            this.donateToolStripMenuItem.Click += new System.EventHandler(this.donateToolStripMenuItem_Click);
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.aboutToolStripMenuItem.Text = "About";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // localhostToolStripMenuItem
            // 
            this.localhostToolStripMenuItem.Name = "localhostToolStripMenuItem";
            this.localhostToolStripMenuItem.Size = new System.Drawing.Size(72, 21);
            this.localhostToolStripMenuItem.Text = "localhost";
            this.localhostToolStripMenuItem.Click += new System.EventHandler(this.localhostToolStripMenuItem_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.php_check_box);
            this.groupBox1.Controls.Add(this.mdb_check_box);
            this.groupBox1.Controls.Add(this.ngx_check_box);
            this.groupBox1.Controls.Add(this.php_restart);
            this.groupBox1.Controls.Add(this.mdb_restart);
            this.groupBox1.Controls.Add(this.ngx_restart);
            this.groupBox1.Controls.Add(this.php_log);
            this.groupBox1.Controls.Add(this.mdb_log);
            this.groupBox1.Controls.Add(this.ngx_log);
            this.groupBox1.Controls.Add(this.php_cfg);
            this.groupBox1.Controls.Add(this.mdb_cfg);
            this.groupBox1.Controls.Add(this.ngx_config);
            this.groupBox1.Controls.Add(this.php_name);
            this.groupBox1.Controls.Add(this.mdb_name);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.ngx_name);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.mdb_stop);
            this.groupBox1.Controls.Add(this.mdb_start);
            this.groupBox1.Controls.Add(this.php_start);
            this.groupBox1.Controls.Add(this.php_stop);
            this.groupBox1.Controls.Add(this.ngx_start);
            this.groupBox1.Controls.Add(this.ngx_stop);
            this.groupBox1.Location = new System.Drawing.Point(12, 6);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox1.Size = new System.Drawing.Size(543, 162);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Applications";
            // 
            // php_check_box
            // 
            this.php_check_box.AutoSize = true;
            this.php_check_box.Checked = true;
            this.php_check_box.CheckState = System.Windows.Forms.CheckState.Checked;
            this.php_check_box.Location = new System.Drawing.Point(22, 127);
            this.php_check_box.Margin = new System.Windows.Forms.Padding(2);
            this.php_check_box.Name = "php_check_box";
            this.php_check_box.Size = new System.Drawing.Size(15, 14);
            this.php_check_box.TabIndex = 81;
            this.php_check_box.UseVisualStyleBackColor = true;
            // 
            // mdb_check_box
            // 
            this.mdb_check_box.AutoSize = true;
            this.mdb_check_box.Checked = true;
            this.mdb_check_box.CheckState = System.Windows.Forms.CheckState.Checked;
            this.mdb_check_box.Location = new System.Drawing.Point(22, 88);
            this.mdb_check_box.Margin = new System.Windows.Forms.Padding(2);
            this.mdb_check_box.Name = "mdb_check_box";
            this.mdb_check_box.Size = new System.Drawing.Size(15, 14);
            this.mdb_check_box.TabIndex = 80;
            this.mdb_check_box.UseVisualStyleBackColor = true;
            // 
            // ngx_check_box
            // 
            this.ngx_check_box.AutoSize = true;
            this.ngx_check_box.Checked = true;
            this.ngx_check_box.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ngx_check_box.Location = new System.Drawing.Point(22, 47);
            this.ngx_check_box.Margin = new System.Windows.Forms.Padding(2);
            this.ngx_check_box.Name = "ngx_check_box";
            this.ngx_check_box.Size = new System.Drawing.Size(15, 14);
            this.ngx_check_box.TabIndex = 79;
            this.ngx_check_box.UseVisualStyleBackColor = true;
            // 
            // php_restart
            // 
            this.php_restart.Location = new System.Drawing.Point(276, 122);
            this.php_restart.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.php_restart.Name = "php_restart";
            this.php_restart.Size = new System.Drawing.Size(50, 26);
            this.php_restart.TabIndex = 78;
            this.php_restart.Text = "Restart";
            this.php_restart.UseVisualStyleBackColor = true;
            this.php_restart.Click += new System.EventHandler(this.php_restart_Click);
            // 
            // mdb_restart
            // 
            this.mdb_restart.Location = new System.Drawing.Point(276, 82);
            this.mdb_restart.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.mdb_restart.Name = "mdb_restart";
            this.mdb_restart.Size = new System.Drawing.Size(50, 26);
            this.mdb_restart.TabIndex = 77;
            this.mdb_restart.Text = "Restart";
            this.mdb_restart.UseVisualStyleBackColor = true;
            this.mdb_restart.Click += new System.EventHandler(this.mdb_restart_Click);
            // 
            // ngx_restart
            // 
            this.ngx_restart.Location = new System.Drawing.Point(276, 42);
            this.ngx_restart.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.ngx_restart.Name = "ngx_restart";
            this.ngx_restart.Size = new System.Drawing.Size(50, 26);
            this.ngx_restart.TabIndex = 76;
            this.ngx_restart.Text = "Restart";
            this.ngx_restart.UseVisualStyleBackColor = true;
            this.ngx_restart.Click += new System.EventHandler(this.ngx_reload_Click);
            // 
            // php_log
            // 
            this.php_log.Location = new System.Drawing.Point(421, 122);
            this.php_log.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.php_log.Name = "php_log";
            this.php_log.Size = new System.Drawing.Size(50, 26);
            this.php_log.TabIndex = 75;
            this.php_log.Text = "Logs";
            this.php_log.UseVisualStyleBackColor = true;
            this.php_log.Click += new System.EventHandler(this.php_log_Click);
            // 
            // mdb_log
            // 
            this.mdb_log.Location = new System.Drawing.Point(421, 82);
            this.mdb_log.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.mdb_log.Name = "mdb_log";
            this.mdb_log.Size = new System.Drawing.Size(50, 26);
            this.mdb_log.TabIndex = 74;
            this.mdb_log.Text = "Logs";
            this.mdb_log.UseVisualStyleBackColor = true;
            this.mdb_log.Click += new System.EventHandler(this.mdb_log_Click);
            // 
            // ngx_log
            // 
            this.ngx_log.Location = new System.Drawing.Point(421, 42);
            this.ngx_log.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.ngx_log.Name = "ngx_log";
            this.ngx_log.Size = new System.Drawing.Size(50, 26);
            this.ngx_log.TabIndex = 73;
            this.ngx_log.Text = "Logs";
            this.ngx_log.UseVisualStyleBackColor = true;
            this.ngx_log.Click += new System.EventHandler(this.ngx_log_Click);
            // 
            // php_cfg
            // 
            this.php_cfg.Location = new System.Drawing.Point(332, 122);
            this.php_cfg.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.php_cfg.Name = "php_cfg";
            this.php_cfg.Size = new System.Drawing.Size(50, 26);
            this.php_cfg.TabIndex = 72;
            this.php_cfg.Text = "Config";
            this.php_cfg.UseVisualStyleBackColor = true;
            this.php_cfg.Click += new System.EventHandler(this.php_cfg_Click);
            // 
            // mdb_cfg
            // 
            this.mdb_cfg.Location = new System.Drawing.Point(332, 82);
            this.mdb_cfg.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.mdb_cfg.Name = "mdb_cfg";
            this.mdb_cfg.Size = new System.Drawing.Size(50, 26);
            this.mdb_cfg.TabIndex = 71;
            this.mdb_cfg.Text = "Config";
            this.mdb_cfg.UseVisualStyleBackColor = true;
            this.mdb_cfg.Click += new System.EventHandler(this.mdb_cfg_Click);
            // 
            // ngx_config
            // 
            this.ngx_config.Location = new System.Drawing.Point(332, 42);
            this.ngx_config.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.ngx_config.Name = "ngx_config";
            this.ngx_config.Size = new System.Drawing.Size(50, 26);
            this.ngx_config.TabIndex = 70;
            this.ngx_config.Text = "Config";
            this.ngx_config.UseVisualStyleBackColor = true;
            this.ngx_config.Click += new System.EventHandler(this.ngx_config_Click);
            // 
            // php_name
            // 
            this.php_name.AutoSize = true;
            this.php_name.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.php_name.Location = new System.Drawing.Point(76, 127);
            this.php_name.Name = "php_name";
            this.php_name.Size = new System.Drawing.Size(36, 16);
            this.php_name.TabIndex = 69;
            this.php_name.Text = "PHP";
            // 
            // mdb_name
            // 
            this.mdb_name.AutoSize = true;
            this.mdb_name.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mdb_name.Location = new System.Drawing.Point(76, 88);
            this.mdb_name.Name = "mdb_name";
            this.mdb_name.Size = new System.Drawing.Size(61, 16);
            this.mdb_name.TabIndex = 68;
            this.mdb_name.Text = "MariaDB";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(164, 22);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(50, 13);
            this.label6.TabIndex = 65;
            this.label6.Text = "Options";
            // 
            // ngx_name
            // 
            this.ngx_name.AutoSize = true;
            this.ngx_name.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ngx_name.ForeColor = System.Drawing.SystemColors.ControlText;
            this.ngx_name.Location = new System.Drawing.Point(76, 47);
            this.ngx_name.Name = "ngx_name";
            this.ngx_name.Size = new System.Drawing.Size(42, 16);
            this.ngx_name.TabIndex = 63;
            this.ngx_name.Text = "Nginx";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(76, 22);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(70, 13);
            this.label3.TabIndex = 62;
            this.label3.Text = "Application";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(6, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 13);
            this.label1.TabIndex = 60;
            this.label1.Text = "checked";
            // 
            // mdb_stop
            // 
            this.mdb_stop.Location = new System.Drawing.Point(220, 82);
            this.mdb_stop.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.mdb_stop.Name = "mdb_stop";
            this.mdb_stop.Size = new System.Drawing.Size(50, 26);
            this.mdb_stop.TabIndex = 57;
            this.mdb_stop.Text = "Stop";
            this.mdb_stop.UseVisualStyleBackColor = true;
            this.mdb_stop.Click += new System.EventHandler(this.mdb_stop_Click);
            // 
            // mdb_start
            // 
            this.mdb_start.Location = new System.Drawing.Point(164, 82);
            this.mdb_start.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.mdb_start.Name = "mdb_start";
            this.mdb_start.Size = new System.Drawing.Size(50, 26);
            this.mdb_start.TabIndex = 56;
            this.mdb_start.Text = "Start";
            this.mdb_start.UseVisualStyleBackColor = true;
            this.mdb_start.Click += new System.EventHandler(this.mdb_start_Click);
            // 
            // php_start
            // 
            this.php_start.Location = new System.Drawing.Point(164, 122);
            this.php_start.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.php_start.Name = "php_start";
            this.php_start.Size = new System.Drawing.Size(50, 26);
            this.php_start.TabIndex = 55;
            this.php_start.Text = "Start";
            this.php_start.UseVisualStyleBackColor = true;
            this.php_start.Click += new System.EventHandler(this.php_start_Click);
            // 
            // php_stop
            // 
            this.php_stop.Location = new System.Drawing.Point(220, 122);
            this.php_stop.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.php_stop.Name = "php_stop";
            this.php_stop.Size = new System.Drawing.Size(50, 26);
            this.php_stop.TabIndex = 54;
            this.php_stop.Text = "Stop";
            this.php_stop.UseVisualStyleBackColor = true;
            this.php_stop.Click += new System.EventHandler(this.php_stop_Click);
            // 
            // ngx_start
            // 
            this.ngx_start.ContextMenuStrip = this.nginx_menu;
            this.ngx_start.Location = new System.Drawing.Point(164, 42);
            this.ngx_start.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.ngx_start.Name = "ngx_start";
            this.ngx_start.Size = new System.Drawing.Size(50, 26);
            this.ngx_start.TabIndex = 53;
            this.ngx_start.Text = "Start";
            this.ngx_start.UseVisualStyleBackColor = true;
            this.ngx_start.Click += new System.EventHandler(this.ngx_start_Click);
            // 
            // ngx_stop
            // 
            this.ngx_stop.Location = new System.Drawing.Point(220, 42);
            this.ngx_stop.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.ngx_stop.Name = "ngx_stop";
            this.ngx_stop.Size = new System.Drawing.Size(50, 26);
            this.ngx_stop.TabIndex = 52;
            this.ngx_stop.Text = "Stop";
            this.ngx_stop.UseVisualStyleBackColor = true;
            this.ngx_stop.Click += new System.EventHandler(this.ngx_stop_Click);
            // 
            // mdb_shell
            // 
            this.mdb_shell.Location = new System.Drawing.Point(576, 86);
            this.mdb_shell.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.mdb_shell.Name = "mdb_shell";
            this.mdb_shell.Size = new System.Drawing.Size(63, 46);
            this.mdb_shell.TabIndex = 58;
            this.mdb_shell.Text = "Open MariaDB Shell";
            this.mdb_shell.UseVisualStyleBackColor = true;
            this.mdb_shell.Click += new System.EventHandler(this.mdb_shell_Click);
            // 
            // start_select
            // 
            this.start_select.Location = new System.Drawing.Point(576, 2);
            this.start_select.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.start_select.Name = "start_select";
            this.start_select.Size = new System.Drawing.Size(63, 34);
            this.start_select.TabIndex = 49;
            this.start_select.Text = "Start selected";
            this.start_select.UseVisualStyleBackColor = true;
            this.start_select.Click += new System.EventHandler(this.start_select_Click);
            // 
            // stop_select
            // 
            this.stop_select.Location = new System.Drawing.Point(576, 47);
            this.stop_select.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.stop_select.Name = "stop_select";
            this.stop_select.Size = new System.Drawing.Size(63, 34);
            this.stop_select.TabIndex = 50;
            this.stop_select.Text = "Stop selected";
            this.stop_select.UseVisualStyleBackColor = true;
            this.stop_select.Click += new System.EventHandler(this.stop_select_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.Controls.Add(this.wnmpdir);
            this.panel1.Controls.Add(this.log_rtb);
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Controls.Add(this.start_select);
            this.panel1.Controls.Add(this.stop_select);
            this.panel1.Controls.Add(this.mdb_shell);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 25);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(647, 309);
            this.panel1.TabIndex = 5;
            // 
            // wnmpdir
            // 
            this.wnmpdir.Location = new System.Drawing.Point(576, 137);
            this.wnmpdir.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.wnmpdir.Name = "wnmpdir";
            this.wnmpdir.Size = new System.Drawing.Size(63, 37);
            this.wnmpdir.TabIndex = 59;
            this.wnmpdir.Text = "Wnmp Directory";
            this.wnmpdir.UseVisualStyleBackColor = true;
            this.wnmpdir.Click += new System.EventHandler(this.wnmpdir_Click);
            // 
            // log_rtb
            // 
            this.log_rtb.BackColor = System.Drawing.Color.White;
            this.log_rtb.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.log_rtb.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.log_rtb.Location = new System.Drawing.Point(0, 186);
            this.log_rtb.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.log_rtb.Name = "log_rtb";
            this.log_rtb.ReadOnly = true;
            this.log_rtb.Size = new System.Drawing.Size(647, 123);
            this.log_rtb.TabIndex = 49;
            this.log_rtb.Text = "";
            // 
            // nginx_menu
            // 
            this.nginx_menu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.startToolStripMenuItem,
            this.stopToolStripMenuItem,
            this.restarToolStripMenuItem});
            this.nginx_menu.Name = "nginx_menu";
            this.nginx_menu.Size = new System.Drawing.Size(153, 92);
            // 
            // startToolStripMenuItem
            // 
            this.startToolStripMenuItem.Name = "startToolStripMenuItem";
            this.startToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.startToolStripMenuItem.Text = "Start";
            this.startToolStripMenuItem.Click += new System.EventHandler(this.startToolStripMenuItem_Click);
            // 
            // stopToolStripMenuItem
            // 
            this.stopToolStripMenuItem.Name = "stopToolStripMenuItem";
            this.stopToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.stopToolStripMenuItem.Text = "Stop";
            this.stopToolStripMenuItem.Click += new System.EventHandler(this.stopToolStripMenuItem_Click);
            // 
            // restarToolStripMenuItem
            // 
            this.restarToolStripMenuItem.Name = "restarToolStripMenuItem";
            this.restarToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.restarToolStripMenuItem.Text = "Restar";
            this.restarToolStripMenuItem.Click += new System.EventHandler(this.restarToolStripMenuItem_Click);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(647, 334);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.MainFormMenuStrip);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.MainFormMenuStrip;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MaximizeBox = false;
            this.MinimumSize = new System.Drawing.Size(662, 371);
            this.Name = "Main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Wnmp";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Main_FormClosing);
            this.Load += new System.EventHandler(this.Main_Load);
            this.Resize += new System.EventHandler(this.Main_Resize);
            this.MainFormMenuStrip.ResumeLayout(false);
            this.MainFormMenuStrip.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.nginx_menu.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip MainFormMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.Button mdb_shell;
        public System.Windows.Forms.Button mdb_stop;
        public System.Windows.Forms.Button php_start;
        public System.Windows.Forms.Button php_stop;
        public System.Windows.Forms.Button ngx_stop;
        public System.Windows.Forms.Button start_select;
        public System.Windows.Forms.Button stop_select;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button ngx_config;
        private System.Windows.Forms.Button php_cfg;
        private System.Windows.Forms.Button mdb_cfg;
        private System.Windows.Forms.ToolStripMenuItem wnmpOptionsToolStripMenuItem;
        private System.Windows.Forms.Button php_log;
        private System.Windows.Forms.Button mdb_log;
        private System.Windows.Forms.Button ngx_log;
        private System.Windows.Forms.Button wnmpdir;
        public System.Windows.Forms.RichTextBox log_rtb;
        protected System.Windows.Forms.Label ngx_name;
        protected System.Windows.Forms.Label php_name;
        protected System.Windows.Forms.Label mdb_name;
        public System.Windows.Forms.Button mdb_start;
        public System.Windows.Forms.Button ngx_start;
        public System.Windows.Forms.Button ngx_restart;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem donateToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem websiteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem checkForUpdatesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem supportToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem reportBugToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem localhostToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem hostToIPToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem getHTTPHeadersToolStripMenuItem;
        public System.Windows.Forms.Button php_restart;
        public System.Windows.Forms.Button mdb_restart;
        private System.Windows.Forms.CheckBox ngx_check_box;
        private System.Windows.Forms.CheckBox php_check_box;
        private System.Windows.Forms.CheckBox mdb_check_box;
        private System.Windows.Forms.ContextMenuStrip nginx_menu;
        private System.Windows.Forms.ToolStripMenuItem startToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem stopToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem restarToolStripMenuItem;
    }
}

