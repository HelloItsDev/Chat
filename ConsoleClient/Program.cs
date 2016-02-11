using Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleClient
{
    class Program
    {
        static void Main(string[] args)
        {
            ChannelFactory<AuthentificationManager> dupFactory = null;
            AuthentificationManager clientProxy = null;
            TextChatter _chatter = new TextChatter();
            dupFactory = new ChannelFactory<AuthentificationManager>(
                new NetTcpBinding(), new EndpointAddress("net.tcp://localhost:8999/AuthManager"));
            dupFactory.Open();
            clientProxy = dupFactory.CreateChannel();
            int menu = 0;
            string username;
            while(menu == 0)
            {
                Console.WriteLine("Entrez votre username:");
                username = Console.ReadLine();
                Console.WriteLine(" Entrez votre password:");
                var password = Console.ReadLine();
                Console.WriteLine("1.Se connecter \n 2.s'inscrire");
                switch (Console.ReadLine())
                {

                    case "1":
                        
                        if (clientProxy.login(username, password))
                        {
                            joinTopicsManager(username);
                        }
                        
                        break;
                    case "2":
                        clientProxy.addUser(username, password);
                        break;

                }
            }


        }
        private static void joinTopicsManager(string username)
        {
            ChannelFactory<TopicsManager> dupFactory = null;
            TopicsManager clientProxy = null;
            dupFactory = new ChannelFactory<TopicsManager>(
                new NetTcpBinding(), new EndpointAddress("net.tcp://localhost:9000/TopicManager"));
            dupFactory.Open();
            clientProxy = dupFactory.CreateChannel();
            while (true)
            {
                Console.WriteLine("************TOPICS MANAGER************");
                Console.WriteLine("Liste des rooms diponibles : ");
                List<string> list = clientProxy.listTopics();
                foreach (var t in list)
                {
                    Console.WriteLine(t);
                }
                Console.WriteLine("1. Se connecter a une room \n2.Créer un nouveau chatroom");

                switch (Console.ReadLine())
                {
                    case "1":
                        Console.WriteLine("Entrez le nom de la room");
                        joinChatroom(clientProxy.joinTopic(Console.ReadLine()), username);

                        break;
                    case "2":
                        Console.WriteLine("Entrez le nom de la room");
                        clientProxy.createTopic(Console.ReadLine());
                        break;

                }
            }
        }

        private static void joinChatroom(int port, string username)
        {
            DuplexChannelFactory<Chatroom> dupFactory = null;
            Chatroom clientProxy = null;
            TextChatter _chatter = new TextChatter();
            dupFactory = new DuplexChannelFactory<Chatroom>(
                _chatter, new NetTcpBinding(), new EndpointAddress("net.tcp://localhost:"+ port +"/Chat"));
            dupFactory.Open();
            clientProxy = dupFactory.CreateChannel();
       
            Console.WriteLine("Bienvenue dans la room {0}",username);
            clientProxy.join(username);
            string input = null;
            while (input != "exit")
            {
                input = Console.ReadLine();
                clientProxy.send(input, username);
                Console.SetCursorPosition(0, Console.CursorTop - 2);
                ClearCurrentConsoleLine();
                Console.SetCursorPosition(0, Console.CursorTop + 2);
            }

            dupFactory.Close();
        }

        private static void ClearCurrentConsoleLine()
        {
            int currentLineCursor = Console.CursorTop;
            Console.SetCursorPosition(0, Console.CursorTop);
            Console.Write(new string(' ', Console.WindowWidth));
            Console.SetCursorPosition(0, currentLineCursor);
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
