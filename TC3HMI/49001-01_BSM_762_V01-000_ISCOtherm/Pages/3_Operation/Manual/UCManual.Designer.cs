namespace App.Pages.Operation.Manual
{
    partial class UCManual
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
            this.ucButtonMultiOn1 = new App.Components.UCButtonMultiOn();
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
            // ucButtonMultiOn1
            // 
            this.ucButtonMultiOn1.ActStatus = ((ushort)(0));
            this.ucButtonMultiOn1.BackColor = System.Drawing.Color.Transparent;
            this.ucButtonMultiOn1.Location = new System.Drawing.Point(462, 248);
            this.ucButtonMultiOn1.Name = "ucButtonMultiOn1";
            this.ucButtonMultiOn1.ObjectName = null;
            this.ucButtonMultiOn1.OnName = null;
            this.ucButtonMultiOn1.PlcVarNameOn1 = null;
            this.ucButtonMultiOn1.PlcVarNameOn2 = null;
            this.ucButtonMultiOn1.PlcVarNameOn3 = null;
            this.ucButtonMultiOn1.PlcVarNameOn4 = null;
            this.ucButtonMultiOn1.PlcVarNameOn5 = null;
            this.ucButtonMultiOn1.PlcVarNameOn6 = null;
            this.ucButtonMultiOn1.PlcVarNameOn7 = null;
            this.ucButtonMultiOn1.PlcVarNameOn8 = null;
            this.ucButtonMultiOn1.Size = new System.Drawing.Size(100, 80);
            this.ucButtonMultiOn1.TabIndex = 32;
            // 
            // UCManual
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.BackgroundImage = global::App.Properties.Resources.MainMashine_1024x572x8;
            this.Controls.Add(this.lblWindowTitle);
            this.MaximumSize = new System.Drawing.Size(1024, 572);
            this.Name = "UCManual";
            this.Size = new System.Drawing.Size(1024, 572);
            this.Load += new System.EventHandler(this.UCManual_Load);
            this.VisibleChanged += new System.EventHandler(this.UCManual_VisibleChanged);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblWindowTitle;
        private Components.UCButtonMultiOn ucButtonMultiOn1;
    }
}
