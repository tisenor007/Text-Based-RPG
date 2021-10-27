using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Text_Based_RPG
{
    class ItemManager
    {
        //makes array that size
        public Item[] items = new Item[itemCap];
        public int itemCount;
        public int valuableCount;
        //total number of enemies
        private static int itemCap = 100;

        private ShopManager shopManager;
        public void SetShopManager(ShopManager shopManagerReference)
        {
            shopManager = shopManagerReference;
        }

        //this runs as part of the Shop's init
        public void AddShopItem(Item itemToAdd)
        {
            for(int x = 0; x < itemCap; x++)
            {
                if(items[x] == null)
                {
                    items[x] = itemToAdd;
                    items[x].isShopItem = true;
                    itemCount = itemCount + 1;
                    return;
                }
            }
        }
        public void InitItemFromWorldLoc(char[,] world, int X, int Y)
        {
                if (itemCount > itemCap - 1) { return; }
                if (world[X, Y] == Global.firstAidAppearance) { items[itemCount] = new FirstAidKit(X, Y); itemCount = itemCount + 1; }
                if (world[X, Y] == Global.keyAppearance) { items[itemCount] = new Key(X, Y); itemCount = itemCount + 1; }
                if (world[X, Y] == Global.shieldAppearance) { items[itemCount] = new Shield(X, Y); itemCount = itemCount + 1; }
                if (world[X, Y] == Global.valuableAppearance) { items[itemCount] = new Valuable(X, Y); itemCount = itemCount + 1; valuableCount++; }
                //for Different weapon types
                if (world[X, Y] == '1') { items[itemCount] = new Weapon(X, Y, Item.ItemType.BrassKnuckles); itemCount = itemCount + 1; }
                if (world[X, Y] == '2') { items[itemCount] = new Weapon(X, Y, Item.ItemType.BaseballBat); itemCount = itemCount + 1; }
                if (world[X, Y] == '3') { items[itemCount] = new Weapon(X, Y, Item.ItemType.Knife); itemCount = itemCount + 1; }
                if (world[X, Y] == '4') { items[itemCount] = new Weapon(X, Y, Item.ItemType.Machete); itemCount = itemCount + 1; }
                if (world[X, Y] == '5') { items[itemCount] = new Weapon(X, Y, Item.ItemType.Chainsaw); itemCount = itemCount + 1; }
        }
        public void CreateItemInInventory(Item.ItemType itemType)
        {
            if (itemCount > itemCap - 1) { return; }
            if (itemType == Item.ItemType.FirstAidKit) { items[itemCount] = new FirstAidKit(0, 0); itemCount = itemCount + 1;}
            if (itemType == Item.ItemType.Shield) { items[itemCount] = new Shield(0, 0); itemCount = itemCount + 1;}
            if (itemType == Item.ItemType.BrassKnuckles) { items[itemCount] = new Weapon(0, 0, itemType); itemCount = itemCount + 1;}
            if (itemType == Item.ItemType.BaseballBat) { items[itemCount] = new Weapon(0, 0, itemType); itemCount = itemCount + 1;}
            if (itemType == Item.ItemType.Knife) { items[itemCount] = new Weapon(0, 0, itemType); itemCount = itemCount + 1; }
            if (itemType == Item.ItemType.Machete) { items[itemCount] = new Weapon(0, 0, itemType); itemCount = itemCount + 1;}
            if (itemType == Item.ItemType.Chainsaw) { items[itemCount] = new Weapon(0, 0, itemType); itemCount = itemCount + 1;}
        }

        //cycles through items and updates each one
        public void UpdateItems(Map map, Player player, Inventory inventory, Camera camera)
        {
            for (int i = 0; i < itemCount; i++)
            {
                items[i].Update(map, player, inventory, camera, this);
            }
        }
        //cycles through items and draws each one
        public void DrawItems(Camera camera)
        {
            for (int i = 0; i < itemCount; i++)
            {
                items[i].Draw(camera);
            }
        }
        public void SetItemColour(char[,] renderer, int x, int y, int offsetX, int offsetY)
        {
            for (int i = 0; i < itemCount; i++)
            {
                items[i].itemTile.SetTileColour(renderer, x, y, offsetX, offsetY);
            }
        }
        //used to define which item is being picked up
        public void CheckAndPickupItems(int x, int y)
        {
            for (int i = 0; i < itemCount; i++)
            {
                if (x == items[i].xLoc && items[i].pickingUp == false)
                {
                    if (y == items[i].yLoc && items[i].pickingUp == false)
                    {
                        if (CheckForShopItem(items[i]) && items[i].pickingUp == false)
                        {
                            shopManager.PurchaseFromShop(items[i].GetShop(), items[i]);
                        }
                        else if (items[i].pickingUp == false)
                        {
                            items[i].pickingUp = true;
                            return;
                        }
                    }
                }
            }
        }
        public void CheckToDropItem(char icon, Item.ItemType weapontype)
        {
            for (int i = 0; i < itemCount; i++)
            {
                if (items[i].xLoc == 0)
                {
                    if (items[i].yLoc == 0)
                    {
                        if ((items[i].itemTile.tileCharacter == icon) && (items[i].itemType == weapontype))
                        {
                            items[i].dropped = true;
                            return;
                        }
                    }
                }
            }
        }
        public void CheckandSwitchWeapon(char icon, Item.ItemType weapontype, Inventory inventory)
        {
            for (int i = 0; i < itemCount; i++)
            {
                if (items[i].xLoc == 0)
                {
                    if (items[i].yLoc == 0)
                    {
                        if ((items[i].itemTile.tileCharacter == icon) && (items[i].itemType == weapontype))
                        {
                            inventory.addItemToInventory(items[i]);
                            return;
                        }
                    }
                }
            }
        }
        public void CheckToUseItem(char icon, Item.ItemType weapontype)
        {
            for (int i = 0; i < itemCount; i++)
            {
                if (items[i].xLoc == 0)
                {
                    if (items[i].yLoc == 0)
                    {
                        if ((items[i].itemTile.tileCharacter == icon) && (items[i].itemType == weapontype))
                        {
                            items[i].used = true;
                            return;
                        }
                    }
                }
            }
        }
        //bool for other objects to detect collision with each items
        public bool IsItemAt(int x, int y)
        {
            for (int i = 0; i < itemCount; i++)
            {
                if (x == items[i].xLoc)
                {
                    if (y == items[i].yLoc)
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        public bool CheckForShopItem(Item itemToCheck)
        {
            return itemToCheck.IsShopItem();
        }
    }
}
