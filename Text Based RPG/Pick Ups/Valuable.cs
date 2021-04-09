using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Text_Based_RPG
{
    class Valuable : Item
    {
        public Valuable(int X, int Y)
        {
            //valuable properties...
            pickedUp = false;
            xLoc = X;
            yLoc = Y;
            icon = '$';
        }
        public override void Update(Map map, Player player)
        {
            if (pickedUp == true)
            {
                player.CollectValuable(100);
                icon = ' ';
                xLoc = 0;
                yLoc = 0;
                pickedUp = false;
            }
        }
    }
}
