namespace App.Components
{
    using System;
    using System.Runtime.InteropServices;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Drawing;
    using System.Text;
    using System.Windows.Forms;

    public class CVisuListView : ListBox
    {
        public CVisuListView()
        {
            this.Cursor = Cursors.Hand;
        }
    }
}
