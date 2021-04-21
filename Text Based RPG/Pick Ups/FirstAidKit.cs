using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Text_Based_RPG
{
    class FirstAidKit :Item
    {
        //adds health on pickup
        public FirstAidKit(int X, int Y)
        {
            pickedUp = false;
            xLoc = X;
            yLoc = Y;
            itemTile.tileCharacter = '+';
        }
        public override void Update(Map map, Player player, Inventory inventory)
        {
            if (pickedUp == true)
            {
                //player.Heal(10);
                inventory.addItemToInventory("First Aid Kit");
                Console.WriteLine("You have found a first aid kit!");
                //icon = ' ';
                xLoc = 0;
                yLoc = 0;
                pickedUp = false;
            }
            if (dropped == true)
            {
                pickedUp = false;
                xLoc = player.xLoc;
                yLoc = player.yLoc;
                dropped = false;
            }
            if (used == true)
            {
                player.Heal(10);
                pickedUp = false;
                used = false;
                itemTile.tileCharacter = ' ';
            }
        }
    }
}
