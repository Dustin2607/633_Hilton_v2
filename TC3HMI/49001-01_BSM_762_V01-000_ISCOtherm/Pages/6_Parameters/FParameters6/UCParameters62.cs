namespace App.Pages.Parameters
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

    public partial class UCParameters62 : UserControl
    {
        #region Member enummerations

        #endregion

        #region Member variables

        // Application
        private FMainApp frmMainApp;
        private FParameters6 parentForm;
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
        /// Constructor ucManual1.
        /// </summary>
        public UCParameters62(FParameters6 f)
        {
            parentForm = f;
            
            InitializeComponent();

            ucProcessPara1.LanguageManager = parentForm.LanguageManager;
            ucWeldingPara1.LanguageManager = parentForm.LanguageManager;

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

        private void UCParameters62_Load(object sender, EventArgs e)
        {
            frmMain = CMainApp.GetMainAppForm().frmMain;
            frmMainApp = CMainApp.GetMainAppForm();

            ucProcessPara1.SerUserManager(frmMainApp.userManager);
            ucWeldingPara1.SerUserManager(frmMainApp.userManager);

            SetProcessPara(ucProcessPara1);
            SetWeldingPara(ucWeldingPara1);

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

        private void UCParameters62_VisibleChanged(object sender, EventArgs e)
        {
            if ((Visible == true) && (IsControlAtFront(this) == true))
            {

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
            lblWindowTitle.Text = lm["UCParameters62.WindowTitle"];
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
                //ucProcessPara1.Para1 = frmMainApp.Gr02HMITOPLC.lrAxisWeldingPreWeldingPos.ToString();
                //ucProcessPara1.Para2 = frmMainApp.Gr02HMITOPLC.lrAxisWeldingSafetyPos.ToString();
                //ucProcessPara1.Para3 = frmMainApp.Gr02HMITOPLC.lrContactForce.ToString();
                //ucProcessPara1.Para4 = frmMainApp.Gr02HMITOPLC.arstForceWelding[0].rProcessCtrlKp.ToString();
                //ucProcessPara1.Para5 = frmMainApp.Gr02HMITOPLC.arstForceWelding[0].rProcessCtrlTi.ToString();
                //ucProcessPara1.Para6 = frmMainApp.Gr02HMITOPLC.arstForceWelding[0].rProcessCtrlLimit.ToString();
                //ucProcessPara1.Para7 = frmMainApp.Gr02HMITOPLC.lrSetTemp.ToString();
                //ucProcessPara1.Para8 = frmMainApp.Gr02HMITOPLC.lrTempReadyTol.ToString();

                //ucWeldingPara1.Para1 = frmMainApp.Gr02HMITOPLC.stPreHeat.unProcessTime.ToString();

                //ucWeldingPara1.Para2 = frmMainApp.Gr02HMITOPLC.arstForceWelding[1].lrProcessForce.ToString();
                //ucWeldingPara1.Para3 = frmMainApp.Gr02HMITOPLC.arstForceWelding[1].unProcessRamp.ToString();
                //ucWeldingPara1.Para4 = frmMainApp.Gr02HMITOPLC.arstForceWelding[1].unProcessTime.ToString();

                //ucWeldingPara1.Para5 = frmMainApp.Gr02HMITOPLC.arstForceWelding[2].lrProcessForce.ToString();
                //ucWeldingPara1.Para6 = frmMainApp.Gr02HMITOPLC.arstForceWelding[2].unProcessRamp.ToString();
                //ucWeldingPara1.Para7 = frmMainApp.Gr02HMITOPLC.arstForceWelding[2].unProcessTime.ToString();

                //ucWeldingPara1.Para8 = frmMainApp.Gr02HMITOPLC.arstForceWelding[3].lrProcessForce.ToString();
                //ucWeldingPara1.Para9 = frmMainApp.Gr02HMITOPLC.arstForceWelding[3].unProcessRamp.ToString();
                //ucWeldingPara1.Para10 = frmMainApp.Gr02HMITOPLC.arstForceWelding[3].unProcessTime.ToString();

                //ucWeldingPara1.Para11 = frmMainApp.Gr02HMITOPLC.arstForceWelding[4].lrProcessForce.ToString();
                //ucWeldingPara1.Para12 = frmMainApp.Gr02HMITOPLC.arstForceWelding[4].unProcessRamp.ToString();
                //ucWeldingPara1.Para13 = frmMainApp.Gr02HMITOPLC.arstForceWelding[4].unProcessTime.ToString();


                //ucWeldingPara1.Para14 = frmMainApp.Gr02HMITOPLC.arstForceWelding[1].unCoolingDuration1.ToString();
                //ucWeldingPara1.Para15 = frmMainApp.Gr02HMITOPLC.arstForceWelding[1].unCoolingDuration2.ToString();

                //ucWeldingPara1.Para16 = frmMainApp.Gr02HMITOPLC.arstForceWelding[2].unCoolingDuration1.ToString();
                //ucWeldingPara1.Para17 = frmMainApp.Gr02HMITOPLC.arstForceWelding[2].unCoolingDuration2.ToString();

                //ucWeldingPara1.Para18 = frmMainApp.Gr02HMITOPLC.arstForceWelding[3].unCoolingDuration1.ToString();
                //ucWeldingPara1.Para19 = frmMainApp.Gr02HMITOPLC.arstForceWelding[3].unCoolingDuration2.ToString();

                //ucWeldingPara1.Para20 = frmMainApp.Gr02HMITOPLC.arstForceWelding[4].unCoolingDuration1.ToString();
                //ucWeldingPara1.Para21 = frmMainApp.Gr02HMITOPLC.arstForceWelding[4].unCoolingDuration2.ToString();

                //ucWeldingPara1.Para22 = frmMainApp.Gr02HMITOPLC.arstForceWelding[1].arlrCoolingAirPressure1.ToString();
                //ucWeldingPara1.Para23 = frmMainApp.Gr02HMITOPLC.arstForceWelding[1].arlrCoolingAirPressure2.ToString();

                //ucWeldingPara1.Para24 = frmMainApp.Gr02HMITOPLC.arstForceWelding[2].arlrCoolingAirPressure1.ToString();
                //ucWeldingPara1.Para25 = frmMainApp.Gr02HMITOPLC.arstForceWelding[2].arlrCoolingAirPressure2.ToString();

                //ucWeldingPara1.Para26 = frmMainApp.Gr02HMITOPLC.arstForceWelding[3].arlrCoolingAirPressure1.ToString();
                //ucWeldingPara1.Para27 = frmMainApp.Gr02HMITOPLC.arstForceWelding[3].arlrCoolingAirPressure2.ToString();

                //ucWeldingPara1.Para28 = frmMainApp.Gr02HMITOPLC.arstForceWelding[4].arlrCoolingAirPressure1.ToString();
                //ucWeldingPara1.Para29 = frmMainApp.Gr02HMITOPLC.arstForceWelding[4].arlrCoolingAirPressure2.ToString();


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

        private void SetProcessPara(UCProcessPara2_2 uc)
        {
            uc.tbxPara1.InstallWritePLCValueDelegate(
                new WritePLCValueDelegate(frmMainApp.mWritePLCValue)
            );
            uc.tbxPara2.InstallWritePLCValueDelegate(
                new WritePLCValueDelegate(frmMainApp.mWritePLCValue)
            );
            uc.tbxPara3.InstallWritePLCValueDelegate(
                new WritePLCValueDelegate(frmMainApp.mWritePLCValue)
            );
            uc.tbxPara4.InstallWritePLCValueDelegate(
                new WritePLCValueDelegate(frmMainApp.mWritePLCValue)
            );
            uc.tbxPara5.InstallWritePLCValueDelegate(
                new WritePLCValueDelegate(frmMainApp.mWritePLCValue)
            );
            uc.tbxPara6.InstallWritePLCValueDelegate(
                new WritePLCValueDelegate(frmMainApp.mWritePLCValue)
            );
            uc.tbxPara7.InstallWritePLCValueDelegate(
                new WritePLCValueDelegate(frmMainApp.mWritePLCValue)
            );
            uc.tbxPara8.InstallWritePLCValueDelegate(
                new WritePLCValueDelegate(frmMainApp.mWritePLCValue)
            );
            uc.tbxPara9.InstallWritePLCValueDelegate(
                new WritePLCValueDelegate(frmMainApp.mWritePLCValue)
            );

        }

        private void SetWeldingPara(UCWeldingPara2_2 uc)
        {
            uc.tbxPara1.InstallWritePLCValueDelegate(
                new WritePLCValueDelegate(frmMainApp.mWritePLCValue)
            );
            uc.tbxPara2.InstallWritePLCValueDelegate(
                new WritePLCValueDelegate(frmMainApp.mWritePLCValue)
            );
            uc.tbxPara3.InstallWritePLCValueDelegate(
                new WritePLCValueDelegate(frmMainApp.mWritePLCValue)
            );
            uc.tbxPara4.InstallWritePLCValueDelegate(
                new WritePLCValueDelegate(frmMainApp.mWritePLCValue)
            );
            uc.tbxPara8.InstallWritePLCValueDelegate(
                new WritePLCValueDelegate(frmMainApp.mWritePLCValue)
            );
            uc.tbxPara5.InstallWritePLCValueDelegate(
                new WritePLCValueDelegate(frmMainApp.mWritePLCValue)
            );
            uc.tbxPara6.InstallWritePLCValueDelegate(
                new WritePLCValueDelegate(frmMainApp.mWritePLCValue)
            );
            uc.tbxPara7.InstallWritePLCValueDelegate(
                new WritePLCValueDelegate(frmMainApp.mWritePLCValue)
            );
            uc.tbxPara9.InstallWritePLCValueDelegate(
                new WritePLCValueDelegate(frmMainApp.mWritePLCValue)
            );
            uc.tbxPara10.InstallWritePLCValueDelegate(
                new WritePLCValueDelegate(frmMainApp.mWritePLCValue)
            );
            uc.tbxPara11.InstallWritePLCValueDelegate(
                new WritePLCValueDelegate(frmMainApp.mWritePLCValue)
            );
            uc.tbxPara12.InstallWritePLCValueDelegate(
                new WritePLCValueDelegate(frmMainApp.mWritePLCValue)
            );
            uc.tbxPara13.InstallWritePLCValueDelegate(
                new WritePLCValueDelegate(frmMainApp.mWritePLCValue)
            );
            uc.tbxPara14.InstallWritePLCValueDelegate(
                new WritePLCValueDelegate(frmMainApp.mWritePLCValue)
            );
            uc.tbxPara15.InstallWritePLCValueDelegate(
                new WritePLCValueDelegate(frmMainApp.mWritePLCValue)
            );
            uc.tbxPara16.InstallWritePLCValueDelegate(
                new WritePLCValueDelegate(frmMainApp.mWritePLCValue)
            );
            uc.tbxPara17.InstallWritePLCValueDelegate(
                new WritePLCValueDelegate(frmMainApp.mWritePLCValue)
            );
            uc.tbxPara18.InstallWritePLCValueDelegate(
                new WritePLCValueDelegate(frmMainApp.mWritePLCValue)
            );
            uc.tbxPara19.InstallWritePLCValueDelegate(
                new WritePLCValueDelegate(frmMainApp.mWritePLCValue)
            );
            uc.tbxPara20.InstallWritePLCValueDelegate(
                new WritePLCValueDelegate(frmMainApp.mWritePLCValue)
            );
            uc.tbxPara21.InstallWritePLCValueDelegate(
                new WritePLCValueDelegate(frmMainApp.mWritePLCValue)
            );
            uc.tbxPara22.InstallWritePLCValueDelegate(
                new WritePLCValueDelegate(frmMainApp.mWritePLCValue)
            );
            uc.tbxPara23.InstallWritePLCValueDelegate(
                new WritePLCValueDelegate(frmMainApp.mWritePLCValue)
            );
            uc.tbxPara24.InstallWritePLCValueDelegate(
                new WritePLCValueDelegate(frmMainApp.mWritePLCValue)
            );
            uc.tbxPara25.InstallWritePLCValueDelegate(
                new WritePLCValueDelegate(frmMainApp.mWritePLCValue)
            );
            uc.tbxPara26.InstallWritePLCValueDelegate(
                new WritePLCValueDelegate(frmMainApp.mWritePLCValue)
            );
            uc.tbxPara27.InstallWritePLCValueDelegate(
                new WritePLCValueDelegate(frmMainApp.mWritePLCValue)
            );
            uc.tbxPara28.InstallWritePLCValueDelegate(
                new WritePLCValueDelegate(frmMainApp.mWritePLCValue)
            );
            uc.tbxPara29.InstallWritePLCValueDelegate(
                new WritePLCValueDelegate(frmMainApp.mWritePLCValue)
            );

        }

        #endregion

        #region Implementation of Function Keys

        #endregion

    } 
}
