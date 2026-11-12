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

    public partial class UCHeatingTemp : UserControl
    {

        #region Member enummerations

        #endregion

        #region Member variables

        // Application
        private FMainApp frmMainApp;
        private CLanguageManager lm;

        private string m_sActTempInside;
        private string m_sRefTempInside;
        private string m_sActTempOutside;
        private string m_sRefTempOutside;

        // Set color theme
        private Color colorCaption;
        private Color colorRow2;
        private Color colorRow3;

        #endregion

        #region Systemcode

        #region Constructor

        public UCHeatingTemp()
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
        /// Set plc variable name - actual temperature inside.
        /// </summary>
        /// <value>Plc variable name - actual temperature inside.</value>
        [Description("Sets plc variable name - actual temperature inside."), Category("App")]
        public string ActTempInside
        {
            get { return m_sActTempInside; }
            set {
                    m_sActTempInside = value;
                    lblActTempInside.Text = m_sActTempInside;
                }
        }

        /// <summary>
        /// Set plc variable name - reference temperature inside.
        /// </summary>
        /// <value>Plc variable name - reference temperature inside.</value>
        [Description("Sets plc variable name - reference temperature inside."), Category("App")]
        public string RefTempInside
        {
            get { return m_sRefTempInside; }
            set
            {
                m_sRefTempInside = value;
                lblRefTempInside.Text = m_sRefTempInside;
            }
        }


        /// <summary>
        /// Set plc variable name - actual temperature outside.
        /// </summary>
        /// <value>Plc variable name - actual temperature outside.</value>
        [Description("Sets plc variable name - actual temperature outside."), Category("App")]
        public string ActTempOutside
        {
            get { return m_sActTempOutside; }
            set
            {
                m_sActTempOutside = value;
                lblActTempOutside.Text = m_sActTempOutside;
            }
        }

        /// <summary>
        /// Set plc variable name - reference temperature outside.
        /// </summary>
        /// <value>Plc variable name - reference temperature outside.</value>
        [Description("Sets plc variable name - reference temperature outside."), Category("App")]
        public string RefTempOutside
        {
            get { return m_sRefTempOutside; }
            set
            {
                m_sRefTempOutside = value;
                lblRefTempOutside.Text = m_sRefTempOutside;
            }
        }

        #endregion

        #region Events

        #region Form Events

        private void UCHeatingTemp_Load(object sender, EventArgs e)
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
                this.lblHeatingInside.Text = lm["UCHeatingTemp.lblHeatingInside"];
                this.lblHeatingOutside.Text = lm["UCHeatingTemp.lblHeatingOutside"];
            }
            else
            {
                this.lblHeatingInside.Text = "Heating Inside:";
                this.lblHeatingOutside.Text = "Heating Outside:";
            }
        }

        #endregion

    }
}
