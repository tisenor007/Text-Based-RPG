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
       //public Inventory()
       // {
       //     for (int i = 0; i < inventorySize; i++)
       //     {
       //         slots[i] = new Item();
       //     }
       // }
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
                    Console.WriteLine("Inventory slot " + (i + 1) + ": " + slots[i].name);
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
                if (player.weaponInHand == "Fist"){Console.WriteLine("You are already unarmed!");}
                else 
                {
                    //if inventory slot is available, puts previous weapon in inventory
                    if (filledInventorySlots < inventorySize) 
                    {
                        if (player.weaponInHand == "Brass Knuckles") { itemManager.CheckItemToSwitchWeapon('W', 1, this); }
                        if (player.weaponInHand == "Baseball Bat") { itemManager.CheckItemToSwitchWeapon('W', 2, this); }
                        if (player.weaponInHand == "Knife") { itemManager.CheckItemToSwitchWeapon('W', 3, this); }
                        if (player.weaponInHand == "Machete") { itemManager.CheckItemToSwitchWeapon('W', 4, this); }
                        if (player.weaponInHand == "Chain Saw") { itemManager.CheckItemToSwitchWeapon('W', 5, this); }
                    }
                    else
                    {
                        //if inventory is full you just drop you weapon that you are unarming
                        if (player.weaponInHand == "Brass Knuckles") { itemManager.CheckToDropItem('W', 1); }
                        if (player.weaponInHand == "Baseball Bat") { itemManager.CheckToDropItem('W', 2); }
                        if (player.weaponInHand == "Knife") { itemManager.CheckToDropItem('W', 3); }
                        if (player.weaponInHand == "Machete") { itemManager.CheckToDropItem('W', 4); }
                        if (player.weaponInHand == "Chain Saw") { itemManager.CheckToDropItem('W', 5); }
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
                        else if (slots[i].name == "Shield") { itemManager.CheckToDropItem('S', 0);slots[i] = null; filledInventorySlots = filledInventorySlots - 1; inventoryIsOpen = false; Console.Clear(); }
                        else if (slots[i].name == "First Aid Kit") { itemManager.CheckToDropItem('+', 0);slots[i] = null; filledInventorySlots = filledInventorySlots - 1; inventoryIsOpen = false; Console.Clear(); }
                        else if (slots[i].name == "Brass Knuckles") { itemManager.CheckToDropItem('W', 1);slots[i] = null; filledInventorySlots = filledInventorySlots - 1; inventoryIsOpen = false; Console.Clear(); }
                        else if (slots[i].name == "Baseball Bat") { itemManager.CheckToDropItem('W', 2);slots[i] = null; filledInventorySlots = filledInventorySlots - 1; inventoryIsOpen = false; Console.Clear(); }
                        else if (slots[i].name == "Knife") { itemManager.CheckToDropItem('W', 3);slots[i] = null; filledInventorySlots = filledInventorySlots - 1; inventoryIsOpen = false; Console.Clear(); }
                        else if (slots[i].name == "Machete") { itemManager.CheckToDropItem('W', 4);slots[i] = null; filledInventorySlots = filledInventorySlots - 1; inventoryIsOpen = false; Console.Clear(); }
                        else if (slots[i].name == "Chain Saw") { itemManager.CheckToDropItem('W', 5);slots[i] = null; filledInventorySlots = filledInventorySlots - 1; inventoryIsOpen = false; Console.Clear(); }
                    }
                    //if you want to use an item it contacts item manager to be use an item and uses it.....
                    if (action == "e")
                    {
                        if (slots[i] == null) { return; }
                        else if (slots[i].name == "Shield") { itemManager.CheckToUseItem('S', 0); slots[i] = null; filledInventorySlots = filledInventorySlots - 1; inventoryIsOpen = false; Console.Clear(); }
                        else if (slots[i].name == "First Aid Kit") { itemManager.CheckToUseItem('+', 0); slots[i] = null; filledInventorySlots = filledInventorySlots - 1; inventoryIsOpen = false; Console.Clear();}
                        else if (slots[i].name == "Brass Knuckles") { itemManager.CheckToUseItem('W', 1); slots[i] = null; filledInventorySlots = filledInventorySlots - 1; inventoryIsOpen = false; Console.Clear(); }
                        else if (slots[i].name == "Baseball Bat") { itemManager.CheckToUseItem('W', 2); slots[i] = null; filledInventorySlots = filledInventorySlots - 1; inventoryIsOpen = false; Console.Clear(); }
                        else if (slots[i].name == "Knife") { itemManager.CheckToUseItem('W', 3); slots[i] = null; filledInventorySlots = filledInventorySlots - 1; inventoryIsOpen = false; Console.Clear(); }
                        else if (slots[i].name == "Machete") { itemManager.CheckToUseItem('W', 4); slots[i] = null; filledInventorySlots = filledInventorySlots - 1; inventoryIsOpen = false; Console.Clear(); }
                        else if (slots[i].name == "Chain Saw") { itemManager.CheckToUseItem('W', 5); slots[i] = null; filledInventorySlots = filledInventorySlots - 1; inventoryIsOpen = false; Console.Clear(); }
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
