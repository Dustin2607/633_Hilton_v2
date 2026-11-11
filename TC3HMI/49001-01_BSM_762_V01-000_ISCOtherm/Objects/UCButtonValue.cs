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
    using System.Globalization;

    public partial class UCButtonValue : UserControlBase
    {
        #region Member enummerations

        #endregion

        #region Member variables

        // TwinCAT references
        private TcAdsClient adsClient;

        // Application
        private CLanguageManager lm;

        private string m_LblOnName;
        private string m_LblOffName;
        private bool m_bDisable;
        private string m_BtnOnName;
        private string m_BtnOffName;
        private ushort m_ActStatus;
        private bool[] arbActStatus = new bool[16];

        private string m_sPlcVarName;
        private int m_nVarType;
        private string m_sValueOn;
        private string m_sValueOff;

        private WritePLCValueDelegate WritePLCValueFunc;
        public event WritePLCValueDelegate WritePLCValueEvent;

        #endregion

        #region Systemcode

        #region Constructor

        public UCButtonValue()
        {
            InitializeComponent();

            this.btnOn.BackColor = System.Drawing.SystemColors.Control;
            this.btnOff.BackColor = System.Drawing.SystemColors.Control;
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
            get { return this.lm; }
            set { this.lm = value; }

        }

        /// </summary>
        /// <value>Sets name of object.</value>
        /// </summary>
        [Description("Sets name of object."), Category("Parameter")]
        public string ObjectOnName
        {
            get { return m_LblOnName; }
            set { m_LblOnName = value; }
        }

        /// </summary>
        /// <value>Sets name of object.</value>
        /// </summary>
        [Description("Sets name of object."), Category("Parameter")]
        public string ObjectOffName
        {
            get { return m_LblOffName; }
            set { m_LblOffName = value; }
        }

        /// Set disable.
        /// </summary>
        /// <value>Set disable.</value>
        [Description("Set disable."), Category("Disable")]
        public bool Disable
        {
            get { return m_bDisable; }
            set
            {
                m_bDisable = value;
                if (m_bDisable)
                {
                    this.btnOn.Enabled = false;
                    this.btnOff.Enabled = false;
                    this.btnOn.ForeColor = System.Drawing.SystemColors.ControlDark;
                    this.btnOff.ForeColor = System.Drawing.SystemColors.ControlDark;
                }
                else
                {
                    this.btnOn.Enabled = true;
                    this.btnOff.Enabled = true;
                    this.btnOn.ForeColor = System.Drawing.SystemColors.ControlText;
                    this.btnOff.ForeColor = System.Drawing.SystemColors.ControlText;
                }
            }
        }

        /// </summary>
        /// <value>Sets name of on button.</value>
        /// </summary>
        [Description("Sets name of on button."), Category("Parameter")]
        public string BtnOnName
        {
            get { return m_BtnOnName; }
            set { m_BtnOnName = value; }
        }

        /// </summary>
        /// <value>Sets name of off button.</value>
        /// </summary>
        [Description("Sets name of off button."), Category("Parameter")]
        public string BtnOffName
        {
            get { return m_BtnOffName; }
            set { m_BtnOffName = value; }
        }

        /// <summary>
        /// Set plc variable name.
        /// </summary>
        /// <value>Plc variable name.</value>
        [Description("Sets plc variable name."), Category("Parameter")]
        public string PlcVarName
        {
            get { return m_sPlcVarName; }
            set { this.m_sPlcVarName = value; }
        }

        /// <summary>
        /// Set plc variable type.
        /// </summary>
        /// <value>Plc variable type.</value>
        [Description("Sets plc variable type."), Category("Parameter")]
        public int VarType
        {
            get { return m_nVarType; }
            set { this.m_nVarType = value; }
        }

        /// <summary>
        /// Set plc value.
        /// </summary>
        /// <value>Plc value.</value>
        [Description("Sets plc variable type."), Category("Parameter")]
        public string ValueOn
        {
            get { return m_sValueOn; }
            set { this.m_sValueOn = value; }
        }

        /// <summary>
        /// Set plc value.
        /// </summary>
        /// <value>Plc value.</value>
        [Description("Sets plc variable type."), Category("Parameter")]
        public string ValueOff
        {
            get { return m_sValueOff; }
            set { this.m_sValueOff = value; }
        }

        /// <summary>
        /// Get plc status.
        /// </summary>
        /// <value>Plc status.</value>
        [Browsable(false)]
        [Description("Gets plc status."), Category("Parameter")]
        public ushort ActStatusOn
        {
            get { return m_ActStatus; }
            set
            {
                m_ActStatus = value;
                arbActStatus = Utility.CUtility.BinaryConverter.UShortToBinary(m_ActStatus);

                if (arbActStatus[0])
                {
                    this.btnOn.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
                    this.btnOff.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Regular);

                    //this.btnOn.BackgroundImage = Properties.Resources.TabActive;
                    //this.btnOff.BackgroundImage = Properties.Resources.GrommetNoActive;
                }

                if (arbActStatus[1])
                {
                    this.btnOn.BackColor = Color.Lime;
                }
                else
                {

                    this.btnOn.BackColor = System.Drawing.SystemColors.Control;
                }
                //LoadLanguageStrings();
            }
        }

        /// <summary>
        /// Get plc status.
        /// </summary>
        /// <value>Plc status.</value>
        [Browsable(false)]
        [Description("Gets plc status."), Category("Parameter")]
        public ushort ActStatusOff
        {
            get { return m_ActStatus; }
            set
            {
                m_ActStatus = value;
                arbActStatus = Utility.CUtility.BinaryConverter.UShortToBinary(m_ActStatus);

                if (arbActStatus[0])
                {
                    this.btnOn.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Regular);
                    this.btnOff.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);

                    //this.btnOn.BackgroundImage = Properties.Resources.GrommetActive;
                    //this.btnOff.BackgroundImage = Properties.Resources.TabNoActive;
                }

                if (arbActStatus[1])
                {
                    this.btnOff.BackColor = Color.Lime;
                }
                else
                {
                    this.btnOff.BackColor = System.Drawing.SystemColors.Control;
                }

                //LoadLanguageStrings();
            }
        }

        #endregion

        #region Events

        #region Form Events

        private void UCButtonValue_Load(object sender, EventArgs e)
        {
            if (this.lm == null)
                return;
            this.lm.StringDel += new CLanguageManager.InitStringDelegate(this.LoadLanguageStrings);
            this.LoadLanguageStrings();
        }

        #endregion

        #region Object Events

        private void btnOn_MouseDown(object sender, EventArgs e)
        {
            //Set plc value
            this.SetPLCValue(m_nVarType, m_sPlcVarName, m_sValueOn);
        }

        private void btnOn_MouseUp(object sender, EventArgs e)
        {
            //Set plc value
            this.SetPLCValue(m_nVarType, m_sPlcVarName, "0");
        }

        private void btnOff_MouseDown(object sender, EventArgs e)
        {
            //Set plc value
            this.SetPLCValue(m_nVarType, m_sPlcVarName, m_sValueOff);
        }

        private void btnOff_MouseUp(object sender, EventArgs e)
        {
            //Set plc value
            this.SetPLCValue(m_nVarType, m_sPlcVarName, "0");
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

        private void SetPLCValue(int vartype, string varname, string value)
        {

            if ((value == "") || (varname == ""))
                return;

            //Set PLC Variable
            try
            {
                switch (vartype)
                {
                    case 1:
                        // PLC variable int type
                        this.WritePLCValueEvent(varname, Int16.Parse(value, NumberStyles.Number, CultureInfo.InvariantCulture));

                        break;

                    case 2:
                        // PLC variable dint type
                        this.WritePLCValueEvent(varname, Int32.Parse(value, NumberStyles.Number, CultureInfo.InvariantCulture));

                        break;

                    case 3:
                        // PLC variable uint type
                        this.WritePLCValueEvent(varname, UInt16.Parse(value, NumberStyles.Number, CultureInfo.InvariantCulture));

                        break;

                    case 4:
                        // PLC variable udint type
                        this.WritePLCValueEvent(varname, UInt32.Parse(value, NumberStyles.Number, CultureInfo.InvariantCulture));

                        break;

                    case 5:
                        // PLC variable real type
                        this.WritePLCValueEvent(varname, Single.Parse(value, NumberStyles.Number, CultureInfo.InvariantCulture));

                        break;

                    case 6:
                        // PLC variable long real type
                        this.WritePLCValueEvent(varname, Double.Parse(value, NumberStyles.Number, CultureInfo.InvariantCulture));

                        break;

                    case 10:
                        // PLC variable string type
                        this.WritePLCValueEvent(varname, value);

                        break;

                    default:
                        break;
                }

            }
            catch
            {

            }

        }

        private void LoadLanguageStrings()
        {
            //if (this.lm != null)
            //{
            //    this.lblObject.Text = lm["UCCylinder." + m_Name];

            //    if (arbActStatus[0])        // Cylinder closed
            //        this.btnButton.Text = lm["UCCylinder." + m_Name + ".OpenButton"];
            //    else if (arbActStatus[1])    // Cylinder opened
            //        this.btnButton.Text = lm["UCCylinder." + m_Name + ".CloseButton"];
            //    else
            //        this.btnButton.Text = lm["UCCylinder." + m_Name + ".Info"];
            //}
            //else
            //{
            this.btnOn.Text = m_BtnOnName;
            this.btnOff.Text = m_BtnOffName;
            //}

        }

        #endregion
    }
}
