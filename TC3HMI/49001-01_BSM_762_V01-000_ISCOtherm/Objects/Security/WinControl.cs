namespace App.Security
{
    using Microsoft.Win32;
    using System;
    using System.Diagnostics;
    using System.Runtime.InteropServices;

    public class WinControl
    {
        public const byte disableChangePasswd = 4;
        public const byte disableLockWrkStation = 2;
        public const byte disableLogoff = 8;
        public const byte disableShutdwown = 0x10;
        public const byte disableTaskMgr = 1;
        internal const int EWX_FORCE = 4;
        internal const int EWX_FORCEIFHUNG = 0x10;
        internal const int EWX_LOGOFF = 0;
        internal const int EWX_POWEROFF = 8;
        internal const int EWX_REBOOT = 2;
        internal const int EWX_SHUTDOWN = 1;
        internal const int SE_PRIVILEGE_ENABLED = 2;
        internal const string SE_SHUTDOWN_NAME = "SeShutdownPrivilege";
        internal const int TOKEN_ADJUST_PRIVILEGES = 0x20;
        internal const int TOKEN_QUERY = 8;
        public const int WM_CtrlAltDel = 0x401;
        public const int WM_SecurityDialog = 0x402;
        public const int WM_SysKeys = 0x409;
        public const int WM_TaskBar = 0x408;
        public const int WM_USER = 0x400;
        public const int WM_WinKeys = 0x403;

        [DllImport("advapi32.dll", SetLastError=true, ExactSpelling=true)]
        internal static extern bool AdjustTokenPrivileges(IntPtr htok, bool disall, ref TokPriv1Luid newst, int len, IntPtr prev, IntPtr relen);
        public static bool DisableAllWindowsSyskeys()
        {
            int hWnd = FindWindow(null, "TcWinLock");
            if (hWnd == 0)
            {
                return false;
            }
            SendMessage(hWnd, 0x409, 1, 0);
            return true;
        }

        public static bool DisableCtrlAltDel()
        {
            int hWnd = FindWindow(null, "TcWinLock");
            if (hWnd == 0)
            {
                return false;
            }
            SendMessage(hWnd, 0x401, 1, 0);
            return true;
        }

        public static bool DisableTaskBar()
        {
            int hWnd = FindWindow(null, "TcWinLock");
            if (hWnd == 0)
            {
                return false;
            }
            SendMessage(hWnd, 0x408, 1, 0);
            return true;
        }

        public static bool DisableWindowsKeys()
        {
            int hWnd = FindWindow(null, "TcWinLock");
            if (hWnd == 0)
            {
                return false;
            }
            SendMessage(hWnd, 0x403, 1, 0);
            return true;
        }

        public static bool EnableAllWindowsSyskeys()
        {
            int hWnd = FindWindow(null, "TcWinLock");
            if (hWnd == 0)
            {
                return false;
            }
            SendMessage(hWnd, 0x409, 0, 0);
            return true;
        }

        public static bool EnableCtrlAltDel()
        {
            int hWnd = FindWindow(null, "TcWinLock");
            if (hWnd == 0)
            {
                return false;
            }
            SendMessage(hWnd, 0x401, 0, 0);
            return true;
        }

        public static bool EnableTaskBar()
        {
            int hWnd = FindWindow(null, "TcWinLock");
            if (hWnd == 0)
            {
                return false;
            }
            SendMessage(hWnd, 0x408, 0, 0);
            return true;
        }

        public static bool EnableWindowsKeys()
        {
            int hWnd = FindWindow(null, "TcWinLock");
            if (hWnd == 0)
            {
                return false;
            }
            SendMessage(hWnd, 0x403, 0, 0);
            return true;
        }

        [DllImport("user32.dll", SetLastError=true, ExactSpelling=true)]
        internal static extern bool ExitWindowsEx(int flg, int rea);
        [DllImport("user32.dll")]
        public static extern int FindWindow(string lpClassName, string lpWindowName);
        [DllImport("kernel32.dll", ExactSpelling=true)]
        internal static extern IntPtr GetCurrentProcess();
        public static void LockTaskManager()
        {
            RegistryKey key = Registry.CurrentUser.OpenSubKey(@"Software\Microsoft\WINDOWS\CURRENTVERSION\POLICIES").OpenSubKey("SYSTEM", true);
            key.SetValue("DisableTaskMgr", 1);
            key.Close();
        }

        [DllImport("advapi32.dll", SetLastError=true)]
        internal static extern bool LookupPrivilegeValue(string host, string name, ref long pluid);
        [DllImport("advapi32.dll", SetLastError=true, ExactSpelling=true)]
        internal static extern bool OpenProcessToken(IntPtr h, int acc, ref IntPtr phtok);
        public static void ProcessInfo()
        {
            ProcessStartInfo startInfo = new ProcessStartInfo("notepad.exe");
            startInfo.WindowStyle = ProcessWindowStyle.Maximized;
            Process.Start(startInfo);
        }

        public static void Reboot()
        {
            XPRebootCommand(6);
        }

        public static bool SecurityDialogConfig(int mask)
        {
            int hWnd = FindWindow(null, "TcWinLock");
            if (hWnd == 0)
            {
                return false;
            }
            SendMessage(hWnd, 0x402, mask, 0);
            return true;
        }

        [DllImport("user32.dll")]
        public static extern int SendMessage(int hWnd, int Msg, int wParam, int lParam);
        public static void ShutDown()
        {
            XPRebootCommand(5);
        }

        public static void UnLockTaskManager()
        {
            RegistryKey key = Registry.CurrentUser.OpenSubKey(@"Software\Microsoft\WINDOWS\CURRENTVERSION\POLICIES").OpenSubKey("SYSTEM", true);
            key.SetValue("DisableTaskMgr", 0);
            key.Close();
        }

        private static void XPRebootCommand(int flg)
        {
            TokPriv1Luid luid;
            IntPtr currentProcess = GetCurrentProcess();
            IntPtr zero = IntPtr.Zero;
            OpenProcessToken(currentProcess, 40, ref zero);
            luid.Count = 1;
            luid.Luid = 0L;
            luid.Attr = 2;
            LookupPrivilegeValue(null, "SeShutdownPrivilege", ref luid.Luid);
            AdjustTokenPrivileges(zero, false, ref luid, 0, IntPtr.Zero, IntPtr.Zero);
            ExitWindowsEx(flg, 0);
        }

        [StructLayout(LayoutKind.Sequential, Pack=1)]
        internal struct TokPriv1Luid
        {
            public int Count;
            public long Luid;
            public int Attr;
        }
    }
}

