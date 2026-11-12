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
    using App.Components;

    public partial class UCCurrentValue : UserControlBase
    {
        private string m_sActValueName;
        private string m_sActValue;
        private string m_sActValueUnit;

        // Application
        private CLanguageManager lm;

        // Set color theme
        private Color colorCaption;
        private Color colorRow2;
        private Color colorRow3;

        public UCCurrentValue()
        {
            InitializeComponent();

            // Set color theme
            //colorCaption = groupBox1.BackColor;
            //colorRow2 = groupBox1.BackColor;
            //colorRow3 = groupBox1.BackColor;
        }

        /// <summary>
        /// Gets / sets the backcolor of the caption.
        /// </summary>
        /// <value>The backcolor of the caption.</value>
        //[Description("Gets / sets the backcolor of the caption."), Category("App")]
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
        //[Description("The color / the second row."), Category("App")]
        public Color ColorRow2
        {
            get { return colorRow2; }
            set
            {
                colorRow2 = value;
                //groupBox1.BackColor = colorRow2;
                //groupBox2.BackColor = colorRow2;
                //groupBox3.BackColor = colorRow2;
                //groupBox4.BackColor = colorRow2;
                //groupBox5.BackColor = colorRow2;
            }
        }

        /// <summary>
        /// Gets / sets the color of the third row.
        /// </summary>
        /// <value>The color of the third row.</value>
        //[Description("Gets / sets the color of the third row."), Category("App")]
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
            set { this.lm = value; }
        }

        /// <summary>
        /// Set plc variable name - pipe diameter.
        /// </summary>
        /// <value>Plc variable name - pipe diameter.</value>
        [Description("Sets plc variable name - pipe diameter."), Category("App")]
        public string ActValueName
        {
            get { return m_sActValueName; }
            set {
                    m_sActValueName = value;
                    lblActValueName.Text = m_sActValueName;
                }
        }

        /// <summary>
        /// Set plc variable name - hole diameter.
        /// </summary>
        /// <value>Plc variable name - hole diameter.</value>
        [Description("Sets plc variable name - hole diameter."), Category("App")]
        public string ActValue
        {
            get { return m_sActValue; }
            set {
                    m_sActValue = value;
                    lblActValue.Text = m_sActValue;
                }
        }

        /// <summary>
        /// Actuale value align.
        /// </summary>
        /// <value>Actuale value align.</value>
        [Description("Sets text align."), Category("App")]
        public System.Drawing.ContentAlignment ActValueAlign
        {
            get { return this.lblActValue.TextAlign; }
            set { this.lblActValue.TextAlign = value; }
        }

        /// <summary>
        /// Set plc variable name - depth axis Z.
        /// </summary>
        /// <value>Plc variable name - depth axis Z.</value>
        [Description("Sets plc variable name - depth axis Z."), Category("App")]
        public string ActValueUnit
        {
            get { return m_sActValueUnit; }
            set {
                    m_sActValueUnit = value;
                    lblActValueUnit.Text = m_sActValueUnit;
                }
        }

        private void UCCurrentValue_Load(object sender, EventArgs e)
        {
            if (this.lm == null)
                return;
            this.lm.StringDel += new CLanguageManager.InitStringDelegate(this.LoadLanguageStrings);
            this.LoadLanguageStrings();
        }

        private void LoadLanguageStrings()
        {
            if (this.lm != null)
            {
                this.lblActValueName.Text = lm["UCCurrentValue." + m_sActValueName];
                this.lblActValueUnit.Text = lm["UCCurrentValue." + m_sActValueName + ".Unit"];
            }
            else
            {
                this.lblActValueName.Text = m_sActValueName;
                this.lblActValueUnit.Text = m_sActValueUnit;

            }

        }

    }
}
