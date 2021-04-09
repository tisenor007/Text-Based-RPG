using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Text_Based_RPG
{
    class Heavy : Enemy
    {
        public Heavy(int X, int Y)
        {
            SwitchVitalStatus(VitalStatus.Alive);
           
            xLoc = X;
            yLoc = Y;
            character = 'E';
            health = 100;
            shield = 0;
            name = "Heavy";
            attackDamage = 5;
        }

        public override void Update(Map map, Player player, Camera camera, ItemManager itemManager, EnemyManager enemyManager)
        {
            if (vitalStatus == VitalStatus.Alive)
            {
                //wanted to do "base.update(etc...)" since this code is pretty much the same, but that would require one of the if statements to be just an "if" instead "else if" which caused crashes
                //ugly and the same but it works without crashes.......

                

                if (player.isPlayerAt(xLoc, yLoc - 1) == true) { player.TakeDamage(attackDamage); Console.Beep(100, 150); }
                else if (player.isPlayerAt(xLoc - 1, yLoc) == true) { player.TakeDamage(attackDamage); Console.Beep(100, 150); }
                else if (player.isPlayerAt(xLoc + 1, yLoc) == true) { player.TakeDamage(attackDamage); Console.Beep(100, 150); }
                else if (player.isPlayerAt(xLoc, yLoc + 1) == true) { player.TakeDamage(attackDamage); Console.Beep(100, 150); }

                else
                {
                    int pos = rnd.Next(1, 4);
                    if ((pos >= 1) && (pos <= 2)) { SwitchDirection(Moving.Left); }
                    else if ((pos >= 3) && (pos <= 4)) { SwitchDirection(Moving.Right); }
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
