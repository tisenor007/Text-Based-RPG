using System;

namespace Text_Based_RPG
{
    class GameManager 
    {
        public void RunGame()
        {
            Global global = new Global();
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
            Inventory inventory = new Inventory(itemManager);
            ShopManager shopManager = new ShopManager();
            world.InitEntities(enemyManager, itemManager, player, camera, inventory, shopManager);
            itemManager.SetShopManager(shopManager);

            //gameloop
            Hud.DisplayHUD(player, enemyManager, camera, inventory, itemManager);
            camera.Draw(player, enemyManager, map, itemManager, shopManager);
            while (true)
            {

                // updates
                itemManager.UpdateItems(map, player, inventory, camera);
                player.Update(map, enemyManager, itemManager, gameOver, inventory, shopManager);
                shopManager.Update();
                inventory.Update(player, itemManager);
                camera.Update(map, player);
                enemyManager.UpdateEnemies(map, player, camera, itemManager, enemyManager);

                //draws + other game elements(for polish)
                itemManager.DrawItems(camera);
                Hud.DisplayHUD(player, enemyManager, camera, inventory, itemManager);
                enemyManager.DrawEnemies(camera);
                shopManager.Draw();
                player.Draw(camera);
                camera.Draw(player, enemyManager, map, itemManager, shopManager);               

                //if game is over in anyway break out of game loop.....

                if (gameOver.gameOverWin == true){break;}
                if (gameOver.gameOverLoss == true){break;}
            }
            if (gameOver.gameOverWin == true){Console.Clear(); gameOver.GameOverWinScreen();}
            if (gameOver.gameOverLoss == true){Console.Clear(); gameOver.GameOverLossScreen();}
        }
    }
}
