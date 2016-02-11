using Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClientForm
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new AuthForm());
            Console.ReadLine();
        }
    }
    public class TextChatter : Chatter
    {
        #region Chatter Members
        private chatForm currentChat;

        public TextChatter(chatForm cform)
        {
            currentChat = cform;
        }

        public void receiveAMessage(string msg, string from)
        {
            currentChat.recevoir_message(msg); 
        }

        #endregion
    }
}
