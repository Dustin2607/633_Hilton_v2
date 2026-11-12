namespace App
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Text;
    using System.Windows.Forms;
    using System.Runtime.InteropServices;

    using TwinCAT.App;
    using TwinCAT.Ads;

    using App.Utility;
    using App.Components;
    using App.Security;

    public partial class FMainApp : Form
    {

        // Struct packing of the PLC interface: TwinCAT 2 = 1, TwinCAT 3 = 0 (natural alignment)
        private const int nPlcStructPack = 0;

        #region Member enummerations

        // Types of errors into usercontrol
        public enum UserControlErrorType
        {
            None = 0,
            UnableToConnectToADS = 1,
            UnableToDisconnectFromADS = 2,
            UnableToCreateNotificationHandles = 3,
            ADSError = 4
        }

        public enum InternalEventType
        {
            None = 0,
            OnChange_bLiveBit = 1,
            OnChange_ST_Gr00HMITOPLC = 10,
            OnChange_ST_Gr00PLCTOHMI = 11,
            OnChange_ST_Gr01HMITOPLC = 12,
            OnChange_ST_Gr01PLCTOHMI = 13,
            OnChange_ST_Gr02HMITOPLC = 14,
            OnChange_ST_Gr02PLCTOHMI = 15,
            OnChange_ST_Gr05HMITOPLC = 20,
            OnChange_ST_Gr05PLCTOHMI = 21,
            OnChange_ST_Gr00ALARM = 100,
            OnChange_ST_Gr01ALARM = 101,
            OnChange_ST_Gr02ALARM = 102,
            OnChange_ST_Gr05ALARM = 105,
            OnChange_AdsState = 50

        }

        #endregion

        #region Member variables

        // Application references
        private bool bADSConnected;                         // True to connect to the adsClient
        private bool bNotificationHandlesCreated;            // Notification handles for adsClient created

        private bool bNoSystem;
        private bool bSysIsRunning;
        private bool bPlcIsRunning;
        private bool bMachineIsRunning;

        public FMain frmMain;
        private CLanguageManager lm;
        public CUserManager userManager;

        // Application color theme
        public Color colorCaption;
		public Color colorRow2;
		public Color colorRow3;
		public Color colorFKeyBottom;
		public Color colorFKeyLR;

        private Color colorRiexBlue;
        private Color colorRiexNavyBlue1;
        private Color colorRiexNavyBlue2;
        private Color colorRiexLightGray;
        private Color colorRiexDarkGray;

        #endregion

        #region PLC Variables

        // TwinCAT references
        private TcAdsClient adsClient;                      // Object to communicate with the PLC
        private int nRefreshTime = 200;

        // Variables of the PLC
        private bool bLiveBit;
        private ST_Gr00HMITOPLC stGr00HMITOPLC = new ST_Gr00HMITOPLC();
        private ST_Gr00PLCTOHMI stGr00PLCTOHMI = new ST_Gr00PLCTOHMI();
        private ST_Gr01HMITOPLC stGr01HMITOPLC = new ST_Gr01HMITOPLC();
        private ST_Gr01PLCTOHMI stGr01PLCTOHMI = new ST_Gr01PLCTOHMI();
        private ST_Gr02HMITOPLC stGr02HMITOPLC = new ST_Gr02HMITOPLC();
        private ST_Gr02PLCTOHMI stGr02PLCTOHMI = new ST_Gr02PLCTOHMI();
        private ST_Gr05HMITOPLC stGr05HMITOPLC = new ST_Gr05HMITOPLC();
        private ST_Gr05PLCTOHMI stGr05PLCTOHMI = new ST_Gr05PLCTOHMI();

        private ST_Gr00ALARM stGr00ALARM = new ST_Gr00ALARM();
        private ST_Gr01ALARM stGr01ALARM = new ST_Gr01ALARM();
        private ST_Gr02ALARM stGr02ALARM = new ST_Gr02ALARM();
        private ST_Gr05ALARM stGr05ALARM = new ST_Gr05ALARM();

        private ArrayList arlNotificationHandles;

        #region Interface HMI <-> PLC

        #region Enummerations

        public enum ET_MachineMode : short
        {
            eUndefined = 0,
            eAutomatic = 1,
            eCycle = 2,
            eStepping = 3,
            eHome = 4,
            eManual = 5,
            eEStop = 10
        }

        public enum ET_MachineState : short
        {
            eUndefined = 0,
            eAutoExe = 1,
            eAutoSteppingExe = 2,
            eAutoSteppingNoExe = 3,
            eHomeExe = 4,
            eHomeRefExe = 5,
            eEStop = 10
        }

        #endregion

        #region ThermocoupleTyp

        public enum ET_ThermocoupleTyp : short
        {
            eK = 0,				// Typ: K -200°C bis 1370°C
            eJ = 1,				// Typ: J -100°C bis 1200°C
            eL = 2,				// Typ: L 0°C bis 900°C
            eE = 3,				// Typ: E -100°C bis 1000°C
            eT = 4,				// Typ: T -200°C bis 400°C
            eN = 5,				// Typ: N -100°C bis 1300°C
            eU = 6,				// Typ: U 0°C bis 600°C
            eB = 7,				// Typ: B 600°C bis 1800°C
            eR = 8,				// Typ: R 0°C bis 1767°C
            eS = 9,				// Typ: S 0°C bis 1760°C
            eC = 10,			// Typ: C 0°C bis 2320°C
            e30mV = 100,		// +/-30 mV (1uV resolution)
            e60mV = 101,		// +/-60 mV (2uV resolution)
            e75mV = 102,		// +/-75 mV (4uV resolution)
            eNoConn = 999		// No connected 
        }

        #endregion

        #region Welding phases

        public struct ST_PreHeat
        {
            public double lrProcessForce;               // Process force[N]
            public ushort unProcessRamp;				// Process ramp[s]
            public ushort unProcessTime;                // Process time[s]
            public float rProcessCtrlKp;                // Process controller proportional gain Kp
            public float rProcessCtrlTi;				// Process controller integral Ti	
            public float rProcessCtrlLimit;             // Process controller limit output velocity of the drive
        }

        public struct ST_ForceProcess
        {
            public double lrProcessForce;				// Process force[N]
            public ushort unProcessRamp;                // Process ramp[s]
            public ushort unProcessTime;				// Process time[s]
            public double lrProcessDistance;            // Process distance[mm]
            public ushort unCoolingDuration1;           // Duration[s]
            public ushort unCoolingDuration2;           // Duration[s]       
            public double arlrCoolingAirPressure1;      // Air pressure[bar]
            public double arlrCoolingAirPressure2;      // Air pressure[bar]      
            public float rProcessCtrlKp;                // Process controller proportional gain Kp
            public float rProcessCtrlTi;				// Process controller integral Ti	
            public float rProcessCtrlLimit;             // Process controller limit output velocity of the drive
        }

        #endregion

        #region Welding status

        public struct ST_WeldingPhaseStatus
        {
            //public uint dwWeldingPhaseInitTime;       // Welding phase init time[s]
            //public uint dwWeldingPhaseRestTime;       // Welding phase rest time[s]
            public double lrStartWeldingPos;          // Start welding position [mm]
            public double lrEndWeldingPos;            // End welding position [mm]
            public double lrDistanceWelding;          // Distance welding position [mm]
        }

        public struct ST_WeldingTotalStatus
        {
            public uint dwChangeOverInitTime;                        // ChangeOver init time[s]
            public uint dwChangeOverActTime;                         // ChangeOver rest time[s]
            public uint dwWeldnigTotalInitTime;                      // Weldnig total init time[s]
            public uint dwWeldnigTotalRestTime;                      // Weldnig total rest time[s]
            public short nActWeldingPhase;                           // Act welding phase
        }

        #endregion

        #region Quality control

        public enum ET_QS_OKNOK : short
        {
            ET_QS_IDLE = 0,				// Quallity assurance IDLE
            ET_QS_NOK = 1,				// Quallity assurance NOK
            ET_QS_OK = 2				// Quallity assurance OK
        }

        public struct ST_QS_Temperature
        {
            public double lrTemp;                       // Temperature[°C]
            public double lrTempMin;                     // Minimal temperature[°C]		
            public double lrTempMax;                    // Maximal temperature[°C] *)
        }

        public struct ST_QS_DistanceWelding
        {
            public double lrDistanceWelding;            // Welding distance[mm]	
            public double lrDistanceWeldingMin;         // Minimal welding distance[mm]
            public double lrDistanceWeldingMax;         // Minimal welding distance[mm]	
        }

        public struct ST_QS_AirFlow
        {
            public double lrAirFlow;                    // Air flow[l / min]
            public double lrAirPressure;				// Air pressure[bar]	 	
            public double lrAirFlowMin;                 // Minimal air flow[l / min]
            public double lrAirFlowMax;					// Maximal air flow[l / min]
        }

        #endregion

        #region Nested type: ST_Gr00HMITOPLC

        // TwinCAT2 Pack = 1, TwinCAT3 Pack = 0
        [StructLayout(LayoutKind.Sequential, Pack = nPlcStructPack)]
        public class ST_Gr00HMITOPLC
        {
            public ET_MachineMode etMachineMode;        // Machine mode enum variable
            [MarshalAs(UnmanagedType.I1)]
            public bool bBtnStart;                      // Button start
            [MarshalAs(UnmanagedType.I1)]
            public bool bBtnStop;                       // Button stop
            [MarshalAs(UnmanagedType.I1)]
            public bool bBtnReset;                      // Button reset
            [MarshalAs(UnmanagedType.I1)]
            public bool bBtnForceRef;                   // Button reference force
            [MarshalAs(UnmanagedType.I1)]
            public bool bBtnMachinePurge;               // Button machine purge
            [MarshalAs(UnmanagedType.I1)]
            public bool bResetCounterUser;			    // Reset counter user
            [MarshalAs(UnmanagedType.I1)]
            public bool bSafetyInterlockOff;            // Deactivation safety interlocks if machine is in manual mode
            [MarshalAs(UnmanagedType.I1)]
            public bool bProgramActive;                 // Program active
            public float rOverride;                     // Override
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 81)]
            public string sActRecipe = "";									

        }

        #endregion

        #region Nested type: ST_Gr00PLCTOHMI

        // TwinCAT2 Pack = 1, TwinCAT3 Pack = 0
        [StructLayout(LayoutKind.Sequential, Pack = nPlcStructPack)]
        public class ST_Gr00PLCTOHMI
        {
            public ET_MachineMode etMachineMode;        // Machine mode enum variable
            public ET_MachineState etMachineState;      // Machine state enum variable
            public ushort wBtnStartStatus;              // Button start status
            public ushort wBtnStopStatus;               // Button stop status
            public ushort wBtnResetStatus;              // Button reset status
            public ushort wBtnForceRefStatus;           // Button reference force status
            public ushort wBtnAutoStatus;               // Button auto status
            public ushort wBtnHomeStatus;               // Button home status
            public ushort wBtnManualStatus;             // Button manual status
            public ushort wLampStatus;                  // Lamp status
            public ushort wAlarmStatus;                 // Alarm status
            [MarshalAs(UnmanagedType.I1)]
            public bool bMachineRunning;                // Machine running
            [MarshalAs(UnmanagedType.I1)]
            public bool bHomeCompleted;                 // Home completed
            [MarshalAs(UnmanagedType.I1)]               
            public bool bAutoCompleted;                 // Auto completed
            [MarshalAs(UnmanagedType.I1)]
            public bool bModeAutomatic;                 // Machine mode automatic
            [MarshalAs(UnmanagedType.I1)]
            public bool bModeHome;                      // Machine mode home
            [MarshalAs(UnmanagedType.I1)]
            public bool bModeManual;                    // Machine mode manual
            public uint udnCounterTotal;                // Total counter
            public uint udnCounterUser;                 // User counter
            public uint dwCycleTime;				    // Cycletime in 0.01sec / Zykluszeit in 0.01Sekunden
            public double lrMachineLifetime;		    // Machine lifetime
            public double lrMachineLifetimeAfterTurnOn; // Machine lifetime after turn on
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 81)]
            public byte[] sPrgFilePath = new byte[80];                     // Current recipe file

        }

        #endregion

        #region Nested type: ST_Gr01HMITOPLC

        // TwinCAT2 Pack = 1, TwinCAT3 Pack = 0
        [StructLayout(LayoutKind.Sequential, Pack = nPlcStructPack)]
        public class ST_Gr01HMITOPLC
        {
            [MarshalAs(UnmanagedType.I1)]
            public bool bBtnStart;                      // Button start
            [MarshalAs(UnmanagedType.I1)]
            public bool bBtnStop;                       // Button stop
            [MarshalAs(UnmanagedType.I1)]
            public bool bBtnSteppingProcess;            // Stepping process
            public float rOverride;                     // Override 0 - 100 [%]
            [MarshalAs(UnmanagedType.I1)]
            public bool bResetLifetime;                 // Reset life time
            [MarshalAs(UnmanagedType.I1)]
            public bool bResetCounterUser;			    // Reset counter user

            [MarshalAs(UnmanagedType.I1)]
            public bool bBtnAxisSawBowPlus;			    // Button move axis saw bow plus
            [MarshalAs(UnmanagedType.I1)]
            public bool bBtnAxisSawBowMinus;            // Button move axis saw bow minus

            [MarshalAs(UnmanagedType.I1)]
            public bool bBtnAxisAnglePlus;			    // Button move axis angle plus
            [MarshalAs(UnmanagedType.I1)]
            public bool bBtnAxisAngleMinus;             // Button move axis angle minus

            [MarshalAs(UnmanagedType.I1)]
            public bool bBtnSawbandPlus;			    // Button sawband plus
            [MarshalAs(UnmanagedType.I1)]
            public bool bBtnSawbandMinus;               // Button sawband minus

            [MarshalAs(UnmanagedType.I1)]
            public bool bBtnSawbandAirOn;			    // On sawband air
            [MarshalAs(UnmanagedType.I1)]
            public bool bBtnSawbandAirOff;              // Off sawband air

            [MarshalAs(UnmanagedType.I1)]
            public bool bBtnLaserOn;			        // On laser
            [MarshalAs(UnmanagedType.I1)]
            public bool bBtnLaserOff;                   // Off laser

            [MarshalAs(UnmanagedType.I1)]
            public bool bBtnVacuumCleanerOn;			// Vacuum cleaner on
            [MarshalAs(UnmanagedType.I1)]
            public bool bBtnVacuumCleanerOff;           // Vacuum cleaner off


            public double lrAxisSawBowTipDistance;		// Tip distance axis sawbow[mm]
            public double lrAxisSawBowOriginShiftPos;   // Origin shift position axis sawbow[mm]
            public double lrAxisSawBowHomePos;			// Home position axis sawbow[mm]
            public double lrAxisSawBowSoftLimitMax;     // Software limit maximum axis sawbow[mm]
            public double lrAxisSawBowSoftLimitMin;     // Software limit minimum axis sawbow[mm]
            public double lrAxisSawBowNoRefVelo;        // No reference velocity axis sawbow[mm / s]
            public double lrAxisSawBowManualVelo;		// Manual velocity axis sawbow[mm / s]
            public double lrAxisSawBowHomeVelo;	        // Home velocity axis sawbow[mm / s]
            public double lrAxisSawBowAutoVelo;         // Auto velocity axis sawbow[mm / s]

            public double lrAxisAngleTipDistance;		// Tip distance axis angle[mm]
            public double lrAxisAngleOriginShiftPos;    // Origin shift position axis angle[mm]
            public double lrAxisAngleHomePos;			// Home position axis angle[mm]
            public double lrAxisAngleSoftLimitMax;      // Software limit maximum axis angle[mm]
            public double lrAxisAngleSoftLimitMin;      // Software limit minimum axis angle[mm]
            public double lrAxisAngleNoRefVelo;         // No reference velocity axis angle[mm / s]
            public double lrAxisAngleManualVelo;		// Manual velocity axis angle[mm / s]
            public double lrAxisAngleHomeVelo;	        // Home velocity axis angle[mm / s]
            public double lrAxisAngleAutoVelo;	        // Auto velocity axis angle[mm / s]


            public float rSawbandManualSpeed;	        // Manual speed sawband [upm]
            public float rSawbandAutoSpeed;           // Auto speed sawband [upm]

            public float rSawingOverride;               // Sawing override 0 - 100 [%] 
            public float rPipeDiameter;               // Pipe diameter [mm]
            public double lrActSawingAngle; 			// Actual angle of sawing [mm]
            public double lrSafetyDistance;             // Safety distance [mm] 
            public double lrSafeDistSawBandToPipe;		// Safety distance sawband to pipe[mm] 
            public double lrSawBandThickness;           // Sawband thickness [mm]

        }

        #endregion

        #region Nested type: ST_Gr01PLCTOHMI

        // TwinCAT2 Pack = 1, TwinCAT3 Pack = 0
        [StructLayout(LayoutKind.Sequential, Pack = nPlcStructPack)]
        public class ST_Gr01PLCTOHMI
        {
            public ushort wBtnStartStatus;              // Button start status
            public ushort wBtnStopStatus;               // Button stop status
            public ushort wBtnStepProcStatus;           // Button stepping process status
            [MarshalAs(UnmanagedType.I1)]
            public bool bHomeCompleted;                 // Home completed
            [MarshalAs(UnmanagedType.I1)]
            public bool bExecutedProcess;               // Process executed
            public uint udnCounterTotal;                // Total counter
            public uint dwCycleTime;				    // Cycletime in 0.01sec / Zykluszeit in 0.01Sekunden
            public double lrLifetime;				    // Lifetime
            public double lrLifetimeAfterReset;		    // Lifetime after reset
            public double lrLifetimeAfterTurnOn;        // Lifetime after turn on

            public ushort wAxisSawBowStatus;            // Axis sawbow status
            public ushort wAxisAngleStatus;		        // Axis welding left status
            public ushort wSawbandStatus;               // Axis welding left status
            public ushort wSawbandAirStatus;            // Axis welding left status
            public ushort wLaserStatus;		            // Axis welding left status

            public double lrAxisSawBowActPos;            // Actual position axis sawbow [mm]
            public double lrAxisSawBowActVelo;          // Actual velocity axis sawbow [mm/s]
            public double lrAxisSawBowActForce;         // Actual force axis sawbow [N]

            public double lrAxisAngleActPos;            // Actual position axis angle [mm]
            public double lrAxisAngleActVelo;           // Actual velocity axis angle [mm/s]
            public double lrAxisAngleActForce;          // Actual force axis angle [N]

            public double lrSawbandActSpeed;            // Actual speed swaband [Upm]

        }

        #endregion

        #region Nested type: ST_Gr02HMITOPLC

        // TwinCAT2 Pack = 1, TwinCAT3 Pack = 0
        [StructLayout(LayoutKind.Sequential, Pack = nPlcStructPack)]
        public class ST_Gr02HMITOPLC
        {
            [MarshalAs(UnmanagedType.I1)]
            public bool bBtnStart;                      // Button start
            [MarshalAs(UnmanagedType.I1)]
            public bool bBtnStop;                       // Button stop
            [MarshalAs(UnmanagedType.I1)]
            public bool bBtnSteppingProcess;            // Stepping process
            public float rOverride;                     // Override 0 - 100 [%]
            [MarshalAs(UnmanagedType.I1)]
            public bool bResetLifetime;                 // Reset life time
            [MarshalAs(UnmanagedType.I1)]
            public bool bResetCounterUser;			    // Reset counter user

        }

        #endregion

        #region Nested type: ST_Gr02PLCTOHMI

        // TwinCAT2 Pack = 1, TwinCAT3 Pack = 0
        [StructLayout(LayoutKind.Sequential, Pack = nPlcStructPack)]
        public class ST_Gr02PLCTOHMI
        {
            public ushort wBtnStartStatus;              // Button start status
            public ushort wBtnStopStatus;               // Button stop status
            public ushort wBtnStepProcStatus;           // Button stepping process status
            [MarshalAs(UnmanagedType.I1)]
            public bool bHomeCompleted;                 // Home completed
            [MarshalAs(UnmanagedType.I1)]
            public bool bExecutedProcess;               // Process executed
            public uint udnCounterTotal;                // Total counter
            public uint dwCycleTime;				    // Cycletime in 0.01sec / Zykluszeit in 0.01Sekunden
            public double lrLifetime;				    // Lifetime
            public double lrLifetimeAfterReset;		    // Lifetime after reset
            public double lrLifetimeAfterTurnOn;        // Lifetime after turn on

        }

        #endregion

        #region Nested type: ST_Gr05HMITOPLC

        // TwinCAT2 Pack = 1, TwinCAT3 Pack = 0
        [StructLayout(LayoutKind.Sequential, Pack = nPlcStructPack)]
        public class ST_Gr05HMITOPLC
        {
            [MarshalAs(UnmanagedType.I1)]
            public bool bBtnStart;                      // Button start
            [MarshalAs(UnmanagedType.I1)]
            public bool bBtnStop;                       // Button stop
            [MarshalAs(UnmanagedType.I1)]
            public bool bBtnSteppingProcess;            // Stepping process
            public float rOverride;                     // Override 0 - 100 [%]
            [MarshalAs(UnmanagedType.I1)]
            public bool bResetLifetime;                 // Reset life time
            [MarshalAs(UnmanagedType.I1)]
            public bool bResetCounterUser;			    // Reset counter user

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]            // Button move axis clamp plus, ARRAY[1..ungGr05ClampMaxNo] OF BOOL
            public byte[] arbBtnAxisClampPlus = new byte[2];
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]            // Button move axis clamp minus, ARRAY[1..ungGr05ClampMaxNo] OF BOOL
            public byte[] arbBtnAxisClampMinus = new byte[2];

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]            // Button clamp open, ARRAY[1..ungGr05ClampMaxNo] OF BOOL
            public byte[] arbBtnClampOpen = new byte[2];
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]            // Button clamp close, ARRAY[1..ungGr05ClampMaxNo] OF BOOL
            public byte[] arbBtnClampClose = new byte[2];

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]            // Button position cylinder open, ARRAY[1..ungGr05CylinderPosMaxNo] OF BOOL
            public byte[] arbBtnCylinderPosOpen = new byte[3];
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]            // Button position cylinder close, ARRAY[1..ungGr05CylinderPosMaxNo] OF BOOL
            public byte[] arbBtnCylinderPosClose = new byte[3];

            [MarshalAs(UnmanagedType.I1)]
            public bool bBtnSlideUp;                                        // Button slide up
            [MarshalAs(UnmanagedType.I1)]
            public bool bBtnSlideDown;                                      // Button slide down
            [MarshalAs(UnmanagedType.I1)]
            public bool bBtnRemovalBandToPlus;                              // Reset counter user
            [MarshalAs(UnmanagedType.I1)]
            public bool bBtnRemovalBandToMinus;                             // Reset counter user

            [MarshalAs(UnmanagedType.I1)]
            public bool bSlideActive;                                       // Slide active
            [MarshalAs(UnmanagedType.I1)]
            public bool bCylinderPosActive;                                 // Position cylinder active

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]            // Tip distance axis clamp, ARRAY[1..ungGr05ClampMaxNo] OF LREAL
            public double[] arlrAxisClampTipDistance = new double[2];

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]            // Origin shift position axis clamp, ARRAY[1..ungGr05ClampMaxNo] OF LREAL
            public double[] arlrAxisClampOriginShiftPos = new double[2];

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]            // Home position axis clamp, ARRAY[1..ungGr05ClampMaxNo] OF LREAL
            public double[] arlrAxisClampHomePos = new double[2];

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]            // Software limit maximum axis clamp, ARRAY[1..ungGr05ClampMaxNo] OF LREAL
            public double[] arlrAxisClampSoftLimitMax = new double[2];

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]            // Software limit minimum axis clamp, ARRAY[1..ungGr05ClampMaxNo] OF LREAL
            public double[] arlrAxisClampSoftLimitMin = new double[2];

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]            // No reference velocity axis clamp, ARRAY[1..ungGr05ClampMaxNo] OF LREAL
            public double[] arlrAxisClampNoRefVelo = new double[2];

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]            // Manual velocity axis clamp, ARRAY[1..ungGr05ClampMaxNo] OF LREAL
            public double[] arlrAxisClampManualVelo = new double[2];

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]            // Home velocity axis clamp, ARRAY[1..ungGr05ClampMaxNo] OF LREAL
            public double[] arlrAxisClampHomeVelo = new double[2];

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]            // Auto velocity axis clamp, ARRAY[1..ungGr05ClampMaxNo] OF LREAL
            public double[] arlrAxisClampAutoVelo = new double[2];

            public double lrActSawingLength;                                // Actual sawing length [mm]
        }

        #endregion

        #region Nested type: ST_Gr05PLCTOHMI

        // TwinCAT2 Pack = 1, TwinCAT3 Pack = 0
        [StructLayout(LayoutKind.Sequential, Pack = nPlcStructPack)]
        public class ST_Gr05PLCTOHMI
        {
            public ushort wBtnStartStatus;              // Button start status
            public ushort wBtnStopStatus;               // Button stop status
            public ushort wBtnStepProcStatus;           // Button stepping process status
            [MarshalAs(UnmanagedType.I1)]
            public bool bHomeCompleted;                 // Home completed
            [MarshalAs(UnmanagedType.I1)]
            public bool bExecutedProcess;               // Process executed
            public uint udnCounterTotal;                // Total counter
            public uint dwCycleTime;				    // Cycletime in 0.01sec / Zykluszeit in 0.01Sekunden
            public double lrLifetime;				    // Lifetime
            public double lrLifetimeAfterReset;		    // Lifetime after reset
            public double lrLifetimeAfterTurnOn;        // Lifetime after turn on

            public ushort wAxisClampStatus;             // Axis clamp status
            public ushort wSlideStatus;                 // Axis slide status
            public ushort wRemovalBandStatus;           // Axis removal band status

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]            // Clamp status, ARRAY[1..ungGr05ClampMaxNo] OF WORD
            public ushort[] arwClampStatus = new ushort[2];

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]            // Position cylinder status, ARRAY[1..ungGr05CylinderPosMaxNo] OF WORD
            public ushort[] arwCylinderPosStatus = new ushort[3];

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]            // Axis clamp actual position, ARRAY[1..ungGr05ClampMaxNo] OF LREAL
            public double[] arlrAxisClampActPos = new double[2];

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]            // Axis clamp actual velocity, ARRAY[1..ungGr05ClampMaxNo] OF LREAL
            public double[] arlrAxisClampActVelo = new double[2];

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]            // Axis clamp actual velocity, ARRAY[1..ungGr05ClampMaxNo] OF LREAL
            public double[] arlrAxisClampActForce = new double[2];

            public ushort unSawingStep;                                     // Current sawing step
        }

        #endregion

        #endregion

        #region Interface Alarms

        #region Enummerations

        public enum ET_AlarmType : short
        {
            eIdle = 0,
            eFatalError = 1,
            eError = 2,
            eWarning = 3,
            eMessage = 4,
            eHint = 5
        }

        #endregion

        #region Nested type: ST_AlarmProperties
        // TwinCAT2 Pack = 1, TwinCAT3 Pack = 0
        [StructLayout(LayoutKind.Sequential, Pack = nPlcStructPack)]
        public struct ST_AlarmProperties
        {
            //[MarshalAs(UnmanagedType.ByValArray, ArraySubType = UnmanagedType.I1, SizeConst = 64)]
            [MarshalAs(UnmanagedType.I1)]
            public bool bActive;				    // Alarm on 
            public uint dtDateTime;				    // Alarm time stamp 
            public ET_AlarmType enType;				// Alarm type
            public int dnCode;				        // Alarm code
        }

        #endregion

        #region Nested type: ST_AlarmOut
        // TwinCAT2 Pack = 1, TwinCAT3 Pack = 0
        [StructLayout(LayoutKind.Sequential, Pack = nPlcStructPack)]
        public class ST_AlarmOut
        {
            //[MarshalAs(UnmanagedType.ByValArray, ArraySubType = UnmanagedType.I1, SizeConst = 64)]
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 32)]
            public ST_AlarmProperties[] arbFatalError = new ST_AlarmProperties[32];
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 32)]
            public ST_AlarmProperties[] arbError = new ST_AlarmProperties[32];
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 32)]
            public ST_AlarmProperties[] arbWarning = new ST_AlarmProperties[32];
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 32)]
            public ST_AlarmProperties[] arbMessage = new ST_AlarmProperties[32];
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 32)]
            public ST_AlarmProperties[] arbHint = new ST_AlarmProperties[32];
            [MarshalAs(UnmanagedType.I1)]
            public bool bFatalError;				// Fatal error in group / Fataler Fehler in der Gruppe 
            [MarshalAs(UnmanagedType.I1)]
            public bool bError;				        // Error in group / Fehler in der Gruppe 
            [MarshalAs(UnmanagedType.I1)]
            public bool bWarning;				    // Warning in group / Warnung  in der Gruppe
            [MarshalAs(UnmanagedType.I1)]
            public bool bMessage;				    // Message in group / Meldung in der Gruppe
            [MarshalAs(UnmanagedType.I1)]
            public bool bHint;				        // Hint in group / Hint in der Gruppe
        }

        #endregion

        #region Nested type: ST_ControlAlarm

        // TwinCAT2 Pack = 1, TwinCAT3 Pack = 0
        [StructLayout(LayoutKind.Sequential, Pack = nPlcStructPack)]
        private class ST_ControlAlarm : ST_AlarmOut
        {

        }

        #endregion

        #region Nested type: ST_ManualAlarm

        // TwinCAT2 Pack = 1, TwinCAT3 Pack = 0
        [StructLayout(LayoutKind.Sequential, Pack = nPlcStructPack)]
        private class ST_ManualAlarm : ST_AlarmOut
        {

        }

        #endregion

        #region Nested type: ST_HomeAlarm

        // TwinCAT2 Pack = 1, TwinCAT3 Pack = 0
        [StructLayout(LayoutKind.Sequential, Pack = nPlcStructPack)]
        private class ST_HomeAlarm : ST_AlarmOut
        {

        }

        #endregion

        #region Nested type: ST_AutoAlarm

        // TwinCAT2 Pack = 1, TwinCAT3 Pack = 0
        [StructLayout(LayoutKind.Sequential, Pack = nPlcStructPack)]
        private class ST_AutoAlarm : ST_AlarmOut
        {

        }

        #endregion

        #region Nested type: ST_AlarmRef

        // TwinCAT2 Pack = 1, TwinCAT3 Pack = 0
        [StructLayout(LayoutKind.Sequential, Pack = nPlcStructPack)]
        public class ST_AlarmRef
        {
            public ST_AlarmOut stControl = new ST_AlarmOut();
            public ST_AlarmOut stMaintenance = new ST_AlarmOut();
            public ST_AlarmOut stManual = new ST_AlarmOut();
            public ST_AlarmOut stHome = new ST_AlarmOut();
            public ST_AlarmOut stAuto = new ST_AlarmOut();
        }

        #endregion

        #region Nested type: ST_Alarm

        // TwinCAT2 Pack = 1, TwinCAT3 Pack = 0
        [StructLayout(LayoutKind.Sequential, Pack = nPlcStructPack)]
        public class ST_Alarm
        {
            public ST_AlarmRef stAlarmRef = new ST_AlarmRef();              // Alarm
        }

        #endregion

        #region Nested type: ST_Gr00ALARM

        // TwinCAT2 Pack = 1, TwinCAT3 Pack = 0
        [StructLayout(LayoutKind.Sequential, Pack = nPlcStructPack)]
        public class ST_Gr00ALARM : ST_AlarmRef
        {

        }

        #endregion

        #region Nested type: ST_Gr01ALARM

        // TwinCAT2 Pack = 1, TwinCAT3 Pack = 0
        [StructLayout(LayoutKind.Sequential, Pack = nPlcStructPack)]
        public class ST_Gr01ALARM : ST_AlarmRef
        {

        }

        #endregion

        #region Nested type: ST_Gr02ALARM

        // TwinCAT2 Pack = 1, TwinCAT3 Pack = 0
        [StructLayout(LayoutKind.Sequential, Pack = nPlcStructPack)]
        public class ST_Gr02ALARM : ST_AlarmRef
        {

        }

        #endregion

        #region Nested type: ST_Gr05ALARM

        // TwinCAT2 Pack = 1, TwinCAT3 Pack = 0
        [StructLayout(LayoutKind.Sequential, Pack = nPlcStructPack)]
        public class ST_Gr05ALARM : ST_AlarmRef
        {

        }

        #endregion

        #endregion

        #endregion

        #region Systemcode

        #region Constructor

        /// <summary>
        /// Constructor FMainApp.
        /// </summary>
        public FMainApp()
        {
            InitializeComponent();


            // Only one instance of the adsClient
            adsClient = new TcAdsClient();

            // User Manager
            userManager = new CUserManager();
            userManager.FileName = "AppUser.usr";
            userManager.CurrentUserChanged += UserManager_CurrentUserChanged;
            userManager.LoginDialog(true, "riex", "admin");

            // Language Manager
            try
            {
                lm = new CLanguageManager(this, false);

                // Delegate instance: Error handling for errors from the TCLM
                //lm.Error += new CLanguageManager.TCLMErrorEventHandler(tclm_Error);
            }
            catch (Exception ex)
            {
                //string tmp = "Error during opening language manager database!";
            }

            // Connect all components to the Language Manager
            ucHeader1.LanguageManager = lm;
            panel1.Controls.Add(this.ucHeader1);
            userManager.LanguageManager = lm;
            

            colorRiexBlue = Color.FromArgb(51, 81, 122);
            colorRiexNavyBlue1 = Color.FromArgb(39, 79, 119);
            colorRiexNavyBlue2 = Color.FromArgb(0, 2, 40);
            colorRiexLightGray = SystemColors.Control;
            colorRiexDarkGray = Color.FromArgb(102, 102, 102);

            SetFormStyle(this);
            SetColorTheme(1);

            Cursor.Hide();
       
        }

        #endregion

        #endregion

        #region Properties

        /// <summary>
        /// Gets / sets the ads clinet reference.
        /// </summary>
        /// <value>The ads server ref.</value>
        [Description("Gets / sets the ads client reference."), Category("App")]
        public TcAdsClient AdsClientRef
        {
            get { return this.adsClient; }
            set {this.adsClient = value; }
        }

        public int RefreshTime
        {
            get { return this.nRefreshTime; }
            set { this.nRefreshTime = value; }
        }

        [Browsable(false)]
        public bool NoSystem
        {
            get { return this.bNoSystem; }
            set { this.bNoSystem = value; }
        }

        [Browsable(false)]
        public bool SysIsRunning
        {
            get { return this.bSysIsRunning; }
            set { this.bSysIsRunning = value; }
        }

        [Browsable(false)]
        public bool PlcIsRunning
        {
            get { return this.bPlcIsRunning; }
            set { this.bPlcIsRunning = value; }
        }

        [Browsable(false)]
        public bool MachineIsRunning
        {
            get { return this.bMachineIsRunning; }
            set { this.bMachineIsRunning = value; }
        }

        [Browsable(false)]
        public bool ADSConnect
        {
            set
            {
                if ((value != bADSConnected) && value)
                {
                    bADSConnected = mADSConnect();
                }

                if ((value != bADSConnected) && (value == false))
                {
                    mADSDisconnect();
                    bADSConnected = false;
                }
            }
            get { return bADSConnected; }
        }

        [Browsable(false)]
        public ST_Gr00HMITOPLC Gr00HMITOPLC
        {
            get { return stGr00HMITOPLC; }
        }

        [Browsable(false)]
        public ST_Gr00PLCTOHMI Gr00PLCTOHMI
        {
            get { return stGr00PLCTOHMI; }
        }

        [Browsable(false)]
        public ST_Gr01HMITOPLC Gr01HMITOPLC
        {
            get { return stGr01HMITOPLC; }
        }

        [Browsable(false)]
        public ST_Gr01PLCTOHMI Gr01PLCTOHMI
        {
            get { return stGr01PLCTOHMI; }
        }

        [Browsable(false)]
        public ST_Gr02HMITOPLC Gr02HMITOPLC
        {
            get { return stGr02HMITOPLC; }
        }

        [Browsable(false)]
        public ST_Gr02PLCTOHMI Gr02PLCTOHMI
        {
            get { return stGr02PLCTOHMI; }
        }

        [Browsable(false)]
        public ST_Gr05HMITOPLC Gr05HMITOPLC
        {
            get { return stGr05HMITOPLC; }
        }

        [Browsable(false)]
        public ST_Gr05PLCTOHMI Gr05PLCTOHMI
        {
            get { return stGr05PLCTOHMI; }
        }

        [Browsable(false)]
        public ST_Gr00ALARM Gr00ALARM
        {
            get { return stGr00ALARM; }
        }

        [Browsable(false)]
        public ST_Gr01ALARM Gr01ALARM
        {
            get { return stGr01ALARM; }
        }

        [Browsable(false)]
        public ST_Gr02ALARM Gr02ALARM
        {
            get { return stGr02ALARM; }
        }

        [Browsable(false)]
        public ST_Gr05ALARM Gr05ALARM
        {
            get { return stGr05ALARM; }
        }

        #endregion

        #region User interface

        #endregion

        #region Events

        #region Form Events

        private void frmMainApp_Load(object sender, EventArgs e)
        {
            this.ADSConnect = true;

            //lm.Sprache = lm.Translate("DEUTSCH", lm.Sprache, "ENGLISCH");
            lm.Sprache = lm.Translate("ENGLISCH", lm.Sprache, "DEUTSCH");
            //lm.Sprache = lm.Translate("SPANISCH", lm.Sprache, "DEUTSCH");
            lm.SaveAllChanges();

            lm.StringDel += new CLanguageManager.InitStringDelegate(LoadLanguageStrings);
            LoadLanguageStrings();

            frmMain = new FMain();
            frmMain.MdiParent = this;
            frmMain.CaptionBackColor = Color.FromArgb(51, 81, 122);//colorCaption;
            frmMain.Show();

            ucHeader1.AdsClientRef = this.adsClient;
            ucHeader1.OnSystemState += new System.EventHandler<App.Components.UCHeader.OnSystemStateArgs>(this.ucHeader1_OnSystemState);
            ucHeader1.tcEventLoggerLine1.TcEventLogData = frmMain.GetFormDiagnosis().GetEventLoggerData();

            // Show the user
            if (userManager.CurrentUserLevel != CUserLevel.None)
            {
                lblUser.Text = "User: " + userManager.CurrentUserName;
                lblUserLevel.Text = "Level: " + userManager.CurrentUserLevel.ToString();
            }
            else
            {
                lblUser.Text = "No user logged";
                lblUserLevel.Text = " ";
            }

            // bring always to front
            this.TopMost = true; 
        }

        private void ucHeader1_OnSystemState(object sender, Components.UCHeader.OnSystemStateArgs eucHeaderOnSystemStateArgs)
        {
            bNoSystem = false;
            bSysIsRunning = false;
            bPlcIsRunning = false;
            bMachineIsRunning = false;

            switch ((int)eucHeaderOnSystemStateArgs.SystemState)
            {
                case 0: // eNoSystem
                    bNoSystem = true;

                    break;

                case 1: // eSysIsRunning
                    bSysIsRunning = true;

                    break;

                case 2: // ePlcIsRunning
                    bSysIsRunning = true;
                    bPlcIsRunning = true;

                    // Create notification handles
                    if (bNotificationHandlesCreated == false)
                    {
                        bNotificationHandlesCreated = !mCreateNotificationHandles();
                    }

                    break;

                case 3: // eMachineIsRunning
                    bSysIsRunning = true;
                    bPlcIsRunning = true;
                    bMachineIsRunning = true;

                    break;

            }
        }

        protected override void WndProc(ref Message m)
        {
            if (m.Msg == 5)
                return;
            base.WndProc(ref m);
        }

        #endregion

        #region Object Events

        private void UserManager_CurrentUserChanged(CUser user, bool logOn)
        {
            if (logOn == true)
            {
                lblUser.Text = "User: " + user.Name;
                lblUserLevel.Text = "Level: " + user.UserLevel.ToString();
                // log.Info("User logged in -> " + user.FullName);
            }
            else
            {
                lblUser.Text = "No user logged";
                lblUserLevel.Text = " ";
                // log.Info("User logged out -> " + user.FullName);
            }
        }

        #endregion

        #region User Events

        public event EventHandler<OnErrorArgs> OnError; /* Event for internal usercontrol errors */
        public event EventHandler<OnEventArgs> OnEvent; /* Event for internal usercontrol errors */

        #region Nested type: OnErrorArgs

        public class OnErrorArgs : EventArgs
        {
            private readonly UserControlErrorType etUserControlErrorType;
            private readonly String strErrorMessage;

            public OnErrorArgs(UserControlErrorType UserControlErrorType, String strErrorMessage)
            {
                etUserControlErrorType = UserControlErrorType;
                this.strErrorMessage = strErrorMessage;
            }

            public String ErrorMessage
            {
                get { return strErrorMessage; }
            }

            public UserControlErrorType UserControlErrorType
            {
                get { return etUserControlErrorType; }
            }
        }

        #endregion

        #region Nested type: OnEventArgs

        public class OnEventArgs : EventArgs
        {
            private readonly InternalEventType etInternalEventType;

            public OnEventArgs(InternalEventType EventType)
            {
                etInternalEventType = EventType;
            }

            public InternalEventType EventType
            {
                get { return etInternalEventType; }
            }
        }

        #endregion

        #endregion

        #endregion

        #region Interface implementation

        #endregion

        #region Public method

        /// <summary>
        /// Returns the object language manager.
        /// </summary>
        [Description("Returns the object language manager."), Category("Application")]
        public CLanguageManager GetLanguageManager()
        {
            if (lm != null)
                return lm;
            return null;
        }

        #region Read PLC value

        public object mReadPLCValue(string sPLCVariableName)
        {
            ITcAdsSymbol iTcAdsSymbol;
            
            try
            {
                // Getting the symbol info of variable
                iTcAdsSymbol = adsClient.ReadSymbolInfo(sPLCVariableName);

                //read value of variable
                return adsClient.ReadSymbol(iTcAdsSymbol);

            }
            catch (Exception e)
            {
                mInternalError(UserControlErrorType.UnableToCreateNotificationHandles, e.Message);
            }
            return null;
        }

        public object mReadPLCValue(string sPLCVariableName, Type tType)
        {
            int hValueHandle;

            try
            {
                // Getting the handle - needed for writing the value
                hValueHandle = adsClient.CreateVariableHandle(sPLCVariableName);

                //write by handle
                //the second parameter is the object to be read from the PLC
                return adsClient.ReadAny(hValueHandle, tType);

            }
            catch (Exception e)
            {
                mInternalError(UserControlErrorType.UnableToCreateNotificationHandles, e.Message);
            }
            return null;
        }

        public object mReadPLCValue(string sPLCVariableName, Type tType, int[] args)
        {
            int hValueHandle;

            try
            {
                // Getting the handle - needed for writing the value
                hValueHandle = adsClient.CreateVariableHandle(sPLCVariableName);

                //write by handle
                //the second parameter is the object to be read from the PLC
                return adsClient.ReadAny(hValueHandle, tType, args);

            }
            catch (Exception e)
            {
                mInternalError(UserControlErrorType.UnableToCreateNotificationHandles, e.Message);
            }
            return null;
        }

        #endregion

        #region Write PLC value

        public bool mWritePLCValue(string sPLCVariableName, bool bValue)
        {
            int hValueHandle;

            try
            {
                // Getting the handle - needed for writing the value
                hValueHandle = adsClient.CreateVariableHandle(sPLCVariableName);

                //write by handle
                //the second parameter is the object to be written to the PLC variable
                adsClient.WriteAny(hValueHandle, (Boolean)bValue);

                return false;
            }
            catch (Exception e)
            {
                mInternalError(UserControlErrorType.UnableToCreateNotificationHandles, e.Message);
            }
            return true;
        }

        public bool mWritePLCValue(string sPLCVariableName, object oValue)
        {
            int hValueHandle;

            try
            {
                // Getting the handle - needed for writing the value
                hValueHandle = adsClient.CreateVariableHandle(sPLCVariableName);

                //write by handle
                //the second parameter is the object to be written to the PLC variable
                adsClient.WriteAny(hValueHandle, oValue);

                return false;
            }
            catch (Exception e)
            {
                mInternalError(UserControlErrorType.UnableToCreateNotificationHandles, e.Message);
            }
            return true;
        }

        public bool mWritePLCValue(string sPLCVariableName, object oValue, int[] args)
        {
            int hValueHandle;

            try
            {
                // Getting the handle - needed for writing the value
                hValueHandle = adsClient.CreateVariableHandle(sPLCVariableName);

                //write by handle
                //the second parameter is the object to be written to the PLC variable
                adsClient.WriteAny(hValueHandle, oValue, args);

                return false;
            }
            catch (Exception e)
            {
                mInternalError(UserControlErrorType.UnableToCreateNotificationHandles, e.Message);
            }
            return true;
        }

        public bool mWritePLCValue(string sPLCVariableName, string sValue)
        {
            int hValueHandle;

            try
            {
                // Getting the handle - needed for writing the value
                hValueHandle = adsClient.CreateVariableHandle(sPLCVariableName);

                //write by handle
                //the second parameter is the object to be written to the PLC variable
                adsClient.WriteAny(hValueHandle, (String)sValue, new int[] {80});

                return false;
            }
            catch (Exception e)
            {
                mInternalError(UserControlErrorType.UnableToCreateNotificationHandles, e.Message);
            }
            return true;
        }

        public bool mWritePLCValue(string sPLCVariableName, string sValue, int nLenght)
        {
            int hValueHandle;

            try
            {
                // Getting the handle - needed for writing the value
                hValueHandle = adsClient.CreateVariableHandle(sPLCVariableName);

                //write by handle
                //the second parameter is the object to be written to the PLC variable
                adsClient.WriteAny(hValueHandle, (String)sValue, new int[] { nLenght });

                return false;
            }
            catch (Exception e)
            {
                mInternalError(UserControlErrorType.UnableToCreateNotificationHandles, e.Message);
            }
            return true;
        }

        #endregion

        #endregion

        #region Private methods

        private void SetFormStyle(Form form)
        {
            form.Location = new Point(0, 0);
            form.MaximumSize = new System.Drawing.Size(1024, 768);
            form.MinimumSize = new System.Drawing.Size(1024, 768);
            form.FormBorderStyle = FormBorderStyle.None;
            form.WindowState = FormWindowState.Maximized;
        }

        private void SetColorTheme(int nAppColorTheme)
        {
            // Set color theme
            switch (nAppColorTheme)
            {
                default:
                case 1:
                    colorCaption = colorRiexBlue;
                    colorRow2 = colorRiexLightGray;
                    colorRow3 = colorRiexLightGray;
                    colorFKeyBottom = colorRiexDarkGray;
                    colorFKeyLR = colorRiexDarkGray;

                    break;
                case 2:

                    break;
                case 3:

                    break;
                case 4:

                    break;
            }

            // Set color the ucHeader1
            ucHeader1.CaptionBackColor = colorCaption;
            ucHeader1.ColorRow2 = colorRow2;
            ucHeader1.ColorRow3 = colorRow3;

            tcFKeyBottom.FKeyBtnBackColor = colorFKeyBottom;
            tcFKeyBottom.FKeyBtnSelectedColor = colorRiexNavyBlue1;

        }

        private void LoadLanguageStrings()
        {
            this.Text = lm["x"];
        }

        #region Error Handling

        private bool mInternalError(UserControlErrorType etUserControlErrorType, String strErrorMessage)
        {
            if (OnError != null)
                OnError(this, new OnErrorArgs(etUserControlErrorType, strErrorMessage));
            return true;
        }

        #endregion

        #endregion

        #region Override methods

        #endregion

        #region TwinCat ADS Routinen

        private void adsClient_AdsNotificationEx(object sender, AdsNotificationExEventArgs e)
        {
            try
            {
                switch ((int)e.UserData)
                {
                    case 1: // bLiveBit
                        bLiveBit = (bool)e.Value;
                        if (OnEvent != null)
                        {
                            OnEvent(this, new OnEventArgs(InternalEventType.OnChange_bLiveBit));
                        }

                        break;

                    case 10: // ST_Gr00HMITOPLC
                        stGr00HMITOPLC = (ST_Gr00HMITOPLC)e.Value;
                        if (OnEvent != null)
                        {
                            OnEvent(this, new OnEventArgs(InternalEventType.OnChange_ST_Gr00HMITOPLC));
                        }

                        break;

                    case 11: // ST_Gr00PLCTOHMI
                        stGr00PLCTOHMI = (ST_Gr00PLCTOHMI)e.Value;
                        if (OnEvent != null)
                        {
                            OnEvent(this, new OnEventArgs(InternalEventType.OnChange_ST_Gr00PLCTOHMI));
                        }

                        break;

                    case 12: // ST_Gr01HMITOPLC
                        stGr01HMITOPLC = (ST_Gr01HMITOPLC)e.Value;
                        if (OnEvent != null)
                        {
                            OnEvent(this, new OnEventArgs(InternalEventType.OnChange_ST_Gr01HMITOPLC));
                        }

                        break;

                    case 13: // ST_Gr01PLCTOHMI
                        stGr01PLCTOHMI = (ST_Gr01PLCTOHMI)e.Value;
                        if (OnEvent != null)
                        {
                            OnEvent(this, new OnEventArgs(InternalEventType.OnChange_ST_Gr01PLCTOHMI));
                        }

                        break;

                    case 14: // ST_Gr02HMITOPLC
                        stGr02HMITOPLC = (ST_Gr02HMITOPLC)e.Value;
                        if (OnEvent != null)
                        {
                            OnEvent(this, new OnEventArgs(InternalEventType.OnChange_ST_Gr02HMITOPLC));
                        }

                        break;

                    case 15: // ST_Gr02PLCTOHMI
                        stGr02PLCTOHMI = (ST_Gr02PLCTOHMI)e.Value;
                        if (OnEvent != null)
                        {
                            OnEvent(this, new OnEventArgs(InternalEventType.OnChange_ST_Gr02PLCTOHMI));
                        }

                        break;

                    case 20: // ST_Gr05HMITOPLC
                        stGr05HMITOPLC = (ST_Gr05HMITOPLC)e.Value;
                        if (OnEvent != null)
                        {
                            OnEvent(this, new OnEventArgs(InternalEventType.OnChange_ST_Gr05HMITOPLC));
                        }

                        break;

                    case 21: // ST_Gr05PLCTOHMI
                        stGr05PLCTOHMI = (ST_Gr05PLCTOHMI)e.Value;
                        if (OnEvent != null)
                        {
                            OnEvent(this, new OnEventArgs(InternalEventType.OnChange_ST_Gr05PLCTOHMI));
                        }

                        break;

                    case 100: // ST_Gr00ALARM
                        stGr00ALARM = (ST_Gr00ALARM)e.Value;
                        if (OnEvent != null)
                        {
                            OnEvent(this, new OnEventArgs(InternalEventType.OnChange_ST_Gr00ALARM));
                        }

                        break;

                    case 101: // ST_Gr01ALARM
                        stGr01ALARM = (ST_Gr01ALARM)e.Value;
                        if (OnEvent != null)
                        {
                            OnEvent(this, new OnEventArgs(InternalEventType.OnChange_ST_Gr01ALARM));
                        }

                        break;

                    case 102: // ST_Gr02ALARM
                        stGr02ALARM = (ST_Gr02ALARM)e.Value;
                        if (OnEvent != null)
                        {
                            OnEvent(this, new OnEventArgs(InternalEventType.OnChange_ST_Gr02ALARM));
                        }

                        break;

                    case 105: // ST_Gr05ALARM
                        stGr05ALARM = (ST_Gr05ALARM)e.Value;
                        if (OnEvent != null)
                        {
                            OnEvent(this, new OnEventArgs(InternalEventType.OnChange_ST_Gr05ALARM));
                        }

                        break;

                }
            }
            catch (Exception ex)
            {
                mInternalError(UserControlErrorType.ADSError, ex.Message);
            }
        }

        private bool mCreateNotificationHandles()
        {
            try
            {
                // Creating an event for changes of the PLC variable values
                arlNotificationHandles = new ArrayList();
                adsClient.AdsNotificationEx += new AdsNotificationExEventHandler(adsClient_AdsNotificationEx);
                arlNotificationHandles.Clear();

                // Initializing the monitoring of the PLC variables            
                //arlNotificationHandles.Add(adsClient.AddDeviceNotificationEx("GVL_HMI.bLiveBit", AdsTransMode.OnChange, nRefreshTime, 0, 1, typeof(Boolean)));
                arlNotificationHandles.Add(adsClient.AddDeviceNotificationEx(".stgGr00HMI.stHMITOPLC", AdsTransMode.OnChange, nRefreshTime, 0, 10, typeof(ST_Gr00HMITOPLC)));
                arlNotificationHandles.Add(adsClient.AddDeviceNotificationEx(".stgGr00HMI.stPLCTOHMI", AdsTransMode.OnChange, nRefreshTime, 0, 11, typeof(ST_Gr00PLCTOHMI)));
                arlNotificationHandles.Add(adsClient.AddDeviceNotificationEx(".stgGr01HMI.stHMITOPLC", AdsTransMode.OnChange, nRefreshTime, 0, 12, typeof(ST_Gr01HMITOPLC)));
                arlNotificationHandles.Add(adsClient.AddDeviceNotificationEx(".stgGr01HMI.stPLCTOHMI", AdsTransMode.OnChange, nRefreshTime, 0, 13, typeof(ST_Gr01PLCTOHMI)));
                arlNotificationHandles.Add(adsClient.AddDeviceNotificationEx(".stgGr02HMI.stHMITOPLC", AdsTransMode.OnChange, nRefreshTime, 0, 14, typeof(ST_Gr02HMITOPLC)));
                arlNotificationHandles.Add(adsClient.AddDeviceNotificationEx(".stgGr02HMI.stPLCTOHMI", AdsTransMode.OnChange, nRefreshTime, 0, 15, typeof(ST_Gr02PLCTOHMI)));
                arlNotificationHandles.Add(adsClient.AddDeviceNotificationEx(".stgGr05HMI.stHMITOPLC", AdsTransMode.OnChange, nRefreshTime, 0, 20, typeof(ST_Gr05HMITOPLC)));
                arlNotificationHandles.Add(adsClient.AddDeviceNotificationEx(".stgGr05HMI.stPLCTOHMI", AdsTransMode.OnChange, nRefreshTime, 0, 21, typeof(ST_Gr05PLCTOHMI)));
                arlNotificationHandles.Add(adsClient.AddDeviceNotificationEx(".stgGr00Alarm", AdsTransMode.OnChange, nRefreshTime, 0, 100, typeof(ST_Gr00ALARM)));
                arlNotificationHandles.Add(adsClient.AddDeviceNotificationEx(".stgGr01Alarm", AdsTransMode.OnChange, nRefreshTime, 0, 101, typeof(ST_Gr01ALARM)));
                arlNotificationHandles.Add(adsClient.AddDeviceNotificationEx(".stgGr02Alarm", AdsTransMode.OnChange, nRefreshTime, 0, 102, typeof(ST_Gr02ALARM)));
                arlNotificationHandles.Add(adsClient.AddDeviceNotificationEx(".stgGr05Alarm", AdsTransMode.OnChange, nRefreshTime, 0, 105, typeof(ST_Gr05ALARM)));

                return false;
            }
            catch (Exception e)
            {
                mInternalError(UserControlErrorType.UnableToCreateNotificationHandles, e.Message);
            }
            return true;


        }

        private bool mADSConnect()
        {
            try
            {
                // Connecting to external PLC - Runtime 1
                // PLC RunTime 1 - TwinCAT 2 = 801, TwinCAT 3 = 851
                adsClient.Connect("9.4.19.82.1.1", 851);

                // Connecting to local PLC - Runtime 1
                // PLC RunTime 1 - TwinCAT 2 = 801, TwinCAT 3 = 851
                //adsClient.Connect(801);

                // Create notification handles
                bNotificationHandlesCreated = !mCreateNotificationHandles();

                // Map the adsClient object to the main app
                CMainApp.GetMainAppForm().AdsClientRef = adsClient;

                return false;
            }
            catch (Exception e)
            {
                mInternalError(UserControlErrorType.UnableToConnectToADS, e.Message);
            }
            return true;
        }

        private void mADSDisconnect()
        {
            try
            {
                foreach (int handle in arlNotificationHandles)
                {
                    adsClient.DeleteDeviceNotification(handle);
                }

                arlNotificationHandles.Clear();
                adsClient.Dispose();
            }
            catch (Exception e)
            {
                mInternalError(UserControlErrorType.UnableToDisconnectFromADS, e.Message);
            }
        }

        #endregion

    }

}
