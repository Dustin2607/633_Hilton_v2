namespace App.Pages.Operation.Manual
{
    partial class UCManual7
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
            this.ucGuideRailTop = new App.Components.UCCylinderVer();
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
            // ucGuideRailTop
            // 
            this.ucGuideRailTop.ActStatus = ((ushort)(0));
            this.ucGuideRailTop.ActValue = null;
            this.ucGuideRailTop.ActValueVisable = false;
            this.ucGuideRailTop.BackColor = System.Drawing.Color.Transparent;
            this.ucGuideRailTop.BottomButtonName = "Down";
            this.ucGuideRailTop.LanguageManager = null;
            this.ucGuideRailTop.Location = new System.Drawing.Point(407, 55);
            this.ucGuideRailTop.MirrorCtrl = false;
            this.ucGuideRailTop.Name = "ucGuideRailTop";
            this.ucGuideRailTop.ObjectName = "GuideRailTop";
            this.ucGuideRailTop.PlcVarNameNegative = ".stgGr01HMI.stHMITOPLC.bBtnGuideRailTopToBase";
            this.ucGuideRailTop.PlcVarNamePositive = ".stgGr01HMI.stHMITOPLC.bBtnGuideRailTopToWork";
            this.ucGuideRailTop.Size = new System.Drawing.Size(80, 183);
            this.ucGuideRailTop.TabIndex = 10;
            this.ucGuideRailTop.TopButtonName = "Up";
            this.ucGuideRailTop.Unit = null;
            // 
            // UCManual7
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.Controls.Add(this.ucGuideRailTop);
            this.Controls.Add(this.lblWindowTitle);
            this.MaximumSize = new System.Drawing.Size(1024, 572);
            this.Name = "UCManual7";
            this.Size = new System.Drawing.Size(1024, 572);
            this.Load += new System.EventHandler(this.UCManual7_Load);
            this.VisibleChanged += new System.EventHandler(this.UCManual7_VisibleChanged);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblWindowTitle;
        private Components.UCCylinderVer ucGuideRailTop;

    }
}
