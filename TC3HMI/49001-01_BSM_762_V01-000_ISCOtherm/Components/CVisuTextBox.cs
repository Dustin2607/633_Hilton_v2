namespace App.Components
{
    using System;
    using System.Runtime.InteropServices;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Drawing;
    using System.Text;
    using System.Windows.Forms;

    public class CVisuTextBox : TextBox
    {
        [DllImport("user32.dll")]
        static extern bool HideCaret(IntPtr hwnd);

        [DllImport("user32.dll")]
        static extern bool ShowCaret(IntPtr hwnd);

        public CVisuTextBox()
        {
            this.ReadOnly = true;
            this.BackColor = Color.White;
            this.Cursor = Cursors.Hand;
            this.TabStop = false;
            this.TextAlign = HorizontalAlignment.Right;
            this.ScrollBars = ScrollBars.None;
            this.BorderStyle = BorderStyle.None;
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
       }

        protected override void OnGotFocus(EventArgs e)
        {
            base.OnGotFocus(e);
            HideCaret(Handle);
        }

        protected override void OnLostFocus(EventArgs e)
        {
            base.OnLostFocus(e);
            ShowCaret(Handle);
        }
    }
}
