using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Text_Based_RPG
{
    //set cursor position (0,0) plus or minus offset, which is attched to player coordinates

    class tries
    {
        private char[,] display = new char[54, 13];
        private char[,] world = new char[108, 26];

        public int xPos;
        public int yPos;
        public int Xstart = 0;
        public int Ystart = 0;
        public int Xend = 55;
        public int Yend = 13;
        public char[,] map = new char[108, 26];
        private string[] mapData;
        private int x;
        private int y;
        public void SetDisplay()
        {

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
        public void Display(Player player)
        {
            //world = map;
            int setY = 0;
            for (int y = Ystart + player.yLoc; y < Yend - player.yLoc; y++)
            {
                int setX = 0;
                for (int x = Xstart + player.xLoc; y < Xend - player.xLoc; x++)
                {
                    display[setY, setX] = world[x, y];
                    Console.WriteLine(display[x, y]);

                    //if (setX < Yend) {setX++}
                    //else { }
                }
                //if(setY)
            }
        }
        
        public void DisplayToWorld(char gameObject, int x, int y)
        {
            world[x, y] = gameObject;
        }
        public void loadCamera(Map map, Player player)
        {
            //Xoffset = player.xLoc - map.xLoc;
            //Yoffset = player.yLoc = map.yLoc;
        }
        public void Update()
        {
            world = map;


        }
    }
}
