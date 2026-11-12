namespace App
{
    using System;

    partial class FInfo : IDisposable
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

        ~FInfo()
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
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
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
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = global::App.Properties.Resources.Riexinger_Logo_sw;
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox1.Location = new System.Drawing.Point(738, 30);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(276, 45);
            this.pictureBox1.TabIndex = 70;
            this.pictureBox1.TabStop = false;
            // 
            // FInfo
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.BackgroundImage = global::App.Properties.Resources.Info_1024x572x8;
            this.ClientSize = new System.Drawing.Size(1024, 572);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.lblWindowTitle);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximumSize = new System.Drawing.Size(1024, 572);
            this.Name = "FInfo";
            this.Text = "FParameters8";
            this.Activated += new System.EventHandler(this.FSettings8_Activated);
            this.Load += new System.EventHandler(this.FSettings8_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblWindowTitle;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}