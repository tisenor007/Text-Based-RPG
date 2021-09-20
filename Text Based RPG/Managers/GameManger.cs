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
            //main title
            MainMenu mainMenu = new MainMenu();
            mainMenu.StartMainMenu();
            Console.Clear();
            mainMenu.ShowInfoScreen();
            Console.Clear();

            //intantiation and declaration of objects.....

            Map map = new Map();
            World world = new World();
            GameOver gameOver = new GameOver();
            Player player = new Player();
            EnemyManager enemyManager = new EnemyManager();
            ItemManager itemManager = new ItemManager();
            HUD Hud = new HUD();
            Camera camera = new Camera(map);
            Inventory inventory = new Inventory();
            ShopManager shopManager = new ShopManager(itemManager, player, camera, inventory, enemyManager);
            world.InitEntities(enemyManager, itemManager, player, inventory);
            itemManager.SetShopManager(shopManager);

            //gameloop
            Hud.DisplayHUD(player, enemyManager, camera, inventory);
            camera.Draw(player, enemyManager, map, itemManager);
            while (true)
            {
                
                //draws + other game elements(for polish)
                shopManager.Update();
                itemManager.UpdateItems(map, player, inventory, camera);
                inventory.Update(player, itemManager);
                player.Update(map, enemyManager, itemManager, gameOver, inventory, shopManager);
                camera.Update(map, player);
                enemyManager.UpdateEnemies(map, player, camera, itemManager, enemyManager);

                itemManager.DrawItems(camera);
                Hud.DisplayHUD(player, enemyManager, camera, inventory);
                enemyManager.DrawEnemies(camera);
                shopManager.Draw();
                player.Draw(camera);
                camera.Draw(player, enemyManager, map, itemManager);


                //updates
                //world.Update(enemyManager, itemManager);
                

                //if game is over in anyway break out of game loop.....

                if (gameOver.gameOverWin == true){break;}
                if (gameOver.gameOverLoss == true){break;}
            }
            if (gameOver.gameOverWin == true){Console.Clear(); gameOver.GameOverWinScreen();}
            if (gameOver.gameOverLoss == true){Console.Clear(); gameOver.GameOverLossScreen();}
        }
    }
}
