using System;
using Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Collections.Concurrent;

namespace Server
{
    // REMARQUE : vous pouvez utiliser la commande Renommer du menu Refactoriser pour changer le nom de classe "Chatroom" à la fois dans le code et le fichier de configuration.
    [ServiceBehavior(ConcurrencyMode = ConcurrencyMode.Multiple, InstanceContextMode = InstanceContextMode.Single)]
    public class TextChatroom : Chatroom
    {
        public ConcurrentDictionary<string, ConnectedChatter> Chatters = new ConcurrentDictionary<string, ConnectedChatter>();
        public string Topic { set; get; }
        public int port { set; get; }

        public void join(string username)
        {
            var establishedChatterConnection = OperationContext.Current.GetCallbackChannel<Chatter>();
            ConnectedChatter newChatter = new ConnectedChatter();
            newChatter.connection = establishedChatterConnection;
            newChatter.username = username;
            Chatters.TryAdd(username, newChatter);
           
        }

        public void send(string msg, string from)
        {
            foreach (var chatter in Chatters)
            {
                  chatter.Value.connection.receiveAMessage(msg, from);  
            }
        }

        public string GetTopic()
        {
            return Topic;
        }
    }
}
