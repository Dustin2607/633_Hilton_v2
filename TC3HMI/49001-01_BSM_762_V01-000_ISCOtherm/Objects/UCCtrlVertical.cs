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

    public partial class UCCtrlVertical : UserControlBase
    {
        #region Member enummerations

        #endregion

        #region Member variables

        // TwinCAT references
        private TcAdsClient adsClient;

        // Application
        private CLanguageManager lm;
        private CUserManager um;

        private bool m_bMirrorCtrl = false;

        private string m_Name;
        private string m_Unit;
        private string m_TopButtonName;
        private string m_BottomButtonName;

        private string m_sPlcVarNameNegative;
        private string m_sPlcVarNamePositive;

        private string m_sActValue;
        private bool m_bActValueVisable;

        private ushort m_ActStatus;
        private bool[] arbActStatus = new bool[16];

        private WritePLCValueDelegate WritePLCValueFunc;
        public event WritePLCValueDelegate WritePLCValueEvent;

        #endregion

        #region Systemcode

        #region Constructor

        public UCCtrlVertical()
        {
            InitializeComponent();
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

        /// <summary>
        /// Gets the user manager.
        /// </summary>
        /// <value>The user manager.</value>
        [DefaultValue(1)]
        [Description("Gets the user manager."), Category("App")]
        public CUserManager UserManager
        {
            set { this.um = value; }
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
        /// <value>Sets name of top button.</value>
        /// </summary>
        [Description("Sets name of top button."), Category("Parameter")]
        public string TopButtonName
        {
            get { return m_TopButtonName; }
            set { m_TopButtonName = value; }
        }

        /// </summary>
        /// <value>Sets name of bottom button.</value>
        /// </summary>
        [Description("Sets name of bottom button."), Category("Parameter")]
        public string BottomButtonName
        {
            get { return m_BottomButtonName; }
            set { m_BottomButtonName = value; }
        }

        /// <summary>
        /// Set plc variable name - negative.
        /// </summary>
        /// <value>Plc variable name - negative.</value>
        [Description("Sets plc variable name - negative."), Category("Parameter")]
        public string PlcVarNameNegative
        {
            get { return m_sPlcVarNameNegative; }
            set { this.m_sPlcVarNameNegative = value; }
        }

        /// <summary>
        /// Set plc variable name - positive.
        /// </summary>
        /// <value>Plc variable name - positive.</value>
        [Description("Sets plc variable name - positive."), Category("Parameter")]
        public string PlcVarNamePositive
        {
            get { return m_sPlcVarNamePositive; }
            set { this.m_sPlcVarNamePositive = value; }
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

        /// </summary>
        /// <value>Sets mirror control.</value>
        /// </summary>
        [Description("Sets name of object."), Category("Parameter")]
        public bool ActValueVisable
        {
            get { return this.m_bActValueVisable; }
            set
            {
                this.m_bActValueVisable = value;
                tbxValue.Visible = ActValueVisable;
            }
        }

        /// <summary>
        /// Get plc status.
        /// </summary>
        /// <value>Plc status.</value>
        [Browsable(false)]
        [Description("Gets plc status."), Category("Parameter")]
        public ushort ActStatus
        {
            get { return m_ActStatus; }
            set
            {
                m_ActStatus = value;
                arbActStatus = CUtility.BinaryConverter.UShortToBinary(m_ActStatus);
                this.LoadLanguageStrings();
            }
        }

        #endregion

        #region Events

        #region Form Events

        private void UCCtrlHorizontal_Load(object sender, EventArgs e)
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
            if (m_bMirrorCtrl == true)
            {
                this.WritePLCValueEvent(m_sPlcVarNameNegative, true);
            }
            else
            {
                this.WritePLCValueEvent(m_sPlcVarNamePositive, true);
            }
        }

        private void btnPositive_MouseUp(object sender, MouseEventArgs e)
        {
            if (m_bMirrorCtrl == true)
            {
                this.WritePLCValueEvent(m_sPlcVarNameNegative, false);
            }
            else
            {
                this.WritePLCValueEvent(m_sPlcVarNamePositive, false);
            }
        }

        private void btnNegative_MouseDown(object sender, MouseEventArgs e)
        {
            if (m_bMirrorCtrl == true)
            {
                this.WritePLCValueEvent(m_sPlcVarNamePositive, true);
            }
            else
            {
                this.WritePLCValueEvent(m_sPlcVarNameNegative, true);
            }
        }

        private void btnNegative_MouseUp(object sender, MouseEventArgs e)
        {
            if (m_bMirrorCtrl == true)
            {
                this.WritePLCValueEvent(m_sPlcVarNamePositive, false);
            }
            else
            {
                this.WritePLCValueEvent(m_sPlcVarNameNegative, false);
            }
        }

        #endregion

        #region User Events

        #endregion

        #endregion

        #region Interface implementation

        #endregion

        #region Public functions

        /// <summary>
        /// Sets the write PLC value delegate.
        /// </summary>
        [Description("Sets the write PLC value delegate."), Category("App")]
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
            if (this.lm != null)
            {
                this.lblObject.Text = lm["UCCtrlVertical." + m_Name];
                this.lblUnit.Text = lm["UCCtrlVertical." + m_Name + ".Unit"];
                this.btnPositive.Text = lm["UCCtrlVertical." + m_Name + ".TopButton"];
                this.btnNegative.Text = lm["UCCtrlVertical." + m_Name + ".BottomButton"];
            }
            else
            {
                this.lblObject.Text = m_Name;
                this.lblUnit.Text = m_Unit;
                this.btnPositive.Text = m_TopButtonName;
                this.btnNegative.Text = m_BottomButtonName;
            }

        }

        #endregion

    }
}
