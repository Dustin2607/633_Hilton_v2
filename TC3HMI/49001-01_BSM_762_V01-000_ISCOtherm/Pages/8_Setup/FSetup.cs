namespace App
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Diagnostics;
    using System.Text;
    using System.Windows.Forms;

    using TwinCAT.App;
    using TwinCAT.Ads;

    using App.Utility;
    using App.Components;
    using App.Security;
    using App.Pages.Setup;

    public partial class FSetup : Form
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
        private FSetup1 frmSetup1;

        private CLanguageManager lm;

        // Set color theme
        private Color colorCaption;
        private Color colorRow2;
        private Color colorRow3;

        #endregion

        #region Systemcode

        #region Constructor

        /// <summary>
        /// Constructor FSetup.
        /// </summary>
        public FSetup(Form f)
        {
            parentForm = f;

            InitializeComponent();

            // Get language manager
            lm = CMainApp.GetMainAppForm().GetLanguageManager();

            // Create form objects
            frmSetup1 = new FSetup1(this);

            ucBtnResetCounter.LanguageManager = lm;

            ucCVCounterTotal.LanguageManager = lm;
            ucCVCounterUser.LanguageManager = lm;

            ucBtnResetLifetimeDevice.LanguageManager = lm;

            ucCVLifetimeDevice.LanguageManager = lm;
            ucCVLifetimeDeviceRst.LanguageManager = lm;
            ucCVLifetimeDeviceOn.LanguageManager = lm;

            adsClient = CMainApp.GetMainAppForm().AdsClientRef;
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
                frmSetup1.CaptionBackColor = colorCaption;

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

        private void FSetup_Activated(object sender, EventArgs e)
        {
            SetFunctionKeys(CMainApp.GetMainAppForm().tcFKeyBottom);
        }

        private void FSetup_Load(object sender, EventArgs e)
        {
            frmMain = CMainApp.GetMainAppForm().frmMain;
            frmMainApp = CMainApp.GetMainAppForm();

            lm.StringDel += new CLanguageManager.InitStringDelegate(LoadLanguageStrings);
            LoadLanguageStrings();

            SetBtnOn(ucBtnResetCounter);
            SetBtnOn(ucBtnResetLifetimeDevice);

            // Variables update
            GetVariablesGr00HMITOPLC();
            GetVariablesGr00PLCTOHMI();
            GetVariablesGr01HMITOPLC();
            GetVariablesGr01PLCTOHMI();
            GetVariablesGr02HMITOPLC();
            GetVariablesGr02PLCTOHMI();
            GetVariablesGr05HMITOPLC();
            GetVariablesGr05PLCTOHMI();

            // Get events
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
                case 10: // ST_Gr00HMITOPLC
                    GetVariablesGr00HMITOPLC();

                    break;

                case 11: // ST_Gr00PLCTOHMI
                    GetVariablesGr00PLCTOHMI();

                    break;

                case 12: // ST_Gr01HMITOPLC
                    GetVariablesGr01HMITOPLC();

                    break;

                case 13: // ST_Gr01PLCTOHMI
                    GetVariablesGr01PLCTOHMI();

                    break;

                case 14: // ST_Gr02HMITOPLC
                    GetVariablesGr02HMITOPLC();

                    break;

                case 15: // ST_Gr02PLCTOHMI
                    GetVariablesGr02PLCTOHMI();

                    break;

                case 20: // ST_Gr05HMITOPLC
                    GetVariablesGr05HMITOPLC();

                    break;

                case 21: // ST_Gr05PLCTOHMI
                    GetVariablesGr05PLCTOHMI();

                    break;

            }
        }

        protected override void OnResize(EventArgs eEventArgs)
        {
            base.OnResize(eEventArgs);
            this.FormBorderStyle = FormBorderStyle.None;
            this.WindowState = FormWindowState.Maximized;
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            base.OnClosing(e);

            frmMainApp.OnError -= new System.EventHandler<App.FMainApp.OnErrorArgs>(this.frmMainApp_OnError);
            frmMainApp.OnEvent -= new System.EventHandler<App.FMainApp.OnEventArgs>(this.frmMainApp_OnEvent);
        }

        protected override void WndProc(ref Message m)
        {
            if (m.Msg == 5)
                return;
            base.WndProc(ref m);
        }

        #endregion

        #region Object Events

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

        #endregion

        #region Private methods

        private void LoadLanguageStrings()
        {
            lblWindowTitle.Text = lm["FSetup.WindowTitle"];
            gbxCounter.Text = lm["gbxCounter"];
            gbxLifetimeDevice.Text = lm["gbxLifetimeDevice"];
        }

        #region Gr00 variables update

        private void GetVariablesGr00HMITOPLC()
        {

        }

        private void GetVariablesGr00PLCTOHMI()
        {
            try
            {
                ucCVCounterTotal.ActValue = frmMainApp.Gr00PLCTOHMI.udnCounterTotal.ToString();
                ucCVCounterUser.ActValue = frmMainApp.Gr00PLCTOHMI.udnCounterUser.ToString();

            }
            catch
            {

            }
        }

        #endregion

        #region Gr01 variables update

        private void GetVariablesGr01HMITOPLC()
        {

            try
            {

            }
            catch
            {

            }

        }

        private void GetVariablesGr01PLCTOHMI()
        {
            try
            {
                ucCVLifetimeDevice.ActValue = CUtility.DoFormat1(frmMainApp.Gr01PLCTOHMI.lrLifetime.ToString());
                ucCVLifetimeDeviceRst.ActValue = CUtility.DoFormat1(frmMainApp.Gr01PLCTOHMI.lrLifetimeAfterReset.ToString());
                ucCVLifetimeDeviceOn.ActValue = CUtility.DoFormat1(frmMainApp.Gr01PLCTOHMI.lrLifetimeAfterTurnOn.ToString());
            }
            catch
            {

            }
        }

        #endregion

        #region Gr02 variables update

        private void GetVariablesGr02HMITOPLC()
        {

        }

        private void GetVariablesGr02PLCTOHMI()
        {
            try
            {

            }
            catch
            {

            }

        }

        #endregion

        #region Gr05 variables update

        private void GetVariablesGr05HMITOPLC()
        {

        }

        private void GetVariablesGr05PLCTOHMI()
        {

        }

        #endregion

        #endregion

        #region Implementation of Fields

        private void SetBtnOn(UCButtonOn uc)
        {
            uc.InstallWritePLCValueDelegate(
                new WritePLCValueDelegate(frmMainApp.mWritePLCValue)
            );
        }

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
            fKey.FKeyText(1, ""); 			                        //""
            fKey.FKeyText(2, ""/*lm["FSetup.FKey[2]"]*/); 			    //"User"
            fKey.FKeyText(3, ""/*lm["FSetup.FKey[3]"]*/); 			    //"User manager"
            fKey.FKeyText(4, "");			                        //""
            fKey.FKeyText(5, "");                                   //""
            fKey.FKeyText(6, "");	                                //""
            fKey.FKeyText(7, "");	                                //""
            fKey.FKeyText(8, ""/*lm["FSetup.FKey[8]"]*/);	        //"Open scope" 
            fKey.FKeyText(9, lm["FSetup.FKey[9]"]);	                //"Close" 
        }

        private void FKeyUpEvent(int nIdx)
        {

            switch (nIdx)
            {
                case 1:
                    this.SuspendLayout();
                    frmSetup1.MdiParent = this.MdiParent;
                    frmSetup1.Show();
                    frmSetup1.BringToFront();
                    this.ResumeLayout();

                    break;

                case 2:
                    frmMainApp.userManager.LoginDialog(false, false);

                    break;

                case 3:
                    frmMainApp.userManager.UserManagerDialog();

                    break;
                case 4:

                    break;
                case 5:

                    break;

                case 6:

                    break;

                case 7:

                    break;

                case 8:

                    if (frmMainApp.userManager.CurrentUserLevel > CUserLevel.Standarduser)
                    {
                        frmMainApp.userManager.LoginDialog(false, false);
                    }

                    if (frmMainApp.userManager.CurrentUserLevel <= CUserLevel.Standarduser)
                    {
                        //ProcessStartInfo startInfo = new ProcessStartInfo();
                        //startInfo.FileName = "D:\TwinCAT Measurement Project4";
                        ////startInfo.Arguments = f;
                        //Process.Start(startInfo);

                        // Use ProcessStartInfo class
                        ProcessStartInfo startInfo = new ProcessStartInfo();
                        //startInfo.CreateNoWindow = false;
                        //startInfo.UseShellExecute = false;
                        startInfo.FileName = @"C:\Riex\Scope\Scope project\Scope project.sln";
                        startInfo.WindowStyle = ProcessWindowStyle.Maximized;
                        //startInfo.Arguments = "-f j -o \"" + ex1 + "\" -z 1.0 -s y " + ex2;

                        try
                        {
                            // Start the process with the info we specified.
                            // Call WaitForExit and then the using statement will close.
                            using (Process exeProcess = Process.Start(startInfo))
                            {
                                exeProcess.WaitForExit();
                            }
                        }
                        catch
                        {
                            // Log error.
                        }
                    }

                    break;

                case 9:
                    parentForm.BringToFront();
                    //this.Close();

                    break;
            }
        }

        private void FKeyDownEvent(int nIdx)
        {

        }

        #endregion
    }
}
