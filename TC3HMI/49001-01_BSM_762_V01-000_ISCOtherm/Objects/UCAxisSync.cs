namespace App.Components
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Drawing;
    using System.Data;
    using System.Text;
    using System.Windows.Forms;

    using TwinCAT.Ads;
    using App.Utility;

    public partial class UCAxisSync : UserControl
    {
        #region Member enummerations

        #endregion

        #region Member variables

        // TwinCAT references
        private TcAdsClient adsClient;

        // Application
        private FMainApp frmMainApp;
        private CLanguageManager lm;

        private string m_ObjectName1;
        private string m_ObjectName2;

        private string m_sPlcVarNameSyncOnOff;
        private string m_sPlcVarNameSyncCenter;
        private string m_sPlcVarNameSyncFlow;

        private string m_sPlcVarNameMinus;
        private string m_sPlcVarNamePlus;

        private bool m_bSyncOnOff = false;
        private bool m_bSyncCenter = false;
        private bool m_bSyncFlow = false;

        private string m_sActPosAxis1;
        private string m_sActPosAxis2;

        // Set color theme
        private Color colorCaption;
        private Color colorRow2;
        private Color colorRow3;

        #endregion

        #region Systemcode

        #region Constructor

        /// <summary>
        /// Constructor UCOverride.
        /// </summary>
        public UCAxisSync()
        {
            InitializeComponent();

            // Set color theme
            //colorCaption = groupBox1.BackColor;
            //colorRow2 = groupBox1.BackColor;
            //colorRow3 = groupBox1.BackColor;

            mSetSyncStatus();
        }

        #endregion

        #endregion

        #region Properties

        /// <summary>
        /// Gets / sets the language manager.
        /// </summary>
        /// <value>The language manager.</value>
        [DefaultValue(1)]
        [Description("Gets or sets the language manager."), Category("App")]
        public CLanguageManager LanguageManager
        {
            set { this.lm = value; }
        }

        /// </summary>
        /// <value>Sets name of object.</value>
        [Description("Sets name of object."), Category("App")]
        public string ObjectName1
        {
            set { m_ObjectName1 = value; }
        }

        /// </summary>
        /// <value>Sets name of object.</value>
        [Description("Sets name of object."), Category("App")]
        public string ObjectName2
        {
            set { m_ObjectName2 = value; }
        }

        /// <summary>
        /// Set plc variable name - synchronization on / off.
        /// </summary>
        /// <value>Plc variable name - synchronization on / off.</value>
        [Description("Sets plc variable name - synchronization on / off."), Category("App")]
        public string PlcVarNameSyncOnOff
        {
            set { this.m_sPlcVarNameSyncOnOff = value; }
        }

        /// <summary>
        /// Set plc variable name - synchronization center activ.
        /// </summary>
        /// <value>Plc variable name - synchronization center activ.</value>
        [Description("Sets plc variable name - synchronization center activ."), Category("App")]
        public string PlcVarNameSyncCenter
        {
            set { this.m_sPlcVarNameSyncCenter = value; }
        }

        /// <summary>
        /// Set plc variable name - synchronization flow activ.
        /// </summary>
        /// <value>Plc variable name - synchronization flow activ.</value>
        [Description("Sets plc variable name - synchronization flow activ."), Category("App")]
        public string PlcVarNameSyncFlow
        {
            set { this.m_sPlcVarNameSyncFlow = value; }
        }

        /// <summary>
        /// Set plc variable name - minus.
        /// </summary>
        /// <value>Plc variable name - minus.</value>
        [Description("Sets plc variable name - minus."), Category("App")]
        public string PlcVarNameMinus
        {
            set { this.m_sPlcVarNameMinus = value; }
        }

        /// <summary>
        /// Set plc variable name - plus.
        /// </summary>
        /// <value>Plc variable name - plus.</value>
        [Description("Sets plc variable name - plus."), Category("App")]
        public string PlcVarNamePlus
        {
            set { this.m_sPlcVarNamePlus = value; }
        }

        /// <summary>
        /// Set plc value of synchronization on / off.
        /// </summary>
        /// <value>Plc value of synchronization on / off.</value>
        [Description("Sets plc value of synchronization on / off."), Category("App")]
        public bool SyncOnOff
        {
            get { return m_bSyncOnOff; }
            set { 
                    m_bSyncOnOff = value;
                    mSetSyncStatus();
                }
        }

        /// <summary>
        /// Set plc value of synchronization center activ.
        /// </summary>
        /// <value>Plc value of synchronization center activ.</value>
        [Description("Sets value of synchronization center activ."), Category("App")]
        public bool SyncCenter
        {
            get { return m_bSyncCenter; }
            set
            {
                m_bSyncCenter = value;
                mSetSyncCenterStatus(m_bSyncCenter);
            }
        }

        /// <summary>
        /// Set plc value of synchronization flow activ.
        /// </summary>
        /// <value>Plc value of synchronization flow activ.</value>
        [Description("Sets plc value of synchronization flow activ."), Category("App")]
        public bool SyncFlow
        {
            get { return m_bSyncFlow; }
            set
            {
                m_bSyncFlow = value;
                mSetSyncFlowStatus(m_bSyncFlow);
            }
        }

        /// <summary>
        /// Set plc value of position axis.
        /// </summary>
        /// <value>Plc value of position axis.</value>
        [Description("Sets plc value of position axis."), Category("App")]
        public string ActPosAxis1
        {
            get { return m_sActPosAxis1; }
            set
            {
                m_sActPosAxis1 = value;
                tbxPositionAxis1.Text = CUtility.DoFormat(m_sActPosAxis1);
            }
        }

        /// <summary>
        /// Set plc value of position axis.
        /// </summary>
        /// <value>Plc value of position axis.</value>
        [Description("Sets plc value of position axis."), Category("App")]
        public string ActPosAxis2
        {
            get { return m_sActPosAxis2; }
            set
            {
                m_sActPosAxis2 = value;
                tbxPositionAxis2.Text = CUtility.DoFormat(m_sActPosAxis2);
            }
        }


        #endregion

        #region User interface

        #endregion

        #region Events

        #region Form Events

        private void UCAxisSync_Load(object sender, EventArgs e)
        {
            frmMainApp = CMainApp.GetMainAppForm();

            if (this.lm == null)
                return;
            this.lm.StringDel += new CLanguageManager.InitStringDelegate(this.LoadLanguageStrings);
            this.LoadLanguageStrings();
        }

        private void UCAxisSync_Leave(object sender, EventArgs e)
        {
            frmMainApp.mWritePLCValue(m_sPlcVarNameSyncOnOff, false);
            frmMainApp.mWritePLCValue(m_sPlcVarNameSyncCenter, false);
            frmMainApp.mWritePLCValue(m_sPlcVarNameSyncFlow, false);
        }

        #endregion

        #region Object Events

        private void btnSyncOnOff_MouseUp(object sender, MouseEventArgs e)
        {
            if (m_bSyncOnOff == true)
            {
                frmMainApp.mWritePLCValue(m_sPlcVarNameSyncOnOff, false);
                frmMainApp.mWritePLCValue(m_sPlcVarNameSyncCenter, false);
                frmMainApp.mWritePLCValue(m_sPlcVarNameSyncFlow, false);
            }
            else
            {
                frmMainApp.mWritePLCValue(m_sPlcVarNameSyncOnOff, true);
                frmMainApp.mWritePLCValue(m_sPlcVarNameSyncCenter, true);
                frmMainApp.mWritePLCValue(m_sPlcVarNameSyncFlow, false);
            }

        }

        private void rbtnCenter_MouseUp(object sender, MouseEventArgs e)
        {
            frmMainApp.mWritePLCValue(m_sPlcVarNameSyncCenter, true);
            frmMainApp.mWritePLCValue(m_sPlcVarNameSyncFlow, false);
        }

        private void rbtnFlow_MouseUp(object sender, MouseEventArgs e)
        {
            frmMainApp.mWritePLCValue(m_sPlcVarNameSyncCenter, false);
            frmMainApp.mWritePLCValue(m_sPlcVarNameSyncFlow, true);
        }

        private void btnSyncLeft_MouseDown(object sender, MouseEventArgs e)
        {
            if (rbtnFlow.Checked)
            {
                frmMainApp.mWritePLCValue(m_sPlcVarNamePlus, true);

                btnSyncLeft.Text = "<";
                btnSyncRight.Text = "<";
            }
            else
            {
                frmMainApp.mWritePLCValue(m_sPlcVarNameMinus, true);     
            }
        }

        private void btnSyncLeft_MouseUp(object sender, MouseEventArgs e)
        {
            frmMainApp.mWritePLCValue(m_sPlcVarNamePlus, false);
            frmMainApp.mWritePLCValue(m_sPlcVarNameMinus, false); 

            if (rbtnFlow.Checked)
            {           
                btnSyncLeft.Text = "<";
                btnSyncRight.Text = ">";
            }

        }

        private void btnSyncRight_MouseDown(object sender, MouseEventArgs e)
        {
            if (rbtnFlow.Checked)
            {
                frmMainApp.mWritePLCValue(m_sPlcVarNameMinus, true); 

                btnSyncLeft.Text = ">";
                btnSyncRight.Text = ">";
            }
            else
            {
                frmMainApp.mWritePLCValue(m_sPlcVarNamePlus, true);
            }
        }

        private void btnSyncRight_MouseUp(object sender, MouseEventArgs e)
        {
            frmMainApp.mWritePLCValue(m_sPlcVarNamePlus, false);
            frmMainApp.mWritePLCValue(m_sPlcVarNameMinus, false); 

            if (rbtnFlow.Checked)
            {
                btnSyncLeft.Text = "<";
                btnSyncRight.Text = ">";
            }
        }

        #endregion

        #region User Events

        #endregion

        #endregion

        #region Interface implementation

        #endregion

        #region Public functions

        #endregion

        #region Private methods

        private void LoadLanguageStrings()
        {
            if (this.lm != null)
            {
                this.lblObject1.Text = lm["UCAxisSync." + m_ObjectName1];
                this.lblObject2.Text = lm["UCAxisSync." + m_ObjectName2];
                this.rbtnFlow.Text = lm["UCAxisSync.rbtnFlow"];
                this.rbtnCenter.Text = lm["UCAxisSync.rbtnCenter"];
            }
            else
            {
                this.lblObject1.Text = m_ObjectName1;
                this.lblObject2.Text = m_ObjectName2;
                this.rbtnFlow.Text = "Flow";
                this.rbtnCenter.Text = "Center";
            }

            mSetSyncStatus();
        }

        private void mSetSyncStatus()
        {    

            if (m_bSyncOnOff)
            {
                rbtnCenter.Visible = true;
                rbtnFlow.Visible = true;
                btnSyncLeft.Visible = true;
                btnSyncRight.Visible = true;
                lblObject1.Visible = true;
                tbxPositionAxis1.Visible = true;
                lblObject2.Visible = true;
                tbxPositionAxis2.Visible = true;

                btnSyncOnOff.BackColor = Color.Green;

                if (this.lm != null)
                {
                    btnSyncOnOff.Text = lm["UCAxisSync.SyncOff"];
                }
                else
                {
                    btnSyncOnOff.Text = "Sync Off";
                }

            }
            else
            {
                rbtnCenter.Visible = false;
                rbtnFlow.Visible = false;
                btnSyncLeft.Visible = false;
                btnSyncRight.Visible = false;
                lblObject1.Visible = false;
                tbxPositionAxis1.Visible = false;
                lblObject2.Visible = false;
                tbxPositionAxis2.Visible = false;

                btnSyncOnOff.BackColor = SystemColors.Control;

                if (this.lm != null)
                {
                    btnSyncOnOff.Text = lm["UCAxisSync.SyncOn"];
                }
                else
                {
                    btnSyncOnOff.Text = "Sync On";
                }
            
            }
        }

        private void mSetSyncCenterStatus(bool bSyncCenter)
        {
            rbtnCenter.Checked = bSyncCenter;

            if (bSyncCenter)
            {
                btnSyncLeft.Text = "><";
                btnSyncRight.Text = "<>";
            }
        }

        private void mSetSyncFlowStatus(bool bSyncFlow)
        {
            rbtnFlow.Checked = bSyncFlow;

            if (bSyncFlow)
            {
                btnSyncLeft.Text = "<";
                btnSyncRight.Text = ">";
            }
        }

        #endregion

    }
}
