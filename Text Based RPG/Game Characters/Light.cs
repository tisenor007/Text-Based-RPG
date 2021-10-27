using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Text_Based_RPG
{
    //idea behind light is that it has low health and does little damage....
    class Light : Enemy
    {
        public Light(int X, int Y)
        {
            xLoc = X;
            yLoc = Y;
            //light properties
            SwitchVitalStatus(VitalStatus.Alive);
            characterTile.tileCharacter = Global.lightAppearance;
            characterTile.tileColour = Global.lightColour;
            health = Global.lightHealth;
            healthCap = Global.lightHealth;
            shield = Global.lightShield;
            shieldCap = Global.lightShield;
            name = Global.lightName;
            attackDamage = Global.lightAttackDamage;
        }

        public override void Update(Map map, Player player, Camera camera, ItemManager itemManager, EnemyManager enemyManager)
        {
            //specific AI
            if (vitalStatus == VitalStatus.Alive)
            {
                if (player.isPlayerAt(xLoc, yLoc - 1) == true) { player.TakeDamage(attackDamage); Console.Beep(700, 100); }
                else if (player.isPlayerAt(xLoc - 1, yLoc) == true) { player.TakeDamage(attackDamage); Console.Beep(700, 100); }
                else if (player.isPlayerAt(xLoc + 1, yLoc) == true) { player.TakeDamage(attackDamage); Console.Beep(700, 100); }
                else if (player.isPlayerAt(xLoc, yLoc + 1) == true) { player.TakeDamage(attackDamage); Console.Beep(700, 100); }
                else
                {
                    int pos = rnd.Next(1, 8);
                    if (pos == 2) { Move(Moving.Left); }
                    if ((pos >= 3) && (pos <= 4)) { Move(Moving.Right); }
                    if ((pos >= 5) && (pos <= 6)) { Move(Moving.Up); }
                    if (pos == 7) { Move(Moving.Down); }
                }

                base.Update(map, player, camera, itemManager, enemyManager);
            }
            //"if its not alive its dead"
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
