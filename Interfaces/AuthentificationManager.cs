using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces
{
    [ServiceContract]
    public interface AuthentificationManager
    {
        [OperationContract]
        void addUser(string login, string password);
        [OperationContract]
        bool login(string login, string password);
    }
}
