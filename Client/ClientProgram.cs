using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Net;
using System.Net.Sockets;

namespace Client
{
    class ClientProgram
    {
        int port = 11111;
        IPAddress ip = IPAddress.Parse("127.0.0.1");
        string input;
        TcpClient client;

        public void Run()
        {
            Console.WriteLine("Press enter to connect");
            Console.ReadLine();

            try
            {
                client = new TcpClient();
                client.Connect(ip, port);
                NetworkStream stream = client.GetStream();
                StreamReader sr = new StreamReader(stream);
                StreamWriter sw = new StreamWriter(stream);

                string data = sr.ReadLine();
                Console.WriteLine(data);
                data = sr.ReadLine();
                Console.Title = data;

                while (true)
                {
                    input = Console.ReadLine();
                    sw.WriteLine(input);
                    sw.Flush();

                    data = sr.ReadLine();
                    Console.WriteLine(data);
                }
            }
            catch (Exception e)
            {
                client.Close();
                Console.WriteLine("Error: " + e.Message);
                Console.WriteLine("The client has ended.");
                Console.ReadLine();
            }
        }
    }
}
