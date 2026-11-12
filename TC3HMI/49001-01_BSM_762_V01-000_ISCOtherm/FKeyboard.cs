namespace App
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Text;
    using System.Windows.Forms;

    using App.Utility;
    using App.Components;

    public partial class FKeyboard : Form
    {
        #region Member enummerations

        #endregion

        #region Member variables

        // Application
        private FMainApp frmMainApp;

        private bool m_btbxCleared;
        private ushort m_unDisplayLenght = 0;

        #endregion

        #region Systemcode

        #region Constructor

        /// <summary>
        /// Constructor FInputBox.
        /// </summary>
        public FKeyboard()
        {
            InitializeComponent();

            m_unDisplayLenght = 20;

            SetFormStyle(this);
        }

        #endregion

        #endregion

        #region Properties


        #endregion

        #region User interface

        #endregion

        #region Events

        #region Form Events


        private void FInputBox_Load(object sender, EventArgs e)
        {
            frmMainApp = CMainApp.GetMainAppForm();

            CapitalToLower();
        }

        private void FInputBox_Closing(object sender, CancelEventArgs e)
        {
            //if (this.DialogResult == DialogResult.Cancel)
            //    tbxDisplay.Text = "";
        }

        #endregion

        #region Object Events

        private void CapitalButton_Click(object oSender, EventArgs eEventArgs)
        {
            CVisuButton oButton = (CVisuButton)oSender;

            if (m_unDisplayLenght == tbxDisplay.Text.Length)
            {
                return;

            }

            if (!m_btbxCleared)
            {
                tbxDisplay.Text = string.Empty;
                m_btbxCleared = true;
            }

            tbxDisplay.Text += oButton.Text;

            this.CapitalToLower();
        }

        private void BackspaceButton_Click(object oSender, EventArgs eRoutedEventArgs)
        {
            if (0 == tbxDisplay.Text.Length)
            {
                return;

            }

            this.m_btbxCleared = true;

            tbxDisplay.Text = tbxDisplay.Text.Substring(0, tbxDisplay.Text.Length - 1);

        }

        //private void EnterButton_Click(object oSender, EventArgs eRoutedEventArgs)
        //{
        //    if (string.IsNullOrEmpty(tbxDisplay.Text))
        //    {
        //        return;
        //    }

        //    this.Close();

        //}

        //private void Esc_Click(object sender, EventArgs eRoutedEventArgs)
        //{
        //    tbxDisplay.Text = "";
        //    this.Close();
        //}

        private void Shift_Click(object sender, EventArgs e)
        {
            this.CapitalToUpper();
        }

        protected override void OnClosed(EventArgs e)
        {
            base.OnClosed(e);

            this.CapitalToLower();
            this.m_btbxCleared = false;
        }

        #endregion

        #endregion

        #region Interface implementation

        #endregion

        #region Public functions

        public DialogResult Show(string title, string promptText, ref string value)
        {
            return Show(title, promptText, ref value, null);
        }

        public DialogResult Show(string title, string promptText, ref string value, InputBoxValidation validation)
        {
            this.Text = title;
            label1.Text = promptText;
            tbxDisplay.Text = value;

            if (validation != null)
            {
                this.Closing += delegate(object sender, CancelEventArgs e)
                {
                    if (this.DialogResult == DialogResult.OK)
                    {
                        string errorText = validation(tbxDisplay.Text);
                        if (e.Cancel = (errorText != ""))
                        {
                            MessageBox.Show(errorText, "Error",
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

        private void CapitalToUpper()
        {
            this.btnq.Text = "Q";
            this.btnw.Text = "W";
            this.btne.Text = "E";
            this.btnr.Text = "R";
            this.btnt.Text = "T";
            this.btny.Text = "Y";
            this.btnu.Text = "U";
            this.btni.Text = "I";
            this.btno.Text = "O";
            this.btnp.Text = "P";

            this.btna.Text = "A";
            this.btns.Text = "S";
            this.btnd.Text = "D";
            this.btnf.Text = "F";
            this.btng.Text = "G";
            this.btnh.Text = "H";
            this.btnj.Text = "J";
            this.btnk.Text = "K";
            this.btnl.Text = "L";

            this.btnz.Text = "Z";
            this.btnx.Text = "X";
            this.btnc.Text = "C";
            this.btnv.Text = "V";
            this.btnb.Text = "B";
            this.btnn.Text = "N";
            this.btnm.Text = "M";
        
        }

        private void CapitalToLower()
        {

            this.btnq.Text = "q";
            this.btnw.Text = "w";
            this.btne.Text = "e";
            this.btnr.Text = "r";
            this.btnt.Text = "t";
            this.btny.Text = "y";
            this.btnu.Text = "u";
            this.btni.Text = "i";
            this.btno.Text = "o";
            this.btnp.Text = "p";

            this.btna.Text = "a";
            this.btns.Text = "s"; 
            this.btnd.Text = "d";
            this.btnf.Text = "f";
            this.btng.Text = "g";
            this.btnh.Text = "h";
            this.btnj.Text = "j";
            this.btnk.Text = "k";
            this.btnl.Text = "l";

            this.btnz.Text = "z";
            this.btnx.Text = "x";
            this.btnc.Text = "c";
            this.btnv.Text = "v";
            this.btnb.Text = "b";
            this.btnn.Text = "n";
            this.btnm.Text = "m";
            
        }

        private void SetFormStyle(Form form)
        {
            tbxDisplay.ReadOnly = false;

            btnEnter.Text = "enter";
            btnEsc.Text = "esc";
            btnEnter.DialogResult = DialogResult.OK;
            btnEsc.DialogResult = DialogResult.Cancel;

            //label1.AutoSize = true;
            tbxDisplay.Anchor = tbxDisplay.Anchor | AnchorStyles.Right;
            btnEnter.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnEsc.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;

            form.ShowInTaskbar = false;
            form.MaximizeBox = false;
            form.MinimizeBox = false;
            form.StartPosition = FormStartPosition.CenterParent;
            form.FormBorderStyle = FormBorderStyle.FixedDialog;
            form.TopMost = true;
        }

        #endregion

    }
}

public delegate string InputBoxValidation(string errorMessage);
