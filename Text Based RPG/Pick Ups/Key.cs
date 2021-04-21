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
            //key properties
            pickedUp = false;
            xLoc = X;
            yLoc = Y;
            itemTile.tileCharacter = '&';
        }

        public override void Update(Map map, Player player, Inventory inventory)
        {
            //if they are picked up doors open and pickup turns invisible and goes off screen.....
            if (pickedUp == true)
            {
                //lets you know
                Console.WriteLine("You found a key, this must unlock where the valuables are hidden!");
                map.openDoors = true;
                itemTile.tileCharacter = ' ';
                xLoc = 0;
                yLoc = 0;
                //stops console.writeline from repeating
                pickedUp = false;
            }
        }

    }
}
