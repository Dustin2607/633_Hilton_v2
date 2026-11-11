namespace App.Components
{
    partial class UCCurrentValue4
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
            this.lblActValue3 = new System.Windows.Forms.Label();
            this.lblEqual = new System.Windows.Forms.Label();
            this.lblActValue2 = new System.Windows.Forms.Label();
            this.lblActValueUnit = new System.Windows.Forms.Label();
            this.lblActValue1 = new System.Windows.Forms.Label();
            this.lblActValueName = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cActValueGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // cActValueGroupBox
            // 
            this.cActValueGroupBox.Controls.Add(this.label1);
            this.cActValueGroupBox.Controls.Add(this.lblActValue3);
            this.cActValueGroupBox.Controls.Add(this.lblEqual);
            this.cActValueGroupBox.Controls.Add(this.lblActValue2);
            this.cActValueGroupBox.Controls.Add(this.lblActValueUnit);
            this.cActValueGroupBox.Controls.Add(this.lblActValue1);
            this.cActValueGroupBox.Controls.Add(this.lblActValueName);
            this.cActValueGroupBox.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cActValueGroupBox.Location = new System.Drawing.Point(0, 0);
            this.cActValueGroupBox.Name = "cActValueGroupBox";
            this.cActValueGroupBox.Size = new System.Drawing.Size(360, 30);
            this.cActValueGroupBox.TabIndex = 0;
            this.cActValueGroupBox.TabStop = false;
            // 
            // lblActValue3
            // 
            this.lblActValue3.Location = new System.Drawing.Point(257, 9);
            this.lblActValue3.Name = "lblActValue3";
            this.lblActValue3.Size = new System.Drawing.Size(50, 17);
            this.lblActValue3.TabIndex = 22;
            this.lblActValue3.Text = "-------";
            this.lblActValue3.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lblEqual
            // 
            this.lblEqual.Location = new System.Drawing.Point(234, 9);
            this.lblEqual.Name = "lblEqual";
            this.lblEqual.Size = new System.Drawing.Size(20, 17);
            this.lblEqual.TabIndex = 23;
            this.lblEqual.Text = "=";
            this.lblEqual.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lblActValue2
            // 
            this.lblActValue2.Location = new System.Drawing.Point(181, 9);
            this.lblActValue2.Name = "lblActValue2";
            this.lblActValue2.Size = new System.Drawing.Size(50, 17);
            this.lblActValue2.TabIndex = 24;
            this.lblActValue2.Text = "-------";
            this.lblActValue2.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lblActValueUnit
            // 
            this.lblActValueUnit.Location = new System.Drawing.Point(323, 9);
            this.lblActValueUnit.Name = "lblActValueUnit";
            this.lblActValueUnit.Size = new System.Drawing.Size(35, 17);
            this.lblActValueUnit.TabIndex = 26;
            this.lblActValueUnit.Text = "Unit";
            // 
            // lblActValue1
            // 
            this.lblActValue1.Location = new System.Drawing.Point(100, 9);
            this.lblActValue1.Name = "lblActValue1";
            this.lblActValue1.Size = new System.Drawing.Size(50, 17);
            this.lblActValue1.TabIndex = 27;
            this.lblActValue1.Text = "-------";
            this.lblActValue1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lblActValueName
            // 
            this.lblActValueName.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.lblActValueName.Location = new System.Drawing.Point(2, 9);
            this.lblActValueName.Name = "lblActValueName";
            this.lblActValueName.Size = new System.Drawing.Size(95, 17);
            this.lblActValueName.TabIndex = 28;
            this.lblActValueName.Text = "ActValueName:";
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(159, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(20, 17);
            this.label1.TabIndex = 29;
            this.label1.Text = "-";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // UCCurrentValue4
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.Controls.Add(this.cActValueGroupBox);
            this.Name = "UCCurrentValue4";
            this.Size = new System.Drawing.Size(360, 25);
            this.Load += new System.EventHandler(this.UCCurrentValue_Load);
            this.cActValueGroupBox.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private CVisuGroupBox cActValueGroupBox;
        private System.Windows.Forms.Label lblActValue3;
        private System.Windows.Forms.Label lblEqual;
        private System.Windows.Forms.Label lblActValue2;
        private System.Windows.Forms.Label lblActValueUnit;
        private System.Windows.Forms.Label lblActValue1;
        private System.Windows.Forms.Label lblActValueName;
        private System.Windows.Forms.Label label1;
    }
}
