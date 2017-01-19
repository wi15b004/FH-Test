using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace ClientChat
{
    class Handler
    {
        TcpClient client = new TcpClient();
        Socket socket;

        public Handler()
        {
            client.Connect(new IPEndPoint(IPAddress.Loopback, 10100));
            socket = client.Client;
        }

        public void sendMessage(string message)
        {
            socket.Send(Encoding.UTF8.GetBytes(message));
        }
    }
}
