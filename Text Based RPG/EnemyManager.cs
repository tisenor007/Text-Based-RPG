using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Text_Based_RPG
{
    class EnemyManager
    {
       
        private static int Enemy_Limit = 2;
        public int Cap = Enemy_Limit;
        public Enemy[] enemies = new Enemy[Enemy_Limit];

        public void InitEnemies()
        {
           
            //for (int i = 0; i < Enemy_Limit; i++)
            //{
            enemies[0] = new Heavy(6, 1);
            enemies[1] = new SpecializedCombat(28, 1);
            //}
        }
        //public void LoadEnemies()
        //{
            //enemies[0].LoadEnemy(6, 1, 3);
            //enemies[1].LoadEnemy(28, 1, 3);
            //enemies[2].LoadEnemy(6, 5, 3);
            //enemies[3].LoadEnemy(28, 5, 1);
            //enemies[4].LoadEnemy(88, 1, 2);
            //enemies[5].LoadEnemy(100, 4, 2);
            //enemies[6].LoadEnemy(29, 17, 1);
            //enemies[7].LoadEnemy(13, 18, 1);
            //enemies[8].LoadEnemy(13, 20, 1);
            //enemies[9].LoadEnemy(52, 10, 2);
            //enemies[10].LoadEnemy(71, 16, 1);
            //enemies[11].LoadEnemy(104, 16, 1);
            //enemies[12].LoadEnemy(69, 22, 3);
            //enemies[13].LoadEnemy(104, 22, 2);
        //}
        public void UpdateEnemies(Map map, Player player, Camera camera)
        {
            for (int i = 0; i < Enemy_Limit; i++)
            {
                enemies[i].Update(map, player, camera);
            }
               
        }
        public void DrawEnemies(Camera camera)
        {
            for (int i = 0; i < Enemy_Limit; i++)
            {
                enemies[i].Draw(camera);
            }
        }
        public void CheckEnemies(int x, int y)
        {
            for (int i = 0; i < Enemy_Limit; i++)
            {
                if (x == enemies[i].xLoc)
                {
                    if (y == enemies[i].yLoc)
                    {
                        enemies[i].TakeDamage(20);
                    }
                }
            }
               
        }
        public void testhealth()
        {
            for (int i = 0; i < Enemy_Limit; i++)
            {
                Console.WriteLine("Enemy" + i +" : " + enemies[i].health);
            }
        }
        //collision
       
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
