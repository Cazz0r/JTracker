namespace EIC_Tracker
{
    partial class frmSettings
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSettings));
            this.btnSettingsSave = new System.Windows.Forms.Button();
            this.chkStartup = new System.Windows.Forms.CheckBox();
            this.chkAutoCommodity = new System.Windows.Forms.CheckBox();
            this.chkMinimized = new System.Windows.Forms.CheckBox();
            this.chkTaskbar = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblAlarmFriendly = new System.Windows.Forms.Label();
            this.lblAlarmUnknown = new System.Windows.Forms.Label();
            this.lblAlarmHostile = new System.Windows.Forms.Label();
            this.chkIFFAlarms = new System.Windows.Forms.CheckBox();
            this.chkIFFAuto = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtIFF = new System.Windows.Forms.TextBox();
            this.chkIFFBalloon = new System.Windows.Forms.CheckBox();
            this.chkSilentUpdating = new System.Windows.Forms.CheckBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.numOverlay = new System.Windows.Forms.NumericUpDown();
            this.chkOverlayColor = new System.Windows.Forms.CheckBox();
            this.chkOverlayTitleBar = new System.Windows.Forms.CheckBox();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numOverlay)).BeginInit();
            this.SuspendLayout();
            // 
            // btnSettingsSave
            // 
            this.btnSettingsSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSettingsSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSettingsSave.ForeColor = System.Drawing.Color.White;
            this.btnSettingsSave.Location = new System.Drawing.Point(12, 360);
            this.btnSettingsSave.Name = "btnSettingsSave";
            this.btnSettingsSave.Size = new System.Drawing.Size(255, 35);
            this.btnSettingsSave.TabIndex = 0;
            this.btnSettingsSave.Text = "Save && Close";
            this.btnSettingsSave.UseVisualStyleBackColor = true;
            this.btnSettingsSave.Click += new System.EventHandler(this.btnSettingsSave_Click);
            // 
            // chkStartup
            // 
            this.chkStartup.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkStartup.ForeColor = System.Drawing.Color.White;
            this.chkStartup.Location = new System.Drawing.Point(10, 5);
            this.chkStartup.Name = "chkStartup";
            this.chkStartup.Size = new System.Drawing.Size(270, 25);
            this.chkStartup.TabIndex = 1;
            this.chkStartup.Text = "Start with Windows";
            this.chkStartup.UseVisualStyleBackColor = true;
            // 
            // chkAutoCommodity
            // 
            this.chkAutoCommodity.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkAutoCommodity.ForeColor = System.Drawing.Color.White;
            this.chkAutoCommodity.Location = new System.Drawing.Point(10, 45);
            this.chkAutoCommodity.Name = "chkAutoCommodity";
            this.chkAutoCommodity.Size = new System.Drawing.Size(270, 40);
            this.chkAutoCommodity.TabIndex = 2;
            this.chkAutoCommodity.Text = "Automatically Search For Commodity on Mission Accept";
            this.chkAutoCommodity.UseVisualStyleBackColor = true;
            // 
            // chkMinimized
            // 
            this.chkMinimized.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkMinimized.ForeColor = System.Drawing.Color.White;
            this.chkMinimized.Location = new System.Drawing.Point(10, 25);
            this.chkMinimized.Name = "chkMinimized";
            this.chkMinimized.Size = new System.Drawing.Size(270, 25);
            this.chkMinimized.TabIndex = 3;
            this.chkMinimized.Text = "Start JTracker Minimized";
            this.chkMinimized.UseVisualStyleBackColor = true;
            // 
            // chkTaskbar
            // 
            this.chkTaskbar.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkTaskbar.ForeColor = System.Drawing.Color.White;
            this.chkTaskbar.Location = new System.Drawing.Point(10, 85);
            this.chkTaskbar.Name = "chkTaskbar";
            this.chkTaskbar.Size = new System.Drawing.Size(270, 25);
            this.chkTaskbar.TabIndex = 4;
            this.chkTaskbar.Text = "Minimize to Taskbar instead of Tray";
            this.chkTaskbar.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lblAlarmFriendly);
            this.groupBox1.Controls.Add(this.lblAlarmUnknown);
            this.groupBox1.Controls.Add(this.lblAlarmHostile);
            this.groupBox1.Controls.Add(this.chkIFFAlarms);
            this.groupBox1.Controls.Add(this.chkIFFAuto);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.txtIFF);
            this.groupBox1.Controls.Add(this.chkIFFBalloon);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.ForeColor = System.Drawing.SystemColors.Control;
            this.groupBox1.Location = new System.Drawing.Point(1, 127);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(282, 130);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "IFF";
            // 
            // lblAlarmFriendly
            // 
            this.lblAlarmFriendly.AutoSize = true;
            this.lblAlarmFriendly.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblAlarmFriendly.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAlarmFriendly.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.lblAlarmFriendly.Location = new System.Drawing.Point(200, 105);
            this.lblAlarmFriendly.Name = "lblAlarmFriendly";
            this.lblAlarmFriendly.Size = new System.Drawing.Size(58, 17);
            this.lblAlarmFriendly.TabIndex = 12;
            this.lblAlarmFriendly.Text = "Friendly";
            this.lblAlarmFriendly.Click += new System.EventHandler(this.lblAlarmFriendly_Click);
            // 
            // lblAlarmUnknown
            // 
            this.lblAlarmUnknown.AutoSize = true;
            this.lblAlarmUnknown.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblAlarmUnknown.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAlarmUnknown.ForeColor = System.Drawing.Color.Gray;
            this.lblAlarmUnknown.Location = new System.Drawing.Point(111, 105);
            this.lblAlarmUnknown.Name = "lblAlarmUnknown";
            this.lblAlarmUnknown.Size = new System.Drawing.Size(66, 17);
            this.lblAlarmUnknown.TabIndex = 11;
            this.lblAlarmUnknown.Text = "Unknown";
            this.lblAlarmUnknown.Click += new System.EventHandler(this.lblAlarmUnknown_Click);
            // 
            // lblAlarmHostile
            // 
            this.lblAlarmHostile.AutoSize = true;
            this.lblAlarmHostile.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblAlarmHostile.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAlarmHostile.ForeColor = System.Drawing.Color.Red;
            this.lblAlarmHostile.Location = new System.Drawing.Point(33, 105);
            this.lblAlarmHostile.Name = "lblAlarmHostile";
            this.lblAlarmHostile.Size = new System.Drawing.Size(51, 17);
            this.lblAlarmHostile.TabIndex = 10;
            this.lblAlarmHostile.Text = "Hostile";
            this.lblAlarmHostile.Click += new System.EventHandler(this.lblAlarmHostile_Click);
            // 
            // chkIFFAlarms
            // 
            this.chkIFFAlarms.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkIFFAlarms.ForeColor = System.Drawing.Color.White;
            this.chkIFFAlarms.Location = new System.Drawing.Point(9, 85);
            this.chkIFFAlarms.Name = "chkIFFAlarms";
            this.chkIFFAlarms.Size = new System.Drawing.Size(254, 20);
            this.chkIFFAlarms.TabIndex = 9;
            this.chkIFFAlarms.Text = "Play Custom Sounds for IFF Results:";
            this.chkIFFAlarms.UseVisualStyleBackColor = true;
            // 
            // chkIFFAuto
            // 
            this.chkIFFAuto.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkIFFAuto.ForeColor = System.Drawing.Color.White;
            this.chkIFFAuto.Location = new System.Drawing.Point(9, 15);
            this.chkIFFAuto.Name = "chkIFFAuto";
            this.chkIFFAuto.Size = new System.Drawing.Size(254, 20);
            this.chkIFFAuto.TabIndex = 8;
            this.chkIFFAuto.Text = "Perform automatic IFF searches";
            this.chkIFFAuto.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(9, 60);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(157, 17);
            this.label1.TabIndex = 7;
            this.label1.Text = "Direct Chat Code Word:";
            // 
            // txtIFF
            // 
            this.txtIFF.Location = new System.Drawing.Point(176, 57);
            this.txtIFF.Name = "txtIFF";
            this.txtIFF.Size = new System.Drawing.Size(96, 23);
            this.txtIFF.TabIndex = 6;
            // 
            // chkIFFBalloon
            // 
            this.chkIFFBalloon.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkIFFBalloon.ForeColor = System.Drawing.Color.White;
            this.chkIFFBalloon.Location = new System.Drawing.Point(9, 35);
            this.chkIFFBalloon.Name = "chkIFFBalloon";
            this.chkIFFBalloon.Size = new System.Drawing.Size(254, 20);
            this.chkIFFBalloon.TabIndex = 5;
            this.chkIFFBalloon.Text = "Display IFF results in notification";
            this.chkIFFBalloon.UseVisualStyleBackColor = true;
            // 
            // chkSilentUpdating
            // 
            this.chkSilentUpdating.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkSilentUpdating.ForeColor = System.Drawing.Color.White;
            this.chkSilentUpdating.Location = new System.Drawing.Point(10, 105);
            this.chkSilentUpdating.Name = "chkSilentUpdating";
            this.chkSilentUpdating.Size = new System.Drawing.Size(270, 25);
            this.chkSilentUpdating.TabIndex = 6;
            this.chkSilentUpdating.Text = "Update without Prompting";
            this.chkSilentUpdating.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.numOverlay);
            this.groupBox2.Controls.Add(this.chkOverlayColor);
            this.groupBox2.Controls.Add(this.chkOverlayTitleBar);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.ForeColor = System.Drawing.Color.White;
            this.groupBox2.Location = new System.Drawing.Point(1, 260);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(282, 92);
            this.groupBox2.TabIndex = 7;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Overlay";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(9, 66);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(124, 17);
            this.label2.TabIndex = 9;
            this.label2.Text = "Overlay Font Size:";
            // 
            // numOverlay
            // 
            this.numOverlay.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numOverlay.Location = new System.Drawing.Point(135, 64);
            this.numOverlay.Name = "numOverlay";
            this.numOverlay.Size = new System.Drawing.Size(43, 23);
            this.numOverlay.TabIndex = 2;
            // 
            // chkOverlayColor
            // 
            this.chkOverlayColor.AutoSize = true;
            this.chkOverlayColor.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkOverlayColor.Location = new System.Drawing.Point(9, 42);
            this.chkOverlayColor.Name = "chkOverlayColor";
            this.chkOverlayColor.Size = new System.Drawing.Size(177, 21);
            this.chkOverlayColor.TabIndex = 1;
            this.chkOverlayColor.Text = "Overwrite Overlay Color";
            this.chkOverlayColor.UseVisualStyleBackColor = true;
            // 
            // chkOverlayTitleBar
            // 
            this.chkOverlayTitleBar.AutoSize = true;
            this.chkOverlayTitleBar.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkOverlayTitleBar.Location = new System.Drawing.Point(9, 19);
            this.chkOverlayTitleBar.Name = "chkOverlayTitleBar";
            this.chkOverlayTitleBar.Size = new System.Drawing.Size(175, 21);
            this.chkOverlayTitleBar.TabIndex = 0;
            this.chkOverlayTitleBar.Text = "Show Overlay Drag Bar";
            this.chkOverlayTitleBar.UseVisualStyleBackColor = true;
            // 
            // frmSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(284, 396);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.chkSilentUpdating);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.chkTaskbar);
            this.Controls.Add(this.chkMinimized);
            this.Controls.Add(this.chkAutoCommodity);
            this.Controls.Add(this.chkStartup);
            this.Controls.Add(this.btnSettingsSave);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmSettings";
            this.Text = "Settings";
            this.TopMost = true;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmSettings_FormClosing);
            this.Load += new System.EventHandler(this.frmSettings_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numOverlay)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnSettingsSave;
        private System.Windows.Forms.CheckBox chkStartup;
        private System.Windows.Forms.CheckBox chkAutoCommodity;
        private System.Windows.Forms.CheckBox chkMinimized;
        private System.Windows.Forms.CheckBox chkTaskbar;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox chkIFFBalloon;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtIFF;
        private System.Windows.Forms.CheckBox chkIFFAuto;
        private System.Windows.Forms.CheckBox chkSilentUpdating;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.CheckBox chkOverlayColor;
        private System.Windows.Forms.CheckBox chkOverlayTitleBar;
        private System.Windows.Forms.ColorDialog colorDialog1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown numOverlay;
        private System.Windows.Forms.CheckBox chkIFFAlarms;
        private System.Windows.Forms.Label lblAlarmHostile;
        private System.Windows.Forms.Label lblAlarmFriendly;
        private System.Windows.Forms.Label lblAlarmUnknown;
    }
}