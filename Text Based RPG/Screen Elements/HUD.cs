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
        public void DisplayHUD(Player player, EnemyManager enemyManager, Camera camera, Inventory inventory)
        {
            //player stats
            //clear string to prevent overlapping text and values.....
            Console.ForegroundColor = ConsoleColor.White;
            Console.SetCursorPosition(0, camera.endViewY + 1);
            Console.WriteLine(clear);
            Console.Write(player.name + " health: " + player.health);
            Console.WriteLine(clear);
            Console.Write(player.name + " sheild health: " + player.shield);
            Console.WriteLine(clear);
            Console.Write(player.name + " weapon in hand: " + player.weaponInHand.itemType);
            Console.WriteLine(clear);
            Console.Write("Stolen valuables recoved: " + player.collectedValuables + "/600");
            Console.WriteLine(clear);
            Console.Write("Hit 'i' to open inventory....");
            if (inventory.inventoryIsFull == true)
            {
                Console.WriteLine(clear);
                Console.Write("YOUR INVENTORY IS FULL!");
            }
            else
            {
                //nothing
            }
            Console.WriteLine();
            
            //if an enemy is close display they're stats
            for (int i = 0; i < enemyManager.enemyCount; i++)
            {
                if ((player.xLoc <= enemyManager.enemies[i].xLoc + 5) && (player.xLoc >= enemyManager.enemies[i].xLoc - 5) && (player.yLoc <= enemyManager.enemies[i].yLoc + 5) && (player.yLoc >= enemyManager.enemies[i].yLoc - 5))
                {
                  Console.WriteLine(clear);
                  Console.Write(enemyManager.enemies[i].name + " enemy number " + i + "'s health: " + enemyManager.enemies[i].health);
                }
            }
            Console.WriteLine(clear);
            Console.WriteLine(clear);
            Console.WriteLine(clear);
            Console.WriteLine(clear);
            Console.WriteLine(clear);
            Console.WriteLine(clear);
            Console.WriteLine(clear);
            Console.WriteLine(clear);
            Console.WriteLine(clear);
            Console.WriteLine(clear);
            Console.WriteLine(clear);
            Console.WriteLine(clear);
            Console.WriteLine(clear);
            Console.WriteLine(clear);
            Console.WriteLine(clear);
            Console.WriteLine(clear);
            Console.WriteLine(clear);
            Console.WriteLine(clear);
            Console.WriteLine(clear);
            Console.WriteLine(clear);
            Console.WriteLine(clear);
            Console.WriteLine(clear);
            Console.WriteLine(clear);
            Console.WriteLine(clear);
            Console.WriteLine(clear);
            Console.WriteLine(clear);
            Console.WriteLine(clear);
            Console.WriteLine(clear);
            Console.WriteLine(clear);
            Console.WriteLine(clear);
            Console.WriteLine(clear);
            Console.WriteLine(clear);
            Console.WriteLine(clear);
            Console.WriteLine(clear);
            Console.WriteLine(clear);
            Console.WriteLine(clear);
            Console.WriteLine(clear);
            Console.WriteLine(clear);
        }
    }
}
