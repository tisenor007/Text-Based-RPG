using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Text_Based_RPG
{
    class EnemyManager : Enemy
    {
       
        
        public Enemy[] enemyNum = new Enemy[9];

        public void InitEnemies()
        {
            enemyNum[0] = new Enemy();
            enemyNum[1] = new Enemy();
            enemyNum[2] = new Enemy();
            enemyNum[3] = new Enemy();
            enemyNum[4] = new Enemy();
            enemyNum[5] = new Enemy();
            enemyNum[6] = new Enemy();
            enemyNum[7] = new Enemy();
            enemyNum[8] = new Enemy();
            

        }
        public void LoadEnemies()
        {
            enemyNum[0].LoadEnemy(16, 19, 1);
            enemyNum[1].LoadEnemy(6, 3, 2);
        }
        public void UpdateandDraw(Map map, Player player)
        {
            enemyNum[0].Update(map, player);
            enemyNum[0].Draw();
            enemyNum[1].Update(map, player);
            enemyNum[1].Draw();
        }
        //collision for each direction
        public bool isEnemyUp(int x, int y)
        {
            if (x == enemyNum[0].xLoc)
            {
                if (y - 1 == enemyNum[0].yLoc)
                {
                    return true;   
                }
                else
                {
                    return false;
                }
            }
            else if (x == enemyNum[1].xLoc)
            {
                if (y - 1 == enemyNum[1].yLoc)
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
        public bool isEnemyLeft(int x, int y)
        {
            if (y == enemyNum[0].yLoc)
            {
                if (x - 1 == enemyNum[0].xLoc)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else if (y == enemyNum[1].yLoc)
            {
                if (x - 1 == enemyNum[1].xLoc)
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
        public bool isEnemyRight(int x, int y)
        {
            if (y == enemyNum[0].yLoc)
            {
                if (x + 1 == enemyNum[0].xLoc)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else if (y == enemyNum[1].yLoc)
            {
                if (x + 1 == enemyNum[1].xLoc)
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
        public bool isEnemyDown(int x, int y)
        {
            if (x == enemyNum[0].xLoc)
            {
                if (y + 1 == enemyNum[0].yLoc)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else if (x == enemyNum[1].xLoc)
            {
                if (y + 1 == enemyNum[1].yLoc)
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
