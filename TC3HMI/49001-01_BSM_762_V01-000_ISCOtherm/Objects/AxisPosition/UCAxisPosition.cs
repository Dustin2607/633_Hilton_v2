namespace App.Components
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Drawing;
    using System.Data;
    using System.Text;
    using System.Windows.Forms;

    using TwinCAT.Ads;
    using App.Utility;

    public partial class UCAxisPosition : UserControl
    {
        private CLanguageManager lm;

        private string[] arsAxisValue = new string[6];


        // Set color theme
        private Color colorCaption;
        private Color colorRow2;
        private Color colorRow3;

        public UCAxisPosition()
        {
            InitializeComponent();

            // Set color theme
            colorCaption = groupBox2_1.BackColor;
            colorRow2 = groupBox2_1.BackColor;
            colorRow3 = groupBox2_1.BackColor;

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
                groupBox2_1.BackColor = colorRow2;
                groupBox1_2.BackColor = colorRow2;
                groupBox1_1.BackColor = colorRow2;
                groupBox2_2.BackColor = colorRow2;
                groupBox3_1.BackColor = colorRow2;
                groupBox3_2.BackColor = colorRow2;
                groupBox6_2.BackColor = colorRow2;
                groupBox6_1.BackColor = colorRow2;
                groupBox5_2.BackColor = colorRow2;
                groupBox5_1.BackColor = colorRow2;
                groupBox4_2.BackColor = colorRow2;
                groupBox4_1.BackColor = colorRow2;
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
        /// Set current value - Axis 1.
        /// </summary>
        /// <value>Set current value - Axis 1.</value>
        [Description("Set current value - Axis 1."), Category("App")]
        public string Axis1Value
        {
            get { return arsAxisValue[0]; }
            set
            {
                arsAxisValue[0] = value;
                lblAxisPos[0].Text = CUtility.DoFormat(arsAxisValue[0]);
            }
        }

        /// <summary>
        /// Set current value - Axis 2.
        /// </summary>
        /// <value>Set current value - Axis 2.</value>
        [Description("Set current value - Axis 2."), Category("App")]
        public string Axis2Value
        {
            get { return arsAxisValue[1]; }
            set
            {
                arsAxisValue[1] = value;
                lblAxisPos[1].Text = CUtility.DoFormat(arsAxisValue[1]);
            }
        }

        /// <summary>
        /// Set current value - Axis 3.
        /// </summary>
        /// <value>Set current value - Axis 3.</value>
        [Description("Set current value - Axis 3."), Category("App")]
        public string Axis3Value
        {
            get { return arsAxisValue[2]; }
            set
            {
                arsAxisValue[2] = value;
                lblAxisPos[2].Text = CUtility.DoFormat(arsAxisValue[2]);
            }
        }

        /// <summary>
        /// Set current value - Axis 4.
        /// </summary>
        /// <value>Set current value - Axis 4.</value>
        [Description("Set current value - Axis 4."), Category("App")]
        public string Axis4Value
        {
            get { return arsAxisValue[3]; }
            set
            {
                arsAxisValue[3] = value;
                lblAxisPos[3].Text = CUtility.DoFormat(arsAxisValue[3]);
            }
        }

        /// <summary>
        /// Set current value - Axis 5.
        /// </summary>
        /// <value>Set current value - Axis 5.</value>
        [Description("Set current value - Axis 5."), Category("App")]
        public string Axis5Value
        {
            get { return arsAxisValue[4]; }
            set
            {
                arsAxisValue[4] = value;
                lblAxisPos[4].Text = CUtility.DoFormat(arsAxisValue[4]);
            }
        }

        /// <summary>
        /// Set current value - Axis 6.
        /// </summary>
        /// <value>Set current value - Axis 6.</value>
        [Description("Set current value - Axis 6."), Category("App")]
        public string Axis6Value
        {
            get { return arsAxisValue[5]; }
            set
            {
                arsAxisValue[5] = value;
                lblAxisPos[5].Text = CUtility.DoFormat(arsAxisValue[5]);
            }
        }

        #endregion

        private void UCAxisPosition_Load(object sender, EventArgs e)
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
                for (int idx = 0; idx < lblAxis.Length; idx++)
                {
                    this.lblAxis[idx].Text = lm["UCAxisPosition.Axis" + (idx + 1).ToString()];
                    this.lblAxisUnit[idx].Text = lm["UCAxisPosition.Axis" + (idx + 1).ToString() + ".Unit"];
                }

            }
            else
            {
                for (int idx = 0; idx < lblAxis.Length; idx++)
                {
                    this.lblAxis[idx].Text = "Axis" + idx.ToString();
                    this.lblAxisUnit[idx].Text = "[mm]";
                }

            }

        }

    }
}
