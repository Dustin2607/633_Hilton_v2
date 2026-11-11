namespace App.Components
{

    partial class UCButtonMultiOn
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
            this.btnOn = new App.Components.CVisuButton();
            this.SuspendLayout();
            // 
            // lblObject
            // 
            this.lblObject.BackColor = System.Drawing.SystemColors.Control;
            this.lblObject.Font = new System.Drawing.Font("Tahoma", 9F);
            this.lblObject.Location = new System.Drawing.Point(9, 61);
            this.lblObject.Name = "lblObject";
            this.lblObject.Size = new System.Drawing.Size(80, 18);
            this.lblObject.TabIndex = 0;
            this.lblObject.Text = "----------";
            this.lblObject.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // btnOn
            // 
            this.btnOn.BackColor = System.Drawing.SystemColors.Control;
            this.btnOn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnOn.Font = new System.Drawing.Font("Tahoma", 10F);
            this.btnOn.Location = new System.Drawing.Point(9, -1);
            this.btnOn.Name = "btnOn";
            this.btnOn.Size = new System.Drawing.Size(80, 60);
            this.btnOn.TabIndex = 0;
            this.btnOn.Text = "On";
            this.btnOn.UseVisualStyleBackColor = false;
            this.btnOn.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btnOnOff_MouseDown);
            this.btnOn.MouseUp += new System.Windows.Forms.MouseEventHandler(this.btnOnOff_MouseUp);
            // 
            // UCButtonMultiOn
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.lblObject);
            this.Controls.Add(this.btnOn);
            this.Name = "UCButtonMultiOn";
            this.Size = new System.Drawing.Size(100, 80);
            this.Load += new System.EventHandler(this.UCButtonOn_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private CVisuButton btnOn;
        private System.Windows.Forms.Label lblObject;
    }
}
