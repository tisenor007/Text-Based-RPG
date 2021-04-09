using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Text_Based_RPG
{
    class FirstAidKit :Item
    {
        public FirstAidKit(int X, int Y)
        {
            pickedUp = false;
            xLoc = X;
            yLoc = Y;
            icon = '+';
        }
        public override void Update(Map map, Player player)
        {
            if (pickedUp == true)
            {
                player.Heal(10);
                Console.WriteLine("You have found a first aid kit!");
                icon = ' ';
                xLoc = 0;
                yLoc = 0;
                pickedUp = false;
            }
        }
    }
}
