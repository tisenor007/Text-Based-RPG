using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Text_Based_RPG
{
    //idea behind specialized combat enemy is that it does more damage than the heavy but has less health, making a special trained force
    class SpecializedCombat : Enemy
    {
        //coords in construction
        public SpecializedCombat(int X, int Y)
        {
            xLoc = X;
            yLoc = Y;
            //special properties
            SwitchVitalStatus(VitalStatus.Alive);
            character = '3';
            health = 50;
            shield = 0;
            name = "Special";
            attackDamage = 10;
        }

        public override void Update(Map map, Player player, Camera camera, ItemManager itemManager, EnemyManager enemyManager)
        {
            if (vitalStatus == VitalStatus.Alive)
            {
                //attacks player differently and specific AI
                if (player.isPlayerAt(xLoc, yLoc - 1) == true) { player.TakeDamage(attackDamage); Console.Beep(400, 100); }
                else if (player.isPlayerAt(xLoc - 1, yLoc) == true) { player.TakeDamage(attackDamage); Console.Beep(400, 100); }
                else if (player.isPlayerAt(xLoc + 1, yLoc) == true) { player.TakeDamage(attackDamage); Console.Beep(400, 100); }
                else if (player.isPlayerAt(xLoc, yLoc + 1) == true) { player.TakeDamage(attackDamage); Console.Beep(400, 100); }

                //wanted to implement enemy following player but didn't figure it out
                //else if (player.isPlayerNear(xLoc, yLoc - 10) == true) { SwitchDirection(Moving.Up, fast); }
                //else if (player.isPlayerNear(xLoc - 10, yLoc) == true) { SwitchDirection(Moving.Left, fast); }
                //else if (player.isPlayerNear(xLoc + 10, yLoc) == true) { SwitchDirection(Moving.Right, fast); }
                //else if (player.isPlayerNear(xLoc, yLoc + 10) == true) { SwitchDirection(Moving.Down, fast); }

                else
                {
                    int pos = rnd.Next(1, 8);
                    if (pos == 2) { Move(Moving.Up); }
                    if ((pos >= 3) && (pos <= 4)) { Move(Moving.Down); }
                    if ((pos >= 5) && (pos <= 6)) { Move(Moving.Up); }
                    if (pos == 7) { Move(Moving.Down); }
                }
                //normal behavior
                base.Update(map, player, camera, itemManager, enemyManager);
            }
            //if its not alive its dead.....
            else
            {
                SwitchVitalStatus(VitalStatus.Dead);
            }


        }
    }
}
