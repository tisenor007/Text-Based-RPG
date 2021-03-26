using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Text_Based_RPG
{
    
    class Map
    {   //fields.....
        //map delcared and instantiated with proper map bounds
        public char[,] map = new char[108, 26]; // size ???
        private string[] mapData;
        private int x;
        private int y;
        private int xLoc = 0;
        private int yLoc = 0;
        public bool openDoors = false;
       
        public void Load()
        {
            //mapData reads file through lines - Gets Y
            mapData = System.IO.File.ReadAllLines("Map.txt");
            for (y = 0; y <= mapData.Length - 1; y = y + 1)
            {
                //string created to be = to 1 / current line of map
                string currMapLine = mapData[y];
                for (x = 0; x <= currMapLine.Length - 1; x = x + 1)
                {
                    //char mapTile = mapData[y][x];
                    //map tile is = to map line split by x
                    char mapTile = currMapLine[x];
                    //map[x,y] is = to map tile for exact location
                    map[x, y] = mapTile;

                }
            }

        }
        public void Draw(Camera camera)
        {

            Console.SetCursorPosition(xLoc, yLoc);
            for (y = 0; y <= mapData.Length - 1; y = y + 1)
            {
                //repeats lines til whole map is displayed
                //end of repeat is determined by y
                Console.WriteLine(mapData[y]);
            }

            //for (y = camera.Ystart; y <= camera.Yend; y = y + 1)
            //{
            //    //repeats lines til whole map is displayed
            //    //end of repeat is determined by y
            //    Console.WriteLine(mapData[y]);
            //}
        }
        public void Update(Camera camera)
        {
            
            //mapData reads file through lines - Gets Y
            //mapData = System.IO.File.ReadAllLines("Map.txt");
            //for (y = camera.Ystart + 4; y <= camera.Yend; y = y + 1)
            //{
            //    //string created to be = to 1 / current line of map
            //    string currMapLine = mapData[y];
            //    for (x = camera.Xstart; x <= currMapLine.Length - 1; x = x + 1)
            //    {
            //        //char mapTile = mapData[y][x];
            //        //map tile is = to map line split by x
            //        char mapTile = currMapLine[x];
            //        //map[x,y] is = to map tile for exact location
            //        map[x, y] = mapTile;

            //    }
            //}
        }
        public bool IsWallAt(int x, int y)
        {
            //lets you walk on certain tiles but anything else, no
            if (map[x, y] == '.')
            {
                return false;
            }
            else if (map[x, y] == '#')
            {
                return false;
            }
            if (openDoors == true)
            {
                if (map[x, y] == '&')
                {
                    return false;
                }
                return true;
            }
            else
            {
                return true;
            }
           
        }
    }
}
