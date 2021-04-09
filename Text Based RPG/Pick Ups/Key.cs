using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Text_Based_RPG
{
    class Key : Item
    {
        public Key(int X, int Y)
        {
            pickedUp = false;
            xLoc = X;
            yLoc = Y;
            icon = '&';
        }

        public override void Update(Map map, Player player)
        {
            if (pickedUp == true)
            {
                Console.WriteLine("You found a key, this must unlock where the valuables are hidden!");
                map.openDoors = true;
                icon = ' ';
                xLoc = 0;
                yLoc = 0;
                pickedUp = false;
            }
        }

    }
}
