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
    using App.Pages.Parameters;

    public partial class FParameters : Form
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
        private FParameters1 frmParameters1;
        private FParameters5 frmParameters5;
        private FParameters6 frmParameters6;
        private FParameters7 frmParameters7;

        private CLanguageManager lm;

        // Set color theme
        private Color colorCaption;
        private Color colorRow2;
        private Color colorRow3;

        #endregion

        #region Systemcode

        #region Constructor

        /// <summary>
        /// Constructor FParameters.
        /// </summary>
        public FParameters(Form f)
        {
            parentForm = f;

            InitializeComponent();

            // Get language manager
            lm = CMainApp.GetMainAppForm().GetLanguageManager();

            // Create form objects
            frmParameters1 = new FParameters1(this);
            frmParameters5 = new FParameters5(this);
            frmParameters6 = new FParameters6(this);
            frmParameters7 = new FParameters7(this);

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
                frmParameters1.CaptionBackColor = colorCaption;
                frmParameters5.CaptionBackColor = colorCaption;
                frmParameters6.CaptionBackColor = colorCaption;
                frmParameters7.CaptionBackColor = colorCaption;

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

        private void FParameters_Activated(object sender, EventArgs e)
        {
            SetFunctionKeys(CMainApp.GetMainAppForm().tcFKeyBottom);
        }

        private void FParameters_Load(object sender, EventArgs e)
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
            lblWindowTitle.Text = lm["FParameters.WindowTitle"];
        }

        #region Gr00 variables update

        private void GetVariablesGr00HMITOPLC()
        {
            try
            {

            }
            catch
            {

            }
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

        }

        #endregion

        #region Gr02 variables update

        private void GetVariablesGr02HMITOPLC()
        {

        }

        private void GetVariablesGr02PLCTOHMI()
        {

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

        private void SetTextBox(CVisuTextBoxVar tb)
        {
            tb.InstallWritePLCValueDelegate(
                new WritePLCValueDelegate(frmMainApp.mWritePLCValue)
            );

            tb.InstallWritePLCStringDelegate(
                new WritePLCStringDelegate(frmMainApp.mWritePLCValue)
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
            fKey.FKeyText(2, ""); 			                        //""
            fKey.FKeyText(3, ""); 			                        //""
            fKey.FKeyText(4, "");			                        //""
            fKey.FKeyText(5, lm["FParameters.FKey[5]"]);            //"Machine Parameters"
            fKey.FKeyText(6, lm["FParameters.FKey[6]"]);	        //"Process Parameters"
            fKey.FKeyText(7, ""/*lm["FParameters.FKey[7]"]*/);	    //"Quality Parameters"
            fKey.FKeyText(8, "");	                                //""
            fKey.FKeyText(9, lm["FParameters.FKey[9]"]);	        //"Close" 
        }

        private void FKeyUpEvent(int nIdx)
        {
            switch (nIdx)
            {
                case 1:
                    this.SuspendLayout();
                    frmParameters1.MdiParent = this.MdiParent;
                    frmParameters1.Show();
                    frmParameters1.BringToFront();
                    this.ResumeLayout();

                    break;

                case 2:

                    break;

                case 3:

                    break;
                case 4:

                    break;
                case 5:
                    this.SuspendLayout();
                    frmParameters5.MdiParent = this.MdiParent;
                    frmParameters5.Show();
                    frmParameters5.BringToFront();
                    this.ResumeLayout();

                    break;

                case 6:
                    this.SuspendLayout();
                    frmParameters6.MdiParent = this.MdiParent;
                    frmParameters6.Show();
                    frmParameters6.BringToFront();
                    this.ResumeLayout();

                    break;

                case 7:
                    this.SuspendLayout();
                    frmParameters7.MdiParent = this.MdiParent;
                    frmParameters7.Show();
                    frmParameters7.BringToFront();
                    this.ResumeLayout();

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

        }

        #endregion

    }
}

