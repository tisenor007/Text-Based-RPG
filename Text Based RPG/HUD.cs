using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Text_Based_RPG
{
    class HUD
    {

        private string clear = "                                                                                                     ";
        public void DisplayHUD(Player player, EnemyManager enemyManager)
        {
            Console.SetCursorPosition(0, 27);
            Console.WriteLine(clear);
            Console.Write("Player health: " + player.health);
            Console.WriteLine(clear);
            Console.WriteLine("Current Reward / Money: " + player.reward);
            
            for (int i = 0; i < enemyManager.Cap; i++)
            {
                if ((player.xLoc <= enemyManager.enemies[i].xLoc + 5) && (player.xLoc >= enemyManager.enemies[i].xLoc - 5) && (player.yLoc <= enemyManager.enemies[i].yLoc + 5) && (player.yLoc >= enemyManager.enemies[i].yLoc - 5))
                {
                  Console.WriteLine(clear);
                  Console.Write("Enemy " + i + " health : " + enemyManager.enemies[i].health);
                  Console.WriteLine(clear);
                }
                
            }
        }
        
    }
}
