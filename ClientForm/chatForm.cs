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
    public partial class chatForm : Form
    {
        public Chatroom clientProxy = null;
        private string username;
        public chatForm(int port, string usernme)
        {
            InitializeComponent();
            DuplexChannelFactory<Chatroom> dupFactory = null;
            
            TextChatter _chatter = new TextChatter(this);
            dupFactory = new DuplexChannelFactory<Chatroom>(
                _chatter, new NetTcpBinding(), new EndpointAddress("net.tcp://localhost:" + port + "/Chat"));
            dupFactory.Open();
            clientProxy = dupFactory.CreateChannel();
            username = usernme;
            clientProxy.join(username);
        }

        private void sendButton_Click(object sender, EventArgs e)
        {
            
            clientProxy.send(messageTextBox.Text, username);
            messageTextBox.Text = "";
        }

        private void chatForm_Load(object sender, EventArgs e)
        {
            this.Text = clientProxy.GetTopic();
        }
    }

}
