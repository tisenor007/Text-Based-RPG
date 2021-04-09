using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Text_Based_RPG
{
    class EnemyManager
    {
       
        private static int Enemy_Limit = 31;
        public int Cap = Enemy_Limit;
        public Enemy[] enemies = new Enemy[Enemy_Limit];

        public void InitEnemies()
        {
         
            enemies[0] = new Boss(107, 41);
            enemies[1] = new Light(38, 15);
            enemies[2] = new Light(24, 24);
            enemies[3] = new Light(17, 11);
            enemies[4] = new Light(29, 30);
            enemies[5] = new Light(74, 26);
            enemies[6] = new Light(143, 6);
            enemies[7] = new Light(17, 34);
            enemies[8] = new Light(117, 19);
            enemies[9] = new Light(75, 10);
            enemies[10] = new Light(221, 35);
            enemies[11] = new Heavy(29, 30);
            enemies[12] = new Heavy(166, 34);
            enemies[13] = new Heavy(147, 14);
            enemies[14] = new Heavy(208, 22);
            enemies[15] = new Heavy(79, 12);
            enemies[16] = new Heavy(47, 11);
            enemies[17] = new Heavy(51, 26);
            enemies[18] = new Heavy(120, 28);
            enemies[19] = new Heavy(95, 24);
            enemies[20] = new Heavy(178, 17);
            enemies[21] = new SpecializedCombat(113, 23);
            enemies[22] = new SpecializedCombat(70, 38);
            enemies[23] = new SpecializedCombat(169, 38);
            enemies[24] = new SpecializedCombat(153, 28);
            enemies[25] = new SpecializedCombat(128, 33);
            enemies[26] = new SpecializedCombat(105, 43);
            enemies[27] = new SpecializedCombat(203, 6);
            enemies[28] = new SpecializedCombat(135, 44);
            enemies[29] = new SpecializedCombat(129, 52);
            enemies[30] = new SpecializedCombat(226, 23);
        }
      
        public void UpdateEnemies(Map map, Player player, Camera camera, ItemManager itemManager, EnemyManager enemyManager)
        {
            for (int i = 0; i < Enemy_Limit; i++)
            {
                enemies[i].Update(map, player, camera, itemManager, enemyManager);
            }
               
        }
        public void DrawEnemies(Camera camera)
        {
            for (int i = 0; i < Enemy_Limit; i++)
            {
                enemies[i].Draw(camera);
            }
        }
        public void CheckEnemies(int x, int y, int playerAttackDamage)
        {
            for (int i = 0; i < Enemy_Limit; i++)
            {
                if (x == enemies[i].xLoc)
                {
                    if (y == enemies[i].yLoc)
                    {
                        enemies[i].TakeDamage(playerAttackDamage);
                    }
                }
            }
               
        }
        
        //collision
       
        public bool IsEnemyAt(int x, int y)
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
