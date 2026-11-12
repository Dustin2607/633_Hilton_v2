namespace App.Components
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Drawing;
    using System.Data;
    using System.Text;
    using System.Windows.Forms;

    using TwinCAT.Ads;
    using App.Utility;

    public partial class UCHeader : UserControl
    {
        #region Member enummerations

        public enum ENSystemState
        {
            eNoSystem = 0,
            eSysIsRunning = 1,
            ePlcIsRunning = 2,
            eMachineIsRunning = 3
        }

        #endregion

        #region Member variables

        // TwinCAT references
        private TcAdsClient adsClient;
        private AdsState adsState;

        // Application
        private FMainApp frmMainApp;
        private ENSystemState enSystemState;
        private Timer tmrAdsState;
        private Timer tmrDateTime;

        private CLanguageManager lm;
        private string[] arsOpMode = new string[12]{"","","","","","","","","","","",""};

        private bool bMachineRunning;

        // Set color theme
        private Color colorCaption;
        private Color colorRow2;
        private Color colorRow3;

        #endregion

        #region Systemcode

        #region Constructor

        /// <summary>
        /// Constructor UCHeader.
        /// </summary>
        public UCHeader()
        {
            InitializeComponent();
       
            // Set color theme
            colorCaption = groupBox1.BackColor;
            colorRow2 = groupBox1.BackColor;
            colorRow3 = groupBox1.BackColor;

            tmrDateTime = new Timer();
            tmrDateTime.Enabled = true;
            tmrDateTime.Interval = 990;
            tmrDateTime.Start();
            tmrDateTime.Tick += new System.EventHandler(this.tmrDateTime_Tick);

        }

        #endregion

        #endregion

        #region Properties

        /// <summary>
        /// Gets / sets the ads server reference.
        /// </summary>
        /// <value>The ads server ref.</value>
        [Description("Gets / sets the ads client reference."), Category("App")]
        public TcAdsClient AdsClientRef
        {
            get { return this.adsClient; }
            set { this.adsClient = value; }
        }

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
                groupBox1.BackColor = colorCaption;
                groupBox9.BackColor = colorCaption;
                groupBox8.BackColor = colorCaption;
                groupBox10.BackColor = colorCaption;
                groupBox2.BackColor = colorCaption;
                groupBox4.BackColor = colorCaption;
                groupBox6.BackColor = colorCaption;
                groupBox12.BackColor = colorCaption;
                groupBox13.BackColor = colorCaption;
                groupBox14.BackColor = colorCaption;

                ucAxisPosition1.CaptionBackColor = colorCaption;
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

                groupBox3.BackColor = colorRow2;
                groupBox5.BackColor = colorRow2;
                groupBox7.BackColor = colorRow2;

                ucAxisPosition1.ColorRow2 = colorRow2;
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
                groupBox11.BackColor = colorRow3;

                ucAxisPosition1.ColorRow3 = colorRow3;
            }
        }

        /// <summary>
        /// Gets / sets the language manager.
        /// </summary>
        /// <value>The language manager.</value>
        [DefaultValue(1)]
        [Description("Gets or sets the language manager."), Category("App")]
        public CLanguageManager LanguageManager
        {
            set { 
                    this.lm = value;
                    ucAxisPosition1.LanguageManager = this.lm;
                }
        }

        #endregion

        #region User interface

        #endregion

        #region Events

        #region Form Events

        private void UCHeader_Load(object sender, EventArgs e)
        {
            frmMainApp = CMainApp.GetMainAppForm();

            // Create ads system monitoring 
            tmrAdsState = new Timer();
            tmrAdsState.Enabled = true;
            tmrAdsState.Interval = 1000;
            tmrAdsState.Start();
            tmrAdsState.Tick += new System.EventHandler(this.tmrAdsState_Tick);

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

        private void tmrDateTime_Tick(object sender, EventArgs e)
        {
            this.lblData.Text = DateTime.Now.ToShortDateString();
            this.lblTime.Text = DateTime.Now.ToString("T");
        }

        private void tmrAdsState_Tick(object sender, EventArgs e)
        {
            try
            {

                adsState = adsClient.ReadState().AdsState;

                switch (adsState)
                {

                    case AdsState.Run:

                        if (OnSystemState != null && enSystemState != ENSystemState.ePlcIsRunning)
                        {
                            OnSystemState(this, new OnSystemStateArgs(ENSystemState.ePlcIsRunning));
                        }

                        if (bMachineRunning == true)
                        {
                            enSystemState = ENSystemState.eMachineIsRunning;
                        }
                        else
                        {
                            enSystemState = ENSystemState.ePlcIsRunning;
                        }

                        break;

                    case AdsState.Stop:

                        if (OnSystemState != null && enSystemState != ENSystemState.eSysIsRunning)
                        {
                            OnSystemState(this, new OnSystemStateArgs(ENSystemState.eSysIsRunning));
                        }

                        enSystemState = ENSystemState.eSysIsRunning;

                        break;

                    default:

                        if (OnSystemState != null && enSystemState != ENSystemState.eSysIsRunning)
                        {
                            OnSystemState(this, new OnSystemStateArgs(ENSystemState.eSysIsRunning));
                        }

                        enSystemState = ENSystemState.eSysIsRunning;

                        break;

                }
            }
            catch (Exception ex)
            {

                if (OnSystemState != null && enSystemState != ENSystemState.eNoSystem)
                {
                    OnSystemState(this, new OnSystemStateArgs(ENSystemState.eNoSystem, ex.Message));
                }

                enSystemState = ENSystemState.eNoSystem;

            }

            mUpdateSystemState();

        }

        private void tcEventLoggerLine1_DoubleClick(object sender, EventArgs e)
        {
            Form activeChild = CMainApp.GetMainAppForm().ActiveMdiChild;
            FDiagnosis frmDiagnosis = CMainApp.GetMainAppForm().frmMain.GetFormDiagnosis();
            if (activeChild != frmDiagnosis)
            {
                frmDiagnosis.SetParentForm(activeChild);
                frmDiagnosis.MdiParent = activeChild.MdiParent;
                frmDiagnosis.Show();
                frmDiagnosis.BringToFront();
            }
        }

        #endregion

        #region User Events

        public event EventHandler<OnSystemStateArgs> OnSystemState;

        #region Nested type: OnSystemStateArgs

        public class OnSystemStateArgs : EventArgs
        {
            private readonly ENSystemState enSystemState;
            private readonly string sSystemMessage;

            public OnSystemStateArgs(ENSystemState enSystemState)
            {
                this.enSystemState = enSystemState;
            }

            public OnSystemStateArgs(ENSystemState enSystemState, String sSystemMessage)
            {
                this.enSystemState = enSystemState;
                this.sSystemMessage = sSystemMessage;
            }

            public string SystemMessage
            {
                get { return sSystemMessage; }
            }

            public ENSystemState SystemState
            {
                get { return enSystemState; }
            }
        }

        #endregion

        #endregion

        #endregion

        #region Interface implementation

        #endregion

        #region Public functions

        #endregion

        #region Private methods

        private void LoadLanguageStrings()
        {
            if (this.lm != null)
            {
                lblMachine.Text = lm["UCHeader.lblMachine"];
                lblPLC.Text = lm["UCHeader.lblPLC"];
                lblSystem.Text = lm["UCHeader.lblSystem"];

                lblCycleTime.Text = lm["UCHeader.lblCycleTime"];
                lblCntrTotal.Text = lm["UCHeader.lblCntrTotal"];
                lblCntrUser.Text = lm["UCHeader.lblCntrUser"];

                lblTempLeft.Text = lm["UCHeader.lblTempLeft"];
                lblPrg.Text = lm["UCHeader.lblTempRight"];

                arsOpMode[0] = lm["UCHeader.lblOpMode.NoServer"];
                arsOpMode[1] = lm["UCHeader.lblOpMode.Undefined"];
                arsOpMode[2] = lm["UCHeader.lblOpMode.Auto"];
                arsOpMode[3] = lm["UCHeader.lblOpMode.Cycle"];
                arsOpMode[4] = lm["UCHeader.lblOpMode.Stepping"];
                arsOpMode[5] = lm["UCHeader.lblOpMode.Home"];
                arsOpMode[6] = lm["UCHeader.lblOpMode.Manual"];
                arsOpMode[7] = lm["UCHeader.lblOpMode.Maintenance"];
                arsOpMode[8] = lm["UCHeader.lblOpMode.DryRun"];
                arsOpMode[9] = lm["UCHeader.lblOpMode.MDI"];
                arsOpMode[11]  = lm["UCHeader.lblOpMode.Idle"];
            }
            else
            {
                this.lblMachine.Text = "Machine";
                this.lblPLC.Text = "PLC";
                this.lblSystem.Text = "System";

                lblCycleTime.Text = "Cycle time";
                lblCntrTotal.Text = "CntrTotalLeft";
                lblCntrUser.Text = "CntrTotalRight";

                lblTempLeft.Text = "TempLeft";
                lblPrg.Text = "TempRight";

                arsOpMode[0] = "No Server";
                arsOpMode[1] = "Undefined";
                arsOpMode[2] = "Auto";
                arsOpMode[3] = "Cycle";
                arsOpMode[4] = "Stepping";
                arsOpMode[5] = "Home";
                arsOpMode[6] = "Manual";
                arsOpMode[7] = "Maintenance";
                arsOpMode[8] = "DryRun";
                arsOpMode[9] = "MDI";
                arsOpMode[11] = "Idle";
            }
        }

        private void mUpdateSystemState()
        {

            if (enSystemState == ENSystemState.eNoSystem)
            {
                lblSystemStatus.Text = "No System";
                lblSystemStatus.BackColor = Color.Gray;
                lblPLCStatus.Text = "No System";
                lblPLCStatus.BackColor = Color.Gray;
                lblMachineStatus.Text = "No System";
                lblMachineStatus.BackColor = Color.Gray;

                return;
            }

            lblSystemStatus.Text = "STOP";
            lblSystemStatus.BackColor = Color.Red;
            lblPLCStatus.Text = "STOP";
            lblPLCStatus.BackColor = Color.Red;
            lblMachineStatus.Text = "STOP";
            lblMachineStatus.BackColor = Color.Red;

            if ((enSystemState == ENSystemState.eSysIsRunning)
                || (enSystemState == ENSystemState.ePlcIsRunning)
                || (enSystemState == ENSystemState.eMachineIsRunning))
            {
                lblSystemStatus.Text = "RUN";
                lblSystemStatus.BackColor = Color.Green;

                if ((enSystemState == ENSystemState.ePlcIsRunning)
                   || (enSystemState == ENSystemState.eMachineIsRunning))
                {
                    lblPLCStatus.Text = "RUN";
                    lblPLCStatus.BackColor = Color.Green;

                    if (enSystemState == ENSystemState.eMachineIsRunning)
                    {
                        lblMachineStatus.Text = "RUN";
                        lblMachineStatus.BackColor = Color.Green;

                    }
                }
            }
        }

        private void mGetOpMode(int nMachineMode)
        {
            try
            {
                
                switch (nMachineMode)
                {
                    case 0: // eUndefined

                        lblOpMode.Text = arsOpMode[1];

                        break;

                    case 1: // eAutomatic

                        lblOpMode.Text = arsOpMode[2];

                        break;

                    case 2: // eCycle

                        lblOpMode.Text = arsOpMode[3];

                        break;

                    case 3: // eStepping

                        lblOpMode.Text = arsOpMode[4];

                        break;

                    case 4: // eHome

                        lblOpMode.Text = arsOpMode[5];

                        break;

                    case 5: // eManual

                        lblOpMode.Text = arsOpMode[6];

                        break;

                    case 6: // eMaintenance

                        lblOpMode.Text = arsOpMode[7];

                        break;

                    case 7: // eDryRun

                        lblOpMode.Text = arsOpMode[8];

                        break;

                    case 8: // eMDI

                        lblOpMode.Text = arsOpMode[9];

                        break;

                    case 10: // eIdle

                        lblOpMode.Text = arsOpMode[11];

                        break;

                    default:
                        lblOpMode.Text = arsOpMode[0];

                        break;
                }
            }
            catch
            {
                throw new Exception("OpMode:" + nMachineMode.ToString());
            }
        
        }

        #region Gr00 variables update

        private void GetVariablesGr00HMITOPLC()
        {

            try
            {
                if (frmMainApp.Gr00HMITOPLC.bProgramActive)
                {
                    lblPrgStatus.Text = "Program active";
                    lblPrgStatus.BackColor = Color.Green;
                    lblPrgStatus2.BackColor = Color.Green;
                }
                else
                {
                    lblPrgStatus.Text = "Program deactivated";
                    lblPrgStatus.BackColor = Color.Red;
                    lblPrgStatus2.BackColor = Color.Red;
                }
            }
            catch
            {

            }


        }

        private void GetVariablesGr00PLCTOHMI()
        {
            try
            {
                lblCycleTimeStatus.Text = CUtility.DoFormat1((Convert.ToDouble(frmMainApp.Gr00PLCTOHMI.dwCycleTime)/10.0).ToString());

                bMachineRunning = frmMainApp.Gr00PLCTOHMI.bMachineRunning;
                mGetOpMode((int)frmMainApp.Gr00PLCTOHMI.etMachineMode);
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
                lblCounterTotal.Text = frmMainApp.Gr00PLCTOHMI.udnCounterTotal.ToString();
                lblCounterUser.Text = frmMainApp.Gr00PLCTOHMI.udnCounterUser.ToString();

                ucAxisPosition1.Axis1Value = CUtility.ConvMMtoCal(frmMainApp.Gr01PLCTOHMI.lrAxisSawBowActPos).ToString();
                ucAxisPosition1.Axis4Value = frmMainApp.Gr01PLCTOHMI.lrAxisAngleActPos.ToString();

                ucAxisPosition1.Axis2Value = CUtility.ConvMpMintoFpMin(frmMainApp.Gr01PLCTOHMI.lrSawbandActSpeed).ToString();
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
                ucAxisPosition1.Axis3Value = CUtility.ConvMMtoCal(frmMainApp.Gr05PLCTOHMI.arlrAxisClampActPos[1]).ToString();
                ucAxisPosition1.Axis6Value = CUtility.ConvMMtoCal(frmMainApp.Gr05PLCTOHMI.arlrAxisClampActPos[0]).ToString();
            }
            catch
            {

            }

        }

        #endregion

        #endregion

    }
}
