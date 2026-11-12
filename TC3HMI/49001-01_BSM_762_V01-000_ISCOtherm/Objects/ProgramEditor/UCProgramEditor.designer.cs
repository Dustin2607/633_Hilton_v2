namespace App.Components.ProgramEditor
{
    partial class UCProgramEditor
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
            this.tbxFileResults = new System.Windows.Forms.TextBox();
            this.tbxfilepath = new System.Windows.Forms.TextBox();
            this.tbxPLCFileResult = new System.Windows.Forms.TextBox();
            this.tbxplcfilepath = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // tbxFileResults
            // 
            this.tbxFileResults.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbxFileResults.ForeColor = System.Drawing.Color.Black;
            this.tbxFileResults.Location = new System.Drawing.Point(514, 23);
            this.tbxFileResults.Multiline = true;
            this.tbxFileResults.Name = "tbxFileResults";
            this.tbxFileResults.ReadOnly = true;
            this.tbxFileResults.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbxFileResults.Size = new System.Drawing.Size(510, 549);
            this.tbxFileResults.TabIndex = 11;
            // 
            // tbxfilepath
            // 
            this.tbxfilepath.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.tbxfilepath.Location = new System.Drawing.Point(514, 0);
            this.tbxfilepath.Name = "tbxfilepath";
            this.tbxfilepath.ReadOnly = true;
            this.tbxfilepath.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbxfilepath.Size = new System.Drawing.Size(510, 24);
            this.tbxfilepath.TabIndex = 14;
            // 
            // tbxPLCFileResult
            // 
            this.tbxPLCFileResult.BackColor = System.Drawing.SystemColors.Control;
            this.tbxPLCFileResult.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbxPLCFileResult.ForeColor = System.Drawing.Color.Black;
            this.tbxPLCFileResult.Location = new System.Drawing.Point(0, 23);
            this.tbxPLCFileResult.Multiline = true;
            this.tbxPLCFileResult.Name = "tbxPLCFileResult";
            this.tbxPLCFileResult.ReadOnly = true;
            this.tbxPLCFileResult.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbxPLCFileResult.Size = new System.Drawing.Size(510, 549);
            this.tbxPLCFileResult.TabIndex = 8;
            this.tbxPLCFileResult.TabStop = false;
            // 
            // tbxplcfilepath
            // 
            this.tbxplcfilepath.BackColor = System.Drawing.SystemColors.Control;
            this.tbxplcfilepath.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.tbxplcfilepath.Location = new System.Drawing.Point(0, 0);
            this.tbxplcfilepath.Name = "tbxplcfilepath";
            this.tbxplcfilepath.ReadOnly = true;
            this.tbxplcfilepath.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbxplcfilepath.Size = new System.Drawing.Size(510, 24);
            this.tbxplcfilepath.TabIndex = 15;
            // 
            // UCProgramEditor
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.BackColor = System.Drawing.SystemColors.ControlDark;
            this.Controls.Add(this.tbxFileResults);
            this.Controls.Add(this.tbxPLCFileResult);
            this.Controls.Add(this.tbxplcfilepath);
            this.Controls.Add(this.tbxfilepath);
            this.Name = "UCProgramEditor";
            this.Size = new System.Drawing.Size(1024, 572);
            this.Load += new System.EventHandler(this.UCProgramEditor_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbxFileResults;
        private System.Windows.Forms.TextBox tbxfilepath;
        private System.Windows.Forms.TextBox tbxPLCFileResult;
        private System.Windows.Forms.TextBox tbxplcfilepath;

    }
}
