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

        public void LoadPlayer(int X, int Y)
        {
            //loads player position, character, health
            xLoc = X;
            yLoc = Y;
            Character = "@";
            health = 100;


        }
        public void Update(Map map, EnemyManager enemyManager)
        {
            //makes cursor not visable 
            Console.CursorVisible = false;
            //sets position and draws character
            Console.SetCursorPosition(xLoc, yLoc);
            Console.WriteLine(Character);
            ConsoleKeyInfo keyPressed = Console.ReadKey();
            if (health <= 0)
            {
                //if player dies......
                health = 0;
                Character = "X";
            }
            else
            {

                
                if (keyPressed.Key == ConsoleKey.W)
                {
                    //you are able to move unless there is a wall

                    //Console.WriteLine(enemyManager.isEnemyAt(xLoc, yLoc));
                    if (wallExist = map.IsWallAt(xLoc, yLoc - 1))
                    {
                        //do nothing 
                    }
                    else if (enemyExist = enemyManager.isEnemyAt(xLoc, yLoc - 1))
                    {
                        enemyManager.CheckEnemies(xLoc, yLoc - 1);
                       
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

                    }
                    else if (enemyExist = enemyManager.isEnemyAt(xLoc - 1, yLoc))
                    {
                        enemyManager.CheckEnemies(xLoc - 1, yLoc);
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
                        
                    }
                    else if (enemyExist = enemyManager.isEnemyAt(xLoc, yLoc + 1))
                    {
                        enemyManager.CheckEnemies(xLoc, yLoc + 1);
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

                    }
                    else if (enemyExist = enemyManager.isEnemyAt(xLoc + 1, yLoc))
                    {
                        enemyManager.CheckEnemies(xLoc + 1, yLoc);
                    }
                    else
                    {
                        xLoc = xLoc + 1;
                    }
                }
            }
        }
        public bool IsPlayerUp(int x, int y)
        {
            if (x == xLoc)
            {
                if (y - 1 == yLoc)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }
        public bool IsPlayerLeft(int x, int y)
        {
            if (y == yLoc)
            {
                if (x - 1 == xLoc)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }
        public bool IsPlayerRight(int x, int y)
        {
            if (y == yLoc)
            {
                if (x + 1 == xLoc)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }
        public bool IsPlayerDown(int x, int y)
        {
            if (x == xLoc)
            {
                if (y + 1 == yLoc)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }



    }
}
