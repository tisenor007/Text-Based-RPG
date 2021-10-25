using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Text_Based_RPG
{
    class Weapon : Item
    {

        //int to determine what weapon will be picked up
       
        
        public Weapon(int X, int Y, ItemType weaponPickUp)
        {
            itemType = weaponPickUp;
            pickedUp = false;
            xLoc = X;
            yLoc = Y;
            itemTile.tileCharacter = 'W';
            if (itemType == ItemType.BrassKnuckles) { name = "Brass Knuckles"; }
            else if (itemType == ItemType.BaseballBat) { name = "Baseball Bat"; }
            else if (itemType == ItemType.Knife) { name = "Knife"; }
            else if (itemType == ItemType.Machete) { name = "Machete"; }
            else if (itemType == ItemType.Chainsaw) { name = "Chainsaw"; }
            Random rand = new Random();
            SetPrice(rand.Next(1, 10));
        }
        public override void Update(Map map, Player player, Inventory inventory, Camera camera, ItemManager itemManager)
        {
            if (isShopItem == true)
                itemTile.tileColour = ConsoleColor.Yellow;

            if (pickedUp == true)
            {
                xLoc = 0;
                yLoc = 0;
                if (itemType == ItemType.BrassKnuckles) {inventory.addItemToInventory(this); infoMessage = "You have found a " + name + "!"; base.Update(map, player, inventory, camera, itemManager);}
                else if (itemType == ItemType.BaseballBat) {inventory.addItemToInventory(this); infoMessage = "You have found a " + name + "!"; base.Update(map, player, inventory, camera, itemManager);}
                else if (itemType == ItemType.Knife) {inventory.addItemToInventory(this); infoMessage = "You have found a " + name + "!"; base.Update(map, player, inventory, camera, itemManager);}
                else if (itemType == ItemType.Machete) {inventory.addItemToInventory(this); infoMessage = "You have found a " + name + "!"; base.Update(map, player, inventory, camera, itemManager);}
                else if (itemType == ItemType.Chainsaw) {inventory.addItemToInventory(this); infoMessage = "You have found a " + name + "!"; base.Update(map, player, inventory, camera, itemManager);}
                pickedUp = false;
            }
            
            if (dropped == true)
            {
                
                xLoc = player.xLoc;
                yLoc = player.yLoc;
                dropped = false;
            }
            if (used == true)
            {
                if (player.equippedWeapon.itemType == ItemType.Fist)
                {

                }
                
                else if (player.equippedWeapon.itemType == ItemType.BrassKnuckles) { itemManager.CheckandSwitchWeapon('W', ItemType.BrassKnuckles, inventory); }
                else if (player.equippedWeapon.itemType == ItemType.BaseballBat) { itemManager.CheckandSwitchWeapon('W', ItemType.BrassKnuckles, inventory); }
                else if (player.equippedWeapon.itemType == ItemType.Knife) { itemManager.CheckandSwitchWeapon('W', ItemType.Knife, inventory); }
                else if (player.equippedWeapon.itemType == ItemType.Machete) { itemManager.CheckandSwitchWeapon('W', ItemType.Machete, inventory); }
                else if (player.equippedWeapon.itemType == ItemType.Chainsaw) { itemManager.CheckandSwitchWeapon('W', ItemType.Chainsaw, inventory); }
                
                if (itemType == ItemType.BrassKnuckles) { SwitchWeapon(ItemType.BrassKnuckles, player);}
                if (itemType == ItemType.BaseballBat) { SwitchWeapon(ItemType.BaseballBat, player); }
                if (itemType == ItemType.Knife) { SwitchWeapon(ItemType.Knife, player); }
                if (itemType == ItemType.Machete) { SwitchWeapon(ItemType.Machete, player); }
                if (itemType == ItemType.Chainsaw) { SwitchWeapon(ItemType.Chainsaw, player); }
                pickedUp = false;
                used = false;
                //itemTile.tileCharacter = ' ';
            }
            
            
        }
        public void SwitchWeapon(ItemType newWeapon, Player player)
        {
            //sets what damage the weapons do and what they will be displayed as.......
            itemType = newWeapon;
            switch (itemType)
            {
                case ItemType.Fist:
                    player.equippedWeapon.itemType = ItemType.Fist;
                    player.attackDamage = 5;
                    break;
                case ItemType.BrassKnuckles:
                    player.equippedWeapon.itemType = ItemType.BrassKnuckles;
                    player.attackDamage = 10;
                    break;
                case ItemType.BaseballBat:
                    player.equippedWeapon.itemType = ItemType.BaseballBat;
                    player.attackDamage = 25;
                    break;
                case ItemType.Knife:
                    player.equippedWeapon.itemType = ItemType.Knife;
                    player.attackDamage = 50;
                    break;
                case ItemType.Machete:
                    player.equippedWeapon.itemType = ItemType.Machete;
                    player.attackDamage = 75;
                    break;
                case ItemType.Chainsaw:
                    player.equippedWeapon.itemType = ItemType.Chainsaw;
                    player.attackDamage = 100;
                    break;

            }
        }
    }
}
