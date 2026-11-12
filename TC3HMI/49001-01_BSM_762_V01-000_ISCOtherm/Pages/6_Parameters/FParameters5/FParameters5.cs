namespace App.Pages.Parameters
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Text;
    using System.Windows.Forms;

    using TwinCAT.Ads;
    using App.Utility;
    using App.Components;

    public partial class FParameters5 : Form
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

        public UCParameters51 ucParameters51;
        public UCParameters52 ucParameters52;
        public UCParameters53 ucParameters53;
        public UCParameters54 ucParameters54;
        public UCParameters55 ucParameters55;
        public UCParameters56 ucParameters56;
        public UCParameters57 ucParameters57;
        public UCParameters58 ucParameters58;

        // Set color theme
        private Color colorCaption;
        private Color colorRow2;
        private Color colorRow3;

        #endregion

        #region Systemcode

        #region Constructor

        /// <summary>
        /// Constructor FSettings.
        /// </summary>
        public FParameters5(Form f)
        {
            parentForm = f;

            InitializeComponent();

            // Get language manager
            lm = CMainApp.GetMainAppForm().GetLanguageManager();

            // Create form objects
            ucParameters51 = new UCParameters51(this);
            ucParameters51.LanguageManager = lm;
            ucParameters52 = new UCParameters52(this);
            ucParameters52.LanguageManager = lm;
            ucParameters53 = new UCParameters53(this);
            ucParameters53.LanguageManager = lm;
            ucParameters54 = new UCParameters54(this);
            ucParameters54.LanguageManager = lm;
            ucParameters55 = new UCParameters55(this);
            ucParameters55.LanguageManager = lm;
            ucParameters56 = new UCParameters56(this);
            ucParameters56.LanguageManager = lm;
            ucParameters57 = new UCParameters57(this);
            ucParameters57.LanguageManager = lm;
            ucParameters58 = new UCParameters58(this);
            ucParameters58.LanguageManager = lm;

            // Loading user controls
            panel1.Controls.Add(ucParameters51);
            panel1.Controls.Add(ucParameters52);
            panel1.Controls.Add(ucParameters53);
            panel1.Controls.Add(ucParameters54);
            panel1.Controls.Add(ucParameters55);
            panel1.Controls.Add(ucParameters56);
            panel1.Controls.Add(ucParameters57);
            panel1.Controls.Add(ucParameters58);

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

                ucParameters51.CaptionBackColor = colorCaption;
                ucParameters52.CaptionBackColor = colorCaption;
                ucParameters53.CaptionBackColor = colorCaption;
                ucParameters54.CaptionBackColor = colorCaption;
                ucParameters55.CaptionBackColor = colorCaption;
                ucParameters56.CaptionBackColor = colorCaption;
                ucParameters57.CaptionBackColor = colorCaption;
                ucParameters58.CaptionBackColor = colorCaption;
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

        private void FSettings5_Activated(object sender, EventArgs e)
        {
            SetFunctionKeys(CMainApp.GetMainAppForm().tcFKeyBottom);
        }

        private void FSettings5_Load(object sender, EventArgs e)
        {
            frmMain = CMainApp.GetMainAppForm().frmMain;
            frmMainApp = CMainApp.GetMainAppForm();

            ucParameters51.BringToFront();

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
            //lblWindowTitle.Text = lm["FParameters5.WindowTitle"];
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

        #region Implementation of Function Keys

        private void SetFunctionKeys(TwinCAT.App.TcFKey fKey)
        {
            fKey.InstallFKeyDelegate(new FKeyDelegate(FKeyDownEvent), new FKeyDelegate(FKeyUpEvent));
            fKey.FKeyTextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            fKey.FKeyImageAlign = System.Drawing.ContentAlignment.MiddleCenter;
            SetFKeyText(fKey);
        }

        private void SetFKeyText(TwinCAT.App.TcFKey fKey)
        {

            fKey.FKeyText(1, lm["FParameters5.FKey[1]"]); 			                        //""
            fKey.FKeyText(2, lm["FParameters5.FKey[2]"]); 			                        //""
            fKey.FKeyText(3, ""/*lm["FParameters5.FKey[3]"]*/); 			                        //""
            fKey.FKeyText(4, ""/*lm["FParameters5.FKey[4]"]*/);			                        //""
            fKey.FKeyText(5, ""/*lm["FParameters5.FKey[5]"]*/);                                   //""
            fKey.FKeyText(6, ""/*lm["FParameters5.FKey[6]"]*/);	                                //""
            fKey.FKeyText(7, ""/*lm["FParameters5.FKey[7]"]*/);	                                //""
            fKey.FKeyText(8, ""/*lm["FParameters5.FKey[8]"]*/);	                                //""
            fKey.FKeyText(9, lm["FParameters5.FKey[9]"]);	        //"Close" 

        }

        private void FKeyDownEvent(int nIdx)
        {

        }

        private void FKeyUpEvent(int nIdx)
        {

            switch (nIdx)
            {
                case 1:
                    this.ucParameters51.Visible = false;
                    this.ucParameters51.BringToFront();
                    this.ucParameters51.Visible = true;

                    break;

                case 2:
                    this.ucParameters52.Visible = false;
                    this.ucParameters52.BringToFront();
                    this.ucParameters52.Visible = true;

                    break;
                case 3:
                    this.ucParameters53.Visible = false;
                    this.ucParameters53.BringToFront();
                    this.ucParameters53.Visible = true;

                    break;
                case 4:
                    this.ucParameters54.Visible = false;
                    this.ucParameters54.BringToFront();
                    this.ucParameters54.Visible = true;

                    break;
                case 5:
                    this.ucParameters55.Visible = false;
                    this.ucParameters55.BringToFront();
                    this.ucParameters55.Visible = true;

                    break;

                case 6:
                    this.ucParameters56.Visible = false;
                    this.ucParameters56.BringToFront();
                    this.ucParameters56.Visible = true;

                    break;

                case 7:
                    this.ucParameters57.Visible = false;
                    this.ucParameters57.BringToFront();
                    this.ucParameters57.Visible = true;

                    break;

                case 8:
                    this.ucParameters58.Visible = false;
                    this.ucParameters58.BringToFront();
                    this.ucParameters58.Visible = true;

                    break;

                case 9:
                    parentForm.BringToFront();
                    //this.Close();

                    break;
            }
        }

        #endregion
    }
}
