using System;
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
            MainMenu mainMenu = new MainMenu();
            mainMenu.StartMainMenu();
            Clear();
            mainMenu.ShowInfoScreen();

            //intantiation and declaration of objects.....
            Map map = new Map();
            //polymorphism
            GameOver gameOver = new GameOver();
            Player player = new Player(20, 17);
            EnemyManager enemyManager = new EnemyManager();
            ItemManager itemManager = new ItemManager();
            HUD Hud = new HUD();
            Camera camera = new Camera(map);
            
            enemyManager.InitEnemies();
            itemManager.InitItems();
            
            //gameloop
            while (true)
            {
                //display and update all objects
                //passes classes throught methods to get access to specific class data..........
               
                itemManager.UpdateItems(map, player);
                enemyManager.UpdateEnemies(map, player, camera, itemManager, enemyManager);
                player.Update(map, enemyManager, itemManager, gameOver);
                camera.Update(map, player);

                Clear();
                itemManager.DrawItems(camera);
                enemyManager.DrawEnemies(camera);
                player.Draw(camera);
                Hud.DisplayHUD(player, enemyManager, camera);
                camera.Draw();
                
                if (gameOver.gameOverWin == true){break;}
                if (gameOver.gameOverLoss == true){break;}
            }
            if (gameOver.gameOverWin == true){Clear(); gameOver.GameOverWinScreen();}
            if (gameOver.gameOverLoss == true){Clear(); gameOver.GameOverLossScreen();}
        }
        private void Clear()
        {
            Console.SetCursorPosition(0, 0);
            string clear = "                                                                                                                                                                        ";
            Console.Write(clear);
            Console.Write(clear);
            Console.Write(clear);
            Console.Write(clear);
            Console.Write(clear);
            Console.Write(clear);
            Console.Write(clear);
            Console.Write(clear);
            Console.Write(clear);
            Console.Write(clear);
            Console.Write(clear);
            Console.Write(clear);
            Console.Write(clear);
            Console.Write(clear);
            Console.Write(clear);
            Console.Write(clear);
            Console.Write(clear);
            Console.Write(clear);
            Console.Write(clear);
            Console.Write(clear);
            Console.Write(clear);
            Console.Write(clear);
            Console.Write(clear);
            Console.Write(clear);
            Console.Write(clear);
            Console.Write(clear);
            Console.Write(clear);
            Console.Write(clear);
            Console.Write(clear);
            Console.Write(clear);
            Console.Write(clear);
            Console.Write(clear);
            Console.Write(clear);
            Console.Write(clear);
            Console.Write(clear);
            Console.Write(clear);
            Console.Write(clear);
            Console.Write(clear);
            Console.Write(clear);
            Console.Write(clear);
            Console.Write(clear);
            Console.Write(clear);
            Console.Write(clear);
            Console.Write(clear);
            Console.Write(clear);
            Console.Write(clear);
            Console.Write(clear);
            Console.Write(clear);
            Console.Write(clear);
            Console.Write(clear);
            Console.Write(clear);
            Console.Write(clear);
            Console.Write(clear);
        }
       

    }
}
