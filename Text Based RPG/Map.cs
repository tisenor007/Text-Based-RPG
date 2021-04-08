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
        public char[,] map = new char[121, 26]; // size ???
        public string[] mapData;
        public string currMapLine;
        private char mapTile;

      
       
        private int x;
        private int y;
        public bool openDoors = false;
       
        public Map()
        {
           
            //mapData reads file through lines - Gets Y
            mapData = System.IO.File.ReadAllLines("Map.txt");
            for (y = 0; y <= mapData.Length - 1; y = y + 1)
            { 
               
                //string created to be = to 1 / current line of map
                currMapLine = mapData[y];
                for (x = 0; x <= currMapLine.Length - 1; x = x + 1)
                {
                    //char mapTile = mapData[y][x];
                    //map tile is = to map line split by x
                   
                     mapTile = currMapLine[x];
                    //map[x,y] is = to map tile for exact location
                    map[x, y] = mapTile;
                   
                }
            }
           
        }
       
        public void Draw(Camera camera)
        {
           
            

        }
        //public void Update(Camera camera)
        //{

        //    if (camera.offsetX <= -1)
        //    {
        //        camera.Xstart = camera.Xstart + 1;
        //        camera.offsetX = camera.offsetX + 1;

        //    }
        //    if (camera.offsetY <= -1)
        //    {
        //        camera.Ystart = camera.Ystart + 1;
        //        camera.offsetY = camera.offsetY + 1;
        //    }

        //    if (camera.offsetX >= 1)
        //    {
        //        camera.Xstart = camera.Xstart - 1;
        //        camera.offsetX = camera.offsetX - 1;
        //    }
        //    if (camera.offsetY >= 1)
        //    {
        //        camera.Ystart = camera.Ystart - 1;
        //        camera.offsetY = camera.offsetY - 1;
        //    }
        //    if (camera.Xstart <= 0)
        //    {
        //        camera.Xstart = 0;

        //    }
        //    if (camera.Ystart <= 0)
        //    {
        //        camera.Ystart = 0;

        //    }

        //}
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
