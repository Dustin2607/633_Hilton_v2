
namespace App.Components
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Windows.Forms;

    using TwinCAT.App.TCLManager;

    public class CLanguageManager : CTCLManager
    {
        public CLanguageManager(Form frm)
            : base(frm, false)
        {

        }

        public CLanguageManager(Form frm, bool test)
            :base(frm, test)
        {
            
        }
    }
}
