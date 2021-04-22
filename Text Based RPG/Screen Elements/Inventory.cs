using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Text_Based_RPG
{
    class Inventory
    {
        
        public String[] slots = new String[inventorySize];
        //keeps track of things in iventory
        public int filledInventorySlots = 0;
        public bool inventoryOpen = false;
        public bool inventoryFull = false;
        private static int inventorySize = 10;
        public void addItemToInventory(string item)
        {
            if (filledInventorySlots < inventorySize)
            {
                inventoryFull = false;
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
                inventoryFull = true;
                return;
            }
        }

        public void removeItemFromInventory(int itemSlot)
        {
            slots[itemSlot] = null;
        }

        public void displayInventory(Player player, ItemManager itemManager)
        {
            Console.Clear();
            for (int i = 0; i < inventorySize; i++)
            {
                Console.WriteLine("Inventory slot " + (i+1) + ": " +slots[i]);
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
                if (player.weaponInHand == "Fist"){Console.WriteLine("You are already unarmed!");}
                else 
                {
                    //if inventory slot is available, puts previous weapon in inventory
                    if (filledInventorySlots < inventorySize){addItemToInventory(player.weaponInHand);}
                    else
                    {
                        //if inventory is full you just drop you weapon that you are unarming
                        if (player.weaponInHand == "Brass Knuckles") { itemManager.CheckToDropItem('W', 1);}
                        if (player.weaponInHand == "Baseball Bat") { itemManager.CheckToDropItem('W', 2);}
                        if (player.weaponInHand == "Knife") { itemManager.CheckToDropItem('W', 3);}
                        if (player.weaponInHand == "Machete") { itemManager.CheckToDropItem('W', 4);}
                        if (player.weaponInHand == "Chain Saw") { itemManager.CheckToDropItem('W', 5);}
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
                        if (slots[i] == "Shield") { itemManager.CheckToDropItem('S', 0);slots[i] = null; filledInventorySlots = filledInventorySlots - 1; inventoryOpen = false; Console.Clear(); }
                        if (slots[i] == "First Aid Kit") { itemManager.CheckToDropItem('+', 0);slots[i] = null; filledInventorySlots = filledInventorySlots - 1; inventoryOpen = false; Console.Clear(); }
                        if (slots[i] == "Brass Knuckles") { itemManager.CheckToDropItem('W', 1);slots[i] = null; filledInventorySlots = filledInventorySlots - 1; inventoryOpen = false; Console.Clear(); }
                        if (slots[i] == "Baseball Bat") { itemManager.CheckToDropItem('W', 2);slots[i] = null; filledInventorySlots = filledInventorySlots - 1; inventoryOpen = false; Console.Clear(); }
                        if (slots[i] == "Knife") { itemManager.CheckToDropItem('W', 3);slots[i] = null; filledInventorySlots = filledInventorySlots - 1; inventoryOpen = false; Console.Clear(); }
                        if (slots[i] == "Machete") { itemManager.CheckToDropItem('W', 4);slots[i] = null; filledInventorySlots = filledInventorySlots - 1; inventoryOpen = false; Console.Clear(); }
                        if (slots[i] == "Chain Saw") { itemManager.CheckToDropItem('W', 5);slots[i] = null; filledInventorySlots = filledInventorySlots - 1; inventoryOpen = false; Console.Clear(); }
                    }
                    //if you want to use an item it contacts item manager to be use an item and uses it.....
                    if (action == "e")
                    {
                        if (slots[i] == "Shield") { itemManager.CheckToUseItem('S', 0); slots[i] = null; filledInventorySlots = filledInventorySlots - 1; inventoryOpen = false; Console.Clear(); }
                        if (slots[i] == "First Aid Kit") { itemManager.CheckToUseItem('+', 0); slots[i] = null; filledInventorySlots = filledInventorySlots - 1; inventoryOpen = false; Console.Clear(); }
                        if (slots[i] == "Brass Knuckles") { itemManager.CheckToUseItem('W', 1); slots[i] = null; filledInventorySlots = filledInventorySlots - 1; inventoryOpen = false; Console.Clear(); }
                        if (slots[i] == "Baseball Bat") { itemManager.CheckToUseItem('W', 2); slots[i] = null; filledInventorySlots = filledInventorySlots - 1; inventoryOpen = false; Console.Clear(); }
                        if (slots[i] == "Knife") { itemManager.CheckToUseItem('W', 3); slots[i] = null; filledInventorySlots = filledInventorySlots - 1; inventoryOpen = false; Console.Clear(); }
                        if (slots[i] == "Machete") { itemManager.CheckToUseItem('W', 4); slots[i] = null; filledInventorySlots = filledInventorySlots - 1; inventoryOpen = false; Console.Clear(); }
                        if (slots[i] == "Chain Saw") { itemManager.CheckToUseItem('W', 5); slots[i] = null; filledInventorySlots = filledInventorySlots - 1; inventoryOpen = false; Console.Clear(); }
                    }
                    //else { return; }
                }
                //else { return; }
            }
            if (input == "b"){inventoryOpen = false;}
        }
        //boolean used by player to see if inventory is full before they pick up an item......
        public bool IsInventorySlotAvailable()
        {
            if (filledInventorySlots < inventorySize)
            {
                inventoryFull = false;
                return true;
            }
            else
            {
                inventoryFull = true;
                return false;
            }
            
        }
    }
}
