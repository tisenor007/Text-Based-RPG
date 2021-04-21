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
            itemTile.tileCharacter = 'S';
        }
        public override void Update(Map map, Player player, Inventory inventory, Camera camera)
        {
            if (pickedUp == true)
            {
                //player.RegenShield(100);
                inventory.addItemToInventory("Shield");
                infoMessage ="You have found a Sheild!";
                base.Update(map, player, inventory, camera);
                //icon = ' ';
                xLoc = 0;
                yLoc = 0;
                dropped = false;
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
                player.RegenShield(100);
                pickedUp = false;
                used = false;
                itemTile.tileCharacter = ' ';
            }
        }
    }
}
