namespace App
{
    using System;

    partial class FMainApp : IDisposable
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

        ~FMainApp()
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

            if (this != null)
            {
                this.ADSConnect = false;
            }

            // Cleanup managed resources
            if (adsClient != null)
            {
                adsClient.Dispose();
            }

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
            this.tcFKeyBottom = new TwinCAT.App.TcFKey();
            this.panel1 = new System.Windows.Forms.Panel();
            this.statusStripMainApp = new System.Windows.Forms.StatusStrip();
            this.lblUserLevel = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblUser = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblPartWorkingCode = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblRecipe2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblRecipe1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblToolNo = new System.Windows.Forms.ToolStripStatusLabel();
            this.ucHeader1 = new App.Components.UCHeader();
            this.statusStripMainApp.SuspendLayout();
            this.SuspendLayout();
            // 
            // tcFKeyBottom
            // 
            this.tcFKeyBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.tcFKeyBottom.FKeyBtnBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(153)))), ((int)(((byte)(153)))));
            this.tcFKeyBottom.FKeyBtnForeColor = System.Drawing.Color.White;
            this.tcFKeyBottom.FKeyBtnSelectedColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(102)))), ((int)(((byte)(102)))));
            this.tcFKeyBottom.FKeyFlatStyle = System.Windows.Forms.FlatStyle.Standard;
            this.tcFKeyBottom.FKeyHorizontalDistanceLeft = 0;
            this.tcFKeyBottom.FKeyHorizontalDistanceRight = 0;
            this.tcFKeyBottom.FKeyImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.tcFKeyBottom.FKeyLabelAlign = System.Drawing.ContentAlignment.TopLeft;
            this.tcFKeyBottom.FKeyLabelBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(102)))), ((int)(((byte)(102)))));
            this.tcFKeyBottom.FKeyLabelForeColor = System.Drawing.Color.White;
            this.tcFKeyBottom.FKeyLabelHeightRelation = 0;
            this.tcFKeyBottom.FKeyLabelTextString = "F";
            this.tcFKeyBottom.FKeyLabelWidthRelation = 0;
            this.tcFKeyBottom.FKeyMax = 9;
            this.tcFKeyBottom.FKeySelectedMode = false;
            this.tcFKeyBottom.FKeyStyle = 1;
            this.tcFKeyBottom.FKeyTextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.tcFKeyBottom.FKeyVerticalDistance = 0;
            this.tcFKeyBottom.Location = new System.Drawing.Point(0, 657);
            this.tcFKeyBottom.Name = "tcFKeyBottom";
            this.tcFKeyBottom.Size = new System.Drawing.Size(1006, 64);
            this.tcFKeyBottom.TabIndex = 1;
            // 
            // panel1
            // 
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1006, 129);
            this.panel1.TabIndex = 2;
            // 
            // statusStripMainApp
            // 
            this.statusStripMainApp.AutoSize = false;
            this.statusStripMainApp.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.25F);
            this.statusStripMainApp.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblUserLevel,
            this.lblUser,
            this.lblPartWorkingCode,
            this.lblRecipe2,
            this.lblRecipe1,
            this.lblToolNo});
            this.statusStripMainApp.Location = new System.Drawing.Point(0, 639);
            this.statusStripMainApp.Name = "statusStripMainApp";
            this.statusStripMainApp.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.statusStripMainApp.Size = new System.Drawing.Size(1006, 18);
            this.statusStripMainApp.TabIndex = 4;
            this.statusStripMainApp.Text = "statusStrip1";
            this.statusStripMainApp.Visible = false;
            // 
            // lblUserLevel
            // 
            this.lblUserLevel.Name = "lblUserLevel";
            this.lblUserLevel.Size = new System.Drawing.Size(14, 13);
            this.lblUserLevel.Text = "---";
            // 
            // lblUser
            // 
            this.lblUser.Name = "lblUser";
            this.lblUser.Size = new System.Drawing.Size(14, 13);
            this.lblUser.Text = "---";
            // 
            // lblPartWorkingCode
            // 
            this.lblPartWorkingCode.Name = "lblPartWorkingCode";
            this.lblPartWorkingCode.Size = new System.Drawing.Size(14, 13);
            this.lblPartWorkingCode.Text = "---";
            // 
            // lblRecipe2
            // 
            this.lblRecipe2.Name = "lblRecipe2";
            this.lblRecipe2.Size = new System.Drawing.Size(14, 13);
            this.lblRecipe2.Text = "---";
            // 
            // lblRecipe1
            // 
            this.lblRecipe1.Name = "lblRecipe1";
            this.lblRecipe1.Size = new System.Drawing.Size(14, 13);
            this.lblRecipe1.Text = "---";
            // 
            // lblToolNo
            // 
            this.lblToolNo.Name = "lblToolNo";
            this.lblToolNo.Size = new System.Drawing.Size(14, 13);
            this.lblToolNo.Text = "---";
            // 
            // ucHeader1
            // 
            this.ucHeader1.AdsClientRef = null;
            this.ucHeader1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ucHeader1.CaptionBackColor = System.Drawing.SystemColors.Control;
            this.ucHeader1.ColorRow2 = System.Drawing.SystemColors.Control;
            this.ucHeader1.ColorRow3 = System.Drawing.SystemColors.Control;
            this.ucHeader1.Location = new System.Drawing.Point(0, 0);
            this.ucHeader1.Margin = new System.Windows.Forms.Padding(2);
            this.ucHeader1.Name = "ucHeader1";
            this.ucHeader1.Size = new System.Drawing.Size(1006, 129);
            this.ucHeader1.TabIndex = 0;
            // 
            // FMainApp
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.ClientSize = new System.Drawing.Size(1006, 721);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.statusStripMainApp);
            this.Controls.Add(this.tcFKeyBottom);
            this.IsMdiContainer = true;
            this.Name = "FMainApp";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.frmMainApp_Load);
            this.statusStripMainApp.ResumeLayout(false);
            this.statusStripMainApp.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        public TwinCAT.App.TcFKey tcFKeyBottom;
        private System.Windows.Forms.Panel panel1;
        private Components.UCHeader ucHeader1;
        private System.Windows.Forms.ToolStripStatusLabel lblUser;
        private System.Windows.Forms.ToolStripStatusLabel lblUserLevel;
        private System.Windows.Forms.ToolStripStatusLabel lblPartWorkingCode;
        private System.Windows.Forms.ToolStripStatusLabel lblRecipe2;
        private System.Windows.Forms.ToolStripStatusLabel lblRecipe1;
        private System.Windows.Forms.ToolStripStatusLabel lblToolNo;
        public System.Windows.Forms.StatusStrip statusStripMainApp;
    }
}

