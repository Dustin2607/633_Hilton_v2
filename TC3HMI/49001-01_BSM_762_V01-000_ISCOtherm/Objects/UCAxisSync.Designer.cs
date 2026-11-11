namespace App.Components
{
    using App.Utility;

    partial class UCAxisSync
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
            this.lblObject1 = new System.Windows.Forms.Label();
            this.lblObject2 = new System.Windows.Forms.Label();
            this.rbtnCenter = new System.Windows.Forms.RadioButton();
            this.rbtnFlow = new System.Windows.Forms.RadioButton();
            this.tbxPositionAxis2 = new App.Components.CVisuTextBox();
            this.tbxPositionAxis1 = new App.Components.CVisuTextBox();
            this.btnSyncRight = new App.Components.CVisuButton();
            this.btnSyncLeft = new App.Components.CVisuButton();
            this.btnSyncOnOff = new App.Components.CVisuButton();
            this.SuspendLayout();
            // 
            // lblObject1
            // 
            this.lblObject1.AutoSize = true;
            this.lblObject1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblObject1.Location = new System.Drawing.Point(275, 4);
            this.lblObject1.Name = "lblObject1";
            this.lblObject1.Size = new System.Drawing.Size(92, 25);
            this.lblObject1.TabIndex = 10;
            this.lblObject1.Text = "----------";
            // 
            // lblObject2
            // 
            this.lblObject2.AutoSize = true;
            this.lblObject2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblObject2.Location = new System.Drawing.Point(401, 4);
            this.lblObject2.Name = "lblObject2";
            this.lblObject2.Size = new System.Drawing.Size(92, 25);
            this.lblObject2.TabIndex = 12;
            this.lblObject2.Text = "----------";
            // 
            // rbtnCenter
            // 
            this.rbtnCenter.AutoSize = true;
            this.rbtnCenter.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbtnCenter.Location = new System.Drawing.Point(87, 18);
            this.rbtnCenter.Name = "rbtnCenter";
            this.rbtnCenter.Size = new System.Drawing.Size(80, 24);
            this.rbtnCenter.TabIndex = 13;
            this.rbtnCenter.TabStop = true;
            this.rbtnCenter.Text = "Center";
            this.rbtnCenter.UseVisualStyleBackColor = true;
            this.rbtnCenter.MouseUp += new System.Windows.Forms.MouseEventHandler(this.rbtnCenter_MouseUp);
            // 
            // rbtnFlow
            // 
            this.rbtnFlow.AutoSize = true;
            this.rbtnFlow.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbtnFlow.Location = new System.Drawing.Point(607, 18);
            this.rbtnFlow.Name = "rbtnFlow";
            this.rbtnFlow.Size = new System.Drawing.Size(65, 24);
            this.rbtnFlow.TabIndex = 14;
            this.rbtnFlow.TabStop = true;
            this.rbtnFlow.Text = "Flow";
            this.rbtnFlow.UseVisualStyleBackColor = true;
            this.rbtnFlow.MouseUp += new System.Windows.Forms.MouseEventHandler(this.rbtnFlow_MouseUp);
            // 
            // tbxPositionAxis2
            // 
            this.tbxPositionAxis2.BackColor = System.Drawing.Color.White;
            this.tbxPositionAxis2.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tbxPositionAxis2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.tbxPositionAxis2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbxPositionAxis2.Location = new System.Drawing.Point(398, 35);
            this.tbxPositionAxis2.Name = "tbxPositionAxis2";
            this.tbxPositionAxis2.ReadOnly = true;
            this.tbxPositionAxis2.Size = new System.Drawing.Size(100, 23);
            this.tbxPositionAxis2.TabIndex = 11;
            this.tbxPositionAxis2.TabStop = false;
            this.tbxPositionAxis2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // tbxPositionAxis1
            // 
            this.tbxPositionAxis1.BackColor = System.Drawing.Color.White;
            this.tbxPositionAxis1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tbxPositionAxis1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.tbxPositionAxis1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbxPositionAxis1.Location = new System.Drawing.Point(272, 35);
            this.tbxPositionAxis1.Name = "tbxPositionAxis1";
            this.tbxPositionAxis1.ReadOnly = true;
            this.tbxPositionAxis1.Size = new System.Drawing.Size(100, 23);
            this.tbxPositionAxis1.TabIndex = 9;
            this.tbxPositionAxis1.TabStop = false;
            this.tbxPositionAxis1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // btnSyncRight
            // 
            this.btnSyncRight.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSyncRight.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSyncRight.Location = new System.Drawing.Point(505, 0);
            this.btnSyncRight.Name = "btnSyncRight";
            this.btnSyncRight.Size = new System.Drawing.Size(80, 60);
            this.btnSyncRight.TabIndex = 8;
            this.btnSyncRight.Text = ">";
            this.btnSyncRight.UseVisualStyleBackColor = true;
            this.btnSyncRight.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btnSyncRight_MouseDown);
            this.btnSyncRight.MouseUp += new System.Windows.Forms.MouseEventHandler(this.btnSyncRight_MouseUp);
            // 
            // btnSyncLeft
            // 
            this.btnSyncLeft.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSyncLeft.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSyncLeft.Location = new System.Drawing.Point(185, 0);
            this.btnSyncLeft.Name = "btnSyncLeft";
            this.btnSyncLeft.Size = new System.Drawing.Size(80, 60);
            this.btnSyncLeft.TabIndex = 7;
            this.btnSyncLeft.Text = "<";
            this.btnSyncLeft.UseVisualStyleBackColor = true;
            this.btnSyncLeft.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btnSyncLeft_MouseDown);
            this.btnSyncLeft.MouseUp += new System.Windows.Forms.MouseEventHandler(this.btnSyncLeft_MouseUp);
            // 
            // btnSyncOnOff
            // 
            this.btnSyncOnOff.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSyncOnOff.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSyncOnOff.Location = new System.Drawing.Point(1, 0);
            this.btnSyncOnOff.Name = "btnSyncOnOff";
            this.btnSyncOnOff.Size = new System.Drawing.Size(80, 60);
            this.btnSyncOnOff.TabIndex = 5;
            this.btnSyncOnOff.Text = "Sync";
            this.btnSyncOnOff.UseVisualStyleBackColor = false;
            this.btnSyncOnOff.MouseUp += new System.Windows.Forms.MouseEventHandler(this.btnSyncOnOff_MouseUp);
            // 
            // UCAxisSync
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnSyncLeft);
            this.Controls.Add(this.btnSyncRight);
            this.Controls.Add(this.rbtnFlow);
            this.Controls.Add(this.rbtnCenter);
            this.Controls.Add(this.lblObject2);
            this.Controls.Add(this.tbxPositionAxis2);
            this.Controls.Add(this.lblObject1);
            this.Controls.Add(this.tbxPositionAxis1);
            this.Controls.Add(this.btnSyncOnOff);
            this.Name = "UCAxisSync";
            this.Size = new System.Drawing.Size(770, 60);
            this.Load += new System.EventHandler(this.UCAxisSync_Load);
            this.Leave += new System.EventHandler(this.UCAxisSync_Leave);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private CVisuButton btnSyncOnOff;
        private CVisuButton btnSyncLeft;
        private CVisuButton btnSyncRight;
        private System.Windows.Forms.Label lblObject1;
        private CVisuTextBox tbxPositionAxis1;
        private System.Windows.Forms.Label lblObject2;
        private CVisuTextBox tbxPositionAxis2;
        private System.Windows.Forms.RadioButton rbtnCenter;
        private System.Windows.Forms.RadioButton rbtnFlow;
    }
}
