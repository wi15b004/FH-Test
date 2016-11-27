using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace FirstServer
{
    class Program
    {
        static void Main(string[] args)
        {

            // Server socket erstellen und Client Socket erstellen / Socket für client erstellen

            //Socket serverSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp); 
            //serverSocket.Bind(new IPEndPoint(IPAddress.Loopback, 9080));
            //serverSocket.Listen(5);
            //Console.WriteLine("Ready to accept clients..");



            //ThreadPool.QueueUserWorkItem(new WaitCallback(StartAccepting), serverSocket);
            //while (true)
            //{
            //    Console.WriteLine("Do something");
            //    Thread.Sleep(2000);
            //}
            //string message = "Hallo Client!";
            ////Encoding.UTF8.GetBytes(message);
            //clientSocket.Send(Encoding.UTF8.GetBytes(message)); //Sendet nur einzelne Bytes

            //byte[] buffer = new byte[512];
            //int length;

            //while (true)
            //{
            //   length = clientSocket.Receive(buffer); // buffer referenz wird übergeben
            //   Console.Write(Encoding.UTF8.GetString(buffer,0, length)); // bei 0 zum umwandeln bekommen, so lange bis length 


            //}

            Server server = new Server("127.0.0.1", 9080);

            while (true)
            {
                Console.WriteLine("Do Something");
                Thread.Sleep(2000);
            }

        }

        private static void StartAccepting(object state)
        {
            List<Socket> clients = new List<Socket>();

            Socket serverSocket = (Socket)state; // Übergebene Objekt wird zu Socket
            while (true)
            {
                clients.Add(serverSocket.Accept());
                Socket clientSocket = serverSocket.Accept();
                Console.WriteLine("Client accepte");
            }
        }
    }
}
