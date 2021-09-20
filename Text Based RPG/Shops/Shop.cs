using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Text_Based_RPG
{
    class Shop
    {
        private bool isShopOpen;
        private Random rand = new Random();
        private Item newItem = new Item();
        private Player player;
        private GameCharacter shopKeeper;
        private Camera camera;
        private Inventory inventory;
        private EnemyManager enemyManager;
        private int xLoc;
        private int yLoc;
        public Shop(int shopCenterX, int shopCenterY, int shopWidth, int shopHeight, bool isShopVertical, int amountOfItems, ItemManager itemManager, Player playerReference, Camera cam, Inventory inventoryReference, EnemyManager enemyManagerReference)
        {
            isShopOpen = true;
            player = playerReference;
            camera = cam;
            inventory = inventoryReference;
            enemyManager = enemyManagerReference;
            xLoc = shopCenterX;
            yLoc = shopCenterY;

            shopKeeper = new Shopkeeper(shopCenterX, shopCenterY, player, this);
            if (isShopVertical)
            {
               for(int x = 0; x < amountOfItems; x++)
                {
                    CreateItem((shopCenterX - shopWidth) + x, (shopCenterY - shopHeight));
                    newItem.SetShopItem(true);
                    newItem.SetPrice(rand.Next(1, 10));
                    newItem.SetPosition((shopCenterX - shopWidth) + x, (shopCenterY - shopHeight));
                    newItem.SetShop(this);
                    itemManager.AddShopItem(newItem);
                }
            } else
            {
                for (int x = 0; x < amountOfItems; x++)
                {
                    CreateItem((shopCenterX - shopWidth), (shopCenterY - shopHeight) + x);
                    newItem.SetShopItem(true);
                    newItem.SetPrice(rand.Next(1, 10));
                    newItem.SetPosition((shopCenterX - shopWidth), (shopCenterY - shopHeight) + x);
                    newItem.SetShop(this);
                    itemManager.AddShopItem(newItem);
                }
            }
        }
        public void Update()
        {
            shopKeeper.Update();  
        }
        public void Draw()
        {
            shopKeeper.Draw(camera);
        }

        public void ItemInteraction(Item itemToBuy)
        {
            if (isShopOpen)
            {
                Purchase(itemToBuy);
            } else
            {
                PickUpItem(itemToBuy);
            }
        }
        public void SellMenu()
        {
            inventory.SellInventory(player);
        }

            private void Purchase(Item itemToBuy)
        {
            for (bool shopLoop = true; shopLoop != false;)
            {
                if(player.CheckMoney() >= itemToBuy.CheckPrice())
                {
                    Console.Clear();
                    Console.WriteLine("Do you want to buy this " + itemToBuy.CheckName() + "!");
                    Console.WriteLine("Cost: " + itemToBuy.CheckPrice() + "    Gold: " + player.CheckMoney());
                    Console.WriteLine("Y) Yes    N) No      S) Steal");
                    ConsoleKeyInfo keyPressed = Console.ReadKey(true);
                    if (keyPressed.Key == ConsoleKey.Y)
                    {
                        PickUpItem(itemToBuy);
                        player.LoseMoney(itemToBuy.CheckPrice());
                        shopLoop = false;
                    } else if (keyPressed.Key == ConsoleKey.N)
                    {
                        shopLoop = false;
                    } else if(keyPressed.Key == ConsoleKey.S)
                    {
                        PickUpItem(itemToBuy);
                        isShopOpen = false;
                        shopKeeper = new Heavy(shopKeeper.xLoc, shopKeeper.yLoc);
                        shopLoop = false;
                    }
                } else
                {
                    Console.Clear();
                    Console.WriteLine("You cannot afford this " + itemToBuy.CheckName() + "!");
                    Console.WriteLine("Cost: " + itemToBuy.CheckPrice() + "    Gold: " + player.CheckMoney());
                    Console.WriteLine("L) Leave   S) Steal");
                    ConsoleKeyInfo keyPressed = Console.ReadKey(true);
                    if (keyPressed.Key == ConsoleKey.L)
                    {
                        shopLoop = false;
                    }
                    else if (keyPressed.Key == ConsoleKey.S)
                    {
                        PickUpItem(itemToBuy);
                        isShopOpen = false;
                        StolenItem();
                        shopLoop = false;
                    }
                }
            }
        }       

        private void PickUpItem(Item itemToPickUp)
        {
            itemToPickUp.pickedUp = true;
            itemToPickUp.SetShopItem(false);
        }

        private void CreateItem(int x, int y)
        {
            switch (rand.Next(0, 5))
            {
                case 0:
                    newItem = new Shield(x, y);
                    break;
                case 1:
                    newItem = new FirstAidKit(x, y);
                    break;
                case 2:
                    newItem = new Weapon(x, y, Item.ItemType.Knife);
                    break;
                case 3:
                    newItem = new Weapon(x, y, Item.ItemType.BaseballBat);
                    break;
                case 4:
                    newItem = new Weapon(x, y, Item.ItemType.BrassKnuckles);
                    break;
                case 5:
                    newItem = new Weapon(x, y, Item.ItemType.Machete);
                    break;
                default:
                    newItem = new FirstAidKit(x, y);
                    break;
            }
        }

        private void StolenItem()
        {
            enemyManager.AddHeavyEnemy(xLoc, yLoc);
            shopKeeper.Disappear();
        }
    }
}
