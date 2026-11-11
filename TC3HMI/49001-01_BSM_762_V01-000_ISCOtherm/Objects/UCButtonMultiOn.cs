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

    public partial class UCButtonMultiOn : UserControlBase
    {
        #region Member enummerations

        #endregion

        #region Member variables

        // TwinCAT references
        private TcAdsClient adsClient;

        // Application
        private CLanguageManager lm;

        private string m_Name;
        private string m_OnName;
        private string[] m_sPlcVarNameOn = new string[8];

        private ushort m_ActStatus;
        private bool[] arbActStatus = new bool[16];

        private WritePLCValueDelegate WritePLCValueFunc;
        public event WritePLCValueDelegate WritePLCValueEvent;

        #endregion

        #region Systemcode

        #region Constructor

        public UCButtonMultiOn()
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
        /// <value>Sets name of on button.</value>
        /// </summary>
        [Description("Sets name of on button."), Category("Parameter")]
        public string OnName
        {
            get { return m_OnName; }
            set { m_OnName = value; }
        }

        /// <summary>
        /// Set plc variable name - on.
        /// </summary>
        /// <value>Plc variable name - on.</value>
        [Description("Sets plc variable name - on."), Category("Parameter")]
        public string PlcVarNameOn1
        {
            get { return m_sPlcVarNameOn[0]; }
            set { this.m_sPlcVarNameOn[0] = value; }
        }

        /// <summary>
        /// Set plc variable name - on.
        /// </summary>
        /// <value>Plc variable name - on.</value>
        [Description("Sets plc variable name - on."), Category("Parameter")]
        public string PlcVarNameOn2
        {
            get { return m_sPlcVarNameOn[1]; }
            set { this.m_sPlcVarNameOn[1] = value; }
        }

        /// <summary>
        /// Set plc variable name - on.
        /// </summary>
        /// <value>Plc variable name - on.</value>
        [Description("Sets plc variable name - on."), Category("Parameter")]
        public string PlcVarNameOn3
        {
            get { return m_sPlcVarNameOn[2]; }
            set { this.m_sPlcVarNameOn[2] = value; }
        }

        /// <summary>
        /// Set plc variable name - on.
        /// </summary>
        /// <value>Plc variable name - on.</value>
        [Description("Sets plc variable name - on."), Category("Parameter")]
        public string PlcVarNameOn4
        {
            get { return m_sPlcVarNameOn[3]; }
            set { this.m_sPlcVarNameOn[3] = value; }
        }

        /// <summary>
        /// Set plc variable name - on.
        /// </summary>
        /// <value>Plc variable name - on.</value>
        [Description("Sets plc variable name - on."), Category("Parameter")]
        public string PlcVarNameOn5
        {
            get { return m_sPlcVarNameOn[4]; }
            set { this.m_sPlcVarNameOn[4] = value; }
        }

        /// <summary>
        /// Set plc variable name - on.
        /// </summary>
        /// <value>Plc variable name - on.</value>
        [Description("Sets plc variable name - on."), Category("Parameter")]
        public string PlcVarNameOn6
        {
            get { return m_sPlcVarNameOn[5]; }
            set { this.m_sPlcVarNameOn[5] = value; }
        }

        /// <summary>
        /// Set plc variable name - on.
        /// </summary>
        /// <value>Plc variable name - on.</value>
        [Description("Sets plc variable name - on."), Category("Parameter")]
        public string PlcVarNameOn7
        {
            get { return m_sPlcVarNameOn[6]; }
            set { this.m_sPlcVarNameOn[6] = value; }
        }

        /// <summary>
        /// Set plc variable name - on.
        /// </summary>
        /// <value>Plc variable name - on.</value>
        [Description("Sets plc variable name - on."), Category("Parameter")]
        public string PlcVarNameOn8
        {
            get { return m_sPlcVarNameOn[7]; }
            set { this.m_sPlcVarNameOn[7] = value; }
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
                //this.LoadLanguageStrings();
            }
        }

        #endregion

        #region Events

        #region Form Events

        private void UCButtonOn_Load(object sender, EventArgs e)
        {
            if (this.lm == null)
                return;
            this.lm.StringDel += new CLanguageManager.InitStringDelegate(this.LoadLanguageStrings);
            this.LoadLanguageStrings();
        }

        #endregion

        #region Object Events

        private void btnOnOff_MouseDown(object sender, MouseEventArgs e)
        {
            for (int i = 0; i <= 7; i++)
            {
                if (!string.IsNullOrEmpty(m_sPlcVarNameOn[i]))
                {
                    this.WritePLCValueEvent(m_sPlcVarNameOn[i], true);
                }
            }         
        }

        private void btnOnOff_MouseUp(object sender, MouseEventArgs e)
        {
            for (int i = 0; i <= 7; i++)
            {
                if (!string.IsNullOrEmpty(m_sPlcVarNameOn[i]))
                {
                    this.WritePLCValueEvent(m_sPlcVarNameOn[i], false);
                }
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
            if (this.lm != null)
            {
                this.lblObject.Text = lm["UCButtonOn." + m_Name];
                this.btnOn.Text = lm["UCButtonOn." + m_Name + ".On"];
                //if (arbActStatus[0])        // Cylinder closed
                //    this.btnOn.Text = lm["UCButtonOn." + m_Name + ".OpenButton"];
                //else if (arbActStatus[1])    // Cylinder opened
                //    this.btnOn.Text = lm["UCButtonOn." + m_Name + ".CloseButton"];
                //else
                //    this.btnOn.Text = lm["UCButtonOn." + m_Name + ".Info"];
            }
            else
            {
                this.lblObject.Text = m_Name;
                this.btnOn.Text = m_OnName;

            }

        }

        #endregion

    }
}
