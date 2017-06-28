/*
Change Log
0.1c:
- Changed all Int32 to Int64, there's every chance that an exploration data dump, with bonuses, could exceed the limits of Int32, so scrapped them altogether.

0.1d:
- Forgot to turn off the debugging features in 0.1c

0.1e:
- Added Goods Pawned & Crime/Fines to the Stations table. Added a case for CommitCrime, as well as MarketSell section for Stolen goods.

0.1f: 
- Abandoning missions now -1 from pending destination correctly.
- Discoveries stored in a dataset and a button will show them all into the webbrowser control.
- Ignore small crimes.
- Decreased refresh time from 10 seconds to 5 seconds, cause everybody loves being fresh.

0.2:
- Versioning will no longer use letters so that numerical functions can be used on the version number itself.
- Added TrackData function to push data through to the tracker. Added another webbrowser control to facilitate this, it sits in the bottom part of the debug section.
- Welcome screen will be passed the version number to be responsive to different versions and advise that an update is required for old versions.
- Minimize to system tray. We could actually do bubbles to let the user know that things have been tracked....
- If minimized mode sees a game mode change, bubble to the user, hopefully the bubble allows the user to remember which mode they're in.
- Fix to mission redirect, mission will no longer stay as a pending destination for the original destination.

0.21:
- "Dumping" crimes now tracked as a crime. Potentially useful for Operations (dump onionhead at erevate, although we may need to invisibly track the crime type for this to not be gamed).

0.22:
- CommitCrime can issue a "Fine" or a "Bounty" if you already have a Bounty in that system. One of which will always be 0, so now adding them together in all CommitCrime situations.

0.23:
- Wrapped the Json decode in a try-catch because Fdev can't get the syntax right the first time. Which also means, some events will be ignored until the syntax is corrected.
- Added a custom system "LOGERROR", any data sent to the tracker with this system name will log into the bad_json database for later processing (ie, bug reporting).

1.0.24:
- Never get lost again, the JTracker now records the Star Position, so even if the System isn't in the tracker, it will defer to the current star position for distance calculations.
- Tracking Data for systems not in the tracker will create the system in the tracker (now) WITH star position. Resulting in more location data available for eventual use in Travelling Salesman API, after the system is in the tracker EDDN data will be collected for said system.
- Prepared for mass distribution with ClickOnce publishing. Had to go to version 1.0.24 (had to add the 1 at the front for this).

1.0.25:
- Added a settings form for some new settings:
    - "Start With Windows" setting. Pretty descriptive label I think, starts the application with windows. Default: false.
    - "Start JTracker Minimized". Starts the application in the system tray. Default: false.
    - "Automatically Search For Commodity on Mission Accept". Toggles whether or not a commodity is automatically searched for when a mission to collect them is accepted. Default: true.

1.0.26:
- Added new voucher type: settlement

1.0.27:
- Check if the journal folder exists and message if it does not and exit the application.
- Change of desktop/start menu icon, let's hope it's up to Splodey standards :stuck_out_tongue_winking_eye: 
- When silent json errors occur log CMDR name and journal file name so that the journal file can be requested and the error investigated.

1.0.28:
- Fixed sightseeing missions

1.0.29:
- Fix to prevent multiple instances running. Check if another instance is already running, message and close if so.

1.0.30:
- Found that users weren't getting updates (they were leaving the application running 24/7 and never restarted it to receive the update), so have added a new version check everytime the journal entry of "FileHeader" is detected, which is essentially everytime the game creates a new journal (every launch) and when the app is launched it reads the last journal.

1.0.31 & 1.0.32:
- Cazz screwed up and left a button turned on that shouldn't be.

1.0.33:
- When missions are accepted without a destination system, assume it's the current system that's the destination.

1.0.34:
- Message queue system for rapid-action events not cancelling one another out.
- On attempted closing, will check for pending missions (and warn the user) and pending tracked data (and not allow the close and suggest minimizing to tray).

1.0.35:
- Added claim type: scannable

1.0.36:
- Fixed an issue with the update restart and the program close check conflicting.

1.0.37:
- Test to make sure live deployment updates are working.

1.0.38:
- Message queue system rewrite, no longer works on a timer, but on request completion events.
- First message into the queue begins the processing of the queue, once a message is completed, remove it from the queue and attempt to process another.
- The cycle of processing stops when there is no more messages in the queue, and starts anew once a new event is tracked.
- The end result of this is faster message queue processing, and more accurate processing on slower connections that the timer was too fast for.
- Also facilitates for server over-load, previously while on a timer the JTracker would keep firing connections, whereas now on document complete events it will slow down to compensate.

1.0.39: 
- New variable to hold the control faction in the system/station in preparation of the Tracker recording activity per system per faction.
- TrackData now includes the faction. Certain actions (BH/CZ turn-in) don't yet have Faction data unfortunately, it needs to be added to the journal. This should add factions to the tracker for a bigger picture of all factions in our bubble eventually.
- FSDJump / Docked events now update the System/Station Control faction in the Tracker. (Will mostly just verify EDDN data, but if the user isn't running an EDDN connector, it will be the sole source).
- Fixed a bug where the system name (and now faction name) weren't escaped causing special characters to cause mayham. Added the inverse of this replace function to the tracker receive page.

1.0.40:
- Turn's out the FSDJump event can have no SystemFaction record. Fix for this put in place, simply checking if it's null before trying to update the control faction.

1.0.41:
- Added an extra field for tracking. It's main purpose is to pass through the station for Updating it's control faction.
(Delayed update so that I'm not spamming these poor folks.)

1.0.42:
- Hopefully fixed the fileheader error that I've been receiving occasionally. Changed the CompletedIn "Allow DB Null" to false, so that it doesn't get string cast failures.

1.0.43:
- Added the version to the log error event so that I can make sure the errors I'm receiving aren't already fixed.

1.0.44: 
- Done something I should have done from the beginning, include the version in every event sent to the tracker.
- Added claim type: trade (wing trade credits)

1.0.45:
- Added the misc voucher claim type actually sending to the tracker, not simply being ignored. It doesn't show in JTracker (yet) though.

1.0.46:
- Left something uncommented! Fixed it.

1.0.47:
- Forgot to change the version, derp.

1.0.48:
- Added "Minimize to Taskbar instead of Tray" by request of Killian O'Malley. (Default: False)

1.0.49:
- Pressing F3 now shows all the tracked missions. Useful for debugging. Mostly for myself.

1.0.50:
- Pressing F4 now attempts to update the program. Useful for debugging. Mostly for myself.

1.0.51:
- Track mission completed reward.
- Track total value of marketbuy and marketsell events.

1.0.52:
- Accidently pushed the debug version.

1.0.53:
A situation occured where Decessuss' JTracker asked to be updated, but he didn't see until the end of his gaming session, therefore it tracked nothing.
To resolve this, I'm attempting to bring JTracker to the front as well as displaying the notice balloon. This should prompt the user to update.
- When an update is detected it will now minimize/restore the window to bring it to front.
- When an update is detected it will show a notifyicon balloon stating to please update.

1.0.54:
Issue with the "Start with Windows". It created a registry key to the absolute path of where the JTracker is installed, unforunately when installing/updating to the new version it creates a new directory, so we need to update the start up path.
Issue with application settings (such as "Start with windows") not being persistant during upgrades, have resolved this, by attempting a settings upgrade after a fresh version is installed, and at the same time updating the registry path for start with windows.

1.0.55:
- Pushed a debug version doh!

1.0.56:
- IFF Released!

1.0.57: 
- Pushed a damn debug version again....

1.0.58:
- Supress script error on main window.
- Check wb.IsBusy before issueing new navigate commands. wb2 should be fine as it's all queued based on document complete.

1.0.59:
- Make sure the IFF search doesn't pickup "To":"Local" when sending messages in local chat.

1.0.60:
- Display "Notes exist" in the balloon notifcation for IFF where notes do, in fact, exist.

1.0.61:
- Fixed a typo "Notes Exit".
- Created a BTC Address for donations: 1FWxeRwDEgT5Juz81MWzv2qek3QJyUkXj5
- Created a donorbox campaign for donations: https://donorbox.org/jtracker-software-appreciation

1.0.62:
- Font change to EUROCAPS!
- Added tabs with permissions!

1.0.63:
- Wrapped registry changes in a try/catch. Found that BitDefender didn't like the registry update.

1.0.64:
- Embeded the eurocaps font as a resource, as well as all other images.
- On form load it changes all control fonts to use eurocaps.
- We might get issues for the font... let's see!

1.0.65:
- Attempt to fix the application.restart by releasing the mutex pre-restart.

1.0.66:
- TrackData now passes back "LatestVersion", if this doesn't match the version within JTracker it attempts an update check.
- Another way to keep the application up to date ;)
- New mandatory version. No more should be required after this.

1.0.67:
- Accidently pushed a debug version

1.0.68:
- Stopped script errors on all wb controls. Allowed the BGS tab for all CMDRs, but still checking the permissions of the CMDR first in case we want to move back to that.

1.0.69:
- Made sure that the IFF notification balloon has an icon. Hopefully resolves it not showing at all.
- No longer searching for "wing" when the IFF code word is sent to wing chat.
- Increased the font size of the rows in the dataGrid of the main tab.
- Added a "Please Wait, Loading..." to the main web browser, which will hide it everytime its loading.
- Adjusted the height of the systems datagrid and the main browser controls. Added the table-condensed style to all tables in the main browser.

1.0.70:
- Now tracking the mission destination system/faction independantly of the system the mission was accepted in. This should hopefully us to better see the gains for the destination system/faction.
- Added a tooltip for use with various controls.
- Can now click the version for an update check.

1.0.71: (2017-02-08 1630 AEDST)
- Clicking the system name in the tracking table will now copy the system into the clipboard.
- Added additional short-hand versions of commodities (some commodities are listed up to 4 times now, just different spelling).
- "Silent Updating". Default: False.
- Saving WindowPosition on close so that it re-opens in the same spot. Shouldn't effect minimized.

1.0.75: (2017-02-13 0910 AEDST)
- Checking the registry key each start up now, this should hopefully resolve the issue with old keys not getting updated. Or at least let the user know about it.

1.0.77: (2017-02-14 1630 AEDST)
- If a mission isn't present for a missioncomplete event, check historical files, starting with the most recent and working back up to 4 weeks.
- Usually a missionaccept would be present in a log or two prior to the mission complete event.
- This allows tracking of missions without having to keep the JTracker running between E:D sessions.
- Also. Made sure that the window resize happens after the restore window state. This will ensure that debugging section is hidden every start up.

1.0.78: (2017-02-15 915 AEDST)
- Attempted fix where only the title bar would appear.
- F2 now resizes height as well, so pressing F2 should resolve.
- Restoring from the tray now forces the width/height to regular (if debug mode is required pressing F2 again is needed).

1.0.79: I pushed a debug version again :(

1.0.80: Added a debug textbox to show application execution path.

1.0.81: Made sure to not check the current journal file when finding mission accept locations (already in use error).

1.0.82: Added "Always on Top" option.

1.0.83: (2017-02-21 930 AEDST)
- Minimizing toggles the "Always on Top" option off.
- Loading into the game after selecting the mode no longer re-navigates to the BGS Dashboard.
- Clicking the BGS tab button reloads the BGS Dashboard.

1.0.84: (2017-02-22 1330 AEDST)
- Attempt to fix the "Bar" of JTracker, looks to be asscioated with the Minimize to Taskbar instead of tray option. Instead of using the "current" height, it now sets it on start up.
- Also changed the notifyIcon click event - instead of .show() it now uses .bringtofront() before setting the width/height.

1.0.85: (Future Release for Game Version 2.3 + Beta)
- IFF now reports the group's relation with EIC.
- If Automatic IFF is on, it will now fire for the "Escape Interdiction" event, as well as the regular "Interdicted" event. So this now covers, escape, submit and failure. Previously didn't cover escaping.
- Overlay for massacre missions. You can change the position, text size and text color, and toggle it on/off very easily from the main window. (Overlay might be used for additional mission types in future).
- Redeeming bounty vouchers now reports the faction to the tracker, no longer will BGS Nerds have to face the "Undefined" faction!
- Missions now report their type and effect on system influence (previously all missions were considered "medium" effect and no type was reported).
- If in a private group, show the name of the group in the "Game Mode:" section.
- Approaching a settlement in a system of interest will insert the settlement into the tracker if it isn't already there.
- Make sure the fileheader gameversion does not contain "beta", if it does, pause any tracking.

1.0.86:
- Fixed Massacre mission tracking, beta journal has "KillCount" not "TargetCount" as per documentation. GG Fdev. Also allowed for skimmer massacring rather than just "Ships".
- Adjusted header labels to have shipname, shipid, ship type.
- Fixed PVPKill event - the combatrank of the victim wasn't cast as an integer causing errors.
- Fixed the overlay mission table's primary key so that failing/abandoning can use the key to find the mission.
- Added mission type "Assassinate"
- Added contextual IFF alarm sounds + option to turn them on/off. This is based of the IFF status of EIC's status with the found player group which may not represent the player itself.

1.0.87: 
- Fixed an issue with code I had pre-written for Beta Release 3.

1.0.88: 
- Show which journal file is for the beta in the message that says tracking is disabled.
- Fixed the journal back-check from flagging the tracker as beta mode.

1.0.89:
- Form size now adjustable. Width is locked at the present time, however, adjusting the height of the main window also makes the BGS tab + Commodity/IFF result larger.
- The height that the user changes the JTracker to should be remembered for next time and minimizing/restoring from taskbar/tray.

1.0.90:
- Did not anticipate users creating other files in the journal directory, have added a filter for journal files only (Journal.*.log)

1.0.91:
- Fixed PVPkill event (again). Looks like previous fix didn't do the job.
- Change font from Euro Caps to Sintony (along with some sizing/positioning changes, feedback on this would be appreciated).
- Recording "bounty" event - occurs when you destroy a ship, this is so that we can monitor how much "Murderhobo" occurs against each faction within a system.
- Added influence tracking on Location (Game Load) and FSDJump events. It's about damn time Fdev.

1.0.92: "Earyn" (unreleased)
- Created a "Clear Systems List" button which will effectively reset the datagrid of the JTracker. Was requested many moons ago by Earyn.
- Turns out there are stations out there that have no control faction.  Romanek's Folly in Morgor. Check for a StationFaction before attempting to update it.

1.0.93: 
- Treating donation (not credit donation though) missions as a collect mission. So the commodity to donate should be automatically selected in the commodity listing (and searched for if enabled).

1.0.94: "Power Play"
- Added tracking on the FSDJump event to track which powers and their state on in each system. This information is not available in any other source.

1.0.95: 
- Added Sales tab. Turned off via permissions until the page its displaying is finished.

1.0.96: 
- Created a function to create the commodity listing rather than simply having list items in design view.
- Re-exported the list of commodities that have been tracked so that they can be added into JTracker. An increasing amount were not being found. In total 27 additional commodities are now listed.
- Adjusted the height/width and font size of the commodity dropdown box.

1.0.97:
- Changed how the influence data for systems is passed through to the tracker, it's altogether now and not seperate factions. Make's it 1 request per system instead of 1 per faction per system.
- 2.3 Go-Live Version. *fingers crossed*

1.0.98: (12:00 2017-04-12)
- Game Version 2.3 Released!
- Passing the system faction through with influence values, changed the track type from "influence" to "influencefull"

1.0.99: (09:45 2017-04-18)
- Added System Security to Influence tracking, the old "System" update is now only performed if Faction information isn't present, so this is now the fallback, reducing the amount of information pushed to the tracker.
- Forcing ship name + id in uppercase. Now also accurately changes when in-game changes are performed.
- Added JTracker version to the commodity & iff search queries.

1.1.00: 
- I dungoofed the security update, fixed.

1.1.01:
- See what happens when you rush? You only fix half the problem.

1.1.02:
- "View Discoveries", "Clear Systems List" buttons relocated.
- Flying: "Ship Name" ["Ship ID"] OR "Ship Type" (Unnamed). Hiding the ship type when a name is given. Hiding the ship ID when no name is given.

1.1.03:
- Added faction information for the "RedeemVoucher" event. Specifically Bounty Vouchers supporting  multiple factions, as well as Combat Bonds (however, I'm not sure if the journal even logs the faction for combat bonds though).

1.1.04: 
- Added 2 new tabs: Hero & Help. Help is under construction at the time of release.
- Reworked how the "tabs" operate, re-clicking each button will reload the relevant tab.
- If auto IFF is selected, when joining a crew it will IFF the captain of the crew.

1.1.05:
- Attempted fix of the BGS button not being shown.

1.1.06:
- Made sure that FindMissionAccept looked at the current journal file just incase we restart the JTracker *this* session.
- Made some alterations to the F3 "Display Missions" output, it's a little prettier now and more sane.

1.1.07:
- Fixed the FindMissionAccept error when it was re-opening the current file. It now plays nicely.

1.1.08:
- Accidently released 1.1.07 as a debug version, I am noob.

1.1.09: TRUDER
- Fixed yet another issue with the BGS button not show. Prevented all the buttons from being hidden, ever.

1.1.10: 
- Forgot to increment the version number. Working too fast... 

1.1.11:
- Added "Narcotics"

1.1.12:
- Looks like FDEV Changed the RedeemVoucher event "Factions" to "Faction". Fixed the event so that the benefiting faction is passed.

NEW Ideas:
- Splodey had the idea to record "Career Statistics". How many of x good you've brought/sold. How many missions in x system. How many of x types of passengers you've escorted. etc. May cross-over a bit with in-game statistics.
- Tracking a series of events for operations. IE. Interdiction on Player, Cargo Abandoned, then (optional) Player Kill, then SupercruiseEntry / FSDJump. Tally 1 for Operation: Christmas, can later apply system filtering to exclude random PVP.

Credits:
EIC Administrators (Initial concept and testing):
- Aluminum
- Cazz0r
- JaceLansing
- LastHeroAlive
- LiquidCatnip
- Prax Bloodwaters (+++)
- Quawis
- Sainare
- Sinsecato (+++)
- Splodey Dope (+++)
- Ubernostrom (+)
- Voggix (+++)
- WizardZombie

EIC BGS Nerds:
- Apis_Levitans
- DuhstBunny
- Eayrn (+++)
- Killian Oh'Malley (+)
- NeoTron
- PumknNutz (+++)
- SCSkunk
- Swift Arrow (+++)
- Zero_Prime
*/
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;

using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using System.IO;
using System.Runtime.InteropServices;
using System.Net;
using System.Deployment.Application;
using System.Text.RegularExpressions;
using Microsoft.Win32;

using System.Drawing.Text;

using Newtonsoft.Json;

using System.Media; //To play sound files.

namespace EIC_Tracker
{
    public partial class frmMain : Form
    {

        public static class Globals
        {
            //Journal Dir should find where the journals are being stored, hard coded for testing.
            public static String journalDir = "";// Environment.ExpandEnvironmentVariables("%USERPROFILE%\\Saved Games\\Frontier Developments\\Elite Dangerous");

            //Store the current file in a variable name
            public static String journalFile = "";

            //Variable to determine if we're tracking the journal or not.
            public static bool journalTracking = true;

            //How often file changes are detected in ms. Be nice to give an option for the user to specify this.
            public static int tickRate = 10000;

            //A variable to remember the current position in the journal file.
            public static long seekpos = 0;

            //A variable to remember the commander
            public static string cmdr = "";

            //A variable to remember the current star system, x, y, z, control faction
            public static string cursystem = "";
            public static double cursystemx = 0;
            public static double cursystemy = 0;
            public static double cursystemz = 0;
            public static string cursystemfaction = "";

            //A variable to remember the current station & faction
            public static string curstation = "";
            public static string curstationfaction = "";
            public static string curship = "";
            public static string curshipname = "[UNNAMED]";
            public static string curshipident = "NO ID";

            //A variable to record the game mode.
            public static string curmode = "";
            public static string curgroup = "";

            //A variable for the version.
            public static string version = "1.1.12"; //Version Number

            //Variable for the program open time.
            public static DateTime curtime = DateTime.UtcNow;

            //Variable to remember if other forms are open or closed.
            public static bool frmSettingsOpen = false;
            public static bool frmOverlayOpen = false;
        }

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


        public frmMain()
        {
            this.KeyPreview = true;
            this.KeyDown += new KeyEventHandler(Form1_KeyDown);
            InitializeComponent();
        }

        private void ImportStatusForm_Resize(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized)
            {

                //1.0.48: Added a toggle to show the taskbar when minimized.
                if (Properties.Settings.Default.TaskBar == false) //Not showing in Taskbar, make sure the notify icon is shown.
                {
                    this.ShowInTaskbar = false;
                    notifyIcon.Visible = true;
                    if (notifyIcon.BalloonTipText != "")
                    {
                        notifyIcon.BalloonTipIcon = ToolTipIcon.Info;
                        notifyIcon.BalloonTipTitle = "Tray Mode";
                        notifyIcon.BalloonTipText = "JTracker is still running in the background";
                        notifyIcon.ShowBalloonTip(3000);
                    }
                }
                else
                {
                    //Really do nothing because it's a regular minimize.                    
                }

                //Untick "Always on Top"
                chkAlwaysTop.Checked = false;
                this.TopMost = false;
            }else
            { //Restoring or changing the forms width/height.

                int height = lblDonate.Location.Y - tabControl.Location.Y;
                tabControl.SizeMode = TabSizeMode.Normal;
                tabControl.Size = new Size(tabControl.Size.Width, height);
                tabMain.Size = new Size(tabMain.Size.Width, height);

                height = tabMain.Size.Height - panel1.Location.Y;
                panel1.Size = new Size(panel1.Size.Width, height);

                height = panel1.Size.Height - wb.Location.Y;
                wb.Size = new Size(wb.Size.Width, height);

                int location = (wb.Size.Height / 2) + wb.Location.Y - 20;
                lblwbLoading.Location = new Point(1, location);

                location = (wbBGS.Size.Height / 2) + wbBGS.Location.Y - 20;
                lblBGS.Location = new Point(1, location);

                //tabControl.SizeMode = TabSizeMode.Fixed;
#if DEBUG
                DisplayHtml("Form Height:" + this.Size.Height + 
                    "<br>Form Width: " + this.Size.Width +
                    
                    //"<br>tabControl Height: " + tabControl.Size.Height +
                    //"<br>tabControl Width: " + tabControl.Size.Width +
                    //"<br>tabMain Height: " + tabMain.Size.Height +
                    //"<br>tabMain Width: " + tabMain.Size.Width +
                    
                    "<br>browser Height: " + wb.Size.Height +
                    "<br>browser Location: " + wb.Location.Y +
                    //"<br>panel Height: " + panel1.Size.Height +
                    //"<br>panel Width: " + panel1.Size.Width
                    "<br>Loader Location: " + lblwbLoading.Location.Y
                    , "1");
#endif
            }
        }

        private void notifyIcon_MouseDoubleClick(object sender, MouseEventArgs e) //Single click event comes here too.
        {
            
            this.WindowState = FormWindowState.Normal;

            this.BringToFront();

            //this.Size = this.MinimumSize;
            this.ShowInTaskbar = true;
            notifyIcon.Visible = false;
            //this.BringToFront();
        }

        public bool btnCommodityVisible
        {
            get { return btnCommodity.Visible; }
            set { btnCommodity.Visible = value; }
        }

        public bool frmSettingsOpen
        {
            get { return Globals.frmSettingsOpen; }
            set { Globals.frmSettingsOpen = value; }
        }

        public bool frmOverlayOpen
        {
            get { return Globals.frmOverlayOpen; }
            set { Globals.frmOverlayOpen = value; }
        }

        private static string appGuid = "EIC JTracker";
        private static Mutex mutex;

        Mutex mymutex;

        private void frmMain_Load(object sender, EventArgs e)
        {
            
#if DEBUG
            //Nothing!
#else
            bool mutexCreated;
            mymutex = new Mutex(true, "Global\\" + appGuid, out mutexCreated);
            if (mutexCreated)
                mymutex.ReleaseMutex();

            if (!mutexCreated)
            {
                //App is already running, close this!
                MessageBox.Show("JTracker is already running!");
                Application.Exit(); //i used this because its a console app
            }
#endif

            //Load Sintony.
            loadFont();

            foreach (Control c in this.Controls)
            {
                AllocFont(font, c, c.Font.Size, c.Font.Style);
            }
            foreach (Control c in tabMain.Controls)
            {
                AllocFont(font, c, c.Font.Size, c.Font.Style);
            }
            foreach(Control c in tabBGS.Controls)
            {
                AllocFont(font, c, c.Font.Size, c.Font.Style);
            }
            lblwbLoading.Font = new Font(ff, lblwbLoading.Font.Size, lblwbLoading.Font.Style);
            dataGridView1.ColumnHeadersDefaultCellStyle.Font = new Font(ff, dataGridView1.DefaultCellStyle.Font.Size, dataGridView1.DefaultCellStyle.Font.Style);
            dataGridView1.RowsDefaultCellStyle.Font = new Font(ff, 10, dataGridView1.DefaultCellStyle.Font.Style);
            cmbCommodity.Font = new Font(ff, 11);
            dataGridView1.Columns[0].Name = "System Name";

            /*
            foreach (Control c in this.Controls)
            {
                //Assign it to all controls.
                c.Font = new Font(ff, c.Font.Size, c.Font.Style);

            }
            */
            //Make sure the donate button is directly next to the donate text.
            btnDonate.Location = new Point(lblDonate.Location.X + lblDonate.Width + 2, btnDonate.Location.Y);


            

            //Make sure we're on the default tab.
            tabControl.SelectedTab = tabMain;

            //Ensure the tabs aren't showing.
            /*
            tabControl.Appearance = TabAppearance.FlatButtons;
            tabControl.ItemSize = new Size(0, 1);
            tabControl.SizeMode = TabSizeMode.Fixed;

            tabControl.Appearance = TabAppearance.Buttons;
            tabControl.ItemSize = new Size(20, 20);
            tabControl.SizeMode = TabSizeMode.Normal;
            */

            //Make sure the buttons that require permissions aren't showing.
            btnBGS.Visible = true;
            btnSales.Visible = true;
            btnHero.Visible = true;


            //Settings weren't being saved when upgrading versions, found some code that describes a good way to handle this: http://stackoverflow.com/questions/534261/how-do-you-keep-user-config-settings-across-different-assembly-versions-in-net/534335#534335
            if (Properties.Settings.Default.SettingsUpdateRequired)
            {
                Properties.Settings.Default.Upgrade();
                Properties.Settings.Default.SettingsUpdateRequired = false;
                Properties.Settings.Default.Save();

                
            }

#if DEBUG
        
#else
            //Check if we've elected to start with windows and make sure the key is correct, post-update this is crucial, otherwise the old version will continue starting on start up.
            if (Properties.Settings.Default.StartUp) //Yep, we're starting with windows.
            {
                try
                {
                    using (RegistryKey key = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true))
                    {
                        if (key != null)
                        {
                            object o = key.GetValue("EIC Journal Tracker");
                            if (o != null)
                            {
                                if(o.ToString() != "\"" + Application.ExecutablePath + "\"")
                                {
                                    //Registry key is incorrect, update it.
                                    key.SetValue("EIC Journal Tracker", "\"" + Application.ExecutablePath + "\"");
                                }
                            }else
                            {
                                //Registry key doesn't exist, create it.
                                key.SetValue("EIC Journal Tracker", "\"" + Application.ExecutablePath + "\"");
                            }
                        }
                    }
                }
                catch (Exception ex)  //just for demonstration...it's always best to handle specific exceptions
                {
                    MessageBox.Show("Unable to update registry for 'Start with Windows'. Possibly due to not having sufficient permissions/anti-virus blocking the registry change." + Environment.NewLine + "It is suggested to try toggle the setting." + Environment.NewLine + "Exception: " + ex.Message);
                }
            }
#endif



            //Get the journal directory
            Globals.journalDir = GetDefaultJournalDir();
            if (Globals.journalDir == "")
            {
                Application.Exit();                      
            } else {

                //Find the latest file.
                GetFile();

                //Directory & Latest file name gets put into the bar for debugging.
                txtDir.Text = Globals.journalDir;
                txtFile.Text = Globals.journalFile;
                txtPath.Text = Application.ExecutablePath;
                lblVersion.Text = "Version " + Globals.version;

                if (Properties.Settings.Default.AutoCommodity)
                {
                    //btnCommodity.Visible = false;
                }
                else
                {
                    //btnCommodity.Visible = true;
                }

                wb.Navigate("http://eicgaming.com/tracker/welcome.php?CMDR=" + Globals.cmdr + "&Version=" + Globals.version);
                wb2.Navigate("about:blank");


                if (Screen.AllScreens.Any(screen => screen.WorkingArea.IntersectsWith(Properties.Settings.Default.WindowPosition)))
                {
                    StartPosition = FormStartPosition.Manual;
                    DesktopBounds = Properties.Settings.Default.WindowPosition;
                    
                }

                if (Properties.Settings.Default.StartMinimized)
                {
                    notifyIcon.BalloonTipText = "";
                    this.WindowState = FormWindowState.Minimized;
                }

#if DEBUG
                Control control = (Control)sender;
                control.Size = new Size(953, 515);
                control.MinimumSize = new Size(953, 515);
                control.MaximumSize = new Size(953, 4000);
                btnDiscoveries.Visible = true;

#else
                Control control = (Control)sender;
                control.Size = new Size(732, 515);
                control.MinimumSize = new Size(732, 515);
                control.MaximumSize = new Size(732, 4000);
                btnDiscoveries.Visible = false;
#endif

                if (Properties.Settings.Default.WindowHeight > 515)
                {
                    control.Size = new Size(this.Size.Width, Properties.Settings.Default.WindowHeight);
                }

                //DataGrid settings
                //dataGridView1.AutoGenerateColumns = true;
                //dataGridView1.DataSource = dataSystems;
                //dataGridView1.DataMember = "StarSystems";

                //var tbl = dataSystems.Tables["StarSystems"];
                //tbl.PrimaryKey = new DataColumn[] { tbl.Columns["SystemName"] };

                //Kick off the processing of the current journal.
                //ProcessJournal();

                timer1.Enabled = true;

                //Anybody behind a proxy might suffer because of this, so I certainly hope they aren't.
                wb.ScriptErrorsSuppressed = true;
                wb2.ScriptErrorsSuppressed = true;
                wbBGS.ScriptErrorsSuppressed = true;

                //Fill the commodities box.
                ListCommodities();
            }
        }

        public class JEvent
        {
            [JsonProperty(PropertyName = "event")]
            public string eventtype { get; set; }

            [JsonProperty(PropertyName = "StarSystem")]
            public string StarSystem { get; set; }

            [JsonProperty(PropertyName = "StarPos")]
            public dynamic StarPos { get; set; }

            [JsonProperty(PropertyName = "StationName")]
            public string StationName { get; set; }

            [JsonProperty(PropertyName = "Body")]
            public string Body { get; set; }

            [JsonProperty(PropertyName = "Faction")]
            public string Faction { get; set; }

            [JsonProperty(PropertyName = "StationFaction")]
            public string StationFaction { get; set; }

            [JsonProperty(PropertyName = "SystemFaction")]
            public string SystemFaction { get; set; }

            [JsonProperty(PropertyName = "MissionID")]
            public string MissionID { get; set; }

            [JsonProperty(PropertyName = "DestinationSystem")]
            public string DestinationSystem { get; set; }

            [JsonProperty(PropertyName = "DestinationStation")]
            public string DestinationStation { get; set; }

            [JsonProperty(PropertyName = "Commander")]
            public string Commander { get; set; }

            [JsonProperty(PropertyName = "GameMode")]
            public string GameMode { get; set; }

            [JsonProperty(PropertyName = "Docked")]
            public string Docked { get; set; }

            [JsonProperty(PropertyName = "Count")]
            public long Count { get; set; }

            [JsonProperty(PropertyName = "Commodity")]
            public string Commodity { get; set; }

            [JsonProperty(PropertyName = "Commodity_Localised")]
            public string Commodity_Localised { get; set; }

            [JsonProperty(PropertyName = "Name")]
            public string Name { get; set; }

            [JsonProperty(PropertyName = "Type")]
            public string Type { get; set; }

            [JsonProperty(PropertyName = "Amount")]
            public double Amount { get; set; }

            [JsonProperty(PropertyName = "TotalCost")]
            public string TotalCost { get; set; }

            [JsonProperty(PropertyName = "TotalSale")]
            public string TotalSale { get; set; }

            [JsonProperty(PropertyName = "timestamp")]
            public DateTime timestamp { get; set; }

            [JsonProperty(PropertyName = "Systems")]
            public dynamic Systems { get; set; }

            [JsonProperty(PropertyName = "Discovered")]
            public dynamic Discovered { get; set; }

            [JsonProperty(PropertyName = "Factions")]
            public dynamic Factions { get; set; }

            [JsonProperty(PropertyName = "BaseValue")]
            public long BaseValue { get; set; }

            [JsonProperty(PropertyName = "Bonus")]
            public long Bonus { get; set; }

            [JsonProperty(PropertyName = "StolenGoods")]
            public string StolenGoods { get; set; }

            [JsonProperty(PropertyName = "Stolen")]
            public string Stolen { get; set; }

            [JsonProperty(PropertyName = "BlackMarket")]
            public string BlackMarket { get; set; }

            [JsonProperty(PropertyName = "CrimeType")]
            public string CrimeType { get; set; }

            [JsonProperty(PropertyName = "Fine")]
            public string Fine { get; set; }

            [JsonProperty(PropertyName = "Bounty")]
            public string Bounty { get; set; }

            [JsonProperty(PropertyName = "Reward")]
            public string Reward { get; set; }

            [JsonProperty(PropertyName = "IsPlayer")]
            public Boolean IsPlayer { get; set; }

            [JsonProperty(PropertyName = "Interdicted")]
            public string Interdicted { get; set; }

            [JsonProperty(PropertyName = "Interdictor")]
            public string Interdictor { get; set; }

            [JsonProperty(PropertyName = "Channel")]
            public string Channel { get; set; }

            [JsonProperty(PropertyName = "From_Localised")]
            public string From_Localised { get; set; }

            [JsonProperty(PropertyName = "To_Localised")]
            public string To_Localised { get; set; }

            [JsonProperty(PropertyName = "To")]
            public string To { get; set; }

            [JsonProperty(PropertyName = "Message")]
            public string Message { get; set; }

            [JsonProperty(PropertyName = "TargetFaction")]
            public string TargetFaction { get; set; }

            [JsonProperty(PropertyName = "TargetCount")]
            public int TargetCount { get; set; }

            [JsonProperty(PropertyName = "KillCount")]
            public int KillCount { get; set; }

            [JsonProperty(PropertyName = "AwardingFaction")]
            public string AwardingFaction { get; set; }

            [JsonProperty(PropertyName = "VictimFaction")]
            public string VictimFaction { get; set; }

            [JsonProperty(PropertyName = "Target")]
            public string Target { get; set; }

            [JsonProperty(PropertyName = "TotalReward")]
            public int TotalReward { get; set; }

            [JsonProperty(PropertyName = "Influence")]
            public string Influence { get; set; }

            [JsonProperty(PropertyName = "Reputation")]
            public string Reputation { get; set; }

            [JsonProperty(PropertyName = "Ship")]
            public string Ship { get; set; }

            [JsonProperty(PropertyName = "ShipName")]
            public string ShipName { get; set; }

            [JsonProperty(PropertyName = "ShipIdent")]
            public string ShipIdent { get; set; }

            [JsonProperty(PropertyName = "UserShipName")]
            public string UserShipName { get; set; }

            [JsonProperty(PropertyName = "UserShipId")]
            public string UserShipId { get; set; }

            [JsonProperty(PropertyName = "Group")]
            public string Group { get; set; }

            [JsonProperty(PropertyName = "gameversion")]
            public string gameversion { get; set; }

            [JsonProperty(PropertyName = "FactionState")]
            public string FactionState { get; set; }

            [JsonProperty(PropertyName = "Powers")]
            public dynamic Powers { get; set; }

            [JsonProperty(PropertyName = "PowerplayState")]
            public string PowerplayState { get; set; }

            [JsonProperty(PropertyName = "SystemSecurity")]
            public string SystemSecurity { get; set; }

            //Multicrew stuff
            [JsonProperty(PropertyName = "Captain")]
            public string Captain { get; set; }

            
            //PVP Kill Properties
            [JsonProperty(PropertyName = "Victim")]
            public string Victim { get; set; }

            [JsonProperty(PropertyName = "CombatRank")]
            public int CombatRank { get; set; }

            
            //IFF Properties.
            [JsonProperty(PropertyName = "Search")]
            public string Search { get; set; }

            [JsonProperty(PropertyName = "Result")]
            public string Result { get; set; }

            [JsonProperty(PropertyName = "Error")]
            public string Error { get; set; }

            [JsonProperty(PropertyName = "Players")]
            public dynamic Players { get; set; }

            

            //Permissions
            [JsonProperty(PropertyName = "BGS")]
            public bool BGS { get; set; }
            [JsonProperty(PropertyName = "Sales")]
            public bool Sales { get; set; }

        }

        public void UpdateSystem(string StarSystem, dynamic starx, dynamic stary, dynamic starz, string Faction)
        {
            Globals.cursystem = StarSystem;
            Globals.cursystemx = Convert.ToDouble(starx);
            Globals.cursystemy = Convert.ToDouble(stary);
            Globals.cursystemz = Convert.ToDouble(starz);
            Globals.cursystemfaction = Faction;
            SetLocation();
        }
        public void UpdateStation(string Station, string Faction)
        {
            Globals.curstation = Station;
            Globals.curstationfaction = Faction;
            SetLocation();
        }
        public void SetLocation()
        {
#if DEBUG
            lblCmdrSystemStation.Text = Globals.cmdr + " in " + Globals.cursystem; // + " [" + Globals.cursystemx + ", " + Globals.cursystemy + ", " + Globals.cursystemz + "]";
#else
            lblCmdrSystemStation.Text = Globals.cmdr + " in " + Globals.cursystem;
#endif
            if (Globals.curstation != "")
            {
                lblCmdrSystemStation.Text = lblCmdrSystemStation.Text + " @ " + Globals.curstation;
            }
        }

        public void ClearSystems()
        {

        }
        public void UpdateHeaderLabels()
        {
            if(Globals.curshipname != "[UNNAMED]")
            {
                lblShip.Text = "Flying: " + Globals.curshipname.ToUpper() + " [" + Globals.curshipident.ToUpper() + "]";
            }else
            {
                lblShip.Text = "Flying: " + Globals.curship + " (Unnamed)";
            }
            
            lblShip.Location = new Point(lblMode.Location.X + lblMode.Size.Width + 2, lblMode.Location.Y);
        }

        private void DisplayHtml(string html, string which = "2")
        {
            if (which == "2")
            {
                wb2.Navigate("about:blank");
                if (wb2.Document != null)
                {
                    wb2.Document.Write(string.Empty);
                }
                wb2.DocumentText = html;
            }else if(which == "1")
            {
                if (wb.IsBusy)
                {
                    wb.Stop();
                }
                wb.Navigate("about:blank");
                if (wb.Document != null)
                {
                    wb.Document.Write(string.Empty);
                }
                wb.DocumentText = html;
            }
        }

        void webBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            //This document complete event actually handles several complex things.
            lblwbLoading.Visible = false;
            wb.Visible = true;

            //Check for the IFF result element.
            HtmlElement iffresult = wb.Document.GetElementById("IFFResult");
            if (iffresult != null) //If it finds the form, it's logging an error.
            {
                var result = iffresult.InnerHtml;
                dynamic iff = JsonConvert.DeserializeObject<JEvent>(result);


                var icon = notifyIcon.Visible;
                if (Properties.Settings.Default.IFFBalloon == true)
                {
                    
                    if (!icon) notifyIcon.Visible = true;

                }

                var Text = "";
                switch ((string)iff.Result)
                {
                    case "None":
                        Text = "No results found.";
                        break;
                    case "Many":
                        Text = "Too many. Check JTracker window.";
                        break;
                    case "Some":
                        var text = "";
                            
                        foreach (var P in iff.Players)
                        {
                            text = text + P.Name + " : " + P.Group;

                            if (P.Relation != "")
                            {
                                text = text + " (" + P.Relation + ")";
                            }
                            if (Properties.Settings.Default.IFFAlarms){
                                string Relation = P.Relation;
                                switch (Relation.ToUpper())
                                {
                                    case "HOSTILE":
                                        SoundPlayer AlarmHostile = new SoundPlayer(Properties.Resources.hostile);
                                        AlarmHostile.Play();
                                        break;
                                    case "ALLIED":
                                    case "FRIENDLY":
                                        SoundPlayer AlarmFriendly = new SoundPlayer(Properties.Resources.friendly);
                                        AlarmFriendly.Play();
                                        break;
                                    default:
                                        SoundPlayer AlarmUnknown = new SoundPlayer(Properties.Resources.unknown);
                                        AlarmUnknown.Play();
                                        break;
                                }
                            }
                            
                            if(P.Notes != "")
                            {
                                text = text + " [Notes Exist]";
                            }
                            text = text + Environment.NewLine;
                        }
                        Text = text;
                        break;
                    case "Error":
                        Text = "Error: " + iff.Error;
                        break;
                }



                if (Properties.Settings.Default.IFFBalloon == true)
                {
                    notifyIcon.BalloonTipTitle = "IFF Result For " + iff.Search;
                    notifyIcon.BalloonTipText = Text;
                    notifyIcon.BalloonTipIcon = ToolTipIcon.Info;
                    notifyIcon.ShowBalloonTip(5000);
                    if (!icon) notifyIcon.Visible = false;
                }
            }

            //Check for the IFF Request Form.
            HtmlElement formiff = wb.Document.GetElementById("IFFForm");
            if (formiff != null) //If it finds the form, it's logging an error.
            {
                formiff.InvokeMember("submit");
            }
        }

        void webBrowser2_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            //Only attempt to submit anything if it can find the TrackData form.
            HtmlElement form = wb2.Document.GetElementById("TrackData");
            if (form != null) //If it finds the form, it's logging an error.
            {
                form.InvokeMember("submit");
            }
            else if (wb2.Url.AbsoluteUri != "about:blank")
            {
                //Form not there, which means this was a successful track data event.
                //Delete row 0.
                dataSystems.Tables["Tracking"].Rows[0].Delete();
                lblTrackEntries.Text = dataSystems.Tables["Tracking"].Rows.Count.ToString();

                //We're going to recieve a "LatestVersion" dom element with the html inside containing the latest version.
                HtmlElement LatestVersion = wb2.Document.GetElementById("LatestVersion");
                if(LatestVersion != null)
                {
                    //If the html we get back is different to the version we're running...
                    if(LatestVersion.InnerHtml != Globals.version)
                    {
                        //Check if we can update!
                        PreCheckUpdate(false);
                    }
                }
                

                //Call the function again in case there is more to submit.
                ProcessTracking();
            }
        }

        private void wbBGS_Navigating(object sender,  WebBrowserNavigatingEventArgs e)
        {
            wbBGS.Visible = false;
            lblBGS.Visible = true;
        }
        private void wbSales_Navigating(object sender, WebBrowserNavigatingEventArgs e)
        {
            wbSales.Visible = false;
            lblSales.Visible = true;
        }

        private void wb_Navigating(object sender, WebBrowserNavigatingEventArgs e)
        {
            wb.Visible = false;
            lblwbLoading.Visible = true;
        }

        void wbBGS_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            lblBGS.Visible = false;
            wbBGS.Visible = true;
            HtmlElement permissions = wbBGS.Document.GetElementById("Permissions");
            if (permissions != null) //If it finds the permission element.
            {
                var result = permissions.InnerHtml;
                dynamic permission = JsonConvert.DeserializeObject<JEvent>(result);
                if((bool)permission.BGS)
                {
                    //Show the button to allow BGS tab view.
                    btnBGS.Visible = true;
                    btnHero.Visible = true;

                    //Loading is now done when the button is clicked.
                    //Load the BGS Control Centre
                    //if (wbBGS.IsBusy) wbBGS.Stop();
                    //wbBGS.Navigate("http://eicgaming.com/tracker/BGS.php?CMDR=" + Globals.cmdr); //It's read-only data anyway.

                    
                }
                if ((bool)permission.Sales)
                {
                    //Show the button to allow BGS tab view.
                    btnSales.Visible = true;

                    //Loading is now down when the button is clicked.
                    //Load the Sales Control Centre
                    //if (wbSales.IsBusy) wbSales.Stop();
                    //wbBGS.Navigate("http://eicgaming.com/tracker/sales.php?CMDR=" + Globals.cmdr); //It's read-only data anyway.
                }
            }
            else
            {
                
            }
        }

        void wbSales_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            lblBGS.Visible = false;
            wbBGS.Visible = true;
        }

        public void TrackData(string SystemName, string what, long value, string who, string extra = "", string extra2 = "")
        {
            //1.0.34 Change: TrackData should now submit the values into a queue, another process will handle processing the queue.

            //We want to able to call this function from anywhere we need to track something.
            //Trade: TrackData("Kappa Fornacis", "Trade", 256)
            //Mission: TrackData("Tanmark", "MissionMedium", 1)
            //Exploration: TrackData("Bandizel", "Exploration", 2082635)
            //Pawned: TrackData("Skeller", "Pawned", 234)
            //Fined: TrackData("Dakvar", "Fined", 8790)
            //BH: TrackData("BD-15 447", "BH", 792348)
            //CZ: TrackData("LP 771-72", "CZ", 141241154)

            DataRow TrackingData = dataSystems.Tables["Tracking"].NewRow();
            TrackingData["System"] = SystemName;
            TrackingData["What"] = what;
            TrackingData["Value"] = value;
            TrackingData["Who"] = who;
            TrackingData["Extra"] = extra; //Extra added so that we can pass the station name.
            TrackingData["Extra2"] = extra2; //Extra added so that we can pass the station name.
            dataSystems.Tables["Tracking"].Rows.Add(TrackingData);

            lblTrackEntries.Text = dataSystems.Tables["Tracking"].Rows.Count.ToString();

            if(dataSystems.Tables["Tracking"].Rows.Count == 1) //First record initiates ProcessTracking
                //If more actions are added prior to this first on loading the completion event will continue to process the next one, and so on.
                //In theory this should be rapid-firing web requests.
            {
                ProcessTracking();
            }
            
        }
        public string ReplaceString(string replacee)
        {
            //Custom function to replace certain characters in strings for posting to the tracker.
            var s = replacee.Replace("+", "^^");
            s = s.Replace("&", "**");
            return s.ToString();

        }
        public void ProcessTracking() {
            //We only want to do this once every few seconds. 
            //Read the journal fast.
            //Send data slow.

#if DEBUG
            string url = "http://eicgaming.com/tracker/trackdata.php?Debug=true&CMDR=" + Globals.cmdr;
#else
            string url = "http://eicgaming.com/tracker/trackdata.php?CMDR=" + Globals.cmdr;
#endif

            if (dataSystems.Tables["Tracking"].Rows.Count > 0)
            {
                //lblTrackEntries.Text = dataSystems.Tables["Tracking"].Rows.Count.ToString();

                //Get row 0.
                DataRow row = dataSystems.Tables["Tracking"].Rows[0];

                //*
                if ((string)row["System"] == "LOGERROR")
                {
                    //Add a completed handler so that we know when to submit the form.
                    DisplayHtml("<form action='" + url + "' method='post' id='TrackData'><input type='hidden' name='System' value='LOGERROR'><input type='hidden' name='theValue' value='" + row["Value"] + "'><input type='hidden' name='journal' value='" + Globals.journalFile + "'><input type='hidden' name='version' value='" + Globals.version + "'><textarea name='What'>" + row["What"] + "</textarea><textarea name='Who'>" + row["Who"] + "</textarea><input type='submit'></form>");
                    return;
                }
                
                else
                {
                    string postData = "System=" + ReplaceString((string)row["System"]) +
                        "&x=" + Globals.cursystemx + 
                        "&y=" + Globals.cursystemy + 
                        "&z=" + Globals.cursystemz + 
                        "&What=" + row["What"] +
                        "&Value=" + row["Value"] +
                        "&Who=" + ReplaceString((string)row["Who"]) +
                        "&Extra=" + ReplaceString((string)row["Extra"]) + 
                        "&Extra2=" + ReplaceString((string)row["Extra2"]) + 
                        "&Version=" + Globals.version;
                    System.Text.Encoding encoding = System.Text.Encoding.UTF8;
                    byte[] bytes = encoding.GetBytes(postData);

                    wb2.Navigate(url, string.Empty, bytes, "Content-Type: application/x-www-form-urlencoded");
                }
                // */
                
            }
        }




        public void ProcessLine(dynamic line)
        {

            //For certain events we want to read _all the time_, for other events, make sure they happen AFTER we launched the application.
            switch ((string)line.eventtype)
            {
                //These three are only called at the time the game fires up or a new log is generated, you get the idea.
                case "Fileheader":
                    //The game has created a new journal file, or the application has just been started.
                    //Stop checking the journal.
                    timer1.Enabled = false;

                    //Make sure we have no pending missions, we could have accepted missions, closed the game, and re-entered.
                    PreCheckUpdate(false);

                    if (line.gameversion.ToUpper().Contains("BETA"))
                    {
#if DEBUG
                        DisplayHtml("Current Journal File is for the beta, however, JTracker is in debug mode so will continue.", "1");
#else
                        //No further tracking.
                        Globals.journalTracking = false;
                        DisplayHtml("Current Journal File (" + Globals.journalDir + "/" + Globals.journalFile + ") is for the beta, tracking disabled until a live journal file is found.", "1");
#endif
                    }
                    
                    //Ok, continue checking journal.
                    timer1.Enabled = true;
                    break;
                case "Loadout":
                    if (line.Ship != null)
                    {
                        if (line.Ship == "") line.Ship = "Unknown";
                        Globals.curship = line.Ship;
                    }
                    if (line.ShipName != null)
                    {
                        if (line.ShipName == "") line.ShipName = "[UNNAMED]";
                        Globals.curshipname = line.ShipName;
                    }
                    if (line.ShipIdent != null)
                    {
                        if (line.ShipIdent == "") line.ShipIdent = "NO ID";
                        Globals.curshipident = line.ShipIdent;
                    }

                    UpdateHeaderLabels();
                    break;
                case "LoadGame":
                    Globals.cmdr = line.Commander;
                    Globals.curmode = line.GameMode;
                    lblCmdrSystemStation.Text = line.Commander;

                    if (line.Group != null)
                    {
                        Globals.curgroup = line.Group;
                        lblMode.Text = "Mode: " + line.GameMode + " (" + line.Group + ")";
                    }else
                    {
                        Globals.curgroup = "";
                        lblMode.Text = "Mode: " + line.GameMode;
                    }

                    if (line.Ship != null)
                    {
                        if (line.Ship == "") line.Ship = "Unknown";
                        Globals.curship = line.Ship;
                    }
                    if (line.ShipName != null)
                    {
                        if (line.ShipName == "") line.ShipName = "[UNNAMED]";
                        Globals.curshipname = line.ShipName;
                    }
                    if (line.ShipIdent != null)
                    {
                        if (line.ShipIdent == "") line.ShipIdent = "NO ID";
                        Globals.curshipident = line.ShipIdent;
                    }

                    UpdateHeaderLabels();

                    //Got the cmdr. Now check permissions.
                    if (wbBGS.Url.AbsoluteUri == "about:blank"){
                        if (wbBGS.IsBusy)
                        {
                            wbBGS.Stop();
                        }
                        
                        wbBGS.Navigate("http://eicgaming.com/tracker/permission.php?CMDR=" + Globals.cmdr + "&Version=" + Globals.version);
                    }
                    

                    /*
                    if(notifyIcon.Visible == true)
                    {
                        notifyIcon.BalloonTipTitle = "Game Mode Changed";
                        notifyIcon.BalloonTipText = line.GameMode;
                        notifyIcon.ShowBalloonTip(60000);
                    }
                    */
                    break;
                case "Location":
                    UpdateSystem(line.StarSystem, line.StarPos[0], line.StarPos[1], line.StarPos[2], line.SystemFaction);
                    if (line.Docked == "true")
                    {
                        UpdateStation(line.StationName, ""); //The location event does not have a StationFaction presented, but if Docked, the Docked event follows immediately after which does.
                    }

                    if (line.timestamp > Globals.curtime) //If this is a current record (FSDJump processes all the time)
                    {
                        //Update the tracker with the system control faction.
                        if (line.SystemFaction != null)
                        {
                            if (line.Factions != null)
                            {
                                if (line.Factions.Count > 0)
                                {
                                    var Security = "";
                                    if (line.SystemSecurity != null) Security = ReplaceString(line.SystemSecurity);
                                    TrackData(line.StarSystem, "INFLUENCEFULL", 0, JsonConvert.SerializeObject(line.Factions), ReplaceString(line.SystemFaction), ReplaceString(Security));
                                }
                            }else
                            {
                                //No Factions :(
                                TrackData(line.StarSystem, "SYSTEM", 0, line.SystemFaction);
                            }

                        }

                        //To be added into the journal: Faction Influence + States for the entire system.
                        if (line.Powers != null)
                        {
                            string Power = "";
                            switch ((int)line.Powers.Count)
                            {
                                case 0:
                                    break;
                                case 1:
                                    //This is ideal, one power.
                                    foreach (var PowerPlayer in line.Powers)
                                    {
                                        Power = PowerPlayer;
                                    }
                                    break;
                                default: //More than 1, not ideal.
                                    Power = "Multiple";
                                    break;
                            }
                            string PowerState = "";
                            if (line.PowerplayState != null) PowerState = line.PowerplayState;
                            TrackData(line.StarSystem, "POWERPLAY", 0, Power, PowerState);
                        }
                    }

                    break;

                //Docked at a station.
                case "Docked":
                    UpdateStation(line.StationName, line.StationFaction);
                    if (line.timestamp > Globals.curtime) //If this is a current record (Docked processes all the time)
                    {
                        if (line.StationFaction != null)
                        {
                            //Update the tracker with the station control faction.
                            TrackData(line.StarSystem, "STATION", 0, line.StationFaction, line.StationName);
                        }
                    }
                    break;
                //Aproaching a settlement, so let's make sure theres an entry in the database.
                case "ApproachSettlement":
                    TrackData(Globals.cursystem.ToUpper(), "SETTLEMENT", 0, "", line.Name);
                    break;
                //Undocked at a station
                case "Undocked":
                    UpdateStation("", "");
                    break;
                //Entered Supercruise.... no change in system nor station.
                case "SupercruiseEntry":
                    break;
                //Exited Supercruise.... no change in system nor station (yet).
                case "SupercruiseExit":
                    break;
                //Jumped to another system, update the Current system.
                case "FSDJump":
                    UpdateSystem(line.StarSystem, line.StarPos[0], line.StarPos[1], line.StarPos[2], line.SystemFaction);
#if DEBUG
                    if (true)
#else
                    if (line.timestamp > Globals.curtime) //If this is a current record (FSDJump processes all the time)
#endif
                    { 
                        //Update the tracker with the system control faction.
                        if (line.SystemFaction != null)
                        {
                            //To be added into the journal: Faction Influence + States for the entire system.
                            if (line.Factions != null)
                            {
                                if (line.Factions.Count > 0)
                                {
                                    var Security = "";
                                    if (line.SystemSecurity != null) Security = ReplaceString(line.SystemSecurity);
                                    TrackData(line.StarSystem, "INFLUENCEFULL", 0, JsonConvert.SerializeObject(line.Factions), ReplaceString(line.SystemFaction), ReplaceString(Security));
                                }
                            }else
                            {
                                //No Factions :(
                                TrackData(line.StarSystem, "SYSTEM", 0, line.SystemFaction);
                            }
                        }

                        
                        if(line.Powers != null)
                        {
                            string Power = "";
                            switch ((int)line.Powers.Count)
                            {
                                case 0:
                                    break;
                                case 1:
                                    //This is ideal, one power.
                                    foreach (var PowerPlayer in line.Powers)
                                    {
                                        Power = PowerPlayer;
                                    }
                                    break;
                                default: //More than 1, not ideal.
                                    Power = "Multiple";
                                    break;
                            }
                            string PowerState = "";
                            if (line.PowerplayState != null) PowerState = line.PowerplayState;
                            TrackData(line.StarSystem, "POWERPLAY", 0, Power, PowerState);
                        }
                    }
                    break;
                default:
                    //All the rest of the events have to check that they're happening AFTER the app was launched to ensure we don't back-check the journal.
                    
#if DEBUG
                        if (true)
                        //if (line.timestamp > Globals.curtime)
#else
                        if (line.timestamp > Globals.curtime)
                        //if (true)
#endif
                        {
                        switch ((string)line.eventtype)
                        {
                            case "ReceiveText": //We actually aren't interested in what the player says to us.
                                break;
                            case "SendText": //But if we say our code word to another player, IFF them.
                                var codeword = Properties.Settings.Default.IFFText;
                                if (codeword != "") //We have a code word set!
                                {
                                    if (line.Message.Contains(codeword)) //The message contains our code word! Oh goody!
                                    {
                                        //Who is either line.To_Localised in format "CMDR Cazz0r", or simply line.To in format "Cazz0r"
                                        var Who = "";
                                        if (line.To_Localised != null)
                                        {
                                            Who = line.To_Localised.Substring(5);
                                        }
                                        else if (line.To != null)
                                        {
                                            if (line.To != "Local" && line.To != "Wing")
                                            {
                                                Who = line.To;
                                            }
                                        }
                                        if (Who != "")
                                        {
                                            txtIFF.Text = Who;
                                            if (Properties.Settings.Default.IFFAuto)
                                            {
                                                FindCommander();
                                            }
                                        }
                                    }
                                }
                                
                                break;
                            case "JoinACrew":
                                txtIFF.Text = line.Captain;
                                if (Properties.Settings.Default.IFFAuto)
                                {
                                    FindCommander();
                                }
                                break;
                            case "Interdiction":
                                if (line.IsPlayer == true)
                                {
                                    //We've interdicted a player. Let's do an IFF on the line.Interdicted 
                                    txtIFF.Text = line.Interdicted;
                                    if (Properties.Settings.Default.IFFAuto)
                                    {
                                        FindCommander();
                                    }
                                }
                                break;
                            case "EscapeInterdiction":
                            case "Interdicted":
                                if(line.IsPlayer == true)
                                {
                                    //We've been interdicted, let's do an IFF on the line.Interdictor
                                    txtIFF.Text = line.Interdictor;
                                    if (Properties.Settings.Default.IFFAuto)
                                    {
                                        FindCommander();
                                    }
                                }
                                break;
                            case "Bounty": //Occurs when a player kills a ship
                                {
                                    TrackData(Globals.cursystem, "ShipKill", 1, line.VictimFaction.ToString(), line.TotalReward.ToString(), line.Target.ToString());
                                }
                                break;
                            case "SellExplorationData":
                                //For the Current system: +BaseValue to ExplorationClaimed.
                                DataRow ExploreSystem = dataSystems.Tables["StarSystems"].Rows.Find(Globals.cursystem.ToUpper());
                                if (ExploreSystem == null)
                                {
                                    DataRow exploreSystem = dataSystems.Tables["StarSystems"].NewRow();
                                    exploreSystem["SystemName"] = Globals.cursystem.ToUpper();
                                    exploreSystem["ExplorationClaimed"] = line.BaseValue + line.Bonus;
                                    dataSystems.Tables["StarSystems"].Rows.Add(exploreSystem);
                                }
                                else
                                {
                                    ExploreSystem["ExplorationClaimed"] = Convert.ToInt64(ExploreSystem["ExplorationClaimed"]) + Convert.ToInt64(line.BaseValue) + Convert.ToInt64(line.Bonus);
                                }

                                //Track the selling of exploration data
                                TrackData(Globals.cursystem.ToUpper(), "Exploration", (Convert.ToInt64(line.BaseValue) + Convert.ToInt64(line.Bonus)), Globals.curstationfaction);

                                //See if we've just Discovered any new systems
                                //dynamic d = JsonConvert.DeserializeObject<JEvent>(line.Systems);
                                if(line.Discovered.Count > 0)
                                {
                                    btnDiscoveries.Visible = true;


                                    //We've discovered some systems!
                                    foreach (var sys in line.Discovered)
                                    {
                                        DataRow DiscoverSystem = dataSystems.Tables["Discoveries"].NewRow();
                                        DiscoverSystem["BodyName"] = sys;
                                        dataSystems.Tables["Discoveries"].Rows.Add(DiscoverSystem);
                                    }
                                    
                                    /*

                                    string postData = "Discovered=" + line.Discovered;
                                    System.Text.Encoding encoding = System.Text.Encoding.UTF8;
                                    byte[] bytes = encoding.GetBytes(postData);
                                    string url = "http://eicgaming.com/tracker/exploration.php?CMDR=" + Globals.cmdr;
                                    wb.Navigate(url, string.Empty, bytes, "Content-Type: application/x-www-form-urlencoded");
                                    
                                   //*/
                                }
                                break;
                            case "MissionAccepted":
                                //Record the mission ID + accepted system
                                DataRow newMission = dataSystems.Tables["Missions"].NewRow();
                                newMission["MissionID"] = line.MissionID;
                                newMission["AcceptedIn"] = Globals.cursystem.ToUpper();
                                newMission["MissionFromFaction"] = line.Faction;
                                newMission["MissionName"] = line.Name;

                                if (line.Influence == null)
                                {
                                    newMission["InfluenceEffect"] = "Med"; //Medium until the beta goes live and we're finally given the influence effect in the tracker.
                                }
                                else
                                {
                                    newMission["InfluenceEffect"] = line.Influence;
                                }

                                //Determine the mission type.
                                //If this mission is a find x of y and bring them back we'll have a commodity to work with.
                                line.Type = "UNKNOWN";
                                var TargetType = "";
                                //if (line.Commodity_Localised != null)
                                {
                                    /* 

                                    // Mission Names:
                                    Mission_Delivery_Boom: Courier
                                    Mission_Courier_Boom: Courier

                                    Mission_AltruismCredits: Donation

                                    // Passenger Mission Names:
                                    Mission_PassengerVIP_Criminal_BOOM: Courier
                                    Mission_PassengerVIP_General_WAR: Courier
                                    Mission_PassengerVIP_Scientist_WAR: Courier

                                    */
                                    if (line.Name.ToUpper().Contains("CREDITS")) //Credit Donate / Credit blah
                                    {
                                        line.Type = "DONATION";
                                        line.DestinationSystem = Globals.cursystem;
                                        //Never suffers redirects, but complete event also contains faction.
                                    }
                                    else if (line.Name.ToUpper().Contains("COLLECT") || line.Name.ToUpper().Contains("DONATE")) //Didn't have credit in the title, we're donating something else.
                                    {
                                        line.Type = "COLLECT";
                                        //Is subject to mission redirects to alternate system AND FACTION, by RNG. Complete event contains faction.
                                    }
                                    else if (line.Name.ToUpper().Contains("PASSENGER"))
                                    {
                                        line.Type = "PASSENGER";
                                        //Is subject to mission redirects to alternate system AND FACTION, by RNG. Complete event contains faction.
                                    }
                                    else if (line.Name.ToUpper().Contains("DELIVERY") || line.Name.ToUpper().Contains("COURIER"))
                                    {
                                        line.Type = "DELIVERY";
                                        //Is subject to mission redirects to alternate system AND FACTION, by nature. Complete event contains faction.
                                    }
                                    else if (line.Name.ToUpper().Contains("SIGHTSEEING"))
                                    {
                                        line.Type = "SIGHTSEEING";
                                        line.DestinationSystem = Globals.cursystem;
                                        //Not sure on redirects, but is highly likely, complete event contains faction.
                                    }
                                    else if (line.Name.ToUpper().Contains("MASSACRE"))
                                    {
                                        line.Type = "MASSACRE";
                                        line.DestinationSystem = Globals.cursystem;

                                        //Check if Target Faction exists.
                                        if (line.TargetFaction == null)
                                        {
                                            line.TargetFaction = "Undefined";
                                        }

                                        if(line.TargetCount == null)
                                        {
                                            line.TargetCount = 0;
                                        }
                                        if(line.KillCount != null)
                                        {
                                            line.TargetCount = line.KillCount;
                                        }

                                        
                                        if (line.Name.ToUpper().Contains("SKIMMER"))
                                        {
                                            TargetType = "Skimmers";
                                        }else
                                        {
                                            TargetType = "Ships";
                                        }

                                            //Not sure on redirects, but is highly unlikely, complete event contains faction.
                                            newMission["TargetCount"] = line.TargetCount;
                                        newMission["TargetFaction"] = line.TargetFaction;
                                    }
                                    else if (line.Name.ToUpper().Contains("LONGDISTANCEEXPEDITION"))
                                    {
                                        //Not sure on redirects, but is highly likely, complete event contains faction.
                                        line.Type = "EXPEDITION";
                                        line.DestinationSystem = Globals.cursystem;
                                    }
                                    else if (line.Name.ToUpper().Contains("ASSASSINATE"))
                                    {
                                        line.Type = "ASSASSINATION";
                                    }
                                }

                                if (line.DestinationSystem == null)
                                {
                                    line.DestinationSystem = Globals.cursystem;
                                }

                                newMission["DestinationSystem"] = line.DestinationSystem.ToUpper();
                                newMission["MissionType"] = line.Type;
                                dataSystems.Tables["Missions"].Rows.Add(newMission);

                                if (line.Type == "MASSACRE")
                                {
                                    DataRow newOverlayMission = dataSystems.Tables["Overlay"].NewRow();
                                    newOverlayMission["MissionID"] = line.MissionID;
                                    newOverlayMission["Type"] = line.Type;
                                    newOverlayMission["DestinationSystem"] = line.DestinationSystem;
                                    newOverlayMission["TargetFaction"] = line.TargetFaction;
                                    newOverlayMission["TargetCount"] = line.TargetCount;
                                    newOverlayMission["TargetType"] = TargetType;
                                    newOverlayMission["TargetCountKilled"] = 0;
                                    newOverlayMission["ForFaction"] = line.Faction;
                                    dataSystems.Tables["Overlay"].Rows.Add(newOverlayMission);
                                    OverlayMissions();
                                }

                                //Record the system we picked up the mission in.
                                DataRow foundrow = dataSystems.Tables["StarSystems"].Rows.Find(Globals.cursystem.ToUpper());
                                if (foundrow == null)
                                {
                                    DataRow newSystem = dataSystems.Tables["StarSystems"].NewRow();
                                    newSystem["SystemName"] = Globals.cursystem.ToUpper();
                                    newSystem["MissionsPending"] = 1;
                                    newSystem["MissionsDestination"] = 0;
                                    newSystem["MissionsComplete"] = 0;
                                    dataSystems.Tables["StarSystems"].Rows.Add(newSystem);
                                }
                                else
                                {
                                    var x = Convert.ToInt64(foundrow["MissionsPending"]);
                                    var y = x + 1;
                                    foundrow["MissionsPending"] = y.ToString();

                                }

                                //Record the destination system.
                                DataRow foundrow2 = dataSystems.Tables["StarSystems"].Rows.Find(line.DestinationSystem.ToUpper());
                                if (foundrow2 == null)
                                {
                                    DataRow newSystem = dataSystems.Tables["StarSystems"].NewRow();
                                    newSystem["SystemName"] = line.DestinationSystem.ToUpper();
                                    newSystem["MissionsPending"] = 0;
                                    newSystem["MissionsDestination"] = 1;
                                    newSystem["MissionsComplete"] = 0;
                                    dataSystems.Tables["StarSystems"].Rows.Add(newSystem);
                                }
                                else
                                {
                                    var x = Convert.ToInt64(foundrow2["MissionsDestination"]);
                                    var y = x + 1;
                                    foundrow2["MissionsDestination"] = y.ToString();
                                }

                                if (line.Type == "COLLECT" && line.Commodity_Localised != null)
                                {
                                    

                                    //We need to rename some of the commodities.
                                    switch ((string)line.Commodity_Localised.ToUpper())
                                    {
                                        case "BIOREDUCING LICHEN":
                                            line.Commodity_Localised = "Bio Reducing Lichen";
                                            break;
                                        
                                        case "ANIMALMEAT":
                                            line.Commodity_Localised = "Animal Meat";
                                            break;

                                        case "CMM COMPOSITE":
                                        case "C M M COMPOSITE":
                                        case "C.M.M. COMPOSITE":
                                            line.Commodity_Localised = "CMM Composite";
                                            break;

                                        case "HN SHOCKMOUNT":
                                        case "H N SHOCKMOUNT":
                                        case "H.N. SHOCKMOUNT":
                                            line.Commodity_Localised = "HN Shock Mount";
                                            break;

                                        case "HE SUITS":
                                        case "H E SUITS":
                                        case "H.E. SUITS":
                                            line.Commodity_Localised = "Hazardous Environment Suits";
                                            break;
                                        case "LAND ENRICHMENT SYSTEMS":
                                            line.Commodity_Localised = "Terrain Enrichment Systems";
                                            break;

                                    }
                                    //MessageBox.Show(line.Commodity_Localised);
                                    cmbCommodity.SelectedItem = line.Commodity_Localised;
                                    //MessageBox.Show(cmbCommodity.SelectedItem.ToString());
                                    //wb.Navigate("http://eicgaming.com/tracker/commodity.php?CMDR=" + Globals.cmdr + "&Commodity=" + line.Commodity_Localised + "&Station=" + Globals.curstation);
                                }


                                break;
                            case "MissionCompleted":
                                string missionreward = "0";
                                if (line.Reward != null)
                                {
                                    missionreward = (string)line.Reward;
                                }

                                DataRow foundmission = dataSystems.Tables["Missions"].Rows.Find(line.MissionID);
                                if (foundmission == null)
                                {
                                    //We never had the mission in the db, nothing we can do about that. 
                                    //We don't know where we accepted it to credit it.
                                    //We only know where we handed it in and that means nothing to us at the moment.

                                    //Version 1.0.77: Look for the MissionAccept in the historical log files up to 4 weeks back.
                                    if (FindMissionAccept(line.MissionID))
                                    {
                                        //That function would have inserted the mission into the missions table and has returned true, look for it again.
                                        foundmission = dataSystems.Tables["Missions"].Rows.Find(line.MissionID);
                                    }//Else if returned false and didn't find the missionaccepted, that's a bummer.
                                }

                                if(foundmission != null) //Either the mission was originally in the missions table or has just been inserted.
                                {
                                    //We knew about the mission since we accepted it, don't worry about the passed destination system, (it's not present for donation missions and wrong for redirected missions).
                                    foundmission["CompletedIn"] = Globals.cursystem.ToUpper(); //line.DestinationSystem.ToUpper();

                                    //For the AcceptedIn system: +1 MissionsComplete, -1 MissionsPending.
                                    DataRow foundsystem = dataSystems.Tables["StarSystems"].Rows.Find(((string)foundmission["AcceptedIn"]).ToUpper());
                                    if (foundsystem == null)
                                    {
                                        DataRow newSystem = dataSystems.Tables["StarSystems"].NewRow();
                                        newSystem["SystemName"] = ((string)foundmission["AcceptedIn"]).ToUpper();
                                        newSystem["MissionsPending"] = 0;
                                        newSystem["MissionsDestination"] = 0;
                                        newSystem["MissionsComplete"] = 1;
                                        dataSystems.Tables["StarSystems"].Rows.Add(newSystem);
                                    }
                                    else
                                    {
                                        foundsystem["MissionsComplete"] = (Convert.ToInt64(foundsystem["MissionsComplete"]) + 1).ToString();
                                        foundsystem["MissionsPending"] = (Convert.ToInt64(foundsystem["MissionsPending"]) - 1).ToString();
                                    }

                                   

                                    //Track the completed mission - All Missions are displaying as medium at the moment.
                                    TrackData(((string)foundmission["AcceptedIn"]).ToUpper(), "Mission" + (string)foundmission["InfluenceEffect"], 1, (string)foundmission["MissionFromFaction"], missionreward, (string)foundmission["MissionType"]);

                                    //Track the destination completion event,
                                    TrackData(Globals.cursystem.ToUpper(), "MissionD" + (string)foundmission["InfluenceEffect"], 1, (string)line.Faction, missionreward, (string)foundmission["MissionType"]);

                                    //For the CompletedIn system: -1 MissionsDestination. Use the original destination.
                                    DataRow foundsystem2 = dataSystems.Tables["StarSystems"].Rows.Find(foundmission["DestinationSystem"]);
                                    if (foundsystem2 == null)
                                    {
                                        //Wasn't in the DB as a destination, no need to add it really, it'll only be 0,0,0.
                                    }
                                    else
                                    {
                                        foundsystem2["MissionsDestination"] = (Convert.ToInt64(foundsystem2["MissionsDestination"]) - 1).ToString();
                                    }
                                }else
                                {
                                    //We tried to find where we accepted the mission, but no luck, just record the destination completion event, presume "medium" influence.
                                    TrackData(Globals.cursystem.ToUpper(), "MissionD", 1, (string)line.Faction, missionreward, "Unknown");
                                }
                                break;
                            case "MissionAbandoned":
                            case "MissionFailed":
                                //Oh no we failed a mission!

                                DataRow foundmission2 = dataSystems.Tables["Missions"].Rows.Find(line.MissionID);
                                if (foundmission2 == null)
                                {
                                    //We never knew about this mission, nothing to do.
                                }
                                else
                                {
                                    //We didn't complete it, we failed or abandoned it!
                                    foundmission2["CompletedIn"] = (string)line.eventtype;

                                    //For the AcceptedIn system: -1 pending.
                                    //For the AcceptedIn system: +1 MissionsComplete, -1 MissionsPending.
                                    DataRow foundsystem = dataSystems.Tables["StarSystems"].Rows.Find(((string)foundmission2["AcceptedIn"]).ToUpper());
                                    if (foundsystem == null)
                                    {
                                        //Don't bother creating it just for 0,0,0
                                    }
                                    else
                                    {
                                        foundsystem["MissionsPending"] = Convert.ToInt64(foundsystem["MissionsPending"]) - 1;
                                    }

                                    //For the destinationsystem: -1 to destination
                                    DataRow foundsystem2 = dataSystems.Tables["StarSystems"].Rows.Find(((string)foundmission2["DestinationSystem"]).ToUpper());
                                    if (foundsystem2 == null)
                                    {
                                        //Don't bother creating it just for 0,0,0
                                    }
                                    else
                                    {
                                        foundsystem2["MissionsDestination"] = Convert.ToInt64(foundsystem2["MissionsDestination"]) - 1;
                                    }

                                    //Check if the Overlay has this mission present.
                                    DataRow foundmission3 = dataSystems.Tables["Overlay"].Rows.Find(line.MissionID);
                                    if(foundmission3 != null)
                                    {
                                        foundmission3.Delete();
                                        OverlayMissions();
                                    }
                                }

                                break;

                            //Trading
                            case "MarketBuy":
                                //For the Current system: +count to traded.
                                DataRow BuySystem = dataSystems.Tables["StarSystems"].Rows.Find(Globals.cursystem.ToUpper());
                                if (BuySystem == null)
                                {
                                    DataRow newSystem = dataSystems.Tables["StarSystems"].NewRow();
                                    newSystem["SystemName"] = Globals.cursystem.ToUpper();
                                    newSystem["Traded"] = line.Count;
                                    dataSystems.Tables["StarSystems"].Rows.Add(newSystem);
                                }
                                else
                                {
                                    BuySystem["Traded"] = Convert.ToInt64(BuySystem["Traded"]) + Convert.ToInt64(line.Count);
                                }

                                //Track the buying of trade goods
                                //public void TrackData(string SystemName, string what, long value, string who, string extra = "")
                                TrackData(Globals.cursystem.ToUpper(), "Trade", Convert.ToInt64(line.Count), Globals.curstationfaction, (string)line.TotalCost);

                                break;
                            case "MarketSell":
                                //For the Current system: +count to traded.
                                DataRow SellSystem = dataSystems.Tables["StarSystems"].Rows.Find(Globals.cursystem.ToUpper());
                                if (SellSystem == null)
                                {
                                    DataRow newSystem = dataSystems.Tables["StarSystems"].NewRow();
                                    newSystem["SystemName"] = Globals.cursystem.ToUpper();
                                    if(line.StolenGoods == "true")
                                    {
                                        newSystem["Pawned"] = line.Count;
                                    }
                                    else
                                    {
                                        newSystem["Traded"] = line.Count;
                                    }
                                    
                                    dataSystems.Tables["StarSystems"].Rows.Add(newSystem);
                                }
                                else
                                {
                                    if (line.StolenGoods == "true")
                                    {
                                        SellSystem["Pawned"] = Convert.ToInt64(SellSystem["Pawned"]) + Convert.ToInt64(line.Count);
                                    }
                                    else
                                    {
                                        SellSystem["Traded"] = Convert.ToInt64(SellSystem["Traded"]) + Convert.ToInt64(line.Count);
                                    }
                                    
                                }

                                ////public void TrackData(string SystemName, string what, long value, string who, string extra = "")
                                if (line.StolenGoods == "true")
                                {
                                    //Track the selling of stolen goods (pawned)
                                    TrackData(Globals.cursystem.ToUpper(), "Pawned", Convert.ToInt64(line.Count), Globals.curstationfaction, (string)line.TotalSale);
                                }else
                                {
                                    //Track the selling of trade goods
                                    TrackData(Globals.cursystem.ToUpper(), "Trade", Convert.ToInt64(line.Count), Globals.curstationfaction, (string)line.TotalSale);
                                }

                                break;

                            //BH Turn-in
                            case "RedeemVoucher":
                                switch ((string)line.Type.ToUpper())
                                {

                                    case "BOUNTY":
                                        DataRow BHClaimSystem = dataSystems.Tables["StarSystems"].Rows.Find(Globals.cursystem.ToUpper());
                                        if (BHClaimSystem == null)
                                        {
                                            DataRow newSystem = dataSystems.Tables["StarSystems"].NewRow();
                                            newSystem["SystemName"] = Globals.cursystem.ToUpper();
                                            newSystem["BHClaims"] = Convert.ToInt64(line.Amount);
                                            dataSystems.Tables["StarSystems"].Rows.Add(newSystem);
                                        }
                                        else
                                        {
                                            BHClaimSystem["BHClaims"] = Convert.ToInt64(BHClaimSystem["BHClaims"]) + Convert.ToInt64(line.Amount);
                                        }



                                        if (line.Factions != null)
                                        {
                                            if (line.Factions.Count > 0)
                                            {
                                                foreach (dynamic factiondata in line.Factions)
                                                {
                                                   
                                                   TrackData(Globals.cursystem.ToUpper(), "BH", Convert.ToInt64(factiondata.Amount), (string)factiondata.Faction);
                                                }
                                            }else
                                            {
                                                TrackData(Globals.cursystem.ToUpper(), "BH", Convert.ToInt64(line.Amount), "");
                                            }
                                        }
                                        else
                                        {
                                            if (line.Faction != null)
                                            {
                                                TrackData(Globals.cursystem.ToUpper(), "BH", Convert.ToInt64(line.Amount), (string)line.Faction);
                                            }
                                            else
                                            {
                                                //No Factions :(
                                                TrackData(Globals.cursystem.ToUpper(), "BH", Convert.ToInt64(line.Amount), "");
                                            }
                                        }

                                        break;
                                    case "COMBATBOND":
                                        DataRow CZClaimSystem = dataSystems.Tables["StarSystems"].Rows.Find(Globals.cursystem.ToUpper());
                                        if (CZClaimSystem == null)
                                        {
                                            DataRow newSystem = dataSystems.Tables["StarSystems"].NewRow();
                                            newSystem["SystemName"] = Globals.cursystem.ToUpper();
                                            newSystem["CZClaims"] = Convert.ToInt64(line.Amount);
                                            dataSystems.Tables["StarSystems"].Rows.Add(newSystem);
                                        }
                                        else
                                        {
                                            CZClaimSystem["CZClaims"] = Convert.ToInt64(CZClaimSystem["CZClaims"]) + Convert.ToInt64(line.Amount);
                                        }

                                        //Track the redeeming of CZ.
                                        //CZ vouchers are for the faction who issued the voucher, this isn't in the journal atm.
                                        if (line.Factions != null)
                                        {
                                            if (line.Factions.Count > 0)
                                            {
                                                foreach (dynamic factiondata in line.Factions)
                                                {

                                                    TrackData(Globals.cursystem.ToUpper(), "CZ", Convert.ToInt64(factiondata.Amount), (string)factiondata.Faction);
                                                }
                                            }
                                            else
                                            {
                                                TrackData(Globals.cursystem.ToUpper(), "CZ", Convert.ToInt64(line.Amount), "");
                                            }
                                        }
                                        else
                                        {
                                            if (line.Faction != null)
                                            {
                                                TrackData(Globals.cursystem.ToUpper(), "CZ", Convert.ToInt64(line.Amount), (string)line.Faction);
                                            }
                                            else
                                            {
                                                //No Factions :(
                                                TrackData(Globals.cursystem.ToUpper(), "CZ", Convert.ToInt64(line.Amount), "");
                                            }
                                        }



                                        break;
                                    case "SETTLEMENT":
                                    case "SCANNABLE":
                                    case "TRADE":
                                        //We aren't adding these to the JTracker, simply throwing them into the tracker itself.
                                        TrackData(Globals.cursystem.ToUpper(), "Voucher", Convert.ToInt64(line.Amount), Globals.curstationfaction);
                                        break;
                                    default:
                                        TrackData(Globals.cursystem.ToUpper(), (string)line.Type.ToUpper(), Convert.ToInt64(line.Amount), Globals.curstationfaction);

                                        //Unknown claim type...
                                        //wb.Document.Write("Unknown Claim Type: " + (string)line.Type.ToUpper() + "<br>Let Cazz0r know!");
                                        break;

                                }
                                break;
                            case "CommitCrime":
                                //http://edcodex.info/?m=doc#f.10.3
                                //We've commited a crime.
                                bool crime = true;

                                //Not sure if we need to do things for different crimes, but all types are referenced: http://edcodex.info/?m=doc#f.11.6
                                switch ((string)line.CrimeType.ToUpper())
                                {
                                    case "ASSAULT":

                                        break;
                                    case "MURDER":
                                        //We've murdered somebody, this will likely result in a fine.

                                        break;
                                    case "PIRACY":

                                        break;
                                    case "INTERDICTION":

                                        break;
                                    case "ILLEGALCARGO":

                                        break;
                                    case "DISOBEYPOLICE":

                                        break;
                                    case "DUMPINGDANGEROUS":

                                        break;
                                    case "DUMPINGNEARSTATION":
                                        break;
                                    
                                    default: //Don't concern ourselves with any smaller crime.
                                        crime = false;
                                        break;
                                }

                                //For testing purposes we're turning on all crime tracking.
                                crime = true;

                                if (crime)
                                {
                                    DataRow CrimeSystem = dataSystems.Tables["StarSystems"].Rows.Find(Globals.cursystem.ToUpper());
                                    if (CrimeSystem == null)
                                    {
                                        DataRow crimeSystem = dataSystems.Tables["StarSystems"].NewRow();
                                        crimeSystem["SystemName"] = Globals.cursystem.ToUpper();
                                        crimeSystem["Fines"] = Convert.ToInt64(line.Fine) + Convert.ToInt64(line.Bounty);
                                        dataSystems.Tables["StarSystems"].Rows.Add(crimeSystem);
                                    }
                                    else
                                    {
                                        CrimeSystem["Fines"] = Convert.ToInt64(CrimeSystem["Fines"]) + Convert.ToInt64(line.Fine) + Convert.ToInt64(line.Bounty);
                                    }

                                    //Track the fine
                                    TrackData(Globals.cursystem.ToUpper(), "Fined", (Convert.ToInt64(line.Fine) + Convert.ToInt64(line.Bounty)), line.Faction);
                                }
                                break;
                            case "FactionKillBond": //These occurs when you destory a ship that issues a bond.
                                                    //Check if this was a bond we were wanting for a MASSACRE
                                                    //Current System matches "DestinationSystem"
                                                    //"AwardingFaction" matches "ForFaction" 
                                                    //"VictimFaction" matches "TargetFaction"
                                for (int i = frmMain.dataSystems.Tables["Overlay"].Rows.Count - 1; i >= 0; i--)
                                {
                                    var row = frmMain.dataSystems.Tables["Overlay"].Rows[i];
                                    if (
                                            (string)row["Type"] == "MASSACRE" &&
                                            (string)row["DestinationSystem"] == Globals.cursystem &&
                                            (string)row["ForFaction"] == (string)line.AwardingFaction &&
                                            (string)row["TargetFaction"] == (string)line.VictimFaction
                                        )
                                    {
                                        //This is exactly what we were after, we killed another + 1 to killed.
                                        row["TargetCountKilled"] = (int)row["TargetCountKilled"] + 1;
                                        if ((int)row["TargetCountKilled"] >= (int)row["TargetCount"])
                                        {
                                            row.Delete();
                                        }
                                    }
                                }
                                OverlayMissions();
                                break;
                            case "PVPKill":
                                TrackData(Globals.cursystem.ToUpper(), "PVP", (int)line.CombatRank, line.Victim);
                                break;
                            case "SetUserShipName":
                                Globals.curshipname = line.UserShipName;
                                Globals.curship = line.Ship;
                                if(line.UserShipId != null)
                                {
                                    if (line.UserShipId == "") line.UserShipId = "NO ID";
                                    Globals.curshipident = line.UserShipId;
                                }
                                UpdateHeaderLabels();
                                break;
                            default:
                                //Ignore.
                                break;
                        }
                    }
                    break;
            }


            
            return;
        }
        
        
        private void btnDiscoveries_Click(object sender, EventArgs e)
        {
            
            string html = "<h4>Congratulations on discovering...</h4>";

            foreach (DataRow row in dataSystems.Tables["Discoveries"].Rows)
            {
                html = html + row["BodyName"] + "<br>";
            }
            wb.Document.GetElementById("body-container").InnerHtml = html;

        }

        public void btnClearSystems_Click(object sender, EventArgs e)
        {

            dataSystems.Tables["StarSystems"].Clear();
        }

        /* Makes the discoveries button show the missions
        private void btnDiscoveries_Click(object sender, EventArgs e)
        {
            string html = "<h4>Missions:</h4>";

            foreach (DataRow row in dataSystems.Tables["Missions"].Rows)
            {
                html = html + row["MissionID"] + "," + row["AcceptedIn"] + "," + row["DestinationSystem"] + "," + row["CompletedIn"] + "<br>";
            }
            wb.Document.GetElementById("body-container").InnerHtml = html;
        }
        //*/

        public void ProcessJournal(string filename) //Pass the filename to the function for traceback debugging, it's not used otherwise.
        {
            //lblDebug.Text = "Processing Journal...";

            //Let's make sure we're still using the same file as ED
            GetFile();

            //Make sure we've got a file.
            if (Globals.journalFile == "") return;

            //Make sure we're still tracking the journal.
            if (!Globals.journalTracking) return;

            //Let's check the file's size. Get fileinfo.
            FileInfo f = new FileInfo(Globals.journalDir + "\\" + Globals.journalFile);

            //Check if the size is greater than the last seek position
            if (f.Length > Globals.seekpos)
            { //It is!

                //lblDebug.Text = "Checking New Entries...";

                //Clear the debug display.
                rtbJournal.Text = "";

                //Pause the timer while we process the new journal lines.
                timer1.Enabled = false;

                //Get the binary reader out.
                using (BinaryReader b = new BinaryReader(File.Open(Globals.journalDir + "\\" + Globals.journalFile, FileMode.Open, FileAccess.Read, FileShare.ReadWrite)))
                {
                    //Get the current length of the stream.
                    int length = (int)b.BaseStream.Length;

                    //Calculate how many bytes we need to read to get to the end.
                    long toend = length - Globals.seekpos;

                    //lblDebug.Text = "Getting " + toend + " Bytes...";

                    //Seek to the last read-to byes.
                    b.BaseStream.Seek(Globals.seekpos, SeekOrigin.Begin);

                    //Remember where we read up to for next time.
                    Globals.seekpos = length;

                    //Get all the rest of the byes and convert it to a string.
                    string linesblob = System.Text.Encoding.UTF8.GetString(b.ReadBytes((int)toend));

                    //Split the lines that we just got out.
                    var lines = linesblob.Split(new string[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);

                    //lblDebug.Text = lines.Length + " New Entries...";

                    //Loop through each line.
                    for (int i = 0; i < lines.Length; i++)
                    {
                        //We've turned the tracking off, break to stop further tracking.
                        if (!Globals.journalTracking) break;

                        //Add the line to the journal log for debugging.
                        if (i < 10) {  //Only put 10 lines into the debugger, otherwise the program locks up (not cool!)
                            rtbJournal.Text += lines[i] + Environment.NewLine;
                        }

                        //Process the line
                        try
                        {
                            dynamic l = JsonConvert.DeserializeObject<JEvent>(lines[i]);
                            ProcessLine(l);
                        }
                        catch (JsonReaderException jex)
                        {
                            //Exception in parsing json
                            rtbJournal.Text += "Skipped Previous Line. Reason: " + jex.Message + Environment.NewLine;
                            TrackData("LOGERROR", lines[i], 1, jex.Message);
                        }
                        catch (Exception ex) //some other exception
                        {
                            rtbJournal.Text += "Skipped Previous Line. Reason: " + ex.ToString() + Environment.NewLine;
                            TrackData("LOGERROR", lines[i], 2, ex.ToString());
                        }
                        rtbJournal.Text += Environment.NewLine;
                    }

                }
            }
            else
            {
                //Debugging, alert that there hasn't been a change just yet.
                rtbJournal.Text = "No Change...";
            }
            //lblDebug.Text = "Done...";

            //Make sure the timer is going.
            timer1.Enabled = true;
        }

        private Boolean FindMissionAccept(string MissionID)
        {

            //Get all files in the directory, ordered by last write time descending, then only get the first one (the latest).
            var sortedFiles = new DirectoryInfo(Globals.journalDir).GetFiles("Journal.*.log")
                                                .OrderByDescending(f => f.LastWriteTime)
                                                .ToList();
            foreach (FileInfo myFile in sortedFiles)
            {
                //Looping through the journal files, read the file line by line.
                //Read the current journal just in case we restarted the JTracker AFTER accepting missions in this journal file, they wouldn't be known to us as they wouldn't have been within the timestamp parameters.
                //if (myFile.Name != Globals.journalFile)
                if (true)
                {

                    string line;
                    string CurrentSystem = "";

                    System.IO.StreamReader file = new StreamReader(File.Open(Globals.journalDir + "\\" + myFile.Name, FileMode.Open, FileAccess.Read, FileShare.ReadWrite));
                    while ((line = file.ReadLine()) != null)
                    {
                        try
                        {
                            dynamic l = JsonConvert.DeserializeObject<JEvent>(line);
                            switch ((string)l.eventtype)
                            {
                                case "Fileheader":
                                    //If the timestamp exceeds 4 weeks, stop looking for a mission accept.
                                    if ((DateTime.Now - l.timestamp).TotalDays > 28)
                                    {
                                        return false;
                                    }

                                    if (l.gameversion.ToUpper().Contains("BETA"))
                                    {
#if DEBUG
                                        DisplayHtml("Current Journal File is for the beta, however, JTracker is in debug mode so will continue.", "1");
#else
                                        //No further tracking.
                                        return false; //Skip this journal.
#endif
                                    }

                                    break;
                                case "Location":
                                case "FSDJump":
                                    CurrentSystem = l.StarSystem; //Keep the current system somewhere because that'll be where we picked up the mission.
                                    break;
                                case "MissionAccepted": //This is all we really care about.
                                    if (l.MissionID == MissionID)
                                    {
                                        //We found the damn mission! NICE!
                                        //Record the mission ID + accepted system
                                        DataRow newMission = dataSystems.Tables["Missions"].NewRow();
                                        newMission["MissionID"] = l.MissionID;
                                        newMission["AcceptedIn"] = CurrentSystem;
                                        newMission["MissionFromFaction"] = l.Faction;
                                        newMission["MissionName"] = l.Name;

                                        if(l.Influence == null)
                                        {
                                            newMission["InfluenceEffect"] = "Med";
                                        }else
                                        {
                                            newMission["InfluenceEffect"] = l.Influence;
                                        }

                                        dataSystems.Tables["Missions"].Rows.Add(newMission);

                                        //Record the system we picked up the mission in.
                                        DataRow foundrow = dataSystems.Tables["StarSystems"].Rows.Find(CurrentSystem.ToUpper());
                                        if (foundrow == null)
                                        {
                                            DataRow newSystem = dataSystems.Tables["StarSystems"].NewRow();
                                            newSystem["SystemName"] = CurrentSystem.ToUpper();
                                            newSystem["MissionsPending"] = 1;
                                            newSystem["MissionsDestination"] = 0;
                                            newSystem["MissionsComplete"] = 0;
                                            dataSystems.Tables["StarSystems"].Rows.Add(newSystem);
                                        }
                                        else
                                        {
                                            var x = Convert.ToInt64(foundrow["MissionsPending"]);
                                            var y = x + 1;
                                            foundrow["MissionsPending"] = y.ToString();
                                        }
                                        return true;
                                    }
                                    break;
                            }
                        }
                        catch (JsonReaderException jex)
                        {
                            //Exception in parsing json
                            rtbJournal.Text += "Skipped Previous Line. Reason: " + jex.Message + Environment.NewLine;
                            TrackData("LOGERROR", line, 3, "FindMissionAccept: " + jex.Message);
                        }
                        catch (Exception ex) //some other exception
                        {
                            rtbJournal.Text += "Skipped Previous Line. Reason: " + ex.ToString() + Environment.NewLine;
                            TrackData("LOGERROR", line, 4, "FindMissionAccept: " + ex.ToString());
                        }
                    }
                    file.Close();
                }

            }
            //Looped through all files with nothing.
            return false;

        }


        private void timer1_Tick(object sender, EventArgs e)
        {
            var x = Convert.ToInt64(lblTime.Text);
            var y = x - 1;
            if (y == 0)
            {
                ProcessJournal(Globals.journalFile);
                lblTime.Text = "5";
            }
            else
            {
                lblTime.Text = y.ToString();
            }
        }
        private void lblTime_Click(object sender, EventArgs e)
        {
            ProcessJournal(Globals.journalFile);
            lblTime.Text = "5";
        }

        void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.ToString() == "F2")
            {
                Control control = (Control)sender;
                if(control.Size.Width == 953)
                {
                    control.Size = new Size(732, 515);
                    control.MinimumSize = new Size(732, 515);
                    control.MaximumSize = new Size(732, 4000);
                }
                else
                {
                    control.Size = new Size(953, 515);
                    control.MinimumSize = new Size(953, 515);
                    control.MaximumSize = new Size(953, 4000);
                }
            }
            if (e.KeyCode.ToString() == "F3")
            {
                string html = "<h4>Missions:</h4>" + 
                    "<table class='table table-condensed'><thead><tr><th>Mission ID</th><th>Accepted In</th><th>Destination System</th><th>Completed In</th><th>Mission Type</th><th>Mission Name</th></tr></thead><tbody>";

                foreach (DataRow row in dataSystems.Tables["Missions"].Rows)
                {
                    html = html + "<tr>" + "<td>" + row["MissionID"] + "</td><td>" + row["AcceptedIn"] + "</td><td>" + row["DestinationSystem"] + "</td><td>" + row["CompletedIn"] + "</td>" + "</td><td>" + row["MissionType"] + "</td>" + "</td><td>" + row["MissionName"] + "</td>" + "</tr>";
                    //html = html + row["MissionID"] + "," + row["AcceptedIn"] + "," + row["DestinationSystem"] + "," + row["CompletedIn"] + "<br>";
                }
                html = html + "</tbody></table>";
                wb.Document.GetElementById("body-container").InnerHtml = html;
            }
            if (e.KeyCode.ToString() == "F4")
            {
                
                PreCheckUpdate(true);
            }
            
            if (e.KeyCode.ToString() == "F5")
            {
                
            }
            if (e.KeyCode.ToString() == "F6")
            {
                if (chkOverlay.Checked)
                {
                    chkOverlay.Checked = false;
                }else
                {
                    chkOverlay.Checked = true;
                }
                
            }
        }
       

        //Make sure we have no pending missions, we could have accepted missions, closed the game, and re-entered.
        public void PreCheckUpdate(bool output = false)
        {
            bool CheckUpdate = true;
            //Make sure we have no pending data to send to the tracker.
            if (dataSystems.Tables["Tracking"].Rows.Count > 0)
            {
                if (output)
                {
                    wb.Document.GetElementById("body-container").InnerHtml = "Can't Update. Sending Tracking Data.";
                }
                CheckUpdate = false;
                return;
            }

            //Check for an update.
            if (CheckUpdate)
            {
                if (output)
                {
                    InstallUpdateSyncWithInfo("1");
                }
                else
                {
                    InstallUpdateSyncWithInfo("2");
                }
            }
        }
        

        

        public void FindCommander()
        {
            if (txtIFF.Text != "")
            {
                //Add a completed handler so that we know when to submit the form.
                var url = "http://eicgaming.com/tracker/commander.php?CMDR=" + Globals.cmdr + "&x=" + Globals.cursystemx + "&y=" + Globals.cursystemy + "&z=" + Globals.cursystemz + "&System=" + Globals.cursystem + "&Version=" + Globals.version;
                DisplayHtml("<form action='" + url + "' method='post' id='IFFForm'><textarea name='IFF' style='display:none'>" + txtIFF.Text + "</textarea><input type='hidden' name='journal' value='" + Globals.journalFile + "'><input type='hidden' name='version' value='" + Globals.version + "'><input type='submit'></form>", "1");
            }
        }

        public void FindCommodity()
        {
            if (cmbCommodity.SelectedItem != null)
            {
                var commtext = cmbCommodity.SelectedItem.ToString();

                switch (commtext.ToUpper())
                {
                    case "BIOREDUCING LICHEN":
                        commtext = "Bio Reducing Lichen";
                        break;

                    case "ANIMALMEAT":
                        commtext = "Animal Meat";
                        break;

                    case "CMM COMPOSITE":
                    case "C M M COMPOSITE":
                    case "C.M.M. COMPOSITE":
                        commtext = "CMM Composite";
                        break;

                    case "HN SHOCKMOUNT":
                    case "H N SHOCKMOUNT":
                    case "H.N. SHOCKMOUNT":
                        commtext = "HN Shock Mount";
                        break;

                    case "HE SUITS":
                    case "H E SUITS":
                    case "H.E. SUITS":
                        commtext = "Hazardous Environment Suits";
                        break;
                    case "LAND ENRICHMENT SYSTEMS":
                        commtext = "Terrain Enrichment Systems";
                        break;
                }


                var url = "http://eicgaming.com/tracker/commodity.php?CMDR=" + Globals.cmdr + "&Commodity=" + commtext + "&x=" + Globals.cursystemx + "&y=" + Globals.cursystemy + "&z=" + Globals.cursystemz + "&System=" + Globals.cursystem + "&Version=" + Globals.version;
                if (Globals.curstation != "")
                {
                    url = url + "&Station=" + Globals.curstation;
                }

                if (wb.IsBusy)
                {
                    wb.Stop();
                }
                wb.Navigate(url);
            }
        }

        private void cmbCommodity_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Properties.Settings.Default.AutoCommodity)
            {
                FindCommodity();
            }
        }


        private void btnSettings_Click(object sender, EventArgs e)
        {
            if (!Globals.frmSettingsOpen)
            {
                Form Settings = new frmSettings();
                Settings.Visible = true;
            }
        }

        private void btnCommodity_Click(object sender, EventArgs e)
        {
            FindCommodity();
        }

        public void GetFile()
        {
            //Get the directory.
            var directory = new DirectoryInfo(Globals.journalDir);
            FileInfo myFile = null;

            //Make sure the directory has some files.
            if (directory.GetFiles("Journal.*.log").Length > 0)
            {
                //Get all files in the directory, ordered by last write time descending, then only get the first one (the latest).
                myFile = directory.GetFiles("Journal.*.log").OrderByDescending(f => f.LastWriteTime).First();

                //Check if the name has changed (will also fire at start up)
                if (Globals.journalFile != myFile.Name)
                {
                    //Update the global variables
                    Globals.journalFile = myFile.Name;
                    Globals.seekpos = 0;
                    Globals.journalTracking = true; //Turn tracking back on as we got a new journal file. If the header contains "beta" it'll turn off.

                    //Latest file name gets put into the bar for debugging.
                    txtFile.Text = Globals.journalFile;
                }
            }else
            {
                //There's no journal file... could be fine...
                Globals.journalFile = "";
                Globals.seekpos = 0;
                txtFile.Text = "No Journal File Located.";
            }
            

            


        }

        public static DateTime UtcNow { get; }

        public static string GetDefaultJournalDir()
        {
            string path;

            // Windows Saved Games path (Vista and above)
            if (Environment.OSVersion.Platform == PlatformID.Win32NT && Environment.OSVersion.Version.Major >= 6)
            {
                IntPtr pszPath;
                if (SHGetKnownFolderPath(Win32FolderId_SavedGames, 0, IntPtr.Zero, out pszPath) == 0)
                {
                    path = Marshal.PtrToStringUni(pszPath);
                    Marshal.FreeCoTaskMem(pszPath);

                    if (!Directory.Exists(Path.Combine(path, "Frontier Developments", "Elite Dangerous")))
                    {
                        MessageBox.Show("The default journal path (" + Path.Combine(path, "Frontier Developments", "Elite Dangerous") + ") does not exist." + Environment.NewLine + Environment.NewLine + "Seek help in EIC's Discord #jtracker channel.");
                        return "";
                    }else
                    {
                        return Path.Combine(path, "Frontier Developments", "Elite Dangerous");
                    }
                }
            }

            // OS X ApplicationSupportDirectory path (Darwin 12.0 == OS X 10.8)
            if (Environment.OSVersion.Platform == PlatformID.Unix && Environment.OSVersion.Version.Major >= 12)
            {
                path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile), "Library", "Application Support", "Frontier Developments", "Elite Dangerous");

                if (Directory.Exists(path))
                {
                    return path;
                }
            }

            return null;
        }

        private static Guid Win32FolderId_SavedGames = new Guid("4C5C32FF-BB9D-43b0-B5B4-2D72E54EAAA4");
        [DllImport("Shell32.dll")]
        private static extern uint SHGetKnownFolderPath(
            [MarshalAs(UnmanagedType.LPStruct)] Guid rfid,
            uint dwFlags,
            IntPtr hToken,
            out IntPtr pszPath  // API uses CoTaskMemAlloc
        );

        private void InstallUpdateSyncWithInfo(string BrowserOutput = "2")
        {
            DisplayHtml("Checking for updates...", BrowserOutput);
            UpdateCheckInfo info = null;

            if (ApplicationDeployment.IsNetworkDeployed)
            {
                ApplicationDeployment ad = ApplicationDeployment.CurrentDeployment;

                try
                {
                    info = ad.CheckForDetailedUpdate();

                }
                catch (DeploymentDownloadException dde)
                {
                    MessageBox.Show("The new version of the application cannot be downloaded at this time. \n\nPlease check your network connection, or try again later. Error: " + dde.Message);
                    return;
                }
                catch (InvalidDeploymentException ide)
                {
                    MessageBox.Show("Cannot check for a new version of the application. The ClickOnce deployment is corrupt. Please redeploy the application and try again. Error: " + ide.Message);
                    return;
                }
                catch (InvalidOperationException ioe)
                {
                    MessageBox.Show("This application cannot be updated. It is likely not a ClickOnce application. Error: " + ioe.Message);
                    return;
                }

                if (info.UpdateAvailable)
                {
                    Boolean doUpdate = true;
                    DisplayHtml("Update Available!", BrowserOutput);

                    if (!Properties.Settings.Default.SilentUpdates) //Silent updates is false, prompt the user.
                    {
                        //Bring the JTracker to the front. We do this by minimizing it, then showing it again.
                        notifyIcon.BalloonTipText = ""; //Set to blank so no message is shown when doing the next minimized command.
                        if (this.WindowState == FormWindowState.Normal)
                        {
                            this.WindowState = FormWindowState.Minimized;
                        }
                        this.Show();
                        this.WindowState = FormWindowState.Normal;
                        notifyIcon.BalloonTipIcon = ToolTipIcon.Warning;
                        notifyIcon.BalloonTipTitle = "Update Available"; //Let's give them a notice to update.
                        notifyIcon.BalloonTipText = "JTracker Update Available, please update!";
                        notifyIcon.ShowBalloonTip(5000);
                    }




                    if (!info.IsUpdateRequired)
                    {
                        if (!Properties.Settings.Default.SilentUpdates) //Silent updates is false, prompt the user.
                        {
                            DialogResult result = MessageBox.Show("An update is available. Would you like to update the application now?", "Update Available", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                            if (result == DialogResult.No)
                            {
                                doUpdate = false;
                            }
                        }
                    }
                    else
                    {
                        if (!Properties.Settings.Default.SilentUpdates) //Silent updates is false, prompt the user.
                        {
                            // Display a message that the app MUST reboot. Display the minimum required version.
                            MessageBox.Show("This application has detected a mandatory update from your current " +
                            "version to version " + info.MinimumRequiredVersion.ToString() +
                            ". The application will now install the update and restart.",
                            "Update Available", MessageBoxButtons.OK,
                            MessageBoxIcon.Information);
                        }
                    }

                    if (doUpdate)
                    {
                        try
                        {
                            DisplayHtml("Updating...", BrowserOutput);
                            ad.Update();
                            if (!Properties.Settings.Default.SilentUpdates) //Silent updates is false, prompt the user.
                            {
                                MessageBox.Show("The application has been updated, and will now restart.");
                            }
                            //Release the mutex so another process can start and claim it while this restart occurs.
                            mymutex.Dispose();
                            Application.Restart();
                        }
                        catch (DeploymentDownloadException dde)
                        {
                            DisplayHtml("Update Failed!", BrowserOutput);
                            MessageBox.Show("Cannot install the latest version of the application. \n\nPlease check your network connection, or try again later. Error: " + dde);
                            return;
                        }
                    }
                }else
                {
                    DisplayHtml("No Update Required.", BrowserOutput);
                }
            }else
            {
                DisplayHtml("Update Check Failed. JTracker is in stand-alone mode, it won't receive any updates, please re-install.<br><br><a href=\"http://eicgaming.com/jtracker/setup.exe\" target=\"_blank\">http://eicgaming.com/jtracker/setup.exe</a>", BrowserOutput);
            }
        }
        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                //Check if we want the user to close, we might have pending missions or pending data.
                bool AllowClose = true;
                
                //Make sure we have no pending data to send to the tracker.
                if (AllowClose)
                {
                    if (dataSystems.Tables["Tracking"].Rows.Count > 0)
                    {
                        //We've got pending data, don't allow the closure of the application.
                        AllowClose = false;
                        MessageBox.Show("JTracker is still sending tracking information (Message Queue: " + dataSystems.Tables["Tracking"].Rows.Count + "). Please wait and try again." + Environment.NewLine + Environment.NewLine + "You could minimize to system tray and think it was closed though!", "Exit Warning", MessageBoxButtons.OK);
                    }
                }
                else
                {
                    //We've got missions pending, prompt the user.
                    if (MessageBox.Show("You still have pending missions." + Environment.NewLine + Environment.NewLine + "If you exit now you will lose that tracking information." + Environment.NewLine + Environment.NewLine + "Do you still want to exit?", "Exit Warning", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        AllowClose = true;
                    }
                }

                if (!AllowClose)
                {
                    e.Cancel = true;

                }

            }

            Properties.Settings.Default.WindowPosition = DesktopBounds;
            Properties.Settings.Default.WindowHeight = this.Size.Height;
            Properties.Settings.Default.Save();

        }

        private void btnIFF_Click(object sender, EventArgs e)
        {
            FindCommander();
        }
        private void txtIFF_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                //enter key is down
                FindCommander();
            }
        }

        private void btnDonate_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://donorbox.org/jtracker-software-appreciation");
        }

        private void btnTracking_Click(object sender, EventArgs e)
        {
            tabControl.SelectedTab = tabMain;
        }

        private void ChangeTab(string tab)
        {
            tabControl.SelectedTab = tabBGS;
            if (wbBGS.IsBusy)
            {
                wbBGS.Stop();
            }
            switch (tab)
            {
                case "BGS":
                    wbBGS.Navigate("http://eicgaming.com/tracker/BGS.php?CMDR=" + Globals.cmdr);
                    break;
                case "Help":
                    wbBGS.Navigate("http://eicgaming.com/tracker/help.php?CMDR=" + Globals.cmdr);
                    break;
                case "Hero":
                    wbBGS.Navigate("http://eicgaming.com/tracker/hero.php?CMDR=" + Globals.cmdr);
                    break;
                case "Sales":
                    wbBGS.Navigate("http://eicgaming.com/tracker/sales.php?CMDR=" + Globals.cmdr);
                    break;
            }
        }

        private void btnBGS_Click(object sender, EventArgs e)
        {
            ChangeTab("BGS");
        }
        private void btnHelp_Click(object sender, EventArgs e)
        {
            ChangeTab("Help");
        }
        private void btnHero_Click(object sender, EventArgs e)
        {
            ChangeTab("Hero");
        }

        private void btnSales_Click(object sender, EventArgs e)
        {
            ChangeTab("Sales");
            /*
            tabControl.SelectedTab = tabSales;
            if (wbSales.IsBusy)
            {
                wbSales.Stop();
            }
            wbSales.Navigate("http://eicgaming.com/tracker/sales.php?CMDR=" + Globals.cmdr);
            */
        }

        private void lblVersion_Click(object sender, EventArgs e)
        {
            PreCheckUpdate(true);
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.ColumnIndex == 0)
            {
                DataGridViewCell cell = (DataGridViewCell) dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex];
                Clipboard.SetText(cell.Value.ToString());
            }
            
        }

        private void chkAlwaysTop_CheckedChanged(object sender, EventArgs e)
        {
            this.TopMost = chkAlwaysTop.Checked;
        }

        private void chkOverlay_CheckedChanged(object sender, EventArgs e)
        {
            if (!Globals.frmOverlayOpen)
            {
                Globals.frmOverlayOpen = true; //Prevent it from open more.
                Overlay OverlayForm = new Overlay();
                OverlayForm.Visible = true;
                this.Focus();
            }
            else
            {
                for (int index = Application.OpenForms.Count - 1; index >= 0; index--)
                {
                    if (Application.OpenForms[index].Name == "Overlay")
                    {
                        Application.OpenForms[index].Close();
                        Globals.frmOverlayOpen = false;
                    }
                }
            }
        }
        private void ListCommodities()
        {
            cmbCommodity.Items.Clear();
            cmbCommodity.Items.Add("Advanced Catalysers");
            cmbCommodity.Items.Add("Advanced Medicines");
            cmbCommodity.Items.Add("Agricultural Medicines");
            cmbCommodity.Items.Add("Ai Relics");
            cmbCommodity.Items.Add("Algae");
            cmbCommodity.Items.Add("Aluminium");
            cmbCommodity.Items.Add("Animal Meat");
            cmbCommodity.Items.Add("Animal Monitors");
            cmbCommodity.Items.Add("Animalmeat");
            cmbCommodity.Items.Add("Antiquities");
            cmbCommodity.Items.Add("Aquaponic Systems");
            cmbCommodity.Items.Add("Articulation Motors");
            cmbCommodity.Items.Add("Atmospheric Extractors");
            cmbCommodity.Items.Add("Auto Fabricators");
            cmbCommodity.Items.Add("Basic Medicines");
            cmbCommodity.Items.Add("Basic Narcotics");
            cmbCommodity.Items.Add("Battle Weapons");
            cmbCommodity.Items.Add("Bauxite");
            cmbCommodity.Items.Add("Beer");
            cmbCommodity.Items.Add("Bertrandite");
            cmbCommodity.Items.Add("Beryllium");
            cmbCommodity.Items.Add("Bio Reducing Lichen");
            cmbCommodity.Items.Add("Bioreducing Lichen");
            cmbCommodity.Items.Add("Biowaste");
            cmbCommodity.Items.Add("Bismuth");
            cmbCommodity.Items.Add("Bootleg Liquor");
            cmbCommodity.Items.Add("Bromellite");
            cmbCommodity.Items.Add("Building Fabricators");
            cmbCommodity.Items.Add("C M M Composite");
            cmbCommodity.Items.Add("C.M.M. Composite");
            cmbCommodity.Items.Add("CMM Composite");
            cmbCommodity.Items.Add("Ceramic Composites");
            cmbCommodity.Items.Add("Chemical Waste");
            cmbCommodity.Items.Add("Clothing");
            cmbCommodity.Items.Add("Cobalt");
            cmbCommodity.Items.Add("Coffee");
            cmbCommodity.Items.Add("Coltan");
            cmbCommodity.Items.Add("Combat Stabilisers");
            cmbCommodity.Items.Add("Computer Components");
            cmbCommodity.Items.Add("Conductive Fabrics");
            cmbCommodity.Items.Add("Consumer Technology");
            cmbCommodity.Items.Add("Cooling Hoses");
            cmbCommodity.Items.Add("Copper");
            cmbCommodity.Items.Add("Crop Harvesters");
            cmbCommodity.Items.Add("Cryolite");
            cmbCommodity.Items.Add("Data Core");
            cmbCommodity.Items.Add("Deuringas Truffles");
            cmbCommodity.Items.Add("Diagnostic Sensor");
            cmbCommodity.Items.Add("Domestic Appliances");
            cmbCommodity.Items.Add("Drones");
            cmbCommodity.Items.Add("Emergency Power Cells");
            cmbCommodity.Items.Add("Energy Grid Assembly");
            cmbCommodity.Items.Add("Esuseku Caviar");
            cmbCommodity.Items.Add("Evacuation Shelter");
            cmbCommodity.Items.Add("Exhaust Manifold");
            cmbCommodity.Items.Add("Explosives");
            cmbCommodity.Items.Add("Fish");
            cmbCommodity.Items.Add("Food Cartridges");
            cmbCommodity.Items.Add("Fruit And Vegetables");
            cmbCommodity.Items.Add("Galactic Travel Guide");
            cmbCommodity.Items.Add("Gallite");
            cmbCommodity.Items.Add("Gallium");
            cmbCommodity.Items.Add("Geological Equipment");
            cmbCommodity.Items.Add("Gold");
            cmbCommodity.Items.Add("Goslarite");
            cmbCommodity.Items.Add("Grain");
            cmbCommodity.Items.Add("H E Suits");
            cmbCommodity.Items.Add("H N Shock Mount");
            cmbCommodity.Items.Add("H.E. Suits");
            cmbCommodity.Items.Add("H.N. Shock Mount");
            cmbCommodity.Items.Add("HE Suits");
            cmbCommodity.Items.Add("HN Shock Mount");
            cmbCommodity.Items.Add("Hafnium178");
            cmbCommodity.Items.Add("Hardware Diagnostic Sensor");
            cmbCommodity.Items.Add("Hazardous Environment Suits");
            cmbCommodity.Items.Add("Heatsink Interlink");
            cmbCommodity.Items.Add("Heliostatic Furnaces");
            cmbCommodity.Items.Add("Hydrogen Fuel");
            cmbCommodity.Items.Add("Hydrogen Peroxide");
            cmbCommodity.Items.Add("Imperial Slaves");
            cmbCommodity.Items.Add("Indite");
            cmbCommodity.Items.Add("Indium");
            cmbCommodity.Items.Add("Insulating Membrane");
            cmbCommodity.Items.Add("Ion Distributor");
            cmbCommodity.Items.Add("Jadeite");
            cmbCommodity.Items.Add("Land Enrichment Systems");
            cmbCommodity.Items.Add("Landmines");
            cmbCommodity.Items.Add("Lanthanum");
            cmbCommodity.Items.Add("Leather");
            cmbCommodity.Items.Add("Lepidolite");
            cmbCommodity.Items.Add("Liquid Oxygen");
            cmbCommodity.Items.Add("Liquor");
            cmbCommodity.Items.Add("Lithium");
            cmbCommodity.Items.Add("Lithium Hydroxide");
            cmbCommodity.Items.Add("Low Temperature Diamond");
            cmbCommodity.Items.Add("Magnetic Emitter Coil");
            cmbCommodity.Items.Add("Marine Supplies");
            cmbCommodity.Items.Add("Medical Diagnostic Equipment");
            cmbCommodity.Items.Add("Meta Alloys");
            cmbCommodity.Items.Add("Methane Clathrate");
            cmbCommodity.Items.Add("Methanol Monohydrate");
            cmbCommodity.Items.Add("Methanol Monohydrate Crystals");
            cmbCommodity.Items.Add("Micro Controllers");
            cmbCommodity.Items.Add("Micro-Weave Cooling Hoses");
            cmbCommodity.Items.Add("Military Grade Fabrics");
            cmbCommodity.Items.Add("Military Intelligence");
            cmbCommodity.Items.Add("Mineral Extractors");
            cmbCommodity.Items.Add("Mineral Oil");
            cmbCommodity.Items.Add("Modular Terminals");
            cmbCommodity.Items.Add("Moissanite");
            cmbCommodity.Items.Add("Mu Tom Imager");
            cmbCommodity.Items.Add("Nanobreakers");
            cmbCommodity.Items.Add("Narcotics");
            cmbCommodity.Items.Add("Natural Fabrics");
            cmbCommodity.Items.Add("Neofabric Insulation");
            cmbCommodity.Items.Add("Nerve Agents");
            cmbCommodity.Items.Add("Non Lethal Weapons");
            cmbCommodity.Items.Add("Occupied Cryo Pod");
            cmbCommodity.Items.Add("Osmium");
            cmbCommodity.Items.Add("Painite");
            cmbCommodity.Items.Add("Palladium");
            cmbCommodity.Items.Add("Performance Enhancers");
            cmbCommodity.Items.Add("Personal Gifts");
            cmbCommodity.Items.Add("Personal Weapons");
            cmbCommodity.Items.Add("Pesticides");
            cmbCommodity.Items.Add("Platinum");
            cmbCommodity.Items.Add("Polymers");
            cmbCommodity.Items.Add("Power Converter");
            cmbCommodity.Items.Add("Power Generators");
            cmbCommodity.Items.Add("Power Grid Assembly");
            cmbCommodity.Items.Add("Power Transfer Conduits");
            cmbCommodity.Items.Add("Praseodymium");
            cmbCommodity.Items.Add("Progenitor Cells");
            cmbCommodity.Items.Add("Pyrophyllite");
            cmbCommodity.Items.Add("Radiation Baffle");
            cmbCommodity.Items.Add("Reactive Armour");
            cmbCommodity.Items.Add("Reinforced Mounting Plate");
            cmbCommodity.Items.Add("Resonating Separators");
            cmbCommodity.Items.Add("Robotics");
            cmbCommodity.Items.Add("Rutile");
            cmbCommodity.Items.Add("Samarium");
            cmbCommodity.Items.Add("Scrap");
            cmbCommodity.Items.Add("Semiconductors");
            cmbCommodity.Items.Add("Silver");
            cmbCommodity.Items.Add("Skimer Components");
            cmbCommodity.Items.Add("Slaves");
            cmbCommodity.Items.Add("Structural Regulators");
            cmbCommodity.Items.Add("Superconductors");
            cmbCommodity.Items.Add("Surface Stabilisers");
            cmbCommodity.Items.Add("Survival Equipment");
            cmbCommodity.Items.Add("Synthetic Fabrics");
            cmbCommodity.Items.Add("Synthetic Meat");
            cmbCommodity.Items.Add("Synthetic Reagents");
            cmbCommodity.Items.Add("Taaffeite");
            cmbCommodity.Items.Add("Tantalum");
            cmbCommodity.Items.Add("Tea");
            cmbCommodity.Items.Add("Telemetry Suite");
            cmbCommodity.Items.Add("Terrain Enrichment Systems");
            cmbCommodity.Items.Add("Thallium");
            cmbCommodity.Items.Add("Thermal Cooling Units");
            cmbCommodity.Items.Add("Thorium");
            cmbCommodity.Items.Add("Thrutis Cream");
            cmbCommodity.Items.Add("Titanium");
            cmbCommodity.Items.Add("Tobacco");
            cmbCommodity.Items.Add("U S S Cargo Ancient Artefact");
            cmbCommodity.Items.Add("U S S Cargo Experimental Chemicals");
            cmbCommodity.Items.Add("U S S Cargo Military Plans");
            cmbCommodity.Items.Add("U S S Cargo Prototype Tech");
            cmbCommodity.Items.Add("U S S Cargo Rebel Transmissions");
            cmbCommodity.Items.Add("U S S Cargo Technical Blueprints");
            cmbCommodity.Items.Add("U S S Cargo Trade Data");
            cmbCommodity.Items.Add("Unknown Artifact");
            cmbCommodity.Items.Add("Unknown Artifact2");
            cmbCommodity.Items.Add("Uraninite");
            cmbCommodity.Items.Add("Uranium");
            cmbCommodity.Items.Add("Water");
            cmbCommodity.Items.Add("Water Purifiers");
            cmbCommodity.Items.Add("Wine");
            cmbCommodity.Items.Add("Wreckage Components");
        }
        public static void OverlayMissions()
        {
            var Factions = new Dictionary<string, int>();
            //Now we go through the missions to find massacres.

            foreach (DataRow row in frmMain.dataSystems.Tables["Overlay"].Rows)
            {
                if((string)row["Type"] == "MASSACRE") //An incomplete massacre mission! this is the dream!
                {
                    int Remain = (int)row["TargetCount"] - (int)row["TargetCountKilled"];

                    string Faction = "\"" + (string)row["TargetFaction"] + "\" " + (string)row["TargetType"];

                    int Count = 0;
                    if(Factions.TryGetValue(Faction, out Count))
                    {
                        if (Count < Remain)
                        {
                            Factions[Faction] = Remain;
                        }
                    }else
                    {
                        Factions.Add(Faction, Remain);
                    }
                }
            }

            //Create the text
            var Text = "";
            if (Factions.Count() > 0)
            {
                foreach(var Faction in Factions)
                {
                    Text = Text + Faction.Value.ToString() + " x " + Faction.Key + Environment.NewLine;
                }
            }

            //Set the overlay text (will only work if the form is open).
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
                            control.Text = Text;
                        }
                    }
                }
            }
        }
    }

}
