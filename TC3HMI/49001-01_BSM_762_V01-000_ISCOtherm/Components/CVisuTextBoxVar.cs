namespace App.Components
{
    using System;
    using System.Runtime.InteropServices;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Drawing;
    using System.Globalization;
    using System.Text;
    using System.Windows.Forms;

    using TwinCAT.Ads;
    using App.Utility;
    using App.Security;

    public class CVisuTextBoxVar : CVisuTextBox
    {
        #region Member enummerations

        // Types of scaling unit
        public enum ScalingUnit
        {
            //_10000 = 0.0001,
            //_1000 = 0.001,
            //_100 = 0.01,
            //_10 = 0.1,
            x1 = 1,
            x10 = 10,
            x100 = 100,
            x1000 = 1000,
            x10000 = 10000
        }

        #endregion

        #region Member variables

        // Application
        private FNumPad frmNumPad;
        private CLanguageManager lm;
        private CUserManager um;

        private int m_nVarType;
        private string m_sVarMinLimit;
        private string m_sVarMaxLimit;
        private string m_sPLCVarName;
        private bool m_bDisable;
        private bool m_bInchOn;
        private ScalingUnit m_ScalingUnit;
        private CUserLevel m_UserLevel;


        private WritePLCValueDelegate WritePLCValueFunc;
        public event WritePLCValueDelegate WritePLCValueEvent;

        private WritePLCStringDelegate WritePLCStringFunc;
        public event WritePLCStringDelegate WritePLCStringEvent;

        #endregion

        #region Systemcode

        #region Constructor

        /// <summary>
        /// Constructor CVisuTextBoxVar.
        /// </summary>
        public CVisuTextBoxVar()
        {
            this.Scaling = ScalingUnit.x1;
            this.UserLevel = CUserLevel.None;
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
        /// Gets the user manager.
        /// </summary>
        /// <value>The user manager.</value>
        [DefaultValue(1)]
        [Description("Gets the user manager."), Category("App")]
        public CUserManager UserManager
        {
            set { this.um = value; }
        }

        /// <summary>
        /// Set plc variable type.
        /// </summary>
        /// <value>Plc variable type.</value>
        [Description("Sets plc variable type."), Category("App")]
        public int VarType
        {
            get { return m_nVarType; }
            set { m_nVarType = value; }
        }

        /// <summary>
        /// Set plc variable minimum limit.
        /// </summary>
        /// <value>Plc variable minimum limit.</value>
        [Description("Sets plc variable minimum limit."), Category("App")]
        public string VarMinLimit
        {
            get { return m_sVarMinLimit; }
            set { m_sVarMinLimit = value; }
        }

        /// <summary>
        /// Set plc variable maximum limit.
        /// </summary>
        /// <value>Plc variable maximum limit.</value>
        [Description("Sets plc variable maximum limit."), Category("App")]
        public string VarMaxLimit
        {
            get { return m_sVarMaxLimit; }
            set { m_sVarMaxLimit = value; }
        }

        /// <summary>
        /// Set plc variable name.
        /// </summary>
        /// <value>Plc variable name.</value>
        [Description("Sets plc variable name."), Category("App")]
        public string PlcVarName
        {
            get { return m_sPLCVarName; }
            set { m_sPLCVarName = value; }
        }

        /// <summary>
        /// Set scaling unit.
        /// </summary>
        /// <value>Scaling Unit.</value>
        [Description("Sets scaling unit."), Category("App")]
        public ScalingUnit Scaling
        {
            get { return m_ScalingUnit; }
            set { m_ScalingUnit = value; }
        }

        /// <summary>
        /// Sets user level.
        /// </summary>
        /// <value>User level.</value>
        [Description("Sets user level."), Category("App")]
        public CUserLevel UserLevel
        {
            get { return m_UserLevel; }
            set { m_UserLevel = value; }
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
                    this.Enabled = false;
                    this.BackColor = System.Drawing.SystemColors.Control;
                }
                else
                {
                    this.Enabled = true;
                    this.BackColor = Color.White;
                }                
            }
        }

           /// Set InchOn.
        /// </summary>
        /// <value>Set disable.</value>
        [Description("Set InchOn."), Category("InchOn")]
        public bool InchOn
        {
            get { return m_bInchOn; }
            set { m_bInchOn = value; }
        }

#endregion

        #region Events

        #region Form Events

        private void CVisuTextBoxVar_Load(object sender, EventArgs e)
        {
            if (this.lm == null)
                return;
            this.lm.StringDel += new CLanguageManager.InitStringDelegate(this.LoadLanguageStrings);
            this.LoadLanguageStrings();
        }

        #endregion

        #region Object Events

        protected override void OnMouseUp(MouseEventArgs e)
        {
            base.OnMouseUp(e);

            if(this.m_UserLevel < um.CurrentUserLevel)
            {
                um.LoginDialog(false, false);
            }

            if (this.m_UserLevel >= um.CurrentUserLevel)
            {
                if (m_nVarType == 10) //string
                {
                    InputBoxValidation validation = delegate (string val)
                    {
                        if (val == "")
                            return "Name cannot be empty.";
                        if (!(new System.Text.RegularExpressions.Regex(@"^[a-zA-Z0-9_-]+$")).IsMatch(val))
                            return "Name is not valid.";
                        return "";
                    };

                    FKeyboard inputBox = new FKeyboard();

                    //Configure Numpad
                    string value = this.Text;
                    string caption = "Enter your name";
                    string promptText = "Name:" /*tclm["frmNCEditor.FailedOpen"]*/;

                    
                    if (inputBox.Show(caption, promptText, ref value, validation) == DialogResult.OK)
                    {
                        //Set plc value
                        this.SetPLCValue(m_nVarType, m_sPLCVarName, value, Convert.ToInt32(m_sVarMaxLimit), InchOn);
                    }

                    inputBox.Dispose();

                }
                else                 //number
                {
                    frmNumPad = new FNumPad();

                    //Configure Numpad
                    frmNumPad.VarType = m_nVarType;
                    frmNumPad.VarMinLimit = m_sVarMinLimit;
                    frmNumPad.VarMaxLimit = m_sVarMaxLimit;

                    //Show NumPad
                    string value = this.Text;

                    if (frmNumPad.Show(ref value) == DialogResult.OK)
                    {
                        //Set plc value
                        this.SetPLCValue(m_nVarType, m_sPLCVarName, value, (int)m_ScalingUnit, InchOn);

                    }

                    frmNumPad.Dispose();
                }
            }
        }

        #endregion

        #region User Events

        #endregion

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

        /// <summary>
        /// Sets the write PLC string delegate.
        /// </summary>
        [Description("Sets the write PLC string delegate."), Category("App")]
        public void InstallWritePLCStringDelegate(WritePLCStringDelegate WritePLCString)
        {
            if (this.WritePLCStringFunc != null)
            {
                this.WritePLCStringEvent = (WritePLCStringDelegate)Delegate.Remove(this.WritePLCStringEvent, new WritePLCStringDelegate(this.WritePLCStringFunc.Invoke));
            }
            this.WritePLCStringFunc = WritePLCString;
            if (this.WritePLCStringFunc != null)
            {
                this.WritePLCStringEvent = (WritePLCStringDelegate)Delegate.Combine(this.WritePLCStringEvent, new WritePLCStringDelegate(this.WritePLCStringFunc.Invoke));
            }
        }

        protected virtual void RaiseWritePLStringe(string PlcVarNameValue, string ActValue, int Lenght)
        {
            this.WritePLCStringEvent(PlcVarNameValue, ActValue, Lenght);
        }

        #endregion

        #region Private methods

        private void LoadLanguageStrings()
        {
            if (this.lm != null)
            {

            }
            else
            {

            }

        }

        private void SetPLCValue(int vartype, string varname, string value, int scaling, bool InchOn)
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
                        this.WritePLCValueEvent(varname, Convert.ToInt16(Int16.Parse(value, NumberStyles.Number, CultureInfo.InvariantCulture) * scaling));

                        break;

                    case 2:
                        // PLC variable dint type
                        this.WritePLCValueEvent(varname, Convert.ToInt32(Int32.Parse(value, NumberStyles.Number, CultureInfo.InvariantCulture) * scaling));

                        break;

                    case 3:
                        // PLC variable uint type
                        this.WritePLCValueEvent(varname, Convert.ToUInt16(UInt16.Parse(value, NumberStyles.Number, CultureInfo.InvariantCulture) * scaling));

                        break;

                    case 4:
                        // PLC variable udint type
                        this.WritePLCValueEvent(varname, Convert.ToUInt32(UInt32.Parse(value, NumberStyles.Number, CultureInfo.InvariantCulture) * scaling));

                        break;

                    case 5:
                        // PLC variable real type
                        if (InchOn)
                        this.WritePLCValueEvent(varname, CUtility.ConvCaltoMMfloat(Convert.ToSingle(Single.Parse(value, NumberStyles.Number, CultureInfo.InvariantCulture)) * scaling));

                        else
                        this.WritePLCValueEvent(varname, Convert.ToSingle(Single.Parse(value, NumberStyles.Number, CultureInfo.InvariantCulture) * scaling));
                        
                        break;

                    case 6:
                        // PLC variable long real type
                        if (InchOn)
                        this.WritePLCValueEvent(varname, CUtility.ConvCaltoMM(Convert.ToDouble(Double.Parse(value, NumberStyles.Number, CultureInfo.InvariantCulture)) * scaling));

                        else
                            this.WritePLCValueEvent(varname, Convert.ToDouble(Double.Parse(value, NumberStyles.Number, CultureInfo.InvariantCulture) * scaling));

                        break;

                    case 10:
                        // PLC variable string type
                        this.WritePLCStringEvent(varname, value, scaling);

                        break;

                    default:
                        break;
                }

            }
            catch
            {
            
            }

        }

        #endregion
    }
}
