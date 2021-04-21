using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Text_Based_RPG
{
    class Inventory
    {
        private static int inventorySize = 10;
        public String[] slots = new String[inventorySize];
        public int filledInventorySlots = 0;
        public bool inventoryOpen = false;
        public bool inventoryFull = false;

        
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
            Console.WriteLine("e + enter: return to the game....");
            Console.WriteLine();
            Console.WriteLine("Number of slot + enter: select item");
    
            string input = Console.ReadLine();
            for (int i = 0; i < inventorySize; i++)
            {
                if (input == (i + 1).ToString())
                {
                    Console.Clear();
                    Console.WriteLine("What would you like to with this item?");
                    Console.WriteLine();
                    Console.WriteLine("d + enter: drop item  " + "  u + enter to use item");
                    //Console.Clear();
                    //string input = Console.ReadLine();
                    string action = Console.ReadLine();
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
                    if (action == "u")
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
            //if (input == "1d")
            //{ 
            //    if (slots[0] == "Shield") 
            //    {

            //    } 
            //    slots[0] = null;
            //}
            //if (input == "2d"){slots[1] = null;}
            //if (input == "3d"){slots[2] = null;}
            //if (input == "4d"){slots[3] = null;}
            //if (input == "5d"){slots[4] = null;}
            //if (input == "6d"){slots[5] = null;}
            //if (input == "7d"){slots[6] = null;}
            //if (input == "8d"){slots[7] = null;}
            //if (input == "9d"){slots[8] = null;}
            //if (input == "10d"){slots[9] = null;}
            if (input == "e")
            {
                inventoryOpen = false;
            }
        }
        public bool IsInventoryFull()
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
