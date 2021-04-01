using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Text_Based_RPG
{
    class Camera
    {
        public char[,] renderer = new char[108, 26]; // size ???
        private string[] rendererData;
        private int startViewX;
        private int startViewY;
        private int endViewX;
        private int endViewY;

        public int offsetX;
        public int offsetY;
        public void LoadRenderer(Player player)
        {
            startViewY = 0;
            endViewY = 6;
            startViewX = 0;
            endViewX = 20;
            //offsetX = player.xLoc - endViewX / 2;
            //offsetY = player.yLoc - endViewY / 2;

            rendererData = System.IO.File.ReadAllLines("Map.txt");
            for (int y = 0; y <= rendererData.Length - 1; y = y + 1)
            {
                //string created to be = to 1 / current line of map
                string currRendererLine = rendererData[y];
                for (int x = 0; x <= currRendererLine.Length - 1; x = x + 1)
                {
                    //char mapTile = mapData[y][x];
                    //map tile is = to map line split by x
                     char rendererTile = currRendererLine[x];
                    //map[x,y] is = to map tile for exact location
                    renderer[x, y] = rendererTile;

                }
            }
          

        }
        public void Update(Map map, Player player)
        {
            offsetX = player.xLoc - endViewX / 2;
            offsetY = player.yLoc - endViewY / 2;

        }
        public void Draw(Map map)
        {
            Console.SetCursorPosition(0, 0);
            for (int y = startViewY; y < endViewY; y++)
            {
                for (int x = startViewX; x < endViewX; x++)
                {
                    //repeats lines til whole map is displayed
                    //end of repeat is determined by y
                    try
                    {
                        Console.Write(renderer[x + offsetX, y + offsetY]);
                    }
                    catch
                    {
                        Console.Write(" ");
                    }
                    
                }
                Console.WriteLine();
            }
        }
        public void DrawToRenderer(char character, int x, int y)
        {
            renderer[x, y] = character;
        }
    }
}
