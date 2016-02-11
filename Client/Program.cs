using Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client
{
    class Program
    {
        static void Main(string[] args)
        {
            var auth = new AuthForm();
            auth.Show();
            Console.ReadLine();
        }
    }

    public class TextChatter : Chatter
    {
        #region Chatter Members

        public void receiveAMessage(string msg, string from)
        {
            Console.WriteLine(" {0}:   {1} ", from, msg);
        }

        #endregion
    }
}
