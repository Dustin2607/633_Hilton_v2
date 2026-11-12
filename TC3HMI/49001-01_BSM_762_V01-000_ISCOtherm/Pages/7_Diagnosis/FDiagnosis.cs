namespace App
{
    using System;
    using System.IO;
    using System.Collections;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Text;
    using System.Windows.Forms;

    using TwinCAT.App;
    using TwinCAT.App.EventLogger;
    using TwinCAT.Ads;

    using App.Utility;
    using App.Components;

    public partial class FDiagnosis : Form
    {
        #region Member enummerations

        #endregion

        #region Member variables

        // TwinCAT references
        private TcAdsClient adsClient;

        // Application
        private FMainApp frmMainApp;
        private Form parentForm;
        private FMain frmMain;

        private CLanguageManager lm;

        private Timer tmrCheckFreeSpace;

        // Set color theme
        private Color colorCaption;
        private Color colorRow2;
        private Color colorRow3;

        #endregion

        #region Systemcode

        #region Constructor

        /// <summary>
        /// Constructor FDiagnosis.
        /// </summary>
        public FDiagnosis(Form f)
        {
            parentForm = f;

            InitializeComponent();

            // Get language manager
            lm = CMainApp.GetMainAppForm().GetLanguageManager();

            // Init event logger
            this.tcEventLoggerData1.EventList = this.tcEventItemList1;
            this.tcEventLoggerList1.TcEventLogData = this.tcEventLoggerData1;

            adsClient = CMainApp.GetMainAppForm().AdsClientRef;

            //tmrCheckFreeSpace = new Timer();
            //tmrCheckFreeSpace.Enabled = true;
            //tmrCheckFreeSpace.Interval = 10000;//600000;
            //tmrCheckFreeSpace.Start();
            //tmrCheckFreeSpace.Tick += TmrCheckFreeSpace_Tick;

            FDiagnosis_Load(this, null);
        }

        #endregion

        #endregion

        #region Properties

        /// <summary>
        /// Gets / sets the backcolor of the caption.
        /// </summary>
        /// <value>The backcolor of the caption.</value>
        [Description("Gets / sets the backcolor of the caption."), Category("App")]
        public Color CaptionBackColor
        {
            get { return colorCaption; }
            set
            {
                colorCaption = value;
                lblWindowTitle.BackColor = colorCaption;
                //frmMessages.CaptionBackColor = colorCaption;

            }
        }

        /// <summary>
        /// Gets / sets the color of the second row.
        /// </summary>
        /// <value>The color of the second row.</value>
        [Description("The color / the second row."), Category("App")]
        public Color ColorRow2
        {
            get { return colorRow2; }
            set
            {
                colorRow2 = value;
            }
        }

        /// <summary>
        /// Gets / sets the color of the third row.
        /// </summary>
        /// <value>The color of the third row.</value>
        [Description("Gets / sets the color of the third row."), Category("App")]
        public Color ColorRow3
        {
            get { return colorRow3; }
            set
            {
                colorRow3 = value;

            }
        }

        /// <summary>
        /// Gets the language manager.
        /// </summary>
        /// <value>The language manager.</value>
        [DefaultValue(1)]
        [Description("Gets the language manager."), Category("App")]
        public CLanguageManager LanguageManager
        {
            set { this.lm = value; }
        }

        #endregion

        #region User interface

        #endregion

        #region Events

        #region Form Events

        private void FDiagnosis_Activated(object sender, EventArgs e)
        {
            SetFunctionKeys(CMainApp.GetMainAppForm().tcFKeyBottom);

            tcEventLoggerList1.Focus();
        }

        private void FDiagnosis_Load(object sender, EventArgs e)
        {
            frmMain = CMainApp.GetMainAppForm().frmMain;
            frmMainApp = CMainApp.GetMainAppForm();

            lm.StringDel += new CLanguageManager.InitStringDelegate(LoadLanguageStrings);
            LoadLanguageStrings();

            // Variables update
            GetAlarmsGr00ALARM();
            GetAlarmsGr01ALARM();
            GetAlarmsGr02ALARM();
            GetAlarmsGr05ALARM();

            frmMainApp.OnError += new System.EventHandler<App.FMainApp.OnErrorArgs>(this.frmMainApp_OnError);
            frmMainApp.OnEvent += new System.EventHandler<App.FMainApp.OnEventArgs>(this.frmMainApp_OnEvent);

        }

        private void frmMainApp_OnError(object sender, FMainApp.OnErrorArgs efrmMainOnErrortArgs)
        {

        }

        private void frmMainApp_OnEvent(object sender, FMainApp.OnEventArgs efrmMainOnEventArgs)
        {
            switch ((int)efrmMainOnEventArgs.EventType)
            {
                case 100: // ST_Gr00ALARM
                    GetAlarmsGr00ALARM();

                    break;

                case 101: // ST_Gr01ALARM
                    GetAlarmsGr01ALARM();

                    break;

                case 102: // ST_Gr02ALARM
                    GetAlarmsGr02ALARM();

                    break;

                case 105: // ST_Gr05ALARM
                    GetAlarmsGr05ALARM();

                    break;

            }
        }

        protected override void OnResize(EventArgs eEventArgs)
        {
            base.OnResize(eEventArgs);
            this.FormBorderStyle = FormBorderStyle.None;
            this.WindowState = FormWindowState.Maximized;
        }

        protected override void WndProc(ref Message m)
        {
            if (m.Msg == 5)
                return;
            base.WndProc(ref m);
        }

        #endregion

        #region Object Events

        private void TmrCheckFreeSpace_Tick(object sender, EventArgs e)
        {
            CheckFreeSpace();
        }

        private void tcAppEventLogData1_LogEvent(EventItem eventItem)
        {
            if (eventItem == null)
                return;

            // route message to the log4net, if an error happens...
            // if (eventItem.Class == 7)		// TCEVENTCLASS_ALARM
            //     MainApp.log.Error(eventItem.Message);
        }

        private void tcAppEventLogData1_LogInstructionEvent(EventItem eventItem)
        {
            if (eventItem == null)
                return;

            // route message to the main menu
            // MainApp.GetDoc().MainAppMsgInfo(eventItem);
        }

        #endregion

        #endregion

        #region Interface implementation

        #endregion

        #region Public functions

        /// <summary>
        /// Sets the parent form.
        /// </summary>
        [Description("Sets the parent form."), Category("App")]
        public void SetParentForm(Form f)
        {
            parentForm = f;
        }

        /// <summary>
        /// Get the event logger data.
        /// </summary>
        [Description("Get the event logger data."), Category("App")]
        public TcEventLoggerData GetEventLoggerData()
        {
            return tcEventLoggerData1;
        }

        #endregion

        #region Private methods

        private struct SourceId
        {
            public int FatalError;
            public int Error;
            public int Warning;
            public int Message;
            public int Hint;

            public SourceId(int FatalError, int Error, int Warning, int Message, int Hint)
            {
                this.FatalError = FatalError;
                this.Error = Error;
                this.Warning = Warning;
                this.Message = Message;
                this.Hint = Hint;
            }
        }

        private void SetEventItem(FMainApp.ST_AlarmProperties[] arstAlarm, int sourceId, string sourceName, string alarmName, int itemClass)
        {
            for (int id = 0; id < arstAlarm.Length; id++)
            {
                // Check byte status
                if (arstAlarm[id].bActive)
                {
                    // Check if item is already in list
                    bool found = false;
                    foreach (EventItem element in tcEventLoggerData1.EventList.ArrEventList)
                    {
                        if (element.SourceId == sourceId
                            && element.Id == id)
                        {
                            found = true;
                            break;
                        }
                    }

                    // Create new event item if item not found
                    if (!found)
                    {
                        // Create new event item
                        var eventItem = new EventItem();

                        eventItem.Date = DateTime.Now;
                        eventItem.SourceName = sourceName;
                        eventItem.MustConfirm = 0;
                        eventItem.SourceId = sourceId;
                        eventItem.Id = id;
                        eventItem.Message = lm[sourceName + "[" + sourceId + "]." + alarmName + "[" + id + "]"];
                        eventItem.Class = itemClass;

                        // Add item to event logger
                        this.tcEventLoggerData1.EventList.Add(eventItem);
                        this.tcEventLoggerList1.TcEventLogData = this.tcEventLoggerData1;
                    }

                }
                else
                {
                    foreach (EventItem element in tcEventLoggerData1.EventList.ArrEventList)
                    {
                        // Check if item is already in list
                        if (element.SourceId == sourceId
                            && element.Id == id)
                        {
                            // Remove item from event logger
                            this.tcEventLoggerData1.EventList.Remove(element);
                            this.tcEventLoggerList1.TcEventLogData = this.tcEventLoggerData1;
                            break;
                        }
                    }
                }
            }
        }


        private void SetEventItem(int id, int sourceId, string sourceName, string alarmName, int itemClass)
        {

            // Check if item is already in list
            bool found = false;
            foreach (EventItem element in tcEventLoggerData1.EventList.ArrEventList)
            {
                if (element.SourceId == sourceId
                    && element.Id == id)
                {
                    found = true;
                    break;
                }
            }

            // Create new event item if item not found
            if (!found)
            {
                // Create new event item
                var eventItem = new EventItem();

                eventItem.Date = DateTime.Now;
                eventItem.SourceName = sourceName;
                eventItem.MustConfirm = 0;
                eventItem.SourceId = sourceId;
                eventItem.Id = id;
                eventItem.Message = alarmName;//lm[sourceName + "[" + sourceId + "]." + alarmName + "[" + id + "]"];
                eventItem.Class = itemClass;

                // Add item to event logger
                this.tcEventLoggerData1.EventList.Add(eventItem);
                this.tcEventLoggerList1.TcEventLogData = this.tcEventLoggerData1;
            }

        }


        private void RegisterAlarmState(FMainApp.ST_AlarmOut alarmOut, SourceId sourceId, string sourceName)
        {
            // Check fatal error
            if (alarmOut.bFatalError)
            {
                SetEventItem(alarmOut.arbFatalError, sourceId.FatalError, sourceName, "FatalError", TcEventConst.Class.ALARM);
            }
            else
            {
                // Remove all items with source Id from event logger
                foreach (EventItem element in (new ArrayList(tcEventLoggerData1.EventList.ArrEventList)))
                {
                    if (element.SourceId == sourceId.FatalError)
                    {
                        tcEventLoggerData1.EventList.ArrEventList.Remove(element);
                    }
                }

                this.tcEventLoggerList1.TcEventLogData = this.tcEventLoggerData1;

            }

            // Check error
            if (alarmOut.bError)
            {
                SetEventItem(alarmOut.arbError, sourceId.Error, sourceName, "Error", TcEventConst.Class.ALARM);
            }
            else
            {
                // Remove all items with source Id from event logger
                foreach (EventItem element in (new ArrayList(tcEventLoggerData1.EventList.ArrEventList)))
                {
                    if (element.SourceId == sourceId.Error)
                    {
                        tcEventLoggerData1.EventList.ArrEventList.Remove(element);
                    }
                }

                this.tcEventLoggerList1.TcEventLogData = this.tcEventLoggerData1;

            }

            // Check warning
            if (alarmOut.bWarning)
            {
                SetEventItem(alarmOut.arbWarning, sourceId.Warning, sourceName, "Warning", TcEventConst.Class.WARNING);
            }
            else
            {
                // Remove all items with source Id from event logger
                foreach (EventItem element in (new ArrayList(tcEventLoggerData1.EventList.ArrEventList)))
                {
                    if (element.SourceId == sourceId.Warning)
                    {
                        tcEventLoggerData1.EventList.ArrEventList.Remove(element);
                    }
                }

                this.tcEventLoggerList1.TcEventLogData = this.tcEventLoggerData1;

            }

            // Check message
            if (alarmOut.bMessage)
            {
                SetEventItem(alarmOut.arbMessage, sourceId.Message, sourceName, "Message", TcEventConst.Class.MESSAGE);
            }
            else
            {
                // Remove all items with source Id from event logger
                foreach (EventItem element in (new ArrayList(tcEventLoggerData1.EventList.ArrEventList)))
                {
                    if (element.SourceId == sourceId.Message)
                    {
                        tcEventLoggerData1.EventList.ArrEventList.Remove(element);
                    }
                }

                this.tcEventLoggerList1.TcEventLogData = this.tcEventLoggerData1;

            }

            // Check hint
            if (alarmOut.bHint)
            {
                SetEventItem(alarmOut.arbHint, sourceId.Hint, sourceName, "Hint", TcEventConst.Class.HINT);
            }
            else
            {
                // Remove all items with source Id from event logger
                foreach (EventItem element in (new ArrayList(tcEventLoggerData1.EventList.ArrEventList)))
                {
                    if (element.SourceId == sourceId.Hint)
                    {
                        tcEventLoggerData1.EventList.ArrEventList.Remove(element);
                    }
                }

                this.tcEventLoggerList1.TcEventLogData = this.tcEventLoggerData1;

            }

        }

        private void CheckFreeSpace()
        {
            StringBuilder text = new StringBuilder();
            DriveInfo[] allDrives = DriveInfo.GetDrives();

            // Convert bytes to megabytes and gigabytes
            const double BytesInMB = 1048576;
            const double BytesInGB = 1073741824;

            int driveIdx = 0;
             
            foreach (DriveInfo drive in allDrives)
            {
                
                if (drive.IsReady && (drive.Name == "C:\\" || drive.Name == "D:\\"))
                {
                    driveIdx += 1;

                    // Clear text
                    text.Length = 0;

                    // Calculate the percentage free space
                    double freeSpacePerc =
                        (drive.AvailableFreeSpace / (float)drive.TotalSize) * 100;

                    if (freeSpacePerc < 10)
                    {

                        text.AppendFormat(" ");
                        text.AppendFormat(lm["_String.Percentagefreespace"]);
                        text.AppendFormat(" {0:0.0}%. ", freeSpacePerc);

                        // Ouput drive information
                        text.AppendFormat(lm["_String.Drive"]);
                        text.AppendFormat(" {0}", drive.Name);

                        // Show the used and total size in MB and GB, with two decimals
                        //text.AppendFormat(" Used space:\t{0:0.00} MB\t{1:0.00} GB",
                        //    (drive.TotalSize - drive.TotalFreeSpace) / BytesInMB,
                        //    (drive.TotalSize - drive.TotalFreeSpace) / BytesInGB);

                        //text.AppendFormat(" Total size:\t{0:0.00} MB\t{1:0.00} GB",
                        //    drive.TotalSize / BytesInMB,
                        //    drive.TotalSize / BytesInGB);

                        text.AppendFormat(" ");
                        text.AppendFormat(lm["_String.Total"] + " {0:0.00} GB" + " / " + lm["_String.Used"] + " {1:0.00} GB.",
                                drive.TotalSize / BytesInGB,
                                (drive.TotalSize - drive.TotalFreeSpace) / BytesInGB);


                        SetEventItem(driveIdx, driveIdx, "intern", text.ToString(), TcEventConst.Class.MESSAGE);

                    }
                    else
                    {
                        // Remove all items with source Id from event logger
                        foreach (EventItem element in (new ArrayList(tcEventLoggerData1.EventList.ArrEventList)))
                        {
                            if (element.SourceId == driveIdx)
                            {
                                tcEventLoggerData1.EventList.ArrEventList.Remove(element);
                            }
                        }

                        this.tcEventLoggerList1.TcEventLogData = this.tcEventLoggerData1;
                    }
                }
            }
        }

        private void LoadLanguageStrings()
        {
            lblWindowTitle.Text = lm["FDiagnosis.WindowTitle"];
        }

        #region Gr00 alarms update

        private void GetAlarmsGr00ALARM()
        {
            try
            {
                // Initialize source Id:  
                var sourceIdControl = new SourceId(01000, 01100, 01200, 01300, 01400);
                var sourceIdAuto = new SourceId(02000, 02100, 02200, 02300, 02400);
                var sourceIdHome = new SourceId(03000, 03100, 03200, 03300, 03400);
                var sourceIdManual = new SourceId(04000, 04100, 04200, 04300, 04400);

                // Alarm regidter
                RegisterAlarmState(frmMainApp.Gr00ALARM.stControl, sourceIdControl, "Gr00AlarmControl");
                RegisterAlarmState(frmMainApp.Gr00ALARM.stAuto, sourceIdAuto, "Gr00AlarmAuto");
                RegisterAlarmState(frmMainApp.Gr00ALARM.stHome, sourceIdHome, "Gr00AlarmHome");
                RegisterAlarmState(frmMainApp.Gr00ALARM.stManual, sourceIdManual, "Gr00AlarmManual");

            }
            catch
            {

            }

        }

        #endregion

        #region Gr01 alarms update

        private void GetAlarmsGr01ALARM()
        {
            try
            {
                // Initialize source Id:  
                var sourceIdControl = new SourceId(11000, 11100, 11200, 11300, 11400);
                var sourceIdAuto = new SourceId(12000, 12100, 12200, 12300, 12400);
                var sourceIdHome = new SourceId(13000, 13100, 13200, 13300, 13400);
                var sourceIdManual = new SourceId(14000, 14100, 14200, 14300, 14400);

                // Alarm regidter
                RegisterAlarmState(frmMainApp.Gr01ALARM.stControl, sourceIdControl, "Gr01AlarmControl");
                RegisterAlarmState(frmMainApp.Gr01ALARM.stAuto, sourceIdAuto, "Gr01AlarmAuto");
                RegisterAlarmState(frmMainApp.Gr01ALARM.stHome, sourceIdHome, "Gr01AlarmHome");
                RegisterAlarmState(frmMainApp.Gr01ALARM.stManual, sourceIdManual, "Gr01AlarmManual");

            }
            catch
            {

            }
        }

        #endregion

        #region Gr02 alarms update

        private void GetAlarmsGr02ALARM()
        {

            try
            {
                // Initialize source Id:  
                var sourceIdControl = new SourceId(21000, 21100, 21200, 21300, 21400);
                var sourceIdAuto = new SourceId(22000, 22100, 22200, 22300, 22400);
                var sourceIdHome = new SourceId(23000, 23100, 23200, 23300, 23400);
                var sourceIdManual = new SourceId(24000, 24100, 24200, 24300, 24400);

                // Alarm regidter
                RegisterAlarmState(frmMainApp.Gr02ALARM.stControl, sourceIdControl, "Gr02AlarmControl");
                RegisterAlarmState(frmMainApp.Gr02ALARM.stAuto, sourceIdAuto, "Gr02AlarmAuto");
                RegisterAlarmState(frmMainApp.Gr02ALARM.stHome, sourceIdHome, "Gr02AlarmHome");
                RegisterAlarmState(frmMainApp.Gr02ALARM.stManual, sourceIdManual, "Gr02AlarmManual");

            }
            catch
            {

            }

        }

        #endregion

        #region Gr05 alarms update

        private void GetAlarmsGr05ALARM()
        {
            try
            {
                // Initialize source Id:  
                var sourceIdControl = new SourceId(51000, 51100, 51200, 51300, 51400);
                var sourceIdAuto = new SourceId(52000, 52100, 52200, 52300, 52400);
                var sourceIdHome = new SourceId(53000, 53100, 53200, 53300, 53400);
                var sourceIdManual = new SourceId(54000, 54100, 54200, 54300, 54400);

                // Alarm regidter
                RegisterAlarmState(frmMainApp.Gr05ALARM.stControl, sourceIdControl, "Gr05AlarmControl");
                RegisterAlarmState(frmMainApp.Gr05ALARM.stAuto, sourceIdAuto, "Gr05AlarmAuto");
                RegisterAlarmState(frmMainApp.Gr05ALARM.stHome, sourceIdHome, "Gr05AlarmHome");
                RegisterAlarmState(frmMainApp.Gr05ALARM.stManual, sourceIdManual, "Gr05AlarmManual");

            }
            catch
            {

            }
        }

        #endregion

        #endregion

        #region Implementation of Function Keys

        private void SetFunctionKeys(TcFKey fKey)
        {
            fKey.InstallFKeyDelegate(new FKeyDelegate(FKeyDownEvent), new FKeyDelegate(FKeyUpEvent));
            fKey.FKeyTextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            fKey.FKeyImageAlign = System.Drawing.ContentAlignment.MiddleCenter;
            SetFKeyText(fKey);
        }

        private void SetFKeyText(TcFKey fKey)
        {
            fKey.FKeyText(1, ""); 			                                                            //""
            fKey.FKeyText(2, ""); 			                                                            //""
            fKey.FKeyText(3, ""); 			                                                            //""
            fKey.FKeyText(4, "");                                                                       //""
            fKey.FKeyText(5, "");                                                                       //""
            fKey.FKeyText(6, "");	                                                                    //""
            fKey.FKeyText(7, lm["FDiagnosis.FKey[7]"], null, System.Drawing.Color.DarkBlue);	        //"RESET"
            fKey.FKeyText(8, "");	                                                                    //""
            fKey.FKeyText(9, lm["FDiagnosis.FKey[9]"]);	                                                //"Close"
        }

        private void FKeyUpEvent(int nIdx)
        {
            switch (nIdx)
            {
                case 1:

                    break;

                case 2:

                    break;

                case 3:

                    break;
                case 4:

                    break;
                case 5:

                    break;

                case 6:

                    break;

                case 7:
                    frmMainApp.mWritePLCValue(".stgGr00HMI.stHMITOPLC.bBtnReset", (Boolean)false);

                    break;

                case 8:

                    break;

                case 9:
                    parentForm.BringToFront();
                    //this.Close();

                    break;
            }
        }

        private void FKeyDownEvent(int nIdx)
        {
            switch (nIdx)
            {
                case 1:

                    break;

                case 2:

                    break;

                case 3:

                    break;

                case 4:

                    break;

                case 5:

                    break;

                case 6:

                    break;

                case 7:
                    frmMainApp.mWritePLCValue(".stgGr00HMI.stHMITOPLC.bBtnReset", true);

                    break;

                case 8:
                    break;

                case 9:

                    break;
            }

        }

        #endregion

    }
}
