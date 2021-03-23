using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Text_Based_RPG
{
    class EnemyManager : Enemy
    {
       
        private static int Enemy_Limit = 10;
        public Enemy[] enemies = new Enemy[Enemy_Limit];

        public void InitEnemies()
        {
            for (int i = 0; i < Enemy_Limit; i++)
            {
                enemies[i] = new Enemy();
            }
            //enemies[0] = new Enemy();
            //enemies[1] = new Enemy();
            //enemies[2] = new Enemy();
            //enemies[3] = new Enemy();
            //enemies[4] = new Enemy();
            //enemies[5] = new Enemy();
            //enemies[6] = new Enemy();
            //enemies[7] = new Enemy();
            //enemies[8] = new Enemy();
            //enemies[9] = new Enemy();


        }
        public void LoadEnemies()
        {
            enemies[0].LoadEnemy(16, 19, 1);
            enemies[1].LoadEnemy(6, 3, 2);
            enemies[2].LoadEnemy(90, 3, 3);
            enemies[3].LoadEnemy(16, 3, 1);
        }
        public void UpdateandDraw(Map map, Player player)
        {
            //enemyNum[0].Update(map, player);
            //enemyNum[0].Draw();
            //enemyNum[1].Update(map, player);
            //enemyNum[1].Draw();
            //enemyNum[2].Update(map, player);
            //enemyNum[2].Draw();
            //enemyNum[3].Update(map, player);
            //enemyNum[3].Draw();
            enemies[0].Update(map, player);
            enemies[1].Update(map, player);
            enemies[2].Update(map, player);
            enemies[0].Draw();
            enemies[1].Draw();
            enemies[2].Draw();
        }
        public void CheckEnemies(int x, int y)
        {
            if (x == enemies[0].xLoc)
            {
                if (y == enemies[0].yLoc)
                {
                    enemies[0].TakeDamage(20);
                }
            }
            else if (x == enemies[1].xLoc)
            {
                if (y == enemies[1].yLoc)
                {
                    enemies[1].TakeDamage(20);
                }
            }
            else if (x == enemies[2].xLoc)
            {
                if (y == enemies[2].yLoc)
                {
                    enemies[2].TakeDamage(20);
                }
            }
            else if (x == enemies[3].xLoc)
            {
                if (y == enemies[3].yLoc)
                {
                    enemies[3].TakeDamage(20);
                }
            }
            else
            {
                //nothing
            }
        }
        public void testhealth()
        {
            Console.WriteLine("Enemy 1: " + enemies[0].health);
            Console.WriteLine("Enemy 2: " + enemies[1].health);
            Console.WriteLine("Enemy 3: " + enemies[2].health);
            Console.WriteLine("Enemy 4: " + enemies[3].health);
        }
        //collision for each direction
       
        public bool isEnemyAt(int x, int y)
        {
            for (int i = 0; i < Enemy_Limit; i++)
            {
                if (x == enemies[i].xLoc)
                {
                    if (y == enemies[i].yLoc)
                    {
                        return true;
                    }
                }
            }
            return false;
        }
       


    }
}
