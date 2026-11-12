namespace App
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Text;
    using System.Windows.Forms;

    using TwinCAT.App;
    using TwinCAT.Ads;

    using App.Utility;
    using App.Components;
    using App.Pages.Operation.Automatic;

    public partial class FAutomatic : Form
    {
        #region Member enummerations

        #endregion

        #region Member variables

        // TwinCAT references
        private TcAdsClient adsClient;

        // Application
        private FMainApp frmMainApp;
        private Form parentForm;
        private UCAutomatic1 ucAutomatic1;
        private UCAutomatic2 ucAutomatic2;
        private FMain frmMain;
        private CShowForm ShowOpMode;

        private CLanguageManager lm;

        // Set color theme
        private Color colorCaption;
        private Color colorRow2;
        private Color colorRow3;

        #endregion

        #region Systemcode

        #region Constructor

        /// <summary>
        /// Constructor FAutomatic.
        /// </summary>
        public FAutomatic(Form f)
        {
            parentForm = f;

            InitializeComponent();

            // Get language manager
            lm = CMainApp.GetMainAppForm().GetLanguageManager();

            ucOverride1.LanguageManager = lm;
            ucSawbandSpeed.LanguageManager = lm;

            // Create form objects
            ucAutomatic1 = new UCAutomatic1(this);
            ucAutomatic1.LanguageManager = lm;
            ucAutomatic2 = new UCAutomatic2(this);
            ucAutomatic2.LanguageManager = lm;

            // Create operation mode selector
            ShowOpMode = new CShowForm(10, 10, 5);

            // Loading user controls
            panel1.Controls.Add(ucAutomatic1);
            panel1.Controls.Add(ucAutomatic2);

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

                ucAutomatic1.CaptionBackColor = colorCaption;
                ucAutomatic2.CaptionBackColor = colorCaption;

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
            get { return this.lm; }
        }

        #endregion

        #region User interface

        #endregion

        #region Events

        #region Form Events

        private void FAutomatic_Activated(object sender, EventArgs e)
        {
            // Set automatic mode
            CMainApp.GetMainAppForm().mWritePLCValue(".stgGr00HMI.stHMITOPLC.etMachineMode", (short)1);

            SetFunctionKeys(CMainApp.GetMainAppForm().tcFKeyBottom);
            SetOpModeKeys(tcOpModeKey);
        }

        private void FAutomatic_Load(object sender, EventArgs e)
        {
            frmMain = CMainApp.GetMainAppForm().frmMain;
            frmMainApp = CMainApp.GetMainAppForm();

            ucOverride1.SerUserManager(frmMainApp.userManager);
            ucSawbandSpeed.SerUserManager(frmMainApp.userManager);

            ucAutomatic1.BringToFront();

            lm.StringDel += new CLanguageManager.InitStringDelegate(LoadLanguageStrings);
            LoadLanguageStrings();

            SetOverride(ucOverride1);
            SetOverride(ucSawbandSpeed);

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

        }

        private bool IsControlAtFront(Control control)
        {
            if (control.Parent != null)
            {
                if (control.Parent.Controls.GetChildIndex(control) == 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            return false;
        }

        #region Gr00 variables update

        private void GetVariablesGr00HMITOPLC()
        {
            try
            {
                ucOverride1.ActValue = frmMainApp.Gr00HMITOPLC.rOverride.ToString();
            }
            catch
            {

            }
        }

        private void GetVariablesGr00PLCTOHMI()
        {
            try
            {

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
                ucSawbandSpeed.ActValue = frmMainApp.Gr01HMITOPLC.rSawbandAutoSpeed.ToString();
            }
            catch
            {

            }
        }

        private void GetVariablesGr01PLCTOHMI()
        {
            try
            {

            }
            catch
            {

            }

        }

        #endregion

        #region Gr02 variables update

        private void GetVariablesGr02HMITOPLC()
        {
            try
            {

            }
            catch
            {

            }
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
            try
            {

            }
            catch
            {

            }
        }

        private void GetVariablesGr05PLCTOHMI()
        {
            try
            {

            }
            catch
            {

            }
        }

        #endregion

        #endregion

        #region Implementation of Fields

        private void SetOverride(UCOverride uc)
        {
            uc.tbxValue.InstallWritePLCValueDelegate(
                new WritePLCValueDelegate(frmMainApp.mWritePLCValue)
            );
            uc.InstallWritePLCValueDelegate(
                new WritePLCValueDelegate(frmMainApp.mWritePLCValue)
            );
        }

        #endregion

        #region Implementation of Function Keys

        #region Function keys

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
            fKey.FKeyText(2, ""/*lm["FAutomatic.FKey[2]"]*/); 			                                //"Statistic" 3
            fKey.FKeyText(3, lm["FAutomatic.FKey[3]"]); 			                                    //"Operation mode"
            fKey.FKeyText(4, "");                                                                       //""
            fKey.FKeyText(5, lm["FAutomatic.FKey[5]"], null, System.Drawing.Color.Green);               //"START"
            fKey.FKeyText(6, lm["FAutomatic.FKey[6]"], null, System.Drawing.Color.Red);	                //"STOP"
            fKey.FKeyText(7, lm["FAutomatic.FKey[7]"], null, System.Drawing.Color.DarkBlue);	        //"RESET"
            fKey.FKeyText(8, "");	                                                                    //""
            fKey.FKeyText(9, ""/*lm["FAutomatic.FKey[9]"]*/);	                                                //"Close"

        }

        private void FKeyUpEvent(int nIdx)
        {
            switch (nIdx)
            {
                case 1:

                    break;

                case 2:
                    if (IsControlAtFront(ucAutomatic1) == true)
                    {
                        ucAutomatic2.Visible = false;
                        ucAutomatic2.BringToFront();
                        ucAutomatic2.Visible = true;
                    }
                    else
                    {
                        ucAutomatic1.Visible = false;
                        ucAutomatic1.BringToFront();
                        ucAutomatic1.Visible = true;
                    }

                    break;

                case 3:
                    if (tcOpModeKey.Visible == false)
                        ShowOpMode.OpenYBottom(this, tcOpModeKey, true);

                    break;

                case 4:

                    break;

                case 5:
                    frmMainApp.mWritePLCValue(".stgGr00HMI.stHMITOPLC.bBtnStart", (Boolean)false);

                    break;

                case 6:
                    frmMainApp.mWritePLCValue(".stgGr00HMI.stHMITOPLC.bBtnStop", (Boolean)false);

                    break;

                case 7:
                    frmMainApp.mWritePLCValue(".stgGr00HMI.stHMITOPLC.bBtnReset", (Boolean)false);

                    break;

                case 8:

                    break;

                case 9:
                    //this.Close();

                    break;
            }
        }

        private void FKeyDownEvent(int nIdx)
        {
            // Hide operation mode selector
            if (tcOpModeKey.Visible == true)
                ShowOpMode.Close(0);

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
                    frmMainApp.mWritePLCValue(".stgGr00HMI.stHMITOPLC.bBtnStart", true);

                    break;

                case 6:
                    frmMainApp.mWritePLCValue(".stgGr00HMI.stHMITOPLC.bBtnStop", true);

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

        #region Operation mode keys

        private void SetOpModeKeys(TcFKey fKey)
        {
            fKey.InstallFKeyDelegate(new FKeyDelegate(OpModeKeyDownEvent), new FKeyDelegate(OpModeKeyUpEvent));
            fKey.FKeyTextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            fKey.FKeyImageAlign = System.Drawing.ContentAlignment.MiddleCenter;
            SetOpModeKeyText(fKey);
        }

        private void SetOpModeKeyText(TcFKey fKey)
        {
            fKey.FKeyText(1, lm["FAutomatic.OpModeKey[1]"]); 			                            //"Automatic"
            fKey.FKeyText(2, lm["FAutomatic.OpModeKey[2]"]); 			                            //"Home"
            fKey.FKeyText(3, lm["FAutomatic.OpModeKey[3]"]);                                        //"Manual"
            fKey.FKeyText(4, lm["FAutomatic.OpModeKey[4]"]);                                        //""
        }

        private void OpModeKeyUpEvent(int nIdx)
        {
            switch (nIdx)
            {
                case 1:
                    // Hide operation mode selector
                    if (tcOpModeKey.Visible == true)
                        ShowOpMode.Close(0);

                    break;

                case 2:
                    // Hide operation mode selector
                    if (tcOpModeKey.Visible == true)
                        ShowOpMode.Close(0);

                    this.SuspendLayout();
                    var frmHome = frmMain.GetFormHome();
                    frmHome.MdiParent = parentForm.MdiParent;
                    frmHome.Show();
                    frmHome.BringToFront();
                    this.ResumeLayout();
                    //this.Close();

                    break;

                case 3:
                    // Hide operation mode selector
                    if (tcOpModeKey.Visible == true)
                        ShowOpMode.Close(0);

                    this.SuspendLayout();
                    var frmManual = frmMain.GetFormManual();
                    frmManual.MdiParent = parentForm.MdiParent;
                    frmManual.Show();
                    frmManual.BringToFront();
                    this.ResumeLayout();
                    //this.Close();

                    break;

                case 4:

                    break;

            }
        }

        private void OpModeKeyDownEvent(int nIdx)
        {
            switch (nIdx)
            {
                case 1:
                    // Set automatic mode
                    CMainApp.GetMainAppForm().mWritePLCValue(".stgGr00HMI.stHMITOPLC.etMachineMode", (short)1);

                    break;

                case 2:

                    break;

                case 3:

                    break;

                case 4:

                    break;

            }
        }

        #endregion

        #endregion

    }
}
