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

    public partial class UCParameter : UserControl
    {
        #region Member enummerations

        #endregion

        #region Member variables

        // TwinCAT references
        private TcAdsClient adsClient;

        // Application
        private CLanguageManager lm;

        private string m_Name;
        private string m_Unit;
        private string m_LeftButtonName;
        private string m_RightButtonName;

        protected string m_sPlcVarNameValue;

        private string m_sActValue;
        protected string m_sLimitMin;
        protected string m_sLimitMax;
        protected string m_sIncrement;
        protected int m_nVarType;

        private WritePLCValueDelegate WritePLCValueFunc;
        public event WritePLCValueDelegate WritePLCValueEvent;

        #endregion

        #region Systemcode

        #region Constructor

        public UCParameter()
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
        [Browsable(false)]
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
        public string PlcVarNameValue
        {
            get { return m_sPlcVarNameValue; }
            set { this.m_sPlcVarNameValue = value; }
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
                tbxValue.Text = m_sActValue;
            }
        }

        /// <summary>
        /// Set value limit minimum.
        /// </summary>
        /// <value>Value limit minimum.</value>
        [Description("Sets value limit minimum."), Category("Parameter")]
        public string LimitMin
        {
            get { return m_sLimitMin; }
            set { m_sLimitMin = value; }
        }

        /// <summary>
        /// Set value limit maximum.
        /// </summary>
        /// <value>Value limit maximum.</value>
        [Description("Sets value limit maximum."), Category("Parameter")]
        public string LimitMax
        {
            get { return m_sLimitMax; }
            set { m_sLimitMax = value; }
        }

        /// <summary>
        /// Set value of increment.
        /// </summary>
        /// <value>Value increment.</value>
        [Description("Sets value of increment."), Category("Parameter")]
        public string Increment
        {
            get { return m_sIncrement; }
            set { m_sIncrement = value; }
        }

        /// <summary>
        /// Variable type: int16 (int) - 1; double (long real) - 2; string - 3...
        /// </summary>
        [Description("Sets value type: int16 (int) - 1; double (long real) - 2; string - 3"), Category("Parameter")]
        public int VarType
        {
            get { return m_nVarType; }
            set { m_nVarType = value; }
        }

        #endregion

        #region Events

        #region Form Events

        private void UCParameter_Load(object sender, EventArgs e)
        {
            if (this.lm == null)
                return;
            this.lm.StringDel += new CLanguageManager.InitStringDelegate(this.LoadLanguageStrings);
            this.LoadLanguageStrings();
        }

        #endregion

        #region Object Events

        private void btnPlus_MouseDown(object sender, MouseEventArgs e)
        {
            this.btnPlus_MousePressing(this, EventArgs.Empty);         
        }

        private void btnMinus_MouseDown(object sender, MouseEventArgs e)
        {
            this.btnMinus_MousePressing(this, EventArgs.Empty); 
        }

        private void btnPlus_MousePressing(object sender, EventArgs e)
        {
            switch (m_nVarType)
            {
                case 1:
                    // PLC variable int type
                    try
                    {
                        var ActValue = Int16.Parse(m_sActValue);
                        var LimitMax = Int16.Parse(m_sLimitMax);

                        ActValue += Int16.Parse(m_sIncrement);

                        if (ActValue > LimitMax)
                        {
                            ActValue = LimitMax;
                        }

                        this.WritePLCValueEvent(m_sPlcVarNameValue, ActValue);
                    }
                    catch
                    {

                    }

                    break;

                case 2:
                    // PLC variable dint type
                    try
                    {
                        var ActValue = Convert.ToInt32(m_sActValue);
                        var LimitMax = Convert.ToInt32(m_sLimitMax);

                        ActValue += Convert.ToInt32(m_sIncrement);

                        if (ActValue > LimitMax)
                        {
                            ActValue = LimitMax;
                        }

                        this.WritePLCValueEvent(m_sPlcVarNameValue, ActValue);

                    }
                    catch
                    {

                    }
                    break;

                case 3:
                    // Variable uint type
                    try
                    {
                        var ActValue = Convert.ToUInt16(m_sActValue);
                        var LimitMax = Convert.ToUInt16(m_sLimitMax);

                        ActValue += Convert.ToUInt16(m_sIncrement);

                        if (ActValue > LimitMax)
                        {
                            ActValue = LimitMax;
                        }

                        this.WritePLCValueEvent(m_sPlcVarNameValue, ActValue);

                    }
                    catch
                    {

                    }
                    break;

                case 4:
                    // Variable udint type
                    try
                    {
                        var ActValue = Convert.ToUInt32(m_sActValue);
                        var LimitMax = Convert.ToUInt32(m_sLimitMax);

                        ActValue += Convert.ToUInt32(m_sIncrement);

                        if (ActValue > LimitMax)
                        {
                            ActValue = LimitMax;
                        }

                        this.WritePLCValueEvent(m_sPlcVarNameValue, ActValue);

                    }
                    catch
                    {

                    }
                    break;

                case 5:
                    // Variable real type
                    try
                    {
                        var ActValue = Convert.ToSingle(m_sActValue);
                        var LimitMax = Convert.ToSingle(m_sLimitMax);

                        ActValue += Convert.ToSingle(m_sIncrement);

                        if (ActValue > LimitMax)
                        {
                            ActValue = LimitMax;
                        }

                        this.WritePLCValueEvent(m_sPlcVarNameValue, ActValue);

                    }
                    catch
                    {

                    }
                    break;

                case 6:
                    // PLC variable long real type
                    try
                    {
                        var ActValue = Convert.ToDouble(m_sActValue);
                        var LimitMax = Convert.ToDouble(m_sLimitMax);

                        ActValue += Convert.ToDouble(m_sIncrement);

                        if (ActValue > LimitMax)
                        {
                            ActValue = LimitMax;
                        }

                        this.WritePLCValueEvent(m_sPlcVarNameValue, ActValue);

                    }
                    catch
                    {

                    }
                    break;

                case 10:
                    // Variable string type

                    break;

                default:
                    break;
            }
            
        }

        private void btnMinus_MousePressing(object sender, EventArgs e)
        {

            switch (m_nVarType)
            {
                case 1:
                    // PLC variable int type
                    try
                    {
                        var ActValue = Int16.Parse(m_sActValue);
                        var LimitMin = Int16.Parse(m_sLimitMin);

                        ActValue -= Int16.Parse(m_sIncrement);

                        if (ActValue < LimitMin)
                        {
                            ActValue = LimitMin;
                        }

                        this.WritePLCValueEvent(m_sPlcVarNameValue, ActValue);
                    }
                    catch
                    {

                    }

                    break;

                case 2:
                    // PLC variable dint type
                    try
                    {
                        var ActValue = Convert.ToInt32(m_sActValue);
                        var LimitMin = Convert.ToInt32(m_sLimitMin);

                        ActValue -= Convert.ToInt32(m_sIncrement);

                        if (ActValue < LimitMin)
                        {
                            ActValue = LimitMin;
                        }

                        this.WritePLCValueEvent(m_sPlcVarNameValue, ActValue);

                    }
                    catch
                    {

                    }
                    break;

                case 3:
                    // Variable uint type
                    try
                    {
                        var ActValue = Convert.ToUInt16(m_sActValue);
                        var LimitMin = Convert.ToUInt16(m_sLimitMin);

                        ActValue -= Convert.ToUInt16(m_sIncrement);

                        if (ActValue < LimitMin)
                        {
                            ActValue = LimitMin;
                        }

                        this.WritePLCValueEvent(m_sPlcVarNameValue, ActValue);

                    }
                    catch
                    {

                    }
                    break;

                case 4:
                    // Variable udint type
                    try
                    {
                        var ActValue = Convert.ToUInt32(m_sActValue);
                        var LimitMin = Convert.ToUInt32(m_sLimitMin);

                        ActValue -= Convert.ToUInt32(m_sIncrement);

                        if (ActValue < LimitMin)
                        {
                            ActValue = LimitMin;
                        }

                        this.WritePLCValueEvent(m_sPlcVarNameValue, ActValue);

                    }
                    catch
                    {

                    }
                    break;

                case 5:
                    // Variable real type
                    try
                    {
                        var ActValue = Convert.ToSingle(m_sActValue);
                        var LimitMin = Convert.ToSingle(m_sLimitMin);

                        ActValue -= Convert.ToSingle(m_sIncrement);

                        if (ActValue < LimitMin)
                        {
                            ActValue = LimitMin;
                        }

                        this.WritePLCValueEvent(m_sPlcVarNameValue, ActValue);

                    }
                    catch
                    {

                    }
                    break;

                case 6:
                    // PLC variable long real type
                    try
                    {
                        var ActValue = Convert.ToDouble(m_sActValue);
                        var LimitMin = Convert.ToDouble(m_sLimitMin);

                        ActValue -= Convert.ToDouble(m_sIncrement);

                        if (ActValue < LimitMin)
                        {
                            ActValue = LimitMin;
                        }

                        this.WritePLCValueEvent(m_sPlcVarNameValue, ActValue);

                    }
                    catch
                    {

                    }
                    break;

                case 10:
                    // Variable string type

                    break;

                default:
                    break;
            }
        }

        private void tbxValue_Click(object sender, EventArgs e)
        {
            ////Configure Numpad
            //frmNumPad.VarType = m_nVarType;
            //frmNumPad.VarMinLimit = m_sLimitMin;
            //frmNumPad.VarMaxLimit = m_sLimitMax;
            //frmNumPad.PLCVarName = m_sPlcVarNameValue;

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
                this.lblName.Text = lm["UCParameter." + m_Name];
                this.lblUnit.Text = lm["UCParameter." + m_Name + ".Unit"];
                this.btnPlus.Text = lm["UCParameter." + m_Name + ".RightButton"];
                this.btnMinus.Text = lm["UCParameter." + m_Name + ".LeftButton"];
            }
            else
            {
                this.lblName.Text = m_Name;
                this.lblUnit.Text = m_Unit;
                this.btnPlus.Text = m_LeftButtonName;
                this.btnMinus.Text = m_RightButtonName;
            }
        }

        #endregion
    }
}
