namespace App.Components
{
    using System;
    using System.Runtime.InteropServices;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Drawing;
    using System.Data;
    using System.Text;
    using System.Windows.Forms;

    using TwinCAT.Ads;
    using App.Utility;

    public partial class UCMillingParameters : UserControl
    {

        #region Member enummerations

        #endregion

        #region Member variables

        // TwinCAT references
        private TcAdsClient adsClient;

        // Application
        private FMainApp frmMainApp;
        private CLanguageManager lm;

        private string m_sPlcVarNameToolDiameter;
        private string m_sPlcVarNameToolLength;
        private string m_sPlcVarNameFeedRate;
        private string m_sPlcVarNameFeedStep;
        private string m_sPlcVarNameSpindleSpeed;
        private string m_sPlcVarNameSafetyDistance;

        // Set color theme
        private Color colorCaption;
        private Color colorRow2;
        private Color colorRow3;

        #endregion

        #region Systemcode

        #region Constructor

        /// <summary>
        /// Constructor UCOverride.
        /// </summary>
        public UCMillingParameters()
        {
            InitializeComponent();

            // Set color theme
            //colorCaption = groupBox1.BackColor;
            //colorRow2 = groupBox1.BackColor;
            //colorRow3 = groupBox1.BackColor;

        }

        #endregion

        #endregion

        #region Properties

        /// <summary>
        /// Gets / sets the language manager.
        /// </summary>
        /// <value>The language manager.</value>
        [DefaultValue(1)]
        [Description("Gets or sets the language manager."), Category("App")]
        public CLanguageManager LanguageManager
        {
            set { this.lm = value; }
        }

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
        /// Set plc variable name - tool diameter.
        /// </summary>
        /// <value>Plc variable name - tool diameter.</value>
        [Description("Sets plc variable name - tool diameter."), Category("App")]
        [Browsable(false)]
        public string PlcVarNameToolDiameter
        {
            get { return m_sPlcVarNameToolDiameter; }
            set { m_sPlcVarNameToolDiameter = value; }
        }

        /// <summary>
        /// Set plc variable name - tool length.
        /// </summary>
        /// <value>Plc variable name - tool length.</value>
        [Description("Sets plc variable name - tool length."), Category("App")]
        [Browsable(false)]
        public string PlcVarNameToolLength
        {
            get { return m_sPlcVarNameToolLength; }
            set { m_sPlcVarNameToolLength = value; }
        }

        /// <summary>
        /// Set plc variable name - feed rate.
        /// </summary>
        /// <value>Plc variable name - feed rate.</value>
        [Description("Sets plc variable name - feed rate."), Category("App")]
        [Browsable(false)]
        public string PlcVarNameFeedRate
        {
            get { return m_sPlcVarNameFeedRate; }
            set { m_sPlcVarNameFeedRate = value; }
        }

        /// <summary>
        /// Set plc variable name - feed step.
        /// </summary>
        /// <value>Plc variable name - feed step.</value>
        [Description("Sets plc variable name - feed step."), Category("App")]
        public string PlcVarNameFeedStep
        {
            get { return m_sPlcVarNameFeedStep; }
            set { m_sPlcVarNameFeedStep = value; }
        }

        /// <summary>
        /// Set plc variable name - spindle speed.
        /// </summary>
        /// <value>Plc variable name - spindle speed.</value>
        [Description("Sets plc variable name - spindle speed."), Category("App")]
        public string PlcVarNameSpindleSpeed
        {
            get { return m_sPlcVarNameSpindleSpeed; }
            set { m_sPlcVarNameSpindleSpeed = value; }
        }

        /// <summary>
        /// Set plc variable name - origin position axis X1.
        /// </summary>
        /// <value>Plc variable name - origin position axis X1.</value>
        [Description("Sets plc variable name - origin position axis X1."), Category("App")]
        public string PlcVarNameSafetyDistance
        {
            get { return m_sPlcVarNameSafetyDistance; }
            set { m_sPlcVarNameSafetyDistance = value; }
        }

        /// <summary>
        /// Gets / sets the tool diameter.
        /// </summary>
        /// <value>The tool diameter.</value>
        [Description("Gets / sets the tool diameter."), Category("App")]
        public string ToolDiameter
        {
            get { return tbxToolDiameter.Text; }
            set { tbxToolDiameter.Text = value; }
        }

        /// <summary>
        /// Gets / sets the tool length.
        /// </summary>
        /// <value>The tool length.</value>
        [Description("Gets / sets the tool length."), Category("App")]
        public string ToolLength
        {
            get { return tbxToolLength.Text; }
            set { tbxToolLength.Text = value; }
        }

        /// <summary>
        /// Gets / sets the feed rate.
        /// </summary>
        /// <value>The feed rate.</value>
        [Description("Gets / sets the feed rate."), Category("App")]
        public string FeedRate
        {
            get { return tbxFeedRate.Text; }
            set { tbxFeedRate.Text = value; }
        }

        /// <summary>
        /// Gets / sets the feed step.
        /// </summary>
        /// <value>The feed step.</value>
        [Description("Gets / sets the feed step."), Category("App")]
        public string FeedStep
        {
            get { return tbxFeedStep.Text; }
            set { tbxFeedStep.Text = value; }
        }

        /// <summary>
        /// Gets / sets the spindle speed.
        /// </summary>
        /// <value>The spindle speed.</value>
        [Description("Gets / sets the spindle speed."), Category("App")]
        public string SpindleSpeed
        {
            get { return tbxSpindleSpeed.Text; }
            set { tbxSpindleSpeed.Text = value; }
        }

        /// <summary>
        /// Gets / sets the safety distance.
        /// </summary>
        /// <value>The safety distance.</value>
        [Description("Gets / sets the safety distance."), Category("App")]
        public string SafetyDistance
        {
            get { return tbxSafetyDistance.Text; }
            set { tbxSafetyDistance.Text = value; }
        }

        #endregion

        #region User interface

        #endregion

        #region Events

        #region Form Events

        private void UCWeldingParameters_Load(object sender, EventArgs e)
        {
            frmMainApp = CMainApp.GetMainAppForm();

            if (this.lm == null)
                return;
            this.lm.StringDel += new CLanguageManager.InitStringDelegate(this.LoadLanguageStrings);
            this.LoadLanguageStrings();
        }

        #endregion

        #region Object Events

        private void tbxToolDiameter_Click(object sender, EventArgs e)
        {
            ////Configure Numpad
            //frmNumPad.VarType = 3;
            //frmNumPad.VarMinLimit = "20";
            //frmNumPad.VarMaxLimit = "150";
            //frmNumPad.PLCVarName = m_sPlcVarNameToolDiameter;

            ////Show NumPad
            //frmNumPad.ShowDialog();
        }

        private void tbxToolLength_Click(object sender, EventArgs e)
        {
            ////Configure Numpad
            //frmNumPad.VarType = 3;
            //frmNumPad.VarMinLimit = "50";
            //frmNumPad.VarMaxLimit = "500";
            //frmNumPad.PLCVarName = m_sPlcVarNameToolLength;

            ////Show NumPad
            //frmNumPad.ShowDialog();
        }

        private void tbxFeedRate_Click(object sender, EventArgs e)
        {
            ////Configure Numpad
            //frmNumPad.VarType = 4;
            //frmNumPad.VarMinLimit = "10";
            //frmNumPad.VarMaxLimit = "166";
            //frmNumPad.PLCVarName = m_sPlcVarNameFeedRate;

            ////Show NumPad
            //frmNumPad.ShowDialog();
        }

        private void tbxFeedStep_Click(object sender, EventArgs e)
        {
            ////Configure Numpad
            //frmNumPad.VarType = 3;
            //frmNumPad.VarMinLimit = "1";
            //frmNumPad.VarMaxLimit = "30";
            //frmNumPad.PLCVarName = m_sPlcVarNameFeedStep;

            ////Show NumPad
            //frmNumPad.ShowDialog();
        }

        private void tbxSpindleSpeed_Click(object sender, EventArgs e)
        {
            ////Configure Numpad
            //frmNumPad.VarType = 4;
            //frmNumPad.VarMinLimit = "1000";
            //frmNumPad.VarMaxLimit = "20000";
            //frmNumPad.PLCVarName = m_sPlcVarNameSpindleSpeed;

            ////Show NumPad
            //frmNumPad.ShowDialog();
        }

        private void tbxSafetyDistance_Click(object sender, EventArgs e)
        {
            ////Configure Numpad
            //frmNumPad.VarType = 6;
            //frmNumPad.VarMinLimit = "0";
            //frmNumPad.VarMaxLimit = "200";
            //frmNumPad.PLCVarName = m_sPlcVarNameSafetyDistance;

            ////Show NumPad
            //frmNumPad.ShowDialog();
        }

        #endregion

        #region User Events

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
                gbxMillingParam.Text = lm["UCMillingParameters.gbxMillingParam"];
                lblToolDiameter.Text = lm["UCMillingParameters.lblToolDiameter"];
                lblToolLength.Text = lm["UCMillingParameters.lblToolLength"];
                lblFeedRate.Text = lm["UCMillingParameters.lblFeedRate"];
                lblFeedStep.Text = lm["UCMillingParameters.lblFeedStep"];
                lblSpindleSpeed.Text = lm["UCMillingParameters.lblSpindleSpeed"];
                lblSafetyDistance.Text = lm["UCMillingParameters.lblSafetyDistance"];
            }
            else
            {
                this.gbxMillingParam.Text = "Milling parameters";
                this.lblToolDiameter.Text = "Tool diameter:";
                this.lblToolLength.Text = "Tool length:";
                this.lblFeedRate.Text = "Feed rate:";
                this.lblFeedStep.Text = "Feed step:";
                this.lblSpindleSpeed.Text = "Spindle speed:";
                this.lblSafetyDistance.Text = "Safety distance:";          
            }
        }

        #endregion

    }
}
