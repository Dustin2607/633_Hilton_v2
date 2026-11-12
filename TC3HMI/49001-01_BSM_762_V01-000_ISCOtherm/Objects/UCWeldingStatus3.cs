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

    public partial class UCWeldingStatus3 :  UserControlBase
    {

        #region Member enummerations

        #endregion

        #region Member variables

        // TwinCAT references
        private TcAdsClient adsClient;

        // Application
        private CLanguageManager lm;
        private string[] arsWeldingStatus = new string[10] { "", "", "", "", "", "", "", "", "", "" };

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
        public UCWeldingStatus3()
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
            get { return this.tbxPara3.Text; }
            set { tbxPara3.Text = value; }
        }

        /// <summary>
        /// Gets / sets the parameter.
        /// </summary>
        /// <value>The parameter.</value>
        [Description("Gets / sets the parameter."), Category("App")]
        public string Para2
        {
            get { return this.tbxPara4.Text; }
            set { tbxPara4.Text = value; }
        }

        /// <summary>
        /// Gets / sets the parameter.
        /// </summary>
        /// <value>The parameter.</value>
        [Description("Gets / sets the parameter."), Category("App")]
        public string Para3
        {
            get { return this.tbxPara1.Text; }
            set { tbxPara1.Text = value; }
        }

        /// <summary>
        /// Gets / sets the parameter.
        /// </summary>
        /// <value>The parameter.</value>
        [Description("Gets / sets the parameter."), Category("App")]
        public string Para4
        {
            get { return this.tbxPara2.Text; }
            set { tbxPara2.Text = value; }
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
                this.lblPara4.Text = lm["UCWeldingStatus." + m_Name + ".lblPara4"];
                this.lblPara20.Text = lm["UCWeldingStatus." + m_Name + ".lblPara20"];

                this.arsWeldingStatus[0] = lm["UCWeldingStatus." + m_Name + ".NoPhase"];
                this.arsWeldingStatus[1] = lm["UCWeldingStatus." + m_Name + ".Preheating"];
                this.arsWeldingStatus[2] = lm["UCWeldingStatus." + m_Name + ".Joining - Phase 1"];
                this.arsWeldingStatus[3] = lm["UCWeldingStatus." + m_Name + ".Heating - Phase 1"];
                this.arsWeldingStatus[4] = lm["UCWeldingStatus." + m_Name + ".Joining - Phase 2"];
                this.arsWeldingStatus[5] = lm["UCWeldingStatus." + m_Name + ".Heating - Phase 2"];
                this.arsWeldingStatus[6] = lm["UCWeldingStatus." + m_Name + ".Joining - Phase 3"];
                this.arsWeldingStatus[7] = lm["UCWeldingStatus." + m_Name + ".Heating - Phase 3"];
                this.arsWeldingStatus[8] = lm["UCWeldingStatus." + m_Name + ".Joining - Phase 4"];
                this.arsWeldingStatus[9] = lm["UCWeldingStatus." + m_Name + ".Heating - Phase 4"];
            }
            else
            {
                this.gbxWeldingStatus.Text = "Welding status";

                this.lblPara0.Text = "Preheating";
                this.lblPara4.Text = "Welding time";
                this.lblPara20.Text = "Current phase";

                this.arsWeldingStatus[0] = "NoPhase";
                this.arsWeldingStatus[1] = "Preheating";
                this.arsWeldingStatus[2] = "Joining - Phase 1";
                this.arsWeldingStatus[3] = "Heating - Phase 1";
                this.arsWeldingStatus[4] = "Joining - Phase 2";
                this.arsWeldingStatus[5] = "Heating - Phase 2";
                this.arsWeldingStatus[6] = "Joining - Phase 3";
                this.arsWeldingStatus[7] = "Heating - Phase 3";
                this.arsWeldingStatus[8] = "Joining - Phase 4";
                this.arsWeldingStatus[9] = "Heating - Phase 4";
            }

            GetWeldingStatus();

        }

        private void GetWeldingStatus()
        {

            lblPara15.Text = this.arsWeldingStatus[0];

            switch (m_snWeldnigStatus)
            {
                case 0:
                    break;

                case 9:
                case 12:
                    lblPara15.Text = this.arsWeldingStatus[1];
                    break;

                //case 19: case 20: case 21: case 22: case 23: case 24: case 25: case 26: case 27:
                //    lblPara6.Text = /*"Changeover";*/"Umstellen";
                //    break;

                case 1000:
                case 1001:
                case 1002:
                case 1003:
                case 1004:
                    lblPara15.Text = this.arsWeldingStatus[2];
                    break;
                case 1005:
                case 1006:
                case 1007:
                case 1008:
                    lblPara15.Text = this.arsWeldingStatus[3];
                    break;

                case 1100:
                case 1101:
                case 1102:
                case 1103:
                case 1104:
                    lblPara15.Text = this.arsWeldingStatus[4];
                    break;
                case 1105:
                case 1106:
                case 1107:
                case 1108:
                    lblPara15.Text = this.arsWeldingStatus[5];
                    break;

                case 1200:
                case 1201:
                case 1202:
                case 1203:
                case 1204:
                    lblPara15.Text = this.arsWeldingStatus[6];
                    break;
                case 1205:
                case 1206:
                case 1207:
                case 1208:
                    lblPara15.Text = this.arsWeldingStatus[7];
                    break;

                case 1300:
                case 1301:
                case 1302:
                case 1303:
                case 1304:
                    lblPara15.Text = this.arsWeldingStatus[8];
                    break;
                case 1305:
                case 1306:
                case 1307:
                case 1308:
                    lblPara15.Text = this.arsWeldingStatus[9];
                    break;

            }

        }

        #endregion

    }
}
