namespace App.Components
{
    using App.Utility;

    partial class UCMillingParameters
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
            this.gbxMillingParam = new System.Windows.Forms.GroupBox();
            this.tbxSpindleSpeed = new App.Components.CVisuTextBox();
            this.tbxFeedStep = new App.Components.CVisuTextBox();
            this.tbxFeedRate = new App.Components.CVisuTextBox();
            this.tbxToolLength = new App.Components.CVisuTextBox();
            this.tbxSafetyDistance = new App.Components.CVisuTextBox();
            this.tbxToolDiameter = new App.Components.CVisuTextBox();
            this.lblSpindleSpeed = new System.Windows.Forms.Label();
            this.lblFeedStep = new System.Windows.Forms.Label();
            this.lblFeedRate = new System.Windows.Forms.Label();
            this.lblToolLength = new System.Windows.Forms.Label();
            this.lblSafetyDistance = new System.Windows.Forms.Label();
            this.lblToolDiameter = new System.Windows.Forms.Label();
            this.lblrpm1 = new System.Windows.Forms.Label();
            this.lblmmr1 = new System.Windows.Forms.Label();
            this.lblmms1 = new System.Windows.Forms.Label();
            this.lblmm2 = new System.Windows.Forms.Label();
            this.lblmm3 = new System.Windows.Forms.Label();
            this.lblmm1 = new System.Windows.Forms.Label();
            this.gbxMillingParam.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbxMillingParam
            // 
            this.gbxMillingParam.BackColor = System.Drawing.SystemColors.Control;
            this.gbxMillingParam.Controls.Add(this.tbxSpindleSpeed);
            this.gbxMillingParam.Controls.Add(this.tbxFeedStep);
            this.gbxMillingParam.Controls.Add(this.tbxFeedRate);
            this.gbxMillingParam.Controls.Add(this.tbxToolLength);
            this.gbxMillingParam.Controls.Add(this.tbxSafetyDistance);
            this.gbxMillingParam.Controls.Add(this.tbxToolDiameter);
            this.gbxMillingParam.Controls.Add(this.lblSpindleSpeed);
            this.gbxMillingParam.Controls.Add(this.lblFeedStep);
            this.gbxMillingParam.Controls.Add(this.lblFeedRate);
            this.gbxMillingParam.Controls.Add(this.lblToolLength);
            this.gbxMillingParam.Controls.Add(this.lblSafetyDistance);
            this.gbxMillingParam.Controls.Add(this.lblToolDiameter);
            this.gbxMillingParam.Controls.Add(this.lblrpm1);
            this.gbxMillingParam.Controls.Add(this.lblmmr1);
            this.gbxMillingParam.Controls.Add(this.lblmms1);
            this.gbxMillingParam.Controls.Add(this.lblmm2);
            this.gbxMillingParam.Controls.Add(this.lblmm3);
            this.gbxMillingParam.Controls.Add(this.lblmm1);
            this.gbxMillingParam.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.gbxMillingParam.Location = new System.Drawing.Point(0, 0);
            this.gbxMillingParam.Name = "gbxMillingParam";
            this.gbxMillingParam.Size = new System.Drawing.Size(812, 123);
            this.gbxMillingParam.TabIndex = 3;
            this.gbxMillingParam.TabStop = false;
            this.gbxMillingParam.Text = "Milling parameters";
            // 
            // tbxSpindleSpeed
            // 
            this.tbxSpindleSpeed.BackColor = System.Drawing.Color.White;
            this.tbxSpindleSpeed.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tbxSpindleSpeed.Cursor = System.Windows.Forms.Cursors.Hand;
            this.tbxSpindleSpeed.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbxSpindleSpeed.Location = new System.Drawing.Point(366, 88);
            this.tbxSpindleSpeed.Name = "tbxSpindleSpeed";
            this.tbxSpindleSpeed.ReadOnly = true;
            this.tbxSpindleSpeed.Size = new System.Drawing.Size(100, 23);
            this.tbxSpindleSpeed.TabIndex = 25;
            this.tbxSpindleSpeed.TabStop = false;
            this.tbxSpindleSpeed.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.tbxSpindleSpeed.Click += new System.EventHandler(this.tbxSpindleSpeed_Click);
            // 
            // tbxFeedStep
            // 
            this.tbxFeedStep.BackColor = System.Drawing.Color.White;
            this.tbxFeedStep.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tbxFeedStep.Cursor = System.Windows.Forms.Cursors.Hand;
            this.tbxFeedStep.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbxFeedStep.Location = new System.Drawing.Point(366, 59);
            this.tbxFeedStep.Name = "tbxFeedStep";
            this.tbxFeedStep.ReadOnly = true;
            this.tbxFeedStep.Size = new System.Drawing.Size(100, 23);
            this.tbxFeedStep.TabIndex = 29;
            this.tbxFeedStep.TabStop = false;
            this.tbxFeedStep.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.tbxFeedStep.Click += new System.EventHandler(this.tbxFeedStep_Click);
            // 
            // tbxFeedRate
            // 
            this.tbxFeedRate.BackColor = System.Drawing.Color.White;
            this.tbxFeedRate.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tbxFeedRate.Cursor = System.Windows.Forms.Cursors.Hand;
            this.tbxFeedRate.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbxFeedRate.Location = new System.Drawing.Point(366, 30);
            this.tbxFeedRate.Name = "tbxFeedRate";
            this.tbxFeedRate.ReadOnly = true;
            this.tbxFeedRate.Size = new System.Drawing.Size(100, 23);
            this.tbxFeedRate.TabIndex = 27;
            this.tbxFeedRate.TabStop = false;
            this.tbxFeedRate.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.tbxFeedRate.Click += new System.EventHandler(this.tbxFeedRate_Click);
            // 
            // tbxToolLength
            // 
            this.tbxToolLength.BackColor = System.Drawing.Color.White;
            this.tbxToolLength.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tbxToolLength.Cursor = System.Windows.Forms.Cursors.Hand;
            this.tbxToolLength.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbxToolLength.Location = new System.Drawing.Point(115, 59);
            this.tbxToolLength.Name = "tbxToolLength";
            this.tbxToolLength.ReadOnly = true;
            this.tbxToolLength.Size = new System.Drawing.Size(100, 23);
            this.tbxToolLength.TabIndex = 18;
            this.tbxToolLength.TabStop = false;
            this.tbxToolLength.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.tbxToolLength.Click += new System.EventHandler(this.tbxToolLength_Click);
            // 
            // tbxSafetyDistance
            // 
            this.tbxSafetyDistance.BackColor = System.Drawing.Color.White;
            this.tbxSafetyDistance.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tbxSafetyDistance.Cursor = System.Windows.Forms.Cursors.Hand;
            this.tbxSafetyDistance.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbxSafetyDistance.Location = new System.Drawing.Point(663, 30);
            this.tbxSafetyDistance.Name = "tbxSafetyDistance";
            this.tbxSafetyDistance.ReadOnly = true;
            this.tbxSafetyDistance.Size = new System.Drawing.Size(100, 23);
            this.tbxSafetyDistance.TabIndex = 12;
            this.tbxSafetyDistance.TabStop = false;
            this.tbxSafetyDistance.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.tbxSafetyDistance.Click += new System.EventHandler(this.tbxSafetyDistance_Click);
            // 
            // tbxToolDiameter
            // 
            this.tbxToolDiameter.BackColor = System.Drawing.Color.White;
            this.tbxToolDiameter.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tbxToolDiameter.Cursor = System.Windows.Forms.Cursors.Hand;
            this.tbxToolDiameter.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbxToolDiameter.Location = new System.Drawing.Point(115, 30);
            this.tbxToolDiameter.Name = "tbxToolDiameter";
            this.tbxToolDiameter.ReadOnly = true;
            this.tbxToolDiameter.Size = new System.Drawing.Size(100, 23);
            this.tbxToolDiameter.TabIndex = 10;
            this.tbxToolDiameter.TabStop = false;
            this.tbxToolDiameter.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.tbxToolDiameter.Click += new System.EventHandler(this.tbxToolDiameter_Click);
            // 
            // lblSpindleSpeed
            // 
            this.lblSpindleSpeed.AllowDrop = true;
            this.lblSpindleSpeed.BackColor = System.Drawing.Color.Transparent;
            this.lblSpindleSpeed.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F);
            this.lblSpindleSpeed.Location = new System.Drawing.Point(264, 94);
            this.lblSpindleSpeed.Name = "lblSpindleSpeed";
            this.lblSpindleSpeed.Size = new System.Drawing.Size(105, 17);
            this.lblSpindleSpeed.TabIndex = 24;
            this.lblSpindleSpeed.Text = "Spindle speed:";
            this.lblSpindleSpeed.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblFeedStep
            // 
            this.lblFeedStep.AllowDrop = true;
            this.lblFeedStep.BackColor = System.Drawing.Color.Transparent;
            this.lblFeedStep.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F);
            this.lblFeedStep.Location = new System.Drawing.Point(264, 65);
            this.lblFeedStep.Name = "lblFeedStep";
            this.lblFeedStep.Size = new System.Drawing.Size(105, 17);
            this.lblFeedStep.TabIndex = 28;
            this.lblFeedStep.Text = "Feed step:";
            this.lblFeedStep.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblFeedRate
            // 
            this.lblFeedRate.BackColor = System.Drawing.Color.Transparent;
            this.lblFeedRate.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F);
            this.lblFeedRate.Location = new System.Drawing.Point(264, 36);
            this.lblFeedRate.Name = "lblFeedRate";
            this.lblFeedRate.Size = new System.Drawing.Size(105, 17);
            this.lblFeedRate.TabIndex = 26;
            this.lblFeedRate.Text = "Feed rate:";
            this.lblFeedRate.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblToolLength
            // 
            this.lblToolLength.AllowDrop = true;
            this.lblToolLength.BackColor = System.Drawing.Color.Transparent;
            this.lblToolLength.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F);
            this.lblToolLength.Location = new System.Drawing.Point(13, 65);
            this.lblToolLength.Name = "lblToolLength";
            this.lblToolLength.Size = new System.Drawing.Size(105, 17);
            this.lblToolLength.TabIndex = 17;
            this.lblToolLength.Text = "Tool length:";
            this.lblToolLength.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblSafetyDistance
            // 
            this.lblSafetyDistance.AllowDrop = true;
            this.lblSafetyDistance.BackColor = System.Drawing.Color.Transparent;
            this.lblSafetyDistance.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F);
            this.lblSafetyDistance.Location = new System.Drawing.Point(545, 36);
            this.lblSafetyDistance.Name = "lblSafetyDistance";
            this.lblSafetyDistance.Size = new System.Drawing.Size(120, 17);
            this.lblSafetyDistance.TabIndex = 11;
            this.lblSafetyDistance.Text = "Safety distance:";
            this.lblSafetyDistance.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblToolDiameter
            // 
            this.lblToolDiameter.BackColor = System.Drawing.Color.Transparent;
            this.lblToolDiameter.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F);
            this.lblToolDiameter.Location = new System.Drawing.Point(13, 36);
            this.lblToolDiameter.Name = "lblToolDiameter";
            this.lblToolDiameter.Size = new System.Drawing.Size(105, 17);
            this.lblToolDiameter.TabIndex = 9;
            this.lblToolDiameter.Text = "Tool diameter:";
            this.lblToolDiameter.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblrpm1
            // 
            this.lblrpm1.AllowDrop = true;
            this.lblrpm1.AutoSize = true;
            this.lblrpm1.BackColor = System.Drawing.Color.Transparent;
            this.lblrpm1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F);
            this.lblrpm1.Location = new System.Drawing.Point(468, 94);
            this.lblrpm1.Name = "lblrpm1";
            this.lblrpm1.Size = new System.Drawing.Size(32, 17);
            this.lblrpm1.TabIndex = 32;
            this.lblrpm1.Text = "rpm";
            // 
            // lblmmr1
            // 
            this.lblmmr1.AllowDrop = true;
            this.lblmmr1.AutoSize = true;
            this.lblmmr1.BackColor = System.Drawing.Color.Transparent;
            this.lblmmr1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F);
            this.lblmmr1.Location = new System.Drawing.Point(468, 65);
            this.lblmmr1.Name = "lblmmr1";
            this.lblmmr1.Size = new System.Drawing.Size(39, 17);
            this.lblmmr1.TabIndex = 31;
            this.lblmmr1.Text = "inch/r";
            // 
            // lblmms1
            // 
            this.lblmms1.AllowDrop = true;
            this.lblmms1.AutoSize = true;
            this.lblmms1.BackColor = System.Drawing.Color.Transparent;
            this.lblmms1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F);
            this.lblmms1.Location = new System.Drawing.Point(468, 36);
            this.lblmms1.Name = "lblmms1";
            this.lblmms1.Size = new System.Drawing.Size(41, 17);
            this.lblmms1.TabIndex = 30;
            this.lblmms1.Text = "inch/s";
            // 
            // lblmm2
            // 
            this.lblmm2.AllowDrop = true;
            this.lblmm2.AutoSize = true;
            this.lblmm2.BackColor = System.Drawing.Color.Transparent;
            this.lblmm2.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F);
            this.lblmm2.Location = new System.Drawing.Point(218, 65);
            this.lblmm2.Name = "lblmm2";
            this.lblmm2.Size = new System.Drawing.Size(30, 17);
            this.lblmm2.TabIndex = 22;
            this.lblmm2.Text = "inch";
            // 
            // lblmm3
            // 
            this.lblmm3.AllowDrop = true;
            this.lblmm3.AutoSize = true;
            this.lblmm3.BackColor = System.Drawing.Color.Transparent;
            this.lblmm3.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F);
            this.lblmm3.Location = new System.Drawing.Point(765, 36);
            this.lblmm3.Name = "lblmm3";
            this.lblmm3.Size = new System.Drawing.Size(30, 17);
            this.lblmm3.TabIndex = 20;
            this.lblmm3.Text = "inch";
            // 
            // lblmm1
            // 
            this.lblmm1.AllowDrop = true;
            this.lblmm1.AutoSize = true;
            this.lblmm1.BackColor = System.Drawing.Color.Transparent;
            this.lblmm1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F);
            this.lblmm1.Location = new System.Drawing.Point(218, 36);
            this.lblmm1.Name = "lblmm1";
            this.lblmm1.Size = new System.Drawing.Size(30, 17);
            this.lblmm1.TabIndex = 19;
            this.lblmm1.Text = "inch";
            // 
            // UCMillingParameters
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.Controls.Add(this.gbxMillingParam);
            this.Name = "UCMillingParameters";
            this.Size = new System.Drawing.Size(812, 123);
            this.Load += new System.EventHandler(this.UCWeldingParameters_Load);
            this.gbxMillingParam.ResumeLayout(false);
            this.gbxMillingParam.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbxMillingParam;
        private CVisuTextBox tbxToolDiameter;
        private System.Windows.Forms.Label lblToolDiameter;
        private CVisuTextBox tbxSafetyDistance;
        private System.Windows.Forms.Label lblSafetyDistance;
        private CVisuTextBox tbxToolLength;
        private System.Windows.Forms.Label lblToolLength;
        private System.Windows.Forms.Label lblmm3;
        private System.Windows.Forms.Label lblmm1;
        private System.Windows.Forms.Label lblmm2;
        private System.Windows.Forms.Label lblrpm1;
        private System.Windows.Forms.Label lblmmr1;
        private System.Windows.Forms.Label lblmms1;
        private CVisuTextBox tbxFeedStep;
        private System.Windows.Forms.Label lblFeedStep;
        private CVisuTextBox tbxFeedRate;
        private System.Windows.Forms.Label lblFeedRate;
        private CVisuTextBox tbxSpindleSpeed;
        private System.Windows.Forms.Label lblSpindleSpeed;
    }
}
