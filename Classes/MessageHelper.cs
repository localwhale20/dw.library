using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Threading.Tasks;
using danilWhale.Library.Forms.WhaleBreath;

namespace danilWhale.Library.Classes
{
    public static class MessageController
    {
        /// <summary>
        /// Enumeration with icons type
        /// </summary>
        public enum MessageIcon
        {
            Information = 0,
            Warning = 1,
            Error = 2,
            Question = 3
        }
        /// <summary>
        /// Method that shows a message box with specified parameters
        /// </summary>
        /// <param name="title">Message title</param>
        /// <param name="text">Message content</param>
        /// <param name="msgIcon">Message displaying icon (only specified for this moment in MessageIcon enum)</param>
        public static void Show(string title, string text, MessageIcon msgIcon = 0)
        {
            using (MessageForm mes = new MessageForm())
            {
                mes.title.Text = title;
                mes.text.Text = text;
                switch (msgIcon)
                {
                    case MessageIcon.Information:
                        mes.Icon = SystemIcons.Information;
                        break;
                    case MessageIcon.Warning:
                        mes.Icon = SystemIcons.Warning;
                        break;
                    case MessageIcon.Error:
                        mes.Icon = SystemIcons.Error;
                        break;
                    case MessageIcon.Question:
                        mes.Icon = SystemIcons.Question;
                        break;
                }
                mes.icon.Image = mes.Icon.ToBitmap();

                mes.ShowDialog();
            }
        }
        
    }
}
