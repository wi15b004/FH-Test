using System;
using System.Net.Sockets;

namespace FirstServer
{
    internal class ClientHandler
    {
        private Informer inform;
        private Socket socket;

        public ClientHandler(Socket socket, Informer inform)
        {
            this.socket = socket;
            this.inform = inform;
        }

        public Socket ClientSocket { get; internal set; }

        internal void sendMessage(string message)
        {
            throw new NotImplementedException();
        }
    }
}