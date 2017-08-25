using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServerClient
{
    class Game
    {
        int tries;

        public int Tries
        {
            get { return tries; }
        }

        public Game()
        {
            tries = 10;
        }
    }
}
