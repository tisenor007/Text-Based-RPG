using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Text_Based_RPG
{
    class Shield : Item
    {
        //adds sheild on pickup
        public Shield(int X, int Y)
        {
            pickedUp = false;
            xLoc = X;
            yLoc = Y;
            icon = 'S';
        }
        public override void Update(Map map, Player player)
        {
            if (pickedUp == true)
            {
                player.RegenShield(100);
                Console.WriteLine("You have found a Sheild!");
                icon = ' ';
                xLoc = 0;
                yLoc = 0;
                pickedUp = false;
            }
        }
    }
}
