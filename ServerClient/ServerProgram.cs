using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Threading;

namespace ServerClient
{
    class ServerProgram
    {
        int clientsThisSession = 0;
        int port = 11111;
        bool running = true;
        IPAddress ip = IPAddress.Parse("127.0.0.1");
        TcpListener server;
        List<Client> connectedClients = new List<Client>();
        Game game;

        public void Run()
        {
            game = new Game();
            server = new TcpListener(ip, port);
            server.Start();
            WaitForClients();

            Console.WriteLine("Server has stopped..");
            Console.ReadLine();                        
        }

        private void WaitForClients()
        {
            Console.WriteLine("Waiting for clients..");
            ClientHandler clientHandler;
            Socket socket;

            while (running)
            {
                socket = server.AcceptSocket();
                clientHandler = new ClientHandler(socket, game, connectedClients);
                new Thread(() => clientHandler.Run()).Start();
                
                clientsThisSession++;
            }
        }

        private void FlushClients()
        {
            for (int i = connectedClients.Count - 1; i > 0; i--)
            {
                if (!connectedClients[i].Stream.CanWrite)
                    connectedClients.RemoveAt(i);
            }
        }
    }
}
