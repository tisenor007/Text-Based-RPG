using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Text_Based_RPG
{
    class Heavy : Enemy
    {
        public Heavy(int X, int Y)
        {
            xLoc = X;
            yLoc = Y;
            character = 'E';
            health = 100;
        }
    }
}
