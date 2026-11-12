namespace App
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Text;
    using System.Windows.Forms;

    using System.IO;

    using TwinCAT.App;
    using TwinCAT.Ads;

    using App.Utility;
    using App.Components;
    using App.Security;

    public partial class FMain : Form
    {
        #region Member enummerations

        #endregion

        #region Member variables

        // TwinCAT references
        private TcAdsClient adsClient;

        // Application
        private FMainApp frmMainApp;
        private FInfo frmInfo;
        private FStatistic frmStatistic;
        private FOperation frmOperation;
        private FAutomatic frmAutomatic;
        private FHome frmHome;
        private FManual frmManual;
        private FRecipe frmRecipe;
        private FParameters frmParameters;
        private FDiagnosis frmDiagnosis;
        private FSetup frmSetup;
        private CLanguageManager lm;

        public bool m_bAskClosing = true;

        // Set color theme
        private Color colorCaption;
        private Color colorRow2;
        private Color colorRow3;

        #endregion

        #region Systemcode

        #region Constructor

        /// <summary>
        /// Constructor frmMain.
        /// </summary>
        public FMain()
        {
            InitializeComponent();

            // Get language manager
            lm = CMainApp.GetMainAppForm().GetLanguageManager();

            // Create form objects
            frmInfo = new FInfo(this);
            frmStatistic = new FStatistic(this);
            frmOperation = new FOperation(this);
            frmAutomatic = new FAutomatic(this);
            frmHome = new FHome(this);
            frmManual = new FManual(this);
            frmRecipe = new FRecipe(this);
            frmParameters = new FParameters(this);
            frmDiagnosis = new FDiagnosis(this);
            frmSetup = new FSetup(this);

            ucCVCounterTotal.LanguageManager = lm;
            ucCVCounterUser.LanguageManager = lm;

            ucCVLifetimeTotal.LanguageManager = lm;
            ucCVLifetimeOn.LanguageManager = lm;

            ucCVCycleTime.LanguageManager = lm;

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

                frmInfo.CaptionBackColor = colorCaption;
                frmStatistic.CaptionBackColor = colorCaption;
                frmOperation.CaptionBackColor = colorCaption;
                frmAutomatic.CaptionBackColor = colorCaption;
                frmHome.CaptionBackColor = colorCaption;
                frmManual.CaptionBackColor = colorCaption;
                frmRecipe.CaptionBackColor = colorCaption;
                frmParameters.CaptionBackColor = colorCaption;
                frmDiagnosis.CaptionBackColor = colorCaption;
                frmSetup.CaptionBackColor = colorCaption;
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

        #endregion

        #region User interface

        #endregion

        #region Events

        #region Form Events

        private void frmMain_Load(object sender, EventArgs e)
        {
            frmMainApp = CMainApp.GetMainAppForm();

            lm.StringDel += new CLanguageManager.InitStringDelegate(LoadLanguageStrings);
            LoadLanguageStrings();

            this.SuspendLayout();
            GetFormDiagnosis();
            frmDiagnosis.MdiParent = this.MdiParent;
            frmDiagnosis.SendToBack();
            this.ResumeLayout();

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

        private void frmMain_Activated(object oSender, EventArgs eEventArgs)
        {
            SetFunctionKeys(CMainApp.GetMainAppForm().tcFKeyBottom);
        }

        protected override void OnClosing(CancelEventArgs e)
        {

            if (this.m_bAskClosing)
                e.Cancel = !LeaveApplication();
            else
                e.Cancel = false;

            base.OnClosing(e);
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

        #endregion

        #endregion

        #region Interface implementation

        #endregion

        #region Public functions
        /// <summary>
        /// Gets the form info.
        /// </summary>
        /// <returns></returns>
        public FInfo GetFormInfo()
        {
            if (frmInfo == null || frmInfo.Disposed)
                frmInfo = new FInfo(this);
            return frmInfo;
        }

        /// <summary>
        /// Gets the form statistic.
        /// </summary>
        /// <returns></returns>
        public FStatistic GetFormStatistic()
        {
            if (frmStatistic == null || frmStatistic.Disposed)
                frmStatistic = new FStatistic(this);
            return frmStatistic;
        }

        /// <summary>
        /// Gets the form operation.
        /// </summary>
        /// <returns></returns>
        public FOperation GetFormOperation()
        {
            if (frmOperation == null || frmOperation.Disposed)
                frmOperation = new FOperation(this);
            return frmOperation;
        }

        /// <summary>
        /// Gets the form automatic.
        /// </summary>
        /// <returns></returns>
        public FAutomatic GetFormAutomatic()
        {
            if (frmAutomatic == null || frmAutomatic.Disposed)
                frmAutomatic = new FAutomatic(this);
            return frmAutomatic;
        }

        /// <summary>
        /// Gets the form home.
        /// </summary>
        /// <returns></returns>
        public FHome GetFormHome()
        {
            if (frmHome == null || frmHome.Disposed)
                frmHome = new FHome(this);
            return frmHome;
        }

        /// <summary>
        /// Gets the form manual.
        /// </summary>
        /// <returns></returns>
        public FManual GetFormManual()
        {
            if (frmManual == null || frmManual.Disposed)
                frmManual = new FManual(this);
            return frmManual;
        }

        /// <summary>
        /// Gets the form recipe.
        /// </summary>
        /// <returns></returns>
        public FRecipe GetFormRecipe()
        {
            if (frmRecipe == null || frmRecipe.Disposed)
                frmRecipe = new FRecipe(this);
            return frmRecipe;
        }

        /// <summary>
        /// Gets the form parameters.
        /// </summary>
        /// <returns></returns>
        public FParameters GetFormParameters()
        {
            if (frmParameters == null || frmParameters.Disposed)
                frmParameters = new FParameters(this);
            return frmParameters;
        }

        /// <summary>
        /// Gets the form diagnosis.
        /// </summary>
        /// <returns></returns>
        public FDiagnosis GetFormDiagnosis()
        {
            if (frmDiagnosis == null || frmDiagnosis.Disposed)
                frmDiagnosis = new FDiagnosis(this);
            return frmDiagnosis;
        }

        /// <summary>
        /// Gets the form setup.
        /// </summary>
        /// <returns></returns>
        public FSetup GetFormSetup()
        {
            if (frmSetup == null || frmSetup.Disposed)
                frmSetup = new FSetup(this);
            return frmSetup;
        }

        #endregion

        #region Private methods

        private void LoadLanguageStrings()
        {
            gbxCounter.Text = lm["gbxCounter"];
            gbxLifetime.Text = lm["gbxLifetime"];
            gbxLifetimeDevice.Text = lm["gbxLifetimeDevice"];
        }
        private bool LeaveApplication()
        {
            string message = lm["FMain.LeaveApplication.Msg"];
            string caption = lm["FMain.LeaveApplication.Caption"];

            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            DialogResult result = MessageBox.Show(this, message, caption, buttons,
                MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);

            if (result == DialogResult.Yes)
                return true;
            else
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
                ucCVLifetimeTotal.ActValue = CUtility.DoFormat1(frmMainApp.Gr00PLCTOHMI.lrMachineLifetime.ToString());
                ucCVLifetimeOn.ActValue = CUtility.DoFormat1(frmMainApp.Gr00PLCTOHMI.lrMachineLifetimeAfterTurnOn.ToString());

                ucCVCounterTotal.ActValue = frmMainApp.Gr00PLCTOHMI.udnCounterTotal.ToString();
                ucCVCounterUser.ActValue = frmMainApp.Gr00PLCTOHMI.udnCounterUser.ToString();

                ucCVCycleTime.ActValue = CUtility.DoFormat1((Convert.ToDouble(frmMainApp.Gr00PLCTOHMI.dwCycleTime) / 10.0).ToString());

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
                //frmMainApp.statusStripMainApp.Items["lblRecipe1"].Text = lm["FMain.RecipeLleft"] + frmMainApp.Gr01HMITOPLC.sActRecipe;

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
            try
            {
                //frmMainApp.statusStripMainApp.Items["lblRecipe2"].Text = lm["FMain.RecipeRight"] + frmMainApp.Gr02HMITOPLC.sActRecipe;

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

        private void SetFunctionKeys(TcFKey fKey)
        {
            fKey.InstallFKeyDelegate(new FKeyDelegate(FKeyDownEvent), new FKeyDelegate(FKeyUpEvent));
            fKey.FKeyTextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            fKey.FKeyImageAlign = System.Drawing.ContentAlignment.MiddleCenter;
            SetFKeyText(fKey);
        }

        private void SetFKeyText(TcFKey fKey)
        {
            fKey.FKeyText(1, lm["FMain.FKey[1]"]); 			                                //"Info"
            fKey.FKeyText(2, ""/*lm["FMain.FKey[2]"]*/);                                    //"Statistic"
            fKey.FKeyText(3, lm["FMain.FKey[3]"]); 			                                //"Operations"
            fKey.FKeyText(4, "");			                                                //""
            fKey.FKeyText(5, lm["FMain.FKey[5]"]);                                          //"Recipe"                        
            fKey.FKeyText(6, lm["FMain.FKey[6]"]);                                          //"Parameters"
            fKey.FKeyText(7, lm["FMain.FKey[7]"]);                                          //"Diagnosis"
            fKey.FKeyText(8, lm["FMain.FKey[8]"]);	                                        //"Setup"
            fKey.FKeyText(9, lm["FMain.FKey[9]"], null, System.Drawing.Color.Red);	        //"Exit"
        }

        private void FKeyUpEvent(int nIdx)
        {
            switch (nIdx)
            {
                case 1:
                    this.SuspendLayout();
                    GetFormInfo();
                    frmInfo.MdiParent = this.MdiParent;
                    frmInfo.Show();
                    frmInfo.BringToFront();
                    this.ResumeLayout();

                    break;

                case 2:
                    this.SuspendLayout();
                    GetFormStatistic();
                    frmStatistic.MdiParent = this.MdiParent;
                    frmStatistic.Show();
                    frmStatistic.BringToFront();
                    this.ResumeLayout();

                    break;

                case 3:
                    this.SuspendLayout();
                    GetFormOperation();
                    frmOperation.MdiParent = this.MdiParent;
                    frmOperation.Show();
                    frmOperation.BringToFront();
                    this.ResumeLayout();

                    break;

                case 4:

                    break;

                case 5:
                    this.SuspendLayout();
                    GetFormRecipe();
                    frmRecipe.MdiParent = this.MdiParent;
                    frmRecipe.Show();
                    frmRecipe.BringToFront();
                    this.ResumeLayout();

                    break;

                case 6:
                    this.SuspendLayout();
                    GetFormParameters();
                    frmParameters.MdiParent = this.MdiParent;
                    frmParameters.Show();
                    frmParameters.BringToFront();
                    this.ResumeLayout();

                    break;

                case 7:
                    this.SuspendLayout();
                    GetFormDiagnosis();
                    frmDiagnosis.MdiParent = this.MdiParent;
                    frmDiagnosis.Show();
                    frmDiagnosis.BringToFront();
                    this.ResumeLayout();

                    break;

                case 8:
                    this.SuspendLayout();
                    GetFormSetup();
                    frmSetup.MdiParent = this.MdiParent;
                    frmSetup.Show();
                    frmSetup.BringToFront();
                    this.ResumeLayout();

                    break;

                case 9:

                    if (frmMainApp.userManager.CurrentUserLevel > CUserLevel.Administrator)
                    {
                        frmMainApp.userManager.LoginDialog(false, false);
                    }

                    if (frmMainApp.userManager.CurrentUserLevel <= CUserLevel.Administrator)
                    {
                        string message = lm["FMain.LeaveApplication.Msg"];
                        string caption = lm["FMain.LeaveApplication.Caption"];

                        MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                        DialogResult result = MessageBox.Show(this, message, caption, buttons,
                           MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);

                        if (result == DialogResult.Yes)
                        {
                            m_bAskClosing = false;

                            this.ParentForm.Close();
                        }
                    }

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

                    break;

                case 8:
                    break;

                case 9:

                    break;
            }


        }


        #endregion

        #region Drawing

        //public void FillPieRectangle(PaintEventArgs e)
        //{

        //    // Create solid brush.
        //    SolidBrush redBrush = new SolidBrush(Color.Red);

        //    // Create rectangle for ellipse.
        //    Rectangle rect = new Rectangle(0, 0, 100, 100);

        //    // Create start and sweep angles.
        //    float startAngle = 0.0F;
        //    float sweepAngle = 360.0F;

        //    // Fill pie to screen.
        //    e.Graphics.FillPie(redBrush, rect, startAngle, sweepAngle);
        //}

        //public void FillEllipseInt(PaintEventArgs e)
        //{

        //    // Create solid brush.
        //    SolidBrush redBrush = new SolidBrush(Color.Red);

        //    // Create location and size of ellipse.
        //    int x = 0;
        //    int y = 0;
        //    int width = 200;
        //    int height = 100;

        //    // Fill ellipse on screen.
        //    e.Graphics.FillEllipse(redBrush, x, y, width, height);
        //}

        ////private void FMain_Paint(object sender, PaintEventArgs e)
        ////{
        ////    Rectangle ellipseBounds = new Rectangle(50, 50, 100, 100); //like in your code sample
        ////    using (Brush brush = new SolidBrush(Color.Blue))
        ////    {
        ////        e.Graphics.FillPie(brush, ellipseBounds, 0, 180); //for example, do it before drawing lines.
        ////        e.Graphics.DrawEllipse(Pens.Green, ellipseBounds);
        ////    } //brush.Dispose will be automatically called here, even if exception is thrown
        ////    //FillPieRectangle(e);

        ////}

        //private void button1_Click(object sender, EventArgs e)
        //{
        //    //Panel1.CreatGraphics();
        //    Graphics dc = this.CreateGraphics();
        //    Pen Bluepen = new Pen(Color.Blue, 3);
        //    dc.DrawRectangle(Bluepen, 0, 0, 50, 50);

        //    Rectangle ellipseBounds = new Rectangle(50, 50, 100, 100); //like in your code sample
        //    Brush brush = new SolidBrush(Color.Blue);
        //    Pen Redpen = new Pen(Color.Red, 2);
        //    dc.FillPie(brush, ellipseBounds,0,360);
        //    dc.DrawEllipse(Redpen, ellipseBounds);

        //    //((Ellipse)sender).Fill = new SolidColorBrush(Colors.Green);
        //}
        #endregion

    }
}
