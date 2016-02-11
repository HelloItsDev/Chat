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

namespace ClientForm
{
    public partial class TopicManForm : Form
    {
        public TopicsManager clientProxy = null;
        private string username;
        public TopicManForm(string usernm)
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
            username = usernm;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var chatroom = new chatForm(clientProxy.joinTopic((string)listBox1.SelectedItem), username);
            chatroom.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            clientProxy.createTopic(CreatTextBox.Text);
            listBox1.Items.Clear();
            List<string> l = new List<string>();
            l = clientProxy.listTopics();
            foreach (var t in l)
            {
                listBox1.Items.Add(t);
            }
        }
    }
}
