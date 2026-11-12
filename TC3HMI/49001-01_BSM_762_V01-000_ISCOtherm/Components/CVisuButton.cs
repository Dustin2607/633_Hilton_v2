namespace App.Components
{
    using System;
    using System.Runtime.InteropServices;
    using System.Collections.Generic;
    using System.Drawing;
    using System.Text;
    using System.ComponentModel;
    using System.Windows.Forms;

    public class CVisuButton : Button
    {

        #region Touch Windows Driver

        //// Import the necessary Win32 functions
        //[System.Runtime.InteropServices.DllImport("kernel32")]
        //static extern int GlobalAddAtom(string atom);

        //[System.Runtime.InteropServices.DllImport("user32")]
        //static extern bool SetProp(IntPtr hwnd, string atom, long handle);

        //[System.Runtime.InteropServices.DllImport("user32")]
        //static extern bool RemoveProp(IntPtr hwnd, string atom);

        //[DllImport("user32.DLL")]
        //public static extern bool RegisterTouchWindow(IntPtr hwnd, int ulFlags);

        //[DllImport("user32.DLL")]
        //public static extern bool UnregisterTouchWindow(IntPtr hwnd);

        #endregion

        public CVisuButton()
        {
            this.Cursor = Cursors.Hand;

            #region Touch Windows Driver
            //// disable PressAndHold
            //TogglePressAndHold(this.Handle, false);

            //// register the button as touch
            //RegisterTouchWindow(this.Handle, 0);
            #endregion
        }

        #region Touch Windows Driver
        //// Toggle the press and hold system gesture for the given window.
        //public bool TogglePressAndHold(IntPtr hwnd, bool enable)
        //{
        //    // The atom identifier and Tablet PC atom
        //    int atomID;
        //    string tabletAtom;
        //    tabletAtom = "MicrosoftTabletPenServiceProperty";

        //    // Get the Tablet PC atom ID
        //    atomID = GlobalAddAtom(tabletAtom);

        //    // If getting the ID failed, return false
        //    if (atomID == 0)
        //    {
        //        return false;
        //    }

        //    // Enable or disable the press and hold gesture
        //    if (enable)
        //        // Try to enable press and hold gesture by
        //        // clearing the window property, return the result
        //        return RemoveProp(hwnd, tabletAtom);
        //    else
        //        // Try to disable press and hold gesture by
        //        // setting the window property, return the result
        //        return SetProp(hwnd, tabletAtom, 1);
        //}

        ////private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        ////{
        ////    UnregisterTouchWindow(button1.Handle);
        ////}
        #endregion

    }

}
