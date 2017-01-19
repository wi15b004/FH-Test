using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace TextExample.Communication
{
    public class Server
    {
        private Socket serverSocket;
        private List<ClientHandler> clients = new List<ClientHandler>();
        private Action<string> informer;

        public Server(Action<string> informer)
        {
            this.informer = informer;
            serverSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            serverSocket.Bind(new IPEndPoint(IPAddress.Loopback, 10100)); //loopback is localhost
            serverSocket.Listen(5);
            Task.Factory.StartNew(StartAccepting);
        }

        public void StartAccepting()
        {
            while(true)
            {
                clients.Add(new ClientHandler(serverSocket.Accept(), informer));
            }
        }

    }
}
