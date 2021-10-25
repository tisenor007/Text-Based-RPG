using System;

namespace Text_Based_RPG
{
    class Shop
    {
        private bool isShopOpen;
        private Random rand = new Random();
        private Item newItem = new Item();
        private Player player;
        private Shopkeeper shopKeeper;
        private Camera camera;
        private Inventory inventory;
        private EnemyManager enemyManager;
        private int xLoc;
        private int yLoc;
        private int previousItemID = 0;
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
            shopKeeper.SetMoney(30);
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
            }
            else
            {
                PickUpItem(itemToBuy);
            }
        }
        public Shopkeeper GetShopKeeper()
        {
            return shopKeeper;
        }
        public void SellMenu()
        {
            for (bool sellMenuOpen = true; sellMenuOpen == true;)
            {
                Console.Clear();
                Console.WriteLine("Clerk: What do you want to sell to me?");
                Console.WriteLine();
                inventory.SellInventoryDisplay(player, shopKeeper);
                Console.WriteLine();
                Console.WriteLine("Clerk's Gold: " + shopKeeper.CheckMoney() + "      " + "Your Gold: " + player.CheckMoney());
                Console.WriteLine();
                Console.WriteLine("To sell an item, press the related number of said item + enter.");
                Console.WriteLine();
                Console.WriteLine("E + enter) Exit");
                Console.WriteLine();

                string input = Console.ReadLine();
                for (int x = 0; x < inventory.InventorySize(); x++)
                {
                    if (input == "e")
                    {
                        sellMenuOpen = false;
                        return;
                    }
                    else if (Convert.ToInt16(input) == x + 1)// - 48 == x + 1)
                    {
                        if (inventory.InventorySlots(x) != null)
                        {
                            if (inventory.InventorySlots(x).itemType == Item.ItemType.Key || inventory.InventorySlots(x).itemType == Item.ItemType.Valuable)
                            {
                                Console.Clear();
                                Console.WriteLine("You cannot sell this item.");
                                Console.WriteLine("Press any key to continue.");
                                Console.ReadKey(true);
                                return;
                            }
                            else
                            {
                                for (bool inputCheck = false; inputCheck == false;)
                                {
                                    if (shopKeeper.CheckMoney() >= inventory.InventorySlots(x).CheckPrice())
                                    {
                                        Console.Clear();
                                        Console.WriteLine("Do you want to sell " + inventory.InventorySlots(x).CheckName() + " for " + inventory.InventorySlots(x).CheckPrice() + "?");
                                        Console.WriteLine("Clerk's Gold: " + shopKeeper.CheckMoney() + "      " + "Your Gold: " + player.CheckMoney());
                                        Console.WriteLine("Y) Yes     N) No");
                                        ConsoleKeyInfo secondaryInput = Console.ReadKey(true);

                                        if (secondaryInput.Key == ConsoleKey.Y)
                                        {
                                            player.GainMoney(inventory.InventorySlots(x).CheckPrice());
                                            shopKeeper.LoseMoney(inventory.InventorySlots(x).CheckPrice());
                                            inventory.removeItemFromInventory(x);
                                            inputCheck = true;
                                        }
                                        else if (secondaryInput.Key == ConsoleKey.N)
                                        {
                                            inputCheck = true;
                                        }
                                    }
                                    else
                                    {
                                        Console.Clear();
                                        Console.WriteLine("The Clerk cannot afford the original price of " + inventory.InventorySlots(x).CheckPrice() + ".");
                                        Console.WriteLine("Do you still want to sell " + inventory.InventorySlots(x).CheckName() + " for " + shopKeeper.CheckMoney() + "?");
                                        Console.WriteLine("Clerk's Gold: " + shopKeeper.CheckMoney() + "      " + "Your Gold: " + player.CheckMoney());
                                        Console.WriteLine("Y) Yes     N) No");
                                        ConsoleKeyInfo secondaryInput = Console.ReadKey(true);

                                        if (secondaryInput.Key == ConsoleKey.Y)
                                        {
                                            player.GainMoney(shopKeeper.CheckMoney());
                                            shopKeeper.LoseMoney(shopKeeper.CheckMoney());
                                            inventory.removeItemFromInventory(x);
                                            inputCheck = true;
                                        }
                                        else if (secondaryInput.Key == ConsoleKey.N)
                                        {
                                            inputCheck = true;
                                        }
                                    }
                                }
                            }
                            sellMenuOpen = false;
                        }
                    }
                }
            }
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
                        shopKeeper.GainMoney(itemToBuy.CheckPrice());
                    } else if (keyPressed.Key == ConsoleKey.N)
                    {
                        shopLoop = false;
                    } else if(keyPressed.Key == ConsoleKey.S)
                    {
                        PickUpItem(itemToBuy);
                        isShopOpen = false;
                        StolenItem();
                        Console.Clear();
                        Console.WriteLine("Clerk: You thief! I'll make you regret robbing me!");
                        Console.ReadKey(true);
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
                        Console.Clear();
                        Console.WriteLine("Clerk: You thief! I'll make you regret robbing me!");
                        Console.ReadKey(true);
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
            int randomItem = rand.Next(8);
            while (randomItem == previousItemID)
            {
                randomItem = rand.Next(8);
            }
            previousItemID = randomItem;
            switch (randomItem)
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
                case 6:
                    newItem = new Shield(x, y);
                    break;
                case 7:
                    newItem = new FirstAidKit(x, y);
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
