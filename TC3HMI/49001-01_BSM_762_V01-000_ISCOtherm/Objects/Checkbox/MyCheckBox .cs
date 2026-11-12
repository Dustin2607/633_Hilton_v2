using System;
using System.Drawing;
using System.Windows.Forms;

namespace App.Objects.Checkbox
{
    public class MyCheckBox : CheckBox
    {
        public MyCheckBox()
        {
            this.Text = "Approved";
            this.TextAlign = ContentAlignment.MiddleRight;
        }

        public override bool AutoSize
        {
            set { base.AutoSize = false; }
            get { return base.AutoSize; }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            int h = this.ClientSize.Height - 2;
            Rectangle rc = new Rectangle(new Point(0, 1), new Size(h, h));
            ControlPaint.DrawCheckBox(e.Graphics, rc,
                this.Checked ? ButtonState.Checked : ButtonState.Normal);
        }
    }
}
