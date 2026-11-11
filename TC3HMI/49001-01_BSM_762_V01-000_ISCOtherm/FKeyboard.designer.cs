namespace App
{
    using System;

    partial class FKeyboard : IDisposable
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

        ~FKeyboard()
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
            this.label1 = new System.Windows.Forms.Label();
            this.btnShift = new App.Components.CVisuButton();
            this.btnSpace = new App.Components.CVisuButton();
            this.btnc = new App.Components.CVisuButton();
            this.btnx = new App.Components.CVisuButton();
            this.btnz = new App.Components.CVisuButton();
            this.btnn = new App.Components.CVisuButton();
            this.btnb = new App.Components.CVisuButton();
            this.btnv = new App.Components.CVisuButton();
            this.btnm = new App.Components.CVisuButton();
            this.btnd = new App.Components.CVisuButton();
            this.btns = new App.Components.CVisuButton();
            this.btna = new App.Components.CVisuButton();
            this.btnh = new App.Components.CVisuButton();
            this.btng = new App.Components.CVisuButton();
            this.btnf = new App.Components.CVisuButton();
            this.btnl = new App.Components.CVisuButton();
            this.btnk = new App.Components.CVisuButton();
            this.btnj = new App.Components.CVisuButton();
            this.btnp = new App.Components.CVisuButton();
            this.btne = new App.Components.CVisuButton();
            this.btnw = new App.Components.CVisuButton();
            this.btnq = new App.Components.CVisuButton();
            this.btny = new App.Components.CVisuButton();
            this.btnt = new App.Components.CVisuButton();
            this.btnr = new App.Components.CVisuButton();
            this.btno = new App.Components.CVisuButton();
            this.btni = new App.Components.CVisuButton();
            this.btnu = new App.Components.CVisuButton();
            this.btnBack = new App.Components.CVisuButton();
            this.btn_ = new App.Components.CVisuButton();
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
            this.btnEnter = new App.Components.CVisuButton();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(6, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 20);
            this.label1.Text = "label1";
            // 
            // btnShift
            // 
            this.btnShift.BackgroundImage = null;
            this.btnShift.Location = new System.Drawing.Point(6, 245);
            this.btnShift.Name = "btnShift";
            this.btnShift.Size = new System.Drawing.Size(134, 50);
            this.btnShift.TabIndex = 51;
            this.btnShift.TabStop = false;
            this.btnShift.Text = "shift";
            this.btnShift.Click += new System.EventHandler(this.Shift_Click);
            // 
            // btnSpace
            // 
            this.btnSpace.BackgroundImage = null;
            this.btnSpace.Location = new System.Drawing.Point(174, 301);
            this.btnSpace.Name = "btnSpace";
            this.btnSpace.Size = new System.Drawing.Size(329, 50);
            this.btnSpace.TabIndex = 49;
            this.btnSpace.TabStop = false;
            this.btnSpace.Text = "space";
            this.btnSpace.Click += new System.EventHandler(this.CapitalButton_Click);
            // 
            // btnc
            // 
            this.btnc.BackgroundImage = null;
            this.btnc.Location = new System.Drawing.Point(258, 245);
            this.btnc.Name = "btnc";
            this.btnc.Size = new System.Drawing.Size(50, 50);
            this.btnc.TabIndex = 48;
            this.btnc.TabStop = false;
            this.btnc.Text = "c";
            this.btnc.Click += new System.EventHandler(this.CapitalButton_Click);
            // 
            // btnx
            // 
            this.btnx.BackgroundImage = null;
            this.btnx.Location = new System.Drawing.Point(202, 245);
            this.btnx.Name = "btnx";
            this.btnx.Size = new System.Drawing.Size(50, 50);
            this.btnx.TabIndex = 47;
            this.btnx.TabStop = false;
            this.btnx.Text = "x";
            this.btnx.Click += new System.EventHandler(this.CapitalButton_Click);
            // 
            // btnz
            // 
            this.btnz.BackgroundImage = null;
            this.btnz.Location = new System.Drawing.Point(146, 245);
            this.btnz.Name = "btnz";
            this.btnz.Size = new System.Drawing.Size(50, 50);
            this.btnz.TabIndex = 45;
            this.btnz.TabStop = false;
            this.btnz.Text = "z";
            this.btnz.Click += new System.EventHandler(this.CapitalButton_Click);
            // 
            // btnn
            // 
            this.btnn.BackgroundImage = null;
            this.btnn.Location = new System.Drawing.Point(426, 245);
            this.btnn.Name = "btnn";
            this.btnn.Size = new System.Drawing.Size(50, 50);
            this.btnn.TabIndex = 46;
            this.btnn.TabStop = false;
            this.btnn.Text = "n";
            this.btnn.Click += new System.EventHandler(this.CapitalButton_Click);
            // 
            // btnb
            // 
            this.btnb.BackgroundImage = null;
            this.btnb.Location = new System.Drawing.Point(370, 245);
            this.btnb.Name = "btnb";
            this.btnb.Size = new System.Drawing.Size(50, 50);
            this.btnb.TabIndex = 44;
            this.btnb.TabStop = false;
            this.btnb.Text = "b";
            this.btnb.Click += new System.EventHandler(this.CapitalButton_Click);
            // 
            // btnv
            // 
            this.btnv.BackgroundImage = null;
            this.btnv.Location = new System.Drawing.Point(314, 245);
            this.btnv.Name = "btnv";
            this.btnv.Size = new System.Drawing.Size(50, 50);
            this.btnv.TabIndex = 43;
            this.btnv.TabStop = false;
            this.btnv.Text = "v";
            this.btnv.Click += new System.EventHandler(this.CapitalButton_Click);
            // 
            // btnm
            // 
            this.btnm.BackgroundImage = null;
            this.btnm.Location = new System.Drawing.Point(482, 245);
            this.btnm.Name = "btnm";
            this.btnm.Size = new System.Drawing.Size(50, 50);
            this.btnm.TabIndex = 42;
            this.btnm.TabStop = false;
            this.btnm.Text = "m";
            this.btnm.Click += new System.EventHandler(this.CapitalButton_Click);
            // 
            // btnd
            // 
            this.btnd.BackgroundImage = null;
            this.btnd.Location = new System.Drawing.Point(230, 189);
            this.btnd.Name = "btnd";
            this.btnd.Size = new System.Drawing.Size(50, 50);
            this.btnd.TabIndex = 41;
            this.btnd.TabStop = false;
            this.btnd.Text = "d";
            this.btnd.Click += new System.EventHandler(this.CapitalButton_Click);
            // 
            // btns
            // 
            this.btns.BackgroundImage = null;
            this.btns.Location = new System.Drawing.Point(174, 189);
            this.btns.Name = "btns";
            this.btns.Size = new System.Drawing.Size(50, 50);
            this.btns.TabIndex = 40;
            this.btns.TabStop = false;
            this.btns.Text = "s";
            this.btns.Click += new System.EventHandler(this.CapitalButton_Click);
            // 
            // btna
            // 
            this.btna.BackgroundImage = null;
            this.btna.Location = new System.Drawing.Point(118, 189);
            this.btna.Name = "btna";
            this.btna.Size = new System.Drawing.Size(50, 50);
            this.btna.TabIndex = 38;
            this.btna.TabStop = false;
            this.btna.Text = "a";
            this.btna.Click += new System.EventHandler(this.CapitalButton_Click);
            // 
            // btnh
            // 
            this.btnh.BackgroundImage = null;
            this.btnh.Location = new System.Drawing.Point(398, 189);
            this.btnh.Name = "btnh";
            this.btnh.Size = new System.Drawing.Size(50, 50);
            this.btnh.TabIndex = 39;
            this.btnh.TabStop = false;
            this.btnh.Text = "h";
            this.btnh.Click += new System.EventHandler(this.CapitalButton_Click);
            // 
            // btng
            // 
            this.btng.BackgroundImage = null;
            this.btng.Location = new System.Drawing.Point(342, 189);
            this.btng.Name = "btng";
            this.btng.Size = new System.Drawing.Size(50, 50);
            this.btng.TabIndex = 37;
            this.btng.TabStop = false;
            this.btng.Text = "g";
            this.btng.Click += new System.EventHandler(this.CapitalButton_Click);
            // 
            // btnf
            // 
            this.btnf.BackgroundImage = null;
            this.btnf.Location = new System.Drawing.Point(286, 189);
            this.btnf.Name = "btnf";
            this.btnf.Size = new System.Drawing.Size(50, 50);
            this.btnf.TabIndex = 36;
            this.btnf.TabStop = false;
            this.btnf.Text = "f";
            this.btnf.Click += new System.EventHandler(this.CapitalButton_Click);
            // 
            // btnl
            // 
            this.btnl.BackgroundImage = null;
            this.btnl.Location = new System.Drawing.Point(564, 189);
            this.btnl.Name = "btnl";
            this.btnl.Size = new System.Drawing.Size(50, 50);
            this.btnl.TabIndex = 35;
            this.btnl.TabStop = false;
            this.btnl.Text = "l";
            this.btnl.Click += new System.EventHandler(this.CapitalButton_Click);
            // 
            // btnk
            // 
            this.btnk.BackgroundImage = null;
            this.btnk.Location = new System.Drawing.Point(509, 189);
            this.btnk.Name = "btnk";
            this.btnk.Size = new System.Drawing.Size(50, 50);
            this.btnk.TabIndex = 34;
            this.btnk.TabStop = false;
            this.btnk.Text = "k";
            this.btnk.Click += new System.EventHandler(this.CapitalButton_Click);
            // 
            // btnj
            // 
            this.btnj.BackgroundImage = null;
            this.btnj.Location = new System.Drawing.Point(454, 189);
            this.btnj.Name = "btnj";
            this.btnj.Size = new System.Drawing.Size(50, 50);
            this.btnj.TabIndex = 33;
            this.btnj.TabStop = false;
            this.btnj.Text = "j";
            this.btnj.Click += new System.EventHandler(this.CapitalButton_Click);
            // 
            // btnp
            // 
            this.btnp.BackgroundImage = null;
            this.btnp.Location = new System.Drawing.Point(592, 132);
            this.btnp.Name = "btnp";
            this.btnp.Size = new System.Drawing.Size(50, 50);
            this.btnp.TabIndex = 32;
            this.btnp.TabStop = false;
            this.btnp.Text = "p";
            this.btnp.Click += new System.EventHandler(this.CapitalButton_Click);
            // 
            // btne
            // 
            this.btne.BackgroundImage = null;
            this.btne.Location = new System.Drawing.Point(202, 132);
            this.btne.Name = "btne";
            this.btne.Size = new System.Drawing.Size(50, 50);
            this.btne.TabIndex = 31;
            this.btne.TabStop = false;
            this.btne.Text = "e";
            this.btne.Click += new System.EventHandler(this.CapitalButton_Click);
            // 
            // btnw
            // 
            this.btnw.BackgroundImage = null;
            this.btnw.Location = new System.Drawing.Point(146, 132);
            this.btnw.Name = "btnw";
            this.btnw.Size = new System.Drawing.Size(50, 50);
            this.btnw.TabIndex = 30;
            this.btnw.TabStop = false;
            this.btnw.Text = "w";
            this.btnw.Click += new System.EventHandler(this.CapitalButton_Click);
            // 
            // btnq
            // 
            this.btnq.BackgroundImage = null;
            this.btnq.Location = new System.Drawing.Point(90, 132);
            this.btnq.Name = "btnq";
            this.btnq.Size = new System.Drawing.Size(50, 50);
            this.btnq.TabIndex = 28;
            this.btnq.TabStop = false;
            this.btnq.Text = "q";
            this.btnq.Click += new System.EventHandler(this.CapitalButton_Click);
            // 
            // btny
            // 
            this.btny.BackgroundImage = null;
            this.btny.Location = new System.Drawing.Point(370, 132);
            this.btny.Name = "btny";
            this.btny.Size = new System.Drawing.Size(50, 50);
            this.btny.TabIndex = 29;
            this.btny.TabStop = false;
            this.btny.Text = "y";
            this.btny.Click += new System.EventHandler(this.CapitalButton_Click);
            // 
            // btnt
            // 
            this.btnt.BackgroundImage = null;
            this.btnt.Location = new System.Drawing.Point(314, 132);
            this.btnt.Name = "btnt";
            this.btnt.Size = new System.Drawing.Size(50, 50);
            this.btnt.TabIndex = 27;
            this.btnt.TabStop = false;
            this.btnt.Text = "t";
            this.btnt.Click += new System.EventHandler(this.CapitalButton_Click);
            // 
            // btnr
            // 
            this.btnr.BackgroundImage = null;
            this.btnr.Location = new System.Drawing.Point(258, 132);
            this.btnr.Name = "btnr";
            this.btnr.Size = new System.Drawing.Size(50, 50);
            this.btnr.TabIndex = 26;
            this.btnr.TabStop = false;
            this.btnr.Text = "r";
            this.btnr.Click += new System.EventHandler(this.CapitalButton_Click);
            // 
            // btno
            // 
            this.btno.BackgroundImage = null;
            this.btno.Location = new System.Drawing.Point(536, 132);
            this.btno.Name = "btno";
            this.btno.Size = new System.Drawing.Size(50, 50);
            this.btno.TabIndex = 25;
            this.btno.TabStop = false;
            this.btno.Text = "o";
            this.btno.Click += new System.EventHandler(this.CapitalButton_Click);
            // 
            // btni
            // 
            this.btni.BackgroundImage = null;
            this.btni.Location = new System.Drawing.Point(481, 132);
            this.btni.Name = "btni";
            this.btni.Size = new System.Drawing.Size(50, 50);
            this.btni.TabIndex = 24;
            this.btni.TabStop = false;
            this.btni.Text = "i";
            this.btni.Click += new System.EventHandler(this.CapitalButton_Click);
            // 
            // btnu
            // 
            this.btnu.BackgroundImage = null;
            this.btnu.Location = new System.Drawing.Point(426, 132);
            this.btnu.Name = "btnu";
            this.btnu.Size = new System.Drawing.Size(50, 50);
            this.btnu.TabIndex = 23;
            this.btnu.TabStop = false;
            this.btnu.Text = "u";
            this.btnu.Click += new System.EventHandler(this.CapitalButton_Click);
            // 
            // btnBack
            // 
            this.btnBack.BackgroundImage = null;
            this.btnBack.Location = new System.Drawing.Point(676, 75);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(50, 50);
            this.btnBack.TabIndex = 22;
            this.btnBack.TabStop = false;
            this.btnBack.Text = "bck";
            this.btnBack.Click += new System.EventHandler(this.BackspaceButton_Click);
            // 
            // btn_
            // 
            this.btn_.BackgroundImage = null;
            this.btn_.Location = new System.Drawing.Point(620, 75);
            this.btn_.Name = "btn_";
            this.btn_.Size = new System.Drawing.Size(50, 50);
            this.btn_.TabIndex = 21;
            this.btn_.TabStop = false;
            this.btn_.Text = "_";
            this.btn_.Click += new System.EventHandler(this.CapitalButton_Click);
            // 
            // btn0
            // 
            this.btn0.BackgroundImage = null;
            this.btn0.Location = new System.Drawing.Point(564, 75);
            this.btn0.Name = "btn0";
            this.btn0.Size = new System.Drawing.Size(50, 50);
            this.btn0.TabIndex = 19;
            this.btn0.TabStop = false;
            this.btn0.Text = "0";
            this.btn0.Click += new System.EventHandler(this.CapitalButton_Click);
            // 
            // btn3
            // 
            this.btn3.BackgroundImage = null;
            this.btn3.Location = new System.Drawing.Point(174, 75);
            this.btn3.Name = "btn3";
            this.btn3.Size = new System.Drawing.Size(50, 50);
            this.btn3.TabIndex = 18;
            this.btn3.TabStop = false;
            this.btn3.Text = "3";
            this.btn3.Click += new System.EventHandler(this.CapitalButton_Click);
            // 
            // btn2
            // 
            this.btn2.BackgroundImage = null;
            this.btn2.Location = new System.Drawing.Point(118, 75);
            this.btn2.Name = "btn2";
            this.btn2.Size = new System.Drawing.Size(50, 50);
            this.btn2.TabIndex = 17;
            this.btn2.TabStop = false;
            this.btn2.Text = "2";
            this.btn2.Click += new System.EventHandler(this.CapitalButton_Click);
            // 
            // btn1
            // 
            this.btn1.BackgroundImage = null;
            this.btn1.Location = new System.Drawing.Point(62, 75);
            this.btn1.Name = "btn1";
            this.btn1.Size = new System.Drawing.Size(50, 50);
            this.btn1.TabIndex = 15;
            this.btn1.TabStop = false;
            this.btn1.Text = "1";
            this.btn1.Click += new System.EventHandler(this.CapitalButton_Click);
            // 
            // btn6
            // 
            this.btn6.BackgroundImage = null;
            this.btn6.Location = new System.Drawing.Point(342, 75);
            this.btn6.Name = "btn6";
            this.btn6.Size = new System.Drawing.Size(50, 50);
            this.btn6.TabIndex = 16;
            this.btn6.TabStop = false;
            this.btn6.Text = "6";
            this.btn6.Click += new System.EventHandler(this.CapitalButton_Click);
            // 
            // btn5
            // 
            this.btn5.BackgroundImage = null;
            this.btn5.Location = new System.Drawing.Point(286, 75);
            this.btn5.Name = "btn5";
            this.btn5.Size = new System.Drawing.Size(50, 50);
            this.btn5.TabIndex = 14;
            this.btn5.TabStop = false;
            this.btn5.Text = "5";
            this.btn5.Click += new System.EventHandler(this.CapitalButton_Click);
            // 
            // btn4
            // 
            this.btn4.BackgroundImage = null;
            this.btn4.Location = new System.Drawing.Point(230, 75);
            this.btn4.Name = "btn4";
            this.btn4.Size = new System.Drawing.Size(50, 50);
            this.btn4.TabIndex = 13;
            this.btn4.TabStop = false;
            this.btn4.Text = "4";
            this.btn4.Click += new System.EventHandler(this.CapitalButton_Click);
            // 
            // btn9
            // 
            this.btn9.BackgroundImage = null;
            this.btn9.Location = new System.Drawing.Point(508, 75);
            this.btn9.Name = "btn9";
            this.btn9.Size = new System.Drawing.Size(50, 50);
            this.btn9.TabIndex = 12;
            this.btn9.TabStop = false;
            this.btn9.Text = "9";
            this.btn9.Click += new System.EventHandler(this.CapitalButton_Click);
            // 
            // btn8
            // 
            this.btn8.BackgroundImage = null;
            this.btn8.Location = new System.Drawing.Point(453, 75);
            this.btn8.Name = "btn8";
            this.btn8.Size = new System.Drawing.Size(50, 50);
            this.btn8.TabIndex = 11;
            this.btn8.TabStop = false;
            this.btn8.Text = "8";
            this.btn8.Click += new System.EventHandler(this.CapitalButton_Click);
            // 
            // btn7
            // 
            this.btn7.BackgroundImage = null;
            this.btn7.Location = new System.Drawing.Point(398, 75);
            this.btn7.Name = "btn7";
            this.btn7.Size = new System.Drawing.Size(50, 50);
            this.btn7.TabIndex = 10;
            this.btn7.TabStop = false;
            this.btn7.Text = "7";
            this.btn7.Click += new System.EventHandler(this.CapitalButton_Click);
            // 
            // tbxDisplay
            // 
            this.tbxDisplay.BackColor = System.Drawing.Color.White;
            this.tbxDisplay.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tbxDisplay.Font = new System.Drawing.Font("Tahoma", 20F, System.Drawing.FontStyle.Bold);
            this.tbxDisplay.Location = new System.Drawing.Point(118, 31);
            this.tbxDisplay.MaxLength = 10;
            this.tbxDisplay.Name = "tbxDisplay";
            this.tbxDisplay.Size = new System.Drawing.Size(496, 38);
            this.tbxDisplay.TabIndex = 0;
            this.tbxDisplay.TabStop = false;
            this.tbxDisplay.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // btnEsc
            // 
            this.btnEsc.BackgroundImage = null;
            this.btnEsc.Location = new System.Drawing.Point(6, 75);
            this.btnEsc.Name = "btnEsc";
            this.btnEsc.Size = new System.Drawing.Size(50, 50);
            this.btnEsc.TabIndex = 53;
            this.btnEsc.TabStop = false;
            this.btnEsc.Text = "esc";
            // 
            // btnEnter
            // 
            this.btnEnter.BackgroundImage = null;
            this.btnEnter.Location = new System.Drawing.Point(620, 189);
            this.btnEnter.Name = "btnEnter";
            this.btnEnter.Size = new System.Drawing.Size(106, 50);
            this.btnEnter.TabIndex = 54;
            this.btnEnter.TabStop = false;
            this.btnEnter.Text = "enter";
            // 
            // FInputBox
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.ClientSize = new System.Drawing.Size(733, 356);
            this.Controls.Add(this.btnEnter);
            this.Controls.Add(this.btnEsc);
            this.Controls.Add(this.btnShift);
            this.Controls.Add(this.btnSpace);
            this.Controls.Add(this.btnc);
            this.Controls.Add(this.btnx);
            this.Controls.Add(this.btnz);
            this.Controls.Add(this.btnn);
            this.Controls.Add(this.btnb);
            this.Controls.Add(this.btnv);
            this.Controls.Add(this.btnm);
            this.Controls.Add(this.btnd);
            this.Controls.Add(this.btns);
            this.Controls.Add(this.btna);
            this.Controls.Add(this.btnh);
            this.Controls.Add(this.btng);
            this.Controls.Add(this.btnf);
            this.Controls.Add(this.btnl);
            this.Controls.Add(this.btnk);
            this.Controls.Add(this.btnj);
            this.Controls.Add(this.btnp);
            this.Controls.Add(this.btne);
            this.Controls.Add(this.btnw);
            this.Controls.Add(this.btnq);
            this.Controls.Add(this.btny);
            this.Controls.Add(this.btnt);
            this.Controls.Add(this.btnr);
            this.Controls.Add(this.btno);
            this.Controls.Add(this.btni);
            this.Controls.Add(this.btnu);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.btn_);
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
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tbxDisplay);
            this.Name = "FInputBox";
            this.Text = "FInputBox";
            this.Load += new System.EventHandler(this.FInputBox_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private App.Components.CVisuTextBox tbxDisplay;
        private System.Windows.Forms.Label label1;
        private App.Components.CVisuButton btn0;
        private App.Components.CVisuButton btn3;
        private App.Components.CVisuButton btn2;
        private App.Components.CVisuButton btn1;
        private App.Components.CVisuButton btn6;
        private App.Components.CVisuButton btn5;
        private App.Components.CVisuButton btn4;
        private App.Components.CVisuButton btn9;
        private App.Components.CVisuButton btn8;
        private App.Components.CVisuButton btn7;
        private App.Components.CVisuButton btn_;
        private App.Components.CVisuButton btnBack;
        private App.Components.CVisuButton btnp;
        private App.Components.CVisuButton btne;
        private App.Components.CVisuButton btnw;
        private App.Components.CVisuButton btnq;
        private App.Components.CVisuButton btny;
        private App.Components.CVisuButton btnt;
        private App.Components.CVisuButton btnr;
        private App.Components.CVisuButton btno;
        private App.Components.CVisuButton btni;
        private App.Components.CVisuButton btnu;
        private App.Components.CVisuButton btnd;
        private App.Components.CVisuButton btns;
        private App.Components.CVisuButton btna;
        private App.Components.CVisuButton btnh;
        private App.Components.CVisuButton btng;
        private App.Components.CVisuButton btnf;
        private App.Components.CVisuButton btnl;
        private App.Components.CVisuButton btnk;
        private App.Components.CVisuButton btnj;
        private App.Components.CVisuButton btnc;
        private App.Components.CVisuButton btnx;
        private App.Components.CVisuButton btnz;
        private App.Components.CVisuButton btnn;
        private App.Components.CVisuButton btnb;
        private App.Components.CVisuButton btnv;
        private App.Components.CVisuButton btnm;
        private App.Components.CVisuButton btnSpace;
        private App.Components.CVisuButton btnShift;
        private App.Components.CVisuButton btnEsc;
        private App.Components.CVisuButton btnEnter;
    }
}