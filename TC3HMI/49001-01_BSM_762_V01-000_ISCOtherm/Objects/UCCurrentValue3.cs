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

    public partial class UCCurrentValue3 : UserControlBase
    {
        // TwinCAT references
        private TcAdsClient adsClient;

        // Application
        private CLanguageManager lm;

        private string m_sValueName;
        private string m_sActValue;
        private string m_sSetValueName;
        private string m_sSetValue;
        private string m_sValueUnit;

        private WritePLCValueDelegate WritePLCValueFunc;
        public event WritePLCValueDelegate WritePLCValueEvent;

        // Set color theme
        private Color colorCaption;
        private Color colorRow2;
        private Color colorRow3;

        public UCCurrentValue3()
        {
            InitializeComponent();

            // Set color theme
            //colorCaption = groupBox1.BackColor;
            //colorRow2 = groupBox1.BackColor;
            //colorRow3 = groupBox1.BackColor;
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
                //groupBox1.BackColor = colorRow2;
                //groupBox2.BackColor = colorRow2;
                //groupBox3.BackColor = colorRow2;
                //groupBox4.BackColor = colorRow2;
                //groupBox5.BackColor = colorRow2;
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
            set { this.lm = value; }
        }

        /// <summary>
        /// Set plc variable name.
        /// </summary>
        /// <value>Plc variable name.</value>
        [Description("Sets plc variable name."), Category("App")]
        public string ValueName
        {
            get { return m_sValueName; }
            set {
                    m_sValueName = value;
                    lblValueName.Text = m_sValueName;
                }
        }

        /// <summary>
        /// Set plc variable name.
        /// </summary>
        /// <value>Plc variable name.</value>
        [Description("Sets plc variable name."), Category("Parameter")]
        public string SetValueName
        {
            get { return m_sSetValueName; }
            set
            {
                this.m_sSetValueName = value;
                this.tbxSetValue.PlcVarName = value;
            }
        }

        /// <summary>
        /// Set plc variable name.
        /// </summary>
        /// <value>Plc variable name.</value>
        [Description("Sets plc variable name."), Category("App")]
        public string ActValue
        {
            set {
                    m_sActValue = value;
                    lblActValue.Text = m_sActValue;
                }
        }

        /// <summary>
        /// Set plc variable name.
        /// </summary>
        /// <value>Plc variable name.</value>
        [Description("Sets plc variable name."), Category("App")]
        public string SetValue
        {
            set
            {
                m_sSetValue = value;
                tbxSetValue.Text = m_sSetValue;
            }
        }

        /// <summary>
        /// Set plc var type.
        /// </summary>
        /// <value>Plc var type.</value>
        [Description("Sets plc var type."), Category("VarType")]
        public int VarTypeSetValue
        {
            get { return tbxSetValue.VarType; }
            set { tbxSetValue.VarType = value; }
        }

        /// <summary>
        /// Set plc var min limit.
        /// </summary>
        /// <value>Plc var min limit.</value>
        [Description("Sets plc var min limit."), Category("VarMinLimit")]
        public string VarMinLimitSetValue
        {
            get { return tbxSetValue.VarMinLimit; }
            set { tbxSetValue.VarMinLimit = value; }
        }

        /// <summary>
        /// Set plc var max limit.
        /// </summary>
        /// <value>Plc var max limit.</value>
        [Description("Sets plc var max limit."), Category("VarMaxLimit")]
        public string VarMaxLimitSetValue
        {
            get { return tbxSetValue.VarMaxLimit; }
            set { tbxSetValue.VarMaxLimit = value; }
        }

        /// <summary>
        /// Set plc variable name.
        /// </summary>
        /// <value>Plc variable name.</value>
        [Description("Sets plc variable name."), Category("App")]
        public string ValueUnit
        {
            get { return m_sValueUnit; }
            set {
                    m_sValueUnit = value;
                    lblValueUnit.Text = m_sValueUnit;
                }
        }

        private void UCCurrentValue_Load(object sender, EventArgs e)
        {
            if (this.lm == null)
                return;
            this.lm.StringDel += new CLanguageManager.InitStringDelegate(this.LoadLanguageStrings);
            this.LoadLanguageStrings();
        }

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
                this.lblValueName.Text = lm["UCCurrentValue." + m_sValueName];
                this.lblValueUnit.Text = lm["UCCurrentValue." + m_sValueName + ".Unit"];
            }
            else
            {
                this.lblValueName.Text = m_sValueName;
                this.lblValueUnit.Text = m_sValueUnit;

            }

        }

        #endregion

    }
}
