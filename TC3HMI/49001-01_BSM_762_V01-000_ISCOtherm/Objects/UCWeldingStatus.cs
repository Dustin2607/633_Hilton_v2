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

    public partial class UCWeldingStatus : UserControlBase
    {

        #region Member enummerations

        #endregion

        #region Member variables

        // TwinCAT references
        private TcAdsClient adsClient;

        // Application
        private CLanguageManager lm;
        private string[] arsWeldingStatus = new string[7] { "", "", "", "", "", "", ""};

        private string m_Name;

        // Set color theme
        private Color colorCaption;
        private Color colorRow2;
        private Color colorRow3;

        private short m_snWeldnigStatus;

        #endregion

        #region Systemcode

        #region Constructor

        /// <summary>
        /// Constructor UCWeldingPara.
        /// </summary>
        public UCWeldingStatus()
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

        /// <summary>
        /// Gets / sets the parameter.
        /// </summary>
        /// <value>The parameter.</value>
        [Description("Gets / sets the parameter."), Category("App")]
        public string Para1
        {
            get { return this.tbxPara1.Text; }
            set { tbxPara1.Text = value; }
        }

        /// <summary>
        /// Gets / sets the parameter.
        /// </summary>
        /// <value>The parameter.</value>
        [Description("Gets / sets the parameter."), Category("App")]
        public string Para2
        {
            get { return this.tbxPara2.Text; }
            set { tbxPara2.Text = value; }
        }

        /// <summary>
        /// Gets / sets the parameter.
        /// </summary>
        /// <value>The parameter.</value>
        [Description("Gets / sets the parameter."), Category("App")]
        public string Para3
        {
            get { return this.tbxPara3.Text; }
            set { tbxPara3.Text = value; }
        }

        /// <summary>
        /// Gets / sets the parameter.
        /// </summary>
        /// <value>The parameter.</value>
        [Description("Gets / sets the parameter."), Category("App")]
        public string Para4
        {
            get { return this.tbxPara4.Text; }
            set { tbxPara4.Text = value; }
        }

        /// <summary>
        /// Gets / sets the parameter.
        /// </summary>
        /// <value>The parameter.</value>
        [Description("Gets / sets the parameter."), Category("App")]
        public string Para5
        {
            get { return this.tbxPara5.Text; }
            set { tbxPara5.Text = value; }
        }

        /// <summary>
        /// Gets / sets the parameter.
        /// </summary>
        /// <value>The parameter.</value>
        [Description("Gets / sets the parameter."), Category("App")]
        public string Para6
        {
            get { return this.tbxPara6.Text; }
            set { tbxPara6.Text = value; }
        }

        /// <summary>
        /// Gets / sets the parameter.
        /// </summary>
        /// <value>The parameter.</value>
        [Description("Gets / sets the parameter."), Category("App")]
        public string Para7
        {
            get { return this.tbxPara7.Text; }
            set { tbxPara7.Text = value; }
        }

        /// <summary>
        /// Gets / sets the parameter.
        /// </summary>
        /// <value>The parameter.</value>
        [Description("Gets / sets the parameter."), Category("App")]
        public string Para8
        {
            get { return this.tbxPara8.Text; }
            set { tbxPara8.Text = value; }
        }

        /// <summary>
        /// Gets / sets the parameter.
        /// </summary>
        /// <value>The parameter.</value>
        [Description("Gets / sets the parameter."), Category("App")]
        public string Para9
        {
            get { return this.tbxPara9.Text; }
            set { tbxPara9.Text = value; }
        }

        /// <summary>
        /// Gets / sets the parameter.
        /// </summary>
        /// <value>The parameter.</value>
        [Description("Gets / sets the parameter."), Category("App")]
        public string Para10
        {
            get { return this.tbxPara10.Text; }
            set { tbxPara10.Text = value; }
        }

        /// <summary>
        /// Gets / sets the parameter.
        /// </summary>
        /// <value>The parameter.</value>
        [Description("Gets / sets the parameter."), Category("App")]
        public string Para11
        {
            get { return this.tbxPara11.Text; }
            set { tbxPara11.Text = value; }
        }

        /// <summary>
        /// Gets / sets the parameter.
        /// </summary>
        /// <value>The parameter.</value>
        [Description("Gets / sets the parameter."), Category("App")]
        public string Para12
        {
            get { return this.tbxPara12.Text; }
            set { tbxPara12.Text = value; }
        }

        /// <summary>
        /// Set plc variable name -  weldnig status.
        /// </summary>
        /// <value>Plc variable name - weldnig status.</value>
        [Description("Sets plc variable name - weldnig status."), Category("App")]
        public short WeldnigStatus
        {
            get { return m_snWeldnigStatus; }
            set
            {
                m_snWeldnigStatus = value;
                GetWeldingStatus();
            }
        }

        #endregion

        #region User interface

        #endregion

        #region Events

        #region Form Events

        private void UCMachineParameters_Load(object sender, EventArgs e)
        {
            //if (this.lm == null)
            //    return;
            //this.lm.StringDel += new CLanguageManager.InitStringDelegate(this.LoadLanguageStrings);
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

        #endregion

        #region Private methods

        private void LoadLanguageStrings()
        {
            if (this.lm != null)
            {
                this.gbxWeldingStatus.Text = lm["UCWeldingStatus." + m_Name + ".gbxWeldingStatus"];

                this.lblPara0.Text = lm["UCWeldingStatus." + m_Name + ".lblPara0"];
                this.lblPara1.Text = lm["UCWeldingStatus." + m_Name + ".lblPara1"];
                this.lblPara2.Text = lm["UCWeldingStatus." + m_Name + ".lblPara2"];
                this.lblPara3.Text = lm["UCWeldingStatus." + m_Name + ".lblPara3"];
                this.lblPara4.Text = lm["UCWeldingStatus." + m_Name + ".lblPara4"];
                this.lblPara5.Text = lm["UCWeldingStatus." + m_Name + ".lblPara5"];
                this.lblPara20.Text = lm["UCWeldingStatus." + m_Name + ".lblPara20"];

                this.arsWeldingStatus[0] = lm["UCWeldingStatus." + m_Name + ".NoPhase"];
                this.arsWeldingStatus[1] = lm["UCWeldingStatus." + m_Name + ".Preheating"];
                this.arsWeldingStatus[2] = lm["UCWeldingStatus." + m_Name + ".BeadUp"];
                this.arsWeldingStatus[3] = lm["UCWeldingStatus." + m_Name + ".HeatUp"];
                this.arsWeldingStatus[4] = lm["UCWeldingStatus." + m_Name + ".Changeover"];
                this.arsWeldingStatus[5] = lm["UCWeldingStatus." + m_Name + ".Welding"];
                this.arsWeldingStatus[6] = lm["UCWeldingStatus." + m_Name + ".Cooling"];
            }
            else
            {
                this.gbxWeldingStatus.Text = "Welding status";

                this.lblPara0.Text = "Preheating";
                this.lblPara1.Text = "Heating";
                this.lblPara2.Text = "Changeover";
                this.lblPara3.Text = "Cooling";
                this.lblPara4.Text = "Welding time";
                this.lblPara5.Text = "Force";
                this.lblPara20.Text = "Current phase";

                this.arsWeldingStatus[0] = "NoPhase";
                this.arsWeldingStatus[1] = "Preheating";
                this.arsWeldingStatus[2] = "BeadUp";
                this.arsWeldingStatus[3] = "HeatUp";
                this.arsWeldingStatus[4] = "Changeover";
                this.arsWeldingStatus[5] = "Welding";
                this.arsWeldingStatus[6] = "Cooling";
            }

            GetWeldingStatus();

        }

        private void GetWeldingStatus()
        {

            lblPara21.Text = this.arsWeldingStatus[0];

            switch (m_snWeldnigStatus)
            {
                case 0:
                    break;

                case 28:
                    lblPara21.Text = this.arsWeldingStatus[1];
                    break;

                case 29:
                case 30:
                case 31:
                case 32:
                case 33:
                case 34:
                case 35:
                case 36:
                case 37:
                    lblPara21.Text = this.arsWeldingStatus[4];
                    break;

                case 1101:
                case 1102:
                case 1103:
                case 1104:
                case 1105:
                case 1106:
                case 1107:
                    lblPara21.Text = this.arsWeldingStatus[2];
                    break;

                case 1108:
                case 1109:
                case 1110:
                case 1111:
                case 1112:
                case 1113:
                case 1114:
                case 1115:
                case 1116:

                    lblPara21.Text = this.arsWeldingStatus[3];

                    break;

                case 1201:
                case 1202:
                case 1203:
                case 1204:
                    lblPara21.Text = this.arsWeldingStatus[5];

                    break;

                case 1205:
                case 1206:
                case 1207:
                case 1208:
                case 1209:
                case 1210:

                    lblPara21.Text = this.arsWeldingStatus[6];

                    break;
            }

        }

        #endregion

    }
}
