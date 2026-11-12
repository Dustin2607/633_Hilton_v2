namespace App
{
    using System;

    partial class FSetup : IDisposable
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

        ~FSetup()
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
            this.lblWindowTitle = new System.Windows.Forms.Label();
            this.ucCVCounterUser = new App.Components.UCCurrentValue1();
            this.ucCVCounterTotal = new App.Components.UCCurrentValue1();
            this.ucBtnResetCounter = new App.Components.UCButtonOn();
            this.ucBtnResetLifetimeDevice = new App.Components.UCButtonOn();
            this.ucCVLifetimeDeviceOn = new App.Components.UCCurrentValue();
            this.ucCVLifetimeDeviceRst = new App.Components.UCCurrentValue();
            this.ucCVLifetimeDevice = new App.Components.UCCurrentValue();
            this.gbxLifetimeDevice = new App.Components.CVisuGroupBox();
            this.gbxCounter = new App.Components.CVisuGroupBox();
            this.gbxLifetimeDevice.SuspendLayout();
            this.gbxCounter.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblWindowTitle
            // 
            this.lblWindowTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblWindowTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblWindowTitle.ForeColor = System.Drawing.Color.White;
            this.lblWindowTitle.Location = new System.Drawing.Point(0, 0);
            this.lblWindowTitle.Name = "lblWindowTitle";
            this.lblWindowTitle.Size = new System.Drawing.Size(1024, 20);
            this.lblWindowTitle.TabIndex = 10;
            this.lblWindowTitle.Text = "---------";
            this.lblWindowTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ucCVCounterUser
            // 
            this.ucCVCounterUser.ActValue = null;
            this.ucCVCounterUser.ActValueName = "CVCounterUser";
            this.ucCVCounterUser.ActValueUnit = "";
            this.ucCVCounterUser.CaptionBackColor = System.Drawing.Color.Empty;
            this.ucCVCounterUser.ColorRow2 = System.Drawing.Color.Empty;
            this.ucCVCounterUser.ColorRow3 = System.Drawing.Color.Empty;
            this.ucCVCounterUser.Location = new System.Drawing.Point(5, 46);
            this.ucCVCounterUser.Name = "ucCVCounterUser";
            this.ucCVCounterUser.Size = new System.Drawing.Size(300, 25);
            this.ucCVCounterUser.TabIndex = 57;
            // 
            // ucCVCounterTotal
            // 
            this.ucCVCounterTotal.ActValue = null;
            this.ucCVCounterTotal.ActValueName = "CVCounterTotal";
            this.ucCVCounterTotal.ActValueUnit = "";
            this.ucCVCounterTotal.CaptionBackColor = System.Drawing.Color.Empty;
            this.ucCVCounterTotal.ColorRow2 = System.Drawing.Color.Empty;
            this.ucCVCounterTotal.ColorRow3 = System.Drawing.Color.Empty;
            this.ucCVCounterTotal.Location = new System.Drawing.Point(5, 20);
            this.ucCVCounterTotal.Name = "ucCVCounterTotal";
            this.ucCVCounterTotal.Size = new System.Drawing.Size(300, 25);
            this.ucCVCounterTotal.TabIndex = 55;
            // 
            // ucBtnResetCounter
            // 
            this.ucBtnResetCounter.ActStatus = ((ushort)(0));
            this.ucBtnResetCounter.BackColor = System.Drawing.Color.Transparent;
            this.ucBtnResetCounter.Bistable = false;
            this.ucBtnResetCounter.Location = new System.Drawing.Point(303, 331);
            this.ucBtnResetCounter.Name = "ucBtnResetCounter";
            this.ucBtnResetCounter.ObjectName = "BtnResetCounter";
            this.ucBtnResetCounter.OffName = "On";
            this.ucBtnResetCounter.OnName = "On";
            this.ucBtnResetCounter.PlcVarNameOn = ".stgGr00HMI.stHMITOPLC.bResetCounterUser";
            this.ucBtnResetCounter.Size = new System.Drawing.Size(80, 50);
            this.ucBtnResetCounter.TabIndex = 59;
            // 
            // ucBtnResetLifetimeDevice
            // 
            this.ucBtnResetLifetimeDevice.ActStatus = ((ushort)(0));
            this.ucBtnResetLifetimeDevice.BackColor = System.Drawing.Color.Transparent;
            this.ucBtnResetLifetimeDevice.Bistable = false;
            this.ucBtnResetLifetimeDevice.Location = new System.Drawing.Point(594, 360);
            this.ucBtnResetLifetimeDevice.Name = "ucBtnResetLifetimeDevice";
            this.ucBtnResetLifetimeDevice.ObjectName = "BtnResetLifetimeDevice";
            this.ucBtnResetLifetimeDevice.OffName = "On";
            this.ucBtnResetLifetimeDevice.OnName = "On";
            this.ucBtnResetLifetimeDevice.PlcVarNameOn = ".stgGr01HMI.stHMITOPLC.bResetLifetime";
            this.ucBtnResetLifetimeDevice.Size = new System.Drawing.Size(80, 50);
            this.ucBtnResetLifetimeDevice.TabIndex = 60;
            // 
            // ucCVLifetimeDeviceOn
            // 
            this.ucCVLifetimeDeviceOn.ActValue = null;
            this.ucCVLifetimeDeviceOn.ActValueAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.ucCVLifetimeDeviceOn.ActValueName = "CVLifetimeDeviceOn";
            this.ucCVLifetimeDeviceOn.ActValueUnit = "Std.";
            this.ucCVLifetimeDeviceOn.CaptionBackColor = System.Drawing.Color.Empty;
            this.ucCVLifetimeDeviceOn.ColorRow2 = System.Drawing.Color.Empty;
            this.ucCVLifetimeDeviceOn.ColorRow3 = System.Drawing.Color.Empty;
            this.ucCVLifetimeDeviceOn.Location = new System.Drawing.Point(5, 72);
            this.ucCVLifetimeDeviceOn.Name = "ucCVLifetimeDeviceOn";
            this.ucCVLifetimeDeviceOn.Size = new System.Drawing.Size(250, 25);
            this.ucCVLifetimeDeviceOn.TabIndex = 63;
            // 
            // ucCVLifetimeDeviceRst
            // 
            this.ucCVLifetimeDeviceRst.ActValue = null;
            this.ucCVLifetimeDeviceRst.ActValueAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.ucCVLifetimeDeviceRst.ActValueName = "CVLifetimeDeviceRst";
            this.ucCVLifetimeDeviceRst.ActValueUnit = "Std.";
            this.ucCVLifetimeDeviceRst.CaptionBackColor = System.Drawing.Color.Empty;
            this.ucCVLifetimeDeviceRst.ColorRow2 = System.Drawing.Color.Empty;
            this.ucCVLifetimeDeviceRst.ColorRow3 = System.Drawing.Color.Empty;
            this.ucCVLifetimeDeviceRst.Location = new System.Drawing.Point(5, 46);
            this.ucCVLifetimeDeviceRst.Name = "ucCVLifetimeDeviceRst";
            this.ucCVLifetimeDeviceRst.Size = new System.Drawing.Size(250, 25);
            this.ucCVLifetimeDeviceRst.TabIndex = 62;
            // 
            // ucCVLifetimeDevice
            // 
            this.ucCVLifetimeDevice.ActValue = null;
            this.ucCVLifetimeDevice.ActValueAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.ucCVLifetimeDevice.ActValueName = "CVLifetimeDevice";
            this.ucCVLifetimeDevice.ActValueUnit = "Std.";
            this.ucCVLifetimeDevice.CaptionBackColor = System.Drawing.Color.Empty;
            this.ucCVLifetimeDevice.ColorRow2 = System.Drawing.Color.Empty;
            this.ucCVLifetimeDevice.ColorRow3 = System.Drawing.Color.Empty;
            this.ucCVLifetimeDevice.Location = new System.Drawing.Point(5, 20);
            this.ucCVLifetimeDevice.Name = "ucCVLifetimeDevice";
            this.ucCVLifetimeDevice.Size = new System.Drawing.Size(250, 25);
            this.ucCVLifetimeDevice.TabIndex = 61;
            // 
            // gbxLifetimeDevice
            // 
            this.gbxLifetimeDevice.Controls.Add(this.ucCVLifetimeDevice);
            this.gbxLifetimeDevice.Controls.Add(this.ucCVLifetimeDeviceOn);
            this.gbxLifetimeDevice.Controls.Add(this.ucCVLifetimeDeviceRst);
            this.gbxLifetimeDevice.Cursor = System.Windows.Forms.Cursors.Hand;
            this.gbxLifetimeDevice.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.gbxLifetimeDevice.Location = new System.Drawing.Point(518, 232);
            this.gbxLifetimeDevice.Name = "gbxLifetimeDevice";
            this.gbxLifetimeDevice.Size = new System.Drawing.Size(262, 103);
            this.gbxLifetimeDevice.TabIndex = 64;
            this.gbxLifetimeDevice.TabStop = false;
            this.gbxLifetimeDevice.Text = "gbxLifetimeDevice";
            // 
            // gbxCounter
            // 
            this.gbxCounter.Controls.Add(this.ucCVCounterTotal);
            this.gbxCounter.Controls.Add(this.ucCVCounterUser);
            this.gbxCounter.Cursor = System.Windows.Forms.Cursors.Hand;
            this.gbxCounter.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.gbxCounter.Location = new System.Drawing.Point(191, 232);
            this.gbxCounter.Name = "gbxCounter";
            this.gbxCounter.Size = new System.Drawing.Size(312, 76);
            this.gbxCounter.TabIndex = 65;
            this.gbxCounter.TabStop = false;
            this.gbxCounter.Text = "gbxCounter";
            // 
            // FSetup
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.BackgroundImage = global::App.Properties.Resources.MainMashine_1024x572x8;
            this.ClientSize = new System.Drawing.Size(1024, 572);
            this.Controls.Add(this.gbxCounter);
            this.Controls.Add(this.gbxLifetimeDevice);
            this.Controls.Add(this.ucBtnResetLifetimeDevice);
            this.Controls.Add(this.ucBtnResetCounter);
            this.Controls.Add(this.lblWindowTitle);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximumSize = new System.Drawing.Size(1024, 572);
            this.Name = "FSetup";
            this.Text = "FSetup";
            this.Activated += new System.EventHandler(this.FSetup_Activated);
            this.Load += new System.EventHandler(this.FSetup_Load);
            this.gbxLifetimeDevice.ResumeLayout(false);
            this.gbxCounter.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblWindowTitle;
        private Components.UCCurrentValue1 ucCVCounterUser;
        private Components.UCCurrentValue1 ucCVCounterTotal;
        private Components.UCButtonOn ucBtnResetCounter;
        private Components.UCButtonOn ucBtnResetLifetimeDevice;
        private Components.UCCurrentValue ucCVLifetimeDeviceOn;
        private Components.UCCurrentValue ucCVLifetimeDeviceRst;
        private Components.UCCurrentValue ucCVLifetimeDevice;
        private Components.CVisuGroupBox gbxLifetimeDevice;
        private Components.CVisuGroupBox gbxCounter;
    }
}