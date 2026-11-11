namespace App.Pages.Operation.Home
{
    partial class UCHome1
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblWindowTitle = new System.Windows.Forms.Label();
            this.gbxCounter = new App.Components.CVisuGroupBox();
            this.ucCVCycleTime = new App.Components.UCCurrentValue();
            this.ucCVCounterTotal = new App.Components.UCCurrentValue1();
            this.ucCVCounterUser = new App.Components.UCCurrentValue1();
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
            this.lblWindowTitle.TabIndex = 9;
            this.lblWindowTitle.Text = "---------";
            this.lblWindowTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // gbxCounter
            // 
            this.gbxCounter.Controls.Add(this.ucCVCycleTime);
            this.gbxCounter.Controls.Add(this.ucCVCounterTotal);
            this.gbxCounter.Controls.Add(this.ucCVCounterUser);
            this.gbxCounter.Cursor = System.Windows.Forms.Cursors.Hand;
            this.gbxCounter.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.gbxCounter.Location = new System.Drawing.Point(160, 450);
            this.gbxCounter.Name = "gbxCounter";
            this.gbxCounter.Size = new System.Drawing.Size(312, 102);
            this.gbxCounter.TabIndex = 68;
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
            // UCHome1
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.BackgroundImage = global::App.Properties.Resources.MainMashine_1024x572x8;
            this.Controls.Add(this.gbxCounter);
            this.Controls.Add(this.lblWindowTitle);
            this.MaximumSize = new System.Drawing.Size(1024, 572);
            this.Name = "UCHome1";
            this.Size = new System.Drawing.Size(1024, 572);
            this.Load += new System.EventHandler(this.UCHome1_Load);
            this.gbxCounter.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblWindowTitle;
        private Components.CVisuGroupBox gbxCounter;
        private Components.UCCurrentValue ucCVCycleTime;
        private Components.UCCurrentValue1 ucCVCounterTotal;
        private Components.UCCurrentValue1 ucCVCounterUser;
    }
}
