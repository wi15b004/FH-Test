using System;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace TextExample.Communication
{
    internal class ClientHandler
    {
        private Socket socket;
        private byte[] buffer = new byte[512];
        Action<string> guiInformer;

        public ClientHandler(Socket socket, Action<string> guiInformer)
        {
            this.socket = socket;
            this.guiInformer = guiInformer;
            Task.Factory.StartNew(Receive);
        }

        private void Receive()
        {
            while(true)
            {
                int length;
                length = socket.Receive(buffer);
                guiInformer(Encoding.UTF8.GetString(buffer, 0, length));
            }
           
        }
    }
}