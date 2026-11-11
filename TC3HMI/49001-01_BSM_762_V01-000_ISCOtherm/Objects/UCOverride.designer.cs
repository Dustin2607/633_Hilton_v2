namespace App.Components
{
    partial class UCOverride
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
            this.tbxValue = new App.Components.CVisuTextBoxVar();
            this.btnPositive = new App.Components.CVisuButton();
            this.lblUnit = new System.Windows.Forms.Label();
            this.btnNegative = new App.Components.CVisuButton();
            this.SuspendLayout();
            // 
            // lblObject
            // 
            this.lblObject.Font = new System.Drawing.Font("Tahoma", 9F);
            this.lblObject.Location = new System.Drawing.Point(82, 1);
            this.lblObject.Name = "lblObject";
            this.lblObject.Size = new System.Drawing.Size(85, 18);
            this.lblObject.TabIndex = 0;
            this.lblObject.Text = "----------";
            this.lblObject.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // tbxValue
            // 
            this.tbxValue.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbxValue.BackColor = System.Drawing.Color.White;
            this.tbxValue.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tbxValue.Cursor = System.Windows.Forms.Cursors.Hand;
            this.tbxValue.Disable = false;
            this.tbxValue.Font = new System.Drawing.Font("Tahoma", 9F);
            this.tbxValue.InchOn = false;
            this.tbxValue.Location = new System.Drawing.Point(82, 23);
            this.tbxValue.Multiline = true;
            this.tbxValue.Name = "tbxValue";
            this.tbxValue.PlcVarName = "";
            this.tbxValue.ReadOnly = true;
            this.tbxValue.Scaling = App.Components.CVisuTextBoxVar.ScalingUnit.x1;
            this.tbxValue.Size = new System.Drawing.Size(85, 20);
            this.tbxValue.TabIndex = 13;
            this.tbxValue.TabStop = false;
            this.tbxValue.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tbxValue.UserLevel = App.Security.CUserLevel.None;
            this.tbxValue.VarMaxLimit = "100";
            this.tbxValue.VarMinLimit = "0";
            this.tbxValue.VarType = 5;
            // 
            // btnPositive
            // 
            this.btnPositive.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPositive.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold);
            this.btnPositive.Location = new System.Drawing.Point(169, 0);
            this.btnPositive.Name = "btnPositive";
            this.btnPositive.Size = new System.Drawing.Size(80, 60);
            this.btnPositive.TabIndex = 12;
            this.btnPositive.Text = "Plus";
            this.btnPositive.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btnPositive_MouseDown);
            this.btnPositive.MouseUp += new System.Windows.Forms.MouseEventHandler(this.btnPositive_MouseUp);
            // 
            // lblUnit
            // 
            this.lblUnit.BackColor = System.Drawing.SystemColors.Control;
            this.lblUnit.Font = new System.Drawing.Font("Tahoma", 9F);
            this.lblUnit.Location = new System.Drawing.Point(85, 42);
            this.lblUnit.Name = "lblUnit";
            this.lblUnit.Size = new System.Drawing.Size(78, 20);
            this.lblUnit.TabIndex = 14;
            this.lblUnit.Text = "[---]";
            this.lblUnit.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // btnNegative
            // 
            this.btnNegative.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnNegative.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold);
            this.btnNegative.Location = new System.Drawing.Point(0, 0);
            this.btnNegative.Name = "btnNegative";
            this.btnNegative.Size = new System.Drawing.Size(80, 60);
            this.btnNegative.TabIndex = 10;
            this.btnNegative.Text = "Minus";
            this.btnNegative.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btnNegative_MouseDown);
            this.btnNegative.MouseUp += new System.Windows.Forms.MouseEventHandler(this.btnNegative_MouseUp);
            // 
            // UCOverride
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.Controls.Add(this.lblObject);
            this.Controls.Add(this.tbxValue);
            this.Controls.Add(this.btnPositive);
            this.Controls.Add(this.lblUnit);
            this.Controls.Add(this.btnNegative);
            this.Name = "UCOverride";
            this.Size = new System.Drawing.Size(250, 60);
            this.Load += new System.EventHandler(this.UCOverride_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblObject;
        private CVisuButton btnPositive;
        private System.Windows.Forms.Label lblUnit;
        private CVisuButton btnNegative;
        public CVisuTextBoxVar tbxValue;
    }
}
