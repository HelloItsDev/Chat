﻿using Interfaces;
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
    public partial class AuthForm : Form
    {
         public AuthentificationManager clientProxy = null;
        public AuthForm()
        {
            InitializeComponent();
            ChannelFactory<AuthentificationManager> dupFactory = null;
            dupFactory = new ChannelFactory<AuthentificationManager>(
                new NetTcpBinding(), new EndpointAddress("net.tcp://localhost:8999/AuthManager"));
            dupFactory.Open();
            clientProxy = dupFactory.CreateChannel();
        }

        private void button1_Click(object sender, EventArgs e)
        {
           if (usernameTextBox.Text != "" && PasswordTextBox.Text != "")
            {
               
                if (clientProxy.login(usernameTextBox.Text, PasswordTextBox.Text))
                {
                    var topicman = new TopicManForm(usernameTextBox.Text);
                    topicman.Show();
                }
                else
                {
                    MessageBox.Show("Compte innexistant");
                }
                
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            clientProxy.addUser(usernameTextBox.Text, PasswordTextBox.Text);
        }
    }
}
