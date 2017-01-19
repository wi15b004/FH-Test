using System.Net.Sockets;

namespace TextExample.Communication
{
    internal class ClientHandler
    {
        private Socket socket;
        private byte[] buffer = new byte[512];


        public ClientHandler(Socket socket)
        {
            this.socket = socket;
        }
    }
}