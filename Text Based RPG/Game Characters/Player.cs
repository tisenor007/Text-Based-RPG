using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Text_Based_RPG
{
    class Player : GameCharacter
    {
        private bool wallExist;
        private bool enemyExist;
        private bool itemExist;
        public int collectedValuables;
        public string weaponInHand;

        public Player()
        {
            //loads player position, character, health
            SwitchVitalStatus(VitalStatus.Alive);
            character = '@';
            health = 100;
            shield = 0;
            collectedValuables = 0;
            name = "Player";
            weaponInHand = "Fist";
            attackDamage = 5;
        }
        //specific to the player...
        public void CollectValuable(int money)
        {
            collectedValuables = collectedValuables + money;
        }
        public void CheckPlayerWorldLoc(char[,] world, int X, int Y)
        {
            if (world[X, Y] == '@') { xLoc = X; yLoc = Y; }
        }
        public void Update(Map map, EnemyManager enemyManager, ItemManager itemManager, GameOver gameOver)
        {
            Console.CursorVisible = false;
            ConsoleKeyInfo keyPressed = Console.ReadKey(true);
            
            if (vitalStatus == VitalStatus.Alive)
            {
                if (keyPressed.Key == ConsoleKey.W)
                {
                    //collision
                    if (wallExist = map.IsWallAt(xLoc, yLoc - 1))
                    {
                        //do nothing 
                    }
                    else if (enemyExist = enemyManager.IsEnemyAt(xLoc, yLoc - 1))
                    {
                        enemyManager.CheckEnemies(xLoc, yLoc - 1, attackDamage);
                    }
                    else if (itemExist = itemManager.IsItemAt(xLoc, yLoc - 1))
                    {
                        itemManager.CheckItems(xLoc, yLoc - 1);
                    }
                    else
                    {
                        yLoc = yLoc - 1;
                    }
                }
                if (keyPressed.Key == ConsoleKey.A)
                {
                    if (wallExist = map.IsWallAt(xLoc - 1, yLoc))
                    {
                        //do nothing
                    }
                    else if (enemyExist = enemyManager.IsEnemyAt(xLoc - 1, yLoc))
                    {
                        enemyManager.CheckEnemies(xLoc - 1, yLoc, attackDamage);
                    }
                    else if (itemExist = itemManager.IsItemAt(xLoc - 1, yLoc))
                    {
                        itemManager.CheckItems(xLoc - 1, yLoc);
                    }
                    else
                    {
                        xLoc = xLoc - 1;
                    }
                }
                if (keyPressed.Key == ConsoleKey.S)
                {
                    if (wallExist = map.IsWallAt(xLoc, yLoc + 1))
                    {
                        //do nothing
                    }
                    else if (enemyExist = enemyManager.IsEnemyAt(xLoc, yLoc + 1))
                    {
                        enemyManager.CheckEnemies(xLoc, yLoc + 1, attackDamage);
                    }
                    else if (itemExist = itemManager.IsItemAt(xLoc, yLoc + 1))
                    {
                        itemManager.CheckItems(xLoc, yLoc + 1);
                    }  
                    else
                    {
                        yLoc = yLoc + 1;
                    }
                }
                if (keyPressed.Key == ConsoleKey.D)
                {
                    if (wallExist = map.IsWallAt(xLoc + 1, yLoc))
                    {
                        //do nothing
                    }
                    else if (enemyExist = enemyManager.IsEnemyAt(xLoc + 1, yLoc))
                    {
                        enemyManager.CheckEnemies(xLoc + 1, yLoc, attackDamage);
                    }
                    else if (itemExist = itemManager.IsItemAt(xLoc + 1, yLoc))
                    {
                        itemManager.CheckItems(xLoc + 1, yLoc);
                    }
                    else
                    {
                        xLoc = xLoc + 1;
                    }
                }
                //determines win
                if (collectedValuables >= 600)
                {
                    gameOver.gameOverWin = true;
                }
            }
            else
            {
                SwitchVitalStatus(VitalStatus.Dead);
            }
            //determines loss...
            if (vitalStatus == VitalStatus.Dead)
            {
                gameOver.gameOverLoss = true;
            }
        }
        //for others to detect collision with player
        public bool isPlayerAt(int x, int y)
        {
          
            if (x == xLoc)
            {
                if (y == yLoc)
                {
                    return true;
                }
            }
            
            return false;
        }
    }
}
