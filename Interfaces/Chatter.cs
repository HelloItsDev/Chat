using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces
{
    public interface Chatter
    {
        [OperationContract]
        void receiveAMessage(string msg, string from);

    }
}
