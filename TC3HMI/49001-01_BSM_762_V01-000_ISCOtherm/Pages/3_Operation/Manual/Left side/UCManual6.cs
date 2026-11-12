namespace App.Pages.Operation.Manual
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Drawing;
    using System.Data;
    using System.Text;
    using System.Windows.Forms;

    using TwinCAT.App;

    using App.Components;
    using App.Utility;

    public partial class UCManual6 : UserControl
    {
        #region Member enummerations

        #endregion

        #region Member variables

        // Application
        private FMainApp frmMainApp;
        private FManual parentForm;
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
        /// Constructor ucManual6.
        /// </summary>
        public UCManual6(FManual f)
        {
            parentForm = f;

            InitializeComponent();

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
        /// Gets / sets the language manager.
        /// </summary>
        /// <value>The language manager.</value>
        [DefaultValue(1)]
        [Browsable(false)]
        [Description("Gets or sets the language manager."), Category("App")]
        public CLanguageManager LanguageManager
        {
            set { this.lm = value; }
        }

        #endregion

        #region User interface

        #endregion

        #region Events

        #region Form Events

        private void UCManual6_Load(object sender, EventArgs e)
        {
            frmMain = CMainApp.GetMainAppForm().frmMain;
            frmMainApp = CMainApp.GetMainAppForm();

            SetFunctionKeysLeft(parentForm.tcFKeyLeft);
            SetFunctionKeysRight(parentForm.tcFKeyRight);

            // Variables update
            GetVariablesGr00HMITOPLC();
            GetVariablesGr00PLCTOHMI();
            GetVariablesGr01HMITOPLC();
            GetVariablesGr01PLCTOHMI();
            GetVariablesGr02HMITOPLC();
            GetVariablesGr02PLCTOHMI();
            GetVariablesGr05HMITOPLC();
            GetVariablesGr05PLCTOHMI();

            frmMainApp.OnError += new System.EventHandler<App.FMainApp.OnErrorArgs>(this.frmMainApp_OnError);
            frmMainApp.OnEvent += new System.EventHandler<App.FMainApp.OnEventArgs>(this.frmMainApp_OnEvent);

            if (this.lm == null)
                return;
            this.lm.StringDel += new CLanguageManager.InitStringDelegate(this.LoadLanguageStrings);
            this.LoadLanguageStrings();
        }

        private void UCManual6_VisibleChanged(object sender, EventArgs e)
        {
            if ((Visible == true) && (IsControlAtFront(this) == true))
            {
                SetFunctionKeysLeft(parentForm.tcFKeyLeft);
                SetFunctionKeysRight(parentForm.tcFKeyRight);
            }
        }

        private void frmMainApp_OnError(object sender, FMainApp.OnErrorArgs efrmMainOnErrorArgs)
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

        #endregion

        #region Object Events

        #endregion

        #endregion

        #region Interface implementation

        #endregion

        #region Public functions

        #endregion

        #region Private methods

        private void LoadLanguageStrings()
        {
            lblWindowTitle.Text = lm["UCManual6.WindowTitle"];
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

        #region Implementation of Fields

        #endregion

        #region Implementation of Function Keys

        #region Left side

        private void SetFunctionKeysLeft(TcFKey fKey)
        {
            fKey.InstallFKeyDelegate(new FKeyDelegate(FKeyDownEventLeft), new FKeyDelegate(FKeyUpEventLeft));
            fKey.FKeyTextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            fKey.FKeyImageAlign = System.Drawing.ContentAlignment.MiddleCenter;
            SetFKeyTextLeft(fKey);
        }

        private void SetFKeyTextLeft(TcFKey fKey)
        {
            fKey.FKeyText(1, lm["UCManual6.FKey[1]"]); 			                           //""
            fKey.FKeyText(2, lm["UCManual6.FKey[2]"]); 			                           //""
            fKey.FKeyText(3, lm["UCManual6.FKey[3]"]); 			                           //""
            fKey.FKeyText(4, lm["UCManual6.FKey[4]"]); 			                           //""
            fKey.FKeyText(5, ""/*lm["UCManual6.FKey[5]"]*/); 			                   //""
            fKey.FKeyText(6, ""/*lm["UCManual6.FKey[6]"]*/, null, fKey.FKeyBtnSelectedColor);  			                           //""
            fKey.FKeyText(7, lm["UCManual6.FKey[7]"]); 			                           //""
            fKey.FKeyText(8, ""/*lm["UCManual6.FKey[8]"]*/); 			                   //""
        }

        private void FKeyUpEventLeft(int nIdx)
        {

            switch (nIdx)
            {
                case 1:
                    parentForm.ucManual1.Visible = false;
                    parentForm.ucManual1.BringToFront();
                    parentForm.ucManual1.Visible = true;

                    break;

                case 2:
                    parentForm.ucManual2.Visible = false;
                    parentForm.ucManual2.BringToFront();
                    parentForm.ucManual2.Visible = true;

                    break;

                case 3:
                    parentForm.ucManual3.Visible = false;
                    parentForm.ucManual3.BringToFront();
                    parentForm.ucManual3.Visible = true;

                    break;
                case 4:
                    parentForm.ucManual4.Visible = false;
                    parentForm.ucManual4.BringToFront();
                    parentForm.ucManual4.Visible = true;

                    break;
                case 5:
                    parentForm.ucManual5.Visible = false;
                    parentForm.ucManual5.BringToFront();
                    parentForm.ucManual5.Visible = true;
                    break;

                case 6:

                    break;

                case 7:
                    parentForm.ucManual7.Visible = false;
                    parentForm.ucManual7.BringToFront();
                    parentForm.ucManual7.Visible = true;

                    break;

                case 8:
                    parentForm.ucManual8.Visible = false;
                    parentForm.ucManual8.BringToFront();
                    parentForm.ucManual8.Visible = true;

                    break;

            }
        }

        private void FKeyDownEventLeft(int nIdx)
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

            }

        }

        #endregion

        #region Right side

        private void SetFunctionKeysRight(TcFKey fKey)
        {
            fKey.InstallFKeyDelegate(new FKeyDelegate(FKeyDownEventRight), new FKeyDelegate(FKeyUpEventRight));
            fKey.FKeyTextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            fKey.FKeyImageAlign = System.Drawing.ContentAlignment.MiddleCenter;
            SetFKeyTextRight(fKey);
        }

        private void SetFKeyTextRight(TcFKey fKey)
        {
            fKey.FKeyText(1, lm["UCManual16.FKey[1]"]); 			                           //""
            fKey.FKeyText(2, ""/*lm["UCManual16.FKey[2]"]*/); 			                           //""
            fKey.FKeyText(3, lm["UCManual16.FKey[3]"]); 			                           //""
            fKey.FKeyText(4, lm["UCManual16.FKey[4]"]); 			                           //""
            fKey.FKeyText(5, ""/*lm["UCManual16.FKey[5]"]*/); 			                   //""
            fKey.FKeyText(6, ""/*lm["UCManual16.FKey[6]"]*/); 			                           //""
            fKey.FKeyText(7, ""/*lm["UCManual16.FKey[7]"]*/); 			                           //""
            fKey.FKeyText(8, ""/*lm["UCManual16.FKey[8]"]*/); 			                   //""
        }

        private void FKeyUpEventRight(int nIdx)
        {

            switch (nIdx)
            {
                case 1:
                    parentForm.ucManual11.Visible = false;
                    parentForm.ucManual11.BringToFront();
                    parentForm.ucManual11.Visible = true;

                    break;

                case 2:
                    parentForm.ucManual12.Visible = false;
                    parentForm.ucManual12.BringToFront();
                    parentForm.ucManual12.Visible = true;

                    break;

                case 3:
                    parentForm.ucManual13.Visible = false;
                    parentForm.ucManual13.BringToFront();
                    parentForm.ucManual13.Visible = true;

                    break;
                case 4:
                    parentForm.ucManual14.Visible = false;
                    parentForm.ucManual14.BringToFront();
                    parentForm.ucManual14.Visible = true;

                    break;
                case 5:
                    parentForm.ucManual15.Visible = false;
                    parentForm.ucManual15.BringToFront();
                    parentForm.ucManual15.Visible = true;

                    break;

                case 6:
                    parentForm.ucManual16.Visible = false;
                    parentForm.ucManual16.BringToFront();
                    parentForm.ucManual16.Visible = true;

                    break;

                case 7:
                    parentForm.ucManual17.Visible = false;
                    parentForm.ucManual17.BringToFront();
                    parentForm.ucManual17.Visible = true;

                    break;

                case 8:
                    parentForm.ucManual18.Visible = false;
                    parentForm.ucManual18.BringToFront();
                    parentForm.ucManual18.Visible = true;

                    break;

            }
        }

        private void FKeyDownEventRight(int nIdx)
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

            }

        }

        #endregion

        #endregion

    }
}
