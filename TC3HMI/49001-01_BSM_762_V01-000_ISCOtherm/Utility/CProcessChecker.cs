namespace App.Utility
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Runtime.CompilerServices;
    using System.Runtime.InteropServices;
    using System.Text;
    using System.Threading;
    using System.Windows.Forms;

    /// <summary>
    /// Class used to check current process.
    /// </summary>
    public static class CProcessChecker
    {
        #region Member enummerations

        public enum enResult
        {
            eNoProcess,
            eProcessButNoWindow,
            eWindowActivated
        }

        #endregion

        #region Member variables

        private static bool m_bFoundWindow = false;
        private static string m_sRequiredString = String.Empty;

        #endregion

        #region Systemcode

        #region Constructor

        #endregion

        #endregion

        #region Properties

        #endregion

        #region User interface
            
        public delegate bool EnumWindowsProcCallBack(IntPtr hWnd, int lParam);

        #endregion

        #region Public methods

        /// <summary>
        /// Get the process by its name.
        /// </summary>
        /// <param name="processTitle">The process name.</param>
        public static bool GetProcess(string sProcessTitle)
        {
            m_sRequiredString = sProcessTitle;
            for (int i = 0; i < 10; i++)
            {
                switch (GetProcessInternal(sProcessTitle))
                {
                    case enResult.eNoProcess:
                        if (i >= 5)
                        {
                            //Util.DebugLog("took a long time to close.", i + " seconds");
                        }
                        return true;

                    case enResult.eProcessButNoWindow:
                        return false;
                }

                #if !DEBUG
                    Thread.Sleep(TimeSpan.FromSeconds(1.0));
                #else
                    Thread.Sleep(TimeSpan.FromSeconds(5.0));
                #endif
            }

            return false;
        }

        /// <summary>
        /// Get the process by its name.
        /// </summary>
        /// <param name="processTitle">The process name.</param>
        /// <param name="windowsTitle">The windows name of the process.</param>
        public static bool GetProcess(string sProcessTitle, string sWindowsTitle)
        {
            m_sRequiredString = sWindowsTitle;

            for (int i = 0; i < 10; i++)
            {
                switch (GetProcessInternal(sProcessTitle))
                {
                    case enResult.eNoProcess:
                        if (i >= 5)
                        {
                            //Util.DebugLog("took a long time to close.", i + " seconds");
                        }
                        return true;

                    case enResult.eWindowActivated:
                        return false;
                }

                #if !DEBUG
                    Thread.Sleep(TimeSpan.FromSeconds(1.0));
                #else
                    Thread.Sleep(TimeSpan.FromSeconds(5.0));
                #endif
            }

            string sError = sProcessTitle + " is already running on your computer but doesn't have any open windows. It may be in the process of closing.\n\nTry launching " + sProcessTitle + " again in a few seconds, use Task Manager to end " + sProcessTitle + ", or restart your computer.";
            //MessageBox.Show(sError, "Starting Process", MessageBoxButtons.OK, MessageBoxIcon.Error);

            return false;

        }
        #endregion

        #region Private methods

        /// <summary>
        /// Provides access to local and remote processes.
        /// </summary>
        /// <param name="processTitle">The process name.</param>
        private static enResult GetProcessInternal(string sProcessTitle)
        {
            m_bFoundWindow = false;
            Process[] process = Process.GetProcessesByName(sProcessTitle);
            bool bAnyProcsMatch = false;
            foreach (var proc in process)
            {
                if (proc.Id != Process.GetCurrentProcess().Id)
                {
                    bAnyProcsMatch = true;
                    NativeMethods.EnumWindows((hWnd, lParam) =>
                    {
                        return EnumWindowsProc(hWnd, lParam);
                    }, proc.Id);

                    if (m_bFoundWindow)
                    {
                        break;
                    }
                }
            }

            if (!bAnyProcsMatch)
            {
                return enResult.eNoProcess;
            }

            if (m_bFoundWindow)
            {
                return enResult.eWindowActivated;
            }

            return enResult.eProcessButNoWindow;
        }

        /// <summary>
        /// Sets this Window Object's visibility
        /// </summary>
        /// <param name="hWnd">Handle to a top-level window.</param>
        /// <param name="lParam">Specifies the application-defined value given in EnumWindows or EnumDesktopWindows.</param>
        private static bool EnumWindowsProc(IntPtr hWnd, int lParam)
        {
            int processId = 0;

            NativeMethods.GetWindowThreadProcessId(hWnd, ref processId);

            // Check the process ID
            if (processId == lParam)
            {
                // Check the window title lenght
                if (NativeMethods.GetWindowTextLength(hWnd) > 0)
                {
                    StringBuilder stringBuilder = new StringBuilder(NativeMethods.GetWindowTextLength(hWnd));
                    NativeMethods.GetWindowText(hWnd, stringBuilder, stringBuilder.Capacity + 1);

                    // Check the window title
                    if (stringBuilder.ToString().IndexOf(m_sRequiredString, StringComparison.OrdinalIgnoreCase) != -1)
                    {
                        // Show the window
                        NativeMethods.ShowWindowAsync(hWnd, 1);
                        NativeMethods.SetForegroundWindow(hWnd);
                        m_bFoundWindow = true;
                    }
                }
            }
            return true;
        }

        #endregion

        #region Events

        #endregion

        #region Internal class

        /// <summary>
        /// Object used to control a Windows Form.
        /// </summary>
        internal static class NativeMethods
        {
            #region Varibales declaration

            /// <summary>
            /// Win32 API Constants for ShowWindowAsync()
            /// </summary>
            private const int SW_HIDE = 0;
            private const int SW_SHOWNORMAL = 1;
            private const int SW_SHOWMINIMIZED = 2;
            private const int SW_SHOWMAXIMIZED = 3;
            private const int SW_SHOWNOACTIVATE = 4;
            private const int SW_RESTORE = 9;
            private const int SW_SHOWDEFAULT = 10;

            #endregion

            #region Public static functions

            /// <summary>
            /// Win32 API Imports
            /// </summary>
            [DllImport("user32.dll")]
            public static extern bool EnumWindows(CProcessChecker.EnumWindowsProcCallBack lpEnumFunc, int lParam);
            [DllImport("user32.dll")]
            public static extern int GetWindowTextLength(IntPtr hWnd);
            [DllImport("user32.dll")]
            public static extern int GetWindowText(IntPtr hWnd, StringBuilder lpString, int nMaxCount);
            [DllImport("user32.dll")]
            public static extern int GetWindowThreadProcessId(IntPtr hWnd, ref int lpdwProcessId);
            [DllImport("user32.dll")]
            public static extern bool SetForegroundWindow(IntPtr hWnd);
            [DllImport("user32.dll")]
            public static extern bool ShowWindowAsync(IntPtr hWnd, int nCmdShow);

            #endregion

        }

        #endregion

    }
}
