namespace App
{
    using System;

    partial class FManual : IDisposable
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

        ~FManual()
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
            this.tcFKeyRight = new TwinCAT.App.TcFKey();
            this.ucOverride1 = new App.Components.UCOverride();
            this.ucSawbandSpeed = new App.Components.UCOverride();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.tcOpModeKey);
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
            this.tcFKeyLeft.FKeyBtnSelectedColor = System.Drawing.Color.DarkBlue;
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
            // 
            // tcFKeyRight
            // 
            this.tcFKeyRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.tcFKeyRight.FKeyBtnBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(153)))), ((int)(((byte)(153)))));
            this.tcFKeyRight.FKeyBtnForeColor = System.Drawing.Color.Transparent;
            this.tcFKeyRight.FKeyBtnSelectedColor = System.Drawing.Color.DarkBlue;
            this.tcFKeyRight.FKeyFlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.tcFKeyRight.FKeyHorizontalDistanceLeft = 0;
            this.tcFKeyRight.FKeyHorizontalDistanceRight = 0;
            this.tcFKeyRight.FKeyImageAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.tcFKeyRight.FKeyLabelAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.tcFKeyRight.FKeyLabelBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(102)))), ((int)(((byte)(102)))));
            this.tcFKeyRight.FKeyLabelForeColor = System.Drawing.Color.White;
            this.tcFKeyRight.FKeyLabelHeightRelation = 0;
            this.tcFKeyRight.FKeyLabelTextString = "F";
            this.tcFKeyRight.FKeyLabelWidthRelation = 0;
            this.tcFKeyRight.FKeyMax = 8;
            this.tcFKeyRight.FKeySelectedMode = false;
            this.tcFKeyRight.FKeyStyle = 4;
            this.tcFKeyRight.FKeyTextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.tcFKeyRight.FKeyVerticalDistance = 0;
            this.tcFKeyRight.Location = new System.Drawing.Point(874, 0);
            this.tcFKeyRight.Name = "tcFKeyRight";
            this.tcFKeyRight.Size = new System.Drawing.Size(132, 721);
            this.tcFKeyRight.TabIndex = 22;
            this.tcFKeyRight.Visible = false;
            // 
            // ucOverride1
            // 
            this.ucOverride1.ActValue = null;
            this.ucOverride1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ucOverride1.BackColor = System.Drawing.SystemColors.Control;
            this.ucOverride1.LeftButtonName = "-";
            this.ucOverride1.Location = new System.Drawing.Point(750, 25);
            this.ucOverride1.MirrorCtrl = false;
            this.ucOverride1.Name = "ucOverride1";
            this.ucOverride1.ObjectName = "Override";
            this.ucOverride1.OverrideMax = 100F;
            this.ucOverride1.OverrideMin = 0F;
            this.ucOverride1.OverrideStep = 5F;
            this.ucOverride1.PlcVarName = ".stgGr00HMI.stHMITOPLC.rOverride";
            this.ucOverride1.RightButtonName = "+";
            this.ucOverride1.Size = new System.Drawing.Size(250, 60);
            this.ucOverride1.TabIndex = 21;
            this.ucOverride1.Unit = "%";
            // 
            // ucSawbandSpeed
            // 
            this.ucSawbandSpeed.ActValue = null;
            this.ucSawbandSpeed.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ucSawbandSpeed.BackColor = System.Drawing.SystemColors.Control;
            this.ucSawbandSpeed.LeftButtonName = "-";
            this.ucSawbandSpeed.Location = new System.Drawing.Point(750, 90);
            this.ucSawbandSpeed.MirrorCtrl = false;
            this.ucSawbandSpeed.Name = "ucSawbandSpeed";
            this.ucSawbandSpeed.ObjectName = "Saw band";
            this.ucSawbandSpeed.OverrideMax = 1300F;
            this.ucSawbandSpeed.OverrideMin = 330F;
            this.ucSawbandSpeed.OverrideStep = 10F;
            this.ucSawbandSpeed.PlcVarName = ".stgGr01HMI.stHMITOPLC.rSawbandManualSpeed";
            this.ucSawbandSpeed.RightButtonName = "+";
            this.ucSawbandSpeed.Size = new System.Drawing.Size(250, 60);
            this.ucSawbandSpeed.TabIndex = 23;
            this.ucSawbandSpeed.Unit = "fpm";
            // 
            // FManual
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.ClientSize = new System.Drawing.Size(1006, 721);
            this.Controls.Add(this.tcFKeyRight);
            this.Controls.Add(this.ucSawbandSpeed);
            this.Controls.Add(this.tcFKeyLeft);
            this.Controls.Add(this.ucOverride1);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximumSize = new System.Drawing.Size(1024, 768);
            this.Name = "FManual";
            this.Text = "FManual";
            this.Activated += new System.EventHandler(this.FManual_Activated);
            this.Load += new System.EventHandler(this.FManual_Load);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        public TwinCAT.App.TcFKey tcFKeyLeft;
        public TwinCAT.App.TcFKey tcFKeyRight;
        private TwinCAT.App.TcFKey tcOpModeKey;
        private Components.UCOverride ucOverride1;
        public System.Windows.Forms.Panel panel1;
        private Components.UCOverride ucSawbandSpeed;
    }
}