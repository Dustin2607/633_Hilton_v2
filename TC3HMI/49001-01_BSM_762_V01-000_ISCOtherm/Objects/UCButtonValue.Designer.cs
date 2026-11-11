namespace App.Components
{
    partial class UCButtonValue
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
            this.SuspendLayout();
            // 
            // btnOn
            // 
            this.btnOn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnOn.Font = new System.Drawing.Font("Tahoma", 10F);
            this.btnOn.Location = new System.Drawing.Point(0, 0);
            this.btnOn.Name = "btnOn";
            this.btnOn.Size = new System.Drawing.Size(70, 60);
            this.btnOn.TabIndex = 0;
            this.btnOn.Text = "On";
            this.btnOn.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btnOn_MouseDown);
            this.btnOn.MouseUp += new System.Windows.Forms.MouseEventHandler(this.btnOn_MouseUp);
            // 
            // btnOff
            // 
            this.btnOff.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnOff.Font = new System.Drawing.Font("Tahoma", 10F);
            this.btnOff.Location = new System.Drawing.Point(70, 0);
            this.btnOff.Name = "btnOff";
            this.btnOff.Size = new System.Drawing.Size(70, 60);
            this.btnOff.TabIndex = 1;
            this.btnOff.Text = "Off";
            this.btnOff.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btnOff_MouseDown);
            this.btnOff.MouseUp += new System.Windows.Forms.MouseEventHandler(this.btnOff_MouseUp);
            // 
            // UCButtonValue
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.btnOff);
            this.Controls.Add(this.btnOn);
            this.Name = "UCButtonValue";
            this.Size = new System.Drawing.Size(140, 60);
            this.Load += new System.EventHandler(this.UCButtonValue_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private App.Components.CVisuButton btnOn;
        private App.Components.CVisuButton btnOff;
    }
}
