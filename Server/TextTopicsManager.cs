using Interfaces;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Server
{
    [ServiceBehavior(ConcurrencyMode = ConcurrencyMode.Multiple, InstanceContextMode = InstanceContextMode.Single)]
    public class TextTopicsManager : TopicsManager
    {
        public ConcurrentDictionary<string, TextChatroom> Topics = new ConcurrentDictionary<string, TextChatroom>();

        public TextTopicsManager()
        {
            //création d'une mainroom
            createTopic("MainRoom");
        }
        public void createTopic(string topicName)
        {
            TextChatroom newChatroom = new TextChatroom();
            newChatroom.Topic = topicName;
            newChatroom.port = 9001 + Topics.Count();
            Topics.TryAdd(topicName, newChatroom);
            Thread ChatroomThread = new Thread(
                new ThreadStart(
                delegate ()
                {
                    Console.WriteLine("....Starting a new chatroom.Port {0}.Name {1}.", newChatroom.port, topicName);
                    Uri[] uriArr = { new Uri("net.tcp://localhost:"+ newChatroom.port + "/Chat") };
                    ServiceHost host = new ServiceHost(typeof(TextChatroom), uriArr);
                    host.Open();
                    Console.WriteLine("Host started...");
                    Console.ReadKey();
                }));
            ChatroomThread.Start();

        }

        public int joinTopic(string topicName)
        {
            return Topics[topicName].port;
        }

        public List<string> listTopics()
        {
            List<string> listT = new List<string>();
            foreach (var topic in Topics)
            {
                listT.Add(topic.Key);
            }
            return listT;
        }
    }
}
