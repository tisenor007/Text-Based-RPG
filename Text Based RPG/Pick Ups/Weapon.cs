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
            Fist,
            BaseballBat,
            Knife,
            Machete,
            Chainsaw
        }
        public WeaponType weapon;
        //int to determine what weapon will be picked up
        public int weaponBeingPickedUp;
        public Weapon(int X, int Y, int weaponPickUp)
        {
            weaponBeingPickedUp = weaponPickUp;
            pickedUp = false;
            xLoc = X;
            yLoc = Y;
            icon = 'W';
        }
        public override void Update(Map map, Player player, Inventory inventory)
        {
            if (pickedUp == true)
            {
                icon = ' ';
                xLoc = 0;
                yLoc = 0;
                if (weaponBeingPickedUp <= 1) { SwitchWeapon(WeaponType.Fist, player); Console.WriteLine("You picked up " + player.weaponInHand); }
                if (weaponBeingPickedUp == 2) { SwitchWeapon(WeaponType.BaseballBat, player); Console.WriteLine("You picked up a " + player.weaponInHand); }
                if (weaponBeingPickedUp == 3) { SwitchWeapon(WeaponType.Knife, player); Console.WriteLine("You picked up a " + player.weaponInHand); }
                if (weaponBeingPickedUp == 4) { SwitchWeapon(WeaponType.Machete, player); Console.WriteLine("You picked up a " + player.weaponInHand); }
                if (weaponBeingPickedUp >= 5) { SwitchWeapon(WeaponType.Chainsaw, player); Console.WriteLine("You picked up a " + player.weaponInHand); }
                pickedUp = false;
            }
        }
        public void SwitchWeapon(WeaponType newWeapon, Player player)
        {
            //sets what damage the weapons do and what they will be displayed as.......
            weapon = newWeapon;
            switch (weapon)
            {
                case WeaponType.Fist:
                    player.weaponInHand = "Fist";
                    player.attackDamage = 5;
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
