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

    public partial class UCParameterGet : UCParameter
    {
        #region Member enummerations

        #endregion

        #region Member variables

        // Application
        private string m_sActGetValue;

        #endregion

        #region Systemcode

        #region Constructor

        public UCParameterGet()
        {
            InitializeComponent();
        }

        #endregion

        private void btnPlus_MouseDown(object sender, MouseEventArgs e)
        {

        }

        #endregion

        #region Properties
        /// <summary>
        /// Set plc value.
        /// </summary>
        /// <value>Plc value.</value>
        [Browsable(false)]
        [Description("Sets plc value."), Category("Parameter")]
        public string ActGetValue
        {
            get { return m_sActGetValue; }
            set { m_sActGetValue = CUtility.DoFormat(value); }
        }
        #endregion

        #region Events

        #region Form Events

        #endregion

        #region Object Events

        private void btnGetValue_MouseDown(object sender, MouseEventArgs e)
        {
            switch (m_nVarType)
            {
                case 1:
                    // PLC variable int type
                    try
                    {
                        var ActValue = Convert.ToInt16(m_sActGetValue);
                        var LimitMin = Convert.ToInt16(m_sLimitMin);
                        var LimitMax = Convert.ToInt16(m_sLimitMax);

                        if (ActValue > LimitMax)
                        {
                            ActValue = LimitMax;
                        }
                        else if (ActValue < LimitMin)
                        {
                            ActValue = LimitMin;
                        }

                        this.RaiseWritePLCValue(m_sPlcVarNameValue, ActValue);

                    }
                    catch
                    {

                    }

                    break;

                case 2:
                    // PLC variable dint type
                    try
                    {
                        var ActValue = Convert.ToInt32(m_sActGetValue);
                        var LimitMin = Convert.ToInt32(m_sLimitMin);
                        var LimitMax = Convert.ToInt32(m_sLimitMax);

                        if (ActValue > LimitMax)
                        {
                            ActValue = LimitMax;
                        }
                        else if (ActValue < LimitMin)
                        {
                            ActValue = LimitMin;
                        }

                        this.RaiseWritePLCValue(m_sPlcVarNameValue, ActValue);

                    }
                    catch
                    {

                    }

                    break;

                case 3:
                    // Variable uint type
                    try
                    {
                        var ActValue = Convert.ToUInt16(m_sActGetValue);
                        var LimitMin = Convert.ToUInt16(m_sLimitMin);
                        var LimitMax = Convert.ToUInt16(m_sLimitMax);

                        if (ActValue > LimitMax)
                        {
                            ActValue = LimitMax;
                        }
                        else if (ActValue < LimitMin)
                        {
                            ActValue = LimitMin;
                        }

                        this.RaiseWritePLCValue(m_sPlcVarNameValue, ActValue);

                    }
                    catch
                    {

                    }
                    break;

                case 4:
                    // Variable udint type
                    try
                    {
                        var ActValue = Convert.ToUInt32(m_sActGetValue);
                        var LimitMin = Convert.ToUInt32(m_sLimitMin);
                        var LimitMax = Convert.ToUInt32(m_sLimitMax);

                        if (ActValue > LimitMax)
                        {
                            ActValue = LimitMax;
                        }
                        else if (ActValue < LimitMin)
                        {
                            ActValue = LimitMin;
                        }

                        this.RaiseWritePLCValue(m_sPlcVarNameValue, ActValue);

                    }
                    catch
                    {

                    }
                    break;

                case 5:
                    // Variable real type
                    try
                    {
                        var ActValue = Convert.ToSingle(m_sActGetValue);
                        var LimitMin = Convert.ToSingle(m_sLimitMin);
                        var LimitMax = Convert.ToSingle(m_sLimitMax);

                        if (ActValue > LimitMax)
                        {
                            ActValue = LimitMax;
                        }
                        else if (ActValue < LimitMin)
                        {
                            ActValue = LimitMin;
                        }

                        this.RaiseWritePLCValue(m_sPlcVarNameValue, ActValue);

                    }
                    catch
                    {

                    }
                    break;

                case 6:
                    // PLC variable long real type
                    try
                    {
                        var ActValue = Convert.ToDouble(m_sActGetValue);
                        var LimitMin = Convert.ToDouble(m_sLimitMin);
                        var LimitMax = Convert.ToDouble(m_sLimitMax);

                        if (ActValue > LimitMax)
                        {
                            ActValue = LimitMax;
                        }
                        else if (ActValue < LimitMin)
                        {
                            ActValue = LimitMin;
                        }

                        this.RaiseWritePLCValue(m_sPlcVarNameValue, ActValue);

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

        #endregion

        #region User Events

        #endregion

        #endregion

        #region Interface implementation

        #endregion

        #region Public functions

        #endregion

        #region Private methods

        #endregion
    }
}
