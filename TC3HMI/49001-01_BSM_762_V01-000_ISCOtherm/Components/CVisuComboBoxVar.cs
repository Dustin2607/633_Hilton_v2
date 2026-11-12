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

    public class CVisuComboBoxVar : CVisuComboBox
    {

        #region Member variables

        // Application
        private FNumPad frmNumPad;
        private CLanguageManager lm;
        private CUserManager um;

        // Application
        private string m_sPLCVarName;
        private bool m_bDisable;
        private bool m_Recipe;
        private bool m_DisableOnSelectedIndex;
        private CUserLevel m_UserLevel;

        private WritePLCValueDelegate WritePLCValueFunc;
        public event WritePLCValueDelegate WritePLCValueEvent;

        #endregion

        #region Systemcode

        #region Constructor

        /// <summary>
        /// Constructor CVisuComboBoxVar.
        /// </summary>
        public CVisuComboBoxVar()
        {
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
        /// Set variable of recipe.
        /// </summary>
        /// <value>Variable of recipe.</value>
        [Description("Sets variable of recipe."), Category("App")]
        public bool Recipe
        {
            get { return m_Recipe; }
            set { m_Recipe = value; }
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

        /// <summary>
        /// Set variable of recipe.
        /// </summary>
        /// <value>Variable of recipe.</value>
        [Description("Sets variable of recipe."), Category("App")]
        public bool DisableOnSelectedIndex
        {
            set { m_DisableOnSelectedIndex = value; }
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

        #endregion

        #region Events

        #region Form Events

        private void CVisuComboBoxVar_Load(object sender, EventArgs e)
        {
            if (this.lm == null)
                return;
            this.lm.StringDel += new CLanguageManager.InitStringDelegate(this.LoadLanguageStrings);
            this.LoadLanguageStrings();
        }

        #endregion

        #region Object Events

        protected override void OnSelectedIndexChanged(EventArgs e)
        {
            base.OnSelectedIndexChanged(e);

            double myDouble = 0;
            if (IsNumeric(this.SelectedValue, out myDouble))
            {
                if (!m_DisableOnSelectedIndex)
                    this.SetPLCValue(3, m_sPLCVarName, this.SelectedValue.ToString());

                m_DisableOnSelectedIndex = false;
                //MessageBox.Show(this.SelectedValue.ToString());
            }
            else
            {
                //MessageBox.Show("Invalid number: " + this.SelectedValue.ToString());
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

        private bool IsNumeric (object Expression, out double myDouble)
        {
            myDouble = 0;

            if(Expression == null || Expression is DateTime)
                return false;

            if(Expression is Int16 || Expression is Int32 || Expression is Int64 || Expression is Decimal || Expression is Single || Expression is Double || Expression is Boolean)
                return true;
           
            try 
            {
                if(Expression is string)
                    myDouble = Double.Parse(Expression as string);
                else
                    myDouble = Double.Parse(Expression.ToString());
                    return true;
            } 
            catch {} // just dismiss errors but return false
                
            return false;
            
        }

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

        #endregion
    }
}
