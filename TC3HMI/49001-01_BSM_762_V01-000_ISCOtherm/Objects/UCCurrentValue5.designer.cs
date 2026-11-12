namespace App.Components
{
    partial class UCCurrentValue5
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
            this.lblActValue = new System.Windows.Forms.Label();
            this.cActValueGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // cActValueGroupBox
            // 
            this.cActValueGroupBox.Controls.Add(this.lblActValue);
            this.cActValueGroupBox.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cActValueGroupBox.Location = new System.Drawing.Point(0, 0);
            this.cActValueGroupBox.Name = "cActValueGroupBox";
            this.cActValueGroupBox.Size = new System.Drawing.Size(320, 40);
            this.cActValueGroupBox.TabIndex = 0;
            this.cActValueGroupBox.TabStop = false;
            // 
            // lblActValue
            // 
            this.lblActValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.25F);
            this.lblActValue.Location = new System.Drawing.Point(3, 2);
            this.lblActValue.Name = "lblActValue";
            this.lblActValue.Size = new System.Drawing.Size(320, 40);
            this.lblActValue.TabIndex = 1;
            this.lblActValue.Text = "-------";
            this.lblActValue.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // UCCurrentValue5
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.Controls.Add(this.cActValueGroupBox);
            this.Name = "UCCurrentValue5";
            this.Size = new System.Drawing.Size(320, 40);
            this.Load += new System.EventHandler(this.UCCurrentValue_Load);
            this.cActValueGroupBox.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private CVisuGroupBox cActValueGroupBox;
        private System.Windows.Forms.Label lblActValue;
    }
}
