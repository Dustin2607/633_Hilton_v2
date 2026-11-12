namespace App
{
    using System;
    using System.Threading;
    using System.Globalization;
    using System.ComponentModel;
    using System.Collections.Generic;
    using System.Threading;
    using System.Windows.Forms;

    using App.Utility;

    static class CMainApp
    {
        public static FMainApp frmMainApp;

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // Set decimal separator
            CultureInfo customCulture = (CultureInfo)Thread.CurrentThread.CurrentCulture.Clone();
            customCulture.NumberFormat.NumberDecimalSeparator = ".";
            Thread.CurrentThread.CurrentCulture = customCulture;

            //Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;

            frmMainApp = new FMainApp();

            // Check if process instance created.
            if (CProcessChecker.GetProcess(Application.ProductName))
            {
                // Create a new instance of an frmMain control and run application.
                Application.Run(frmMainApp);
            }


        }

        /// <summary>
        /// Returns the static object of the main form.
        /// </summary>
        [Description("Returns the static object of the main form."), Category("Application")]
        public static FMainApp GetMainAppForm()
        {
            if (frmMainApp != null)
                return frmMainApp;
            return null;
        }
    }
}
