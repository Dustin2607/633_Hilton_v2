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

    public partial class UCCurrentParameter : UserControl
    {
        private CLanguageManager lm;

        private string m_sPipeDiameter;
        private string m_sHoleDiameter;
        private string m_sDepthAxisZ;
        private string m_sHolePosAxisX;
        private string m_sHolePosAxisY;


        // Set color theme
        private Color colorCaption;
        private Color colorRow2;
        private Color colorRow3;

        public UCCurrentParameter()
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
            set { this.lm = value; }
        }

        /// <summary>
        /// Set plc variable name - pipe diameter.
        /// </summary>
        /// <value>Plc variable name - pipe diameter.</value>
        [Description("Sets plc variable name - pipe diameter."), Category("App")]
        public string PipeDiameter
        {
            get { return m_sPipeDiameter; }
            set {
                    m_sPipeDiameter = value;
                    lblPipeDiameter.Text = CUtility.DoFormat(m_sPipeDiameter);
                }
        }

        /// <summary>
        /// Set plc variable name - hole diameter.
        /// </summary>
        /// <value>Plc variable name - hole diameter.</value>
        [Description("Sets plc variable name - hole diameter."), Category("App")]
        public string HoleDiameter
        {
            get { return m_sHoleDiameter; }
            set {
                    m_sHoleDiameter = value;
                    lblHoleDiameter.Text = CUtility.DoFormat(m_sHoleDiameter);
                }
        }

        /// <summary>
        /// Set plc variable name - depth axis Z.
        /// </summary>
        /// <value>Plc variable name - depth axis Z.</value>
        [Description("Sets plc variable name - depth axis Z."), Category("App")]
        public string DepthAxisZ
        {
            get { return m_sDepthAxisZ; }
            set {
                    m_sDepthAxisZ = value;
                    lblDepthZ.Text = CUtility.DoFormat(m_sDepthAxisZ);
                }
        }

        /// <summary>
        /// Set plc variable name - hole positon axis X.
        /// </summary>
        /// <value>Plc variable name - hole positon axis X.</value>
        [Description("Sets plc variable name - hole positon axis X."), Category("App")]
        public string HolePosAxisX
        {
            get { return m_sHolePosAxisX; }
            set
            {
                m_sHolePosAxisX = value;
                lblHolePosX.Text = CUtility.DoFormat(m_sHolePosAxisX);
            }
        }

        /// <summary>
        /// Set plc variable name - hole positon axis Y.
        /// </summary>
        /// <value>Plc variable name - hole positon axis Y.</value>
        [Description("Sets plc variable name - hole positon axis Y."), Category("App")]
        public string HolePosAxisY
        {
            get { return m_sHolePosAxisY; }
            set
            {
                m_sHolePosAxisY = value;
                lblHolePosY.Text = CUtility.DoFormat(m_sHolePosAxisY);
            }
        }

        #endregion

    }
}
