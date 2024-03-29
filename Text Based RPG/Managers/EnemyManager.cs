﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Text_Based_RPG
{
    class EnemyManager
    {
        //enemy count.....
        public static int enemyCap = 100;
        public Enemy[] enemies = new Enemy[enemyCap];
        public int enemyCount = 0;
        
        public void InitEnemyFromWorldLoc(char[,] world, int X, int Y)
        {
            if (enemyCount > enemyCap - 1) { return; }
            else if (world[X, Y] == Global.heavyAppearance) { enemies[enemyCount] = new Heavy(X, Y); enemyCount = enemyCount + 1; }
            else if (world[X, Y] == Global.lightAppearance) { enemies[enemyCount] = new Light(X, Y); enemyCount = enemyCount + 1; }
            else if (world[X, Y] == Global.SCAppearance) { enemies[enemyCount] = new SpecializedCombat(X, Y); enemyCount = enemyCount + 1; }
            else if (world[X, Y] == Global.bossAppearance) { enemies[enemyCount] = new Boss(X, Y); enemyCount = enemyCount + 1; }
        }
        //updates each enemys
        public void UpdateEnemies(Map map, Player player, Camera camera, ItemManager itemManager, EnemyManager enemyManager)
        {
            for (int i = 0; i < enemyCount; i++)
            {
                enemies[i].Update(map, player, camera, itemManager, enemyManager);
            }
        }
        public void SetEnemyColour(char[,] renderer, int x, int y, int offsetX, int offsetY)
        {
            for (int i = 0; i < enemyCount; i++)
            {
                enemies[i].characterTile.SetTileColour(renderer, x, y, offsetX, offsetY);
            }
        }
        //draws each enemy
        public void DrawEnemies(Camera camera)
        {
            for (int i = 0; i < enemyCount; i++)
            {
                enemies[i].Draw(camera);
            }
        }
        
        //check enemy to for player to check which one its attacking....
        public void CheckEnemies(int x, int y, int playerAttackDamage)
        {
            for (int i = 0; i < enemyCount; i++)
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
            for (int i = 0; i < enemyCount; i++)
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

        public void AddHeavyEnemy(int x, int y)
        {
            if (enemyCount > enemyCap - 1) { return; }
            enemies[enemyCount] = new Heavy(x,y);
            enemyCount += 1;
        }
    }
}
