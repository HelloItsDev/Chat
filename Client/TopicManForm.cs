using Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Client
{
    public partial class TopicManForm : Form
    {
        public TopicsManager clientProxy = null;
        public TopicManForm()
        {
            InitializeComponent();
            ChannelFactory<TopicsManager> dupFactory = null;
            dupFactory = new ChannelFactory<TopicsManager>(
                new NetTcpBinding(), new EndpointAddress("net.tcp://localhost:9000/TopicManager"));
            dupFactory.Open();
            clientProxy = dupFactory.CreateChannel();
            List<string> l = new List<string>();
            l = clientProxy.listTopics();
            foreach (var t in l)
            {
                listBox1.Items.Add(t);
            }
            
        }
    }
}
