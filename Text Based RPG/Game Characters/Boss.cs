using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Text_Based_RPG
{
    class Boss : Enemy
    {
        public Boss(int X, int Y)
        {
            SwitchVitalStatus(VitalStatus.Alive);
            xLoc = X;
            yLoc = Y;
            character = 'B';
            health = 300;
            shield = 0;
            name = "Boss";
            attackDamage = 20;
        }

        public override void Update(Map map, Player player, Camera camera, ItemManager itemManager, EnemyManager enemyManager)
        {
            if (vitalStatus == VitalStatus.Alive)
            {
    
                if (player.isPlayerAt(xLoc, yLoc - 1) == true) { player.TakeDamage(attackDamage); Console.Beep(400, 100); }
                else if (player.isPlayerAt(xLoc - 1, yLoc) == true) { player.TakeDamage(attackDamage); Console.Beep(400, 100); }
                else if (player.isPlayerAt(xLoc + 1, yLoc) == true) { player.TakeDamage(attackDamage); Console.Beep(400, 100); }
                else if (player.isPlayerAt(xLoc, yLoc + 1) == true) { player.TakeDamage(attackDamage); Console.Beep(50, 500); }


                //else if (player.isPlayerNear(xLoc, yLoc - 5) == true) { SwitchDirection(Moving.Up, normal); }
                //else if (player.isPlayerNear(xLoc - 5, yLoc) == true) { SwitchDirection(Moving.Left, normal); }
                //else if (player.isPlayerNear(xLoc + 5, yLoc) == true) { SwitchDirection(Moving.Right, normal); }
                //else if (player.isPlayerNear(xLoc, yLoc + 5) == true) { SwitchDirection(Moving.Down, normal); }


                else
                {
                    int pos = rnd.Next(1, 5);
                    if (pos == 1) { SwitchDirection(Moving.Left); }
                    else if (pos == 2) { SwitchDirection(Moving.Right); }
                    else if (pos == 3) { SwitchDirection(Moving.Down); }
                    else if (pos == 3) { SwitchDirection(Moving.Up); }
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
