﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServerClient
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "Server";
            ServerProgram p = new ServerProgram();
            p.Run();
        }
    }
}
