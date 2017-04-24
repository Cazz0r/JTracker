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

namespace EIC_Tracker
{
    public partial class Overlay : Form
    {
        
        [DllImport("gdi32.dll")]
        private static extern IntPtr AddFontMemResourceEx(IntPtr pbfont, uint cbfont, IntPtr pdv, [In] ref uint pcFonts);

        FontFamily ff;
        Font font;



       
        private void loadFont()
        {
            byte[] fontArray = EIC_Tracker.Properties.Resources.eurocaps;
            int dataLength = EIC_Tracker.Properties.Resources.eurocaps.Length;

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

        public Overlay()
        {
            InitializeComponent();
        }

        private void Overlay_Load(object sender, EventArgs e)
        {
            if (Properties.Settings.Default.OverlayTitleBar)
            {
                this.FormBorderStyle = FormBorderStyle.FixedDialog;
            }

            //Prevent the settings window being opened multiple times, set the global variable in frmMain to true.
            foreach (frmMain form1 in Application.OpenForms.OfType<frmMain>())
            {
                form1.frmOverlayOpen = true;
            }

            //Load EuroCaps.
            loadFont();
            foreach (Control c in this.Controls)
            {
                AllocFont(font, c, c.Font.Size, c.Font.Style);
            }


            if (Screen.AllScreens.Any(screen => screen.WorkingArea.IntersectsWith(Properties.Settings.Default.OverlayPosition)))
            {
                StartPosition = FormStartPosition.Manual;
                DesktopBounds = Properties.Settings.Default.OverlayPosition;
            }

            lblOverlay.Font = new Font(ff, (int)Properties.Settings.Default.OverlayTextSize);

            frmMain.OverlayMissions();
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void Overlay_FormClosing(object sender, FormClosingEventArgs e)
        {
            Properties.Settings.Default.OverlayPosition = DesktopBounds;
            Properties.Settings.Default.Save();

        }

        public void ChangeColor(Color color)
        {
            lblOverlay.ForeColor = color;
        }
    }
}
