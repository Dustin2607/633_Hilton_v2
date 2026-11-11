namespace App
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Text;
    using System.Windows.Forms;

    using TwinCAT.Ads;
    using App.Utility;
    using App.Components;

    public partial class FNumPad : Form
    {
        #region Member enummerations

        #endregion

        #region Member variables

        // Application
        private FMainApp frmMainApp;

        private int m_nVarType;
        private string m_sVarName;
        private string m_sVarInfo;
        private string m_sVarUnit;
        private string m_sVarDefault;

        private bool m_bInchOn;

        private bool m_bUseMinMax;
        private string m_sMinLimit;
        private string m_sMaxLimit;

        private ushort m_unDisplayLenght = 0;
        private double m_dVariableValue = 0.0;

        private bool m_btbxCleared;

        #endregion

        #region Systemcode

        #region Constructor

        /// <summary>
        /// Constructor FNumPad.
        /// </summary>
        public FNumPad()
        {
            InitializeComponent();

            m_unDisplayLenght = 20;

            SetFormStyle(this);
        }

        #endregion

        #endregion

        #region Properties

        /// <summary>
        /// PLC variable type: int  - 1; double (long real) - 2; string - 3,
        /// float (real) - 4; uint (udint, uint) - 5;
        /// </summary>
	    public int VarType
	    {
            get { return m_nVarType; }
            set { m_nVarType = value; }
	    }

        /// <summary>
        /// Variable name in PLC!
        /// </summary>
        public string PLCVarName
        {
            get { return m_sVarName; }
            set { m_sVarName = value; }
        }

        /// <summary>
        /// Variable info
        /// </summary>
        public string VarInfo
        {
            get { return m_sVarInfo; }
            set { m_sVarInfo = value; }
        }

        /// <summary>
        /// Variable unit
        /// </summary>
        public string VarUnit
        {
            get { return m_sVarUnit; }
            set { m_sVarUnit = value; }
        }

        /// <summary>
        /// Variable min limit.
        /// </summary>
        public string VarMinLimit
        {
            get { return m_sMinLimit; }
            set {m_sMinLimit = value; }
        }

        /// <summary>
        /// Variable max limit.
        /// </summary>
        public string VarMaxLimit
        {
            get { return m_sMaxLimit; }
            set { m_sMaxLimit = value; }
        }

        /// <summary>
        /// Variable InchOn.
        /// </summary>
        public bool InchOn
        {
            get { return m_bInchOn; }
            set { m_bInchOn = value; }
        }


        #endregion

        #region User interface

        #endregion

        #region Events

        #region Form Events

        private void FNumPad_Activated(object sender, EventArgs e)
        {
            //ChkLimts();
        }

        private void FNumPad_Load(object sender, EventArgs e)
        {
            frmMainApp = CMainApp.GetMainAppForm();

            lblVarInfo.Text = m_sVarInfo;
            lblVarUnit.Text = m_sVarUnit;
            lblVarDefault.Text = m_sVarDefault;

            if (m_sMinLimit == String.Empty || m_sMaxLimit == String.Empty)
            {
                m_bUseMinMax = false;
                lblMinValue.Visible = false;
                lblMaxValue.Visible = false;

            }
            else
            {
                m_bUseMinMax = true;
                lblMinValue.Visible = true;
                lblMaxValue.Visible = true;
                lblMinValue.Text = m_sMinLimit;
                lblMaxValue.Text = m_sMaxLimit;
            }


            btnOk.Enabled = true;
        }

        private void FNumPad_Closing(object sender, CancelEventArgs e)
        {
            if (this.DialogResult == DialogResult.Cancel)
                tbxDisplay.Text = "";
        }

        #endregion

        #region Object Events

        private void NumberButton_Click(object oSender, EventArgs eEventArgs)
        {
            CVisuButton oButton = (CVisuButton)oSender;

            if (m_unDisplayLenght == tbxDisplay.Text.Length)
            {
                return;

            }
            else if ((1 == tbxDisplay.Text.Length)
                    && ("0" == tbxDisplay.Text)
                    && ("0" == (oButton.Text).ToString()))
            {
                return;

            }

            if (!m_btbxCleared)
            {
                tbxDisplay.Text = string.Empty;
                m_btbxCleared = true;
            }

            tbxDisplay.Text += oButton.Text;
        }

        private void CommaButton_Click(object oSender, EventArgs eventArgs)
        {
            if (0 == tbxDisplay.Text.Length)
            {
                tbxDisplay.Text += "0";

            }
            else if ((1 == tbxDisplay.Text.Length)
                    && ("-" == tbxDisplay.Text))
            {
                tbxDisplay.Text += "0";

            }
            else if (m_nVarType == 1)
            {
                return;
            }
            else if (tbxDisplay.Text.Contains("."))
            {
                return;

            }

            m_btbxCleared = true;

            tbxDisplay.Text += ".";
        }

        private void ClearButton_Click(object oSender, EventArgs eRoutedEventArgs)
        {
            tbxDisplay.Text = string.Empty;
        }

        private void SignButton_Click(object oSender, EventArgs eRoutedEventArgs)
        {
            if (tbxDisplay.Text.StartsWith("-"))
            {
                tbxDisplay.Text = tbxDisplay.Text.Replace("-", string.Empty);

                return;

            }
            else if (m_nVarType == 1)
            {
                return;
            }

            m_btbxCleared = true;

            tbxDisplay.Text = "-" + tbxDisplay.Text;

        }

        private void BackspaceButton_Click(object oSender, EventArgs eRoutedEventArgs)
        {
            if (0 == tbxDisplay.Text.Length)
            {
                return;

            }

            m_btbxCleared = true;

            tbxDisplay.Text = tbxDisplay.Text.Substring(0, tbxDisplay.Text.Length - 1);

        }

        private void OkButton_Click(object oSender, EventArgs eRoutedEventArgs)
        {
            if (string.IsNullOrEmpty(tbxDisplay.Text))
            {
                return;
            }
            //else if (m_sVarEntry == tbxDisplay.Text)
            //{
            //    return;
            //}
            else if ((1 == tbxDisplay.Text.Length)
                    && (("-" == tbxDisplay.Text) || ("." == tbxDisplay.Text)))
            {
                return;

            }

            this.Close();

        }

        private void Esc_Click(object sender, EventArgs eRoutedEventArgs)
        {
            tbxDisplay.Text = "";
            this.Close();
        }

        private void tbxDisplay_TextChanged(object sender, EventArgs e)
        {
            ChkLimts();
        }

        protected override void OnClosed(EventArgs e)
        {
            base.OnClosed(e);

            this.m_btbxCleared = false;
        }

        #endregion

        #endregion

        #region Interface implementation

        #endregion

        #region Public functions

        public DialogResult Show(ref string value)
        {
            return Show(String.Empty, ref value);
        }

        public DialogResult Show(string title, ref string value)
        {
            return Show(title, ref value, null);
        }

        public DialogResult Show(string title, ref string value, InputBoxValidation validation)
        {
            this.Text = title;
            this.m_sVarDefault = value;
            this.tbxDisplay.Text = value;

            if (validation != null)
            {
                this.FormClosing += delegate(object sender, FormClosingEventArgs e)
                {
                    if (this.DialogResult == DialogResult.OK)
                    {
                        string errorText = validation(tbxDisplay.Text);
                        if (e.Cancel = (errorText != ""))
                        {
                            MessageBox.Show(this, errorText, "Error",
                                            MessageBoxButtons.OK,
                                            MessageBoxIcon.Exclamation,
                                            MessageBoxDefaultButton.Button1);

                            tbxDisplay.Focus();
                        }
                    }
                };
            }

            DialogResult dialogResult = this.ShowDialog();

            value = tbxDisplay.Text;

            return dialogResult;

        }

        #endregion
        
        #region Private methods

        private void SetFormStyle(Form form)
        {
            btnOk.Text = "ok";
            btnEsc.Text = "Esc";
            btnOk.DialogResult = DialogResult.OK;
            btnEsc.DialogResult = DialogResult.Cancel;

            //label1.AutoSize = true;
            tbxDisplay.Anchor = tbxDisplay.Anchor | AnchorStyles.Right;
            btnOk.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnEsc.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;

            form.ShowInTaskbar = false;
            form.MaximizeBox = false;
            form.MinimizeBox = false;
            form.StartPosition = FormStartPosition.CenterParent;
            form.FormBorderStyle = FormBorderStyle.FixedDialog;
            form.AcceptButton = btnOk;
            form.CancelButton = btnEsc;
            form.TopMost = true;
        }

        /// <summary>
        /// Method to check limits
        /// </summary>
        private void ChkLimts()
        {
            lblMaxValue.BackColor = Color.Silver;
            lblMinValue.BackColor = Color.Silver;

            if (string.IsNullOrEmpty(tbxDisplay.Text))
            {
                return;
            }

            btnOk.Enabled = false;

            switch (m_nVarType)
            {
                case 1:
                    // PLC variable int type
                    try
                    {
                        var CurrentValue = Convert.ToInt16(tbxDisplay.Text);

                        if (m_bUseMinMax)
                        {
                            var MinLimit = Convert.ToInt16(m_sMinLimit);
                            var MaxLimit = Convert.ToInt16(m_sMaxLimit);

                            // Limits background color
                            if (CurrentValue < MinLimit)
                            {
                                lblMinValue.BackColor = Color.Yellow;
                                lblMaxValue.BackColor = Color.Silver;
                            }

                            if (CurrentValue > MaxLimit)
                            {
                                lblMaxValue.BackColor = Color.Yellow;
                                lblMinValue.BackColor = Color.Silver;
                            }

                            // Ok button enable
                            if (CurrentValue >= MinLimit && CurrentValue <= MaxLimit)
                            {
                                btnOk.Enabled = true;
                            }
                        }
                        else
                            btnOk.Enabled = true;

                    }
                    catch
                    {

                    }

                    break;

                case 2:
                    // PLC variable dint type
                    try
                    {
                        var CurrentValue = Convert.ToInt32(tbxDisplay.Text);

                        if (m_bUseMinMax)
                        {
                            var MinLimit = Convert.ToInt32(m_sMinLimit);
                            var MaxLimit = Convert.ToInt32(m_sMaxLimit);

                            // Limits background color
                            if (CurrentValue < MinLimit)
                            {
                                lblMinValue.BackColor = Color.Yellow;
                                lblMaxValue.BackColor = Color.Silver;
                            }

                            if (CurrentValue > MaxLimit)
                            {
                                lblMaxValue.BackColor = Color.Yellow;
                                lblMinValue.BackColor = Color.Silver;
                            }

                            // Ok button enable
                            if (CurrentValue >= MinLimit && CurrentValue <= MaxLimit)
                            {
                                btnOk.Enabled = true;
                            }
                        }
                        else
                            btnOk.Enabled = true;

                    }
                    catch
                    {

                    }

                    break;

                case 3:
                    // Variable uint type
                    try
                    {
                        var CurrentValue =  Convert.ToUInt16(tbxDisplay.Text);

                        if (m_bUseMinMax)
                        {
                            var MinLimit = Convert.ToUInt16(m_sMinLimit);
                            var MaxLimit = Convert.ToUInt16(m_sMaxLimit);

                            // Limits background color
                            if (CurrentValue < MinLimit)
                            {
                                lblMinValue.BackColor = Color.Yellow;
                                lblMaxValue.BackColor = Color.Silver;
                            }

                            if (CurrentValue > MaxLimit)
                            {
                                lblMaxValue.BackColor = Color.Yellow;
                                lblMinValue.BackColor = Color.Silver;
                            }

                            // OK button enable
                            if (CurrentValue >= MinLimit && CurrentValue <= MaxLimit)
                            {
                                btnOk.Enabled = true;
                            }
                        }
                        else
                            btnOk.Enabled = true;

                    }
                    catch
                    {

                    }
                    break;

                case 4:
                    // Variable udint type
                    try
                    {
                        var CurrentValue = Convert.ToUInt32(tbxDisplay.Text);

                        if (m_bUseMinMax)
                        {
                            var MinLimit = Convert.ToUInt32(m_sMinLimit);
                            var MaxLimit = Convert.ToUInt32(m_sMaxLimit);

                            // Limits background color
                            if (CurrentValue < MinLimit)
                            {
                                lblMinValue.BackColor = Color.Yellow;
                                lblMaxValue.BackColor = Color.Silver;
                            }

                            if (CurrentValue > MaxLimit)
                            {
                                lblMaxValue.BackColor = Color.Yellow;
                                lblMinValue.BackColor = Color.Silver;
                            }

                            // OK button enable
                            if (CurrentValue >= MinLimit && CurrentValue <= MaxLimit)
                            {
                                btnOk.Enabled = true;
                            }
                        }
                        else
                            btnOk.Enabled = true;

                    }
                    catch
                    {

                    }
                    break;

                case 5:
                    // Variable real type
                    try
                    {
                        var CurrentValue = Convert.ToSingle(tbxDisplay.Text);   

                        if (m_bUseMinMax)
                        {
                            var MinLimit = Convert.ToSingle(m_sMinLimit);
                            var MaxLimit = Convert.ToSingle(m_sMaxLimit);

                            // Limits background color
                            if (CurrentValue < MinLimit)
                            {
                                lblMinValue.BackColor = Color.Yellow;
                                lblMaxValue.BackColor = Color.Silver;
                            }

                            if (CurrentValue > MaxLimit)
                            {
                                lblMaxValue.BackColor = Color.Yellow;
                                lblMinValue.BackColor = Color.Silver;
                            }

                            // OK button enable
                            if (CurrentValue >= MinLimit && CurrentValue <= MaxLimit)
                            {
                                btnOk.Enabled = true;
                            }
                        }
                        else
                            btnOk.Enabled = true;

                    }
                    catch
                    {

                    }
                    break;

                case 6:
                    // PLC variable long real type
                    try
                    {
                        var CurrentValue = Convert.ToDouble(tbxDisplay.Text);

                        if (m_bUseMinMax)
                        {
                            var MinLimit = Convert.ToDouble(m_sMinLimit);
                            var MaxLimit = Convert.ToDouble(m_sMaxLimit);

                            // Limits background color
                            if (CurrentValue < MinLimit)
                            {
                                lblMinValue.BackColor = Color.Yellow;
                                lblMaxValue.BackColor = Color.Silver;
                            }

                            if (CurrentValue > MaxLimit)
                            {
                                lblMaxValue.BackColor = Color.Yellow;
                                lblMinValue.BackColor = Color.Silver;
                            }

                            // OK button enable
                            if (CurrentValue >= MinLimit && CurrentValue <= MaxLimit)
                            {
                                btnOk.Enabled = true;
                            }
                        }
                        else
                            btnOk.Enabled = true;

                    }
                    catch
                    {
 
                    }
                    break;

                case 10:
                    // Variable string type
                    btnOk.Enabled = true;
                    
                    break;

                default:
                    break;

            }
      
        }

        #endregion

    }
}
