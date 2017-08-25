using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;
using System.IO;

namespace ServerClient
{
    class Client
    {
        private Socket client;
        private NetworkStream stream;
        private StreamReader sr;
        private StreamWriter sw;

        public string Name { get; private set; }

        public NetworkStream Stream
        {
            get { return stream; }
        }

        public Client(Socket client, int clientNum)
        {
            Name = "Client" + (clientNum + 1);
            this.client = client;
            stream = new NetworkStream(client);
            sr = new StreamReader(stream);
            sw = new StreamWriter(stream);
        }

        public void WriteLine(string data)
        {
            sw.WriteLine(data);
            sw.Flush();
        }

        public string ReadLine()
        {
            return sr.ReadLine();
        }

        public void Close()
        {
            client.Close();
        }
    }
}
