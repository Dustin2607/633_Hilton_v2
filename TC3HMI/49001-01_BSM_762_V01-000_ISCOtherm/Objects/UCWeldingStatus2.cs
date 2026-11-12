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

    public partial class UCWeldingStatus2 : UserControl
    {

        #region Member enummerations

        #endregion

        #region Member variables

        // Application
        private FMainApp frmMainApp;
        private CLanguageManager lm;

        private string m_sWPh1InitTime;
        private string m_sWPh1RestTime;
        private string m_sWPh2InitTime;
        private string m_sWPh2RestTime;
        private string m_sChangeOverInitTime;
        private string m_sChangeOverActTime;
        private string m_sWeldnigInitTime;
        private string m_sWeldnigRestTime;
        private short m_snWeldnigStatus;


        // Set color theme
        private Color colorCaption;
        private Color colorRow2;
        private Color colorRow3;

        #endregion

        #region Systemcode

        #region Constructor

        /// <summary>
        /// Constructor UCWeldingStatus2.
        /// </summary>
        public UCWeldingStatus2()
        {
            InitializeComponent();

            // Set color theme
            colorCaption = groupBox1.BackColor;
            colorRow2 = groupBox1.BackColor;
            colorRow3 = groupBox1.BackColor;

        }

        #endregion

        #endregion

        #region Properties

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
                groupBox1.BackColor = colorRow2;
                groupBox2.BackColor = colorRow2;
                groupBox3.BackColor = colorRow2;
                groupBox4.BackColor = colorRow2;
                groupBox5.BackColor = colorRow2;
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
            set { this.lm = value;
            LoadLanguageStrings();
            }
        }

        /// <summary>
        /// Set plc variable name - welding phase 1 init time.
        /// </summary>
        /// <value>Plc variable name - welding phase 1 init time.</value>
        [Description("Sets plc variable name - welding phase 1 init time."), Category("App")]
        public string WPh1InitTime
        {
            get { return m_sWPh1InitTime; }
            set {
                    m_sWPh1InitTime = value;
                    lblWPh1InitTime.Text = m_sWPh1InitTime;
                }
        }

        /// <summary>
        /// Set plc variable name -  welding phase 1 rest time.
        /// </summary>
        /// <value>Plc variable name - welding phase 1 rest time.</value>
        [Description("Sets plc variable name - welding phase 1 rest time."), Category("App")]
        public string WPh1RestTime
        {
            get { return m_sWPh1RestTime; }
            set {
                    m_sWPh1RestTime = value;
                    lblWPh1RestTime.Text = m_sWPh1RestTime;
                }
        }

        /// <summary>
        /// Set plc variable name - welding phase 2 init time.
        /// </summary>
        /// <value>Plc variable name - welding phase 2 init time.</value>
        [Description("Sets plc variable name - welding phase 2 init time."), Category("App")]
        public string WPh2InitTime
        {
            get { return m_sWPh2InitTime; }
            set
            {
                m_sWPh2InitTime = value;
                lblWPh2InitTime.Text = m_sWPh2InitTime;
            }
        }

        /// <summary>
        /// Set plc variable name -  welding phase 2 rest time.
        /// </summary>
        /// <value>Plc variable name - welding phase 2 rest time.</value>
        [Description("Sets plc variable name - welding phase 2 rest time."), Category("App")]
        public string WPh2RestTime
        {
            get { return m_sWPh2RestTime; }
            set
            {
                m_sWPh2RestTime = value;
                lblWPh2RestTime.Text = m_sWPh2RestTime;
            }
        }

        /// <summary>
        /// Set plc variable name - changeover init time.
        /// </summary>
        /// <value>Plc variable name - changeover init time.</value>
        [Description("Sets plc variable name - changeover init time."), Category("App")]
        public string ChangeOverInitTime
        {
            get { return m_sChangeOverInitTime; }
            set
            {
                m_sChangeOverInitTime = value;
                lblChangeOverInitTime.Text = m_sChangeOverInitTime;
            }
        }

        /// <summary>
        /// Set plc variable name -  changeover rest time.
        /// </summary>
        /// <value>Plc variable name - changeover rest time.</value>
        [Description("Sets plc variable name - changeover rest time."), Category("App")]
        public string ChangeOverActTime
        {
            get { return m_sChangeOverActTime; }
            set
            {
                m_sChangeOverActTime = value;
                lblChangeOverActTime.Text = m_sChangeOverActTime;
            }
        }


        /// <summary>
        /// Set plc variable name - weldnig init time.
        /// </summary>
        /// <value>Plc variable name - weldnig init time.</value>
        [Description("Sets plc variable name - weldnig init time."), Category("App")]
        public string WeldnigInitTime
        {
            get { return m_sWeldnigInitTime; }
            set
            {
                m_sWeldnigInitTime = value;
                lblWeldnigInitTime.Text = m_sWeldnigInitTime;
            }
        }

        /// <summary>
        /// Set plc variable name -  weldnig rest time.
        /// </summary>
        /// <value>Plc variable name - weldnig rest time.</value>
        [Description("Sets plc variable name - weldnig rest time."), Category("App")]
        public string WeldnigRestTime
        {
            get { return m_sWeldnigRestTime; }
            set
            {
                m_sWeldnigRestTime = value;
                lblWeldnigRestTime.Text = m_sWeldnigRestTime;
            }
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
                mGetWeldingStatus();
            }
        }

        #endregion

        #region Events

        #region Form Events

        private void UCWeldingStatics_Load(object sender, EventArgs e)
        {
            frmMainApp = CMainApp.GetMainAppForm();

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

        #region Public functions

        #endregion

        #region Private methods

        private void LoadLanguageStrings()
        {
            if (this.lm != null)
            {
                lblHeating.Text = lm["UCWeldingStatus2.lblHeating"];
                lblChangeover.Text = lm["UCWeldingStatus2.lblChangeover"];
                lblCooling.Text = lm["UCWeldingStatus2.lblCooling"];
                lblCycletime.Text = lm["UCWeldingStatus2.lblCycletime"];
                lblCurrentPhase.Text = lm["UCWeldingStatus2.lblCurrentPhase"];
            }
            else
            {
                lblHeating.Text = "Heating:";
                lblChangeover.Text = "Changeover:";
                lblCooling.Text = "Cooling:";
                lblCycletime.Text = "Welding:";
                lblCurrentPhase.Text = "CurrentPhase:";
            }

            mGetWeldingStatus();
        }

        private void mGetWeldingStatus()
        {

            if (this.lm != null)
            {

                //lblWeldnigStatus.Text = lm["UCWeldingStatus.lblWeldnigStatus.NoPhase"];

                switch (m_snWeldnigStatus)
                {
                //    case 10:
                //    case 11:
                //    case 12:
                //    case 13:
                //    case 14:

                //        lblWeldnigStatus.Text = lm["UCWeldingStatus.lblWeldnigStatus.Changeover"];

                //        break;

                //    case 120:
                //    case 125:
                //    case 130:
                //    case 135:

                //        lblWeldnigStatus.Text = lm["UCWeldingStatus.lblWeldnigStatus.BeadUp"];

                //        break;

                //    case 140:
                //    case 145:
                //    case 150:
                //    case 155:

                //        lblWeldnigStatus.Text = lm["UCWeldingStatus.lblWeldnigStatus.HeatUp"];

                //        break;

                //    case 220:
                //    case 225:

                //        lblWeldnigStatus.Text = lm["UCWeldingStatus.lblWeldnigStatus.Welding"];

                //        break;

                //    case 230:
                //    case 235:

                //        lblWeldnigStatus.Text = lm["UCWeldingStatics.lblWeldnigStatus.Cooling"];

                //        break;
                }
            }
            else
            {
                lblWeldnigStatus.Text = "No Phase";

                switch (m_snWeldnigStatus)
                {
                    case 10:
                    case 11:
                    case 12:
                    case 13:
                    case 14:

                        lblWeldnigStatus.Text = "Changeover";

                        break;

                    case 120:
                    case 125:
                    case 130:
                    case 135:

                        lblWeldnigStatus.Text = "Bead Up";

                        break;

                    case 140:
                    case 145:
                    case 150:
                    case 155:

                        lblWeldnigStatus.Text = "Heat Up";

                        break;

                    case 220:
                    case 225:

                        lblWeldnigStatus.Text = "Welding";

                        break;

                    case 230:
                    case 235:

                        lblWeldnigStatus.Text = "Cooling";

                        break;
                }
            
            }

        }

        #endregion

    }
}
