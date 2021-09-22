using System;

namespace Text_Based_RPG
{
    class ShopManager
    {
        private Shop[] shops;
        private Random rand = new Random();

        public ShopManager(ItemManager itemManager, Player player, Camera cam, Inventory inventory, EnemyManager enemyManager)
        {
            shops = new Shop[3];
            shops[0] = new Shop(44, 10, 3, 1, true, 3, itemManager, player, cam, inventory, enemyManager, rand);
            shops[1] = new Shop(118, 9, 1, 2, true, 3, itemManager, player, cam, inventory, enemyManager, rand);
            shops[2] = new Shop(47, 24, 2, -2, true, 3, itemManager, player, cam, inventory, enemyManager, rand);
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

        public Shopkeeper GetFirstShopKeeper()
        {
            return shops[0].GetShopKeeper();
        }
    }
}
