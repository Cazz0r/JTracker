using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Win32;

using System.Runtime.InteropServices;
using System.Drawing.Text;

using System.Media; //To play sound files.

namespace EIC_Tracker
{
    
    
    public partial class frmSettings : Form
    {

        [DllImport("gdi32.dll")]
        private static extern IntPtr AddFontMemResourceEx(IntPtr pbfont, uint cbfont, IntPtr pdv, [In] ref uint pcFonts);

        FontFamily ff;
        Font font;

        private void loadFont()
        {
            byte[] fontArray = EIC_Tracker.Properties.Resources.Sintony;
            int dataLength = EIC_Tracker.Properties.Resources.Sintony.Length;

            IntPtr ptrData = Marshal.AllocCoTaskMem(dataLength);

            Marshal.Copy(fontArray, 0, ptrData, dataLength);

            uint cFonts = 0;

            AddFontMemResourceEx(ptrData, (uint)fontArray.Length, IntPtr.Zero, ref cFonts);

            PrivateFontCollection pfc = new PrivateFontCollection();

            pfc.AddMemoryFont(ptrData, dataLength);

            Marshal.FreeCoTaskMem(ptrData);

            ff = pfc.Families[0];
            font = new Font(ff, 15f, FontStyle.Regular);
        }
        private void AllocFont(Font f, Control c, float size, FontStyle style)
        {
            c.Font = new Font(ff, size, style);
        }



        public frmSettings()
        {
            InitializeComponent();
        }

        private void btnSettingsSave_Click(object sender, EventArgs e)
        {
            this.Close();  
        }

        

        private void frmSettings_Load(object sender, EventArgs e)
        {
            //Prevent the settings window being opened multiple times, set the global variable in frmMain to true.
            foreach (frmMain form1 in Application.OpenForms.OfType<frmMain>())
            {
                form1.frmSettingsOpen = true;
            }

            //Load Sintony.
            loadFont();
            foreach (Control c in this.Controls)
            {
                AllocFont(font, c, c.Font.Size, c.Font.Style);
            }
            foreach(Control c in groupBox1.Controls)
            {
                AllocFont(font, c, c.Font.Size, c.Font.Style);
            }
            foreach (Control c in groupBox2.Controls)
            {
                AllocFont(font, c, c.Font.Size, c.Font.Style);
            }

            chkAutoCommodity.Checked = Properties.Settings.Default.AutoCommodity;
            chkStartup.Checked = Properties.Settings.Default.StartUp;
            chkMinimized.Checked = Properties.Settings.Default.StartMinimized;
            chkTaskbar.Checked = Properties.Settings.Default.TaskBar;
            chkSilentUpdating.Checked = Properties.Settings.Default.SilentUpdates;

            //IFF section.
            chkIFFAuto.Checked = Properties.Settings.Default.IFFAuto;
            chkIFFBalloon.Checked = Properties.Settings.Default.IFFBalloon;
            txtIFF.Text = Properties.Settings.Default.IFFText;
            chkIFFAlarms.Checked = Properties.Settings.Default.IFFAlarms;

            //Overlay Section
            chkOverlayTitleBar.Checked = Properties.Settings.Default.OverlayTitleBar;
            if (Properties.Settings.Default.OverlayTextColor != Color.White)
            {
                //Turn off the function that launches the colour picker.
                chkOverlayColor.Checked = true;
            }
            numOverlay.Value = Properties.Settings.Default.OverlayTextSize;

            //Register the event handlers.
            this.chkAutoCommodity.CheckedChanged += new System.EventHandler(this.chkAutoCommodity_CheckedChanged);
            this.chkStartup.CheckedChanged += new System.EventHandler(this.chkStartup_CheckedChanged);
            this.chkMinimized.CheckedChanged += new System.EventHandler(this.chkMinimized_CheckedChanged);
            this.chkTaskbar.CheckedChanged += new System.EventHandler(this.chkTaskbar_CheckedChanged);
            this.chkSilentUpdating.CheckedChanged += new System.EventHandler(this.chkSilentUpdating_CheckedChanged);

            this.chkIFFAuto.CheckedChanged += new System.EventHandler(this.chkIFFAuto_CheckedChanged);
            this.chkIFFBalloon.CheckedChanged += new System.EventHandler(this.chkIFFBalloon_CheckedChanged);
            this.chkIFFAlarms.CheckedChanged += new System.EventHandler(this.chkIFFAlarms_CheckedChanged);
            

            this.chkOverlayTitleBar.CheckedChanged += new System.EventHandler(this.chkOverlayTitleBar_CheckedChanged);
            this.chkOverlayColor.CheckedChanged += new System.EventHandler(this.chkOverlayColor_CheckedChanged);
            this.numOverlay.ValueChanged += new System.EventHandler(this.numOverlay_ValueChanged);
        }

        private void frmSettings_FormClosing(object sender, FormClosingEventArgs e)
        {
            Properties.Settings.Default.IFFText = txtIFF.Text;
            Properties.Settings.Default.OverlayTextSize = (int)numOverlay.Value;
            Properties.Settings.Default.Save();
            foreach (frmMain form1 in Application.OpenForms.OfType<frmMain>())
            {
                form1.frmSettingsOpen = false;
            }
        }

        private void chkAutoCommodity_CheckedChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.AutoCommodity = chkAutoCommodity.Checked;
            if (chkAutoCommodity.Checked)
            {
                foreach (frmMain form1 in Application.OpenForms.OfType<frmMain>())
                {
                    //form1.btnCommodityVisible = false;
                }
            }
            else
            {
                foreach (frmMain form1 in Application.OpenForms.OfType<frmMain>())
                {
                    //form1.btnCommodityVisible = true;
                }
            }
        }


        private void chkStartup_CheckedChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.StartUp = chkStartup.Checked;
            try
            {
                if (chkStartup.Checked)
                {
                    using (RegistryKey key = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true))
                    {
                        key.SetValue("EIC Journal Tracker", "\"" + Application.ExecutablePath + "\"");
                    }
                }
                else
                {
                    using (RegistryKey key = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true))
                    {
                        key.DeleteValue("EIC Journal Tracker", false);
                    }
                }
            }
            catch (Exception ex)  //just for demonstration...it's always best to handle specific exceptions
            {
                MessageBox.Show("Unable to update registry for 'Start with Windows'. Possibly due to not having sufficient permissions/anti-virus blocking the registry change." + Environment.NewLine + "Exception: " + ex.Message);
            }
        }

        private void chkMinimized_CheckedChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.StartMinimized = chkMinimized.Checked;
        }

        private void chkTaskbar_CheckedChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.TaskBar = chkTaskbar.Checked;
        }

        private void chkIFFAuto_CheckedChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.IFFAuto = chkIFFAuto.Checked;
        }

        private void chkIFFBalloon_CheckedChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.IFFBalloon = chkIFFBalloon.Checked;
        }

        private void chkIFFAlarms_CheckedChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.IFFAlarms = chkIFFAlarms.Checked;
        }

        private void chkSilentUpdating_CheckedChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.SilentUpdates = chkSilentUpdating.Checked;
        }

        private void chkOverlayColor_CheckedChanged(object sender, EventArgs e)
        {


            if (chkOverlayColor.Checked) //We've checked the option, pick a color.
            {
                if (colorDialog1.ShowDialog() == DialogResult.OK)
                {
                    if (colorDialog1.Color == Color.Black || colorDialog1.Color == Color.White) 
                        //Don't allow the user to pick black. That'll go transparent due to transparency key, same code if they select white.
                    {
                        chkOverlayColor.Checked = false;
                        Properties.Settings.Default.OverlayTextColor = Color.White;
                        Properties.Settings.Default.Save();
                    }
                    else
                    {
                        Properties.Settings.Default.OverlayTextColor = colorDialog1.Color;
                        Properties.Settings.Default.Save();
                    }
                }
            }
            else
            {
                //They unchecked it, revert to default.
                Properties.Settings.Default.OverlayTextColor = Color.White;
                Properties.Settings.Default.Save();
            }

            for (int index = Application.OpenForms.Count - 1; index >= 0; index--)
            {
                if (Application.OpenForms[index].Name == "Overlay")
                {

                    Form frm = Application.OpenForms[index]; //   
                    var controls = frm.Controls.Find("lblOverlay", true);
                    if (controls != null)
                    {
                        foreach (var control in controls)
                        { 
                            control.ForeColor = Properties.Settings.Default.OverlayTextColor;
                        }
                    }
                }
            }

                
        }

        private void chkOverlayTitleBar_CheckedChanged(object sender, EventArgs e)
        {

            Properties.Settings.Default.OverlayTitleBar = chkOverlayTitleBar.Checked;
            Properties.Settings.Default.Save();

            for (int index = Application.OpenForms.Count - 1; index >= 0; index--)
            {
                if (Application.OpenForms[index].Name == "Overlay")
                {
                    if (chkOverlayTitleBar.Checked)
                    {
                        Application.OpenForms[index].FormBorderStyle = FormBorderStyle.FixedDialog;
                    }else
                    {
                        Application.OpenForms[index].FormBorderStyle = FormBorderStyle.None;

                        //Save it's position.
                        
                        Properties.Settings.Default.OverlayPosition = Application.OpenForms[index].DesktopBounds;
                        Properties.Settings.Default.Save();
                    }
                }
            }

        }

        private void numOverlay_ValueChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.OverlayTextSize = (int)numOverlay.Value;
            Properties.Settings.Default.Save();

            for (int index = Application.OpenForms.Count - 1; index >= 0; index--)
            {
                if (Application.OpenForms[index].Name == "Overlay")
                {

                    Form frm = Application.OpenForms[index]; //   
                    var controls = frm.Controls.Find("lblOverlay", true);
                    if (controls != null)
                    {
                        foreach (var control in controls)
                        {
                            control.Font = new Font(ff, Properties.Settings.Default.OverlayTextSize);
                            control.AutoSize = true;
                        }
                    }
                }
            }
        }

        private void lblAlarmHostile_Click(object sender, EventArgs e)
        {
            SoundPlayer audio = new SoundPlayer(Properties.Resources.hostile);
            audio.Play();
        }

        private void lblAlarmUnknown_Click(object sender, EventArgs e)
        {
            SoundPlayer audio = new SoundPlayer(Properties.Resources.unknown);
            audio.Play();
        }

        private void lblAlarmFriendly_Click(object sender, EventArgs e)
        {
            SoundPlayer audio = new SoundPlayer(Properties.Resources.friendly);
            audio.Play();
        }
    }
}
