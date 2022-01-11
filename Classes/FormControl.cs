using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace danilWhale.Library.Classes
{
    public static class FormControl
    {
        /// <summary>
        /// Method that closes application
        /// </summary>
        public static void Close()
        {
            Application.Exit();
        }
        /// <summary>
        /// Method that maximizes form on your screen
        /// </summary>
        /// <param name="form">Targeted form to maximize</param>
        public static void Maximize(Form form)
        {
            if (form.WindowState == FormWindowState.Maximized)
            {
                form.WindowState = FormWindowState.Normal;
            }
            else if (form.WindowState == FormWindowState.Normal)
            {
                form.WindowState = FormWindowState.Maximized;
            }
        }
        /// <summary>
        /// Method thaat minimizes form
        /// </summary>
        /// <param name="form">Targeted form</param>
        public static void Minimize(Form form)
        {
            form.WindowState = FormWindowState.Minimized;
        }
    }
}
