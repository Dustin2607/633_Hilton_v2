namespace App.Components
{
    using App.Utility;

    partial class UCParameterGet
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
            this.btnGetValue = new App.Components.CVisuButton();
            this.SuspendLayout();
            // 
            // btnGetValue
            // 
            this.btnGetValue.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnGetValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGetValue.Location = new System.Drawing.Point(281, 0);
            this.btnGetValue.Name = "btnGetValue";
            this.btnGetValue.Size = new System.Drawing.Size(80, 60);
            this.btnGetValue.TabIndex = 7;
            this.btnGetValue.Text = "<--";
            this.btnGetValue.UseVisualStyleBackColor = true;
            this.btnGetValue.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btnGetValue_MouseDown);
            // 
            // UCParameterGet
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.Controls.Add(this.btnGetValue);
            this.Name = "UCParameterGet";
            this.Size = new System.Drawing.Size(362, 60);
            this.Controls.SetChildIndex(this.btnGetValue, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private CVisuButton btnGetValue;

    }
}
