using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Text_Based_RPG
{
    class ShopManager
    {
        private Shop[] shops;

        public ShopManager(ItemManager itemManager, Player player, Camera cam, Inventory inventory)
        {
            shops = new Shop[3];
            shops[0] = new Shop(44, 10, 3, 1, true, 3, itemManager, player, cam, inventory);
            shops[1] = new Shop(118, 9, 3, 1, false, 3, itemManager, player, cam, inventory);
            shops[2] = new Shop(47, 24, 2, -2, true, 3, itemManager, player, cam, inventory);
        }

        public void Update()
        {
            for(int x = 0; x < shops.Length; x++)
            {
                shops[x].Update();
            }
        }
        public void Draw()
        {
            for (int x = 0; x < shops.Length; x++)
            {
                shops[x].Draw();
            }
        }

        public void PurchaseFromShop(Shop shopToBuyFrom, Item itemToBuy)
        {
            shopToBuyFrom.ItemInteraction(itemToBuy);
        }
    }
}
