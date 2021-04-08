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
            Console.WriteLine("Welcome to the Beta");
            Console.WriteLine();
            Console.Write("Hit any button to continue.....");
            Console.ReadKey(true);

            Console.SetCursorPosition(0, 2);
            Console.Write("                                       ");

            Console.Beep(2200, 750);
            //intantiation and declaration of objects.....
            Map map = new Map();
            //polymorphism
            Player player = new Player(14, 3);
            EnemyManager enemyManager = new EnemyManager();
            ItemManager itemManager = new ItemManager();
            HUD Hud = new HUD();
            Camera camera = new Camera(map);
            
            enemyManager.InitEnemies();
            itemManager.InitItems();
            //camera.SetDisplay(map, player);

            //loading all the options, set position, type etc
            //camera.loadCamera(map, player);
            
            
           
            
            itemManager.LoadItems();


            //gameloop
            while (true)
            {
                //display and update all objects
                //passes classes throught methods to get access to specific class data..........
                
                itemManager.UpdateItems(map, player);
                enemyManager.UpdateEnemies(map, player, camera);
                player.Update(map, enemyManager, itemManager, camera);
                camera.Update(map, player);
                
                itemManager.DrawItems(camera);
                enemyManager.DrawEnemies(camera);
                player.Draw(camera);
                Hud.DisplayHUD(player, enemyManager, camera);
                camera.Draw();
               
                
               
               


            }

        }
       

    }
}
