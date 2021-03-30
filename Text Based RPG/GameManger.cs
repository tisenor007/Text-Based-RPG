﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Text_Based_RPG
{
    class GameManager 
    {
        public void RunGame()
        {
            //kind of a main title screen
            Console.WriteLine("Welcome to the Beta");
            Console.WriteLine();
            Console.Write("Hit any button to continue.....");
            Console.ReadKey(true);

            //intantiation and declaration of objects.....
            Map map = new Map();
            Player player = new Player();
            EnemyManager enemyManager = new EnemyManager();
            ItemManager itemManager = new ItemManager();
            HUD Hud = new HUD();
            Camera camera = new Camera();
            
            enemyManager.InitEnemies();
            itemManager.InitItems();
            //camera.SetDisplay(map, player);

            //loading all the options, set position, type etc
            //camera.loadCamera(map, player);
            
            map.Load(camera);
            player.LoadPlayer(14, 3);
            enemyManager.LoadEnemies();
            itemManager.LoadItems();


            //gameloop
            while (true)
            {
                //display and update all objects
                //passes classes throught methods to get access to specific class data..........
               
                
                itemManager.UpdateItems(map, player);
                enemyManager.UpdateEnemies(map, player);
                player.Update(map, enemyManager, itemManager, camera);
                map.Update(camera);
                map.Draw(camera);
                itemManager.DrawItems();
                enemyManager.DrawEnemies();
                player.Draw();
                Hud.DisplayHUD(player, enemyManager);

               
               
                
               
                

               
                
                
                



            }

        }
       

    }
}
