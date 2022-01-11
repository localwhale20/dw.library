using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using danilWhale.Library.Classes;

namespace danilWhale.Library.Forms.WhaleBreath
{
    public partial class WhaleBreathForm : Form
    {
        public WhaleBreathForm()
        {
            InitializeComponent();
            this.DoubleBuffered = true;
            this.SetStyle(ControlStyles.ResizeRedraw, true);
        }

        private const int cGrip = 16;      // Grip size
        private const int cCaption = 32;   // Caption bar height;

        protected override void OnPaint(PaintEventArgs e)
        {
            Rectangle rc = new Rectangle(this.ClientSize.Width - cGrip, this.ClientSize.Height - cGrip, cGrip, cGrip);
            ControlPaint.DrawSizeGrip(e.Graphics, this.BackColor, rc);
            rc = new Rectangle(0, 0, this.ClientSize.Width, cCaption);
            e.Graphics.FillRectangle(Brushes.DarkBlue, rc);
        }

        protected override void WndProc(ref System.Windows.Forms.Message m)
        {
            if (m.Msg == 0x84)
            {  // Trap WM_NCHITTEST
                Point pos = new Point(m.LParam.ToInt32() & 0xffff, m.LParam.ToInt32() >> 16);
                pos = this.PointToClient(pos);
                if (pos.Y < cCaption)
                {
                    m.Result = (IntPtr)2;  // HTCAPTION
                    return;
                }
                if (pos.X >= this.ClientSize.Width - cGrip && pos.Y >= this.ClientSize.Height - cGrip)
                {
                    m.Result = (IntPtr)17; // HTBOTTOMRIGHT
                    return;
                }
            }
            base.WndProc(ref m);
        }
        private void closeButton_Click(object sender, EventArgs e)
        {
            FormControl.Close();
        }

        private void minimizeButton_Click(object sender, EventArgs e)
        {
            FormControl.Minimize(this);
        }

        private void titleBar_MouseDown(object sender, MouseEventArgs e)
        {
            base.Capture = false;
            titleBar.Capture = false;
            System.Windows.Forms.Message m = System.Windows.Forms.Message.Create(base.Handle, 161, new IntPtr(2), IntPtr.Zero);
            base.WndProc(ref m);
        }
    }
}
