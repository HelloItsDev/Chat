using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace Interfaces
{
    // REMARQUE : vous pouvez utiliser la commande Renommer du menu Refactoriser pour changer le nom d'interface "IChatroom" à la fois dans le code et le fichier de configuration.
    [ServiceContract(CallbackContract = typeof(Chatter))]
    public interface Chatroom
    {
        [OperationContract]
        void join(string username);
        [OperationContract]
        void send(string msg, string from);
        [OperationContract]
        string GetTopic();
    }
}
