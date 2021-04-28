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
        //total number of enemies
        private static int itemCap = 100;
        public void InitItemFromWorldLoc(char[,] world, int X, int Y)
        {
                if (itemCount > itemCap - 1) { return; }
                if (world[X, Y] == '+') { items[itemCount] = new FirstAidKit(X, Y); itemCount = itemCount + 1; }
                if (world[X, Y] == '&') { items[itemCount] = new Key(X, Y); itemCount = itemCount + 1; }
                if (world[X, Y] == 'S') { items[itemCount] = new Shield(X, Y); itemCount = itemCount + 1; }
                if (world[X, Y] == '$') { items[itemCount] = new Valuable(X, Y); itemCount = itemCount + 1; }
                if (world[X, Y] == '1') { items[itemCount] = new Weapon(X, Y, Item.ItemType.BrassKnuckles); itemCount = itemCount + 1; }
                if (world[X, Y] == '2') { items[itemCount] = new Weapon(X, Y, Item.ItemType.BaseballBat); itemCount = itemCount + 1; }
                if (world[X, Y] == 'W') { items[itemCount] = new Weapon(X, Y, Item.ItemType.Knife); itemCount = itemCount + 1; }
                if (world[X, Y] == '4') { items[itemCount] = new Weapon(X, Y, Item.ItemType.Machete); itemCount = itemCount + 1; }
                if (world[X, Y] == '5') { items[itemCount] = new Weapon(X, Y, Item.ItemType.Chainsaw); itemCount = itemCount + 1; }
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
                if (x == items[i].xLoc)
                {
                    if (y == items[i].yLoc)
                    {
                        items[i].pickedUp = true;
                        return;
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
    }
}
