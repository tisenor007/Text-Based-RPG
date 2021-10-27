using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Text_Based_RPG
{
    class Valuable : Item
    {
        public Valuable(int X, int Y)
        {
            //valuable properties...
            pickingUp = false;
            xLoc = X;
            yLoc = Y;
            itemTile.tileCharacter = Global.valuableAppearance;
            itemTile.tileColour = Global.valuableColour;
            itemType = ItemType.Valuable;
        }
        public override void Update(Map map, Player player, Inventory inventory, Camera camera, ItemManager itemManager)
        {
            if (pickingUp == true)
            {
                player.CollectValuable();
                itemTile.tileCharacter = ' ';
                xLoc = 0;
                yLoc = 0;
                pickingUp = false;
            }

        }
    }
}
