namespace App.Components
{
    partial class UCCurrentValue3
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
            this.lblValueName = new System.Windows.Forms.Label();
            this.tbxSetValue = new App.Components.CVisuTextBoxVar();
            this.lblValueUnit = new System.Windows.Forms.Label();
            this.lblActValue = new System.Windows.Forms.Label();
            this.cActValueGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // cActValueGroupBox
            // 
            this.cActValueGroupBox.Controls.Add(this.lblValueName);
            this.cActValueGroupBox.Controls.Add(this.tbxSetValue);
            this.cActValueGroupBox.Controls.Add(this.lblValueUnit);
            this.cActValueGroupBox.Controls.Add(this.lblActValue);
            this.cActValueGroupBox.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cActValueGroupBox.Location = new System.Drawing.Point(0, 0);
            this.cActValueGroupBox.Name = "cActValueGroupBox";
            this.cActValueGroupBox.Size = new System.Drawing.Size(129, 45);
            this.cActValueGroupBox.TabIndex = 0;
            this.cActValueGroupBox.TabStop = false;
            // 
            // lblValueName
            // 
            this.lblValueName.Location = new System.Drawing.Point(1, 2);
            this.lblValueName.Name = "lblValueName";
            this.lblValueName.Size = new System.Drawing.Size(125, 20);
            this.lblValueName.TabIndex = 2;
            this.lblValueName.Text = "ActValueName";
            this.lblValueName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tbxSetValue
            // 
            this.tbxSetValue.BackColor = System.Drawing.Color.White;
            this.tbxSetValue.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tbxSetValue.Cursor = System.Windows.Forms.Cursors.Hand;
            this.tbxSetValue.Font = new System.Drawing.Font("Tahoma", 9F);
            this.tbxSetValue.Location = new System.Drawing.Point(2, 22);
            this.tbxSetValue.Multiline = true;
            this.tbxSetValue.Name = "tbxSetValue";
            this.tbxSetValue.PlcVarName = "";
            this.tbxSetValue.ReadOnly = true;
            this.tbxSetValue.Size = new System.Drawing.Size(40, 20);
            this.tbxSetValue.TabIndex = 14;
            this.tbxSetValue.TabStop = false;
            this.tbxSetValue.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tbxSetValue.VarMaxLimit = "100";
            this.tbxSetValue.VarMinLimit = "0";
            this.tbxSetValue.VarType = 5;
            // 
            // lblValueUnit
            // 
            this.lblValueUnit.Location = new System.Drawing.Point(88, 20);
            this.lblValueUnit.Name = "lblValueUnit";
            this.lblValueUnit.Size = new System.Drawing.Size(38, 20);
            this.lblValueUnit.TabIndex = 0;
            this.lblValueUnit.Text = "[inch]";
            this.lblValueUnit.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblActValue
            // 
            this.lblActValue.Location = new System.Drawing.Point(45, 21);
            this.lblActValue.Name = "lblActValue";
            this.lblActValue.Size = new System.Drawing.Size(40, 20);
            this.lblActValue.TabIndex = 1;
            this.lblActValue.Text = "-------";
            this.lblActValue.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // UCCurrentValue3
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.Controls.Add(this.cActValueGroupBox);
            this.Name = "UCCurrentValue3";
            this.Size = new System.Drawing.Size(129, 45);
            this.Load += new System.EventHandler(this.UCCurrentValue_Load);
            this.cActValueGroupBox.ResumeLayout(false);
            this.cActValueGroupBox.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private CVisuGroupBox cActValueGroupBox;
        private System.Windows.Forms.Label lblValueName;
        private System.Windows.Forms.Label lblActValue;
        public CVisuTextBoxVar tbxSetValue;
        private System.Windows.Forms.Label lblValueUnit;
    }
}
