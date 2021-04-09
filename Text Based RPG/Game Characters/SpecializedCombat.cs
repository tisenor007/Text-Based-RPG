using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Text_Based_RPG
{
    class SpecializedCombat : Enemy
    {
        public SpecializedCombat(int X, int Y)
        {
            SwitchVitalStatus(VitalStatus.Alive);
            xLoc = X;
            yLoc = Y;
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
               
                if (player.isPlayerAt(xLoc, yLoc - 1) == true) { player.TakeDamage(attackDamage); Console.Beep(400, 100); }
                else if (player.isPlayerAt(xLoc - 1, yLoc) == true) { player.TakeDamage(attackDamage); Console.Beep(400, 100); }
                else if (player.isPlayerAt(xLoc + 1, yLoc) == true) { player.TakeDamage(attackDamage); Console.Beep(400, 100); }
                else if (player.isPlayerAt(xLoc, yLoc + 1) == true) { player.TakeDamage(attackDamage); Console.Beep(400, 100); }


                //else if (player.isPlayerNear(xLoc, yLoc - 10) == true) { SwitchDirection(Moving.Up, fast); }
                //else if (player.isPlayerNear(xLoc - 10, yLoc) == true) { SwitchDirection(Moving.Left, fast); }
                //else if (player.isPlayerNear(xLoc + 10, yLoc) == true) { SwitchDirection(Moving.Right, fast); }
                //else if (player.isPlayerNear(xLoc, yLoc + 10) == true) { SwitchDirection(Moving.Down, fast); }

                else
                {
                    int pos = rnd.Next(1, 8);
                    if ((pos >= 1) && (pos <= 2)) { SwitchDirection(Moving.Up); }
                    else if ((pos >= 3) && (pos <= 4)) { SwitchDirection(Moving.Down); }
                    else if ((pos >= 5) && (pos <= 6)) { SwitchDirection(Moving.Up); }
                    else if ((pos >= 7) && (pos <= 8)) { SwitchDirection(Moving.Down); }
                }

                base.Update(map, player, camera, itemManager, enemyManager);
            }
            else
            {
                SwitchVitalStatus(VitalStatus.Dead);
            }


        }
    }
}
