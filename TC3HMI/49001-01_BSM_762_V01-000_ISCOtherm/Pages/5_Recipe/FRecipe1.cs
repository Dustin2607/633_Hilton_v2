namespace App
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Text;
    using System.Windows.Forms;

    using TwinCAT.Ads;
    using App.Utility;
    using App.Components;
    using App.Security;
    using App.Components.RecipeEditor;

    public partial class FRecipe1 : Form
    {
        #region Member enummerations

        #endregion

        #region Member variables

        // TwinCAT references
        private TcAdsClient adsClient;

        // Application
        private FMainApp frmMainApp;
        private Form parentForm;
        private FMain frmMain;

        private CLanguageManager lm;

        // Set color theme
        private Color colorCaption;
        private Color colorRow2;
        private Color colorRow3;

        #endregion

        #region Systemcode

        #region Constructor

        /// <summary>
        /// Constructor FInfo.
        /// </summary>
        public FRecipe1(Form f)
        {
            parentForm = f;

            InitializeComponent();

            // Get language manager
            lm = CMainApp.GetMainAppForm().GetLanguageManager();

            adsClient = CMainApp.GetMainAppForm().AdsClientRef;

            SetFormStyle(this);
        }

        #endregion

        #endregion

        #region Properties

        /// <summary>
        /// Gets / sets the backcolor of the caption.
        /// </summary>
        /// <value>The backcolor of the caption.</value>
        [Description("Gets / sets the backcolor of the caption."), Category("App")]
        public Color CaptionBackColor
        {
            get { return colorCaption; }
            set
            {
                colorCaption = value;
                lblWindowTitle.BackColor = colorCaption;
            }
        }

        /// <summary>
        /// Gets / sets the color of the second row.
        /// </summary>
        /// <value>The color of the second row.</value>
        [Description("The color / the second row."), Category("App")]
        public Color ColorRow2
        {
            get { return colorRow2; }
            set
            {
                colorRow2 = value;
            }
        }

        /// <summary>
        /// Gets / sets the color of the third row.
        /// </summary>
        /// <value>The color of the third row.</value>
        [Description("Gets / sets the color of the third row."), Category("App")]
        public Color ColorRow3
        {
            get { return colorRow3; }
            set
            {
                colorRow3 = value;

            }
        }

        #endregion

        #region User interface

        #endregion

        #region Events

        #region Form Events

        private void FRecipe1_Activated(object sender, EventArgs e)
        {
            SetFunctionKeys(CMainApp.GetMainAppForm().tcFKeyBottom);
        }

        private void FRecipe1_Load(object sender, EventArgs e)
        {
            frmMainApp = CMainApp.GetMainAppForm();
            frmMain = frmMainApp.frmMain;

            lm.StringDel += new CLanguageManager.InitStringDelegate(LoadLanguageStrings);
            LoadLanguageStrings();

            // Variables update
            GetVariablesGr00HMITOPLC();
            GetVariablesGr00PLCTOHMI();
            GetVariablesGr01HMITOPLC();
            GetVariablesGr01PLCTOHMI();
            GetVariablesGr02HMITOPLC();
            GetVariablesGr02PLCTOHMI();
            GetVariablesGr05HMITOPLC();
            GetVariablesGr05PLCTOHMI();

            // Get events
            frmMainApp.OnError += new System.EventHandler<App.FMainApp.OnErrorArgs>(this.frmMainApp_OnError);
            frmMainApp.OnEvent += new System.EventHandler<App.FMainApp.OnEventArgs>(this.frmMainApp_OnEvent);
        }

        private void frmMainApp_OnError(object sender, FMainApp.OnErrorArgs efrmMainOnErrortArgs)
        {
            
        }

        private void frmMainApp_OnEvent(object sender, FMainApp.OnEventArgs efrmMainOnEventArgs)
        {
            switch ((int)efrmMainOnEventArgs.EventType)
            {
                case 10: // ST_Gr00HMITOPLC
                    GetVariablesGr00HMITOPLC();

                    break;

                case 11: // ST_Gr00PLCTOHMI
                    GetVariablesGr00PLCTOHMI();

                    break;

                case 12: // ST_Gr01HMITOPLC
                    GetVariablesGr01HMITOPLC();

                    break;

                case 13: // ST_Gr01PLCTOHMI
                    GetVariablesGr01PLCTOHMI();

                    break;

                case 14: // ST_Gr02HMITOPLC
                    GetVariablesGr02HMITOPLC();

                    break;

                case 15: // ST_Gr02PLCTOHMI
                    GetVariablesGr02PLCTOHMI();

                    break;

                case 20: // ST_Gr05HMITOPLC
                    GetVariablesGr05HMITOPLC();

                    break;

                case 21: // ST_Gr05PLCTOHMI
                    GetVariablesGr05PLCTOHMI();

                    break;

            }
        }

        protected override void OnResize(EventArgs eEventArgs)
        {
            base.OnResize(eEventArgs);
            this.FormBorderStyle = FormBorderStyle.None;
            this.WindowState = FormWindowState.Maximized;
        }

        protected override void WndProc(ref Message m)
        {
            if (m.Msg == 5)
                return;
            base.WndProc(ref m);
        }

        #endregion

        #region Object Events

        #endregion

        #endregion

        #region Interface implementation

        #endregion

        #region Public functions

        /// <summary>
        /// Sets the parent form.
        /// </summary>
        [Description("Sets the parent form."), Category("App")]
        public void SetParentForm(Form f)
        {
            parentForm = f;
        }

        #endregion

        #region Private methods

        private void SetFormStyle(Form form)
        {
            //form.Location = new Point(0, 0);
            form.MaximumSize = new System.Drawing.Size(1024, 572);
            form.MinimumSize = new System.Drawing.Size(1024, 572);
            form.FormBorderStyle = FormBorderStyle.None;
            //form.WindowState = FormWindowState.Maximized;
        }

        private string WriteRcpToPLC()
        {
            // Get reference from parameter list object
            CRcpDataList list = ucRecipeEditor1.GetSelectedList();

            if (adsClient != null
                //&& adsClient.PlcIsRunning
                && list != null)
            {
                try
                {
                    foreach (CRcpData data in list.Data)
                    {
                        if (data != null)
                        {
                            this.SetPLCValue(data.PlcVarType, data.PlcVarName, data.Value, 1);
                        }
                    }

                    return System.IO.Path.GetFileNameWithoutExtension(list.DataFileName);
                }
                catch
                {

                }
            }

            return String.Empty;
        }

        private void ReadParaFromPLC()
        {
            // Get reference from parameter list object
            CRcpDataList list = ucRecipeEditor1.GetSelectedList();

            if (adsClient != null
                //&& adsClient.PlcIsRunning
                && list != null)
            {
                try
                {
                    list.Data.Clear();

                }
                catch
                {

                }
            }

        }

        private void AddRcpData()
        {
            //this.ucRecipeEditor1.AddData(lm["UCProcessPara.ProcessPara.lblPara1"], frmMainApp.Gr01HMITOPLC.lrAxisWeldingPreWeldingPos.ToString(), "mm", 1, 4000.0, -4000.0, ".stgGr01HMI.stHMITOPLC.lrAxisWeldingPreWeldingPos", 6);
            //this.ucRecipeEditor1.AddData(lm["UCProcessPara.ProcessPara.lblPara2"], frmMainApp.Gr01HMITOPLC.lrAxisWeldingSafetyPos.ToString(), "mm", 1, 4000.0, -4000.0, ".stgGr01HMI.stHMITOPLC.lrAxisWeldingSafetyPos", 6);
            //this.ucRecipeEditor1.AddData(lm["UCProcessPara.ProcessPara.lblPara3"], frmMainApp.Gr01HMITOPLC.lrContactForce.ToString(), "N", 1, 0.0, 1000.0, ".stgGr01HMI.stHMITOPLC.lrContactForce", 6);
            //this.ucRecipeEditor1.AddData(lm["UCProcessPara.ProcessPara.lblPara4"], frmMainApp.Gr01HMITOPLC.arstForceWelding[0].rProcessCtrlKp.ToString(), "", 1, 0.0, 200.0, ".stgGr01HMI.stHMITOPLC.arstForceWelding[0].rProcessCtrlKp", 5);
            //this.ucRecipeEditor1.AddData(lm["UCProcessPara.ProcessPara.lblPara5"], frmMainApp.Gr01HMITOPLC.arstForceWelding[0].rProcessCtrlTi.ToString(), "s", 1, 0.0, 1000.0, ".stgGr01HMI.stHMITOPLC.arstForceWelding[0].rProcessCtrlTi", 5);
            //this.ucRecipeEditor1.AddData(lm["UCProcessPara.ProcessPara.lblPara6"], frmMainApp.Gr01HMITOPLC.arstForceWelding[0].rProcessCtrlLimit.ToString(), "mm/s", 1, 0.0, 1000.0, ".stgGr01HMI.stHMITOPLC.arstForceWelding[0].rProcessCtrlLimit", 5);
            //this.ucRecipeEditor1.AddData(lm["UCProcessPara.ProcessPara.lblPara7"], frmMainApp.Gr01HMITOPLC.lrSetTemp.ToString(), "°C", 1, 25.0, 250.0, ".stgGr01HMI.stHMITOPLC.lrSetTemp", 6);
            //this.ucRecipeEditor1.AddData(lm["UCProcessPara.ProcessPara.lblPara8"], frmMainApp.Gr01HMITOPLC.lrTempReadyTol.ToString(), "°C", 1, 0.0, 50.0, ".stgGr01HMI.stHMITOPLC.lrTempReadyTol", 6);
            //this.ucRecipeEditor1.AddData(lm["UCProcessPara.ProcessPara.lblPara9"], frmMainApp.Gr05HMITOPLC.arlrAxisShuttleWeldingPos[0].ToString(), "mm", 1, 0.0, 50.0, ".stgGr05HMI.stHMITOPLC.arlrAxisShuttleWeldingPos[1]", 6);


            //this.ucRecipeEditor1.AddData(lm["UCWeldingPara.WeldingPara.lblPara1"], frmMainApp.Gr01HMITOPLC.stPreHeat.unProcessTime.ToString(), "s", 1, 0.0, 100.0, ".stgGr01HMI.stHMITOPLC.stPreHeat.unProcessTime", 3);

            //this.ucRecipeEditor1.AddData(lm["UCWeldingPara.WeldingPara.lblPara2"], frmMainApp.Gr01HMITOPLC.arstForceWelding[1].lrProcessForce.ToString(), "N", 1, 0.0, 5000.0, ".stgGr01HMI.stHMITOPLC.arstForceWelding[1].lrProcessForce", 6);
            //this.ucRecipeEditor1.AddData(lm["UCWeldingPara.WeldingPara.lblPara3"], frmMainApp.Gr01HMITOPLC.arstForceWelding[1].unProcessRamp.ToString(), "s", 1, 0.0, 100.0, ".stgGr01HMI.stHMITOPLC.arstForceWelding[1].unProcessRamp", 3);
            //this.ucRecipeEditor1.AddData(lm["UCWeldingPara.WeldingPara.lblPara4"], frmMainApp.Gr01HMITOPLC.arstForceWelding[1].unProcessTime.ToString(), "s", 1, 0.0, 100.0, ".stgGr01HMI.stHMITOPLC.arstForceWelding[1].unProcessTime", 3);
            //this.ucRecipeEditor1.AddData(lm["UCWeldingPara.WeldingPara.lblPara14"], frmMainApp.Gr01HMITOPLC.arstForceWelding[1].unCoolingDuration1.ToString(), "s", 1, 0.0, 100.0, ".stgGr01HMI.stHMITOPLC.arstForceWelding[1].arunCoolingDuration[1]", 3);
            //this.ucRecipeEditor1.AddData(lm["UCWeldingPara.WeldingPara.lblPara15"], frmMainApp.Gr01HMITOPLC.arstForceWelding[1].unCoolingDuration2.ToString(), "s", 1, 0.0, 100.0, ".stgGr01HMI.stHMITOPLC.arstForceWelding[1].arunCoolingDuration[2]", 3);
            //this.ucRecipeEditor1.AddData(lm["UCWeldingPara.WeldingPara.lblPara22"], frmMainApp.Gr01HMITOPLC.arstForceWelding[1].arlrCoolingAirPressure1.ToString(), "bar", 1, 0.0, 2.0, ".stgGr01HMI.stHMITOPLC.arstForceWelding[1].arlrCoolingAirPressure[1]", 6);
            //this.ucRecipeEditor1.AddData(lm["UCWeldingPara.WeldingPara.lblPara23"], frmMainApp.Gr01HMITOPLC.arstForceWelding[1].arlrCoolingAirPressure2.ToString(), "bar", 1, 0.0, 6.0, ".stgGr01HMI.stHMITOPLC.arstForceWelding[1].arlrCoolingAirPressure[2]", 6);

            //this.ucRecipeEditor1.AddData(lm["UCWeldingPara.WeldingPara.lblPara5"], frmMainApp.Gr01HMITOPLC.arstForceWelding[2].lrProcessForce.ToString(), "N", 1, 0.0, 5000.0, ".stgGr01HMI.stHMITOPLC.arstForceWelding[2].lrProcessForce", 6);
            //this.ucRecipeEditor1.AddData(lm["UCWeldingPara.WeldingPara.lblPara6"], frmMainApp.Gr01HMITOPLC.arstForceWelding[2].unProcessRamp.ToString(), "s", 1, 0.0, 100.0, ".stgGr01HMI.stHMITOPLC.arstForceWelding[2].unProcessRamp", 3);
            //this.ucRecipeEditor1.AddData(lm["UCWeldingPara.WeldingPara.lblPara7"], frmMainApp.Gr01HMITOPLC.arstForceWelding[2].unProcessTime.ToString(), "s", 1, 0.0, 100.0, ".stgGr01HMI.stHMITOPLC.arstForceWelding[2].unProcessTime", 3);
            //this.ucRecipeEditor1.AddData(lm["UCWeldingPara.WeldingPara.lblPara16"], frmMainApp.Gr01HMITOPLC.arstForceWelding[2].unCoolingDuration1.ToString(), "s", 1, 0.0, 100.0, ".stgGr01HMI.stHMITOPLC.arstForceWelding[2].arunCoolingDuration[1]", 3);
            //this.ucRecipeEditor1.AddData(lm["UCWeldingPara.WeldingPara.lblPara17"], frmMainApp.Gr01HMITOPLC.arstForceWelding[2].unCoolingDuration2.ToString(), "s", 1, 0.0, 100.0, ".stgGr01HMI.stHMITOPLC.arstForceWelding[2].arunCoolingDuration[2]", 3);
            //this.ucRecipeEditor1.AddData(lm["UCWeldingPara.WeldingPara.lblPara24"], frmMainApp.Gr01HMITOPLC.arstForceWelding[2].arlrCoolingAirPressure1.ToString(), "bar", 1, 0.0, 2.0, ".stgGr01HMI.stHMITOPLC.arstForceWelding[2].arlrCoolingAirPressure[1]", 6);
            //this.ucRecipeEditor1.AddData(lm["UCWeldingPara.WeldingPara.lblPara25"], frmMainApp.Gr01HMITOPLC.arstForceWelding[2].arlrCoolingAirPressure2.ToString(), "bar", 1, 0.0, 6.0, ".stgGr01HMI.stHMITOPLC.arstForceWelding[2].arlrCoolingAirPressure[2]", 6);

            //this.ucRecipeEditor1.AddData(lm["UCWeldingPara.WeldingPara.lblPara8"], frmMainApp.Gr01HMITOPLC.arstForceWelding[3].lrProcessForce.ToString(), "N", 1, 0.0, 5000.0, ".stgGr01HMI.stHMITOPLC.arstForceWelding[3].lrProcessForce", 6);
            //this.ucRecipeEditor1.AddData(lm["UCWeldingPara.WeldingPara.lblPara9"], frmMainApp.Gr01HMITOPLC.arstForceWelding[3].unProcessRamp.ToString(), "s", 1, 0.0, 100.0, ".stgGr01HMI.stHMITOPLC.arstForceWelding[3].unProcessRamp", 3);
            //this.ucRecipeEditor1.AddData(lm["UCWeldingPara.WeldingPara.lblPara10"], frmMainApp.Gr01HMITOPLC.arstForceWelding[3].unProcessTime.ToString(), "s", 1, 0.0, 100.0, ".stgGr01HMI.stHMITOPLC.arstForceWelding[3].unProcessTime", 3);
            //this.ucRecipeEditor1.AddData(lm["UCWeldingPara.WeldingPara.lblPara18"], frmMainApp.Gr01HMITOPLC.arstForceWelding[3].unCoolingDuration1.ToString(), "s", 1, 0.0, 100.0, ".stgGr01HMI.stHMITOPLC.arstForceWelding[3].arunCoolingDuration[1]", 3);
            //this.ucRecipeEditor1.AddData(lm["UCWeldingPara.WeldingPara.lblPara19"], frmMainApp.Gr01HMITOPLC.arstForceWelding[3].unCoolingDuration2.ToString(), "s", 1, 0.0, 100.0, ".stgGr01HMI.stHMITOPLC.arstForceWelding[3].arunCoolingDuration[2]", 3);
            //this.ucRecipeEditor1.AddData(lm["UCWeldingPara.WeldingPara.lblPara26"], frmMainApp.Gr01HMITOPLC.arstForceWelding[3].arlrCoolingAirPressure1.ToString(), "bar", 1, 0.0, 2.0, ".stgGr01HMI.stHMITOPLC.arstForceWelding[3].arlrCoolingAirPressure[1]", 6);
            //this.ucRecipeEditor1.AddData(lm["UCWeldingPara.WeldingPara.lblPara27"], frmMainApp.Gr01HMITOPLC.arstForceWelding[3].arlrCoolingAirPressure2.ToString(), "bar", 1, 0.0, 6.0, ".stgGr01HMI.stHMITOPLC.arstForceWelding[3].arlrCoolingAirPressure[2]", 6);

            //this.ucRecipeEditor1.AddData(lm["UCWeldingPara.WeldingPara.lblPara11"], frmMainApp.Gr01HMITOPLC.arstForceWelding[4].lrProcessForce.ToString(), "N", 1, 0.0, 5000.0, ".stgGr01HMI.stHMITOPLC.arstForceWelding[4].lrProcessForce", 6);
            //this.ucRecipeEditor1.AddData(lm["UCWeldingPara.WeldingPara.lblPara12"], frmMainApp.Gr01HMITOPLC.arstForceWelding[4].unProcessRamp.ToString(), "s", 1, 0.0, 100.0, ".stgGr01HMI.stHMITOPLC.arstForceWelding[4].unProcessRamp", 3);
            //this.ucRecipeEditor1.AddData(lm["UCWeldingPara.WeldingPara.lblPara13"], frmMainApp.Gr01HMITOPLC.arstForceWelding[4].unProcessTime.ToString(), "s", 1, 0.0, 100.0, ".stgGr01HMI.stHMITOPLC.arstForceWelding[4].unProcessTime", 3);
            //this.ucRecipeEditor1.AddData(lm["UCWeldingPara.WeldingPara.lblPara20"], frmMainApp.Gr01HMITOPLC.arstForceWelding[4].unCoolingDuration1.ToString(), "s", 1, 0.0, 100.0, ".stgGr01HMI.stHMITOPLC.arstForceWelding[4].arunCoolingDuration[1]", 3);
            //this.ucRecipeEditor1.AddData(lm["UCWeldingPara.WeldingPara.lblPara21"], frmMainApp.Gr01HMITOPLC.arstForceWelding[4].unCoolingDuration2.ToString(), "s", 1, 0.0, 100.0, ".stgGr01HMI.stHMITOPLC.arstForceWelding[4].arunCoolingDuration[2]", 3);
            //this.ucRecipeEditor1.AddData(lm["UCWeldingPara.WeldingPara.lblPara28"], frmMainApp.Gr01HMITOPLC.arstForceWelding[4].arlrCoolingAirPressure1.ToString(), "bar", 1, 0.0, 2.0, ".stgGr01HMI.stHMITOPLC.arstForceWelding[4].arlrCoolingAirPressure[1]", 6);
            //this.ucRecipeEditor1.AddData(lm["UCWeldingPara.WeldingPara.lblPara29"], frmMainApp.Gr01HMITOPLC.arstForceWelding[4].arlrCoolingAirPressure2.ToString(), "bar", 1, 0.0, 6.0, ".stgGr01HMI.stHMITOPLC.arstForceWelding[4].arlrCoolingAirPressure[2]", 6);

        }

        private void SetPLCValue(int vartype, string varname, string value, int scaling)
        {

            if ((value == "") || (varname == ""))
                return;

            //Set PLC Variable
            try
            {
                switch (vartype)
                {
                    case 1:
                        // PLC variable int type
                        this.frmMainApp.mWritePLCValue(varname, Convert.ToInt16(Int16.Parse(value, System.Globalization.NumberStyles.Number, System.Globalization.CultureInfo.InvariantCulture) * scaling));

                        break;

                    case 2:
                        // PLC variable dint type
                        this.frmMainApp.mWritePLCValue(varname, Convert.ToInt32(Int32.Parse(value, System.Globalization.NumberStyles.Number, System.Globalization.CultureInfo.InvariantCulture) * scaling));

                        break;

                    case 3:
                        // PLC variable uint type
                        this.frmMainApp.mWritePLCValue(varname, Convert.ToUInt16(UInt16.Parse(value, System.Globalization.NumberStyles.Number, System.Globalization.CultureInfo.InvariantCulture) * scaling));

                        break;

                    case 4:
                        // PLC variable udint type
                        this.frmMainApp.mWritePLCValue(varname, Convert.ToUInt32(UInt32.Parse(value, System.Globalization.NumberStyles.Number, System.Globalization.CultureInfo.InvariantCulture) * scaling));

                        break;

                    case 5:
                        // PLC variable real type
                        this.frmMainApp.mWritePLCValue(varname, Convert.ToSingle(Single.Parse(value, System.Globalization.NumberStyles.Number, System.Globalization.CultureInfo.InvariantCulture) * scaling));

                        break;

                    case 6:
                        // PLC variable long real type
                        this.frmMainApp.mWritePLCValue(varname, Convert.ToDouble(Double.Parse(value, System.Globalization.NumberStyles.Number, System.Globalization.CultureInfo.InvariantCulture) * scaling));

                        break;

                    case 10:
                        // PLC variable string type
                        this.frmMainApp.mWritePLCValue(varname, value);

                        break;

                    default:
                        break;
                }

            }
            catch
            {

            }

        }

        private void LoadLanguageStrings()
        {
            lblWindowTitle.Text = lm["FRecipe1.WindowTitle"];
        }

        #region Gr00 variables update

        private void GetVariablesGr00HMITOPLC()
        {
            try
            {

            }
            catch
            {

            }
        }

        private void GetVariablesGr00PLCTOHMI()
        {
            try
            {

            }
            catch
            {

            }
        }

        #endregion

        #region Gr01 variables update

        private void GetVariablesGr01HMITOPLC()
        {
            try
            {

            }
            catch
            {

            }
        }

        private void GetVariablesGr01PLCTOHMI()
        {
            try
            {

            }
            catch
            {

            }
        }

        #endregion

        #region Gr02 variables update

        private void GetVariablesGr02HMITOPLC()
        {
            try
            {

            }
            catch
            {

            }
        }

        private void GetVariablesGr02PLCTOHMI()
        {
            try
            {

            }
            catch
            {

            }
        }

        #endregion

        #region Gr05 variables update

        private void GetVariablesGr05HMITOPLC()
        {
            try
            {

            }
            catch
            {

            }
        }

        private void GetVariablesGr05PLCTOHMI()
        {
            try
            {

            }
            catch
            {

            }
        }

        #endregion

        #endregion

        #region Implementation of Function Keys

        private void SetFunctionKeys(TwinCAT.App.TcFKey fKey)
        {
            fKey.InstallFKeyDelegate(new FKeyDelegate(FKeyDownEvent), new FKeyDelegate(FKeyUpEvent));
            fKey.FKeyTextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            fKey.FKeyImageAlign = System.Drawing.ContentAlignment.MiddleCenter;
            SetFKeyText(fKey);
        }

        private void SetFKeyText(TwinCAT.App.TcFKey fKey)
        {

            fKey.FKeyText(1, lm["FRecipe1.FKey[1]"]); 			                        //""
            fKey.FKeyText(2, lm["FRecipe1.FKey[2]"]); 			                        //""
            fKey.FKeyText(3, lm["FRecipe1.FKey[3]"]); 			                        //""
            fKey.FKeyText(4, ""/*lm["FRecipe1.FKey[4]"]*/);			                        //""
            fKey.FKeyText(5, lm["FRecipe1.FKey[5]"]);                                   //""
            fKey.FKeyText(6, lm["FRecipe1.FKey[6]"]);	                                //""
            fKey.FKeyText(7, ""/*lm["FRecipe1.FKey[7]"]*/);	                                //""
            fKey.FKeyText(8, lm["FRecipe1.FKey[8]"]);	                                //""
            fKey.FKeyText(9, lm["FRecipe1.FKey[9]"]);	                //"Close" 

        }

        private void FKeyDownEvent(int nIdx)
        {

        }

        private void FKeyUpEvent(int nIdx)
        {

            switch (nIdx)
            {
                case 1:
                    this.ucRecipeEditor1.RefreshView();

                    break;
                case 2:
                    if (frmMainApp.userManager.CurrentUserLevel > CUserLevel.Standarduser)
                    {
                        frmMainApp.userManager.LoginDialog(false, false);
                    }

                    if (frmMainApp.userManager.CurrentUserLevel <= CUserLevel.Standarduser)
                    {
                        if (this.ucRecipeEditor1.Create())
                        {
                            this.AddRcpData();
                            this.ucRecipeEditor1.Write();
                        }
                    }

                    break;

                case 3:
                    if (frmMainApp.userManager.CurrentUserLevel > CUserLevel.Standarduser)
                    {
                        frmMainApp.userManager.LoginDialog(false, false);
                    }

                    if (frmMainApp.userManager.CurrentUserLevel <= CUserLevel.Standarduser)
                    {
                        this.ucRecipeEditor1.Delete();
                    }
 
                    break;

                case 4:

                    break;

                case 5:
                    string rcp = this.WriteRcpToPLC();

                    //frmMainApp.mWritePLCValue(".stgGr00HMI.stHMITOPLC.sActRecipe", rcp);
                    frmMainApp.mWritePLCValue(".stgGr01HMI.stHMITOPLC.sActRecipe", rcp);

                    break;

                case 6:
                    if (frmMainApp.userManager.CurrentUserLevel > CUserLevel.Standarduser)
                    {
                        frmMainApp.userManager.LoginDialog(false, false);
                    }

                    if (frmMainApp.userManager.CurrentUserLevel <= CUserLevel.Standarduser)
                    {
                        this.ReadParaFromPLC();
                        this.AddRcpData();
                    }

                    break;

                case 7:

                    break;

                case 8:
                    if (frmMainApp.userManager.CurrentUserLevel > CUserLevel.Standarduser)
                    {
                        frmMainApp.userManager.LoginDialog(false, false);
                    }

                    if (frmMainApp.userManager.CurrentUserLevel <= CUserLevel.Standarduser)
                    {
                        this.ucRecipeEditor1.CopyAll();
                    }
   
                    break;

                case 9:
                    parentForm.BringToFront();

                    break;
            }
        }

        #endregion

    }
}
