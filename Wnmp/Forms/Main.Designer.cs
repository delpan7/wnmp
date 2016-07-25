/*
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
using System.Windows.Forms;

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
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            this.MainFormMenuStrip = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.wnmpOptionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.optionsFileStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.hostToIPToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.getHTTPHeadersToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.localhostToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rds_check_box = new System.Windows.Forms.CheckBox();
            this.rds_name = new System.Windows.Forms.Label();
            this.mem_check_box = new System.Windows.Forms.CheckBox();
            this.mem_name = new System.Windows.Forms.Label();
            this.ngx_check_box = new System.Windows.Forms.CheckBox();
            this.mdb_check_box = new System.Windows.Forms.CheckBox();
            this.mdb_name = new System.Windows.Forms.Label();
            this.ngx_name = new System.Windows.Forms.Label();
            this.mdb_shell = new System.Windows.Forms.Button();
            this.start_select = new System.Windows.Forms.Button();
            this.stop_select = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.wnmpdir = new System.Windows.Forms.Button();
            this.log_rtb = new System.Windows.Forms.RichTextBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.MainFormMenuStrip.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // MainFormMenuStrip
            // 
            this.MainFormMenuStrip.BackColor = System.Drawing.Color.Transparent;
            this.MainFormMenuStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.MainFormMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.toolsToolStripMenuItem,
            this.localhostToolStripMenuItem});
            this.MainFormMenuStrip.Location = new System.Drawing.Point(0, 0);
            this.MainFormMenuStrip.Name = "MainFormMenuStrip";
            this.MainFormMenuStrip.Size = new System.Drawing.Size(364, 25);
            this.MainFormMenuStrip.TabIndex = 4;
            this.MainFormMenuStrip.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.wnmpOptionsToolStripMenuItem,
            this.optionsFileStripMenuItem,
            this.toolStripSeparator1,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(39, 21);
            this.fileToolStripMenuItem.Text = "&File";
            // 
            // wnmpOptionsToolStripMenuItem
            // 
            this.wnmpOptionsToolStripMenuItem.Name = "wnmpOptionsToolStripMenuItem";
            this.wnmpOptionsToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.wnmpOptionsToolStripMenuItem.Text = "Wnmp配置";
            this.wnmpOptionsToolStripMenuItem.Click += new System.EventHandler(this.wnmpOptionsToolStripMenuItem_Click);
            // 
            // optionsFileStripMenuItem
            // 
            this.optionsFileStripMenuItem.Name = "optionsFileStripMenuItem";
            this.optionsFileStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.optionsFileStripMenuItem.Text = "打开配置文件";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(145, 6);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
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
            // localhostToolStripMenuItem
            // 
            this.localhostToolStripMenuItem.Name = "localhostToolStripMenuItem";
            this.localhostToolStripMenuItem.Size = new System.Drawing.Size(72, 21);
            this.localhostToolStripMenuItem.Text = "localhost";
            this.localhostToolStripMenuItem.Click += new System.EventHandler(this.localhostToolStripMenuItem_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rds_check_box);
            this.groupBox1.Controls.Add(this.rds_name);
            this.groupBox1.Controls.Add(this.mem_check_box);
            this.groupBox1.Controls.Add(this.mem_name);
            this.groupBox1.Controls.Add(this.ngx_check_box);
            this.groupBox1.Controls.Add(this.mdb_check_box);
            this.groupBox1.Controls.Add(this.mdb_name);
            this.groupBox1.Controls.Add(this.ngx_name);
            this.groupBox1.Controls.Add(this.panel2);
            this.groupBox1.Location = new System.Drawing.Point(76, 8);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox1.Size = new System.Drawing.Size(210, 104);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Applications";
            // 
            // rds_check_box
            // 
            this.rds_check_box.AutoSize = true;
            this.rds_check_box.Checked = true;
            this.rds_check_box.CheckState = System.Windows.Forms.CheckState.Checked;
            this.rds_check_box.Location = new System.Drawing.Point(100, 70);
            this.rds_check_box.Margin = new System.Windows.Forms.Padding(2);
            this.rds_check_box.Name = "rds_check_box";
            this.rds_check_box.Size = new System.Drawing.Size(15, 14);
            this.rds_check_box.TabIndex = 87;
            this.rds_check_box.UseVisualStyleBackColor = true;
            this.rds_check_box.CheckedChanged += new System.EventHandler(this.app_check_box_CheckedChanged);
            // 
            // rds_name
            // 
            this.rds_name.AutoSize = true;
            this.rds_name.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rds_name.Location = new System.Drawing.Point(119, 68);
            this.rds_name.Name = "rds_name";
            this.rds_name.Size = new System.Drawing.Size(44, 16);
            this.rds_name.TabIndex = 86;
            this.rds_name.Text = "Redis";
            this.rds_name.MouseUp += new System.Windows.Forms.MouseEventHandler(this.rds_name_MouseUp);
            // 
            // mem_check_box
            // 
            this.mem_check_box.AutoSize = true;
            this.mem_check_box.Checked = true;
            this.mem_check_box.CheckState = System.Windows.Forms.CheckState.Checked;
            this.mem_check_box.Location = new System.Drawing.Point(98, 37);
            this.mem_check_box.Margin = new System.Windows.Forms.Padding(2);
            this.mem_check_box.Name = "mem_check_box";
            this.mem_check_box.Size = new System.Drawing.Size(15, 14);
            this.mem_check_box.TabIndex = 84;
            this.mem_check_box.UseVisualStyleBackColor = true;
            this.mem_check_box.CheckedChanged += new System.EventHandler(this.app_check_box_CheckedChanged);
            // 
            // mem_name
            // 
            this.mem_name.AutoSize = true;
            this.mem_name.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mem_name.Location = new System.Drawing.Point(118, 35);
            this.mem_name.Name = "mem_name";
            this.mem_name.Size = new System.Drawing.Size(83, 16);
            this.mem_name.TabIndex = 83;
            this.mem_name.Text = "Memcached";
            this.mem_name.MouseUp += new System.Windows.Forms.MouseEventHandler(this.mem_name_MouseUp);
            // 
            // ngx_check_box
            // 
            this.ngx_check_box.AutoSize = true;
            this.ngx_check_box.Checked = true;
            this.ngx_check_box.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ngx_check_box.Location = new System.Drawing.Point(11, 38);
            this.ngx_check_box.Margin = new System.Windows.Forms.Padding(2);
            this.ngx_check_box.Name = "ngx_check_box";
            this.ngx_check_box.Size = new System.Drawing.Size(15, 14);
            this.ngx_check_box.TabIndex = 79;
            this.ngx_check_box.UseVisualStyleBackColor = true;
            this.ngx_check_box.CheckedChanged += new System.EventHandler(this.app_check_box_CheckedChanged);
            // 
            // mdb_check_box
            // 
            this.mdb_check_box.AutoSize = true;
            this.mdb_check_box.Location = new System.Drawing.Point(11, 71);
            this.mdb_check_box.Margin = new System.Windows.Forms.Padding(2);
            this.mdb_check_box.Name = "mdb_check_box";
            this.mdb_check_box.Size = new System.Drawing.Size(15, 14);
            this.mdb_check_box.TabIndex = 80;
            this.mdb_check_box.UseVisualStyleBackColor = true;
            this.mdb_check_box.CheckedChanged += new System.EventHandler(this.app_check_box_CheckedChanged);
            // 
            // mdb_name
            // 
            this.mdb_name.AutoSize = true;
            this.mdb_name.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mdb_name.Location = new System.Drawing.Point(32, 70);
            this.mdb_name.Name = "mdb_name";
            this.mdb_name.Size = new System.Drawing.Size(61, 16);
            this.mdb_name.TabIndex = 68;
            this.mdb_name.Text = "MariaDB";
            this.mdb_name.MouseUp += new System.Windows.Forms.MouseEventHandler(this.mdb_name_MouseUp);
            // 
            // ngx_name
            // 
            this.ngx_name.AutoSize = true;
            this.ngx_name.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ngx_name.ForeColor = System.Drawing.SystemColors.ControlText;
            this.ngx_name.Location = new System.Drawing.Point(32, 36);
            this.ngx_name.Name = "ngx_name";
            this.ngx_name.Size = new System.Drawing.Size(42, 16);
            this.ngx_name.TabIndex = 63;
            this.ngx_name.Text = "Nginx";
            this.ngx_name.MouseUp += new System.Windows.Forms.MouseEventHandler(this.ngx_name_MouseUp);
            // 
            // mdb_shell
            // 
            this.mdb_shell.Location = new System.Drawing.Point(292, 23);
            this.mdb_shell.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.mdb_shell.Name = "mdb_shell";
            this.mdb_shell.Size = new System.Drawing.Size(63, 37);
            this.mdb_shell.TabIndex = 58;
            this.mdb_shell.Text = "MariaDB Shell";
            this.mdb_shell.UseVisualStyleBackColor = true;
            this.mdb_shell.Click += new System.EventHandler(this.mdb_shell_Click);
            // 
            // start_select
            // 
            this.start_select.Location = new System.Drawing.Point(8, 24);
            this.start_select.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.start_select.Name = "start_select";
            this.start_select.Size = new System.Drawing.Size(63, 34);
            this.start_select.TabIndex = 49;
            this.start_select.Text = "启动所选";
            this.start_select.UseVisualStyleBackColor = true;
            this.start_select.Click += new System.EventHandler(this.start_select_Click);
            // 
            // stop_select
            // 
            this.stop_select.Location = new System.Drawing.Point(8, 64);
            this.stop_select.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.stop_select.Name = "stop_select";
            this.stop_select.Size = new System.Drawing.Size(63, 34);
            this.stop_select.TabIndex = 50;
            this.stop_select.Text = "停止所选";
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
            this.panel1.Size = new System.Drawing.Size(364, 266);
            this.panel1.TabIndex = 5;
            // 
            // wnmpdir
            // 
            this.wnmpdir.Location = new System.Drawing.Point(292, 67);
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
            this.log_rtb.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.log_rtb.Location = new System.Drawing.Point(0, 124);
            this.log_rtb.Margin = new System.Windows.Forms.Padding(0);
            this.log_rtb.Name = "log_rtb";
            this.log_rtb.ReadOnly = true;
            this.log_rtb.Size = new System.Drawing.Size(360, 150);
            this.log_rtb.TabIndex = 49;
            this.log_rtb.Text = "";
            // 
            // panel2
            // 
            this.panel2.Location = new System.Drawing.Point(1, 28);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(92, 30);
            this.panel2.TabIndex = 88;
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(364, 291);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.MainFormMenuStrip);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.MainFormMenuStrip;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MaximizeBox = false;
            this.MinimumSize = new System.Drawing.Size(380, 330);
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
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip MainFormMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        public System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Panel panel1;
        public System.Windows.Forms.Button mdb_shell;
        public System.Windows.Forms.Button start_select;
        public System.Windows.Forms.Button stop_select;
        private System.Windows.Forms.ToolStripMenuItem wnmpOptionsToolStripMenuItem;
        private System.Windows.Forms.Button wnmpdir;
        public System.Windows.Forms.RichTextBox log_rtb;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem localhostToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem hostToIPToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem getHTTPHeadersToolStripMenuItem;
        public System.Windows.Forms.CheckBox ngx_check_box;
        public System.Windows.Forms.CheckBox mdb_check_box;
        public System.Windows.Forms.CheckBox rds_check_box;
        public System.Windows.Forms.CheckBox mem_check_box;
        public System.Windows.Forms.ToolStripMenuItem optionsFileStripMenuItem;
        public System.Windows.Forms.Label ngx_name;
        public System.Windows.Forms.Label mdb_name;
        public System.Windows.Forms.Label mem_name;
        public System.Windows.Forms.Label rds_name;
        private Panel panel2;
    }
}

