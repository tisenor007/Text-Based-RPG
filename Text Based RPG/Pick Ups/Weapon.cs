﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Text_Based_RPG
{
    class Weapon : Item
    {
        public enum WeaponType
        {
            BrassKnuckles,
            BaseballBat,
            Knife,
            Machete,
            Chainsaw
        }
        public WeaponType weapon;
        //int to determine what weapon will be picked up
        
        public Weapon(int X, int Y, int weaponPickUp)
        {
            weaponBeingPickedUp = weaponPickUp;
            pickedUp = false;
            xLoc = X;
            yLoc = Y;
            itemTile.tileCharacter = 'W';
        }
        public override void Update(Map map, Player player, Inventory inventory, Camera camera)
        {
            if (pickedUp == true)
            {
                xLoc = 0;
                yLoc = 0;
                if (weaponBeingPickedUp == 1) {inventory.addItemToInventory("Brass Knuckles"); infoMessage = "You picked up Brass Knuckles"; base.Update(map, player, inventory, camera);}
                if (weaponBeingPickedUp == 2) {inventory.addItemToInventory("Baseball Bat"); infoMessage = "You picked up a Baseball Bat"; base.Update(map, player, inventory, camera);}
                if (weaponBeingPickedUp == 3) {inventory.addItemToInventory("Knife");  infoMessage = "You picked up a Knife"; base.Update(map, player, inventory, camera);}
                if (weaponBeingPickedUp == 4) {inventory.addItemToInventory("Machete"); infoMessage = "You picked up a Machete"; base.Update(map, player, inventory, camera);}
                if (weaponBeingPickedUp == 5) {inventory.addItemToInventory("Chain Saw"); infoMessage = "You picked up a Chain Saw"; base.Update(map, player, inventory, camera);}
                pickedUp = false;
            }
            
            if (dropped == true)
            {
                pickedUp = false;
                xLoc = player.xLoc;
                yLoc = player.yLoc;
                dropped = false;
            }
            if (used == true)
            {
                if (player.weaponInHand == "Fist")
                {

                }
                else
                {
                    inventory.addItemToInventory(player.weaponInHand);
                }
                if (weaponBeingPickedUp == 1){ SwitchWeapon(WeaponType.BrassKnuckles, player);}
                if (weaponBeingPickedUp == 2){ SwitchWeapon(WeaponType.BaseballBat, player); }
                if (weaponBeingPickedUp == 3){ SwitchWeapon(WeaponType.Knife, player);}
                if (weaponBeingPickedUp == 4){ SwitchWeapon(WeaponType.Machete, player);}
                if (weaponBeingPickedUp == 5){ SwitchWeapon(WeaponType.Chainsaw, player);}
                pickedUp = false;
                used = false;
                //itemTile.tileCharacter = ' ';
            }
        }
        public void SwitchWeapon(WeaponType newWeapon, Player player)
        {
            //sets what damage the weapons do and what they will be displayed as.......
            weapon = newWeapon;
            switch (weapon)
            {
                case WeaponType.BrassKnuckles:
                    player.weaponInHand = "Brass Knuckles";
                    player.attackDamage = 10;
                    break;
                case WeaponType.BaseballBat:
                    player.weaponInHand = "Baseball Bat";
                    player.attackDamage = 25;
                    break;
                case WeaponType.Knife:
                    player.weaponInHand = "Knife";
                    player.attackDamage = 50;
                    break;
                case WeaponType.Machete:
                    player.weaponInHand = "Machete";
                    player.attackDamage = 75;
                    break;
                case WeaponType.Chainsaw:
                    player.weaponInHand = "Chain Saw";
                    player.attackDamage = 100;
                    break;

            }
        }
    }
}
