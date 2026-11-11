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

    public partial class UCButtonOnOff : UserControlBase
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
        private string m_OffName;
        private ushort m_ActStatus;
        private bool[] arbActStatus = new bool[16];

        private string m_sPlcVarNameOn;
        private string m_sPlcVarNameOff;

        private Label lblAutoSize;

        private WritePLCValueDelegate WritePLCValueFunc;
        public event WritePLCValueDelegate WritePLCValueEvent;

        #endregion

        #region Systemcode

        #region Constructor

        public UCButtonOnOff()
        {
            InitializeComponent();

            lblAutoSize = new Label();
            lblAutoSize.AutoSize = true;
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

        /// </summary>
        /// <value>Sets name of off button.</value>
        /// </summary>
        [Description("Sets name of off button."), Category("Parameter")]
        public string OffName
        {
            get { return m_OffName; }
            set { m_OffName = value; }
        }

        /// <summary>
        /// Set plc variable name - on.
        /// </summary>
        /// <value>Plc variable name - on.</value>
        [Description("Sets plc variable name - on."), Category("Parameter")]
        public string PlcVarNameOn
        {
            get { return m_sPlcVarNameOn; }
            set { this.m_sPlcVarNameOn = value; }
        }

        /// <summary>
        /// Set plc variable name - off.
        /// </summary>
        /// <value>Plc variable name - off.</value>
        [Description("Sets plc variable name - off."), Category("Parameter")]
        public string PlcVarNameOff
        {
            get { return m_sPlcVarNameOff; }
            set { this.m_sPlcVarNameOff = value; }
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
                LoadLanguageStrings();
            }
        }

        #endregion

        #region Events

        #region Form Events

        private void UCButtonOnOff_Load(object sender, EventArgs e)
        {
            if (this.lm == null)
                return;
            this.lm.StringDel += new CLanguageManager.InitStringDelegate(this.LoadLanguageStrings);
            this.LoadLanguageStrings();
        }

        #endregion

        #region Object Events

        private void btnOn_MouseDown(object sender, MouseEventArgs e)
        {
            this.WritePLCValueEvent(m_sPlcVarNameOn, true);
            this.WritePLCValueEvent(m_sPlcVarNameOff, false);
        }

        private void btnOn_MouseUp(object sender, MouseEventArgs e)
        {
            this.WritePLCValueEvent(m_sPlcVarNameOn, false);
            this.WritePLCValueEvent(m_sPlcVarNameOff, false);
        }

        private void btnOff_MouseDown(object sender, MouseEventArgs e)
        {
            this.WritePLCValueEvent(m_sPlcVarNameOn, false);
            this.WritePLCValueEvent(m_sPlcVarNameOff, true);
        }

        private void btnOff_MouseUp(object sender, MouseEventArgs e)
        {
            this.WritePLCValueEvent(m_sPlcVarNameOn, false);
            this.WritePLCValueEvent(m_sPlcVarNameOff, false);
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
                this.lblObject.Text = lm["UCButtonOnOff." + m_Name];
                this.lblAutoSize.Text = this.lblObject.Text;
                this.lblObject.Width = this.lblAutoSize.Width;
                this.lblObject.Height = this.lblAutoSize.Height + this.lblAutoSize.Height; 

                this.btnOn.Text = lm["UCButtonOnOff." + m_Name + ".On"];
                this.btnOff.Text = lm["UCButtonOnOff." + m_Name + ".Off"];

                this.lblObject.Left = (this.Width - this.lblObject.Width) / 2;

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
                this.lblAutoSize.Text = this.lblObject.Text;
                this.lblObject.Width = this.lblAutoSize.Width;

                this.lblObject.Left = (this.Width - this.lblObject.Width) / 2;

                this.btnOn.Text = m_OnName;
                this.btnOff.Text = m_OffName;
            }

            

        }

        #endregion
    }
}
