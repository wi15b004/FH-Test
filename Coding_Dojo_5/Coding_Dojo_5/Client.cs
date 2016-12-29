using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Coding_Dojo_5
{
    class Client
    {
        byte[] buffer = new byte[512];
        Socket clientsocket;
        Action<string> MessageInformer;
        Action AbortInformer;

        public Client(String ip, int port, Action<string> messageInformer, Action abortInformer)
        {
            try
            {
                this.AbortInformer = abortInformer;
                this.MessageInformer = messageInformer;
                TcpClient client = new TcpClient();
                client.Connect(IPAddress.Parse(ip), port);
                clientsocket = client.Client;
                StartReceiving();
            }
            catch (Exception)
            {
                messageInformer("Server error");
                AbortInformer();
            }
        }

        private void StartReceiving()
        {
            Task.Factory.StartNew(Receive);
        }

        private void Receive()
        {
            string message = "";
            while (!message.Equals("@quit"))
            {
                int length = clientsocket.Receive(buffer);
                message = Encoding.UTF8.GetString(buffer, 0, length);
                MessageInformer(message);
            }
            Close();
        }

        public void Send(string message)
        {
            if(clientsocket!=null)
            {
                clientsocket.Send(Encoding.UTF8.GetBytes(message));
            }
        }

        private void Close()
        {
            clientsocket.Close();
            AbortInformer();
        }
    }
}
