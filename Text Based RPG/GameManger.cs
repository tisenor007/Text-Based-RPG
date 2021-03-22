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
            Console.WriteLine("Welcome to the Alpha");
            Console.WriteLine();
            Console.Write("Hit any button to continue.....");
            Console.ReadKey(true);

            //intantiation and declaration of objects.....
            Map map = new Map();
            Player player = new Player();
            EnemyManager enemyManager = new EnemyManager();
            enemyManager.InitEnemies();


            //loading all the options, set position, type etc
            map.Load();
            player.LoadPlayer(20, 19);
            enemyManager.LoadEnemies();


            //gameloop
            while (true)
            {
                //display and update all objects
                //passes classes throught methods to get access to specific class data..........


                map.Update();
                map.Draw();
                Console.WriteLine();
                Console.Write(player.health);
                
                enemyManager.UpdateandDraw(map, player);
                
                player.Update(map, enemyManager.enemyNum, enemyManager);
                player.Draw();
                



            }

        }

    }
}
