using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;

namespace ServerClient
{
    class ClientHandler
    {
        Client client;
        Game game;
        List<Client> connectedClients;

        public ClientHandler(Socket socket, Game game, List<Client> connectedClients)
        {
            this.connectedClients = connectedClients;
            this.game = game;
            client = new Client(socket, connectedClients.Count);
            connectedClients.Add(client);
        }

        public void Run()
        {
            try
            {
                Console.WriteLine("{0} has connected", client.Name);
                client.WriteLine("Ready!");
                client.WriteLine(client.Name);

                string data = client.ReadLine();
                string[] dataSplit;
                while (data != null)
                {
                    dataSplit = data.Split(' ');
                    Console.WriteLine("{0}: {1}", client.Name, data);
                    int a, b;

                    switch (dataSplit[0].ToLower())
                    {
                        case "ip":
                            client.WriteLine("Server: 127.0.0.1");
                            break;
                        case "time":
                            client.WriteLine("Server: " + DateTime.Now.ToString("hh:mm:ss"));
                            break;
                        case "date":
                            client.WriteLine("Server: " + DateTime.Now.ToString("dd-MM-yyyy"));
                            break;
                        case "add":
                            if (int.TryParse(dataSplit[1], out a) && int.TryParse(dataSplit[2], out b))
                                client.WriteLine("Server: Sum: " + (a + b));
                            else
                                client.WriteLine("Server: Invalid characters.");
                            break;
                        case "sub":
                            if (int.TryParse(dataSplit[1], out a) && int.TryParse(dataSplit[2], out b))
                                client.WriteLine("Server: Difference: " + (a - b));
                            else
                                client.WriteLine("Server: Invalid characters.");
                            break;
                        case "exit":
                            client.WriteLine("Server: Goodbye client!");
                            client.Close();
                            break;
                        case "game":
                            client.WriteLine("Server: Game not working yet!");
                            break;
                        default:
                            client.WriteLine("Server: Unknown command!");
                            break;
                    }

                    data = client.ReadLine();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: " + e.Message);
                client.Close();
            }
        }

        private void PlayGame()
        {
            bool running = true;
            string data;

            while(game.Tries > 0 && running)
            {
                data = client.ReadLine();
            }
        }        
    }
}
