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
            itemType = ItemType.FirstAidKit;
            name = "First Aid Kit";
            Random rand = new Random();
            SetPrice(rand.Next(1, 10));
        }
        public override void Update(Map map, Player player, Inventory inventory, Camera camera, ItemManager itemManager)
        {
            if (isShopItem == true)
                itemTile.tileColour = ConsoleColor.Yellow;

            if (pickedUp == true)
            {
                //player.Heal(10);
                inventory.addItemToInventory(this);
                infoMessage = "You have found a " + name +"!";
                base.Update(map, player, inventory, camera, itemManager);
                itemTile.tileCharacter = '+';
                xLoc = 0;
                yLoc = 0;
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
                player.Heal(10);
                pickedUp = false;
                used = false;
                itemTile.tileCharacter = ' ';
            }
        }
    }
}
