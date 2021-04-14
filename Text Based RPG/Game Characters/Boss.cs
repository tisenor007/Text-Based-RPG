using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Text_Based_RPG
{
    //self explanitory
    class Boss : Enemy
    {
        public Boss(int X, int Y)
        {
            xLoc = X;
            yLoc = Y;
            SwitchVitalStatus(VitalStatus.Alive);
            character = 'B';
            //hard to kill
            health = 300;
            shield = 0;
            name = "Boss";
            //can kill you easily
            attackDamage = 20;
        }
        //specific AI
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
                    int pos = rnd.Next(1, 6);
                    if (pos == 2) { Move(Moving.Left); }
                    if (pos == 3) { Move(Moving.Right); }
                    if (pos == 4) { Move(Moving.Down); }
                    if (pos == 5) { Move(Moving.Up); }
                }

                base.Update(map, player, camera, itemManager, enemyManager);
            }
            //I think I have said it to much already.. see other enemy classes.....
            else
            {
                SwitchVitalStatus(VitalStatus.Dead);
            }
        }
    }
}
