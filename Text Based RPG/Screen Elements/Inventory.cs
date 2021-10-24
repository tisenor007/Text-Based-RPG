using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Text_Based_RPG
{
    class Inventory
    {
        public Item[] slots = new Item[Global.playerInventorySlotAmount];
        //keeps track of things in iventory
        public int filledInventorySlots = 0;
        public bool inventoryIsOpen = false;
        public bool inventoryIsFull = false;
        public bool settingUpInventory;
        //private static int inventorySize = Global.playerInventorySlotAmount;
        public Inventory(ItemManager itemManager)
        {
            settingUpInventory = true;
            for (int i = 0; i <= Global.playerInventorySlotAmount - 1; i++)
            {
                if (Global.playerInventoryData[i] == Item.ItemType.FirstAidKit.ToString())
                {
                    setInventorySlot(i, itemManager, Item.ItemType.FirstAidKit);
                }
                if (Global.playerInventoryData[i] == Item.ItemType.Shield.ToString())
                {
                    setInventorySlot(i, itemManager, Item.ItemType.Shield);
                }
                if (Global.playerInventoryData[i] == Item.ItemType.BrassKnuckles.ToString())
                {
                    setInventorySlot(i, itemManager, Item.ItemType.BrassKnuckles);
                }
                if (Global.playerInventoryData[i] == Item.ItemType.BaseballBat.ToString())
                {
                    setInventorySlot(i, itemManager, Item.ItemType.BaseballBat);
                }
                if (Global.playerInventoryData[i] == Item.ItemType.Knife.ToString())
                {
                    setInventorySlot(i, itemManager, Item.ItemType.Knife);
                }
                if (Global.playerInventoryData[i] == Item.ItemType.Machete.ToString())
                {
                    setInventorySlot(i, itemManager, Item.ItemType.Machete);
                }
                if (Global.playerInventoryData[i] == Item.ItemType.Chainsaw.ToString())
                {
                    setInventorySlot(i, itemManager, Item.ItemType.Chainsaw);
                }
            }
            settingUpInventory = false;
        }
        public void Update(Player player, ItemManager itemManager)
        {
            if (filledInventorySlots >= 9)
                if(filledInventorySlots + 1 <= (Global.playerInventorySlotAmount) -1)
                    Global.playerInventorySlotAmount = filledInventorySlots + 1;
            else
                    Global.playerInventorySlotAmount = 10;
            if (inventoryIsOpen == true) { OpenInventory(player, itemManager); }
        }
        public void setInventorySlot(int slotNumber, ItemManager itemManager, Item.ItemType itemName)
        {
            itemManager.CreateItemInInventory(itemName);
            slots[slotNumber] = new Item();
            slots[slotNumber].itemType = itemName;
            filledInventorySlots = filledInventorySlots + 1;
           
        }
        public int InventorySize()
        {
            return Global.playerInventorySlotAmount;
        }
        public Item InventorySlots(int index)
        {
            return slots[index];
        }
        public void addItemToInventory(Item item)
        {
            if (filledInventorySlots < Global.playerInventorySlotAmount)
            {
                inventoryIsFull = false;
                for (int i = 0; i < Global.playerInventorySlotAmount; i++)
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
        public void SellInventoryDisplay(Player player, Shopkeeper shopKeeper)
        { 
            for (int i = 0; i < Global.playerInventorySlotAmount; i++)
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
        }

        public void OpenInventory(Player player, ItemManager itemManager)
        {
            Console.Clear();
            for (int i = 0; i < Global.playerInventorySlotAmount; i++)
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
                    if (filledInventorySlots < Global.playerInventorySlotAmount) 
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
            for (int i = 0; i < Global.playerInventorySlotAmount; i++)
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
            if (filledInventorySlots < Global.playerInventorySlotAmount)
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
