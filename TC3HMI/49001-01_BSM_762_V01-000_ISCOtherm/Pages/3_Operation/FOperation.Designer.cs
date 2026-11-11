namespace App
{
    using System;

    partial class FOperation : IDisposable
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

        ~FOperation()
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.tcOpModeKey = new TwinCAT.App.TcFKey();
            this.tcFKeyLeft = new TwinCAT.App.TcFKey();
            this.tcTypeKey = new TwinCAT.App.TcFKey();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackgroundImage = global::App.Properties.Resources.MainMashine_1024x572x8;
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1006, 721);
            this.panel1.TabIndex = 0;
            // 
            // tcOpModeKey
            // 
            this.tcOpModeKey.FKeyBtnBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(153)))), ((int)(((byte)(153)))));
            this.tcOpModeKey.FKeyBtnForeColor = System.Drawing.Color.White;
            this.tcOpModeKey.FKeyBtnSelectedColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(102)))), ((int)(((byte)(102)))));
            this.tcOpModeKey.FKeyFlatStyle = System.Windows.Forms.FlatStyle.Standard;
            this.tcOpModeKey.FKeyHorizontalDistanceLeft = 0;
            this.tcOpModeKey.FKeyHorizontalDistanceRight = 0;
            this.tcOpModeKey.FKeyImageAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.tcOpModeKey.FKeyLabelAlign = System.Drawing.ContentAlignment.TopLeft;
            this.tcOpModeKey.FKeyLabelBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(102)))), ((int)(((byte)(102)))));
            this.tcOpModeKey.FKeyLabelForeColor = System.Drawing.Color.WhiteSmoke;
            this.tcOpModeKey.FKeyLabelHeightRelation = 30;
            this.tcOpModeKey.FKeyLabelTextString = "F";
            this.tcOpModeKey.FKeyLabelWidthRelation = 0;
            this.tcOpModeKey.FKeyMax = 3;
            this.tcOpModeKey.FKeySelectedMode = false;
            this.tcOpModeKey.FKeyStyle = 4;
            this.tcOpModeKey.FKeyTextAlign = System.Drawing.ContentAlignment.BottomLeft;
            this.tcOpModeKey.FKeyVerticalDistance = 0;
            this.tcOpModeKey.Location = new System.Drawing.Point(207, 535);
            this.tcOpModeKey.Name = "tcOpModeKey";
            this.tcOpModeKey.Size = new System.Drawing.Size(150, 185);
            this.tcOpModeKey.TabIndex = 17;
            this.tcOpModeKey.Visible = false;
            // 
            // tcFKeyLeft
            // 
            this.tcFKeyLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.tcFKeyLeft.FKeyBtnBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(153)))), ((int)(((byte)(153)))));
            this.tcFKeyLeft.FKeyBtnForeColor = System.Drawing.Color.Transparent;
            this.tcFKeyLeft.FKeyBtnSelectedColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(102)))), ((int)(((byte)(102)))));
            this.tcFKeyLeft.FKeyFlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.tcFKeyLeft.FKeyHorizontalDistanceLeft = 0;
            this.tcFKeyLeft.FKeyHorizontalDistanceRight = 0;
            this.tcFKeyLeft.FKeyImageAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.tcFKeyLeft.FKeyLabelAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.tcFKeyLeft.FKeyLabelBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(102)))), ((int)(((byte)(102)))));
            this.tcFKeyLeft.FKeyLabelForeColor = System.Drawing.Color.White;
            this.tcFKeyLeft.FKeyLabelHeightRelation = 0;
            this.tcFKeyLeft.FKeyLabelTextString = "F";
            this.tcFKeyLeft.FKeyLabelWidthRelation = 0;
            this.tcFKeyLeft.FKeyMax = 8;
            this.tcFKeyLeft.FKeySelectedMode = false;
            this.tcFKeyLeft.FKeyStyle = 4;
            this.tcFKeyLeft.FKeyTextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.tcFKeyLeft.FKeyVerticalDistance = 0;
            this.tcFKeyLeft.Location = new System.Drawing.Point(0, 0);
            this.tcFKeyLeft.Name = "tcFKeyLeft";
            this.tcFKeyLeft.Size = new System.Drawing.Size(132, 721);
            this.tcFKeyLeft.TabIndex = 1;
            this.tcFKeyLeft.Visible = false;
            // 
            // tcTypeKey
            // 
            this.tcTypeKey.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.tcTypeKey.FKeyBtnBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(153)))), ((int)(((byte)(153)))));
            this.tcTypeKey.FKeyBtnForeColor = System.Drawing.Color.Transparent;
            this.tcTypeKey.FKeyBtnSelectedColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(102)))), ((int)(((byte)(102)))));
            this.tcTypeKey.FKeyFlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.tcTypeKey.FKeyHorizontalDistanceLeft = 0;
            this.tcTypeKey.FKeyHorizontalDistanceRight = 0;
            this.tcTypeKey.FKeyImageAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.tcTypeKey.FKeyLabelAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.tcTypeKey.FKeyLabelBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(102)))), ((int)(((byte)(102)))));
            this.tcTypeKey.FKeyLabelForeColor = System.Drawing.Color.White;
            this.tcTypeKey.FKeyLabelHeightRelation = 0;
            this.tcTypeKey.FKeyLabelTextString = "";
            this.tcTypeKey.FKeyLabelWidthRelation = 0;
            this.tcTypeKey.FKeyMax = 4;
            this.tcTypeKey.FKeySelectedMode = false;
            this.tcTypeKey.FKeyStyle = 3;
            this.tcTypeKey.FKeyTextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.tcTypeKey.FKeyVerticalDistance = 0;
            this.tcTypeKey.Location = new System.Drawing.Point(133, 0);
            this.tcTypeKey.Name = "tcTypeKey";
            this.tcTypeKey.Size = new System.Drawing.Size(478, 69);
            this.tcTypeKey.TabIndex = 19;
            this.tcTypeKey.Visible = false;
            // 
            // FOperation
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.ClientSize = new System.Drawing.Size(1006, 721);
            this.Controls.Add(this.tcFKeyLeft);
            this.Controls.Add(this.tcTypeKey);
            this.Controls.Add(this.tcOpModeKey);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximumSize = new System.Drawing.Size(1024, 768);
            this.Name = "FOperation";
            this.Text = "FOperation";
            this.Activated += new System.EventHandler(this.FOperation_Activated);
            this.Load += new System.EventHandler(this.FOperation_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        public TwinCAT.App.TcFKey tcFKeyLeft;
        private TwinCAT.App.TcFKey tcOpModeKey;
        public TwinCAT.App.TcFKey tcTypeKey;


    }
}