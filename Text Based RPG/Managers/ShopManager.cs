using System;

namespace Text_Based_RPG
{
    class ShopManager
    {
        public int shopCount;
        private Shop[] shops = new Shop[shopCap];
        private static int shopCap = 100;

       
        public void InitShopFromWorldLoc(char[,] world, int X, int Y, ItemManager itemManager, Player player, Camera cam, Inventory inventory, EnemyManager enemyManager)
        {
            if (shopCount >  shopCap - 1) { return; }
            if (world[X, Y] == 'C') { shops[shopCount] = new Shop(X, Y, 3, 1, true, 3, itemManager, player, cam, inventory, enemyManager); shopCount = shopCount + 1; }
        }

        public void Update()
        {
            for(int i = 0; i < shopCount; i++)
            {
                shops[i].Update();
            }
        }
        public void Draw()
        {
            for (int i = 0; i < shopCount; i++)
            {
                shops[i].Draw();
            }
        }

        public void PurchaseFromShop(Shop shopToBuyFrom, Item itemToBuy)
        {
            shopToBuyFrom.ItemInteraction(itemToBuy);
        }

        public Shopkeeper GetFirstShopKeeper()
        {
            return shops[0].GetShopKeeper();
        }
    }
}
