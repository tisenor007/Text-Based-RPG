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
        public int reward;

        public void LoadPlayer(int X, int Y)
        {
            //loads player position, character, health
            xLoc = X;
            yLoc = Y;
            Character = "@";
            health = 100;
            reward = 0;


        }
        public void GetReward(int money)
        {
            reward = reward + money;
        }
        public void Update(Map map, EnemyManager enemyManager, ItemManager itemManager, Camera camera)
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
                    else if (itemExist = itemManager.isItemAt(xLoc, yLoc - 1))
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

                    }
                    else if (enemyExist = enemyManager.isEnemyAt(xLoc - 1, yLoc))
                    {
                        enemyManager.CheckEnemies(xLoc - 1, yLoc);
                    }
                    else if (itemExist = itemManager.isItemAt(xLoc - 1, yLoc))
                    {
                        
                        itemManager.CheckItems(xLoc - 1, yLoc);
                    }
                    else
                    {
                        //xLoc = xLoc - 1;
                        camera.offsetX = camera.offsetX + 1;
                        
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
                    else if (itemExist = itemManager.isItemAt(xLoc, yLoc + 1))
                    {
                       
                        itemManager.CheckItems(xLoc, yLoc + 1);
                    }
                    
                    else
                    {
                        //yLoc = yLoc + 1;
                        camera.offsetY = camera.offsetY - 1;
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
                    else if (itemExist = itemManager.isItemAt(xLoc + 1, yLoc))
                    {
                        
                        itemManager.CheckItems(xLoc + 1, yLoc);
                    }
                    else
                    {
                        //xLoc = xLoc + 1;
                        camera.offsetX = camera.offsetX - 1;
                    }
                }
            }
        }
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
