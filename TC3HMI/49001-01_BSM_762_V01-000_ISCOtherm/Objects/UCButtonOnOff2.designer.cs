namespace App.Components
{

    partial class UCButtonOnOff2
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
            this.btnOn = new App.Components.CVisuButton();
            this.btnOff = new App.Components.CVisuButton();
            this.lblObject = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnOn
            // 
            this.btnOn.BackColor = System.Drawing.SystemColors.Control;
            this.btnOn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnOn.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOn.Location = new System.Drawing.Point(0, 0);
            this.btnOn.Name = "btnOn";
            this.btnOn.Size = new System.Drawing.Size(70, 60);
            this.btnOn.TabIndex = 0;
            this.btnOn.Text = "On";
            this.btnOn.UseVisualStyleBackColor = false;
            this.btnOn.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btnOn_MouseDown);
            this.btnOn.MouseUp += new System.Windows.Forms.MouseEventHandler(this.btnOn_MouseUp);
            // 
            // btnOff
            // 
            this.btnOff.BackColor = System.Drawing.SystemColors.Control;
            this.btnOff.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnOff.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOff.Location = new System.Drawing.Point(70, 0);
            this.btnOff.Name = "btnOff";
            this.btnOff.Size = new System.Drawing.Size(70, 60);
            this.btnOff.TabIndex = 1;
            this.btnOff.Text = "Off";
            this.btnOff.UseVisualStyleBackColor = false;
            this.btnOff.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btnOff_MouseDown);
            this.btnOff.MouseUp += new System.Windows.Forms.MouseEventHandler(this.btnOff_MouseUp);
            // 
            // lblObject
            // 
            this.lblObject.BackColor = System.Drawing.SystemColors.Control;
            this.lblObject.Font = new System.Drawing.Font("Tahoma", 9F);
            this.lblObject.Location = new System.Drawing.Point(47, 62);
            this.lblObject.Name = "lblObject";
            this.lblObject.Size = new System.Drawing.Size(47, 14);
            this.lblObject.TabIndex = 2;
            this.lblObject.Text = "----------";
            this.lblObject.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // UCButtonOnOff2
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.btnOff);
            this.Controls.Add(this.lblObject);
            this.Controls.Add(this.btnOn);
            this.Name = "UCButtonOnOff2";
            this.Size = new System.Drawing.Size(140, 85);
            this.Load += new System.EventHandler(this.UCButtonOnOff2_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private CVisuButton btnOn;
        private CVisuButton btnOff;
        private System.Windows.Forms.Label lblObject;
    }
}
