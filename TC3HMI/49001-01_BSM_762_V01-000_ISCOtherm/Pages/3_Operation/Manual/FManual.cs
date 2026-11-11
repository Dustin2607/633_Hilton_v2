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
    using App.Pages.Operation.Manual;

    public partial class FManual : Form
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
        private CShowForm ShowOpMode;

        private CLanguageManager lm;

        public UCManual ucManual;

        public UCManual1 ucManual1;
        public UCManual2 ucManual2;
        public UCManual3 ucManual3;
        public UCManual4 ucManual4;
        public UCManual5 ucManual5;
        public UCManual6 ucManual6;
        public UCManual7 ucManual7;
        public UCManual8 ucManual8;

        public UCManual11 ucManual11;
        public UCManual12 ucManual12;
        public UCManual13 ucManual13;
        public UCManual14 ucManual14;
        public UCManual15 ucManual15;
        public UCManual16 ucManual16;
        public UCManual17 ucManual17;
        public UCManual18 ucManual18;

        // Set color theme
        private Color colorCaption;
        private Color colorRow2;
        private Color colorRow3;

        #endregion

        #region Systemcode

        #region Constructor

        /// <summary>
        /// Constructor FManual.
        /// </summary>
        public FManual(Form f)
        {
            parentForm = f;

            InitializeComponent();

            // Get language manager
            lm = CMainApp.GetMainAppForm().GetLanguageManager();

            ucOverride1.LanguageManager = lm;
            ucSawbandSpeed.LanguageManager = lm;

            // Create form objects
            ucManual = new UCManual(this);
            ucManual.LanguageManager = lm;

            ucManual1 = new UCManual1(this);
            ucManual1.LanguageManager = lm;
            ucManual2 = new UCManual2(this);
            ucManual2.LanguageManager = lm;
            //ucManual3 = new UCManual3(this);
            //ucManual3.LanguageManager = lm;
            //ucManual4 = new UCManual4(this);
            //ucManual4.LanguageManager = lm;
            //ucManual5 = new UCManual5(this);
            //ucManual5.LanguageManager = lm;
            //ucManual6 = new UCManual6(this);
            //ucManual6.LanguageManager = lm;
            //ucManual7 = new UCManual7(this);
            //ucManual7.LanguageManager = lm;
            //ucManual8 = new UCManual8(this);
            //ucManual8.LanguageManager = lm;

            //ucManual11 = new UCManual11(this);
            //ucManual11.LanguageManager = lm;
            //ucManual12 = new UCManual12(this);
            //ucManual12.LanguageManager = lm;
            //ucManual13 = new UCManual13(this);
            //ucManual13.LanguageManager = lm;
            //ucManual14 = new UCManual14(this);
            //ucManual14.LanguageManager = lm;
            //ucManual15 = new UCManual15(this);
            //ucManual15.LanguageManager = lm;
            //ucManual16 = new UCManual16(this);
            //ucManual16.LanguageManager = lm;
            //ucManual17 = new UCManual17(this);
            //ucManual17.LanguageManager = lm;
            //ucManual18 = new UCManual18(this);
            //ucManual18.LanguageManager = lm;

            // Create operation mode selector
            ShowOpMode = new CShowForm(10, 10, 5);

            // Loading user controls
            panel1.Controls.Add(ucManual);
            panel1.Controls.Add(ucManual1);
            panel1.Controls.Add(ucManual2);
            //panel1.Controls.Add(ucManual3);
            //panel1.Controls.Add(ucManual4);
            //panel1.Controls.Add(ucManual5);
            //panel1.Controls.Add(ucManual6);
            //panel1.Controls.Add(ucManual7);
            //panel1.Controls.Add(ucManual8);

            //panel1.Controls.Add(ucManual11);
            //panel1.Controls.Add(ucManual12);
            //panel1.Controls.Add(ucManual13);
            //panel1.Controls.Add(ucManual14);
            //panel1.Controls.Add(ucManual15);
            //panel1.Controls.Add(ucManual16);
            //panel1.Controls.Add(ucManual17);
            //panel1.Controls.Add(ucManual18);

            adsClient = CMainApp.GetMainAppForm().AdsClientRef;

            SetFormStyle(this);

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

                ucManual.CaptionBackColor = colorCaption;

                ucManual1.CaptionBackColor = colorCaption;
                ucManual2.CaptionBackColor = colorCaption;
                //ucManual3.CaptionBackColor = colorCaption;
                //ucManual4.CaptionBackColor = colorCaption;
                //ucManual5.CaptionBackColor = colorCaption;
                //ucManual6.CaptionBackColor = colorCaption;
                //ucManual7.CaptionBackColor = colorCaption;
                //ucManual8.CaptionBackColor = colorCaption;

                //ucManual11.CaptionBackColor = colorCaption;
                //ucManual12.CaptionBackColor = colorCaption;
                //ucManual13.CaptionBackColor = colorCaption;
                //ucManual14.CaptionBackColor = colorCaption;
                //ucManual15.CaptionBackColor = colorCaption;
                //ucManual16.CaptionBackColor = colorCaption;
                //ucManual17.CaptionBackColor = colorCaption;
                //ucManual18.CaptionBackColor = colorCaption;

                tcFKeyLeft.FKeyBtnBackColor = colorCaption;
                //tcFKeyLeft.FKeyBtnSelectedColor = Color.Red;//colorCaption;

                tcFKeyRight.FKeyBtnBackColor = colorCaption;
                //tcFKeyRight.FKeyBtnSelectedColor = Color.Yellow;//colorCaption;

                for (int i = 1; i <= 12; i++)
                {
                    Label lbl1 = tcFKeyLeft.FKeyLabelTextObj(i);
                    lbl1.ForeColor = Color.FromArgb(163, 166, 171);

                    Label lbl2 = tcFKeyRight.FKeyLabelTextObj(i);
                    lbl1.ForeColor = Color.FromArgb(163, 166, 171);
                }

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

        private void FManual_Activated(object sender, EventArgs e)
        {
            // Set manual mode
            CMainApp.GetMainAppForm().mWritePLCValue(".stgGr00HMI.stHMITOPLC.etMachineMode", (short)5);

            SetFunctionKeys(CMainApp.GetMainAppForm().tcFKeyBottom);
            SetOpModeKeys(tcOpModeKey);
        }

        private void FManual_Load(object sender, EventArgs e)
        {
            frmMain = CMainApp.GetMainAppForm().frmMain;
            frmMainApp = CMainApp.GetMainAppForm();

            ucManual1.Visible = false;
            ucManual1.BringToFront();
            ucManual1.Visible = true;

            ucOverride1.SerUserManager(frmMainApp.userManager);
            ucSawbandSpeed.SerUserManager(frmMainApp.userManager);

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

        private void SetFormStyle(Form form)
        {
            //form.Location = new Point(0, 0);
            form.MaximumSize = new System.Drawing.Size(1024, 572);
            form.MinimumSize = new System.Drawing.Size(1024, 572);
            form.FormBorderStyle = FormBorderStyle.None;
            //form.WindowState = FormWindowState.Maximized;
        }

        private void LoadLanguageStrings()
        {
            //lblWindowTitle.Text = lm["FParameters6.WindowTitle"];
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
                //if (IsControlAtFront(ucManual)
                //    || IsControlAtFront(ucManual7)
                //    || IsControlAtFront(ucManual8))
                //{
                //    ucOverride1.ActValue = frmMainApp.Gr00HMITOPLC.rOverride.ToString();
                //}

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
                ucSawbandSpeed.ActValue = frmMainApp.Gr01HMITOPLC.rSawbandManualSpeed.ToString();
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
            fKey.FKeyText(2, ""); 			                                                            //""
            fKey.FKeyText(3, lm["FManual.FKey[3]"]); 			                                        //"Operation mode"
            fKey.FKeyText(4, "");                                                                       //""
            fKey.FKeyText(5, ""/*lm["FManual.FKey[5]"]*/ );                                             //""
            fKey.FKeyText(6, ""/*lm["FManual.FKey[6]"], null, System.Drawing.Color.Red*/);	            //"STOP"
            fKey.FKeyText(7, lm["FManual.FKey[7]"], null, System.Drawing.Color.DarkBlue);	            //"RESET"
            fKey.FKeyText(8, "");	                                                                    //""
            fKey.FKeyText(9, lm["FManual.FKey[9]"]);	                                                //"Close"
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
                    if (tcOpModeKey.Visible == false)
                        ShowOpMode.OpenYBottom(this, tcOpModeKey, true);  

                    break;
                case 4:

                    break;
                case 5:
                    frmMainApp.mWritePLCValue(".stgGr00HMI.stHMITOPLC.bBtnStart", (Boolean)false);

                    break;

                case 6:

                    //if ((int)frmMainApp.Gr00HMITOPLC.etMachineMode == 5)                 // Manual
                    //{
                    //    this.SuspendLayout();
                    //    frmHome = frmMain.GetFormHome();
                    //    frmHome.MdiParent = parentForm.MdiParent;
                    //    frmHome.Show();
                    //    frmHome.BringToFront();
                    //    this.ResumeLayout();

                    //}
                    //else if ((int)frmMainApp.Gr00HMITOPLC.etMachineMode == 4)                 // Home
                    //{
                    //    this.SuspendLayout();
                    //    frmAutomatic = frmMain.GetFormAutomatic();
                    //    frmAutomatic.MdiParent = parentForm.MdiParent;
                    //    frmAutomatic.Show();
                    //    frmAutomatic.BringToFront();
                    //    this.ResumeLayout();

                    //}

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
                    // Set maintenance mode
                    CMainApp.GetMainAppForm().mWritePLCValue(".stgGr00HMI.stHMITOPLC.etMachineMode", (short)6);

                    // Starts maintenance mode
                    frmMainApp.mWritePLCValue(".stgGr00HMI.stHMITOPLC.bBtnStart", (Boolean)true);

                    break;

                case 6:


                    break;

                case 7:
                    frmMainApp.mWritePLCValue(".stgGr00HMI.stHMITOPLC.bBtnReset", (Boolean)true);

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
            fKey.FKeyText(1, lm["FManual.OpModeKey[1]"]); 			                            //"Automatic"
            fKey.FKeyText(2, lm["FManual.OpModeKey[2]"]); 			                            //"Home"
            fKey.FKeyText(3, lm["FManual.OpModeKey[3]"]);                                       //"Manual"
            fKey.FKeyText(4, lm["FManual.OpModeKey[4]"]);                                       //""
        }

        private void OpModeKeyUpEvent(int nIdx)
        {
            FAutomatic frmAutomatic = null;
            FHome frmHome = null;
            FManual frmManual = null;

            switch (nIdx)
            {
                case 1:
                    // Hide operation mode selector
                    if (tcOpModeKey.Visible == true)
                        ShowOpMode.Close(0);

                    this.SuspendLayout();
                    frmAutomatic = frmMain.GetFormAutomatic();
                    frmAutomatic.MdiParent = parentForm.MdiParent;
                    frmAutomatic.Show();
                    frmAutomatic.BringToFront();
                    this.ResumeLayout();
                    //this.Close();

                    break;

                case 2:
                    // Hide operation mode selector
                    if (tcOpModeKey.Visible == true)
                        ShowOpMode.Close(0);

                    this.SuspendLayout();
                    frmHome = frmMain.GetFormHome();
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

                    break;

                case 2:

                    break;

                case 3:
                    // Set manual mode
                    CMainApp.GetMainAppForm().mWritePLCValue(".stgGr00HMI.stHMITOPLC.etMachineMode", (short)5);

                    break;

                case 4:

                    break;

            }


        }

        #endregion

        #endregion

    }
}
