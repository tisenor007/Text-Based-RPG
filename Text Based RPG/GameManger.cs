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
            Heavy heavy = new Heavy();
            Special special = new Special();
            Light light = new Light();
            Item item = new Item();

            //loading all the options, set position, type etc
            map.LoadMap();
            player.LoadPlayer(52, 10);
            heavy.LoadHeavy(86, 16);
            special.LoadSpecial(9, 2);
            light.LoadLight(86, 4);
            item.LoadItem(16, 18, 3);


            //gameloop
            while (true)
            {
                //display and update all objects
                //passes classes throught methods to get access to specific class data..........
                map.DisplayMap();
                player.HUD(item);
                heavy.HUD();
                special.HUD();
                light.HUD();
                heavy.Update(map, player, item);
                special.Update(map, player, item);
                light.Update(map, player, item);
                item.DisplayItem();
                player.Update(map, player, heavy, special, light, item);


            }

        }
    }
}
