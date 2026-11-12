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
    using App.Components;
    using App.Security;

    public partial class UCOverride : UserControlBase
    {
        #region Member enummerations

        #endregion

        #region Member variables

        // TwinCAT references
        private TcAdsClient adsClient;

        // Application
        private Timer timer1;
        private CLanguageManager lm;
        private CUserManager um;

        private bool m_bMirrorCtrl = false;
        private string m_Name;
        private string m_Unit;
        private string m_LeftButtonName;
        private string m_RightButtonName;
        private string m_sActValue;
        private string m_sPlcVarName;

        private bool m_OverrideDec = false;

        private float m_fOverrideStep;
        private float m_fOverrideMin;
        private float m_fOverrideMax;

        private bool m_bInchOn;

        private WritePLCValueDelegate WritePLCValueFunc;
        public event WritePLCValueDelegate WritePLCValueEvent;

        // Set color theme
        private Color colorCaption;
        private Color colorRow2;
        private Color colorRow3;

        #endregion

        #region Systemcode

        #region Constructor

        public UCOverride()
        {
            InitializeComponent();

            timer1 = new Timer();
            timer1.Enabled = false;
            timer1.Interval = 600;
            //timer1.Start();
            timer1.Tick += new EventHandler(timer1_Tick);

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
        [Description("Gets or sets the language manager."), Category("Parameter")]
        public CLanguageManager LanguageManager
        {
            set { this.lm = value; }

        }

        /// </summary>
        /// <value>Sets name of object.</value>
        /// </summary>
        [Description("Sets name of object."), Category("Parameter")]
        public string ObjectName
        {
            get { return m_Name; }
            set { m_Name = value; }
        }

        /// </summary>
        /// <value>Sets mirror control.</value>
        /// </summary>
        [Description("Sets name of object."), Category("Parameter")]
        public bool MirrorCtrl
        {
            get { return this.m_bMirrorCtrl; }
            set { this.m_bMirrorCtrl = value; }
        }

        /// </summary>
        /// <value>Sets unit of object.</value>
        /// </summary>
        [Description("Sets unit of object."), Category("Parameter")]
        public string Unit
        {
            get { return m_Unit; }
            set { m_Unit = value; }
        }

        /// </summary>
        /// <value>Sets name of left button.</value>
        /// </summary>
        [Description("Sets name of left button."), Category("Parameter")]
        public string LeftButtonName
        {
            get { return m_LeftButtonName; }
            set { m_LeftButtonName = value; }
        }

        /// </summary>
        /// <value>Sets name of right button.</value>
        /// </summary>
        [Description("Sets name of rigth button."), Category("Parameter")]
        public string RightButtonName
        {
            get { return m_RightButtonName; }
            set { m_RightButtonName = value; }
        }

        /// <summary>
        /// Set plc variable name.
        /// </summary>
        /// <value>Plc variable name.</value>
        [Description("Sets plc variable name."), Category("Parameter")]
        public string PlcVarName
        {
            get { return m_sPlcVarName; }
            set { 
                    this.m_sPlcVarName = value;
                    this.tbxValue.PlcVarName = value;
                }
        }

        /// <summary>
        /// Set override step.
        /// </summary>
        /// <value>Override step.</value>
        [Description("Sets override step."), Category("Parameter")]
        public float OverrideStep
        {
            get { return m_fOverrideStep; }
            set
            {
                this.m_fOverrideStep = value;
            }
        }

        /// <summary>
        /// Set override min.
        /// </summary>
        /// <value>Override min.</value>
        [Description("Sets override min."), Category("Parameter")]
        public float OverrideMin
        {
            get { return m_fOverrideMin; }
            set
            {
                this.m_fOverrideMin = value;
                this.tbxValue.VarMinLimit = value.ToString();
            }
        }

        /// <summary>
        /// Set override max.
        /// </summary>
        /// <value>Override max.</value>
        [Description("Sets override max."), Category("Parameter")]
        public float OverrideMax
        {
            get { return m_fOverrideMax; }
            set
            {
                this.m_fOverrideMax = value;
                this.tbxValue.VarMaxLimit = value.ToString();
            }
        }

        /// <summary>
        /// Set plc value.
        /// </summary>
        /// <value>Plc value.</value>
        [Browsable(false)]
        [Description("Sets plc value."), Category("Parameter")]
        public string ActValue
        {
            get { return m_sActValue; }
            set
            {
                m_sActValue = value;
                tbxValue.Text = CUtility.DoFormat(m_sActValue);
            }
        }

        #endregion

        #region Events

        #region Form Events

        private void UCOverride_Load(object sender, EventArgs e)
        {
            if (this.lm == null)
                return;
            this.lm.StringDel += new CLanguageManager.InitStringDelegate(this.LoadLanguageStrings);
            this.LoadLanguageStrings();
        }

        #endregion

        #region Object Events

        private void btnPositive_MouseDown(object sender, MouseEventArgs e)
        {
            m_OverrideDec = false;
            this.Override();
        }

        private void btnNegative_MouseDown(object sender, MouseEventArgs e)
        {
            m_OverrideDec = true;
            this.Override();
        }

        private void btnNegative_MouseUp(object sender, MouseEventArgs e)
        {
            
        }

        private void btnPositive_MouseUp(object sender, MouseEventArgs e)
        {
            
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            
        }

        #endregion

        #region User Events

        #endregion

        #endregion

        #region Interface implementation

        #endregion

        #region Public functions

        [DefaultValue(1)]
        [Description("Sets the user manager."), Category("App")]
        public void SerUserManager(CUserManager um)
        {
            this.um = um;
            this.tbxValue.UserManager = um;

        }

        /// <summary>
        /// Sets the write PLC value delegate.
        /// </summary>
        //[Description("Sets the write PLC value delegate."), Category("App")]
        public void InstallWritePLCValueDelegate(WritePLCValueDelegate WritePLCValue)
        {
            if (this.WritePLCValueFunc != null)
            {
                this.WritePLCValueEvent = (WritePLCValueDelegate)Delegate.Remove(this.WritePLCValueEvent, new WritePLCValueDelegate(this.WritePLCValueFunc.Invoke));
            }
            this.WritePLCValueFunc = WritePLCValue;
            if (this.WritePLCValueFunc != null)
            {
                this.WritePLCValueEvent = (WritePLCValueDelegate)Delegate.Combine(this.WritePLCValueEvent, new WritePLCValueDelegate(this.WritePLCValueFunc.Invoke));
            }
        }

        protected virtual void RaiseWritePLCValue(string PlcVarNameValue, int ActValue)
        {
            this.WritePLCValueEvent(PlcVarNameValue, ActValue);
        }

        protected virtual void RaiseWritePLCValue(string PlcVarNameValue, double ActValue)
        {
            this.WritePLCValueEvent(PlcVarNameValue, ActValue);
        }

        #endregion

        #region Private methods

        private void LoadLanguageStrings()
        {
            //if (this.lm != null)
            //{
            //    this.lblObject.Text = lm["UCOverride." + m_Name];
            //    this.lblUnit.Text = lm["UCOverride." + m_Name + ".Unit"];
            //    this.btnPositive.Text = lm["UCOverride." + m_Name + ".LeftButton"];
            //    this.btnNegative.Text = lm["UCOverride." + m_Name + ".RightButton"];
            //}
            //else
            //{
                this.lblObject.Text = m_Name;
                this.lblUnit.Text = m_Unit;
                this.btnNegative.Text = m_LeftButtonName;   
                this.btnPositive.Text = m_RightButtonName;
            //}

        }

        private void Override()
        {
            var fCurrentOverride = Single.Parse(m_sActValue);

            if (m_OverrideDec)
            {
                fCurrentOverride -= m_fOverrideStep;

                if (fCurrentOverride < m_fOverrideMin)
                {
                    fCurrentOverride = m_fOverrideMin;
                    this.timer1.Enabled = false;
                }

            }
            else
            {
                fCurrentOverride += m_fOverrideStep;

                if (fCurrentOverride > m_fOverrideMax)
                {
                    fCurrentOverride = m_fOverrideMax;
                    this.timer1.Enabled = false;
                }
            }

            this.WritePLCValueEvent(this.tbxValue.PlcVarName, fCurrentOverride);
        }

        #endregion

    }
}
