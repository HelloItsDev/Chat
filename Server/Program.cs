using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace Server
{
    class Program
    {
        
        static void Main(string[] args)
        {
            Console.WriteLine("....Starting AuthManager...");
            Uri[] _uriArr = { new Uri("net.tcp://localhost:8999/AuthManager") };
            ServiceHost _host = new ServiceHost(typeof(TextAuthentificationManager), _uriArr);
            _host.Open();
            Console.WriteLine("AuthManager server started...");

            Console.WriteLine("....Starting TopicManager...");
            Uri[] uriArr = { new Uri("net.tcp://localhost:9000/TopicManager") };
            ServiceHost host = new ServiceHost(typeof(TextTopicsManager), uriArr);
            host.Open();
            Console.WriteLine("TopicManager server started...");
            Console.ReadKey();

        }
    }
}
