using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Text_Based_RPG
{
    class Shopkeeper : GameCharacter
    {
        private Currency wallet;
        private bool isHostile;
        private string avatar = "C";
        private Player player;
        private Shop shop;

        public Shopkeeper(int x, int y, Player playerReference, Shop shopReference)
        {
            shop = shopReference;
            player = playerReference;
            characterTile.tileCharacter = 'C';
            xLoc = x;
            yLoc = y;
        }
        public void Update()
        {
            switch(player.isPlayerAt(xLoc, yLoc))
            {
                case true:
                    shop.SellMenu();
                    break;
                case false:
                    break;
            }
        }
    }
}
