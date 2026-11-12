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

    public partial class FStatistic : Form
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

        // Set color theme
        private Color colorCaption;
        private Color colorRow2;
        private Color colorRow3;

        #endregion

        #region Systemcode

        #region Constructor

        /// <summary>
        /// Constructor FStatistic.
        /// </summary>
        public FStatistic(Form f)
        {
            parentForm = f;

            InitializeComponent();

            // Get language manager
            lm = CMainApp.GetMainAppForm().GetLanguageManager();

            // Create form objects
            ucCVActCountUserLe.LanguageManager = lm;
            ucCVActCountUserOKLe.LanguageManager = lm;
            ucCVActCountUserNOKLe.LanguageManager = lm;
            ucCVActCountUserDMCLe.LanguageManager = lm;
            ucCVActCountUserNOKWeLe.LanguageManager = lm;

            ucCVActPerUserOKLe.LanguageManager = lm;
            ucCVActPerUserNOKLe.LanguageManager = lm;

            ucCVPrvCountUserLe.LanguageManager = lm;
            ucCVPrvCountUserOKLe.LanguageManager = lm;
            ucCVPrvCountUserNOKLe.LanguageManager = lm;
            ucCVPrvCountUserDMCLe.LanguageManager = lm;
            ucCVPrvCountUserNOKWeLe.LanguageManager = lm;

            ucCVPrvPerUserOKLe.LanguageManager = lm;
            ucCVPrvPerUserNOKLe.LanguageManager = lm;


            ucCVActCountUserRi.LanguageManager = lm;
            ucCVActCountUserOKRi.LanguageManager = lm;
            ucCVActCountUserNOKRi.LanguageManager = lm;
            ucCVActCountUserDMCRi.LanguageManager = lm;
            ucCVActCountUserNOKWeRi.LanguageManager = lm;

            ucCVActPerUserOKRi.LanguageManager = lm;
            ucCVActPerUserNOKRi.LanguageManager = lm;

            ucCVPrvCountUserRi.LanguageManager = lm;
            ucCVPrvCountUserOKRi.LanguageManager = lm;
            ucCVPrvCountUserNOKRi.LanguageManager = lm;
            ucCVPrvCountUserDMCRi.LanguageManager = lm;
            ucCVPrvCountUserNOKWeRi.LanguageManager = lm;

            ucCVPrvPerUserOKRi.LanguageManager = lm;
            ucCVPrvPerUserNOKRi.LanguageManager = lm;


            ucCVActCountUser.LanguageManager = lm;
            ucCVActCountUserOK.LanguageManager = lm;
            ucCVActCountUserNOK.LanguageManager = lm;
            ucCVActCountUserDMC.LanguageManager = lm;
            ucCVActCountUserNOKWe.LanguageManager = lm;

            ucCVActPerUserOK.LanguageManager = lm;
            ucCVActPerUserNOK.LanguageManager = lm;

            ucCVPrvCountUser.LanguageManager = lm;
            ucCVPrvCountUserOK.LanguageManager = lm;
            ucCVPrvCountUserNOK.LanguageManager = lm;
            ucCVPrvCountUserDMC.LanguageManager = lm;
            ucCVPrvCountUserNOKWe.LanguageManager = lm;

            ucCVPrvPerUserOK.LanguageManager = lm;
            ucCVPrvPerUserNOK.LanguageManager = lm;

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

        private void FStatistic_Activated(object sender, EventArgs e)
        {
            SetFunctionKeys(CMainApp.GetMainAppForm().tcFKeyBottom);
        }

        private void FStatistic_Load(object sender, EventArgs e)
        {
            frmMain = CMainApp.GetMainAppForm().frmMain;
            frmMainApp = CMainApp.GetMainAppForm();

            lm.StringDel += new CLanguageManager.InitStringDelegate(LoadLanguageStrings);
            LoadLanguageStrings();

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
            lblWindowTitle.Text = lm["FStatistic.WindowTitle"];

            gbxActShift.Text = lm["FStatistic.gbxActShift"];
            gbxPrvShift.Text = lm["FStatistic.gbxPrvShift"];
            gbxActShiftLeft.Text = lm["FStatistic.gbxActShiftLeft"];
            gbxPrvShiftLeft.Text = lm["FStatistic.gbxPrvShiftLeft"];
            gbxActShiftRight.Text = lm["FStatistic.gbxActShiftRight"];
            gbxPrvShiftRight.Text = lm["FStatistic.gbxPrvShiftRight"];
        }

        #region Gr00 variables update

        private void GetVariablesGr00HMITOPLC()
        {

        }

        private void GetVariablesGr00PLCTOHMI()
        {

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
            fKey.FKeyText(2, ""); 			                        //""
            fKey.FKeyText(3, ""); 			                        //""
            fKey.FKeyText(4, "");			                        //""
            fKey.FKeyText(5, "");                                   //""
            fKey.FKeyText(6, "");	                                //""
            fKey.FKeyText(7, lm["FManual.FKey[7]"], null, System.Drawing.Color.DarkBlue);	            //"RESET"
            fKey.FKeyText(8, "");	                                //"" 
            fKey.FKeyText(9, lm["FStatistic.FKey[9]"]);	            //"Close" 
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
                    frmMainApp.mWritePLCValue(".stgGr01HMI.stHMITOPLC.bResetCounterUser", (Boolean)false);
                    frmMainApp.mWritePLCValue(".stgGr02HMI.stHMITOPLC.bResetCounterUser", (Boolean)false);
                    frmMainApp.mWritePLCValue(".stgGr05HMI.stHMITOPLC.bResetCounterUser", (Boolean)false);

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
                    frmMainApp.mWritePLCValue(".stgGr01HMI.stHMITOPLC.bResetCounterUser", true);
                    frmMainApp.mWritePLCValue(".stgGr02HMI.stHMITOPLC.bResetCounterUser", true);
                    frmMainApp.mWritePLCValue(".stgGr05HMI.stHMITOPLC.bResetCounterUser", true);

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
