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
            pickingUp = false;
            xLoc = X;
            yLoc = Y;
            itemTile.tileCharacter = Global.keyAppearance;
            itemTile.tileColour = Global.keyColour;
            itemType = ItemType.Key;
            name = ItemType.Key.ToString();
        }

        public override void Update(Map map, Player player, Inventory inventory, Camera camera, ItemManager itemManager)
        {
            //if they are picked up doors open and pickup turns invisible and goes off screen.....
            if (pickingUp == true)
            {
                //lets you know
                infoMessage = "You found a "+name+"!";
                base.Update(map, player, inventory, camera, itemManager);
                map.openDoors = true;
                itemTile.tileCharacter = ' ';
                xLoc = 0;
                yLoc = 0;
                //stops console.writeline from repeating
                pickingUp = false;
            }
        }

    }
}
