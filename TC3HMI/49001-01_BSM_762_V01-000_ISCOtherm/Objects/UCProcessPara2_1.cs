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

    public partial class UCProcessPara2_1 : UserControlBase
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
        public UCProcessPara2_1()
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
            this.tbxPara1.UserManager = um;
            this.tbxPara2.UserManager = um;
            this.tbxPara3.UserManager = um;
            this.tbxPara4.UserManager = um;
            this.tbxPara5.UserManager = um;
            this.tbxPara6.UserManager = um;
            this.tbxPara7.UserManager = um;
            this.tbxPara8.UserManager = um;
            this.tbxPara9.UserManager = um;
        }

        #endregion

        #region Private methods

        private void LoadLanguageStrings()
        {
            if (this.lm != null)
            {
                this.gbxProcessPara.Text = lm["UCProcessPara." + m_Name + ".gbxProcessPara"];

                this.lblPara1.Text = lm["UCProcessPara." + m_Name + ".lblPara1"];
                this.lblPara2.Text = lm["UCProcessPara." + m_Name + ".lblPara2"];
                this.lblPara3.Text = lm["UCProcessPara." + m_Name + ".lblPara3"];
                this.lblPara4.Text = lm["UCProcessPara." + m_Name + ".lblPara4"];

                this.lblPara5.Text = lm["UCProcessPara." + m_Name + ".lblPara5"];
                this.lblPara6.Text = lm["UCProcessPara." + m_Name + ".lblPara6"];
                this.lblPara7.Text = lm["UCProcessPara." + m_Name + ".lblPara7"];
                this.lblPara8.Text = lm["UCProcessPara." + m_Name + ".lblPara8"];
                this.lblPara9.Text = lm["UCProcessPara." + m_Name + ".lblPara9"];

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
                this.lblPara8.Text = "Para9:";

            }

        }

        #endregion

    }
}
