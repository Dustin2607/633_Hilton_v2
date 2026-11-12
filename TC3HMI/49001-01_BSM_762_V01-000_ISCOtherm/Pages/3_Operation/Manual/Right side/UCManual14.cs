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

    public partial class UCManual14 : UserControl
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
        /// Constructor ucManual14.
        /// </summary>
        public UCManual14(FManual f)
        {
            parentForm = f;

            InitializeComponent();

            ucBtnZone1.LanguageManager = parentForm.LanguageManager;
            ucBtnZone2.LanguageManager = parentForm.LanguageManager;
            ucBtnZone3.LanguageManager = parentForm.LanguageManager;
            ucBtnZone4.LanguageManager = parentForm.LanguageManager;
            ucBtnZone5.LanguageManager = parentForm.LanguageManager;
            ucBtnZone6.LanguageManager = parentForm.LanguageManager;
            ucBtnZone7.LanguageManager = parentForm.LanguageManager;
            ucBtnZone8.LanguageManager = parentForm.LanguageManager;
            ucBtnZone9.LanguageManager = parentForm.LanguageManager;
            ucBtnZone10.LanguageManager = parentForm.LanguageManager;
            ucBtnZone11.LanguageManager = parentForm.LanguageManager;
            ucBtnZone12.LanguageManager = parentForm.LanguageManager;
            ucBtnZone13.LanguageManager = parentForm.LanguageManager;
            ucBtnZone14.LanguageManager = parentForm.LanguageManager;
            ucBtnZone15.LanguageManager = parentForm.LanguageManager;
            ucBtnZone16.LanguageManager = parentForm.LanguageManager;

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

        private void UCManual14_Load(object sender, EventArgs e)
        {
            frmMain = CMainApp.GetMainAppForm().frmMain;
            frmMainApp = CMainApp.GetMainAppForm();

            SetFunctionKeysLeft(parentForm.tcFKeyLeft);
            SetFunctionKeysRight(parentForm.tcFKeyRight);
            #region SetBtnZoneOnOff
            SetBtnZoneOnOff(ucBtnZone1);
            SetBtnZoneOnOff(ucBtnZone4);
            SetBtnZoneOnOff(ucBtnZone7);
            SetBtnZoneOnOff(ucBtnZone10);
            SetBtnZoneOnOff(ucBtnZone2);
            SetBtnZoneOnOff(ucBtnZone5);
            SetBtnZoneOnOff(ucBtnZone8);
            SetBtnZoneOnOff(ucBtnZone11);
            SetBtnZoneOnOff(ucBtnZone3);
            SetBtnZoneOnOff(ucBtnZone6);
            SetBtnZoneOnOff(ucBtnZone9);
            SetBtnZoneOnOff(ucBtnZone12);
            SetBtnZoneOnOff(ucBtnZone13);
            SetBtnZoneOnOff(ucBtnZone14);
            SetBtnZoneOnOff(ucBtnZone15);
            SetBtnZoneOnOff(ucBtnZone16);
            #endregion
            #region SetCurrentValue
            SetCurrentValue(ucCVSetZone1);
            SetCurrentValue(ucCVSetZone2);
            SetCurrentValue(ucCVSetZone3);
            SetCurrentValue(ucCVSetZone4);
            SetCurrentValue(ucCVSetZone5);
            SetCurrentValue(ucCVSetZone6);
            SetCurrentValue(ucCVSetZone7);
            SetCurrentValue(ucCVSetZone8);
            SetCurrentValue(ucCVSetZone9);
            SetCurrentValue(ucCVSetZone10);
            SetCurrentValue(ucCVSetZone11);
            SetCurrentValue(ucCVSetZone12);
            SetCurrentValue(ucCVSetZone13);
            SetCurrentValue(ucCVSetZone14);
            SetCurrentValue(ucCVSetZone15);
            SetCurrentValue(ucCVSetZone16);
            #endregion

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

        private void UCManual14_VisibleChanged(object sender, EventArgs e)
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
            lblWindowTitle.Text = lm["UCManual14.WindowTitle"];
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

        #region Gr02 variables update

        public void GetVariablesGr02HMITOPLC()
        {
            try
            {
                //ucCVSetZone1.SetValue = frmMainApp.Gr02HMITOPLC.arlrIRHSSetpointRightSide[0].ToString();
                //ucCVSetZone2.SetValue = frmMainApp.Gr02HMITOPLC.arlrIRHSSetpointRightSide[1].ToString();
                //ucCVSetZone3.SetValue = frmMainApp.Gr02HMITOPLC.arlrIRHSSetpointRightSide[2].ToString();
                //ucCVSetZone4.SetValue = frmMainApp.Gr02HMITOPLC.arlrIRHSSetpointRightSide[3].ToString();

                //ucCVSetZone5.SetValue = frmMainApp.Gr02HMITOPLC.arlrIRHSSetpointRightSide[4].ToString();
                //ucCVSetZone6.SetValue = frmMainApp.Gr02HMITOPLC.arlrIRHSSetpointRightSide[5].ToString();
                //ucCVSetZone7.SetValue = frmMainApp.Gr02HMITOPLC.arlrIRHSSetpointRightSide[6].ToString();
                //ucCVSetZone8.SetValue = frmMainApp.Gr02HMITOPLC.arlrIRHSSetpointRightSide[7].ToString();

                //ucCVSetZone9.SetValue = frmMainApp.Gr02HMITOPLC.arlrIRHSSetpointRightSide[8].ToString();
                //ucCVSetZone10.SetValue = frmMainApp.Gr02HMITOPLC.arlrIRHSSetpointRightSide[9].ToString();
                //ucCVSetZone11.SetValue = frmMainApp.Gr02HMITOPLC.arlrIRHSSetpointRightSide[10].ToString();
                //ucCVSetZone12.SetValue = frmMainApp.Gr02HMITOPLC.arlrIRHSSetpointRightSide[11].ToString();

                //ucCVSetZone13.SetValue = frmMainApp.Gr02HMITOPLC.arlrIRHSSetpointRightSide[12].ToString();
                //ucCVSetZone14.SetValue = frmMainApp.Gr02HMITOPLC.arlrIRHSSetpointRightSide[13].ToString();
                //ucCVSetZone15.SetValue = frmMainApp.Gr02HMITOPLC.arlrIRHSSetpointRightSide[14].ToString();
                //ucCVSetZone16.SetValue = frmMainApp.Gr02HMITOPLC.arlrIRHSSetpointRightSide[15].ToString();

            }
            catch
            {

            }

        }

        public void GetVariablesGr02PLCTOHMI()
        {
            try
            {
                //ucCVSetZone1.ActValue = frmMainApp.Gr02PLCTOHMI.arlrIRHSCurrentValueRightSide[0].ToString();
                //ucCVSetZone2.ActValue = frmMainApp.Gr02PLCTOHMI.arlrIRHSCurrentValueRightSide[1].ToString();
                //ucCVSetZone3.ActValue = frmMainApp.Gr02PLCTOHMI.arlrIRHSCurrentValueRightSide[2].ToString();
                //ucCVSetZone4.ActValue = frmMainApp.Gr02PLCTOHMI.arlrIRHSCurrentValueRightSide[3].ToString();

                //ucCVSetZone5.ActValue = frmMainApp.Gr02PLCTOHMI.arlrIRHSCurrentValueRightSide[4].ToString();
                //ucCVSetZone6.ActValue = frmMainApp.Gr02PLCTOHMI.arlrIRHSCurrentValueRightSide[5].ToString();
                //ucCVSetZone7.ActValue = frmMainApp.Gr02PLCTOHMI.arlrIRHSCurrentValueRightSide[6].ToString();
                //ucCVSetZone8.ActValue = frmMainApp.Gr02PLCTOHMI.arlrIRHSCurrentValueRightSide[7].ToString();

                //ucCVSetZone9.ActValue = frmMainApp.Gr02PLCTOHMI.arlrIRHSCurrentValueRightSide[8].ToString();
                //ucCVSetZone10.ActValue = frmMainApp.Gr02PLCTOHMI.arlrIRHSCurrentValueRightSide[9].ToString();
                //ucCVSetZone11.ActValue = frmMainApp.Gr02PLCTOHMI.arlrIRHSCurrentValueRightSide[10].ToString();
                //ucCVSetZone12.ActValue = frmMainApp.Gr02PLCTOHMI.arlrIRHSCurrentValueRightSide[11].ToString();

                //ucCVSetZone13.ActValue = frmMainApp.Gr02PLCTOHMI.arlrIRHSCurrentValueRightSide[12].ToString();
                //ucCVSetZone14.ActValue = frmMainApp.Gr02PLCTOHMI.arlrIRHSCurrentValueRightSide[13].ToString();
                //ucCVSetZone15.ActValue = frmMainApp.Gr02PLCTOHMI.arlrIRHSCurrentValueRightSide[14].ToString();
                //ucCVSetZone16.ActValue = frmMainApp.Gr02PLCTOHMI.arlrIRHSCurrentValueRightSide[15].ToString();

            }
            catch
            {

            }
        }

        #endregion

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

        private void SetBtnZoneOnOff(UCButtonOnOff uc)
        {
            uc.InstallWritePLCValueDelegate(
                new WritePLCValueDelegate(frmMainApp.mWritePLCValue)
            );
        }

        private void SetCurrentValue(UCCurrentValue3 uc)
        {
            uc.tbxSetValue.InstallWritePLCValueDelegate(
                new WritePLCValueDelegate(frmMainApp.mWritePLCValue)
            );

            uc.InstallWritePLCValueDelegate(
                new WritePLCValueDelegate(frmMainApp.mWritePLCValue)
            );
        }

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
            fKey.FKeyText(1, lm["UCManual4.FKey[1]"]); 			                           //""
            fKey.FKeyText(2, lm["UCManual4.FKey[2]"]); 			                           //""
            fKey.FKeyText(3, lm["UCManual4.FKey[3]"]); 			                           //""
            fKey.FKeyText(4, lm["UCManual4.FKey[4]"]); 			                           //""
            fKey.FKeyText(5, ""/*lm["UCManual4.FKey[5]"]*/); 			                   //""
            fKey.FKeyText(6, ""/*lm["UCManual4.FKey[6]"]*/); 			                           //""
            fKey.FKeyText(7, lm["UCManual4.FKey[7]"]); 			                           //""
            fKey.FKeyText(8, ""/*lm["UCManual4.FKey[8]"]*/); 			                   //""
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

                    break;

                case 6:
                    parentForm.ucManual6.Visible = false;
                    parentForm.ucManual6.BringToFront();
                    parentForm.ucManual6.Visible = true;

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
            fKey.FKeyText(1, lm["UCManual14.FKey[1]"]); 			                           //""
            fKey.FKeyText(2, ""/*lm["UCManual14.FKey[2]"]*/); 			                           //""
            fKey.FKeyText(3, lm["UCManual14.FKey[3]"]); 			                           //""
            fKey.FKeyText(4, lm["UCManual14.FKey[4]"], null, fKey.FKeyBtnSelectedColor);  			                           //""
            fKey.FKeyText(5, ""/*lm["UCManual14.FKey[5]"]*/); 			                   //""
            fKey.FKeyText(6, ""/*lm["UCManual14.FKey[6]"]*/); 			                           //""
            fKey.FKeyText(7, ""/*lm["UCManual14.FKey[7]"]*/); 			                           //""
            fKey.FKeyText(8, ""/*lm["UCManual14.FKey[8]"]*/); 			                   //""
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
