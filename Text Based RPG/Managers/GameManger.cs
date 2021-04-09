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
            //main title
            MainMenu mainMenu = new MainMenu();
            mainMenu.StartMainMenu();
            Console.Clear();
            mainMenu.ShowInfoScreen();
            Console.Clear();
            //intantiation and declaration of objects.....
            Map map = new Map();
            GameOver gameOver = new GameOver();
            Player player = new Player(20, 17);
            EnemyManager enemyManager = new EnemyManager();
            ItemManager itemManager = new ItemManager();
            HUD Hud = new HUD();
            Camera camera = new Camera();
            enemyManager.InitEnemies();
            itemManager.InitItems();
            
            //gameloop
            while (true)
            {
                //updates
                itemManager.UpdateItems(map, player);
                enemyManager.UpdateEnemies(map, player, camera, itemManager, enemyManager);
                player.Update(map, enemyManager, itemManager, gameOver);
                camera.Update(map, player);

                //draws + other game elements(for polish)
                
                itemManager.DrawItems(camera);
                enemyManager.DrawEnemies(camera);
                player.Draw(camera);
                Hud.DisplayHUD(player, enemyManager, camera);
                camera.Draw();
                
                //if game is over in anyway break out of game loop.....
                if (gameOver.gameOverWin == true){break;}
                if (gameOver.gameOverLoss == true){break;}
            }
            if (gameOver.gameOverWin == true){Console.Clear(); gameOver.GameOverWinScreen();}
            if (gameOver.gameOverLoss == true){Console.Clear(); gameOver.GameOverLossScreen();}
        }
    }
}
