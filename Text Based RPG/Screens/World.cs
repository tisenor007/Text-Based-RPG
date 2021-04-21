using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Text_Based_RPG
{
    class World
    {
        public char[,] world = new char[269, 63]; // size of map....
        public string[] worldData;
        public string currWorldLine;
        private char worldTile;
        private int x;
        private int y;

        public World()
        {
            //mapData reads file through lines - Gets Y
            worldData = System.IO.File.ReadAllLines("World.txt");
            for (y = 0; y <= worldData.Length - 1; y = y + 1)
            {
                //string created to be = to 1 / current line of map
                currWorldLine = worldData[y];
                for (x = 0; x <= currWorldLine.Length - 1; x = x + 1)
                {
                    //char mapTile = mapData[y][x];
                    //map tile is = to map line split by x
                    worldTile = currWorldLine[x];
                    //map[x,y] is = to map tile for exact location
                    world[x, y] = worldTile;
                }
            }
        }
        public void InitEntities(EnemyManager enemyManager, ItemManager itemManager, Player player)
        {
            for (int y = 0; y < worldData.Length; y++)
            {
                for (int x = 0; x < currWorldLine.Length; x++)
                {
                    enemyManager.CheckEnemyWorldLoc(world, x, y);
                    itemManager.CheckItemWorldLoc(world, x, y);
                    player.CheckPlayerWorldLoc(world, x, y);
                }
            }
        }
    }
}
