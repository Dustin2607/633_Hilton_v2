namespace App.Pages.Operation.Manual
{
    partial class UCManual1
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
            this.ucBtnSawbandAirOn = new App.Components.UCButtonOn();
            this.ucBtnLaserOn = new App.Components.UCButtonOn();
            this.ucBtnVacuumCleanerOn = new App.Components.UCButtonOnOff();
            this.ucAxisAngle = new App.Components.UCAxisHor();
            this.ucAxisSawBow = new App.Components.UCAxisVer();
            this.ucBtnSawbandOn = new App.Components.UCButtonOn();
            this.ucCVSawbandSpeed = new App.Components.UCCurrentValue2();
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
            // ucBtnSawbandAirOn
            // 
            this.ucBtnSawbandAirOn.ActStatus = ((ushort)(0));
            this.ucBtnSawbandAirOn.BackColor = System.Drawing.Color.Transparent;
            this.ucBtnSawbandAirOn.Bistable = false;
            this.ucBtnSawbandAirOn.Location = new System.Drawing.Point(670, 358);
            this.ucBtnSawbandAirOn.Name = "ucBtnSawbandAirOn";
            this.ucBtnSawbandAirOn.ObjectName = "BtnSawbandAirOn";
            this.ucBtnSawbandAirOn.OffName = "Off";
            this.ucBtnSawbandAirOn.OnName = "On";
            this.ucBtnSawbandAirOn.PlcVarNameOn = ".stgGr01HMI.stHMITOPLC.bBtnSawbandAirOn";
            this.ucBtnSawbandAirOn.Size = new System.Drawing.Size(80, 50);
            this.ucBtnSawbandAirOn.TabIndex = 59;
            // 
            // ucBtnLaserOn
            // 
            this.ucBtnLaserOn.ActStatus = ((ushort)(0));
            this.ucBtnLaserOn.BackColor = System.Drawing.Color.Transparent;
            this.ucBtnLaserOn.Bistable = false;
            this.ucBtnLaserOn.Location = new System.Drawing.Point(328, 181);
            this.ucBtnLaserOn.Name = "ucBtnLaserOn";
            this.ucBtnLaserOn.ObjectName = "BtnLaserOn";
            this.ucBtnLaserOn.OffName = "Off";
            this.ucBtnLaserOn.OnName = "On";
            this.ucBtnLaserOn.PlcVarNameOn = ".stgGr01HMI.stHMITOPLC.bBtnLaserOn";
            this.ucBtnLaserOn.Size = new System.Drawing.Size(80, 50);
            this.ucBtnLaserOn.TabIndex = 58;
            // 
            // ucBtnVacuumCleanerOn
            // 
            this.ucBtnVacuumCleanerOn.ActStatus = ((ushort)(0));
            this.ucBtnVacuumCleanerOn.BackColor = System.Drawing.Color.Transparent;
            this.ucBtnVacuumCleanerOn.Location = new System.Drawing.Point(305, 313);
            this.ucBtnVacuumCleanerOn.Name = "ucBtnVacuumCleanerOn";
            this.ucBtnVacuumCleanerOn.ObjectName = "BtnLaserOn";
            this.ucBtnVacuumCleanerOn.OffName = "Off";
            this.ucBtnVacuumCleanerOn.OnName = "On";
            this.ucBtnVacuumCleanerOn.PlcVarNameOff = ".stgGr01HMI.stHMITOPLC.bBtnVacuumCleanerOff";
            this.ucBtnVacuumCleanerOn.PlcVarNameOn = ".stgGr01HMI.stHMITOPLC.bBtnVacuumCleanerOn";
            this.ucBtnVacuumCleanerOn.Size = new System.Drawing.Size(135, 95);
            this.ucBtnVacuumCleanerOn.TabIndex = 54;
            this.ucBtnVacuumCleanerOn.Visible = false;
            // 
            // ucAxisAngle
            // 
            this.ucAxisAngle.ActStatus = ((ushort)(0));
            this.ucAxisAngle.ActValue = null;
            this.ucAxisAngle.ActValueVisable = true;
            this.ucAxisAngle.BackColor = System.Drawing.Color.Transparent;
            this.ucAxisAngle.LeftButtonName = "+";
            this.ucAxisAngle.Location = new System.Drawing.Point(305, 452);
            this.ucAxisAngle.MirrorCtrl = false;
            this.ucAxisAngle.Name = "ucAxisAngle";
            this.ucAxisAngle.ObjectName = "AxisAngle";
            this.ucAxisAngle.PlcVarNameNegative = ".stgGr01HMI.stHMITOPLC.bBtnAxisAnglePlus";
            this.ucAxisAngle.PlcVarNamePositive = ".stgGr01HMI.stHMITOPLC.bBtnAxisAngleMinus";
            this.ucAxisAngle.RightButtonName = "-";
            this.ucAxisAngle.Size = new System.Drawing.Size(250, 60);
            this.ucAxisAngle.TabIndex = 52;
            this.ucAxisAngle.Unit = "[°]";
            // 
            // ucAxisSawBow
            // 
            this.ucAxisSawBow.ActStatus = ((ushort)(0));
            this.ucAxisSawBow.ActValue = null;
            this.ucAxisSawBow.ActValueVisable = true;
            this.ucAxisSawBow.BackColor = System.Drawing.Color.Transparent;
            this.ucAxisSawBow.BottomButtonName = "+";
            this.ucAxisSawBow.Location = new System.Drawing.Point(500, 53);
            this.ucAxisSawBow.MirrorCtrl = false;
            this.ucAxisSawBow.Name = "ucAxisSawBow";
            this.ucAxisSawBow.ObjectName = "AxisSawBow";
            this.ucAxisSawBow.PlcVarNameNegative = ".stgGr01HMI.stHMITOPLC.bBtnAxisSawBowMinus";
            this.ucAxisSawBow.PlcVarNamePositive = ".stgGr01HMI.stHMITOPLC.bBtnAxisSawBowPlus";
            this.ucAxisSawBow.Size = new System.Drawing.Size(80, 180);
            this.ucAxisSawBow.TabIndex = 28;
            this.ucAxisSawBow.TopButtonName = "-";
            this.ucAxisSawBow.Unit = "[mm]";
            // 
            // ucBtnSawbandOn
            // 
            this.ucBtnSawbandOn.ActStatus = ((ushort)(0));
            this.ucBtnSawbandOn.BackColor = System.Drawing.Color.Transparent;
            this.ucBtnSawbandOn.Bistable = false;
            this.ucBtnSawbandOn.Location = new System.Drawing.Point(670, 233);
            this.ucBtnSawbandOn.Name = "ucBtnSawbandOn";
            this.ucBtnSawbandOn.ObjectName = "BtnSawbandOn";
            this.ucBtnSawbandOn.OffName = "Off";
            this.ucBtnSawbandOn.OnName = "On";
            this.ucBtnSawbandOn.PlcVarNameOn = ".stgGr01HMI.stHMITOPLC.bBtnSawbandPlus";
            this.ucBtnSawbandOn.Size = new System.Drawing.Size(80, 50);
            this.ucBtnSawbandOn.TabIndex = 60;
            // 
            // ucCVSawbandSpeed
            // 
            this.ucCVSawbandSpeed.ActValue = null;
            this.ucCVSawbandSpeed.ActValueName = "CVSawbandSpeed";
            this.ucCVSawbandSpeed.ActValueUnit = "fpm";
            this.ucCVSawbandSpeed.CaptionBackColor = System.Drawing.Color.Empty;
            this.ucCVSawbandSpeed.ColorRow2 = System.Drawing.Color.Empty;
            this.ucCVSawbandSpeed.ColorRow3 = System.Drawing.Color.Empty;
            this.ucCVSawbandSpeed.Location = new System.Drawing.Point(649, 264);
            this.ucCVSawbandSpeed.Name = "ucCVSawbandSpeed";
            this.ucCVSawbandSpeed.Size = new System.Drawing.Size(128, 45);
            this.ucCVSawbandSpeed.TabIndex = 61;
            // 
            // UCManual1
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.BackgroundImage = global::App.Properties.Resources.Sawbow_1024x572x8;
            this.Controls.Add(this.ucBtnSawbandOn);
            this.Controls.Add(this.ucCVSawbandSpeed);
            this.Controls.Add(this.ucBtnSawbandAirOn);
            this.Controls.Add(this.ucBtnLaserOn);
            this.Controls.Add(this.ucBtnVacuumCleanerOn);
            this.Controls.Add(this.ucAxisAngle);
            this.Controls.Add(this.ucAxisSawBow);
            this.Controls.Add(this.lblWindowTitle);
            this.MaximumSize = new System.Drawing.Size(1024, 572);
            this.Name = "UCManual1";
            this.Size = new System.Drawing.Size(1024, 572);
            this.Load += new System.EventHandler(this.UCManual1_Load);
            this.VisibleChanged += new System.EventHandler(this.UCManual1_VisibleChanged);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblWindowTitle;
        private Components.UCAxisVer ucAxisSawBow;
        private Components.UCAxisHor ucAxisAngle;
        private Components.UCButtonOnOff ucBtnVacuumCleanerOn;
        private Components.UCButtonOn ucBtnLaserOn;
        private Components.UCButtonOn ucBtnSawbandAirOn;
        private Components.UCButtonOn ucBtnSawbandOn;
        private Components.UCCurrentValue2 ucCVSawbandSpeed;
    }
}
