namespace App
{
    using System;

    partial class FMain : IDisposable
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

        ~FMain()
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
            this.ucCVLifetimeOn = new App.Components.UCCurrentValue();
            this.ucCVLifetimeTotal = new App.Components.UCCurrentValue();
            this.gbxCounter = new App.Components.CVisuGroupBox();
            this.ucCVCycleTime = new App.Components.UCCurrentValue();
            this.ucCVCounterTotal = new App.Components.UCCurrentValue1();
            this.ucCVCounterUser = new App.Components.UCCurrentValue1();
            this.gbxLifetimeDevice = new App.Components.CVisuGroupBox();
            this.ucCVLifetimeDevice = new App.Components.UCCurrentValue();
            this.ucCVLifetimeDeviceRst = new App.Components.UCCurrentValue();
            this.ucCVLifetimeDeviceOn = new App.Components.UCCurrentValue();
            this.gbxLifetime = new App.Components.CVisuGroupBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.gbxCounter.SuspendLayout();
            this.gbxLifetimeDevice.SuspendLayout();
            this.gbxLifetime.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // ucCVLifetimeOn
            // 
            this.ucCVLifetimeOn.ActValue = null;
            this.ucCVLifetimeOn.ActValueAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.ucCVLifetimeOn.ActValueName = "CVLifetimeOn";
            this.ucCVLifetimeOn.ActValueUnit = "Std.";
            this.ucCVLifetimeOn.CaptionBackColor = System.Drawing.Color.Empty;
            this.ucCVLifetimeOn.ColorRow2 = System.Drawing.Color.Empty;
            this.ucCVLifetimeOn.ColorRow3 = System.Drawing.Color.Empty;
            this.ucCVLifetimeOn.Location = new System.Drawing.Point(5, 46);
            this.ucCVLifetimeOn.Name = "ucCVLifetimeOn";
            this.ucCVLifetimeOn.Size = new System.Drawing.Size(250, 25);
            this.ucCVLifetimeOn.TabIndex = 48;
            // 
            // ucCVLifetimeTotal
            // 
            this.ucCVLifetimeTotal.ActValue = null;
            this.ucCVLifetimeTotal.ActValueAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.ucCVLifetimeTotal.ActValueName = "CVLifetimeTotal";
            this.ucCVLifetimeTotal.ActValueUnit = "Std.";
            this.ucCVLifetimeTotal.CaptionBackColor = System.Drawing.Color.Empty;
            this.ucCVLifetimeTotal.ColorRow2 = System.Drawing.Color.Empty;
            this.ucCVLifetimeTotal.ColorRow3 = System.Drawing.Color.Empty;
            this.ucCVLifetimeTotal.Location = new System.Drawing.Point(5, 20);
            this.ucCVLifetimeTotal.Name = "ucCVLifetimeTotal";
            this.ucCVLifetimeTotal.Size = new System.Drawing.Size(250, 25);
            this.ucCVLifetimeTotal.TabIndex = 47;
            // 
            // gbxCounter
            // 
            this.gbxCounter.Controls.Add(this.ucCVCycleTime);
            this.gbxCounter.Controls.Add(this.ucCVCounterTotal);
            this.gbxCounter.Controls.Add(this.ucCVCounterUser);
            this.gbxCounter.Cursor = System.Windows.Forms.Cursors.Hand;
            this.gbxCounter.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.gbxCounter.Location = new System.Drawing.Point(333, 69);
            this.gbxCounter.Name = "gbxCounter";
            this.gbxCounter.Size = new System.Drawing.Size(312, 102);
            this.gbxCounter.TabIndex = 67;
            this.gbxCounter.TabStop = false;
            this.gbxCounter.Text = "gbxCounter";
            // 
            // ucCVCycleTime
            // 
            this.ucCVCycleTime.ActValue = null;
            this.ucCVCycleTime.ActValueAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.ucCVCycleTime.ActValueName = "CVCycleTime";
            this.ucCVCycleTime.ActValueUnit = "s";
            this.ucCVCycleTime.CaptionBackColor = System.Drawing.Color.Empty;
            this.ucCVCycleTime.ColorRow2 = System.Drawing.Color.Empty;
            this.ucCVCycleTime.ColorRow3 = System.Drawing.Color.Empty;
            this.ucCVCycleTime.Location = new System.Drawing.Point(5, 72);
            this.ucCVCycleTime.Name = "ucCVCycleTime";
            this.ucCVCycleTime.Size = new System.Drawing.Size(250, 25);
            this.ucCVCycleTime.TabIndex = 58;
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
            // gbxLifetimeDevice
            // 
            this.gbxLifetimeDevice.Controls.Add(this.ucCVLifetimeDevice);
            this.gbxLifetimeDevice.Controls.Add(this.ucCVLifetimeDeviceRst);
            this.gbxLifetimeDevice.Controls.Add(this.ucCVLifetimeDeviceOn);
            this.gbxLifetimeDevice.Cursor = System.Windows.Forms.Cursors.Hand;
            this.gbxLifetimeDevice.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.gbxLifetimeDevice.Location = new System.Drawing.Point(518, 232);
            this.gbxLifetimeDevice.Name = "gbxLifetimeDevice";
            this.gbxLifetimeDevice.Size = new System.Drawing.Size(262, 103);
            this.gbxLifetimeDevice.TabIndex = 66;
            this.gbxLifetimeDevice.TabStop = false;
            this.gbxLifetimeDevice.Text = "gbxLifetimeDevice";
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
            this.ucCVLifetimeDeviceRst.TabIndex = 63;
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
            this.ucCVLifetimeDeviceOn.TabIndex = 62;
            // 
            // gbxLifetime
            // 
            this.gbxLifetime.Controls.Add(this.ucCVLifetimeTotal);
            this.gbxLifetime.Controls.Add(this.ucCVLifetimeOn);
            this.gbxLifetime.Cursor = System.Windows.Forms.Cursors.Hand;
            this.gbxLifetime.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.gbxLifetime.Location = new System.Drawing.Point(191, 232);
            this.gbxLifetime.Name = "gbxLifetime";
            this.gbxLifetime.Size = new System.Drawing.Size(262, 75);
            this.gbxLifetime.TabIndex = 68;
            this.gbxLifetime.TabStop = false;
            this.gbxLifetime.Text = "gbxLifetime";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = global::App.Properties.Resources.Riexinger_Logo_sw;
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox1.Location = new System.Drawing.Point(720, 10);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(276, 45);
            this.pictureBox1.TabIndex = 69;
            this.pictureBox1.TabStop = false;
            // 
            // FMain
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.BackgroundImage = global::App.Properties.Resources.MainMashine_1024x572x8;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.ClientSize = new System.Drawing.Size(1006, 525);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.gbxLifetime);
            this.Controls.Add(this.gbxCounter);
            this.Controls.Add(this.gbxLifetimeDevice);
            this.MaximumSize = new System.Drawing.Size(1024, 572);
            this.Name = "FMain";
            this.Text = "frmMain";
            this.Activated += new System.EventHandler(this.frmMain_Activated);
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.gbxCounter.ResumeLayout(false);
            this.gbxLifetimeDevice.ResumeLayout(false);
            this.gbxLifetime.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }







        #endregion
        private Components.UCCurrentValue ucCVLifetimeOn;
        private Components.UCCurrentValue ucCVLifetimeTotal;
        private Components.CVisuGroupBox gbxCounter;
        private Components.UCCurrentValue1 ucCVCounterTotal;
        private Components.UCCurrentValue1 ucCVCounterUser;
        private Components.CVisuGroupBox gbxLifetimeDevice;
        private Components.UCCurrentValue ucCVLifetimeDevice;
        private Components.UCCurrentValue ucCVLifetimeDeviceRst;
        private Components.UCCurrentValue ucCVLifetimeDeviceOn;
        private Components.CVisuGroupBox gbxLifetime;
        private Components.UCCurrentValue ucCVCycleTime;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}