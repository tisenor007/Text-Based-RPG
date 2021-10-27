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
            pickingUp = false;
            xLoc = X;
            yLoc = Y;
            itemTile.tileCharacter = Global.shieldAppearance;
            itemTile.tileColour = Global.shieldColour;
            itemType = ItemType.Shield;
            name = ItemType.Shield.ToString();
            //Random rand = new Random();
            //SetPrice(rand.Next(1, 10));
        }
        public override void Update(Map map, Player player, Inventory inventory, Camera camera, ItemManager itemManager)
        {
            //if (isShopItem == true)
            //    itemTile.tileColour = ConsoleColor.Yellow;

            if (pickingUp == true)
            {
                //player.RegenShield(100);
                inventory.addItemToInventory(this);
                infoMessage ="You have found a " + name +"!";
                base.Update(map, player, inventory, camera, itemManager);
                //icon = ' ';
                xLoc = 0;
                yLoc = 0;
                dropped = false;
                pickingUp = false;
            }
            if (dropped == true)
            {
                
                xLoc = player.xLoc;
                yLoc = player.yLoc;
                pickingUp = false;
                dropped = false;
            }
            if (used == true)
            {
                player.RegenShield(Global.ShieldSP);
                pickingUp = false;
                used = false;
                itemTile.tileCharacter = ' ';
            }
        }
    }
}
