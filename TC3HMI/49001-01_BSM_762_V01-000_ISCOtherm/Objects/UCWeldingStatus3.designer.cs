namespace App.Components
{
    using App.Utility;

    partial class UCWeldingStatus3
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
            this.lblPara4 = new System.Windows.Forms.Label();
            this.lblPara20 = new System.Windows.Forms.Label();
            this.lblPara15 = new System.Windows.Forms.Label();
            this.tbxPara3 = new App.Components.CVisuTextBoxVar();
            this.tbxPara4 = new App.Components.CVisuTextBoxVar();
            this.gbxWeldingStatus = new App.Components.CVisuGroupBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.tbxPara1 = new App.Components.CVisuTextBoxVar();
            this.lblPara0 = new System.Windows.Forms.Label();
            this.tbxPara2 = new App.Components.CVisuTextBoxVar();
            this.label13 = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.gbxWeldingStatus.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblPara4
            // 
            this.lblPara4.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.lblPara4.Location = new System.Drawing.Point(2, 69);
            this.lblPara4.Name = "lblPara4";
            this.lblPara4.Size = new System.Drawing.Size(112, 20);
            this.lblPara4.TabIndex = 58;
            this.lblPara4.Text = "Welding:";
            // 
            // lblPara20
            // 
            this.lblPara20.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.lblPara20.Location = new System.Drawing.Point(2, 98);
            this.lblPara20.Name = "lblPara20";
            this.lblPara20.Size = new System.Drawing.Size(135, 20);
            this.lblPara20.TabIndex = 59;
            this.lblPara20.Text = "Current phase:";
            // 
            // lblPara15
            // 
            this.lblPara15.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.lblPara15.Location = new System.Drawing.Point(120, 98);
            this.lblPara15.Name = "lblPara15";
            this.lblPara15.Size = new System.Drawing.Size(212, 20);
            this.lblPara15.TabIndex = 60;
            this.lblPara15.Text = "----------";
            this.lblPara15.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // tbxPara3
            // 
            this.tbxPara3.BackColor = System.Drawing.Color.White;
            this.tbxPara3.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tbxPara3.Cursor = System.Windows.Forms.Cursors.Hand;
            this.tbxPara3.Disable = false;
            this.tbxPara3.Enabled = false;
            this.tbxPara3.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold);
            this.tbxPara3.Location = new System.Drawing.Point(114, 66);
            this.tbxPara3.Multiline = true;
            this.tbxPara3.Name = "tbxPara3";
            this.tbxPara3.PlcVarName = "";
            this.tbxPara3.ReadOnly = true;
            this.tbxPara3.Scaling = App.Components.CVisuTextBoxVar.ScalingUnit.x1;
            this.tbxPara3.Size = new System.Drawing.Size(100, 23);
            this.tbxPara3.TabIndex = 21;
            this.tbxPara3.TabStop = false;
            this.tbxPara3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tbxPara3.VarMaxLimit = "500";
            this.tbxPara3.VarMinLimit = "0";
            this.tbxPara3.VarType = 3;
            // 
            // tbxPara4
            // 
            this.tbxPara4.BackColor = System.Drawing.Color.White;
            this.tbxPara4.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tbxPara4.Cursor = System.Windows.Forms.Cursors.Hand;
            this.tbxPara4.Disable = false;
            this.tbxPara4.Enabled = false;
            this.tbxPara4.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold);
            this.tbxPara4.Location = new System.Drawing.Point(226, 66);
            this.tbxPara4.Multiline = true;
            this.tbxPara4.Name = "tbxPara4";
            this.tbxPara4.PlcVarName = "";
            this.tbxPara4.ReadOnly = true;
            this.tbxPara4.Scaling = App.Components.CVisuTextBoxVar.ScalingUnit.x1;
            this.tbxPara4.Size = new System.Drawing.Size(100, 23);
            this.tbxPara4.TabIndex = 36;
            this.tbxPara4.TabStop = false;
            this.tbxPara4.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tbxPara4.VarMaxLimit = "1000";
            this.tbxPara4.VarMinLimit = "0";
            this.tbxPara4.VarType = 3;
            // 
            // gbxWeldingStatus
            // 
            this.gbxWeldingStatus.Controls.Add(this.label11);
            this.gbxWeldingStatus.Controls.Add(this.label12);
            this.gbxWeldingStatus.Controls.Add(this.tbxPara1);
            this.gbxWeldingStatus.Controls.Add(this.lblPara0);
            this.gbxWeldingStatus.Controls.Add(this.tbxPara2);
            this.gbxWeldingStatus.Controls.Add(this.label13);
            this.gbxWeldingStatus.Controls.Add(this.label21);
            this.gbxWeldingStatus.Controls.Add(this.label20);
            this.gbxWeldingStatus.Controls.Add(this.label14);
            this.gbxWeldingStatus.Controls.Add(this.tbxPara3);
            this.gbxWeldingStatus.Controls.Add(this.lblPara4);
            this.gbxWeldingStatus.Controls.Add(this.tbxPara4);
            this.gbxWeldingStatus.Controls.Add(this.lblPara20);
            this.gbxWeldingStatus.Controls.Add(this.lblPara15);
            this.gbxWeldingStatus.Cursor = System.Windows.Forms.Cursors.Hand;
            this.gbxWeldingStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.gbxWeldingStatus.Location = new System.Drawing.Point(0, 0);
            this.gbxWeldingStatus.Name = "gbxWeldingStatus";
            this.gbxWeldingStatus.Size = new System.Drawing.Size(380, 130);
            this.gbxWeldingStatus.TabIndex = 0;
            this.gbxWeldingStatus.TabStop = false;
            this.gbxWeldingStatus.Text = "Welding status";
            // 
            // label11
            // 
            this.label11.Font = new System.Drawing.Font("Tahoma", 8F);
            this.label11.Location = new System.Drawing.Point(215, 38);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(10, 20);
            this.label11.TabIndex = 0;
            this.label11.Text = "/";
            // 
            // label12
            // 
            this.label12.Font = new System.Drawing.Font("Tahoma", 8F);
            this.label12.Location = new System.Drawing.Point(326, 38);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(40, 20);
            this.label12.TabIndex = 1;
            this.label12.Text = "s";
            // 
            // tbxPara1
            // 
            this.tbxPara1.BackColor = System.Drawing.Color.White;
            this.tbxPara1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tbxPara1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.tbxPara1.Disable = false;
            this.tbxPara1.Enabled = false;
            this.tbxPara1.Font = new System.Drawing.Font("Tahoma", 12F);
            this.tbxPara1.Location = new System.Drawing.Point(114, 35);
            this.tbxPara1.Multiline = true;
            this.tbxPara1.Name = "tbxPara1";
            this.tbxPara1.PlcVarName = "";
            this.tbxPara1.ReadOnly = true;
            this.tbxPara1.Scaling = App.Components.CVisuTextBoxVar.ScalingUnit.x1;
            this.tbxPara1.Size = new System.Drawing.Size(100, 23);
            this.tbxPara1.TabIndex = 43;
            this.tbxPara1.TabStop = false;
            this.tbxPara1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tbxPara1.VarMaxLimit = "4000";
            this.tbxPara1.VarMinLimit = "0";
            this.tbxPara1.VarType = 3;
            // 
            // lblPara0
            // 
            this.lblPara0.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.lblPara0.Location = new System.Drawing.Point(2, 38);
            this.lblPara0.Name = "lblPara0";
            this.lblPara0.Size = new System.Drawing.Size(112, 20);
            this.lblPara0.TabIndex = 44;
            this.lblPara0.Text = "Preheating:";
            // 
            // tbxPara2
            // 
            this.tbxPara2.BackColor = System.Drawing.Color.White;
            this.tbxPara2.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tbxPara2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.tbxPara2.Disable = false;
            this.tbxPara2.Enabled = false;
            this.tbxPara2.Font = new System.Drawing.Font("Tahoma", 12F);
            this.tbxPara2.Location = new System.Drawing.Point(226, 35);
            this.tbxPara2.Multiline = true;
            this.tbxPara2.Name = "tbxPara2";
            this.tbxPara2.PlcVarName = "";
            this.tbxPara2.ReadOnly = true;
            this.tbxPara2.Scaling = App.Components.CVisuTextBoxVar.ScalingUnit.x1;
            this.tbxPara2.Size = new System.Drawing.Size(100, 23);
            this.tbxPara2.TabIndex = 44;
            this.tbxPara2.TabStop = false;
            this.tbxPara2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tbxPara2.VarMaxLimit = "4000";
            this.tbxPara2.VarMinLimit = "0";
            this.tbxPara2.VarType = 3;
            // 
            // label13
            // 
            this.label13.Font = new System.Drawing.Font("Tahoma", 8F);
            this.label13.Location = new System.Drawing.Point(216, 67);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(10, 20);
            this.label13.TabIndex = 45;
            this.label13.Text = "/";
            // 
            // label21
            // 
            this.label21.Font = new System.Drawing.Font("Tahoma", 8F);
            this.label21.Location = new System.Drawing.Point(226, 15);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(100, 18);
            this.label21.TabIndex = 49;
            this.label21.Text = "Reference ";
            this.label21.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label20
            // 
            this.label20.Font = new System.Drawing.Font("Tahoma", 8F);
            this.label20.Location = new System.Drawing.Point(114, 15);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(100, 18);
            this.label20.TabIndex = 50;
            this.label20.Text = "Current";
            this.label20.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label14
            // 
            this.label14.Font = new System.Drawing.Font("Tahoma", 8F);
            this.label14.Location = new System.Drawing.Point(326, 69);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(40, 20);
            this.label14.TabIndex = 51;
            this.label14.Text = "s";
            // 
            // UCWeldingStatus3
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.Controls.Add(this.gbxWeldingStatus);
            this.Name = "UCWeldingStatus3";
            this.Size = new System.Drawing.Size(380, 130);
            this.Load += new System.EventHandler(this.UCMachineParameters_Load);
            this.gbxWeldingStatus.ResumeLayout(false);
            this.gbxWeldingStatus.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private CVisuGroupBox gbxWeldingStatus;
        public CVisuTextBoxVar tbxPara3;
        public CVisuTextBoxVar tbxPara4;
        private System.Windows.Forms.Label lblPara4;
        private System.Windows.Forms.Label lblPara20;
        private System.Windows.Forms.Label lblPara15;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        public CVisuTextBoxVar tbxPara1;
        private System.Windows.Forms.Label lblPara0;
        public CVisuTextBoxVar tbxPara2;


    }
}
