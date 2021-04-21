using System;
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
        public override void Update(Map map, Player player, Inventory inventory)
        {
            if (pickedUp == true)
            {
                xLoc = 0;
                yLoc = 0;
                if (weaponBeingPickedUp == 1) { //SwitchWeapon(WeaponType.Fist, player); 
                    inventory.addItemToInventory("Brass Knuckles"); Console.WriteLine("You picked up Brass Knuckles"); }
                if (weaponBeingPickedUp == 2) { //SwitchWeapon(WeaponType.BaseballBat, player); 
                    inventory.addItemToInventory("Baseball Bat"); Console.WriteLine("You picked up a Baseball Bat"); }
                if (weaponBeingPickedUp == 3) { //SwitchWeapon(WeaponType.Knife, player); 
                    inventory.addItemToInventory("Knife"); Console.WriteLine("You picked up a Knife"); }
                if (weaponBeingPickedUp == 4) { //SwitchWeapon(WeaponType.Machete, player); 
                    inventory.addItemToInventory("Machete"); Console.WriteLine("You picked up a Machete"); }
                if (weaponBeingPickedUp == 5) { //SwitchWeapon(WeaponType.Chainsaw, player); 
                    inventory.addItemToInventory("Chain Saw"); Console.WriteLine("You picked up a Chain Saw"); }
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
