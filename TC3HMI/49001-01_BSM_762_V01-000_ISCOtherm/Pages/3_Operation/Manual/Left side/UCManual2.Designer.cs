namespace App.Pages.Operation.Manual
{
    partial class UCManual2
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
            this.ucAxisClamp1 = new App.Components.UCAxisHor();
            this.ucBtnClamp1 = new App.Components.UCButtonOnOff2();
            this.ucBtnClamp2 = new App.Components.UCButtonOnOff2();
            this.ucCylinderPos100 = new App.Components.UCAxisHor();
            this.ucCylinderPos200 = new App.Components.UCAxisHor();
            this.ucCylinderPos400 = new App.Components.UCAxisHor();
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
            // ucAxisClamp1
            // 
            this.ucAxisClamp1.ActStatus = ((ushort)(0));
            this.ucAxisClamp1.ActValue = null;
            this.ucAxisClamp1.ActValueVisable = true;
            this.ucAxisClamp1.BackColor = System.Drawing.Color.Transparent;
            this.ucAxisClamp1.LeftButtonName = "+";
            this.ucAxisClamp1.Location = new System.Drawing.Point(176, 381);
            this.ucAxisClamp1.MirrorCtrl = true;
            this.ucAxisClamp1.Name = "ucAxisClamp1";
            this.ucAxisClamp1.ObjectName = "AxisClamp1";
            this.ucAxisClamp1.PlcVarNameNegative = ".stgGr05HMI.stHMITOPLC.arbBtnAxisClampMinus[1]";
            this.ucAxisClamp1.PlcVarNamePositive = ".stgGr05HMI.stHMITOPLC.arbBtnAxisClampPlus[1]";
            this.ucAxisClamp1.RightButtonName = "-";
            this.ucAxisClamp1.Size = new System.Drawing.Size(250, 60);
            this.ucAxisClamp1.TabIndex = 16;
            this.ucAxisClamp1.Unit = "[mm]";
            // 
            // ucBtnClamp1
            // 
            this.ucBtnClamp1.ActStatus = ((ushort)(0));
            this.ucBtnClamp1.BackColor = System.Drawing.Color.Transparent;
            this.ucBtnClamp1.Location = new System.Drawing.Point(228, 245);
            this.ucBtnClamp1.Name = "ucBtnClamp1";
            this.ucBtnClamp1.ObjectName = "BtnClamp1";
            this.ucBtnClamp1.OffName = "Close";
            this.ucBtnClamp1.OnName = "Open";
            this.ucBtnClamp1.PlcVarNameOff = ".stgGr05HMI.stHMITOPLC.arbBtnClampClose[1]";
            this.ucBtnClamp1.PlcVarNameOn = ".stgGr05HMI.stHMITOPLC.arbBtnClampOpen[1]";
            this.ucBtnClamp1.Size = new System.Drawing.Size(140, 85);
            this.ucBtnClamp1.TabIndex = 59;
            // 
            // ucBtnClamp2
            // 
            this.ucBtnClamp2.ActStatus = ((ushort)(0));
            this.ucBtnClamp2.BackColor = System.Drawing.Color.Transparent;
            this.ucBtnClamp2.Location = new System.Drawing.Point(577, 178);
            this.ucBtnClamp2.Name = "ucBtnClamp2";
            this.ucBtnClamp2.ObjectName = "BtnClamp2";
            this.ucBtnClamp2.OffName = "Close";
            this.ucBtnClamp2.OnName = "Open";
            this.ucBtnClamp2.PlcVarNameOff = ".stgGr05HMI.stHMITOPLC.arbBtnClampClose[2]";
            this.ucBtnClamp2.PlcVarNameOn = ".stgGr05HMI.stHMITOPLC.arbBtnClampOpen[2]";
            this.ucBtnClamp2.Size = new System.Drawing.Size(140, 85);
            this.ucBtnClamp2.TabIndex = 60;
            // 
            // ucCylinderPos100
            // 
            this.ucCylinderPos100.ActStatus = ((ushort)(0));
            this.ucCylinderPos100.ActValue = null;
            this.ucCylinderPos100.ActValueVisable = true;
            this.ucCylinderPos100.BackColor = System.Drawing.Color.Transparent;
            this.ucCylinderPos100.LeftButtonName = "+";
            this.ucCylinderPos100.Location = new System.Drawing.Point(516, 316);
            this.ucCylinderPos100.MirrorCtrl = true;
            this.ucCylinderPos100.Name = "ucCylinderPos100";
            this.ucCylinderPos100.ObjectName = "CylinderPos100";
            this.ucCylinderPos100.PlcVarNameNegative = ".stgGr05HMI.stHMITOPLC.arbBtnCylinderPosClose[1]";
            this.ucCylinderPos100.PlcVarNamePositive = ".stgGr05HMI.stHMITOPLC.arbBtnCylinderPosOpen[1]";
            this.ucCylinderPos100.RightButtonName = "-";
            this.ucCylinderPos100.Size = new System.Drawing.Size(250, 60);
            this.ucCylinderPos100.TabIndex = 61;
            this.ucCylinderPos100.Unit = "[mm]";
            // 
            // ucCylinderPos200
            // 
            this.ucCylinderPos200.ActStatus = ((ushort)(0));
            this.ucCylinderPos200.ActValue = null;
            this.ucCylinderPos200.ActValueVisable = true;
            this.ucCylinderPos200.BackColor = System.Drawing.Color.Transparent;
            this.ucCylinderPos200.LeftButtonName = "+";
            this.ucCylinderPos200.Location = new System.Drawing.Point(516, 381);
            this.ucCylinderPos200.MirrorCtrl = true;
            this.ucCylinderPos200.Name = "ucCylinderPos200";
            this.ucCylinderPos200.ObjectName = "CylinderPos200";
            this.ucCylinderPos200.PlcVarNameNegative = ".stgGr05HMI.stHMITOPLC.arbBtnCylinderPosClose[2]";
            this.ucCylinderPos200.PlcVarNamePositive = ".stgGr05HMI.stHMITOPLC.arbBtnCylinderPosOpen[2]";
            this.ucCylinderPos200.RightButtonName = "-";
            this.ucCylinderPos200.Size = new System.Drawing.Size(250, 60);
            this.ucCylinderPos200.TabIndex = 62;
            this.ucCylinderPos200.Unit = "[mm]";
            // 
            // ucCylinderPos400
            // 
            this.ucCylinderPos400.ActStatus = ((ushort)(0));
            this.ucCylinderPos400.ActValue = null;
            this.ucCylinderPos400.ActValueVisable = true;
            this.ucCylinderPos400.BackColor = System.Drawing.Color.Transparent;
            this.ucCylinderPos400.LeftButtonName = "+";
            this.ucCylinderPos400.Location = new System.Drawing.Point(516, 448);
            this.ucCylinderPos400.MirrorCtrl = true;
            this.ucCylinderPos400.Name = "ucCylinderPos400";
            this.ucCylinderPos400.ObjectName = "CylinderPos400";
            this.ucCylinderPos400.PlcVarNameNegative = ".stgGr05HMI.stHMITOPLC.arbBtnCylinderPosClose[3]";
            this.ucCylinderPos400.PlcVarNamePositive = ".stgGr05HMI.stHMITOPLC.arbBtnCylinderPosOpen[3]";
            this.ucCylinderPos400.RightButtonName = "-";
            this.ucCylinderPos400.Size = new System.Drawing.Size(250, 60);
            this.ucCylinderPos400.TabIndex = 63;
            this.ucCylinderPos400.Unit = "[mm]";
            // 
            // UCManual2
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.BackgroundImage = global::App.Properties.Resources.Transport_1024x572x8;
            this.Controls.Add(this.ucCylinderPos400);
            this.Controls.Add(this.ucCylinderPos200);
            this.Controls.Add(this.ucCylinderPos100);
            this.Controls.Add(this.ucBtnClamp2);
            this.Controls.Add(this.ucBtnClamp1);
            this.Controls.Add(this.ucAxisClamp1);
            this.Controls.Add(this.lblWindowTitle);
            this.MaximumSize = new System.Drawing.Size(1024, 572);
            this.Name = "UCManual2";
            this.Size = new System.Drawing.Size(1024, 572);
            this.Load += new System.EventHandler(this.UCManual2_Load);
            this.VisibleChanged += new System.EventHandler(this.UCManual2_VisibleChanged);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblWindowTitle;
        private Components.UCAxisHor ucAxisClamp1;
        private Components.UCButtonOnOff2 ucBtnClamp1;
        private Components.UCButtonOnOff2 ucBtnClamp2;
        private Components.UCAxisHor ucCylinderPos100;
        private Components.UCAxisHor ucCylinderPos200;
        private Components.UCAxisHor ucCylinderPos400;
    }
}
