using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Text_Based_RPG
{
    class SpecializedCombat : Enemy
    {
        public SpecializedCombat(int X, int Y)
        {
            xLoc = X;
            yLoc = Y;
            character = '3';
            health = 50;
        }
    }
}
