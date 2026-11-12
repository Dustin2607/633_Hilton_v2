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

    public partial class UCWeldingPara2_2 : UserControlBase
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
        /// Constructor UCWeldingPara.
        /// </summary>
        public UCWeldingPara2_2()
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
            get { return tbxPara9.Text; }
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
        /// Gets / sets the parameter.
        /// </summary>
        /// <value>The parameter.</value>
        [Description("Gets / sets the parameter."), Category("App")]
        public string Para13
        {
            get { return this.tbxPara13.Text; }
            set { tbxPara13.Text = value; }
        }

        /// <summary>
        /// Gets / sets the parameter.
        /// </summary>
        /// <value>The parameter.</value>
        [Description("Gets / sets the parameter."), Category("App")]
        public string Para14
        {
            get { return this.tbxPara14.Text; }
            set { tbxPara14.Text = value; }
        }

        /// <summary>
        /// Gets / sets the parameter.
        /// </summary>
        /// <value>The parameter.</value>
        [Description("Gets / sets the parameter."), Category("App")]
        public string Para15
        {
            get { return this.tbxPara15.Text; }
            set { tbxPara15.Text = value; }
        }

        /// <summary>
        /// Gets / sets the parameter.
        /// </summary>
        /// <value>The parameter.</value>
        [Description("Gets / sets the parameter."), Category("App")]
        public string Para16
        {
            get { return this.tbxPara16.Text; }
            set { tbxPara16.Text = value; }
        }

        /// <summary>
        /// Gets / sets the parameter.
        /// </summary>
        /// <value>The parameter.</value>
        [Description("Gets / sets the parameter."), Category("App")]
        public string Para17
        {
            get { return this.tbxPara17.Text; }
            set { tbxPara17.Text = value; }
        }

        /// <summary>
        /// Gets / sets the parameter.
        /// </summary>
        /// <value>The parameter.</value>
        [Description("Gets / sets the parameter."), Category("App")]
        public string Para18
        {
            get { return this.tbxPara18.Text; }
            set { tbxPara18.Text = value; }
        }

        /// <summary>
        /// Gets / sets the parameter.
        /// </summary>
        /// <value>The parameter.</value>
        [Description("Gets / sets the parameter."), Category("App")]
        public string Para19
        {
            get { return this.tbxPara19.Text; }
            set { tbxPara19.Text = value; }
        }

        /// <summary>
        /// Gets / sets the parameter.
        /// </summary>
        /// <value>The parameter.</value>
        [Description("Gets / sets the parameter."), Category("App")]
        public string Para20
        {
            get { return this.tbxPara20.Text; }
            set { tbxPara20.Text = value; }
        }

        /// <summary>
        /// Gets / sets the parameter.
        /// </summary>
        /// <value>The parameter.</value>
        [Description("Gets / sets the parameter."), Category("App")]
        public string Para21
        {
            get { return this.tbxPara21.Text; }
            set { tbxPara21.Text = value; }
        }


        /// <summary>
        /// Gets / sets the parameter.
        /// </summary>
        /// <value>The parameter.</value>
        [Description("Gets / sets the parameter."), Category("App")]
        public string Para22
        {
            get { return this.tbxPara22.Text; }
            set { tbxPara22.Text = value; }
        }

        /// <summary>
        /// Gets / sets the parameter.
        /// </summary>
        /// <value>The parameter.</value>
        [Description("Gets / sets the parameter."), Category("App")]
        public string Para23
        {
            get { return this.tbxPara23.Text; }
            set { tbxPara23.Text = value; }
        }

        /// <summary>
        /// Gets / sets the parameter.
        /// </summary>
        /// <value>The parameter.</value>
        [Description("Gets / sets the parameter."), Category("App")]
        public string Para24
        {
            get { return this.tbxPara24.Text; }
            set { tbxPara24.Text = value; }
        }

        /// <summary>
        /// Gets / sets the parameter.
        /// </summary>
        /// <value>The parameter.</value>
        [Description("Gets / sets the parameter."), Category("App")]
        public string Para25
        {
            get { return this.tbxPara25.Text; }
            set { tbxPara25.Text = value; }
        }

        /// <summary>
        /// Gets / sets the parameter.
        /// </summary>
        /// <value>The parameter.</value>
        [Description("Gets / sets the parameter."), Category("App")]
        public string Para26
        {
            get { return this.tbxPara26.Text; }
            set { tbxPara26.Text = value; }
        }

        /// <summary>
        /// Gets / sets the parameter.
        /// </summary>
        /// <value>The parameter.</value>
        [Description("Gets / sets the parameter."), Category("App")]
        public string Para27
        {
            get { return this.tbxPara27.Text; }
            set { tbxPara27.Text = value; }
        }

        /// <summary>
        /// Gets / sets the parameter.
        /// </summary>
        /// <value>The parameter.</value>
        [Description("Gets / sets the parameter."), Category("App")]
        public string Para28
        {
            get { return this.tbxPara28.Text; }
            set { tbxPara28.Text = value; }
        }

        /// <summary>
        /// Gets / sets the parameter.
        /// </summary>
        /// <value>The parameter.</value>
        [Description("Gets / sets the parameter."), Category("App")]
        public string Para29
        {
            get { return this.tbxPara29.Text; }
            set { tbxPara29.Text = value; }
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
            this.tbxPara10.UserManager = um;
            this.tbxPara11.UserManager = um;
            this.tbxPara12.UserManager = um;
            this.tbxPara13.UserManager = um;
            this.tbxPara14.UserManager = um;
            this.tbxPara15.UserManager = um;
            this.tbxPara16.UserManager = um;
            this.tbxPara17.UserManager = um;
            this.tbxPara18.UserManager = um;
            this.tbxPara19.UserManager = um;
            this.tbxPara20.UserManager = um;
            this.tbxPara21.UserManager = um;
            this.tbxPara22.UserManager = um;
            this.tbxPara23.UserManager = um;
            this.tbxPara24.UserManager = um;
            this.tbxPara25.UserManager = um;
            this.tbxPara26.UserManager = um;
            this.tbxPara27.UserManager = um;
            this.tbxPara28.UserManager = um;
            this.tbxPara29.UserManager = um;
        }

        #endregion

        #region Private methods

        private void LoadLanguageStrings()
        {
            if (this.lm != null)
            {
                this.gbxWeldingPara.Text = lm["UCWeldingPara." + m_Name + ".gbxWeldingPara"];

                this.lblPara1.Text = lm["UCWeldingPara." + m_Name + ".lblPara1"];
                this.lblPara2.Text = lm["UCWeldingPara." + m_Name + ".lblPara2"];
                this.lblPara3.Text = lm["UCWeldingPara." + m_Name + ".lblPara3"];
                this.lblPara4.Text = lm["UCWeldingPara." + m_Name + ".lblPara4"];
                this.lblPara5.Text = lm["UCWeldingPara." + m_Name + ".lblPara5"];
                this.lblPara6.Text = lm["UCWeldingPara." + m_Name + ".lblPara6"];
                this.lblPara7.Text = lm["UCWeldingPara." + m_Name + ".lblPara7"];
                this.lblPara8.Text = lm["UCWeldingPara." + m_Name + ".lblPara8"];
                this.lblPara9.Text = lm["UCWeldingPara." + m_Name + ".lblPara9"];
                this.lblPara10.Text = lm["UCWeldingPara." + m_Name + ".lblPara10"];
                this.lblPara11.Text = lm["UCWeldingPara." + m_Name + ".lblPara11"];
                this.lblPara12.Text = lm["UCWeldingPara." + m_Name + ".lblPara12"];
                this.lblPara13.Text = lm["UCWeldingPara." + m_Name + ".lblPara13"];
                this.lblPara14.Text = lm["UCWeldingPara." + m_Name + ".lblPara14"];
                this.lblPara15.Text = lm["UCWeldingPara." + m_Name + ".lblPara15"];
                this.lblPara16.Text = lm["UCWeldingPara." + m_Name + ".lblPara16"];
                this.lblPara17.Text = lm["UCWeldingPara." + m_Name + ".lblPara17"];
                this.lblPara18.Text = lm["UCWeldingPara." + m_Name + ".lblPara18"];
                this.lblPara19.Text = lm["UCWeldingPara." + m_Name + ".lblPara19"];
                this.lblPara20.Text = lm["UCWeldingPara." + m_Name + ".lblPara20"];
                this.lblPara21.Text = lm["UCWeldingPara." + m_Name + ".lblPara21"];
                this.lblPara22.Text = lm["UCWeldingPara." + m_Name + ".lblPara22"];
                this.lblPara23.Text = lm["UCWeldingPara." + m_Name + ".lblPara23"];
                this.lblPara24.Text = lm["UCWeldingPara." + m_Name + ".lblPara24"];
                this.lblPara25.Text = lm["UCWeldingPara." + m_Name + ".lblPara25"];
                this.lblPara26.Text = lm["UCWeldingPara." + m_Name + ".lblPara26"];
                this.lblPara27.Text = lm["UCWeldingPara." + m_Name + ".lblPara27"];
                this.lblPara28.Text = lm["UCWeldingPara." + m_Name + ".lblPara28"];
                this.lblPara29.Text = lm["UCWeldingPara." + m_Name + ".lblPara29"];

                this.lbl11.Text = lm["UCWeldingPara." + m_Name + ".lbl11"];
                this.lbl12.Text = lm["UCWeldingPara." + m_Name + ".lbl12"];

            }
            else
            {
                this.gbxWeldingPara.Text = "Welding parameters";

                this.lblPara1.Text = "Preheat Time [s]:";

                this.lblPara2.Text = "Bead Up Ramp [s]:";
                this.lblPara3.Text = "Bead Up Force [N]";
                this.lblPara4.Text = "Bead Up Time [s]";

                this.lblPara5.Text = "Heat Up Ramp [s]:";
                this.lblPara6.Text = "Heat Up Force [N]:";
                this.lblPara7.Text = "Heat Up Time [s]:";

                this.lblPara8.Text = "Welding Ramp [s]:";
                this.lblPara9.Text = "Welding Force [N]:";
                this.lblPara10.Text = "Cool Down Time [s]:";

                this.lbl11.Text = "Time [s]";
                this.lbl12.Text = "Force [N]";
          
            }

        }

        #endregion

    }
}
