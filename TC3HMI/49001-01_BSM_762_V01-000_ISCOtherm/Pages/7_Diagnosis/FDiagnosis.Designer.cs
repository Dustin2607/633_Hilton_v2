namespace App
{
    using System;

    using TwinCAT.App.EventLogger;
    using TwinCAT.App;
    using TwinCAT.Ads;

    using App.Utility;

    partial class FDiagnosis : IDisposable
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components;

        private bool m_bDisposed;

        public bool Disposed
        {
            get { return m_bDisposed; }
        }

        ~FDiagnosis()
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

        //this.tcEventItemList1 = new EventItemList();
        //this.tcEventLoggerList1 = new TcEventLoggerList();
        //this.tcEventLoggerData1 = new TcEventLoggerData();

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.tcEventItemList1 = new EventItemList();
            this.tcEventLoggerList1 = new TcEventLoggerList();
            this.tcEventLoggerData1 = new TcEventLoggerData();
            this.lblWindowTitle = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // tcEventLoggerList1
            // 
            this.tcEventLoggerList1.CaptionColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(85)))), ((int)(((byte)(148)))));
            this.tcEventLoggerList1.ColCaptionClass = "Class";
            this.tcEventLoggerList1.ColCaptionConfirm = "Confirm";
            this.tcEventLoggerList1.ColCaptionDate = "Date";
            this.tcEventLoggerList1.ColCaptionDescription = "Description";
            this.tcEventLoggerList1.ColCaptionID = "ID";
            this.tcEventLoggerList1.ColCaptionMessage = "Message";
            this.tcEventLoggerList1.ColCaptionNr = "Nr.";
            this.tcEventLoggerList1.ColCaptionSource = "Source Id";
            this.tcEventLoggerList1.ColCaptionSourceName = "Source Name";
            this.tcEventLoggerList1.ColCaptionState = "State";
            this.tcEventLoggerList1.ColCaptionTime = "Time";
            this.tcEventLoggerList1.ColCaptionValue = "Value";
            this.tcEventLoggerList1.DetailCaptionText = "Detailed Messages";
            this.tcEventLoggerList1.DetailHeightRelation = 50;
            this.tcEventLoggerList1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F);
            this.tcEventLoggerList1.Location = new System.Drawing.Point(0, 19);
            this.tcEventLoggerList1.Name = "tcEventLoggerList1";
            this.tcEventLoggerList1.RefreshTime = 300;
            this.tcEventLoggerList1.ShowCol = new bool[] {
        true,
        true,
        false,
        false,
        false,
        true,
        false,
        false,
        true,
        true,
        true,
        false,
        false,
        false};
            this.tcEventLoggerList1.ShowDetailWindow = false;
            this.tcEventLoggerList1.Size = new System.Drawing.Size(1020, 555);
            this.tcEventLoggerList1.TabIndex = 2;
            this.tcEventLoggerList1.TcEventLogData = this.tcEventLoggerData1;
            this.tcEventLoggerList1.UpdateByEvent = false;
            // 
            // tcEventLoggerData1
            // 
            this.tcEventLoggerData1.LanguageID = 1031;
            this.tcEventLoggerData1.OperateAtDesignTime = false;
            this.tcEventLoggerData1.LogEvent += new TwinCAT.App.EventLogger.OnLogEvent(this.tcAppEventLogData1_LogEvent);
            this.tcEventLoggerData1.LogInstructionEvent += new TwinCAT.App.EventLogger.OnLogEvent(this.tcAppEventLogData1_LogInstructionEvent);
            // 
            // lblWindowTitle
            // 
            this.lblWindowTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblWindowTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblWindowTitle.ForeColor = System.Drawing.Color.White;
            this.lblWindowTitle.Location = new System.Drawing.Point(0, 0);
            this.lblWindowTitle.Name = "lblWindowTitle";
            this.lblWindowTitle.Size = new System.Drawing.Size(1024, 20);
            this.lblWindowTitle.TabIndex = 10;
            this.lblWindowTitle.Text = "---------";
            this.lblWindowTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // FDiagnosis
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.BackgroundImage = global::App.Properties.Resources.MainMashine_1024x572x8;
            this.ClientSize = new System.Drawing.Size(1024, 572);
            this.Controls.Add(this.lblWindowTitle);
            this.Controls.Add(this.tcEventLoggerList1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximumSize = new System.Drawing.Size(1024, 572);
            this.Name = "FDiagnosis";
            this.Text = "FDiagnosis";
            this.Activated += new System.EventHandler(this.FDiagnosis_Activated);
            this.Load += new System.EventHandler(this.FDiagnosis_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private EventItemList tcEventItemList1;
        private TcEventLoggerList tcEventLoggerList1;
        private TcEventLoggerData tcEventLoggerData1;
        private System.Windows.Forms.Label lblWindowTitle;
    }
}