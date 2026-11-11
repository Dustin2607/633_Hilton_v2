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

    public partial class UCMachineStatics : UserControl
    {
        #region Member enummerations

        #endregion

        #region Member variables

        // Application
        private FMainApp frmMainApp;
        private CLanguageManager lm;

        private string m_sMachineLiveTime;
        private string m_sTotalCounter;
        private string m_sCounterPartOK;
        private string m_sCounterPartNOK;

        // Set color theme
        private Color colorCaption;
        private Color colorRow2;
        private Color colorRow3;

        #endregion


        public UCMachineStatics()
        {
            InitializeComponent();

            // Set color theme
            colorCaption = groupBox1.BackColor;
            colorRow2 = groupBox1.BackColor;
            colorRow3 = groupBox1.BackColor;

        }

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
        /// Set plc variable name - machine live time.
        /// </summary>
        /// <value>Plc variable name - machine live time.</value>
        [Description("Sets plc variable name - machine live time."), Category("App")]
        public string MachineLiveTime
        {
            get { return m_sMachineLiveTime; }
            set {
                    m_sMachineLiveTime = value;
                    lblMachineLiveTime.Text = m_sMachineLiveTime;
                }
        }

        /// <summary>
        /// Set plc variable name - total counter.
        /// </summary>
        /// <value>Plc variable name - total counter.</value>
        [Description("Sets plc variable name - total counter."), Category("App")]
        public string TotalCounter
        {
            get { return m_sTotalCounter; }
            set
            {
                m_sTotalCounter = value;
                lblTotalCounter.Text = m_sTotalCounter;
            }
        }

        /// <summary>
        /// Set plc variable name - counter part ok.
        /// </summary>
        /// <value>Plc variable name - counter part ok.</value>
        [Description("Sets plc variable name - counter part ok."), Category("App")]
        public string CounterPartOK
        {
            get { return m_sCounterPartOK; }
            set
            {
                m_sCounterPartOK = value;
                lblCounterPartOK.Text = m_sCounterPartOK;
            }
        }

        /// <summary>
        /// Set plc variable name - counter part nok.
        /// </summary>
        /// <value>Plc variable name - counter part nok.</value>
        [Description("Sets plc variable name - counter part nok."), Category("App")]
        public string CounterPartNOK
        {
            get { return m_sCounterPartNOK; }
            set
            {
                m_sCounterPartNOK = value;
                lblCounterPartNOK.Text = m_sCounterPartNOK;
            }
        }

        #endregion

        #region Events

        #region Form Events

        private void UCMachineStatics_Load(object sender, EventArgs e)
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

        #region Private methods

        private void LoadLanguageStrings()
        {
            if (this.lm != null)
            {
                this.lblMachineLive.Text = lm["UCMachineStatics.lblMachineLive"];
                this.lblCounter.Text = lm["UCMachineStatics.lblCounter"];
                this.lblCounterOK.Text = lm["UCMachineStatics.lblCounterOK"];
                this.lblCounterNOK.Text = lm["UCMachineStatics.lblCounterNOK"];

            }
            else
            {
                this.lblMachineLive.Text = "Machine live:";
                this.lblCounter.Text = "Counter:";
                this.lblCounterOK.Text = "Counter OK:";
                this.lblCounterNOK.Text = "Counter NOK:";

            }
        }

        #endregion
    }
}
