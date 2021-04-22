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
            pickedUp = false;
            xLoc = X;
            yLoc = Y;
            itemTile.tileCharacter = '$';
            name = "Valuable";
        }
        public override void Update(Map map, Player player, Inventory inventory, Camera camera, ItemManager itemManager)
        {
            if (pickedUp == true)
            {
                player.CollectValuable(100);
                itemTile.tileCharacter = ' ';
                xLoc = 0;
                yLoc = 0;
                pickedUp = false;
            }

        }
    }
}
