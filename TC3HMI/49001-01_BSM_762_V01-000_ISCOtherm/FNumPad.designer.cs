namespace App
{
    using System;

    partial class FNumPad : IDisposable
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        private bool m_bDisposed;

        public bool Disposed
        {
            get { return m_bDisposed; }
        }

        ~FNumPad()
        {
            Dispose(false);
        }

        #region IDisposable Members

        public void Dispose()  
        {  
            Dispose(true);

            // Use SupressFinalize in case a subclass of this type implements a finalizer.
            GC.SuppressFinalize(this);  
        }

        #endregion

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool isDisposing)
        {
            if (!this.m_bDisposed)
            {
                if (isDisposing)
                {
                    // Cleanup managed resources
                    DisposeManagedRessources();
                }

                //Cleanup unmanaged resources
                DisposeUnmanagedRessources();

                this.m_bDisposed = true;
            }

            // Call the base class's dispose
            base.Dispose(isDisposing);
        }

        private void DisposeManagedRessources()
        {
            // Cleanup managed resources
            if (components != null)
            {
                components.Dispose();
            }
        }

        private void DisposeUnmanagedRessources()
        {
            // Cleanup unmanaged resources

        } 

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblVarUnit = new System.Windows.Forms.Label();
            this.lblVarInfo = new System.Windows.Forms.Label();
            this.lblVarDefault = new System.Windows.Forms.Label();
            this.lblMinValue = new System.Windows.Forms.Label();
            this.lblMaxValue = new System.Windows.Forms.Label();
            this.btnSign = new App.Components.CVisuButton();
            this.btnOk = new App.Components.CVisuButton();
            this.btnBack = new App.Components.CVisuButton();
            this.btnClear = new App.Components.CVisuButton();
            this.btnComm = new App.Components.CVisuButton();
            this.btn0 = new App.Components.CVisuButton();
            this.btn3 = new App.Components.CVisuButton();
            this.btn2 = new App.Components.CVisuButton();
            this.btn1 = new App.Components.CVisuButton();
            this.btn6 = new App.Components.CVisuButton();
            this.btn5 = new App.Components.CVisuButton();
            this.btn4 = new App.Components.CVisuButton();
            this.btn9 = new App.Components.CVisuButton();
            this.btn8 = new App.Components.CVisuButton();
            this.btn7 = new App.Components.CVisuButton();
            this.tbxDisplay = new App.Components.CVisuTextBox();
            this.btnEsc = new App.Components.CVisuButton();
            this.SuspendLayout();
            // 
            // lblVarUnit
            // 
            this.lblVarUnit.Location = new System.Drawing.Point(98, 72);
            this.lblVarUnit.Name = "lblVarUnit";
            this.lblVarUnit.Size = new System.Drawing.Size(51, 17);
            this.lblVarUnit.TabIndex = 20;
            this.lblVarUnit.Text = "varunit";
            // 
            // lblVarInfo
            // 
            this.lblVarInfo.Location = new System.Drawing.Point(6, 5);
            this.lblVarInfo.Name = "lblVarInfo";
            this.lblVarInfo.Size = new System.Drawing.Size(234, 17);
            this.lblVarInfo.TabIndex = 19;
            this.lblVarInfo.Text = "varinfo";
            // 
            // lblVarDefault
            // 
            this.lblVarDefault.Location = new System.Drawing.Point(249, 5);
            this.lblVarDefault.Name = "lblVarDefault";
            this.lblVarDefault.Size = new System.Drawing.Size(71, 17);
            this.lblVarDefault.TabIndex = 18;
            this.lblVarDefault.Text = "vardefault";
            // 
            // lblMinValue
            // 
            this.lblMinValue.Location = new System.Drawing.Point(6, 72);
            this.lblMinValue.Name = "lblMinValue";
            this.lblMinValue.Size = new System.Drawing.Size(64, 17);
            this.lblMinValue.TabIndex = 17;
            this.lblMinValue.Text = "minvalue";
            // 
            // lblMaxValue
            // 
            this.lblMaxValue.Location = new System.Drawing.Point(176, 72);
            this.lblMaxValue.Name = "lblMaxValue";
            this.lblMaxValue.Size = new System.Drawing.Size(67, 17);
            this.lblMaxValue.TabIndex = 16;
            this.lblMaxValue.Text = "maxvalue";
            // 
            // btnSign
            // 
            this.btnSign.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSign.Location = new System.Drawing.Point(249, 287);
            this.btnSign.Name = "btnSign";
            this.btnSign.Size = new System.Drawing.Size(75, 58);
            this.btnSign.TabIndex = 14;
            this.btnSign.TabStop = false;
            this.btnSign.Text = "+/-";
            this.btnSign.Click += new System.EventHandler(this.SignButton_Click);
            // 
            // btnOk
            // 
            this.btnOk.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnOk.Location = new System.Drawing.Point(249, 223);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 58);
            this.btnOk.TabIndex = 13;
            this.btnOk.TabStop = false;
            this.btnOk.Text = "ok";
            this.btnOk.Click += new System.EventHandler(this.OkButton_Click);
            // 
            // btnBack
            // 
            this.btnBack.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnBack.Location = new System.Drawing.Point(249, 159);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(75, 58);
            this.btnBack.TabIndex = 12;
            this.btnBack.TabStop = false;
            this.btnBack.Text = "bck";
            this.btnBack.Click += new System.EventHandler(this.BackspaceButton_Click);
            // 
            // btnClear
            // 
            this.btnClear.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnClear.Location = new System.Drawing.Point(249, 95);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(75, 58);
            this.btnClear.TabIndex = 11;
            this.btnClear.TabStop = false;
            this.btnClear.Text = "C";
            this.btnClear.Click += new System.EventHandler(this.ClearButton_Click);
            // 
            // btnComm
            // 
            this.btnComm.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnComm.Location = new System.Drawing.Point(168, 287);
            this.btnComm.Name = "btnComm";
            this.btnComm.Size = new System.Drawing.Size(75, 58);
            this.btnComm.TabIndex = 10;
            this.btnComm.TabStop = false;
            this.btnComm.Text = ".";
            this.btnComm.Click += new System.EventHandler(this.CommaButton_Click);
            // 
            // btn0
            // 
            this.btn0.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn0.Location = new System.Drawing.Point(6, 287);
            this.btn0.Name = "btn0";
            this.btn0.Size = new System.Drawing.Size(156, 58);
            this.btn0.TabIndex = 9;
            this.btn0.TabStop = false;
            this.btn0.Text = "0";
            this.btn0.Click += new System.EventHandler(this.NumberButton_Click);
            // 
            // btn3
            // 
            this.btn3.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn3.Location = new System.Drawing.Point(168, 223);
            this.btn3.Name = "btn3";
            this.btn3.Size = new System.Drawing.Size(75, 58);
            this.btn3.TabIndex = 8;
            this.btn3.TabStop = false;
            this.btn3.Text = "3";
            this.btn3.Click += new System.EventHandler(this.NumberButton_Click);
            // 
            // btn2
            // 
            this.btn2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn2.Location = new System.Drawing.Point(87, 223);
            this.btn2.Name = "btn2";
            this.btn2.Size = new System.Drawing.Size(75, 58);
            this.btn2.TabIndex = 7;
            this.btn2.TabStop = false;
            this.btn2.Text = "2";
            this.btn2.Click += new System.EventHandler(this.NumberButton_Click);
            // 
            // btn1
            // 
            this.btn1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn1.Location = new System.Drawing.Point(6, 223);
            this.btn1.Name = "btn1";
            this.btn1.Size = new System.Drawing.Size(75, 58);
            this.btn1.TabIndex = 6;
            this.btn1.TabStop = false;
            this.btn1.Text = "1";
            this.btn1.Click += new System.EventHandler(this.NumberButton_Click);
            // 
            // btn6
            // 
            this.btn6.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn6.Location = new System.Drawing.Point(168, 159);
            this.btn6.Name = "btn6";
            this.btn6.Size = new System.Drawing.Size(75, 58);
            this.btn6.TabIndex = 6;
            this.btn6.TabStop = false;
            this.btn6.Text = "6";
            this.btn6.Click += new System.EventHandler(this.NumberButton_Click);
            // 
            // btn5
            // 
            this.btn5.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn5.Location = new System.Drawing.Point(87, 159);
            this.btn5.Name = "btn5";
            this.btn5.Size = new System.Drawing.Size(75, 58);
            this.btn5.TabIndex = 5;
            this.btn5.TabStop = false;
            this.btn5.Text = "5";
            this.btn5.Click += new System.EventHandler(this.NumberButton_Click);
            // 
            // btn4
            // 
            this.btn4.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn4.Location = new System.Drawing.Point(6, 159);
            this.btn4.Name = "btn4";
            this.btn4.Size = new System.Drawing.Size(75, 58);
            this.btn4.TabIndex = 4;
            this.btn4.TabStop = false;
            this.btn4.Text = "4";
            this.btn4.Click += new System.EventHandler(this.NumberButton_Click);
            // 
            // btn9
            // 
            this.btn9.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn9.Location = new System.Drawing.Point(168, 95);
            this.btn9.Name = "btn9";
            this.btn9.Size = new System.Drawing.Size(75, 58);
            this.btn9.TabIndex = 3;
            this.btn9.TabStop = false;
            this.btn9.Text = "9";
            this.btn9.Click += new System.EventHandler(this.NumberButton_Click);
            // 
            // btn8
            // 
            this.btn8.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn8.Location = new System.Drawing.Point(87, 95);
            this.btn8.Name = "btn8";
            this.btn8.Size = new System.Drawing.Size(75, 58);
            this.btn8.TabIndex = 2;
            this.btn8.TabStop = false;
            this.btn8.Text = "8";
            this.btn8.Click += new System.EventHandler(this.NumberButton_Click);
            // 
            // btn7
            // 
            this.btn7.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn7.Location = new System.Drawing.Point(6, 95);
            this.btn7.Name = "btn7";
            this.btn7.Size = new System.Drawing.Size(75, 58);
            this.btn7.TabIndex = 1;
            this.btn7.TabStop = false;
            this.btn7.Text = "7";
            this.btn7.Click += new System.EventHandler(this.NumberButton_Click);
            // 
            // tbxDisplay
            // 
            this.tbxDisplay.BackColor = System.Drawing.Color.White;
            this.tbxDisplay.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tbxDisplay.Cursor = System.Windows.Forms.Cursors.Hand;
            this.tbxDisplay.Font = new System.Drawing.Font("Tahoma", 20F, System.Drawing.FontStyle.Bold);
            this.tbxDisplay.Location = new System.Drawing.Point(6, 31);
            this.tbxDisplay.MaxLength = 10;
            this.tbxDisplay.Name = "tbxDisplay";
            this.tbxDisplay.ReadOnly = true;
            this.tbxDisplay.Size = new System.Drawing.Size(237, 41);
            this.tbxDisplay.TabIndex = 0;
            this.tbxDisplay.TabStop = false;
            this.tbxDisplay.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.tbxDisplay.TextChanged += new System.EventHandler(this.tbxDisplay_TextChanged);
            // 
            // btnEsc
            // 
            this.btnEsc.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnEsc.Location = new System.Drawing.Point(249, 31);
            this.btnEsc.Name = "btnEsc";
            this.btnEsc.Size = new System.Drawing.Size(75, 58);
            this.btnEsc.TabIndex = 15;
            this.btnEsc.TabStop = false;
            this.btnEsc.Text = "Esc";
            this.btnEsc.Click += new System.EventHandler(this.Esc_Click);
            // 
            // FNumPad
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.ClientSize = new System.Drawing.Size(331, 351);
            this.Controls.Add(this.btnEsc);
            this.Controls.Add(this.lblMaxValue);
            this.Controls.Add(this.lblMinValue);
            this.Controls.Add(this.lblVarDefault);
            this.Controls.Add(this.lblVarInfo);
            this.Controls.Add(this.lblVarUnit);
            this.Controls.Add(this.btnSign);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.btnComm);
            this.Controls.Add(this.btn0);
            this.Controls.Add(this.btn3);
            this.Controls.Add(this.btn2);
            this.Controls.Add(this.btn1);
            this.Controls.Add(this.btn6);
            this.Controls.Add(this.btn5);
            this.Controls.Add(this.btn4);
            this.Controls.Add(this.btn9);
            this.Controls.Add(this.btn8);
            this.Controls.Add(this.btn7);
            this.Controls.Add(this.tbxDisplay);
            this.Name = "FNumPad";
            this.Text = "FNumPad";
            this.Activated += new System.EventHandler(this.FNumPad_Activated);
            this.Closing += new System.ComponentModel.CancelEventHandler(this.FNumPad_Closing);
            this.Load += new System.EventHandler(this.FNumPad_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private App.Components.CVisuTextBox tbxDisplay;
        private App.Components.CVisuButton btn7;
        private App.Components.CVisuButton btn8;
        private App.Components.CVisuButton btn9;
        private App.Components.CVisuButton btn4;
        private App.Components.CVisuButton btn5;
        private App.Components.CVisuButton btn6;
        private App.Components.CVisuButton btn1;
        private App.Components.CVisuButton btn2;
        private App.Components.CVisuButton btn3;
        private App.Components.CVisuButton btn0;
        private App.Components.CVisuButton btnComm;
        private App.Components.CVisuButton btnClear;
        private App.Components.CVisuButton btnBack;
        private App.Components.CVisuButton btnOk;
        private App.Components.CVisuButton btnSign;
        private System.Windows.Forms.Label lblVarUnit;
        private System.Windows.Forms.Label lblVarInfo;
        private System.Windows.Forms.Label lblVarDefault;
        private System.Windows.Forms.Label lblMinValue;
        private System.Windows.Forms.Label lblMaxValue;
        private App.Components.CVisuButton btnEsc;
    }
}