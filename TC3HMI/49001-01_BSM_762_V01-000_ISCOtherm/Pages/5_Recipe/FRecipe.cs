namespace App
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
    using App.Security;
    using App.Components.RecipeEditor;

    public partial class FRecipe : Form
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
        private FRecipe1 frmRecipe1;
        private FRecipe2 frmRecipe2;
        private FRecipe4 frmRecipe4;

        private CLanguageManager lm;

        // Set color theme
        private Color colorCaption;
        private Color colorRow2;
        private Color colorRow3;

        #endregion

        #region Systemcode

        #region Constructor

        /// <summary>
        /// Constructor FInfo.
        /// </summary>
        public FRecipe(Form f)
        {
            parentForm = f;

            InitializeComponent();

            // Get language manager
            lm = CMainApp.GetMainAppForm().GetLanguageManager();

            // Create form objects
            frmRecipe1 = new FRecipe1(this);
            frmRecipe2 = new FRecipe2(this);
            frmRecipe4 = new FRecipe4(this);

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
                lblWindowTitle.BackColor = colorCaption;
                frmRecipe1.CaptionBackColor = colorCaption;
                frmRecipe2.CaptionBackColor = colorCaption;
                frmRecipe4.CaptionBackColor = colorCaption;
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

        private void FSettings8_Activated(object sender, EventArgs e)
        {
            SetFunctionKeys(CMainApp.GetMainAppForm().tcFKeyBottom);

            if (frmMainApp != null)
                this.ucProgramEditor1.LoadFromPLC(frmMainApp.Gr00PLCTOHMI.sPrgFilePath);
        }

        private void FSettings8_Load(object sender, EventArgs e)
        {
            frmMainApp = CMainApp.GetMainAppForm();
            frmMain = frmMainApp.frmMain;

            this.ucProgramEditor1.LoadFromPLC(frmMainApp.Gr00PLCTOHMI.sPrgFilePath);

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
            lblWindowTitle.Text = lm["FRecipe.WindowTitle"];
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

            fKey.FKeyText(1, lm["FRecipe.FKey[1]"]); 			                        //""
            fKey.FKeyText(2, ""/*lm["FRecipe.FKey[2]"]*/); 			                        //""
            fKey.FKeyText(3, ""/*lm["FRecipe.FKey[3]"]*/); 			                        //""
            fKey.FKeyText(4, lm["FRecipe.FKey[4]"]);			                        //""
            fKey.FKeyText(5, ""/*lm["FRecipe.FKey[5]"]*/);                                   //""
            fKey.FKeyText(6, ""/*lm["FRecipe.FKey[6]"]*/);	                                //""
            fKey.FKeyText(7, ""/*lm["FRecipe.FKey[7]"]*/);	                                //""
            fKey.FKeyText(8, ""/*lm["FRecipe.FKey[8]"]*/);	                                //""
            fKey.FKeyText(9, lm["FRecipe.FKey[9]"]);	                //"Close" 

        }

        private void FKeyDownEvent(int nIdx)
        {

        }

        private void FKeyUpEvent(int nIdx)
        {

            switch (nIdx)
            {
                case 1:

                    //this.SuspendLayout();
                    //frmRecipe1.MdiParent = this.MdiParent;
                    //frmRecipe1.Show();
                    //frmRecipe1.BringToFront();
                    //this.ResumeLayout();
                    this.ucProgramEditor1.OpenFile();

                    break;
                case 2:

                    //this.SuspendLayout();
                    //frmRecipe2.MdiParent = this.MdiParent;
                    //frmRecipe2.Show();
                    //frmRecipe2.BringToFront();
                    //this.ResumeLayout();

                    break;

                case 3:

                    break;

                case 4:
                    if (frmMainApp.userManager.CurrentUserLevel > CUserLevel.Standarduser)
                    {
                        frmMainApp.userManager.LoginDialog(false, false);
                    }

                    if (frmMainApp.userManager.CurrentUserLevel <= CUserLevel.Standarduser)
                    {
                        this.ucProgramEditor1.SaveInToPLC(frmMainApp.Gr00PLCTOHMI.sPrgFilePath);

                    }

                    break;

                case 5:
                    this.ucProgramEditor1.LoadFromPLC(frmMainApp.Gr00PLCTOHMI.sPrgFilePath);

                    break;

                case 6:
                    if (frmMainApp.userManager.CurrentUserLevel > CUserLevel.Standarduser)
                    {
                        frmMainApp.userManager.LoginDialog(false, false);
                    }

                    if (frmMainApp.userManager.CurrentUserLevel <= CUserLevel.Standarduser)
                    {
                        this.ucProgramEditor1.SaveFile();
                    }

                    break;

                case 7:

                    break;

                case 8:

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
