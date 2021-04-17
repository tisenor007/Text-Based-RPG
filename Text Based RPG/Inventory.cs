using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Text_Based_RPG
{
    class Inventory
    {
        public static int inventorySize = 10;
        public String[] slots = new String[inventorySize];
        public int filledInventorySlots = 0;
        public bool inventoryOpen = false;

        public void addItemToInventory(string item)
        {
            if (filledInventorySlots == inventorySize - 1)
            {
                Console.WriteLine("INVENTORY FULL!");
                return;
            }
            for (int i = 0; i < inventorySize - 1; i++)
            {
                if(slots[i] == null)
                {
                    slots[i] = item;   
                    return;
                }
            }
           
        }

        public void removeItemFromInventory(int itemSlot)
        {
            slots[itemSlot] = null;
        }

        public void displayInventory()
        {
            Console.Clear();
            for (int i = 0; i < inventorySize; i++)
            {
                Console.WriteLine("Inventory slot " + i + ": " +slots[i]);
            }
        }
    }
}
