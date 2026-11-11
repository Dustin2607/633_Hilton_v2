namespace App.Components
{
    using App.Utility;

    partial class UCParameter
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
            this.lblName = new System.Windows.Forms.Label();
            this.tbxValue = new App.Components.CVisuTextBox();
            this.btnPlus = new App.Components.CVisuPressableButton();
            this.btnMinus = new App.Components.CVisuPressableButton();
            this.lblUnit = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblName.Location = new System.Drawing.Point(83, 4);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(116, 25);
            this.lblName.TabIndex = 5;
            this.lblName.Text = "-------------";
            this.lblName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tbxValue
            // 
            this.tbxValue.BackColor = System.Drawing.Color.White;
            this.tbxValue.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tbxValue.Cursor = System.Windows.Forms.Cursors.Hand;
            this.tbxValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbxValue.Location = new System.Drawing.Point(84, 35);
            this.tbxValue.Name = "tbxValue";
            this.tbxValue.ReadOnly = true;
            this.tbxValue.Size = new System.Drawing.Size(78, 23);
            this.tbxValue.TabIndex = 4;
            this.tbxValue.TabStop = false;
            this.tbxValue.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.tbxValue.Click += new System.EventHandler(this.tbxValue_Click);
            // 
            // btnPlus
            // 
            this.btnPlus.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPlus.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPlus.Location = new System.Drawing.Point(200, 0);
            this.btnPlus.Name = "btnPlus";
            this.btnPlus.Size = new System.Drawing.Size(80, 60);
            this.btnPlus.TabIndex = 1;
            this.btnPlus.Text = "Plus";
            this.btnPlus.UseVisualStyleBackColor = true;
            this.btnPlus.MousePressing += new App.Components.CVisuPressableButton.MouseEventHandler(this.btnPlus_MousePressing);
            this.btnPlus.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btnPlus_MouseDown);
            // 
            // btnMinus
            // 
            this.btnMinus.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnMinus.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMinus.Location = new System.Drawing.Point(0, 0);
            this.btnMinus.Name = "btnMinus";
            this.btnMinus.Size = new System.Drawing.Size(80, 60);
            this.btnMinus.TabIndex = 0;
            this.btnMinus.Text = "Minus";
            this.btnMinus.UseVisualStyleBackColor = true;
            this.btnMinus.MousePressing += new App.Components.CVisuPressableButton.MouseEventHandler(this.btnMinus_MousePressing);
            this.btnMinus.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btnMinus_MouseDown);
            // 
            // lblUnit
            // 
            this.lblUnit.AutoSize = true;
            this.lblUnit.BackColor = System.Drawing.SystemColors.Control;
            this.lblUnit.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUnit.Location = new System.Drawing.Point(164, 36);
            this.lblUnit.Name = "lblUnit";
            this.lblUnit.Size = new System.Drawing.Size(37, 20);
            this.lblUnit.TabIndex = 6;
            this.lblUnit.Text = "[---]";
            this.lblUnit.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // UCParameter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.Controls.Add(this.btnPlus);
            this.Controls.Add(this.lblUnit);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.tbxValue);
            this.Controls.Add(this.btnMinus);
            this.Name = "UCParameter";
            this.Size = new System.Drawing.Size(280, 60);
            this.Load += new System.EventHandler(this.UCParameter_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private CVisuPressableButton btnMinus;
        private CVisuPressableButton btnPlus;
        private CVisuTextBox tbxValue;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Label lblUnit;
    }
}
