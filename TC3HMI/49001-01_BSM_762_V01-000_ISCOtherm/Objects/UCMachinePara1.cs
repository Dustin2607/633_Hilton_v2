namespace App.Components
{
    using System;
    using System.Runtime.InteropServices;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Drawing;
    using System.Data;
    using System.Text;
    using System.Windows.Forms;

    using TwinCAT.Ads;
    using App.Utility;
    using App.Security;

    public partial class UCMachinePara1 : UserControl
    {

        #region Member enummerations

        #endregion

        #region Member variables

        // TwinCAT references
        private TcAdsClient adsClient;

        // Application
        private CLanguageManager lm;
        private CUserManager um;

        private string m_Name;

        // Set color theme
        private Color colorCaption;
        private Color colorRow2;
        private Color colorRow3;

        #endregion

        #region Systemcode

        #region Constructor

        /// <summary>
        /// Constructor UCOverride.
        /// </summary>
        public UCMachinePara1()
        {
            InitializeComponent();

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
        [Description("Gets or sets the language manager."), Category("App")]
        public CLanguageManager LanguageManager
        {
            set { this.lm = value; }
        }

        /// <summary>
        /// Gets / sets the ads server reference.
        /// </summary>
        /// <value>The ads server ref.</value>
        [Description("Gets / sets the ads client reference."), Category("App")]
        public TcAdsClient AdsClientRef
        {
            get { return this.adsClient; }
            set { this.adsClient = value; }
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

        #region Velocity

        /// <summary>
        /// Set plc variable name - manual velocity.
        /// </summary>
        /// <value>Plc variable name - manual velocity.</value>
        [Description("Sets plc variable name - manual velocity."), Category("Velocity")]
        public string PlcVarNameManualVelocity
        {
            get { return tbxManualVelocity.PlcVarName; }
            set { tbxManualVelocity.PlcVarName = value; }
        }
        /// <summary>
        /// Set plc var type - manual velocity.
        /// </summary>
        /// <value>Plc var type - manual velocity.</value>
        [Description("Sets plc var type - manual velocity."), Category("VarType")]
        public int VarTypeManualVelocity
        {
            get { return tbxManualVelocity.VarType; }
            set { tbxManualVelocity.VarType = value; }
        }
        /// <summary>
        /// Set plc var min limit - manual velocity.
        /// </summary>
        /// <value>Plc var min limit - manual velocity.</value>
        [Description("Sets plc var min limit - manual velocity."), Category("VarMinLimit")]
        public string VarMinLimitManualVelocity
        {
            get { return tbxManualVelocity.VarMinLimit; }
            set { tbxManualVelocity.VarMinLimit = value; }
        }
        /// <summary>
        /// Set plc var max limit - manual velocity.
        /// </summary>
        /// <value>Plc var max limit - manual velocity.</value>
        [Description("Sets plc var max limit - manual velocity."), Category("VarMaxLimit")]
        public string VarMaxLimitManualVelocity
        {
            get { return tbxManualVelocity.VarMaxLimit; }
            set { tbxManualVelocity.VarMaxLimit = value; }
        }

        /// <summary>
        /// Set plc variable name - home velocity.
        /// </summary>
        /// <value>Plc variable name - home velocity.</value>
        [Description("Sets plc variable name - home velocity."), Category("Velocity")]
        public string PlcVarNameHomeVelocity
        {
            get { return tbxHomeVelocity.PlcVarName; }
            set { tbxHomeVelocity.PlcVarName = value; }
        }
        /// <summary>
        /// Set plc var type - home velocity.
        /// </summary>
        /// <value>Plc var type - home velocity.</value>
        [Description("Sets plc var type - home velocity."), Category("VarType")]
        public int VarTypeHomeVelocity
        {
            get { return tbxHomeVelocity.VarType; }
            set { tbxHomeVelocity.VarType = value; }
        }
        /// <summary>
        /// Set plc var min limit - home velocity.
        /// </summary>
        /// <value>Plc var min limit - home velocity.</value>
        [Description("Sets plc var min limit - home velocity."), Category("VarMinLimit")]
        public string VarMinLimitHomeVelocity
        {
            get { return tbxHomeVelocity.VarMinLimit; }
            set { tbxHomeVelocity.VarMinLimit = value; }
        }
        /// <summary>
        /// Set plc var max limit - home velocity.
        /// </summary>
        /// <value>Plc var max limit - home velocity.</value>
        [Description("Sets plc var max limit - home velocity."), Category("VarMaxLimit")]
        public string VarMaxLimitHomeVelocity
        {
            get { return tbxHomeVelocity.VarMaxLimit; }
            set { tbxHomeVelocity.VarMaxLimit = value; }
        }

        /// <summary>
        /// Set plc variable name - auto velocity.
        /// </summary>
        /// <value>Plc variable name - auto velocity.</value>
        [Description("Sets plc variable name - auto velocity."), Category("Velocity")]
        public string PlcVarNameAutoVelocity
        {
            get { return tbxAutoVelocity.PlcVarName; }
            set { tbxAutoVelocity.PlcVarName = value; }
        }
        /// <summary>
        /// Set plc var type - auto velocity.
        /// </summary>
        /// <value>Plc var type - auto velocity.</value>
        [Description("Sets plc var type - auto velocity."), Category("VarType")]
        public int VarTypeAutoVelocity
        {
            get { return tbxAutoVelocity.VarType; }
            set { tbxAutoVelocity.VarType = value; }
        }
        /// <summary>
        /// Set plc var min limit - auto velocity.
        /// </summary>
        /// <value>Plc var min limit - auto velocity.</value>
        [Description("Sets plc var min limit - auto velocity."), Category("VarMinLimit")]
        public string VarMinLimitAutoVelocity
        {
            get { return tbxAutoVelocity.VarMinLimit; }
            set { tbxAutoVelocity.VarMinLimit = value; }
        }
        /// <summary>
        /// Set plc var max limit - auto velocity.
        /// </summary>
        /// <value>Plc var max limit - auto velocity.</value>
        [Description("Sets plc var max limit - auto velocity."), Category("VarMaxLimit")]
        public string VarMaxLimitAutoVelocity
        {
            get { return tbxAutoVelocity.VarMaxLimit; }
            set { tbxAutoVelocity.VarMaxLimit = value; }
        }
        #endregion

        #region OriginShift

        /// <summary>
        /// Set plc variable name - origin position axis 1.
        /// </summary>
        /// <value>Plc variable name - origin position axis 1.</value>
        [Description("Sets plc variable name - origin position axis 1."), Category("OriginShift")]
        public string PlcVarNameOriginShiftPosAxis1
        {
            get { return tbxOriginShiftPosAxis1.PlcVarName; }
            set { tbxOriginShiftPosAxis1.PlcVarName = value; }
        }
        /// <summary>
        /// Set plc var type - origin position axis 1.
        /// </summary>
        /// <value>Plc var type - origin position axis 1.</value>
        [Description("Sets plc var type - origin position axis 1."), Category("VarType")]
        public int VarTypeOriginShiftPosAxis1
        {
            get { return tbxOriginShiftPosAxis1.VarType; }
            set { tbxOriginShiftPosAxis1.VarType = value; }
        }
        /// <summary>
        /// Set plc var min limit - origin position axis 1.
        /// </summary>
        /// <value>Plc var min limit - origin position axis 1.</value>
        [Description("Sets plc var min limit - origin position axis 1."), Category("VarMinLimit")]
        public string VarMinLimitOriginShiftPosAxis1
        {
            get { return tbxOriginShiftPosAxis1.VarMinLimit; }
            set { tbxOriginShiftPosAxis1.VarMinLimit = value; }
        }
        /// <summary>
        /// Set plc var max limit - origin position axis 1.
        /// </summary>
        /// <value>Plc var max limit - origin position axis 1.</value>
        [Description("Sets plc var max limit - origin position axis 1."), Category("VarMaxLimit")]
        public string VarMaxLimitOriginShiftPosAxis1
        {
            get { return tbxOriginShiftPosAxis1.VarMaxLimit; }
            set { tbxOriginShiftPosAxis1.VarMaxLimit = value; }
        }

        /// <summary>
        /// Set plc variable name - origin position axis 2.
        /// </summary>
        /// <value>Plc variable name - origin position axis 2.</value>
        [Description("Sets plc variable name - origin position axis 2."), Category("OriginShift")]
        public string PlcVarNameOriginShiftPosAxis2
        {
            get { return tbxOriginShiftPosAxis2.PlcVarName; }
            set { tbxOriginShiftPosAxis2.PlcVarName = value; }
        }
        /// <summary>
        /// Set plc var type - origin position axis 2.
        /// </summary>
        /// <value>Plc var type - origin position axis 2.</value>
        [Description("Sets plc var type - origin position axis 2."), Category("VarType")]
        public int VarTypeOriginShiftPosAxis2
        {
            get { return tbxOriginShiftPosAxis2.VarType; }
            set { tbxOriginShiftPosAxis2.VarType = value; }
        }
        /// <summary>
        /// Set plc var min limit - origin position axis 2.
        /// </summary>
        /// <value>Plc var min limit - origin position axis 2.</value>
        [Description("Sets plc var min limit - origin position axis 2."), Category("VarMinLimit")]
        public string VarMinLimitOriginShiftPosAxis2
        {
            get { return tbxOriginShiftPosAxis2.VarMinLimit; }
            set { tbxOriginShiftPosAxis2.VarMinLimit = value; }
        }
        /// <summary>
        /// Set plc var max limit - origin position axis 2.
        /// </summary>
        /// <value>Plc var max limit - origin position axis 2.</value>
        [Description("Sets plc var max limit - origin position axis 2."), Category("VarMaxLimit")]
        public string VarMaxLimitOriginShiftPosAxis2
        {
            get { return tbxOriginShiftPosAxis2.VarMaxLimit; }
            set { tbxOriginShiftPosAxis2.VarMaxLimit = value; }
        }

        /// <summary>
        /// Set plc variable name - origin position axis 3.
        /// </summary>
        /// <value>Plc variable name - origin position axis 3.</value>
        [Description("Sets plc variable name - origin position axis 3."), Category("OriginShift")]
        public string PlcVarNameOriginShiftPosAxis3
        {
            get { return tbxOriginShiftPosAxis3.PlcVarName; }
            set { tbxOriginShiftPosAxis3.PlcVarName = value; }
        }
        /// <summary>
        /// Set plc var type - origin position axis 3.
        /// </summary>
        /// <value>Plc var type - origin position axis 3.</value>
        [Description("Sets plc var type - origin position axis 3."), Category("VarType")]
        public int VarTypeOriginShiftPosAxis3
        {
            get { return tbxOriginShiftPosAxis3.VarType; }
            set { tbxOriginShiftPosAxis3.VarType = value; }
        }
        /// <summary>
        /// Set plc var min limit - origin position axis 3.
        /// </summary>
        /// <value>Plc var min limit - origin position axis 3.</value>
        [Description("Sets plc var min limit - origin position axis 3."), Category("VarMinLimit")]
        public string VarMinLimitOriginShiftPosAxis3
        {
            get { return tbxOriginShiftPosAxis3.VarMinLimit; }
            set { tbxOriginShiftPosAxis3.VarMinLimit = value; }
        }
        /// <summary>
        /// Set plc var max limit - origin position axis 3.
        /// </summary>
        /// <value>Plc var max limit - origin position axis 3.</value>
        [Description("Sets plc var max limit - origin position axis 3."), Category("VarMaxLimit")]
        public string VarMaxLimitOriginShiftPosAxis3
        {
            get { return tbxOriginShiftPosAxis3.VarMaxLimit; }
            set { tbxOriginShiftPosAxis3.VarMaxLimit = value; }
        }

        /// <summary>
        /// Set plc variable name - origin position axis 4.
        /// </summary>
        /// <value>Plc variable name - origin position axis 4.</value>
        [Description("Sets plc variable name - origin position axis 4."), Category("OriginShift")]
        public string PlcVarNameOriginShiftPosAxis4
        {
            get { return tbxOriginShiftPosAxis4.PlcVarName; }
            set { tbxOriginShiftPosAxis4.PlcVarName = value; }
        }
        /// <summary>
        /// Set plc var type - origin position axis 4.
        /// </summary>
        /// <value>Plc var type - origin position axis 4.</value>
        [Description("Sets plc var type - origin position axis 4."), Category("VarType")]
        public int VarTypeOriginShiftPosAxis4
        {
            get { return tbxOriginShiftPosAxis4.VarType; }
            set { tbxOriginShiftPosAxis4.VarType = value; }
        }
        /// <summary>
        /// Set plc var min limit - origin position axis 4.
        /// </summary>
        /// <value>Plc var min limit - origin position axis 4.</value>
        [Description("Sets plc var min limit - origin position axis 4."), Category("VarMinLimit")]
        public string VarMinLimitOriginShiftPosAxis4
        {
            get { return tbxOriginShiftPosAxis4.VarMinLimit; }
            set { tbxOriginShiftPosAxis4.VarMinLimit = value; }
        }
        /// <summary>
        /// Set plc var max limit - origin position axis 4.
        /// </summary>
        /// <value>Plc var max limit - origin position axis 4.</value>
        [Description("Sets plc var max limit - origin position axis 4."), Category("VarMaxLimit")]
        public string VarMaxLimitOriginShiftPosAxis4
        {
            get { return tbxOriginShiftPosAxis4.VarMaxLimit; }
            set { tbxOriginShiftPosAxis4.VarMaxLimit = value; }
        }

        /// <summary>
        /// Set plc variable name - origin position axis 5.
        /// </summary>
        /// <value>Plc variable name - origin position axis 5.</value>
        [Description("Sets plc variable name - origin position axis 5."), Category("OriginShift")]
        public string PlcVarNameOriginShiftPosAxis5
        {
            get { return tbxOriginShiftPosAxis5.PlcVarName; }
            set { tbxOriginShiftPosAxis5.PlcVarName = value; }
        }
        /// <summary>
        /// Set plc var type - origin position axis 5.
        /// </summary>
        /// <value>Plc var type - origin position axis 5.</value>
        [Description("Sets plc var type - origin position axis 5."), Category("VarType")]
        public int VarTypeOriginShiftPosAxis5
        {
            get { return tbxOriginShiftPosAxis5.VarType; }
            set { tbxOriginShiftPosAxis5.VarType = value; }
        }
        /// <summary>
        /// Set plc var min limit - origin position axis 5.
        /// </summary>
        /// <value>Plc var min limit - origin position axis 5.</value>
        [Description("Sets plc var min limit - origin position axis 5."), Category("VarMinLimit")]
        public string VarMinLimitOriginShiftPosAxis5
        {
            get { return tbxOriginShiftPosAxis5.VarMinLimit; }
            set { tbxOriginShiftPosAxis5.VarMinLimit = value; }
        }
        /// <summary>
        /// Set plc var max limit - origin position axis 5.
        /// </summary>
        /// <value>Plc var max limit - origin position axis 5.</value>
        [Description("Sets plc var max limit - origin position axis 5."), Category("VarMaxLimit")]
        public string VarMaxLimitOriginShiftPosAxis5
        {
            get { return tbxOriginShiftPosAxis5.VarMaxLimit; }
            set { tbxOriginShiftPosAxis5.VarMaxLimit = value; }
        }

        /// <summary>
        /// Set plc variable name - origin position axis 6.
        /// </summary>
        /// <value>Plc variable name - origin position axis 6.</value>
        [Description("Sets plc variable name - origin position axis 6."), Category("OriginShift")]
        public string PlcVarNameOriginShiftPosAxis6
        {
            get { return tbxOriginShiftPosAxis6.PlcVarName; }
            set { tbxOriginShiftPosAxis6.PlcVarName = value; }
        }
        /// <summary>
        /// Set plc var type - origin position axis 6.
        /// </summary>
        /// <value>Plc var type - origin position axis 6.</value>
        [Description("Sets plc var type - origin position axis 6."), Category("VarType")]
        public int VarTypeOriginShiftPosAxis6
        {
            get { return tbxOriginShiftPosAxis6.VarType; }
            set { tbxOriginShiftPosAxis6.VarType = value; }
        }
        /// <summary>
        /// Set plc var min limit - origin position axis 6.
        /// </summary>
        /// <value>Plc var min limit - origin position axis 6.</value>
        [Description("Sets plc var min limit - origin position axis 6."), Category("VarMinLimit")]
        public string VarMinLimitOriginShiftPosAxis6
        {
            get { return tbxOriginShiftPosAxis6.VarMinLimit; }
            set { tbxOriginShiftPosAxis6.VarMinLimit = value; }
        }
        /// <summary>
        /// Set plc var max limit - origin position axis 6.
        /// </summary>
        /// <value>Plc var max limit - origin position axis 6.</value>
        [Description("Sets plc var max limit - origin position axis 6."), Category("VarMaxLimit")]
        public string VarMaxLimitOriginShiftPosAxis6
        {
            get { return tbxOriginShiftPosAxis6.VarMaxLimit; }
            set { tbxOriginShiftPosAxis6.VarMaxLimit = value; }
        }

        #endregion

        #region HomePos

        /// <summary>
        /// Set plc variable name - init position axis 1.
        /// </summary>
        /// <value>Plc variable name - init position axis 1.</value>
        [Description("Sets plc variable name - home position axis 1."), Category("HomePos")]
        public string PlcVarNameHomePosAxis1
        {
            get { return tbxHomePosAxis1.PlcVarName; }
            set { tbxHomePosAxis1.PlcVarName = value; }
        }
        /// <summary>
        /// Set plc var type - init position axis 1.
        /// </summary>
        /// <value>Plc var type - init position axis 1.</value>
        [Description("Sets plc var type - init position axis 1."), Category("VarType")]
        public int VarTypeHomePosAxis1
        {
            get { return tbxHomePosAxis1.VarType; }
            set { tbxHomePosAxis1.VarType = value; }
        }
        /// <summary>
        /// Set plc var min limit - init position axis 1.
        /// </summary>
        /// <value>Plc var min limit - init position axis 1.</value>
        [Description("Sets plc var min limit - init position axis 1."), Category("VarMinLimit")]
        public string VarMinLimitHomePosAxis1
        {
            get { return tbxHomePosAxis1.VarMinLimit; }
            set { tbxHomePosAxis1.VarMinLimit = value; }
        }
        /// <summary>
        /// Set plc var max limit - init position axis 1.
        /// </summary>
        /// <value>Plc var max limit - init position axis 1.</value>
        [Description("Sets plc var max limit - init position axis 1."), Category("VarMaxLimit")]
        public string VarMaxLimitHomePosAxis1
        {
            get { return tbxHomePosAxis1.VarMaxLimit; }
            set { tbxHomePosAxis1.VarMaxLimit = value; }
        }

        /// <summary>
        /// Set plc variable name - init position axis 2.
        /// </summary>
        /// <value>Plc variable name - init position axis 2.</value>
        [Description("Sets plc variable name - home position axis 2."), Category("HomePos")]
        public string PlcVarNameHomePosAxis2
        {
            get { return tbxHomePosAxis2.PlcVarName; }
            set { tbxHomePosAxis2.PlcVarName = value; }
        }
        /// <summary>
        /// Set plc var type - init position axis 2.
        /// </summary>
        /// <value>Plc var type - init position axis 2.</value>
        [Description("Sets plc var type - init position axis 2."), Category("VarType")]
        public int VarTypeHomePosAxis2
        {
            get { return tbxHomePosAxis2.VarType; }
            set { tbxHomePosAxis2.VarType = value; }
        }
        /// <summary>
        /// Set plc var min limit - init position axis 2.
        /// </summary>
        /// <value>Plc var min limit - init position axis 2.</value>
        [Description("Sets plc var min limit - init position axis 2."), Category("VarMinLimit")]
        public string VarMinLimitHomePosAxis2
        {
            get { return tbxHomePosAxis2.VarMinLimit; }
            set { tbxHomePosAxis2.VarMinLimit = value; }
        }
        /// <summary>
        /// Set plc var max limit - init position axis 2.
        /// </summary>
        /// <value>Plc var max limit - init position axis 2.</value>
        [Description("Sets plc var max limit - init position axis 2."), Category("VarMaxLimit")]
        public string VarMaxLimitHomePosAxis2
        {
            get { return tbxHomePosAxis2.VarMaxLimit; }
            set { tbxHomePosAxis2.VarMaxLimit = value; }
        }

        /// <summary>
        /// Set plc variable name - init position axis 3.
        /// </summary>
        /// <value>Plc variable name - init position axis 3.</value>
        [Description("Sets plc variable name - home position axis 3."), Category("HomePos")]
        public string PlcVarNameHomePosAxis3
        {
            get { return tbxHomePosAxis3.PlcVarName; }
            set { tbxHomePosAxis3.PlcVarName = value; }
        }
        /// <summary>
        /// Set plc var type - init position axis 3.
        /// </summary>
        /// <value>Plc var type - init position axis 3.</value>
        [Description("Sets plc var type - init position axis 3."), Category("VarType")]
        public int VarTypeHomePosAxis3
        {
            get { return tbxHomePosAxis3.VarType; }
            set { tbxHomePosAxis3.VarType = value; }
        }
        /// <summary>
        /// Set plc var min limit - init position axis 3.
        /// </summary>
        /// <value>Plc var min limit - init position axis 3.</value>
        [Description("Sets plc var min limit - init position axis 3."), Category("VarMinLimit")]
        public string VarMinLimitHomePosAxis3
        {
            get { return tbxHomePosAxis3.VarMinLimit; }
            set { tbxHomePosAxis3.VarMinLimit = value; }
        }
        /// <summary>
        /// Set plc var max limit - init position axis 3.
        /// </summary>
        /// <value>Plc var max limit - init position axis 3.</value>
        [Description("Sets plc var max limit - init position axis 3."), Category("VarMaxLimit")]
        public string VarMaxLimitHomePosAxis3
        {
            get { return tbxHomePosAxis3.VarMaxLimit; }
            set { tbxHomePosAxis3.VarMaxLimit = value; }
        }

        /// <summary>
        /// Set plc variable name - init position axis 4.
        /// </summary>
        /// <value>Plc variable name - init position axis 4.</value>
        [Description("Sets plc variable name - home position axis 4."), Category("HomePos")]
        public string PlcVarNameHomePosAxis4
        {
            get { return tbxHomePosAxis4.PlcVarName; }
            set { tbxHomePosAxis4.PlcVarName = value; }
        }
        /// <summary>
        /// Set plc var type - init position axis 4.
        /// </summary>
        /// <value>Plc var type - init position axis 4.</value>
        [Description("Sets plc var type - init position axis 4."), Category("VarType")]
        public int VarTypeHomePosAxis4
        {
            get { return tbxHomePosAxis4.VarType; }
            set { tbxHomePosAxis4.VarType = value; }
        }
        /// <summary>
        /// Set plc var min limit - init position axis 4.
        /// </summary>
        /// <value>Plc var min limit - init position axis 4.</value>
        [Description("Sets plc var min limit - init position axis 4."), Category("VarMinLimit")]
        public string VarMinLimitHomePosAxis4
        {
            get { return tbxHomePosAxis4.VarMinLimit; }
            set { tbxHomePosAxis4.VarMinLimit = value; }
        }
        /// <summary>
        /// Set plc var max limit - init position axis 4.
        /// </summary>
        /// <value>Plc var max limit - init position axis 4.</value>
        [Description("Sets plc var max limit - init position axis 4."), Category("VarMaxLimit")]
        public string VarMaxLimitHomePosAxis4
        {
            get { return tbxHomePosAxis4.VarMaxLimit; }
            set { tbxHomePosAxis4.VarMaxLimit = value; }
        }

        /// <summary>
        /// Set plc variable name - init position axis 5.
        /// </summary>
        /// <value>Plc variable name - init position axis 5.</value>
        [Description("Sets plc variable name - home position axis 5."), Category("HomePos")]
        public string PlcVarNameHomePosAxis5
        {
            get { return tbxHomePosAxis5.PlcVarName; }
            set { tbxHomePosAxis5.PlcVarName = value; }
        }
        /// <summary>
        /// Set plc var type - init position axis 5.
        /// </summary>
        /// <value>Plc var type - init position axis 5.</value>
        [Description("Sets plc var type - init position axis 5."), Category("VarType")]
        public int VarTypeHomePosAxis5
        {
            get { return tbxHomePosAxis5.VarType; }
            set { tbxHomePosAxis5.VarType = value; }
        }
        /// <summary>
        /// Set plc var min limit - init position axis 5.
        /// </summary>
        /// <value>Plc var min limit - init position axis 5.</value>
        [Description("Sets plc var min limit - init position axis 5."), Category("VarMinLimit")]
        public string VarMinLimitHomePosAxis5
        {
            get { return tbxHomePosAxis5.VarMinLimit; }
            set { tbxHomePosAxis5.VarMinLimit = value; }
        }
        /// <summary>
        /// Set plc var max limit - init position axis 5.
        /// </summary>
        /// <value>Plc var max limit - init position axis 5.</value>
        [Description("Sets plc var max limit - init position axis 5."), Category("VarMaxLimit")]
        public string VarMaxLimitHomePosAxis5
        {
            get { return tbxHomePosAxis5.VarMaxLimit; }
            set { tbxHomePosAxis5.VarMaxLimit = value; }
        }

        /// <summary>
        /// Set plc variable name - init position axis 6.
        /// </summary>
        /// <value>Plc variable name - init position axis 6.</value>
        [Description("Sets plc variable name - home position axis 6."), Category("HomePos")]
        public string PlcVarNameHomePosAxis6
        {
            get { return tbxHomePosAxis6.PlcVarName; }
            set { tbxHomePosAxis6.PlcVarName = value; }
        }
        /// <summary>
        /// Set plc var type - init position axis 6.
        /// </summary>
        /// <value>Plc var type - init position axis 6.</value>
        [Description("Sets plc var type - init position axis 6."), Category("VarType")]
        public int VarTypeHomePosAxis6
        {
            get { return tbxHomePosAxis6.VarType; }
            set { tbxHomePosAxis6.VarType = value; }
        }
        /// <summary>
        /// Set plc var min limit - init position axis 6.
        /// </summary>
        /// <value>Plc var min limit - init position axis 6.</value>
        [Description("Sets plc var min limit - init position axis 6."), Category("VarMinLimit")]
        public string VarMinLimitHomePosAxis6
        {
            get { return tbxHomePosAxis6.VarMinLimit; }
            set { tbxHomePosAxis6.VarMinLimit = value; }
        }
        /// <summary>
        /// Set plc var max limit - init position axis 6.
        /// </summary>
        /// <value>Plc var max limit - init position axis 6.</value>
        [Description("Sets plc var max limit - init position axis 6."), Category("VarMaxLimit")]
        public string VarMaxLimitHomePosAxis6
        {
            get { return tbxHomePosAxis6.VarMaxLimit; }
            set { tbxHomePosAxis6.VarMaxLimit = value; }
        }

        #endregion

        #region SoftLimit

        /// <summary>
        /// Set plc variable name - software limit axis 1 minimum.
        /// </summary>
        /// <value>Plc variable name - software limit axis 1 minimum.</value>
        [Description("Sets plc variable name - software limit axis 1 minimum."), Category("SoftLimit")]
        public string PlcVarNameAxis1SoftLimitMin
        {
            get { return tbxSoftwareLimitsAxis1Min.PlcVarName; }
            set { tbxSoftwareLimitsAxis1Min.PlcVarName = value; }
        }
        /// Set plc variable name - software limit axis 1 minimum.
        /// </summary>
        /// <value>Plc variable name - software limit axis 1 minimum.</value>
        [Description("Sets plc variable name - software limit axis 1 minimum."), Category("VarType")]
        public int VarTypeAxis1SoftLimitMin
        {
            get { return tbxSoftwareLimitsAxis1Min.VarType; }
            set { tbxSoftwareLimitsAxis1Min.VarType = value; }
        }
        /// <summary>
        /// Set plc var min limit - software limit axis 1 minimum.
        /// </summary>
        /// <value>Plc var min limit - software limit axis 1 minimum.</value>
        [Description("Sets plc var min limit - software limit axis 1 minimum."), Category("VarMinLimit")]
        public string VarMinLimitAxis1SoftLimitMin
        {
            get { return tbxSoftwareLimitsAxis1Min.VarMinLimit; }
            set { tbxSoftwareLimitsAxis1Min.VarMinLimit = value; }
        }
        /// <summary>
        /// Set plc var max limit - software limit axis 1 minimum.
        /// </summary>
        /// <value>Plc var max limit - software limit axis 1 minimum.</value>
        [Description("Sets plc var max limit - software limit axis 1 minimum."), Category("VarMaxLimit")]
        public string VarMaxLimitAxis1SoftLimitMin
        {
            get { return tbxSoftwareLimitsAxis1Min.VarMaxLimit; }
            set { tbxSoftwareLimitsAxis1Min.VarMaxLimit = value; }
        }

        /// <summary>
        /// Set plc variable name - software limit axis 1 maximmum.
        /// </summary>
        /// <value>Plc variable name - software limit axis 1 maximum.</value>
        [Description("Sets plc variable name - software limit axis 1 maximum."), Category("SoftLimit")]
        public string PlcVarNameAxis1SoftLimitMax
        {
            get { return tbxSoftwareLimitsAxis1Max.PlcVarName; }
            set { tbxSoftwareLimitsAxis1Max.PlcVarName = value; }
        }
        /// Set plc variable name - software limit axis 1 maximum.
        /// </summary>
        /// <value>Plc variable name - software limit axis 1 maximum.</value>
        [Description("Sets plc variable name - software limit axis 1 maximum."), Category("VarType")]
        public int VarTypeAxis1SoftLimitMax
        {
            get { return tbxSoftwareLimitsAxis1Max.VarType; }
            set { tbxSoftwareLimitsAxis1Max.VarType = value; }
        }
        /// <summary>
        /// Set plc var min limit - software limit axis 1 maximum.
        /// </summary>
        /// <value>Plc var min limit - software limit axis 1 maximum.</value>
        [Description("Sets plc var min limit - software limit axis 1 maximum."), Category("VarMinLimit")]
        public string VarMinLimitAxis1SoftLimitMax
        {
            get { return tbxSoftwareLimitsAxis1Max.VarMinLimit; }
            set { tbxSoftwareLimitsAxis1Max.VarMinLimit = value; }
        }
        /// <summary>
        /// Set plc var max limit - software limit axis 1 maximum.
        /// </summary>
        /// <value>Plc var max limit - software limit axis 1 maximum.</value>
        [Description("Sets plc var max limit - software limit axis 1 maximum."), Category("VarMaxLimit")]
        public string VarMaxLimitAxis1SoftLimitMax
        {
            get { return tbxSoftwareLimitsAxis1Max.VarMaxLimit; }
            set { tbxSoftwareLimitsAxis1Max.VarMaxLimit = value; }
        }


        /// <summary>
        /// Set plc variable name - software limit axis 2 minimum.
        /// </summary>
        /// <value>Plc variable name - software limit axis 2 minimum.</value>
        [Description("Sets plc variable name - software limit axis 2 minimum."), Category("SoftLimit")]
        public string PlcVarNameAxis2SoftLimitMin
        {
            get { return tbxSoftwareLimitsAxis2Min.PlcVarName; }
            set { tbxSoftwareLimitsAxis2Min.PlcVarName = value; }
        }
        /// Set plc variable name - software limit axis 2 minimum.
        /// </summary>
        /// <value>Plc variable name - software limit axis 2 minimum.</value>
        [Description("Sets plc variable name - software limit axis 2 minimum."), Category("VarType")]
        public int VarTypeAxis2SoftLimitMin
        {
            get { return tbxSoftwareLimitsAxis2Min.VarType; }
            set { tbxSoftwareLimitsAxis2Min.VarType = value; }
        }
        /// <summary>
        /// Set plc var min limit - software limit axis 2 minimum.
        /// </summary>
        /// <value>Plc var min limit - software limit axis 2 minimum.</value>
        [Description("Sets plc var min limit - software limit axis 2 minimum."), Category("VarMinLimit")]
        public string VarMinLimitAxis2SoftLimitMin
        {
            get { return tbxSoftwareLimitsAxis2Min.VarMinLimit; }
            set { tbxSoftwareLimitsAxis2Min.VarMinLimit = value; }
        }
        /// <summary>
        /// Set plc var max limit - software limit axis 2 minimum.
        /// </summary>
        /// <value>Plc var max limit - software limit axis 2 minimum.</value>
        [Description("Sets plc var max limit - software limit axis 2 minimum."), Category("VarMaxLimit")]
        public string VarMaxLimitAxis2SoftLimitMin
        {
            get { return tbxSoftwareLimitsAxis2Min.VarMaxLimit; }
            set { tbxSoftwareLimitsAxis2Min.VarMaxLimit = value; }
        }

        /// <summary>
        /// Set plc variable name - software limit axis 2 maximmum.
        /// </summary>
        /// <value>Plc variable name - software limit axis 2 maximum.</value>
        [Description("Sets plc variable name - software limit axis 2 maximum."), Category("SoftLimit")]
        public string PlcVarNameAxis2SoftLimitMax
        {
            get { return tbxSoftwareLimitsAxis2Max.PlcVarName; }
            set { tbxSoftwareLimitsAxis2Max.PlcVarName = value; }
        }
        /// Set plc variable name - software limit axis 2 maximum.
        /// </summary>
        /// <value>Plc variable name - software limit axis 2 maximum.</value>
        [Description("Sets plc variable name - software limit axis 2 maximum."), Category("VarType")]
        public int VarTypeAxis2SoftLimitMax
        {
            get { return tbxSoftwareLimitsAxis2Max.VarType; }
            set { tbxSoftwareLimitsAxis2Max.VarType = value; }
        }
        /// <summary>
        /// Set plc var min limit - software limit axis 2 maximum.
        /// </summary>
        /// <value>Plc var min limit - software limit axis 2 maximum.</value>
        [Description("Sets plc var min limit - software limit axis 2 maximum."), Category("VarMinLimit")]
        public string VarMinLimitAxis2SoftLimitMax
        {
            get { return tbxSoftwareLimitsAxis2Max.VarMinLimit; }
            set { tbxSoftwareLimitsAxis2Max.VarMinLimit = value; }
        }
        /// <summary>
        /// Set plc var max limit - software limit axis 2 maximum.
        /// </summary>
        /// <value>Plc var max limit - software limit axis 2 maximum.</value>
        [Description("Sets plc var max limit - software limit axis 2 maximum."), Category("VarMaxLimit")]
        public string VarMaxLimitAxis2SoftLimitMax
        {
            get { return tbxSoftwareLimitsAxis2Max.VarMaxLimit; }
            set { tbxSoftwareLimitsAxis2Max.VarMaxLimit = value; }
        }


        /// <summary>
        /// Set plc variable name - software limit axis 3 minimum.
        /// </summary>
        /// <value>Plc variable name - software limit axis 3 minimum.</value>
        [Description("Sets plc variable name - software limit axis 3 minimum."), Category("SoftLimit")]
        public string PlcVarNameAxis3SoftLimitMin
        {
            get { return tbxSoftwareLimitsAxis3Min.PlcVarName; }
            set { tbxSoftwareLimitsAxis3Min.PlcVarName = value; }
        }
        /// Set plc variable name - software limit axis 3 minimum.
        /// </summary>
        /// <value>Plc variable name - software limit axis 3 minimum.</value>
        [Description("Sets plc variable name - software limit axis 3 minimum."), Category("VarType")]
        public int VarTypeAxis3SoftLimitMin
        {
            get { return tbxSoftwareLimitsAxis3Min.VarType; }
            set { tbxSoftwareLimitsAxis3Min.VarType = value; }
        }
        /// <summary>
        /// Set plc var min limit - software limit axis 3 minimum.
        /// </summary>
        /// <value>Plc var min limit - software limit axis 3 minimum.</value>
        [Description("Sets plc var min limit - software limit axis 3 minimum."), Category("VarMinLimit")]
        public string VarMinLimitAxis3SoftLimitMin
        {
            get { return tbxSoftwareLimitsAxis3Min.VarMinLimit; }
            set { tbxSoftwareLimitsAxis3Min.VarMinLimit = value; }
        }
        /// <summary>
        /// Set plc var max limit - software limit axis 3 minimum.
        /// </summary>
        /// <value>Plc var max limit - software limit axis 3 minimum.</value>
        [Description("Sets plc var max limit - software limit axis 3 minimum."), Category("VarMaxLimit")]
        public string VarMaxLimitAxis3SoftLimitMin
        {
            get { return tbxSoftwareLimitsAxis3Min.VarMaxLimit; }
            set { tbxSoftwareLimitsAxis3Min.VarMaxLimit = value; }
        }

        /// <summary>
        /// Set plc variable name - software limit axis 3 maximmum.
        /// </summary>
        /// <value>Plc variable name - software limit axis 3 maximum.</value>
        [Description("Sets plc variable name - software limit axis 3 maximum."), Category("SoftLimit")]
        public string PlcVarNameAxis3SoftLimitMax
        {
            get { return tbxSoftwareLimitsAxis3Max.PlcVarName; }
            set { tbxSoftwareLimitsAxis3Max.PlcVarName = value; }
        }
        /// Set plc variable name - software limit axis 3 maximum.
        /// </summary>
        /// <value>Plc variable name - software limit axis 3 maximum.</value>
        [Description("Sets plc variable name - software limit axis 3 maximum."), Category("VarType")]
        public int VarTypeAxis3SoftLimitMax
        {
            get { return tbxSoftwareLimitsAxis3Max.VarType; }
            set { tbxSoftwareLimitsAxis3Max.VarType = value; }
        }
        /// <summary>
        /// Set plc var min limit - software limit axis 3 maximum.
        /// </summary>
        /// <value>Plc var min limit - software limit axis 3 maximum.</value>
        [Description("Sets plc var min limit - software limit axis 3 maximum."), Category("VarMinLimit")]
        public string VarMinLimitAxis3SoftLimitMax
        {
            get { return tbxSoftwareLimitsAxis3Max.VarMinLimit; }
            set { tbxSoftwareLimitsAxis3Max.VarMinLimit = value; }
        }
        /// <summary>
        /// Set plc var max limit - software limit axis 3 maximum.
        /// </summary>
        /// <value>Plc var max limit - software limit axis 3 maximum.</value>
        [Description("Sets plc var max limit - software limit axis 3 maximum."), Category("VarMaxLimit")]
        public string VarMaxLimitAxis3SoftLimitMax
        {
            get { return tbxSoftwareLimitsAxis3Max.VarMaxLimit; }
            set { tbxSoftwareLimitsAxis3Max.VarMaxLimit = value; }
        }


        /// <summary>
        /// Set plc variable name - software limit axis 4 minimum.
        /// </summary>
        /// <value>Plc variable name - software limit axis 4 minimum.</value>
        [Description("Sets plc variable name - software limit axis 4 minimum."), Category("SoftLimit")]
        public string PlcVarNameAxis4SoftLimitMin
        {
            get { return tbxSoftwareLimitsAxis4Min.PlcVarName; }
            set { tbxSoftwareLimitsAxis4Min.PlcVarName = value; }
        }
        /// Set plc variable name - software limit axis 4 minimum.
        /// </summary>
        /// <value>Plc variable name - software limit axis 4 minimum.</value>
        [Description("Sets plc variable name - software limit axis 4 minimum."), Category("VarType")]
        public int VarTypeAxis4SoftLimitMin
        {
            get { return tbxSoftwareLimitsAxis4Min.VarType; }
            set { tbxSoftwareLimitsAxis4Min.VarType = value; }
        }
        /// <summary>
        /// Set plc var min limit - software limit axis 4 minimum.
        /// </summary>
        /// <value>Plc var min limit - software limit axis 4 minimum.</value>
        [Description("Sets plc var min limit - software limit axis 4 minimum."), Category("VarMinLimit")]
        public string VarMinLimitAxis4SoftLimitMin
        {
            get { return tbxSoftwareLimitsAxis4Min.VarMinLimit; }
            set { tbxSoftwareLimitsAxis4Min.VarMinLimit = value; }
        }
        /// <summary>
        /// Set plc var max limit - software limit axis 4 minimum.
        /// </summary>
        /// <value>Plc var max limit - software limit axis 4 minimum.</value>
        [Description("Sets plc var max limit - software limit axis 4 minimum."), Category("VarMaxLimit")]
        public string VarMaxLimitAxis4SoftLimitMin
        {
            get { return tbxSoftwareLimitsAxis4Min.VarMaxLimit; }
            set { tbxSoftwareLimitsAxis4Min.VarMaxLimit = value; }
        }

        /// <summary>
        /// Set plc variable name - software limit axis 4 maximmum.
        /// </summary>
        /// <value>Plc variable name - software limit axis 4 maximum.</value>
        [Description("Sets plc variable name - software limit axis 4 maximum."), Category("SoftLimit")]
        public string PlcVarNameAxis4SoftLimitMax
        {
            get { return tbxSoftwareLimitsAxis4Max.PlcVarName; }
            set { tbxSoftwareLimitsAxis4Max.PlcVarName = value; }
        }
        /// Set plc variable name - software limit axis 4 maximum.
        /// </summary>
        /// <value>Plc variable name - software limit axis 4 maximum.</value>
        [Description("Sets plc variable name - software limit axis 4 maximum."), Category("VarType")]
        public int VarTypeAxis4SoftLimitMax
        {
            get { return tbxSoftwareLimitsAxis4Max.VarType; }
            set { tbxSoftwareLimitsAxis4Max.VarType = value; }
        }
        /// <summary>
        /// Set plc var min limit - software limit axis 4 maximum.
        /// </summary>
        /// <value>Plc var min limit - software limit axis 4 maximum.</value>
        [Description("Sets plc var min limit - software limit axis 4 maximum."), Category("VarMinLimit")]
        public string VarMinLimitAxis4SoftLimitMax
        {
            get { return tbxSoftwareLimitsAxis4Max.VarMinLimit; }
            set { tbxSoftwareLimitsAxis4Max.VarMinLimit = value; }
        }
        /// <summary>
        /// Set plc var max limit - software limit axis 4 maximum.
        /// </summary>
        /// <value>Plc var max limit - software limit axis 4 maximum.</value>
        [Description("Sets plc var max limit - software limit axis 4 maximum."), Category("VarMaxLimit")]
        public string VarMaxLimitAxis4SoftLimitMax
        {
            get { return tbxSoftwareLimitsAxis4Max.VarMaxLimit; }
            set { tbxSoftwareLimitsAxis4Max.VarMaxLimit = value; }
        }


        /// <summary>
        /// Set plc variable name - software limit axis 5 minimum.
        /// </summary>
        /// <value>Plc variable name - software limit axis 5 minimum.</value>
        [Description("Sets plc variable name - software limit axis 5 minimum."), Category("SoftLimit")]
        public string PlcVarNameAxis5SoftLimitMin
        {
            get { return tbxSoftwareLimitsAxis5Min.PlcVarName; }
            set { tbxSoftwareLimitsAxis5Min.PlcVarName = value; }
        }
        /// Set plc variable name - software limit axis 5 minimum.
        /// </summary>
        /// <value>Plc variable name - software limit axis 5 minimum.</value>
        [Description("Sets plc variable name - software limit axis 5 minimum."), Category("VarType")]
        public int VarTypeAxis5SoftLimitMin
        {
            get { return tbxSoftwareLimitsAxis5Min.VarType; }
            set { tbxSoftwareLimitsAxis5Min.VarType = value; }
        }
        /// <summary>
        /// Set plc var min limit - software limit axis 5 minimum.
        /// </summary>
        /// <value>Plc var min limit - software limit axis 5 minimum.</value>
        [Description("Sets plc var min limit - software limit axis 5 minimum."), Category("VarMinLimit")]
        public string VarMinLimitAxis5SoftLimitMin
        {
            get { return tbxSoftwareLimitsAxis5Min.VarMinLimit; }
            set { tbxSoftwareLimitsAxis5Min.VarMinLimit = value; }
        }
        /// <summary>
        /// Set plc var max limit - software limit axis 5 minimum.
        /// </summary>
        /// <value>Plc var max limit - software limit axis 5 minimum.</value>
        [Description("Sets plc var max limit - software limit axis 5 minimum."), Category("VarMaxLimit")]
        public string VarMaxLimitAxis5SoftLimitMin
        {
            get { return tbxSoftwareLimitsAxis5Min.VarMaxLimit; }
            set { tbxSoftwareLimitsAxis5Min.VarMaxLimit = value; }
        }

        /// <summary>
        /// Set plc variable name - software limit axis 5 maximmum.
        /// </summary>
        /// <value>Plc variable name - software limit axis 5 maximum.</value>
        [Description("Sets plc variable name - software limit axis 5 maximum."), Category("SoftLimit")]
        public string PlcVarNameAxis5SoftLimitMax
        {
            get { return tbxSoftwareLimitsAxis5Max.PlcVarName; }
            set { tbxSoftwareLimitsAxis5Max.PlcVarName = value; }
        }
        /// Set plc variable name - software limit axis 5 maximum.
        /// </summary>
        /// <value>Plc variable name - software limit axis 5 maximum.</value>
        [Description("Sets plc variable name - software limit axis 5 maximum."), Category("VarType")]
        public int VarTypeAxis5SoftLimitMax
        {
            get { return tbxSoftwareLimitsAxis5Max.VarType; }
            set { tbxSoftwareLimitsAxis5Max.VarType = value; }
        }
        /// <summary>
        /// Set plc var min limit - software limit axis 5 maximum.
        /// </summary>
        /// <value>Plc var min limit - software limit axis 5 maximum.</value>
        [Description("Sets plc var min limit - software limit axis 5 maximum."), Category("VarMinLimit")]
        public string VarMinLimitAxis5SoftLimitMax
        {
            get { return tbxSoftwareLimitsAxis5Max.VarMinLimit; }
            set { tbxSoftwareLimitsAxis5Max.VarMinLimit = value; }
        }
        /// <summary>
        /// Set plc var max limit - software limit axis 5 maximum.
        /// </summary>
        /// <value>Plc var max limit - software limit axis 5 maximum.</value>
        [Description("Sets plc var max limit - software limit axis 5 maximum."), Category("VarMaxLimit")]
        public string VarMaxLimitAxis5SoftLimitMax
        {
            get { return tbxSoftwareLimitsAxis1Max.VarMaxLimit; }
            set { tbxSoftwareLimitsAxis5Max.VarMaxLimit = value; }
        }


        /// <summary>
        /// Set plc variable name - software limit axis 6 minimum.
        /// </summary>
        /// <value>Plc variable name - software limit axis 6 minimum.</value>
        [Description("Sets plc variable name - software limit axis 6 minimum."), Category("SoftLimit")]
        public string PlcVarNameAxis6SoftLimitMin
        {
            get { return tbxSoftwareLimitsAxis6Min.PlcVarName; }
            set { tbxSoftwareLimitsAxis6Min.PlcVarName = value; }
        }
        /// Set plc variable name - software limit axis 6 minimum.
        /// </summary>
        /// <value>Plc variable name - software limit axis 6 minimum.</value>
        [Description("Sets plc variable name - software limit axis 6 minimum."), Category("VarType")]
        public int VarTypeAxis6SoftLimitMin
        {
            get { return tbxSoftwareLimitsAxis6Min.VarType; }
            set { tbxSoftwareLimitsAxis6Min.VarType = value; }
        }
        /// <summary>
        /// Set plc var min limit - software limit axis 6 minimum.
        /// </summary>
        /// <value>Plc var min limit - software limit axis 6 minimum.</value>
        [Description("Sets plc var min limit - software limit axis 6 minimum."), Category("VarMinLimit")]
        public string VarMinLimitAxis6SoftLimitMin
        {
            get { return tbxSoftwareLimitsAxis6Min.VarMinLimit; }
            set { tbxSoftwareLimitsAxis6Min.VarMinLimit = value; }
        }
        /// <summary>
        /// Set plc var max limit - software limit axis 6 minimum.
        /// </summary>
        /// <value>Plc var max limit - software limit axis 6 minimum.</value>
        [Description("Sets plc var max limit - software limit axis 6 minimum."), Category("VarMaxLimit")]
        public string VarMaxLimitAxis6SoftLimitMin
        {
            get { return tbxSoftwareLimitsAxis6Min.VarMaxLimit; }
            set { tbxSoftwareLimitsAxis6Min.VarMaxLimit = value; }
        }

        /// <summary>
        /// Set plc variable name - software limit axis 6 maximmum.
        /// </summary>
        /// <value>Plc variable name - software limit axis 6 maximum.</value>
        [Description("Sets plc variable name - software limit axis 6 maximum."), Category("SoftLimit")]
        public string PlcVarNameAxis6SoftLimitMax
        {
            get { return tbxSoftwareLimitsAxis6Max.PlcVarName; }
            set { tbxSoftwareLimitsAxis6Max.PlcVarName = value; }
        }
        /// Set plc variable name - software limit axis 6 maximum.
        /// </summary>
        /// <value>Plc variable name - software limit axis 6 maximum.</value>
        [Description("Sets plc variable name - software limit axis 6 maximum."), Category("VarType")]
        public int VarTypeAxis6SoftLimitMax
        {
            get { return tbxSoftwareLimitsAxis6Max.VarType; }
            set { tbxSoftwareLimitsAxis6Max.VarType = value; }
        }
        /// <summary>
        /// Set plc var min limit - software limit axis 6 maximum.
        /// </summary>
        /// <value>Plc var min limit - software limit axis 6 maximum.</value>
        [Description("Sets plc var min limit - software limit axis 6 maximum."), Category("VarMinLimit")]
        public string VarMinLimitAxis6SoftLimitMax
        {
            get { return tbxSoftwareLimitsAxis6Max.VarMinLimit; }
            set { tbxSoftwareLimitsAxis6Max.VarMinLimit = value; }
        }
        /// <summary>
        /// Set plc var max limit - software limit axis 6 maximum.
        /// </summary>
        /// <value>Plc var max limit - software limit axis 6 maximum.</value>
        [Description("Sets plc var max limit - software limit axis 6 maximum."), Category("VarMaxLimit")]
        public string VarMaxLimitAxis6SoftLimitMax
        {
            get { return tbxSoftwareLimitsAxis6Max.VarMaxLimit; }
            set { tbxSoftwareLimitsAxis6Max.VarMaxLimit = value; }
        }

        #endregion

        #region Visible

        /// <summary>
        /// Set visible - manual velocity.
        /// </summary>
        /// <value>Set visible - manual velocity.</value>
        [Description("Set visible - manual velocity."), Category("Visible")]
        public bool VisibleManualVelocity
        {
            get { return tbxManualVelocity.Visible; }
            set { 
                    tbxManualVelocity.Visible = value;
                    lblManualVelocity.Visible = value;
                    label9.Visible = value;
                }
        }
        /// <summary>
        /// Set visible - home velocity.
        /// </summary>
        /// <value>Set visible - home velocity.</value>
        [Description("Set visible - home velocity."), Category("Visible")]
        public bool VisibleHomeVelocity
        {
            get { return tbxHomeVelocity.Visible; }
            set { 
                    tbxHomeVelocity.Visible = value;
                    lblHomeVelocity.Visible = value;
                    label8.Visible = value; 
                }
        }
        /// <summary>
        /// Set visible - auto velocity.
        /// </summary>
        /// <value>Set visible - auto velocity.</value>
        [Description("Set visible - auto velocity."), Category("Visible")]
        public bool VisibleAutoVelocity
        {
            get { return tbxAutoVelocity.Visible; }
            set { 
                    tbxAutoVelocity.Visible = value;
                    lblAutoVelocity.Visible = value;
                    label7.Visible = value; 
                }
        }

        /// <summary>
        /// Set visible - origin position axis 1.
        /// </summary>
        /// <value>Set visible - origin position axis 1.</value>
        [Description("Set visible - origin position axis 1."), Category("Visible")]
        public bool VisibleOriginShiftPosAxis1
        {
            get { return tbxOriginShiftPosAxis1.Visible; }
            set { 
                    tbxOriginShiftPosAxis1.Visible = value;
                    lblOriginShiftPosAxis1.Visible = value;
                    label1.Visible = value; 
                }
        }
        /// <summary>
        /// Set visible - origin position axis 2.
        /// </summary>
        /// <value>Set visible - origin position axis 2.</value>
        [Description("Set visible - origin position axis 2."), Category("Visible")]
        public bool VisibleOriginShiftPosAxis2
        {
            get { return tbxOriginShiftPosAxis2.Visible; }
            set { 
                    tbxOriginShiftPosAxis2.Visible = value;
                    lblOriginShiftPosAxis2.Visible = value;
                    label2.Visible = value; 
                }
        }
        /// <summary>
        /// Set visible - origin position axis 3.
        /// </summary>
        /// <value>Set visible - origin position axis 3.</value>
        [Description("Set visible - origin position axis 3."), Category("Visible")]
        public bool VisibleOriginShiftPosAxis3
        {
            get { return tbxOriginShiftPosAxis3.Visible; }
            set { 
                    tbxOriginShiftPosAxis3.Visible = value;
                    lblOriginShiftPosAxis3.Visible = value;
                    label3.Visible = value; 
                }
        }
        /// <summary>
        /// Set visible - origin position axis 4.
        /// </summary>
        /// <value>Set visible - origin position axis 4.</value>
        [Description("Set visible - origin position axis 4."), Category("Visible")]
        public bool VisibleOriginShiftPosAxis4
        {
            get { return tbxOriginShiftPosAxis4.Visible; }
            set { 
                    tbxOriginShiftPosAxis4.Visible = value;
                    lblOriginShiftPosAxis4.Visible = value;
                    label12.Visible = value; 
                }
        }
        /// <summary>
        /// Set visible - origin position axis 5.
        /// </summary>
        /// <value>Set visible - origin position axis 5.</value>
        [Description("Set visible - origin position axis 5."), Category("Visible")]
        public bool VisibleOriginShiftPosAxis5
        {
            get { return tbxOriginShiftPosAxis5.Visible; }
            set { 
                    tbxOriginShiftPosAxis5.Visible = value;
                    lblOriginShiftPosAxis5.Visible = value;
                    label11.Visible = value; 
                }
        }
        /// <summary>
        /// Set visible - origin position axis 6.
        /// </summary>
        /// <value>Set visible - origin position axis 6.</value>
        [Description("Set visible - origin position axis 6."), Category("Visible")]
        public bool VisibleOriginShiftPosAxis6
        {
            get { return tbxOriginShiftPosAxis6.Visible; }
            set { 
                    tbxOriginShiftPosAxis6.Visible = value;
                    lblOriginShiftPosAxis6.Visible = value;
                    label10.Visible = value; 
                }
        }

        /// <summary>
        /// Set visible - init position axis 1.
        /// </summary>
        /// <value>Set visible - init position axis 1.</value>
        [Description("Set visible - home position axis 1."), Category("Visible")]
        public bool VisibleHomePosAxis1
        {
            get { return tbxHomePosAxis1.Visible; }
            set { 
                    tbxHomePosAxis1.Visible = value;
                    lblHomePosAxis1.Visible = value;
                    label6.Visible = value; 
                }
        }
        /// <summary>
        /// Set visible - init position axis 2.
        /// </summary>
        /// <value>Set visible - init position axis 2.</value>
        [Description("Set visible - home position axis 2."), Category("Visible")]
        public bool VisibleHomePosAxis2
        {
            get { return tbxHomePosAxis2.Visible; }
            set { 
                    tbxHomePosAxis2.Visible = value;
                    lblHomePosAxis2.Visible = value;
                    label5.Visible = value; 
                }
        }
        /// <summary>
        /// Set visible - init position axis 3.
        /// </summary>
        /// <value>Set visible - init position axis 3.</value>
        [Description("Set visible - home position axis 3."), Category("Visible")]
        public bool VisibleHomePosAxis3
        {
            get { return tbxHomePosAxis3.Visible; }
            set { 
                    tbxHomePosAxis3.Visible = value;
                    lblHomePosAxis3.Visible = value;
                    label4.Visible = value; 
                }
        }
        /// <summary>
        /// Set visible - init position axis 4.
        /// </summary>
        /// <value>Set visible - init position axis 4.</value>
        [Description("Set visible - home position axis 4."), Category("Visible")]
        public bool VisibleHomePosAxis4
        {
            get { return tbxHomePosAxis4.Visible; }
            set { 
                    tbxHomePosAxis4.Visible = value;
                    lblHomePosAxis4.Visible = value;
                    label15.Visible = value; 
                }
        }
        /// <summary>
        /// Set visible - init position axis 5.
        /// </summary>
        /// <value>Set visible - init position axis 5.</value>
        [Description("Set visible - home position axis 5."), Category("Visible")]
        public bool VisibleHomePosAxis5
        {
            get { return tbxHomePosAxis5.Visible; }
            set { 
                    tbxHomePosAxis5.Visible = value;
                    lblHomePosAxis5.Visible = value;
                    label14.Visible = value; 
                }
        }
        /// <summary>
        /// Set visible - init position axis 6.
        /// </summary>
        /// <value>Set visible - init position axis 6.</value>
        [Description("Set visible - home position axis 6."), Category("Visible")]
        public bool VisibleHomePosAxis6
        {
            get { return tbxHomePosAxis6.Visible; }
            set { 
                    tbxHomePosAxis6.Visible = value;
                    lblHomePosAxis6.Visible = value;
                    label13.Visible = value; 
                }
        }

        /// <summary>
        /// Set visible - software limit axis 1 
        /// </summary>
        /// <value>Set visible - software limit axis 1 .</value>
        [Description("Set visible - software limit axis 1."), Category("Visible")]
        public bool VisibleAxis1SoftLimits
        {
            get { return tbxSoftwareLimitsAxis1Min.Visible; }
            set { 
                    tbxSoftwareLimitsAxis1Min.Visible = value;
                    lblSoftwareLimitsAxis1.Visible = value;
                    tbxSoftwareLimitsAxis1Max.Visible = value;
                    label30.Visible = value;
                }
        }

        /// <summary>
        /// Set visible - software limit axis 2.
        /// </summary>
        /// <value>Set visible - software limit axis 2.</value>
        [Description("Set visible - software limit axis 2 minimum."), Category("Visible")]
        public bool VisibleAxis2SoftLimits
        {
            get { return tbxSoftwareLimitsAxis2Min.Visible; }
            set { 
                    tbxSoftwareLimitsAxis2Min.Visible = value;
                    lblSoftwareLimitsAxis2.Visible = value;
                    tbxSoftwareLimitsAxis2Max.Visible = value;
                    label29.Visible = value;
                }
        }

        /// <summary>
        /// Set visible - software limit axis 3.
        /// </summary>
        /// <value>Set visible - software limit axis 3.</value>
        [Description("Set visible - software limit axis 3."), Category("Visible")]
        public bool VisibleAxis3SoftLimits
        {
            get { return tbxSoftwareLimitsAxis3Min.Visible; }
            set { 
                    tbxSoftwareLimitsAxis3Min.Visible = value;
                    lblSoftwareLimitsAxis3.Visible = value;
                    tbxSoftwareLimitsAxis3Max.Visible = value;
                    label28.Visible = value;
                }
        }

        /// <summary>
        /// Set visible - software limit axis 4 minimum.
        /// </summary>
        /// <value>Set visible - software limit axis 4 minimum.</value>
        [Description("Set visible - software limit axis 4 minimum."), Category("Visible")]
        public bool VisibleAxis4SoftLimits
        {
            get { return tbxSoftwareLimitsAxis4Min.Visible; }
            set { 
                    tbxSoftwareLimitsAxis4Min.Visible = value;
                    lblSoftwareLimitsAxis4.Visible = value;
                    tbxSoftwareLimitsAxis4Max.Visible = value;
                    label21.Visible = value;
                }
        }
 
        /// <summary>
        /// Set visible - software limit axis 5.
        /// </summary>
        /// <value>Set visible - software limit axis 5.</value>
        [Description("Set visible - software limit axis 5."), Category("Visible")]
        public bool VisibleAxis5SoftLimits
        {
            get { return tbxSoftwareLimitsAxis5Min.Visible; }
            set { 
                    tbxSoftwareLimitsAxis5Min.Visible = value;
                    lblSoftwareLimitsAxis5.Visible = value;
                    tbxSoftwareLimitsAxis5Max.Visible = value;
                    label20.Visible = value;
                }
        }

        /// <summary>
        /// Set visible - software limit axis 6.
        /// </summary>
        /// <value>Set visible - software limit axis 6.</value>
        [Description("Set visible - software limit axis 6."), Category("Visible")]
        public bool VisibleAxis6SoftLimits
        {
            get { return tbxSoftwareLimitsAxis6Min.Visible; }
            set { 
                    tbxSoftwareLimitsAxis6Min.Visible = value;
                    lblSoftwareLimitsAxis6.Visible = value;
                    tbxSoftwareLimitsAxis6Max.Visible = value;
                    label19.Visible = value;
                }
        }

        #endregion

        #region Disable

        /// <summary>
        /// Set disable - manual velocity.
        /// </summary>
        /// <value>Set disable - manual velocity.</value>
        [Description("Set disable - manual velocity."), Category("Disable")]
        public bool DisableManualVelocity
        {
            get { return tbxManualVelocity.Disable; }
            set
            {
                tbxManualVelocity.Disable = value;
            }
        }
        /// <summary>
        /// Set disable - home velocity.
        /// </summary>
        /// <value>Set disable - home velocity.</value>
        [Description("Set disable - home velocity."), Category("Disable")]
        public bool DisableHomeVelocity
        {
            get { return tbxHomeVelocity.Disable; }
            set
            {
                tbxHomeVelocity.Disable = value;
            }
        }
        /// <summary>
        /// Set disable - auto velocity.
        /// </summary>
        /// <value>Set disable - auto velocity.</value>
        [Description("Set disable - auto velocity."), Category("Disable")]
        public bool DisableAutoVelocity
        {
            get { return tbxAutoVelocity.Disable; }
            set
            {
                tbxAutoVelocity.Disable = value;
            }
        }

        /// <summary>
        /// Set disable - origin position axis 1.
        /// </summary>
        /// <value>Set disable - origin position axis 1.</value>
        [Description("Set disable - origin position axis 1."), Category("Disable")]
        public bool DisableOriginShiftPosAxis1
        {
            get { return tbxOriginShiftPosAxis1.Disable; }
            set
            {
                tbxOriginShiftPosAxis1.Disable = value;
            }
        }
        /// <summary>
        /// Set disable - origin position axis 2.
        /// </summary>
        /// <value>Set disable - origin position axis 2.</value>
        [Description("Set disable - origin position axis 2."), Category("Disable")]
        public bool DisableOriginShiftPosAxis2
        {
            get { return tbxOriginShiftPosAxis2.Disable; }
            set
            {
                tbxOriginShiftPosAxis2.Disable = value;
            }
        }
        /// <summary>
        /// Set disable - origin position axis 3.
        /// </summary>
        /// <value>Set disable - origin position axis 3.</value>
        [Description("Set disable - origin position axis 3."), Category("Disable")]
        public bool DisableOriginShiftPosAxis3
        {
            get { return tbxOriginShiftPosAxis3.Disable; }
            set
            {
                tbxOriginShiftPosAxis3.Disable = value;
            }
        }
        /// <summary>
        /// Set disable - origin position axis 4.
        /// </summary>
        /// <value>Set disable - origin position axis 4.</value>
        [Description("Set disable - origin position axis 4."), Category("Disable")]
        public bool DisableOriginShiftPosAxis4
        {
            get { return tbxOriginShiftPosAxis4.Disable; }
            set
            {
                tbxOriginShiftPosAxis4.Disable = value;
            }
        }
        /// <summary>
        /// Set disable - origin position axis 5.
        /// </summary>
        /// <value>Set disable - origin position axis 5.</value>
        [Description("Set disable - origin position axis 5."), Category("Disable")]
        public bool DisableOriginShiftPosAxis5
        {
            get { return tbxOriginShiftPosAxis5.Disable; }
            set
            {
                tbxOriginShiftPosAxis5.Disable = value;
            }
        }
        /// <summary>
        /// Set disable - origin position axis 6.
        /// </summary>
        /// <value>Set disable - origin position axis 6.</value>
        [Description("Set disable - origin position axis 6."), Category("Disable")]
        public bool DisableOriginShiftPosAxis6
        {
            get { return tbxOriginShiftPosAxis6.Disable; }
            set
            {
                tbxOriginShiftPosAxis6.Disable = value;
            }
        }

        /// <summary>
        /// Set disable - init position axis 1.
        /// </summary>
        /// <value>Set disable - init position axis 1.</value>
        [Description("Set disable - home position axis 1."), Category("Disable")]
        public bool DisableHomePosAxis1
        {
            get { return tbxHomePosAxis1.Disable; }
            set
            {
                tbxHomePosAxis1.Disable = value;
            }
        }
        /// <summary>
        /// Set disable - init position axis 2.
        /// </summary>
        /// <value>Set disable - init position axis 2.</value>
        [Description("Set disable - home position axis 2."), Category("Disable")]
        public bool DisableHomePosAxis2
        {
            get { return tbxHomePosAxis2.Disable; }
            set
            {
                tbxHomePosAxis2.Disable = value;
            }
        }
        /// <summary>
        /// Set disable - init position axis 3.
        /// </summary>
        /// <value>Set disable - init position axis 3.</value>
        [Description("Set disable - home position axis 3."), Category("Disable")]
        public bool DisableHomePosAxis3
        {
            get { return tbxHomePosAxis3.Disable; }
            set
            {
                tbxHomePosAxis3.Disable = value;
            }
        }
        /// <summary>
        /// Set disable - init position axis 4.
        /// </summary>
        /// <value>Set disable - init position axis 4.</value>
        [Description("Set disable - home position axis 4."), Category("Disable")]
        public bool DisableHomePosAxis4
        {
            get { return tbxHomePosAxis4.Disable; }
            set
            {
                tbxHomePosAxis4.Disable = value;
            }
        }
        /// <summary>
        /// Set disable - init position axis 5.
        /// </summary>
        /// <value>Set disable - init position axis 5.</value>
        [Description("Set disable - home position axis 5."), Category("Disable")]
        public bool DisableHomePosAxis5
        {
            get { return tbxHomePosAxis5.Disable; }
            set
            {
                tbxHomePosAxis5.Disable = value;
            }
        }
        /// <summary>
        /// Set disable - init position axis 6.
        /// </summary>
        /// <value>Set disable - init position axis 6.</value>
        [Description("Set disable - home position axis 6."), Category("Disable")]
        public bool DisableHomePosAxis6
        {
            get { return tbxHomePosAxis6.Disable; }
            set
            {
                tbxHomePosAxis6.Disable = value;
            }
        }

        /// <summary>
        /// Set disable - software limit axis 1 minimum.
        /// </summary>
        /// <value>Set disable - software limit axis 1 minimum.</value>
        [Description("Set disable - software limit axis 1 minimum."), Category("Disable")]
        public bool DisableAxis1SoftLimitMin
        {
            get { return tbxSoftwareLimitsAxis1Min.Disable; }
            set
            {
                tbxSoftwareLimitsAxis1Min.Disable = value;
            }
        }
        /// Set disable - software limit axis 1 maximum.
        /// </summary>
        /// <value>Set disable - software limit axis 1 maximum.</value>
        [Description("Set disable - software limit axis 1 maximum."), Category("Disable")]
        public bool DisableAxis1SoftLimitMax
        {
            get { return tbxSoftwareLimitsAxis1Max.Disable; }
            set
            {
                tbxSoftwareLimitsAxis1Max.Disable = value;
            }
        }

        /// <summary>
        /// Set disable - software limit axis 2 minimum.
        /// </summary>
        /// <value>Set disable - software limit axis 2 minimum.</value>
        [Description("Set disable - software limit axis 2 minimum."), Category("Disable")]
        public bool DisableAxis2SoftLimitMin
        {
            get { return tbxSoftwareLimitsAxis2Min.Disable; }
            set
            {
                tbxSoftwareLimitsAxis2Min.Disable = value;
            }
        }
        /// Set disable - software limit axis 2 maximum.
        /// </summary>
        /// <value>Set disable - software limit axis 2 maximum.</value>
        [Description("Set disable - software limit axis 2 maximum."), Category("Disable")]
        public bool DisableAxis2SoftLimitMax
        {
            get { return tbxSoftwareLimitsAxis2Max.Disable; }
            set
            {
                tbxSoftwareLimitsAxis2Max.Disable = value;
            }
        }

        /// <summary>
        /// Set disable - software limit axis 3 minimum.
        /// </summary>
        /// <value>Set disable - software limit axis 3 minimum.</value>
        [Description("Set disable - software limit axis 3 minimum."), Category("Disable")]
        public bool DisableAxis3SoftLimitMin
        {
            get { return tbxSoftwareLimitsAxis3Min.Disable; }
            set
            {
                tbxSoftwareLimitsAxis3Min.Disable = value;
            }
        }
        /// Set disable - software limit axis 3 maximum.
        /// </summary>
        /// <value>Set disable - software limit axis 3 maximum.</value>
        [Description("Set disable - software limit axis 3 maximum."), Category("Disable")]
        public bool DisableAxis3SoftLimitMax
        {
            get { return tbxSoftwareLimitsAxis3Max.Disable; }
            set
            {
                tbxSoftwareLimitsAxis3Max.Disable = value;
            }
        }

        /// <summary>
        /// Set disable - software limit axis 4 minimum.
        /// </summary>
        /// <value>Set disable - software limit axis 4 minimum.</value>
        [Description("Set disable - software limit axis 4 minimum."), Category("Disable")]
        public bool DisableAxis4SoftLimitMin
        {
            get { return tbxSoftwareLimitsAxis4Min.Disable; }
            set
            {
                tbxSoftwareLimitsAxis4Min.Disable = value;
            }
        }
        /// Set disable - software limit axis 4 maximum.
        /// </summary>
        /// <value>Set disable - software limit axis 4 maximum.</value>
        [Description("Set disable - software limit axis 4 maximum."), Category("Disable")]
        public bool DisableAxis4SoftLimitMax
        {
            get { return tbxSoftwareLimitsAxis4Max.Disable; }
            set
            {
                tbxSoftwareLimitsAxis4Max.Disable = value;
            }
        }

        /// <summary>
        /// Set disable - software limit axis 5 minimum.
        /// </summary>
        /// <value>Set disable - software limit axis 5 minimum.</value>
        [Description("Set disable - software limit axis 5 minimum."), Category("Disable")]
        public bool DisableAxis5SoftLimitMin
        {
            get { return tbxSoftwareLimitsAxis5Min.Disable; }
            set
            {
                tbxSoftwareLimitsAxis5Min.Disable = value;
            }
        }
        /// Set disable - software limit axis 5 maximum.
        /// </summary>
        /// <value>Set disable - software limit axis 5 maximum.</value>
        [Description("Set disable - software limit axis 5 maximum."), Category("Disable")]
        public bool DisableAxis5SoftLimitMax
        {
            get { return tbxSoftwareLimitsAxis5Max.Disable; }
            set
            {
                tbxSoftwareLimitsAxis5Max.Disable = value;
            }
        }

        /// <summary>
        /// Set disable - software limit axis 6 minimum.
        /// </summary>
        /// <value>Set disable - software limit axis 6 minimum.</value>
        [Description("Set disable - software limit axis 6 minimum."), Category("Disable")]
        public bool DisableAxis6SoftLimitMin
        {
            get { return tbxSoftwareLimitsAxis6Min.Disable; }
            set
            {
                tbxSoftwareLimitsAxis6Min.Disable = value;
            }
        }
        /// Set disable - software limit axis 6 maximum.
        /// </summary>
        /// <value>Set disable - software limit axis 6 maximum.</value>
        [Description("Set disable - software limit axis 6 maximum."), Category("Disable")]
        public bool DisableAxis6SoftLimitMax
        {
            get { return tbxSoftwareLimitsAxis6Max.Disable; }
            set
            {
                tbxSoftwareLimitsAxis6Max.Disable = value;
            }
        }
        #endregion

        #region InchOn

        /// <summary>
        /// Set InchOn - origin position axis 1.
        /// </summary>
        /// <value>Set InchOn - origin position axis 1.</value>
        [Description("Set Inch - origin position axis 1."), Category("InchOn")]
        public bool InchOnOriginShiftPosAxis1
        {
            get { return tbxOriginShiftPosAxis1.InchOn; }
            set
            {
                tbxOriginShiftPosAxis1.InchOn = value;
            }
        }

        /// <summary>
        /// Set InchOn - origin position axis 2.
        /// </summary>
        /// <value>Set InchOn - origin position axis 2.</value>
        [Description("Set InchOn - origin position axis 2."), Category("InchOn")]
        public bool InchOnOriginShiftPosAxis2
        {
            get { return tbxOriginShiftPosAxis2.InchOn; }
            set
            {
                tbxOriginShiftPosAxis2.InchOn = value;
            }
        }

        /// <summary>
        /// Set InchOn - origin position axis 3.
        /// </summary>
        /// <value>Set InchOn - origin position axis 3.</value>
        [Description("Set InchOn - origin position axis 3."), Category("InchOn")]
        public bool InchOnOriginShiftPosAxis3
        {
            get { return tbxOriginShiftPosAxis3.InchOn; }
            set
            {
                tbxOriginShiftPosAxis3.InchOn = value;
            }
        }

        /// <summary>
        /// Set InchOn - origin position axis 4.
        /// </summary>
        /// <value>Set InchOn - origin position axis 4.</value>
        [Description("Set InchOn - origin position axis 4."), Category("InchOn")]
        public bool InchOnOriginShiftPosAxis4
        {
            get { return tbxOriginShiftPosAxis4.InchOn; }
            set
            {
                tbxOriginShiftPosAxis4.InchOn = value;
            }
        }

        /// <summary>
        /// Set InchOn - origin position axis 5.
        /// </summary>
        /// <value>Set InchOn - origin position axis 5.</value>
        [Description("Set InchOn - origin position axis 5."), Category("InchOn")]
        public bool InchOnOriginShiftPosAxis5
        {
            get { return tbxOriginShiftPosAxis5.InchOn; }
            set
            {
                tbxOriginShiftPosAxis5.InchOn = value;
            }
        }

        /// <summary>
        /// Set InchOn - origin position axis 6.
        /// </summary>
        /// <value>Set InchOn - origin position axis 6.</value>
        [Description("Set InchOn - origin position axis 6."), Category("InchOn")]
        public bool InchOnOriginShiftPosAxis6
        {
            get { return tbxOriginShiftPosAxis6.InchOn; }
            set
            {
                tbxOriginShiftPosAxis6.InchOn = value;
            }
        }

        /// <summary>
        /// Set InchOn - init position axis 1.
        /// </summary>
        /// <value>Set InchOn - init position axis 1.</value>
        [Description("Set Inch - init position axis 1."), Category("InchOn")]
        public bool InchOnHomePosAxis1
        {
            get { return tbxHomePosAxis1.InchOn; }
            set
            {
                tbxHomePosAxis1.InchOn = value;
            }
        }

        /// <summary>
        /// Set InchOn - init position axis 2.
        /// </summary>
        /// <value>Set InchOn - init position axis 2.</value>
        [Description("Set InchOn - init position axis 2."), Category("InchOn")]
        public bool InchOnHomePosAxis2
        {
            get { return tbxHomePosAxis2.InchOn; }
            set
            {
                tbxHomePosAxis2.InchOn = value;
            }
        }

        /// <summary>
        /// Set InchOn - init position axis 3.
        /// </summary>
        /// <value>Set InchOn - init position axis 3.</value>
        [Description("Set InchOn - init position axis 3."), Category("InchOn")]
        public bool InchOnHomePosAxis3
        {
            get { return tbxHomePosAxis3.InchOn; }
            set
            {
                tbxHomePosAxis3.InchOn = value;
            }
        }

        /// <summary>
        /// Set InchOn - init position axis 4.
        /// </summary>
        /// <value>Set InchOn - init position axis 4.</value>
        [Description("Set InchOn - init position axis 4."), Category("InchOn")]
        public bool InchOnHomePosAxis4
        {
            get { return tbxHomePosAxis4.InchOn; }
            set
            {
                tbxHomePosAxis4.InchOn = value;
            }
        }

        /// <summary>
        /// Set InchOn - init position axis 5.
        /// </summary>
        /// <value>Set InchOn - init position axis 5.</value>
        [Description("Set InchOn - init position axis 5."), Category("InchOn")]
        public bool InchOnHomePosAxis5
        {
            get { return tbxHomePosAxis5.InchOn; }
            set
            {
                tbxHomePosAxis5.InchOn = value;
            }
        }

        /// <summary>
        /// Set InchOn - init position axis 6.
        /// </summary>
        /// <value>Set InchOn - init position axis 6.</value>
        [Description("Set InchOn - init position axis 6."), Category("InchOn")]
        public bool InchOnHomePosAxis6
        {
            get { return tbxHomePosAxis6.InchOn; }
            set
            {
                tbxHomePosAxis6.InchOn = value;
            }
        }

        /// <summary>
        /// Set InchOn - software limit axis 1 minimum.
        /// </summary>
        /// <value>Set InchOn - software limit axis 1 minimum.</value>
        [Description("Set InchOn - software limit axis 1 minimum."), Category("InchOn")]
        public bool InchOnAxis1SoftLimitMin
        {
            get { return tbxSoftwareLimitsAxis1Min.InchOn; }
            set
            {
                tbxSoftwareLimitsAxis1Min.InchOn = value;
            }
        }
        /// Set InchOn - software limit axis 1 maximum.
        /// </summary>
        /// <value>Set InchOn - software limit axis 1 maximum.</value>
        [Description("Set InchOn - software limit axis 1 maximum."), Category("InchOn")]
        public bool InchOnAxis1SoftLimitMax
        {
            get { return tbxSoftwareLimitsAxis1Max.InchOn; }
            set
            {
                tbxSoftwareLimitsAxis1Max.InchOn = value;
            }
        }

        /// <summary>
        /// Set InchOn - software limit axis 2 minimum.
        /// </summary>
        /// <value>Set InchOn - software limit axis 2 minimum.</value>
        [Description("Set InchOn - software limit axis 2 minimum."), Category("InchOn")]
        public bool InchOnAxis2SoftLimitMin
        {
            get { return tbxSoftwareLimitsAxis2Min.InchOn; }
            set
            {
                tbxSoftwareLimitsAxis2Min.InchOn = value;
            }
        }
        /// Set InchOn - software limit axis 2 maximum.
        /// </summary>
        /// <value>Set InchOn - software limit axis 2 maximum.</value>
        [Description("Set InchOn - software limit axis 2 maximum."), Category("InchOn")]
        public bool InchOnAxis2SoftLimitMax
        {
            get { return tbxSoftwareLimitsAxis2Max.InchOn; }
            set
            {
                tbxSoftwareLimitsAxis2Max.InchOn = value;
            }
        }

        /// <summary>
        /// Set InchOn - software limit axis 3 minimum.
        /// </summary>
        /// <value>Set InchOn - software limit axis 3 minimum.</value>
        [Description("Set InchOn - software limit axis 3 minimum."), Category("InchOn")]
        public bool InchOnAxis3SoftLimitMin
        {
            get { return tbxSoftwareLimitsAxis3Min.InchOn; }
            set
            {
                tbxSoftwareLimitsAxis3Min.InchOn = value;
            }
        }
        /// Set InchOn - software limit axis 3 maximum.
        /// </summary>
        /// <value>Set InchOn - software limit axis 3 maximum.</value>
        [Description("Set InchOn - software limit axis 3 maximum."), Category("InchOn")]
        public bool InchOnAxis3SoftLimitMax
        {
            get { return tbxSoftwareLimitsAxis3Max.InchOn; }
            set
            {
                tbxSoftwareLimitsAxis3Max.InchOn = value;
            }
        }

        /// <summary>
        /// Set InchOn - software limit axis 4 minimum.
        /// </summary>
        /// <value>Set InchOn - software limit axis 4 minimum.</value>
        [Description("Set InchOn - software limit axis 4 minimum."), Category("InchOn")]
        public bool InchOnAxis4SoftLimitMin
        {
            get { return tbxSoftwareLimitsAxis4Min.InchOn; }
            set
            {
                tbxSoftwareLimitsAxis4Min.InchOn = value;
            }
        }
        /// Set InchOn - software limit axis 4 maximum.
        /// </summary>
        /// <value>Set InchOn - software limit axis 4 maximum.</value>
        [Description("Set InchOn - software limit axis 4 maximum."), Category("InchOn")]
        public bool InchOnAxis4SoftLimitMax
        {
            get { return tbxSoftwareLimitsAxis4Max.InchOn; }
            set
            {
                tbxSoftwareLimitsAxis4Max.InchOn = value;
            }
        }

        /// <summary>
        /// Set InchOn - software limit axis 5 minimum.
        /// </summary>
        /// <value>Set InchOn - software limit axis 5 minimum.</value>
        [Description("Set InchOn - software limit axis 5 minimum."), Category("InchOn")]
        public bool InchOnAxis5SoftLimitMin
        {
            get { return tbxSoftwareLimitsAxis5Min.InchOn; }
            set
            {
                tbxSoftwareLimitsAxis5Min.InchOn = value;
            }
        }
        /// Set InchOn - software limit axis 5 maximum.
        /// </summary>
        /// <value>Set InchOn - software limit axis 5 maximum.</value>
        [Description("Set InchOn - software limit axis 5 maximum."), Category("InchOn")]
        public bool InchOnAxis5SoftLimitMax
        {
            get { return tbxSoftwareLimitsAxis5Max.InchOn; }
            set
            {
                tbxSoftwareLimitsAxis5Max.InchOn = value;
            }
        }

        /// <summary>
        /// Set InchOn - software limit axis 6 minimum.
        /// </summary>
        /// <value>Set InchOn - software limit axis 6 minimum.</value>
        [Description("Set InchOn - software limit axis 6 minimum."), Category("InchOn")]
        public bool InchOnAxis6SoftLimitMin
        {
            get { return tbxSoftwareLimitsAxis6Min.InchOn; }
            set
            {
                tbxSoftwareLimitsAxis6Min.InchOn = value;
            }
        }
        /// Set InchOn - software limit axis 6 maximum.
        /// </summary>
        /// <value>Set InchOn - software limit axis 6 maximum.</value>
        [Description("Set InchOn - software limit axis 6 maximum."), Category("InchOn")]
        public bool InchOnAxis6SoftLimitMax
        {
            get { return tbxSoftwareLimitsAxis6Max.InchOn; }
            set
            {
                tbxSoftwareLimitsAxis6Max.InchOn = value;
            }
        }


        #endregion
                
        #endregion

        #region User interface

        #endregion

        #region Events

        #region Form Events

        private void UCMachineParameters_Load(object sender, EventArgs e)
        {
            if (this.lm == null)
                return;
            this.lm.StringDel += new CLanguageManager.InitStringDelegate(this.LoadLanguageStrings);
            this.LoadLanguageStrings();
        }

        #endregion

        #region Object Events

        #endregion

        #region User Events

        #endregion

        #endregion

        #region Interface implementation

        #endregion

        #region Public functions

        /// <summary>
        /// Gets the user manager.
        /// </summary>
        /// <value>The user manager.</value>
        [DefaultValue(1)]
        [Description("Sets the user manager."), Category("App")]
        public void SerUserManager(CUserManager um)
        {
            this.um = um;

            this.tbxOriginShiftPosAxis1.UserManager = um;
            this.tbxOriginShiftPosAxis2.UserManager = um;
            this.tbxOriginShiftPosAxis3.UserManager = um;
            this.tbxOriginShiftPosAxis4.UserManager = um;
            this.tbxOriginShiftPosAxis5.UserManager = um;
            this.tbxOriginShiftPosAxis6.UserManager = um;

            this.tbxHomePosAxis1.UserManager = um;
            this.tbxHomePosAxis2.UserManager = um;
            this.tbxHomePosAxis3.UserManager = um;
            this.tbxHomePosAxis4.UserManager = um;
            this.tbxHomePosAxis5.UserManager = um;
            this.tbxHomePosAxis6.UserManager = um;

            this.tbxSoftwareLimitsAxis1Min.UserManager = um;
            this.tbxSoftwareLimitsAxis2Min.UserManager = um;
            this.tbxSoftwareLimitsAxis3Min.UserManager = um;
            this.tbxSoftwareLimitsAxis4Min.UserManager = um;
            this.tbxSoftwareLimitsAxis5Min.UserManager = um;
            this.tbxSoftwareLimitsAxis6Min.UserManager = um;

            this.tbxSoftwareLimitsAxis1Max.UserManager = um;
            this.tbxSoftwareLimitsAxis2Max.UserManager = um;
            this.tbxSoftwareLimitsAxis3Max.UserManager = um;
            this.tbxSoftwareLimitsAxis4Max.UserManager = um;
            this.tbxSoftwareLimitsAxis5Max.UserManager = um;
            this.tbxSoftwareLimitsAxis6Max.UserManager = um;

            this.tbxManualVelocity.UserManager = um;
            this.tbxHomeVelocity.UserManager = um;
            this.tbxAutoVelocity.UserManager = um;

        }

        #endregion

        #region Private methods

        private void LoadLanguageStrings()
        {
            if (this.lm != null)
            {
                this.gbxMachineOrginShift.Text = lm["UCMachinePara1." + m_Name + ".gbxMachineOrginShift"];
                this.gbxMachineHomePos.Text = lm["UCMachinePara1." + m_Name + ".gbxMachineHomePos"];
                this.gbxMachineVelocity.Text = lm["UCMachinePara1." + m_Name + ".gbxMachineVelocity"];
                this.gbxMachineSoftwareLimits.Text = lm["UCMachinePara1." + m_Name + ".gbxMachineSL"];

                this.lblOriginShiftPosAxis1.Text = lm["UCMachinePara1." + m_Name + ".lblOriginShiftAxis1"];
                this.lblOriginShiftPosAxis2.Text = lm["UCMachinePara1." + m_Name + ".lblOriginShiftAxis2"];
                this.lblOriginShiftPosAxis3.Text = lm["UCMachinePara1." + m_Name + ".lblOriginShiftAxis3"];
                this.lblOriginShiftPosAxis4.Text = lm["UCMachinePara1." + m_Name + ".lblOriginShiftAxis4"];
                this.lblOriginShiftPosAxis5.Text = lm["UCMachinePara1." + m_Name + ".lblOriginShiftAxis5"];
                this.lblOriginShiftPosAxis6.Text = lm["UCMachinePara1." + m_Name + ".lblOriginShiftAxis6"];

                this.lblHomePosAxis1.Text = lm["UCMachinePara1." + m_Name + ".lblHomePosAxis1"];
                this.lblHomePosAxis2.Text = lm["UCMachinePara1." + m_Name + ".lblHomePosAxis2"];
                this.lblHomePosAxis3.Text = lm["UCMachinePara1." + m_Name + ".lblHomePosAxis3"];
                this.lblHomePosAxis4.Text = lm["UCMachinePara1." + m_Name + ".lblHomePosAxis4"];
                this.lblHomePosAxis5.Text = lm["UCMachinePara1." + m_Name + ".lblHomePosAxis5"];
                this.lblHomePosAxis6.Text = lm["UCMachinePara1." + m_Name + ".lblHomePosAxis6"];

                this.lblSoftwareLimitsAxis1.Text = lm["UCMachinePara1." + m_Name + ".lblSLAxis1Min"];
                this.lblSoftwareLimitsAxis2.Text = lm["UCMachinePara1." + m_Name + ".lblSLAxis2Min"];
                this.lblSoftwareLimitsAxis3.Text = lm["UCMachinePara1." + m_Name + ".lblSLAxis3Min"];
                this.lblSoftwareLimitsAxis4.Text = lm["UCMachinePara1." + m_Name + ".lblSLAxis4Min"];
                this.lblSoftwareLimitsAxis5.Text = lm["UCMachinePara1." + m_Name + ".lblSLAxis5Min"];
                this.lblSoftwareLimitsAxis6.Text = lm["UCMachinePara1." + m_Name + ".lblSLAxis6Min"];

                this.lblManualVelocity.Text = lm["UCMachinePara1." + m_Name + ".lblManualVelocity"];
                this.lblHomeVelocity.Text = lm["UCMachinePara1." + m_Name + ".lblHomeVelocity"];
                this.lblAutoVelocity.Text = lm["UCMachinePara1." + m_Name + ".lblAutoVelocity"];

            }
            else
            {
                this.gbxMachineOrginShift.Text = "Origin shift";
                this.gbxMachineHomePos.Text = "Home positions";
                this.gbxMachineVelocity.Text = "Velocity";

                this.lblOriginShiftPosAxis1.Text = "Axis 1:";
                this.lblOriginShiftPosAxis2.Text = "Axis 2:";
                this.lblOriginShiftPosAxis3.Text = "Axis 3:";
                this.lblOriginShiftPosAxis4.Text = "Axis 4:";
                this.lblOriginShiftPosAxis5.Text = "Axis 5:";
                this.lblOriginShiftPosAxis6.Text = "Axis 6:";

                this.lblHomePosAxis1.Text = "Axis 1:";
                this.lblHomePosAxis2.Text = "Axis 2:";
                this.lblHomePosAxis3.Text = "Axis 3:";
                this.lblHomePosAxis4.Text = "Axis 4:";
                this.lblHomePosAxis5.Text = "Axis 5:";
                this.lblHomePosAxis6.Text = "Axis 6:";

                this.lblSoftwareLimitsAxis1.Text = "Min 1:";
                this.lblSoftwareLimitsAxis2.Text = "Min 2:";
                this.lblSoftwareLimitsAxis3.Text = "Min 3:";
                this.lblSoftwareLimitsAxis4.Text = "Min 4:";
                this.lblSoftwareLimitsAxis5.Text = "Min 5:";
                this.lblSoftwareLimitsAxis6.Text = "Min 6:";

                this.lblManualVelocity.Text = "Manual";
                this.lblHomeVelocity.Text = "Home";
                this.lblAutoVelocity.Text = "Auto";
          
            }

        }

        #endregion
    }
}
