using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Text_Based_RPG
{
    class ShopItems : Item
    {
        private bool bought = false;
        private ItemManager itemManager;
        
        public ShopItems(ItemManager itemManagerReference)
        {
            itemManager = itemManagerReference;
        }
        public void Update(Player player, Inventory inventory)
        {
            if (bought)
                return;

            if (inventory.IsInventorySlotAvailable())
            {
                if(player.CheckGoldAmount() >= itemPrice)
                {
                    bool canBuyItem = true;
                    while (canBuyItem)
                    {
                        Console.Clear();
                        Console.CursorLeft = 0;
                        Console.CursorTop = 0;
                        Console.WriteLine("This " + itemName + " costs " + itemPrice + ". You have " + player.CheckGoldAmount() + ". Do you want to buy it?");
                        Console.WriteLine("Y) Yes      N) No");
                        ConsoleKeyInfo keyPressed = Console.ReadKey(true);
                        if (keyPressed.Key == ConsoleKey.Y)
                        {
                            GiveItem();
                            player.LoseGold(itemPrice);
                            canBuyItem = false;
                            bought = true;
                            pickedUp = true;
                            Console.Clear();
                            break;
                        } else if (keyPressed.Key == ConsoleKey.N)
                        {
                            canBuyItem = false;
                            Console.Clear();
                            break;
                        }
                    }
                } else
                {
                    Console.Clear();
                    Console.CursorLeft = 0;
                    Console.CursorTop = 0;
                    Console.WriteLine("This " + itemName + " costs " + itemPrice + ". You have " + player.CheckGoldAmount() + ". You cannot afford it.");
                    Console.ReadKey(true);
                    Console.Clear();
                }
            }
        }
        public override void Draw(Camera camera)
        {
            if (bought)
            {
                return;
            }
            camera.DrawToRenderer(itemTile.tileCharacter, xLoc, yLoc);

        }

        private void GiveItem()
        {
            Item newItem;
            switch (itemType)
            {
                case ItemType.Shield:
                    newItem = new Shield(0, 0);
                    itemManager.AddBoughtItem(newItem);
                    newItem.pickedUp = true;
                    break;
                case ItemType.FirstAidKit:
                    newItem = new FirstAidKit(0, 0);
                    itemManager.AddBoughtItem(newItem);
                    newItem.pickedUp = true;
                    break;
                case ItemType.BaseballBat:
                    newItem = new Weapon(0, 0, ItemType.BaseballBat);
                    itemManager.AddBoughtItem(newItem);
                    newItem.pickedUp = true;
                    break;
                case ItemType.BrassKnuckles:
                    newItem = new Weapon(0, 0, ItemType.BrassKnuckles);
                    itemManager.AddBoughtItem(newItem);
                    newItem.pickedUp = true;
                    break;
                case ItemType.Chainsaw:
                    newItem = new Weapon(0, 0, ItemType.Chainsaw);
                    itemManager.AddBoughtItem(newItem);
                    newItem.pickedUp = true;
                    break;
                case ItemType.Knife:
                    newItem = new Weapon(0, 0, ItemType.Knife);
                    itemManager.AddBoughtItem(newItem);
                    newItem.pickedUp = true;
                    break;
                case ItemType.Machete:
                    newItem = new Weapon(0, 0, ItemType.Machete);
                    itemManager.AddBoughtItem(newItem);
                    newItem.pickedUp = true;
                    break;
                default:
                    newItem = new FirstAidKit(0, 0);
                    itemManager.AddBoughtItem(newItem);
                    newItem.pickedUp = true;
                    break;
            }
            newItem.Bought();
        }


    }
}
