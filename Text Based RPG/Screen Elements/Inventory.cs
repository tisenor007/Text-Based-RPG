using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Text_Based_RPG
{
    class Inventory
    {
        public Item[] slots = new Item[inventorySize];
        //keeps track of things in iventory
        public int filledInventorySlots = 0;
        public bool inventoryIsOpen = false;
        public bool inventoryIsFull = false;
        private static int inventorySize = 10;

        public void Update(Player player, ItemManager itemManager)
        {
            if (inventoryIsFull)
                inventorySize = filledInventorySlots + 1;
            else
                inventorySize = 10;
            if (inventoryIsOpen == true) { OpenInventory(player, itemManager); }
        }
        public void addItemToInventory(Item item)
        {
            if (filledInventorySlots < inventorySize)
            {
                inventoryIsFull = false;
                for (int i = 0; i < inventorySize; i++)
                {
                    if (slots[i] == null)
                    {
                        slots[i] = item;
                        filledInventorySlots = filledInventorySlots + 1;
                        return;
                    }
                }
            }
            else
            {
                inventoryIsFull = true;
                return;
            }
        }

        public void removeItemFromInventory(int itemSlot)
        {
            slots[itemSlot] = null;
            filledInventorySlots = filledInventorySlots - 1;
        }
        public void SellInventory(Player player)
        {
            for (bool sellMenuOpen = true; sellMenuOpen = true;)
            {
                Console.Clear();
                Console.WriteLine("Clerk: What do you want to sell to me?");
                Console.WriteLine();
                for (int i = 0; i < inventorySize; i++)
                {
                    if (slots[i] == null)
                    {
                        Console.WriteLine("Inventory slot " + (i + 1) + ": ");
                    }
                    else
                    {
                        Console.WriteLine("Inventory slot " + (i + 1) + ": " + slots[i].itemType);
                    }

                }
                Console.WriteLine();
                Console.WriteLine("To sell an item, press the related number of said item.");
                Console.WriteLine();
                Console.WriteLine("B) Exit");
                Console.WriteLine();

                ConsoleKeyInfo input = Console.ReadKey(true);
                for (int x = 0; x < inventorySize; x++)
                {
                    if (input.Key == ConsoleKey.B)
                    {
                        sellMenuOpen = false;
                        return;
                    }
                    else if (((int)input.Key)-48 == x+1)
                    {
                        if (slots[x] != null)
                        {
                            for (bool inputCheck = false; inputCheck == false;)
                            {
                                Console.Clear();
                                Console.WriteLine("Do you want to sell " + slots[x].CheckName() + " for " + slots[x].CheckPrice() + "?");
                                Console.WriteLine("Y) Yes     N) No");
                                ConsoleKeyInfo secondaryInput = Console.ReadKey(true);

                                if (secondaryInput.Key == ConsoleKey.Y)
                                {
                                    player.GainMoney(slots[x].CheckPrice());
                                    removeItemFromInventory(x);
                                    inputCheck = true;
                                }
                                else if (secondaryInput.Key == ConsoleKey.N)
                                {
                                    inputCheck = true;
                                }
                            }
                            sellMenuOpen = false;
                        }
                    }
                }
            }

        }

        public void OpenInventory(Player player, ItemManager itemManager)
        {
            Console.Clear();
            for (int i = 0; i < inventorySize; i++)
            {
                if (slots[i] == null)
                {
                    Console.WriteLine("Inventory slot " + (i + 1) + ": ");
                }
                else
                {
                    Console.WriteLine("Inventory slot " + (i + 1) + ": " + slots[i].itemType);
                }
                
            }
            Console.WriteLine();
            Console.WriteLine("b + enter: return to the game....");
            Console.WriteLine();
            Console.WriteLine("u + enter: unequip weapon");
            Console.WriteLine();
            Console.WriteLine("Number of slot + enter: select item");
    
            string input = Console.ReadLine();
            if (input == "u")
            {
                //can't unarm your fist!
                if (player.weaponInHand.itemType == Item.ItemType.Fist){Console.WriteLine("You are already unarmed!");}
                else 
                {
                    //if inventory slot is available, puts previous weapon in inventory
                    if (filledInventorySlots < inventorySize) 
                    {
                        if (player.weaponInHand.itemType == Item.ItemType.BrassKnuckles) { itemManager.CheckandSwitchWeapon('W', Item.ItemType.BrassKnuckles, this); }
                        if (player.weaponInHand.itemType == Item.ItemType.BaseballBat) { itemManager.CheckandSwitchWeapon('W', Item.ItemType.BaseballBat, this); }
                        if (player.weaponInHand.itemType == Item.ItemType.Knife) { itemManager.CheckandSwitchWeapon('W', Item.ItemType.Knife, this); }
                        if (player.weaponInHand.itemType == Item.ItemType.Machete) { itemManager.CheckandSwitchWeapon('W', Item.ItemType.Machete, this); }
                        if (player.weaponInHand.itemType == Item.ItemType.Chainsaw) { itemManager.CheckandSwitchWeapon('W', Item.ItemType.Chainsaw, this); }
                    }
                    else
                    {
                        //if inventory is full you just drop you weapon that you are unarming
                        if (player.weaponInHand.itemType == Item.ItemType.BrassKnuckles) { itemManager.CheckToDropItem('W', Item.ItemType.BrassKnuckles); }
                        if (player.weaponInHand.itemType == Item.ItemType.BaseballBat) { itemManager.CheckToDropItem('W', Item.ItemType.BaseballBat); }
                        if (player.weaponInHand.itemType == Item.ItemType.Knife) { itemManager.CheckToDropItem('W', Item.ItemType.Knife); }
                        if (player.weaponInHand.itemType == Item.ItemType.Machete) { itemManager.CheckToDropItem('W', Item.ItemType.Machete); }
                        if (player.weaponInHand.itemType == Item.ItemType.Chainsaw) { itemManager.CheckToDropItem('W', Item.ItemType.Chainsaw); }
                    }
                }
                player.BecomeUnarmed();
            }
            for (int i = 0; i < inventorySize; i++)
            {
                if (input == (i + 1).ToString())
                {
                    Console.Clear();
                    Console.WriteLine("What would you like to with this item?");
                    Console.WriteLine();
                    Console.WriteLine("d + enter: drop item  " + "  e + enter to use / equip item");
                    string action = Console.ReadLine();
                    //if you want to drop and item, it  contacts the item manager to see what it item you are trying to drop and drop it
                    if (action == "d")
                    {
                        if (slots[i] == null) { return; }
                        else if (slots[i].itemType == Item.ItemType.Shield) { itemManager.CheckToDropItem('S', Item.ItemType.Shield);removeItemFromInventory(i); inventoryIsOpen = false; Console.Clear(); }
                        else if (slots[i].itemType == Item.ItemType.FirstAidKit) { itemManager.CheckToDropItem('+', Item.ItemType.FirstAidKit); removeItemFromInventory(i); inventoryIsOpen = false; Console.Clear(); }
                        else if (slots[i].itemType == Item.ItemType.BrassKnuckles) { itemManager.CheckToDropItem('W', Item.ItemType.BrassKnuckles); removeItemFromInventory(i); inventoryIsOpen = false; Console.Clear(); }
                        else if (slots[i].itemType == Item.ItemType.BaseballBat) { itemManager.CheckToDropItem('W', Item.ItemType.BaseballBat); removeItemFromInventory(i); inventoryIsOpen = false; Console.Clear(); }
                        else if (slots[i].itemType == Item.ItemType.Knife) { itemManager.CheckToDropItem('W', Item.ItemType.Knife); removeItemFromInventory(i); inventoryIsOpen = false; Console.Clear(); }
                        else if (slots[i].itemType == Item.ItemType.Machete) { itemManager.CheckToDropItem('W', Item.ItemType.Machete); removeItemFromInventory(i); inventoryIsOpen = false; Console.Clear(); }
                        else if (slots[i].itemType == Item.ItemType.Chainsaw) { itemManager.CheckToDropItem('W', Item.ItemType.Chainsaw); removeItemFromInventory(i); inventoryIsOpen = false; Console.Clear(); }
                    }
                    //if you want to use an item it contacts item manager to be use an item and uses it.....
                    if (action == "e")
                    {
                        if (slots[i] == null) { return; }
                        else if (slots[i].itemType == Item.ItemType.Shield) { itemManager.CheckToUseItem('S', Item.ItemType.Shield); removeItemFromInventory(i); inventoryIsOpen = false; Console.Clear(); }
                        else if (slots[i].itemType == Item.ItemType.FirstAidKit) { itemManager.CheckToUseItem('+', Item.ItemType.FirstAidKit); removeItemFromInventory(i); inventoryIsOpen = false; Console.Clear();}
                        else if (slots[i].itemType == Item.ItemType.BrassKnuckles) { itemManager.CheckToUseItem('W', Item.ItemType.BrassKnuckles); removeItemFromInventory(i); inventoryIsOpen = false; Console.Clear(); }
                        else if (slots[i].itemType == Item.ItemType.BaseballBat) { itemManager.CheckToUseItem('W', Item.ItemType.BaseballBat); removeItemFromInventory(i); inventoryIsOpen = false; Console.Clear(); }
                        else if (slots[i].itemType == Item.ItemType.Knife) { itemManager.CheckToUseItem('W', Item.ItemType.Knife); removeItemFromInventory(i); inventoryIsOpen = false; Console.Clear(); }
                        else if (slots[i].itemType == Item.ItemType.Machete) { itemManager.CheckToUseItem('W', Item.ItemType.Machete); removeItemFromInventory(i); inventoryIsOpen = false; Console.Clear(); }
                        else if (slots[i].itemType == Item.ItemType.Chainsaw) { itemManager.CheckToUseItem('W', Item.ItemType.Chainsaw); removeItemFromInventory(i); inventoryIsOpen = false; Console.Clear(); }
                    }
                    //else { return; }
                }
                //else { return; }
            }
            if (input == "b"){inventoryIsOpen = false;}
        }
        //boolean used by player to see if inventory is full before they pick up an item......
        public bool IsInventorySlotAvailable()
        {
            if (filledInventorySlots < inventorySize)
            {
                inventoryIsFull = false;
                return true;
            }
            else
            {
                inventoryIsFull = true;
                return false;
            }
            
        }
    }
}
