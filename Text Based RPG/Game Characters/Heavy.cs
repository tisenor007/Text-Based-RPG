using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Text_Based_RPG
{
    //idea behind heavy is that it is a beefy enemy type with alot of health and decent damage to player...
    class Heavy : Enemy
    {
        //coordinates passed in when constructing to know where to spawn
        public Heavy(int X, int Y)
        {
            xLoc = X;
            yLoc = Y;
            //Heavy properties, vary based off enemy types
            SwitchVitalStatus(VitalStatus.Alive);
            characterTile.tileCharacter = 'E';
            characterTile.tileColour = ConsoleColor.Red;
            health = 100;
            shield = 0;
            name = "Heavy";
            attackDamage = 5;
        }
        //update method with specific enemy AI behavior, anything else is taken from the main enemy class
        public override void Update(Map map, Player player, Camera camera, ItemManager itemManager, EnemyManager enemyManager)
        {
            //if it is alive it moves and attacks.....
            if (vitalStatus == VitalStatus.Alive)
            {
                //actually attacks player
                if (player.isPlayerAt(xLoc, yLoc - 1) == true) { player.TakeDamage(attackDamage); Console.Beep(100, 150); }
                else if (player.isPlayerAt(xLoc - 1, yLoc) == true) { player.TakeDamage(attackDamage); Console.Beep(100, 150); }
                else if (player.isPlayerAt(xLoc + 1, yLoc) == true) { player.TakeDamage(attackDamage); Console.Beep(100, 150); }
                else if (player.isPlayerAt(xLoc, yLoc + 1) == true) { player.TakeDamage(attackDamage); Console.Beep(100, 150); }
                else
                {
                    int pos = rnd.Next(1, 4);
                    if (pos == 2) { Move(Moving.Left); }
                    if (pos == 3) { Move(Moving.Right); }
                }
                base.Update(map, player, camera, itemManager, enemyManager);
            }
            //if its not alive its dead.......
            else
            {
                SwitchVitalStatus(VitalStatus.Dead);
                if (!gaveGold)
                {
                    player.GainMoney(goldAmountToGive);
                    gaveGold = true;
                }
            }
        }
    }
}
