namespace App.Components
{

    partial class UCCtrlVertical
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
            this.lblObject = new System.Windows.Forms.Label();
            this.btnPositive = new App.Components.CVisuButton();
            this.btnNegative = new App.Components.CVisuButton();
            this.lblUnit = new System.Windows.Forms.Label();
            this.tbxValue = new App.Components.CVisuTextBox();
            this.SuspendLayout();
            // 
            // lblObject
            // 
            this.lblObject.BackColor = System.Drawing.SystemColors.Control;
            this.lblObject.Font = new System.Drawing.Font("Tahoma", 9F);
            this.lblObject.Location = new System.Drawing.Point(0, 62);
            this.lblObject.Name = "lblObject";
            this.lblObject.Size = new System.Drawing.Size(80, 19);
            this.lblObject.TabIndex = 0;
            this.lblObject.Text = "----------";
            this.lblObject.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // btnPositive
            // 
            this.btnPositive.BackColor = System.Drawing.SystemColors.Control;
            this.btnPositive.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPositive.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold);
            this.btnPositive.Location = new System.Drawing.Point(0, 0);
            this.btnPositive.Name = "btnPositive";
            this.btnPositive.Size = new System.Drawing.Size(80, 60);
            this.btnPositive.TabIndex = 1;
            this.btnPositive.Text = "+";
            this.btnPositive.UseVisualStyleBackColor = false;
            this.btnPositive.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btnPositive_MouseDown);
            this.btnPositive.MouseUp += new System.Windows.Forms.MouseEventHandler(this.btnPositive_MouseUp);
            // 
            // btnNegative
            // 
            this.btnNegative.BackColor = System.Drawing.SystemColors.Control;
            this.btnNegative.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnNegative.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold);
            this.btnNegative.Location = new System.Drawing.Point(0, 120);
            this.btnNegative.Name = "btnNegative";
            this.btnNegative.Size = new System.Drawing.Size(80, 60);
            this.btnNegative.TabIndex = 0;
            this.btnNegative.Text = "-";
            this.btnNegative.UseVisualStyleBackColor = false;
            this.btnNegative.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btnNegative_MouseDown);
            this.btnNegative.MouseUp += new System.Windows.Forms.MouseEventHandler(this.btnNegative_MouseUp);
            // 
            // lblUnit
            // 
            this.lblUnit.BackColor = System.Drawing.SystemColors.Control;
            this.lblUnit.Font = new System.Drawing.Font("Tahoma", 9F);
            this.lblUnit.Location = new System.Drawing.Point(0, 101);
            this.lblUnit.Name = "lblUnit";
            this.lblUnit.Size = new System.Drawing.Size(80, 19);
            this.lblUnit.TabIndex = 8;
            this.lblUnit.Text = "[---]";
            this.lblUnit.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // tbxValue
            // 
            this.tbxValue.BackColor = System.Drawing.SystemColors.Control;
            this.tbxValue.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tbxValue.Cursor = System.Windows.Forms.Cursors.Hand;
            this.tbxValue.Font = new System.Drawing.Font("Tahoma", 9F);
            this.tbxValue.Location = new System.Drawing.Point(0, 81);
            this.tbxValue.Multiline = true;
            this.tbxValue.Name = "tbxValue";
            this.tbxValue.ReadOnly = true;
            this.tbxValue.Size = new System.Drawing.Size(80, 20);
            this.tbxValue.TabIndex = 7;
            this.tbxValue.TabStop = false;
            this.tbxValue.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // UCCtrlVertical
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.lblObject);
            this.Controls.Add(this.tbxValue);
            this.Controls.Add(this.btnPositive);
            this.Controls.Add(this.lblUnit);
            this.Controls.Add(this.btnNegative);
            this.Name = "UCCtrlVertical";
            this.Size = new System.Drawing.Size(80, 180);
            this.Load += new System.EventHandler(this.UCCtrlHorizontal_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private CVisuButton btnNegative;
        private CVisuButton btnPositive;
        private System.Windows.Forms.Label lblObject;
        private System.Windows.Forms.Label lblUnit;
        private CVisuTextBox tbxValue;
    }
}
