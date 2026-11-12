namespace App.Pages.Parameters
{
    using System;

    partial class FParameters6 : IDisposable
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        private bool m_bDisposed;

        public bool Disposed
        {
            get { return m_bDisposed; }
        }

        ~FParameters6()
        {
            Dispose(false);
        }

        #region IDisposable Members

        public void Dispose()  
        {  
            Dispose(true);

            // Use SupressFinalize in case a subclass of this type implements a finalizer.
            GC.SuppressFinalize(this);  
        }

        #endregion

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool isDisposing)
        {
            if (!this.m_bDisposed)
            {
                if (isDisposing)
                {
                    // Cleanup managed resources
                    DisposeManagedRessources();
                }

                //Cleanup unmanaged resources
                DisposeUnmanagedRessources();

                this.m_bDisposed = true;
            }

            // Call the base class's dispose
            base.Dispose(isDisposing);
        }

        private void DisposeManagedRessources()
        {
            // Cleanup managed resources
            if (components != null)
            {
                components.Dispose();
            }
        }

        private void DisposeUnmanagedRessources()
        {
            // Cleanup unmanaged resources

        } 

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblWindowTitle = new System.Windows.Forms.Label();
            this.ucProcessPara1 = new App.Components.UCProcessPara();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackgroundImage = global::App.Properties.Resources.MainMashine_1024x572x8;
            this.panel1.Controls.Add(this.lblWindowTitle);
            this.panel1.Controls.Add(this.ucProcessPara1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1024, 572);
            this.panel1.TabIndex = 12;
            // 
            // lblWindowTitle
            // 
            this.lblWindowTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblWindowTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblWindowTitle.ForeColor = System.Drawing.Color.White;
            this.lblWindowTitle.Location = new System.Drawing.Point(0, 0);
            this.lblWindowTitle.Name = "lblWindowTitle";
            this.lblWindowTitle.Size = new System.Drawing.Size(1024, 20);
            this.lblWindowTitle.TabIndex = 13;
            this.lblWindowTitle.Text = "---------";
            this.lblWindowTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ucProcessPara1
            // 
            this.ucProcessPara1.AdsClientRef = null;
            this.ucProcessPara1.DisablePara1 = false;
            this.ucProcessPara1.DisablePara10 = false;
            this.ucProcessPara1.DisablePara11 = false;
            this.ucProcessPara1.DisablePara12 = false;
            this.ucProcessPara1.DisablePara2 = false;
            this.ucProcessPara1.DisablePara3 = false;
            this.ucProcessPara1.DisablePara4 = false;
            this.ucProcessPara1.DisablePara5 = false;
            this.ucProcessPara1.DisablePara6 = false;
            this.ucProcessPara1.DisablePara7 = false;
            this.ucProcessPara1.DisablePara8 = false;
            this.ucProcessPara1.DisablePara9 = false;
            this.ucProcessPara1.InchOnPara1 = true;
            this.ucProcessPara1.InchOnPara10 = false;
            this.ucProcessPara1.InchOnPara11 = false;
            this.ucProcessPara1.InchOnPara12 = false;
            this.ucProcessPara1.InchOnPara2 = false;
            this.ucProcessPara1.InchOnPara3 = true;
            this.ucProcessPara1.InchOnPara4 = true;
            this.ucProcessPara1.InchOnPara5 = true;
            this.ucProcessPara1.InchOnPara6 = true;
            this.ucProcessPara1.InchOnPara7 = true;
            this.ucProcessPara1.InchOnPara8 = true;
            this.ucProcessPara1.InchOnPara9 = false;
            this.ucProcessPara1.Location = new System.Drawing.Point(164, 75);
            this.ucProcessPara1.Name = "ucProcessPara1";
            this.ucProcessPara1.ObjectName = "ProcessPara";
            this.ucProcessPara1.Para10LimitMax = "10";
            this.ucProcessPara1.Para10LimitMin = "1";
            this.ucProcessPara1.Para11LimitMax = "10";
            this.ucProcessPara1.Para11LimitMin = "-10";
            this.ucProcessPara1.Para12LimitMax = "1000";
            this.ucProcessPara1.Para12LimitMin = "0";
            this.ucProcessPara1.Para13 = false;
            this.ucProcessPara1.Para1LimitMax = "30";
            this.ucProcessPara1.Para1LimitMin = "6.625";
            this.ucProcessPara1.Para2LimitMax = "45";
            this.ucProcessPara1.Para2LimitMin = "-45";
            this.ucProcessPara1.Para3LimitMax = "9.842";
            this.ucProcessPara1.Para3LimitMin = "1.181";
            this.ucProcessPara1.Para4LimitMax = "7.784";
            this.ucProcessPara1.Para4LimitMin = "0";
            this.ucProcessPara1.Para5LimitMax = "157.48";
            this.ucProcessPara1.Para5LimitMin = "0";
            this.ucProcessPara1.Para6LimitMax = "9.842";
            this.ucProcessPara1.Para6LimitMin = "1.181";
            this.ucProcessPara1.Para7LimitMax = "9.842";
            this.ucProcessPara1.Para7LimitMin = "1.181";
            this.ucProcessPara1.Para8LimitMax = "0.787";
            this.ucProcessPara1.Para8LimitMin = "0";
            this.ucProcessPara1.Para9LimitMax = "100";
            this.ucProcessPara1.Para9LimitMin = "5";
            this.ucProcessPara1.PlcVarNamePara1 = ".stgGr01HMI.stHMITOPLC.rPipeDiameter";
            this.ucProcessPara1.PlcVarNamePara10 = "";
            this.ucProcessPara1.PlcVarNamePara11 = "";
            this.ucProcessPara1.PlcVarNamePara12 = "";
            this.ucProcessPara1.PlcVarNamePara2 = ".stgGr01HMI.stHMITOPLC.lrActSawingAngle";
            this.ucProcessPara1.PlcVarNamePara3 = ".stgGr01HMI.stHMITOPLC.lrSafetyDistance";
            this.ucProcessPara1.PlcVarNamePara4 = ".stgGr01HMI.stHMITOPLC.lrSafeDistSawBandToPipe";
            this.ucProcessPara1.PlcVarNamePara5 = ".stgGr05HMI.stHMITOPLC.lrActSawingLength";
            this.ucProcessPara1.PlcVarNamePara6 = "";
            this.ucProcessPara1.PlcVarNamePara7 = "";
            this.ucProcessPara1.PlcVarNamePara8 = ".stgGr01HMI.stHMITOPLC.lrSawBandThickness";
            this.ucProcessPara1.PlcVarNamePara9 = "";
            this.ucProcessPara1.Size = new System.Drawing.Size(820, 150);
            this.ucProcessPara1.TabIndex = 12;
            this.ucProcessPara1.VarTypePara1 = 5;
            this.ucProcessPara1.VarTypePara10 = 6;
            this.ucProcessPara1.VarTypePara11 = 6;
            this.ucProcessPara1.VarTypePara12 = 6;
            this.ucProcessPara1.VarTypePara2 = 6;
            this.ucProcessPara1.VarTypePara3 = 6;
            this.ucProcessPara1.VarTypePara4 = 6;
            this.ucProcessPara1.VarTypePara5 = 6;
            this.ucProcessPara1.VarTypePara6 = 6;
            this.ucProcessPara1.VarTypePara7 = 6;
            this.ucProcessPara1.VarTypePara8 = 6;
            this.ucProcessPara1.VarTypePara9 = 6;
            this.ucProcessPara1.VisiblePara1 = true;
            this.ucProcessPara1.VisiblePara10 = false;
            this.ucProcessPara1.VisiblePara11 = false;
            this.ucProcessPara1.VisiblePara12 = false;
            this.ucProcessPara1.VisiblePara2 = true;
            this.ucProcessPara1.VisiblePara3 = false;
            this.ucProcessPara1.VisiblePara4 = true;
            this.ucProcessPara1.VisiblePara5 = true;
            this.ucProcessPara1.VisiblePara6 = false;
            this.ucProcessPara1.VisiblePara7 = false;
            this.ucProcessPara1.VisiblePara8 = true;
            this.ucProcessPara1.VisiblePara9 = false;
            // 
            // FParameters6
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.ClientSize = new System.Drawing.Size(1024, 572);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximumSize = new System.Drawing.Size(1024, 572);
            this.Name = "FParameters6";
            this.Text = "FParameters6";
            this.Activated += new System.EventHandler(this.FSettings6_Activated);
            this.Load += new System.EventHandler(this.FSettings6_Load);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private Components.UCProcessPara ucProcessPara1;
        private System.Windows.Forms.Label lblWindowTitle;
    }
}