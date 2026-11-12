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
    using App.Components;
    using App.Security;

    public partial class UCProcessPara2 : UserControlBase
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
        public UCProcessPara2()
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

        #region PlcVarName

        /// <summary>
        /// Set plc variable name - para1.
        /// </summary>
        /// <value>Plc variable name - para1.</value>
        [Description("Sets plc variable name - para1."), Category("PlcVarName")]
        public string PlcVarNamePara1
        {
            get { return tbxPara1.PlcVarName; }
            set { tbxPara1.PlcVarName = value; }
        }

        /// <summary>
        /// Set plc variable name - para2.
        /// </summary>
        /// <value>Plc variable name - para2.</value>
        [Description("Sets plc variable name - para2."), Category("PlcVarName")]
        public string PlcVarNamePara2
        {
            get { return tbxPara2.PlcVarName; }
            set { tbxPara2.PlcVarName = value; }
        }

        /// <summary>
        /// Set plc variable name - para3.
        /// </summary>
        /// <value>Plc variable name - para3.</value>
        [Description("Sets plc variable name - para3."), Category("PlcVarName")]
        public string PlcVarNamePara3
        {
            get { return tbxPara3.PlcVarName; }
            set { tbxPara3.PlcVarName = value; }
        }

        /// <summary>
        /// Set plc variable name - para4.
        /// </summary>
        /// <value>Plc variable name - para4.</value>
        [Description("Sets plc variable name - para4."), Category("PlcVarName")]
        public string PlcVarNamePara4
        {
            get { return tbxPara4.PlcVarName; }
            set { tbxPara4.PlcVarName = value; }
        }

        /// <summary>
        /// Set plc variable name - para5.
        /// </summary>
        /// <value>Plc variable name - para5.</value>
        [Description("Sets plc variable name - para5."), Category("PlcVarName")]
        public string PlcVarNamePara5
        {
            get { return tbxPara5.PlcVarName; }
            set { tbxPara5.PlcVarName = value; }
        }

        /// <summary>
        /// Set plc variable name - para6.
        /// </summary>
        /// <value>Plc variable name - para6.</value>
        [Description("Sets plc variable name - para6."), Category("PlcVarName")]
        public string PlcVarNamePara6
        {
            get { return tbxPara6.PlcVarName; }
            set { tbxPara6.PlcVarName = value; }
        }

        /// <summary>
        /// Set plc variable name - para7.
        /// </summary>
        /// <value>Plc variable name - para7.</value>
        [Description("Sets plc variable name - para7."), Category("PlcVarName")]
        public string PlcVarNamePara7
        {
            get { return tbxPara7.PlcVarName; }
            set { tbxPara7.PlcVarName = value; }
        }

        /// <summary>
        /// Set plc variable name - para8.
        /// </summary>
        /// <value>Plc variable name - para8.</value>
        [Description("Sets plc variable name - para8."), Category("PlcVarName")]
        public string PlcVarNamePara8
        {
            get { return tbxPara8.PlcVarName; }
            set { tbxPara8.PlcVarName = value; }
        }

        /// <summary>
        /// Set plc variable name - para9.
        /// </summary>
        /// <value>Plc variable name - para9.</value>
        [Description("Sets plc variable name - para9."), Category("PlcVarName")]
        public string PlcVarNamePara9
        {
            get { return tbxPara9.PlcVarName; }
            set { tbxPara9.PlcVarName = value; }
        }

        /// <summary>
        /// Set plc variable name - para10.
        /// </summary>
        /// <value>Plc variable name - para10.</value>
        [Description("Sets plc variable name - para10."), Category("PlcVarName")]
        public string PlcVarNamePara10
        {
            get { return tbxPara10.PlcVarName; }
            set { tbxPara10.PlcVarName = value; }
        }

        /// <summary>
        /// Set plc variable name - para11.
        /// </summary>
        /// <value>Plc variable name - para11.</value>
        [Description("Sets plc variable name - para11."), Category("PlcVarName")]
        public string PlcVarNamePara11
        {
            get { return tbxPara11.PlcVarName; }
            set { tbxPara11.PlcVarName = value; }
        }

        /// <summary>
        /// Set plc variable name - para12.
        /// </summary>
        /// <value>Plc variable name - para12.</value>
        [Description("Sets plc variable name - para12."), Category("PlcVarName")]
        public string PlcVarNamePara12
        {
            get { return tbxPara12.PlcVarName; }
            set { tbxPara12.PlcVarName = value; }
        }

        /// <summary>
        /// Set plc variable name - para101.
        /// </summary>
        /// <value>Plc variable name - para101.</value>
        [Description("Sets plc variable name - para101."), Category("PlcVarName")]
        public string PlcVarNamePara101
        {
            get { return tbxPara101.PlcVarName; }
            set { tbxPara101.PlcVarName = value; }
        }

        /// <summary>
        /// Set plc variable name - para102.
        /// </summary>
        /// <value>Plc variable name - para102.</value>
        [Description("Sets plc variable name - para102."), Category("PlcVarName")]
        public string PlcVarNamePara102
        {
            get { return tbxPara102.PlcVarName; }
            set { tbxPara102.PlcVarName = value; }
        }

        /// <summary>
        /// Set plc variable name - para103.
        /// </summary>
        /// <value>Plc variable name - para103.</value>
        [Description("Sets plc variable name - para103."), Category("PlcVarName")]
        public string PlcVarNamePara103
        {
            get { return tbxPara103.PlcVarName; }
            set { tbxPara103.PlcVarName = value; }
        }

        /// <summary>
        /// Set plc variable name - para104.
        /// </summary>
        /// <value>Plc variable name - para104.</value>
        [Description("Sets plc variable name - para104."), Category("PlcVarName")]
        public string PlcVarNamePara104
        {
            get { return tbxPara104.PlcVarName; }
            set { tbxPara104.PlcVarName = value; }
        }

        /// <summary>
        /// Set plc variable name - para105.
        /// </summary>
        /// <value>Plc variable name - para105.</value>
        [Description("Sets plc variable name - para105."), Category("PlcVarName")]
        public string PlcVarNamePara105
        {
            get { return tbxPara105.PlcVarName; }
            set { tbxPara105.PlcVarName = value; }
        }

        /// <summary>
        /// Set plc variable name - para106.
        /// </summary>
        /// <value>Plc variable name - para106.</value>
        [Description("Sets plc variable name - para106."), Category("PlcVarName")]
        public string PlcVarNamePara106
        {
            get { return tbxPara106.PlcVarName; }
            set { tbxPara106.PlcVarName = value; }
        }

        /// <summary>
        /// Set plc variable name - para107.
        /// </summary>
        /// <value>Plc variable name - para107.</value>
        [Description("Sets plc variable name - para107."), Category("PlcVarName")]
        public string PlcVarNamePara107
        {
            get { return tbxPara107.PlcVarName; }
            set { tbxPara107.PlcVarName = value; }
        }

        /// <summary>
        /// Set plc variable name - para108.
        /// </summary>
        /// <value>Plc variable name - para108.</value>
        [Description("Sets plc variable name - para108."), Category("PlcVarName")]
        public string PlcVarNamePara108
        {
            get { return tbxPara108.PlcVarName; }
            set { tbxPara108.PlcVarName = value; }
        }

        /// <summary>
        /// Set plc variable name - para109.
        /// </summary>
        /// <value>Plc variable name - para109.</value>
        [Description("Sets plc variable name - para109."), Category("PlcVarName")]
        public string PlcVarNamePara109
        {
            get { return tbxPara109.PlcVarName; }
            set { tbxPara109.PlcVarName = value; }
        }

        /// <summary>
        /// Set plc variable name - para110.
        /// </summary>
        /// <value>Plc variable name - para110.</value>
        [Description("Sets plc variable name - para110."), Category("PlcVarName")]
        public string PlcVarNamePara110
        {
            get { return tbxPara110.PlcVarName; }
            set { tbxPara110.PlcVarName = value; }
        }

        /// <summary>
        /// Set plc variable name - para111.
        /// </summary>
        /// <value>Plc variable name - para111.</value>
        [Description("Sets plc variable name - para111."), Category("PlcVarName")]
        public string PlcVarNamePara111
        {
            get { return tbxPara111.PlcVarName; }
            set { tbxPara111.PlcVarName = value; }
        }

        /// <summary>
        /// Set plc variable name - para112.
        /// </summary>
        /// <value>Plc variable name - para112.</value>
        [Description("Sets plc variable name - para112."), Category("PlcVarName")]
        public string PlcVarNamePara112
        {
            get { return tbxPara112.PlcVarName; }
            set { tbxPara112.PlcVarName = value; }
        }

        #endregion

        #region VarType

        /// <summary>
        /// Set plc var type - para1.
        /// </summary>
        /// <value>Plc var type - para1.</value>
        [Description("Sets plc var type - para1."), Category("VarType")]
        public int VarTypePara1
        {
            get { return tbxPara1.VarType; }
            set { tbxPara1.VarType = value; }
        }

        /// <summary>
        /// Set plc var type - para2.
        /// </summary>
        /// <value>Plc var type - para2.</value>
        [Description("Sets plc var type - para2."), Category("VarType")]
        public int VarTypePara2
        {
            get { return tbxPara2.VarType; }
            set { tbxPara2.VarType = value; }
        }

        /// <summary>
        /// Set plc var type - para3.
        /// </summary>
        /// <value>Plc var type - para3.</value>
        [Description("Sets plc var type - para3."), Category("VarType")]
        public int VarTypePara3
        {
            get { return tbxPara3.VarType; }
            set { tbxPara3.VarType = value; }
        }

        /// <summary>
        /// Set plc var type - para4.
        /// </summary>
        /// <value>Plc var type - para4.</value>
        [Description("Sets plc var type - para4."), Category("VarType")]
        public int VarTypePara4
        {
            get { return tbxPara4.VarType; }
            set { tbxPara4.VarType = value; }
        }

        /// <summary>
        /// Set plc var type - para5.
        /// </summary>
        /// <value>Plc var type - para5.</value>
        [Description("Sets plc var type - para5."), Category("VarType")]
        public int VarTypePara5
        {
            get { return tbxPara5.VarType; }
            set { tbxPara5.VarType = value; }
        }

        /// <summary>
        /// Set plc var type - para6.
        /// </summary>
        /// <value>Plc var type - para6.</value>
        [Description("Sets plc var type - para6."), Category("VarType")]
        public int VarTypePara6
        {
            get { return tbxPara6.VarType; }
            set { tbxPara6.VarType = value; }
        }

        /// <summary>
        /// Set plc var type - para7.
        /// </summary>
        /// <value>Plc var type - para7.</value>
        [Description("Sets plc var type - para7."), Category("VarType")]
        public int VarTypePara7
        {
            get { return tbxPara7.VarType; }
            set { tbxPara7.VarType = value; }
        }

        /// <summary>
        /// Set plc var type - para8.
        /// </summary>
        /// <value>Plc var type - para8.</value>
        [Description("Sets plc var type - para8."), Category("VarType")]
        public int VarTypePara8
        {
            get { return tbxPara8.VarType; }
            set { tbxPara8.VarType = value; }
        }

        /// <summary>
        /// Set plc var type - para9.
        /// </summary>
        /// <value>Plc var type - para9.</value>
        [Description("Sets plc var type - para9."), Category("VarType")]
        public int VarTypePara9
        {
            get { return tbxPara9.VarType; }
            set { tbxPara9.VarType = value; }
        }

        /// <summary>
        /// Set plc var type - para10.
        /// </summary>
        /// <value>Plc var type - para10.</value>
        [Description("Sets plc var type - para10."), Category("VarType")]
        public int VarTypePara10
        {
            get { return tbxPara10.VarType; }
            set { tbxPara10.VarType = value; }
        }

        /// <summary>
        /// Set plc var type - para11.
        /// </summary>
        /// <value>Plc var type - para11.</value>
        [Description("Sets plc var type - para11."), Category("VarType")]
        public int VarTypePara11
        {
            get { return tbxPara11.VarType; }
            set { tbxPara11.VarType = value; }
        }

        /// <summary>
        /// Set plc var type - para12.
        /// </summary>
        /// <value>Plc var type - para12.</value>
        [Description("Sets plc var type - para12."), Category("VarType")]
        public int VarTypePara12
        {
            get { return tbxPara12.VarType; }
            set { tbxPara12.VarType = value; }
        }

        /// <summary>
        /// Set plc var type - para101.
        /// </summary>
        /// <value>Plc var type - para101.</value>
        [Description("Sets plc var type - para101."), Category("VarType")]
        public int VarTypePara101
        {
            get { return tbxPara101.VarType; }
            set { tbxPara101.VarType = value; }
        }

        /// <summary>
        /// Set plc var type - para102.
        /// </summary>
        /// <value>Plc var type - para102.</value>
        [Description("Sets plc var type - para102."), Category("VarType")]
        public int VarTypePara102
        {
            get { return tbxPara102.VarType; }
            set { tbxPara102.VarType = value; }
        }

        /// <summary>
        /// Set plc var type - para103.
        /// </summary>
        /// <value>Plc var type - para103.</value>
        [Description("Sets plc var type - para103."), Category("VarType")]
        public int VarTypePara103
        {
            get { return tbxPara103.VarType; }
            set { tbxPara103.VarType = value; }
        }

        /// <summary>
        /// Set plc var type - para104.
        /// </summary>
        /// <value>Plc var type - para104.</value>
        [Description("Sets plc var type - para104."), Category("VarType")]
        public int VarTypePara104
        {
            get { return tbxPara104.VarType; }
            set { tbxPara104.VarType = value; }
        }

        /// <summary>
        /// Set plc var type - para105.
        /// </summary>
        /// <value>Plc var type - para105.</value>
        [Description("Sets plc var type - para105."), Category("VarType")]
        public int VarTypePara105
        {
            get { return tbxPara105.VarType; }
            set { tbxPara105.VarType = value; }
        }

        /// <summary>
        /// Set plc var type - para106.
        /// </summary>
        /// <value>Plc var type - para106.</value>
        [Description("Sets plc var type - para106."), Category("VarType")]
        public int VarTypePara106
        {
            get { return tbxPara106.VarType; }
            set { tbxPara106.VarType = value; }
        }

        /// <summary>
        /// Set plc var type - para107.
        /// </summary>
        /// <value>Plc var type - para107.</value>
        [Description("Sets plc var type - para107."), Category("VarType")]
        public int VarTypePara107
        {
            get { return tbxPara107.VarType; }
            set { tbxPara107.VarType = value; }
        }

        /// <summary>
        /// Set plc var type - para108.
        /// </summary>
        /// <value>Plc var type - para108.</value>
        [Description("Sets plc var type - para108."), Category("VarType")]
        public int VarTypePara108
        {
            get { return tbxPara108.VarType; }
            set { tbxPara108.VarType = value; }
        }

        /// <summary>
        /// Set plc var type - para109.
        /// </summary>
        /// <value>Plc var type - para109.</value>
        [Description("Sets plc var type - para109."), Category("VarType")]
        public int VarTypePara109
        {
            get { return tbxPara109.VarType; }
            set { tbxPara109.VarType = value; }
        }

        /// <summary>
        /// Set plc var type - para110.
        /// </summary>
        /// <value>Plc var type - para110.</value>
        [Description("Sets plc var type - para110."), Category("VarType")]
        public int VarTypePara110
        {
            get { return tbxPara110.VarType; }
            set { tbxPara110.VarType = value; }
        }

        /// <summary>
        /// Set plc var type - para111.
        /// </summary>
        /// <value>Plc var type - para111.</value>
        [Description("Sets plc var type - para111."), Category("VarType")]
        public int VarTypePara111
        {
            get { return tbxPara111.VarType; }
            set { tbxPara111.VarType = value; }
        }

        /// <summary>
        /// Set plc var type - para112.
        /// </summary>
        /// <value>Plc var type - para112.</value>
        [Description("Sets plc var type - para112."), Category("VarType")]
        public int VarTypePara112
        {
            get { return tbxPara112.VarType; }
            set { tbxPara112.VarType = value; }
        }


        #endregion

        #region Limit Minimum

        /// <summary>
        /// Set plc variable name - para 1 limit minimum.
        /// </summary>
        /// <value>Plc variable name - para 1 limit minimum.</value>
        [Description("Sets plc variable name - para 1 limit minimum."), Category("Limits")]
        public string Para1LimitMin
        {
            get { return tbxPara1.VarMinLimit; }
            set { tbxPara1.VarMinLimit = value; }
        }

        /// <summary>
        /// Set plc variable name - para 2 limit minimum.
        /// </summary>
        /// <value>Plc variable name - para 2 limit minimum.</value>
        [Description("Sets plc variable name - para 2 limit minimum."), Category("Limits")]
        public string Para2LimitMin
        {
            get { return tbxPara2.VarMinLimit; }
            set { tbxPara2.VarMinLimit = value; }
        }

        /// <summary>
        /// Set plc variable name - para 3 limit minimum.
        /// </summary>
        /// <value>Plc variable name - para 3 limit minimum.</value>
        [Description("Sets plc variable name - para 3 limit minimum."), Category("Limits")]
        public string Para3LimitMin
        {
            get { return tbxPara3.VarMinLimit; }
            set { tbxPara3.VarMinLimit = value; }
        }

        /// <summary>
        /// Set plc variable name - para 4 limit minimum.
        /// </summary>
        /// <value>Plc variable name - para 4 limit minimum.</value>
        [Description("Sets plc variable name - para 4 limit minimum."), Category("Limits")]
        public string Para4LimitMin
        {
            get { return tbxPara4.VarMinLimit; }
            set { tbxPara4.VarMinLimit = value; }
        }

        /// <summary>
        /// Set plc variable name - para 5 limit minimum.
        /// </summary>
        /// <value>Plc variable name - para 5 limit minimum.</value>
        [Description("Sets plc variable name - para 5 limit minimum."), Category("Limits")]
        public string Para5LimitMin
        {
            get { return tbxPara5.VarMinLimit; }
            set { tbxPara5.VarMinLimit = value; }
        }

        /// <summary>
        /// Set plc variable name - para 6 limit minimum.
        /// </summary>
        /// <value>Plc variable name - para 6 limit minimum.</value>
        [Description("Sets plc variable name - para 6 limit minimum."), Category("Limits")]
        public string Para6LimitMin
        {
            get { return tbxPara6.VarMinLimit; }
            set { tbxPara6.VarMinLimit = value; }
        }

        /// <summary>
        /// Set plc variable name - para 7 limit minimum.
        /// </summary>
        /// <value>Plc variable name - para 7 limit minimum.</value>
        [Description("Sets plc variable name - para 7 limit minimum."), Category("Limits")]
        public string Para7LimitMin
        {
            get { return tbxPara7.VarMinLimit; }
            set { tbxPara7.VarMinLimit = value; }
        }

        /// <summary>
        /// Set plc variable name - para 8 limit minimum.
        /// </summary>
        /// <value>Plc variable name - para 8 limit minimum.</value>
        [Description("Sets plc variable name - para 8 limit minimum."), Category("Limits")]
        public string Para8LimitMin
        {
            get { return tbxPara8.VarMinLimit; }
            set { tbxPara8.VarMinLimit = value; }
        }

        /// <summary>
        /// Set plc variable name - para 9 limit minimum.
        /// </summary>
        /// <value>Plc variable name - para 9 limit minimum.</value>
        [Description("Sets plc variable name - para 9 limit minimum."), Category("Limits")]
        public string Para9LimitMin
        {
            get { return tbxPara9.VarMinLimit; }
            set { tbxPara9.VarMinLimit = value; }
        }

        /// <summary>
        /// Set plc variable name - para 10 limit minimum.
        /// </summary>
        /// <value>Plc variable name - para 10 limit minimum.</value>
        [Description("Sets plc variable name - para 10 limit minimum."), Category("Limits")]
        public string Para10LimitMin
        {
            get { return tbxPara10.VarMinLimit; }
            set { tbxPara10.VarMinLimit = value; }
        }

        /// <summary>
        /// Set plc variable name - para 11 limit minimum.
        /// </summary>
        /// <value>Plc variable name - para 11 limit minimum.</value>
        [Description("Sets plc variable name - para 11 limit minimum."), Category("Limits")]
        public string Para11LimitMin
        {
            get { return tbxPara11.VarMinLimit; }
            set { tbxPara11.VarMinLimit = value; }
        }

        /// <summary>
        /// Set plc variable name - para 12 limit minimum.
        /// </summary>
        /// <value>Plc variable name - para 12 limit minimum.</value>
        [Description("Sets plc variable name - para 12 limit minimum."), Category("Limits")]
        public string Para12LimitMin
        {
            get { return tbxPara12.VarMinLimit; }
            set { tbxPara12.VarMinLimit = value; }
        }

        /// <summary>
        /// Set plc variable name - para 101 limit minimum.
        /// </summary>
        /// <value>Plc variable name - para 101 limit minimum.</value>
        [Description("Sets plc variable name - para 101 limit minimum."), Category("Limits")]
        public string Para101LimitMin
        {
            get { return tbxPara101.VarMinLimit; }
            set { tbxPara101.VarMinLimit = value; }
        }

        /// <summary>
        /// Set plc variable name - para 102 limit minimum.
        /// </summary>
        /// <value>Plc variable name - para 102 limit minimum.</value>
        [Description("Sets plc variable name - para 102 limit minimum."), Category("Limits")]
        public string Para102LimitMin
        {
            get { return tbxPara102.VarMinLimit; }
            set { tbxPara102.VarMinLimit = value; }
        }

        /// <summary>
        /// Set plc variable name - para 103 limit minimum.
        /// </summary>
        /// <value>Plc variable name - para 103 limit minimum.</value>
        [Description("Sets plc variable name - para 103 limit minimum."), Category("Limits")]
        public string Para103LimitMin
        {
            get { return tbxPara103.VarMinLimit; }
            set { tbxPara103.VarMinLimit = value; }
        }

        /// <summary>
        /// Set plc variable name - para 104 limit minimum.
        /// </summary>
        /// <value>Plc variable name - para 104 limit minimum.</value>
        [Description("Sets plc variable name - para 104 limit minimum."), Category("Limits")]
        public string Para104LimitMin
        {
            get { return tbxPara104.VarMinLimit; }
            set { tbxPara104.VarMinLimit = value; }
        }

        /// <summary>
        /// Set plc variable name - para 105 limit minimum.
        /// </summary>
        /// <value>Plc variable name - para 105 limit minimum.</value>
        [Description("Sets plc variable name - para 105 limit minimum."), Category("Limits")]
        public string Para105LimitMin
        {
            get { return tbxPara105.VarMinLimit; }
            set { tbxPara105.VarMinLimit = value; }
        }

        /// <summary>
        /// Set plc variable name - para 106 limit minimum.
        /// </summary>
        /// <value>Plc variable name - para 106 limit minimum.</value>
        [Description("Sets plc variable name - para 106 limit minimum."), Category("Limits")]
        public string Para106LimitMin
        {
            get { return tbxPara106.VarMinLimit; }
            set { tbxPara106.VarMinLimit = value; }
        }

        /// <summary>
        /// Set plc variable name - para 107 limit minimum.
        /// </summary>
        /// <value>Plc variable name - para 107 limit minimum.</value>
        [Description("Sets plc variable name - para 107 limit minimum."), Category("Limits")]
        public string Para107LimitMin
        {
            get { return tbxPara107.VarMinLimit; }
            set { tbxPara107.VarMinLimit = value; }
        }

        /// <summary>
        /// Set plc variable name - para 108 limit minimum.
        /// </summary>
        /// <value>Plc variable name - para 108 limit minimum.</value>
        [Description("Sets plc variable name - para 108 limit minimum."), Category("Limits")]
        public string Para108LimitMin
        {
            get { return tbxPara108.VarMinLimit; }
            set { tbxPara108.VarMinLimit = value; }
        }

        /// <summary>
        /// Set plc variable name - para 109 limit minimum.
        /// </summary>
        /// <value>Plc variable name - para 109 limit minimum.</value>
        [Description("Sets plc variable name - para 109 limit minimum."), Category("Limits")]
        public string Para109LimitMin
        {
            get { return tbxPara109.VarMinLimit; }
            set { tbxPara109.VarMinLimit = value; }
        }

        /// <summary>
        /// Set plc variable name - para 110 limit minimum.
        /// </summary>
        /// <value>Plc variable name - para 110 limit minimum.</value>
        [Description("Sets plc variable name - para 110 limit minimum."), Category("Limits")]
        public string Para110LimitMin
        {
            get { return tbxPara110.VarMinLimit; }
            set { tbxPara110.VarMinLimit = value; }
        }

        /// <summary>
        /// Set plc variable name - para 111 limit minimum.
        /// </summary>
        /// <value>Plc variable name - para 111 limit minimum.</value>
        [Description("Sets plc variable name - para 111 limit minimum."), Category("Limits")]
        public string Para111LimitMin
        {
            get { return tbxPara111.VarMinLimit; }
            set { tbxPara111.VarMinLimit = value; }
        }

        /// <summary>
        /// Set plc variable name - para 12 limit minimum.
        /// </summary>
        /// <value>Plc variable name - para 12 limit minimum.</value>
        [Description("Sets plc variable name - para 12 limit minimum."), Category("Limits")]
        public string Para112LimitMin
        {
            get { return tbxPara112.VarMinLimit; }
            set { tbxPara112.VarMinLimit = value; }
        }

        #endregion

        #region Limit Maximum

        /// <summary>
        /// Set plc variable name - para 1 limit maximum.
        /// </summary>
        /// <value>Plc variable name - para 1 limit maximum.</value>
        [Description("Sets plc variable name - para 1 limit maximum."), Category("Limits")]
        public string Para1LimitMax
        {
            get { return tbxPara1.VarMaxLimit; }
            set { tbxPara1.VarMaxLimit = value; }
        }

        /// <summary>
        /// Set plc variable name - para 2 limit maximum.
        /// </summary>
        /// <value>Plc variable name - para 2 limit maximum.</value>
        [Description("Sets plc variable name - para 2 limit maximum."), Category("Limits")]
        public string Para2LimitMax
        {
            get { return tbxPara2.VarMaxLimit; }
            set { tbxPara2.VarMaxLimit = value; }
        }

        /// <summary>
        /// Set plc variable name - para 3 limit maximum.
        /// </summary>
        /// <value>Plc variable name - para 3 limit maximum.</value>
        [Description("Sets plc variable name - para 3 limit maximum."), Category("Limits")]
        public string Para3LimitMax
        {
            get { return tbxPara3.VarMaxLimit; }
            set { tbxPara3.VarMaxLimit = value; }
        }

        /// <summary>
        /// Set plc variable name - para 4 limit maximum.
        /// </summary>
        /// <value>Plc variable name - para 4 limit maximum.</value>
        [Description("Sets plc variable name - para 4 limit maximum."), Category("Limits")]
        public string Para4LimitMax
        {
            get { return tbxPara4.VarMaxLimit; }
            set { tbxPara4.VarMaxLimit = value; }
        }

        /// <summary>
        /// Set plc variable name - para 5 limit maximum.
        /// </summary>
        /// <value>Plc variable name - para 5 limit maximum.</value>
        [Description("Sets plc variable name - para 5 limit maximum."), Category("Limits")]
        public string Para5LimitMax
        {
            get { return tbxPara5.VarMaxLimit; }
            set { tbxPara5.VarMaxLimit = value; }
        }

        /// <summary>
        /// Set plc variable name - para 6 limit maximum.
        /// </summary>
        /// <value>Plc variable name - para 6 limit maximum.</value>
        [Description("Sets plc variable name - para 6 limit maximum."), Category("Limits")]
        public string Para6LimitMax
        {
            get { return tbxPara6.VarMaxLimit; }
            set { tbxPara6.VarMaxLimit = value; }
        }

        /// <summary>
        /// Set plc variable name - para 7 limit maximum.
        /// </summary>
        /// <value>Plc variable name - para 7 limit maximum.</value>
        [Description("Sets plc variable name - para 7 limit maximum."), Category("Limits")]
        public string Para7LimitMax
        {
            get { return tbxPara7.VarMaxLimit; }
            set { tbxPara7.VarMaxLimit = value; }
        }

        /// <summary>
        /// Set plc variable name - para 8 limit maximum.
        /// </summary>
        /// <value>Plc variable name - para 8 limit maximum.</value>
        [Description("Sets plc variable name - para 8 limit maximum."), Category("Limits")]
        public string Para8LimitMax
        {
            get { return tbxPara8.VarMaxLimit; }
            set { tbxPara8.VarMaxLimit = value; }
        }

        /// <summary>
        /// Set plc variable name - para 9 limit maximum.
        /// </summary>
        /// <value>Plc variable name - para 9 limit maximum.</value>
        [Description("Sets plc variable name - para 9 limit maximum."), Category("Limits")]
        public string Para9LimitMax
        {
            get { return tbxPara9.VarMaxLimit; }
            set { tbxPara9.VarMaxLimit = value; }
        }

        /// <summary>
        /// Set plc variable name - para 10 limit maximum.
        /// </summary>
        /// <value>Plc variable name - para 10 limit maximum.</value>
        [Description("Sets plc variable name - para 10 limit maximum."), Category("Limits")]
        public string Para10LimitMax
        {
            get { return tbxPara10.VarMaxLimit; }
            set { tbxPara10.VarMaxLimit = value; }
        }

        /// <summary>
        /// Set plc variable name - para 11 limit maximum.
        /// </summary>
        /// <value>Plc variable name - para 11 limit maximum.</value>
        [Description("Sets plc variable name - para 11 limit maximum."), Category("Limits")]
        public string Para11LimitMax
        {
            get { return tbxPara11.VarMaxLimit; }
            set { tbxPara11.VarMaxLimit = value; }
        }

        /// <summary>
        /// Set plc variable name - para 12 limit maximum.
        /// </summary>
        /// <value>Plc variable name - para 12 limit maximum.</value>
        [Description("Sets plc variable name - para 12 limit maximum."), Category("Limits")]
        public string Para12LimitMax
        {
            get { return tbxPara12.VarMaxLimit; }
            set { tbxPara12.VarMaxLimit = value; }
        }

        /// <summary>
        /// Set plc variable name - para 101 limit maximum.
        /// </summary>
        /// <value>Plc variable name - para 101 limit maximum.</value>
        [Description("Sets plc variable name - para 101 limit maximum."), Category("Limits")]
        public string Para101LimitMax
        {
            get { return tbxPara101.VarMaxLimit; }
            set { tbxPara101.VarMaxLimit = value; }
        }

        /// <summary>
        /// Set plc variable name - para 102 limit maximum.
        /// </summary>
        /// <value>Plc variable name - para 102 limit maximum.</value>
        [Description("Sets plc variable name - para 102 limit maximum."), Category("Limits")]
        public string Para102LimitMax
        {
            get { return tbxPara102.VarMaxLimit; }
            set { tbxPara102.VarMaxLimit = value; }
        }

        /// <summary>
        /// Set plc variable name - para 103 limit maximum.
        /// </summary>
        /// <value>Plc variable name - para 103 limit maximum.</value>
        [Description("Sets plc variable name - para 103 limit maximum."), Category("Limits")]
        public string Para103LimitMax
        {
            get { return tbxPara103.VarMaxLimit; }
            set { tbxPara103.VarMaxLimit = value; }
        }

        /// <summary>
        /// Set plc variable name - para 104 limit maximum.
        /// </summary>
        /// <value>Plc variable name - para 104 limit maximum.</value>
        [Description("Sets plc variable name - para 104 limit maximum."), Category("Limits")]
        public string Para104LimitMax
        {
            get { return tbxPara104.VarMaxLimit; }
            set { tbxPara104.VarMaxLimit = value; }
        }

        /// <summary>
        /// Set plc variable name - para 105 limit maximum.
        /// </summary>
        /// <value>Plc variable name - para 105 limit maximum.</value>
        [Description("Sets plc variable name - para 105 limit maximum."), Category("Limits")]
        public string Para105LimitMax
        {
            get { return tbxPara105.VarMaxLimit; }
            set { tbxPara105.VarMaxLimit = value; }
        }

        /// <summary>
        /// Set plc variable name - para 106 limit maximum.
        /// </summary>
        /// <value>Plc variable name - para 106 limit maximum.</value>
        [Description("Sets plc variable name - para 106 limit maximum."), Category("Limits")]
        public string Para106LimitMax
        {
            get { return tbxPara106.VarMaxLimit; }
            set { tbxPara106.VarMaxLimit = value; }
        }

        /// <summary>
        /// Set plc variable name - para 107 limit maximum.
        /// </summary>
        /// <value>Plc variable name - para 107 limit maximum.</value>
        [Description("Sets plc variable name - para 107 limit maximum."), Category("Limits")]
        public string Para107LimitMax
        {
            get { return tbxPara107.VarMaxLimit; }
            set { tbxPara107.VarMaxLimit = value; }
        }

        /// <summary>
        /// Set plc variable name - para 108 limit maximum.
        /// </summary>
        /// <value>Plc variable name - para 108 limit maximum.</value>
        [Description("Sets plc variable name - para 108 limit maximum."), Category("Limits")]
        public string Para108LimitMax
        {
            get { return tbxPara108.VarMaxLimit; }
            set { tbxPara108.VarMaxLimit = value; }
        }

        /// <summary>
        /// Set plc variable name - para 109 limit maximum.
        /// </summary>
        /// <value>Plc variable name - para 109 limit maximum.</value>
        [Description("Sets plc variable name - para 109 limit maximum."), Category("Limits")]
        public string Para109LimitMax
        {
            get { return tbxPara109.VarMaxLimit; }
            set { tbxPara109.VarMaxLimit = value; }
        }

        /// <summary>
        /// Set plc variable name - para 110 limit maximum.
        /// </summary>
        /// <value>Plc variable name - para 110 limit maximum.</value>
        [Description("Sets plc variable name - para 110 limit maximum."), Category("Limits")]
        public string Para110LimitMax
        {
            get { return tbxPara110.VarMaxLimit; }
            set { tbxPara110.VarMaxLimit = value; }
        }

        /// <summary>
        /// Set plc variable name - para 111 limit maximum.
        /// </summary>
        /// <value>Plc variable name - para 111 limit maximum.</value>
        [Description("Sets plc variable name - para 111 limit maximum."), Category("Limits")]
        public string Para111LimitMax
        {
            get { return tbxPara111.VarMaxLimit; }
            set { tbxPara111.VarMaxLimit = value; }
        }

        /// <summary>
        /// Set plc variable name - para 112 limit maximum.
        /// </summary>
        /// <value>Plc variable name - para 112 limit maximum.</value>
        [Description("Sets plc variable name - para 112 limit maximum."), Category("Limits")]
        public string Para112LimitMax
        {
            get { return tbxPara112.VarMaxLimit; }
            set { tbxPara112.VarMaxLimit = value; }
        }

        #endregion

        #region Visible

        /// <summary>
        /// Set visible - para1.
        /// </summary>
        /// <value>Set visible - para1.</value>
        [Description("Set visible - para1."), Category("Visible")]
        public bool VisiblePara1
        {
            get { return tbxPara1.Visible; }
            set
            {
                tbxPara1.Visible = value;
                tbxPara101.Visible = value;
                lblPara1.Visible = value;
                label1.Visible = value;
            }
        }

        /// <summary>
        /// Set visible - para2.
        /// </summary>
        /// <value>Set visible - para2.</value>
        [Description("Set visible - para2."), Category("Visible")]
        public bool VisiblePara2
        {
            get { return tbxPara2.Visible; }
            set
            {
                tbxPara2.Visible = value;
                tbxPara102.Visible = value;
                lblPara2.Visible = value;
                label2.Visible = value;
            }
        }

        /// <summary>
        /// Set visible - para3.
        /// </summary>
        /// <value>Set visible - para3.</value>
        [Description("Set visible - para3."), Category("Visible")]
        public bool VisiblePara3
        {
            get { return tbxPara3.Visible; }
            set
            {
                tbxPara3.Visible = value;
                tbxPara103.Visible = value;
                lblPara3.Visible = value;
                label3.Visible = value;
            }
        }

        /// <summary>
        /// Set visible - para4.
        /// </summary>
        /// <value>Set visible - para4.</value>
        [Description("Set visible - para4."), Category("Visible")]
        public bool VisiblePara4
        {
            get { return tbxPara4.Visible; }
            set
            {
                tbxPara4.Visible = value;
                tbxPara104.Visible = value;
                lblPara4.Visible = value;
                label4.Visible = value;
            }
        }

        /// <summary>
        /// Set visible - para5.
        /// </summary>
        /// <value>Set visible - para5.</value>
        [Description("Set visible - para5."), Category("Visible")]
        public bool VisiblePara5
        {
            get { return tbxPara5.Visible; }
            set
            {
                tbxPara5.Visible = value;
                tbxPara105.Visible = value;
                lblPara5.Visible = value;
                label5.Visible = value;
            }
        }

        /// <summary>
        /// Set visible - para6.
        /// </summary>
        /// <value>Set visible - para6.</value>
        [Description("Set visible - para6."), Category("Visible")]
        public bool VisiblePara6
        {
            get { return tbxPara6.Visible; }
            set
            {
                tbxPara6.Visible = value;
                tbxPara106.Visible = value;
                lblPara6.Visible = value;
                label6.Visible = value;
            }
        }

        /// <summary>
        /// Set visible - para7.
        /// </summary>
        /// <value>Set visible - para7.</value>
        [Description("Set visible - para7."), Category("Visible")]
        public bool VisiblePara7
        {
            get { return tbxPara7.Visible; }
            set
            {
                tbxPara7.Visible = value;
                tbxPara107.Visible = value;
                lblPara7.Visible = value;
                label7.Visible = value;
            }
        }

        /// <summary>
        /// Set visible - para8.
        /// </summary>
        /// <value>Set visible - para8.</value>
        [Description("Set visible - para8."), Category("Visible")]
        public bool VisiblePara8
        {
            get { return tbxPara8.Visible; }
            set
            {
                tbxPara8.Visible = value;
                tbxPara108.Visible = value;
                lblPara8.Visible = value;
                label8.Visible = value;
            }
        }

        /// <summary>
        /// Set visible - para9.
        /// </summary>
        /// <value>Set visible - para9.</value>
        [Description("Set visible - para9."), Category("Visible")]
        public bool VisiblePara9
        {
            get { return tbxPara9.Visible; }
            set
            {
                tbxPara9.Visible = value;
                tbxPara109.Visible = value;
                lblPara9.Visible = value;
                label9.Visible = value;
            }
        }

        /// <summary>
        /// Set visible - para10.
        /// </summary>
        /// <value>Set visible - para10.</value>
        [Description("Set visible - para10."), Category("Visible")]
        public bool VisiblePara10
        {
            get { return tbxPara10.Visible; }
            set
            {
                tbxPara10.Visible = value;
                tbxPara110.Visible = value;
                lblPara10.Visible = value;
                label10.Visible = value;
            }
        }

        /// <summary>
        /// Set visible - para11.
        /// </summary>
        /// <value>Set visible - para11.</value>
        [Description("Set visible - para11."), Category("Visible")]
        public bool VisiblePara11
        {
            get { return tbxPara11.Visible; }
            set
            {
                tbxPara11.Visible = value;
                tbxPara111.Visible = value;
                lblPara11.Visible = value;
                label11.Visible = value;
            }
        }

        /// <summary>
        /// Set visible - para12.
        /// </summary>
        /// <value>Set visible - para12.</value>
        [Description("Set visible - para12."), Category("Visible")]
        public bool VisiblePara12
        {
            get { return tbxPara12.Visible; }
            set
            {
                tbxPara12.Visible = value;
                tbxPara112.Visible = value;
                lblPara12.Visible = value;
                label12.Visible = value;
            }
        }

        #endregion

        #region Disable

        /// <summary>
        /// Set disable - para1.
        /// </summary>
        /// <value>Set disable - para1.</value>
        [Description("Set disable - para1."), Category("Disable")]
        public bool DisablePara1
        {
            get { return tbxPara1.Disable; }
            set
            {
                tbxPara1.Disable = value;
            }
        }

        /// <summary>
        /// Set disable - para2.
        /// </summary>
        /// <value>Set disable - para2.</value>
        [Description("Set disable - para2."), Category("Disable")]
        public bool DisablePara2
        {
            get { return tbxPara2.Disable; }
            set
            {
                tbxPara2.Disable = value;
            }
        }

        /// <summary>
        /// Set disable - para3.
        /// </summary>
        /// <value>Set disable - para3.</value>
        [Description("Set disable - para3."), Category("Disable")]
        public bool DisablePara3
        {
            get { return tbxPara3.Disable; }
            set
            {
                tbxPara3.Disable = value;
            }
        }

        /// <summary>
        /// Set disable - para4.
        /// </summary>
        /// <value>Set disable - para4.</value>
        [Description("Set disable - para4."), Category("Disable")]
        public bool DisablePara4
        {
            get { return tbxPara4.Disable; }
            set
            {
                tbxPara4.Disable = value;
            }
        }

        /// <summary>
        /// Set disable - para5.
        /// </summary>
        /// <value>Set disable - para5.</value>
        [Description("Set disable - para5."), Category("Disable")]
        public bool DisablePara5
        {
            get { return tbxPara5.Disable; }
            set
            {
                tbxPara5.Disable = value;
            }
        }

        /// <summary>
        /// Set disable - para6.
        /// </summary>
        /// <value>Set disable - para6.</value>
        [Description("Set disable - para6."), Category("Disable")]
        public bool DisablePara6
        {
            get { return tbxPara6.Disable; }
            set
            {
                tbxPara6.Disable = value;
            }
        }

        /// <summary>
        /// Set disable - para7.
        /// </summary>
        /// <value>Set disable - para7.</value>
        [Description("Set disable - para7."), Category("Disable")]
        public bool DisablePara7
        {
            get { return tbxPara7.Disable; }
            set
            {
                tbxPara7.Disable = value;
            }
        }

        /// <summary>
        /// Set disable - para8.
        /// </summary>
        /// <value>Set disable - para8.</value>
        [Description("Set disable - para8."), Category("Disable")]
        public bool DisablePara8
        {
            get { return tbxPara8.Disable; }
            set
            {
                tbxPara8.Disable = value; ;
            }
        }

        /// <summary>
        /// Set disable - para9.
        /// </summary>
        /// <value>Set disable - para9.</value>
        [Description("Set disable - para9."), Category("Disable")]
        public bool DisablePara9
        {
            get { return tbxPara9.Disable; }
            set
            {
                tbxPara9.Disable = value;
            }
        }

        /// <summary>
        /// Set disable - para10.
        /// </summary>
        /// <value>Set disable - para10.</value>
        [Description("Set disable - para10."), Category("Disable")]
        public bool DisablePara10
        {
            get { return tbxPara10.Disable; }
            set
            {
                tbxPara10.Disable = value;
            }
        }

        /// <summary>
        /// Set disable - para11.
        /// </summary>
        /// <value>Set disable - para11.</value>
        [Description("Set disable - para11."), Category("Disable")]
        public bool DisablePara11
        {
            get { return tbxPara11.Disable; }
            set
            {
                tbxPara11.Disable = value;
            }
        }

        /// <summary>
        /// Set disable - para12.
        /// </summary>
        /// <value>Set disable - para12.</value>
        [Description("Set disable - para12."), Category("Disable")]
        public bool DisablePara12
        {
            get { return tbxPara12.Disable; }
            set
            {
                tbxPara12.Disable = value;
            }
        }

        /// <summary>
        /// Set disable - para101.
        /// </summary>
        /// <value>Set disable - para101.</value>
        [Description("Set disable - para101."), Category("Disable")]
        public bool DisablePara101
        {
            get { return tbxPara101.Disable; }
            set
            {
                tbxPara101.Disable = value;
            }
        }

        /// <summary>
        /// Set disable - para102.
        /// </summary>
        /// <value>Set disable - para102.</value>
        [Description("Set disable - para102."), Category("Disable")]
        public bool DisablePara102
        {
            get { return tbxPara102.Disable; }
            set
            {
                tbxPara102.Disable = value;
            }
        }

        /// <summary>
        /// Set disable - para103.
        /// </summary>
        /// <value>Set disable - para103.</value>
        [Description("Set disable - para103."), Category("Disable")]
        public bool DisablePara103
        {
            get { return tbxPara103.Disable; }
            set
            {
                tbxPara103.Disable = value;
            }
        }

        /// <summary>
        /// Set disable - para104.
        /// </summary>
        /// <value>Set disable - para104.</value>
        [Description("Set disable - para104."), Category("Disable")]
        public bool DisablePara104
        {
            get { return tbxPara104.Disable; }
            set
            {
                tbxPara104.Disable = value;
            }
        }

        /// <summary>
        /// Set disable - para105.
        /// </summary>
        /// <value>Set disable - para105.</value>
        [Description("Set disable - para105."), Category("Disable")]
        public bool DisablePara105
        {
            get { return tbxPara105.Disable; }
            set
            {
                tbxPara105.Disable = value;
            }
        }

        /// <summary>
        /// Set disable - para106.
        /// </summary>
        /// <value>Set disable - para106.</value>
        [Description("Set disable - para106."), Category("Disable")]
        public bool DisablePara106
        {
            get { return tbxPara106.Disable; }
            set
            {
                tbxPara106.Disable = value;
            }
        }

        /// <summary>
        /// Set disable - para107.
        /// </summary>
        /// <value>Set disable - para107.</value>
        [Description("Set disable - para107."), Category("Disable")]
        public bool DisablePara107
        {
            get { return tbxPara107.Disable; }
            set
            {
                tbxPara107.Disable = value;
            }
        }

        /// <summary>
        /// Set disable - para108.
        /// </summary>
        /// <value>Set disable - para108.</value>
        [Description("Set disable - para108."), Category("Disable")]
        public bool DisablePara108
        {
            get { return tbxPara108.Disable; }
            set
            {
                tbxPara108.Disable = value; ;
            }
        }

        /// <summary>
        /// Set disable - para109.
        /// </summary>
        /// <value>Set disable - para109.</value>
        [Description("Set disable - para109."), Category("Disable")]
        public bool DisablePara109
        {
            get { return tbxPara109.Disable; }
            set
            {
                tbxPara109.Disable = value;
            }
        }

        /// <summary>
        /// Set disable - para110.
        /// </summary>
        /// <value>Set disable - para110.</value>
        [Description("Set disable - para110."), Category("Disable")]
        public bool DisablePara110
        {
            get { return tbxPara110.Disable; }
            set
            {
                tbxPara110.Disable = value;
            }
        }

        /// <summary>
        /// Set disable - para111.
        /// </summary>
        /// <value>Set disable - para111.</value>
        [Description("Set disable - para111."), Category("Disable")]
        public bool DisablePara111
        {
            get { return tbxPara111.Disable; }
            set
            {
                tbxPara111.Disable = value;
            }
        }

        /// <summary>
        /// Set disable - para112.
        /// </summary>
        /// <value>Set disable - para112.</value>
        [Description("Set disable - para112."), Category("Disable")]
        public bool DisablePara112
        {
            get { return tbxPara112.Disable; }
            set
            {
                tbxPara112.Disable = value;
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

        [DefaultValue(1)]
        [Description("Sets the user manager."), Category("App")]
        public void SerUserManager(CUserManager um)
        {
            this.um = um;
            this.tbxPara1.UserManager = um;
            this.tbxPara2.UserManager = um;
            this.tbxPara3.UserManager = um;
            this.tbxPara4.UserManager = um;
            this.tbxPara5.UserManager = um;
            this.tbxPara6.UserManager = um;
            this.tbxPara7.UserManager = um;
            this.tbxPara8.UserManager = um;
            this.tbxPara9.UserManager = um;
            this.tbxPara10.UserManager = um;
            this.tbxPara11.UserManager = um;
            this.tbxPara12.UserManager = um;

            this.tbxPara101.UserManager = um;
            this.tbxPara102.UserManager = um;
            this.tbxPara103.UserManager = um;
            this.tbxPara104.UserManager = um;
            this.tbxPara105.UserManager = um;
            this.tbxPara106.UserManager = um;
            this.tbxPara107.UserManager = um;
            this.tbxPara108.UserManager = um;
            this.tbxPara109.UserManager = um;
            this.tbxPara110.UserManager = um;
            this.tbxPara111.UserManager = um;
            this.tbxPara112.UserManager = um;
        }

        #endregion

        #region Private methods

        private void LoadLanguageStrings()
        {
            if (this.lm != null)
            {
                this.gbxProcessPara.Text = lm["UCProcessPara2." + m_Name + ".gbxProcessPara"];

                this.lblPara1.Text = lm["UCProcessPara2." + m_Name + ".lblPara1"];
                this.lblPara2.Text = lm["UCProcessPara2." + m_Name + ".lblPara2"];
                this.lblPara3.Text = lm["UCProcessPara2." + m_Name + ".lblPara3"];
                this.lblPara4.Text = lm["UCProcessPara2." + m_Name + ".lblPara4"];

                this.lblPara5.Text = lm["UCProcessPara2." + m_Name + ".lblPara5"];
                this.lblPara6.Text = lm["UCProcessPara2." + m_Name + ".lblPara6"];
                this.lblPara7.Text = lm["UCProcessPara2." + m_Name + ".lblPara7"];
                this.lblPara8.Text = lm["UCProcessPara2." + m_Name + ".lblPara8"];

                this.lblPara9.Text = lm["UCProcessPara2." + m_Name + ".lblPara9"];
                this.lblPara10.Text = lm["UCProcessPara2." + m_Name + ".lblPara10"];
                this.lblPara11.Text = lm["UCProcessPara2." + m_Name + ".lblPara11"];
                this.lblPara12.Text = lm["UCProcessPara2." + m_Name + ".lblPara12"];

            }
            else
            {
                this.gbxProcessPara.Text = "Process parameters";

                this.lblPara1.Text = "Para1:";
                this.lblPara2.Text = "Para2:";
                this.lblPara3.Text = "Para3:";
                this.lblPara4.Text = "Para4:";

                this.lblPara5.Text = "Para5:";
                this.lblPara6.Text = "Para6:";
                this.lblPara7.Text = "Para7:";
                this.lblPara8.Text = "Para8:";

                this.lblPara9.Text = "Para9:";
                this.lblPara10.Text = "Para10:";
                this.lblPara11.Text = "Para11:";
                this.lblPara12.Text = "Para12:";  
          
            }

        }

        #endregion

    }
}
