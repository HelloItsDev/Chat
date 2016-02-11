using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces
{
    [ServiceContract]
    public interface TopicsManager
    {
        [OperationContract]
        List<string> listTopics();

        [OperationContract]
        void createTopic(string topicName);
        [OperationContract]
        int joinTopic(string topicName);
    }
}
