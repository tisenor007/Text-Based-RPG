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
            itemType = ItemType.Shield;
            name = "Shield";
            Random rand = new Random();
            SetPrice(rand.Next(1, 10));
        }
        public override void Update(Map map, Player player, Inventory inventory, Camera camera, ItemManager itemManager)
        {
            if (isShopItem == true)
                itemTile.tileColour = ConsoleColor.Yellow;

            if (pickedUp == true)
            {
                //player.RegenShield(100);
                inventory.addItemToInventory(this);
                infoMessage ="You have found a " + name +"!";
                base.Update(map, player, inventory, camera, itemManager);
                //icon = ' ';
                xLoc = 0;
                yLoc = 0;
                dropped = false;
                pickedUp = false;
            }
            if (dropped == true)
            {
                
                xLoc = player.xLoc;
                yLoc = player.yLoc;
                pickedUp = false;
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
