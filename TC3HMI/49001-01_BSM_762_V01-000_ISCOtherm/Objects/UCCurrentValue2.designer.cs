namespace App.Components
{
    partial class UCCurrentValue2
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
            this.cActValueGroupBox = new App.Components.CVisuGroupBox();
            this.lblActValueUnit = new System.Windows.Forms.Label();
            this.lblActValue = new System.Windows.Forms.Label();
            this.lblActValueName = new System.Windows.Forms.Label();
            this.cActValueGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // cActValueGroupBox
            // 
            this.cActValueGroupBox.Controls.Add(this.lblActValueUnit);
            this.cActValueGroupBox.Controls.Add(this.lblActValue);
            this.cActValueGroupBox.Controls.Add(this.lblActValueName);
            this.cActValueGroupBox.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cActValueGroupBox.Location = new System.Drawing.Point(0, 0);
            this.cActValueGroupBox.Name = "cActValueGroupBox";
            this.cActValueGroupBox.Size = new System.Drawing.Size(128, 45);
            this.cActValueGroupBox.TabIndex = 0;
            this.cActValueGroupBox.TabStop = false;
            // 
            // lblActValueUnit
            // 
            this.lblActValueUnit.Location = new System.Drawing.Point(79, 22);
            this.lblActValueUnit.Name = "lblActValueUnit";
            this.lblActValueUnit.Size = new System.Drawing.Size(47, 20);
            this.lblActValueUnit.TabIndex = 0;
            this.lblActValueUnit.Text = "Unit";
            this.lblActValueUnit.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblActValue
            // 
            this.lblActValue.Location = new System.Drawing.Point(1, 22);
            this.lblActValue.Name = "lblActValue";
            this.lblActValue.Size = new System.Drawing.Size(75, 20);
            this.lblActValue.TabIndex = 1;
            this.lblActValue.Text = "-------";
            this.lblActValue.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblActValueName
            // 
            this.lblActValueName.Location = new System.Drawing.Point(1, 2);
            this.lblActValueName.Name = "lblActValueName";
            this.lblActValueName.Size = new System.Drawing.Size(125, 20);
            this.lblActValueName.TabIndex = 2;
            this.lblActValueName.Text = "ActValueName";
            this.lblActValueName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // UCCurrentValue2
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.Controls.Add(this.cActValueGroupBox);
            this.Name = "UCCurrentValue2";
            this.Size = new System.Drawing.Size(128, 45);
            this.Load += new System.EventHandler(this.UCCurrentValue_Load);
            this.cActValueGroupBox.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private CVisuGroupBox cActValueGroupBox;
        private System.Windows.Forms.Label lblActValueName;
        private System.Windows.Forms.Label lblActValueUnit;
        private System.Windows.Forms.Label lblActValue;
    }
}
