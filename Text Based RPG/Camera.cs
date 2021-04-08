using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Text_Based_RPG
{
    class Camera
    {
        public char[,] renderer = new char[121, 26]; // size ???
       
        private int startViewX = 0;
        private int startViewY = 0;
        private int endViewX;
        public int endViewY;

        public int offsetX;
        public int offsetY;
        public Camera(Map map)
        {
           
            endViewY = 10;
            endViewX = 25;
        }
        public void Update(Map map, Player player)
        {
            offsetX = player.xLoc - endViewX / 2;
            offsetY = player.yLoc - endViewY / 2;
            DrawMapToRenderer(map);
        }
        public void Draw()
        {
            Console.SetCursorPosition(0, 0);
            Console.Write("+");
            for (int t = startViewX; t < endViewX; t++)
            {
                Console.Write("-");
            }
            Console.Write("+");
            Console.WriteLine();
            
            for (int y = startViewY; y < endViewY; y++)
            {
                Console.Write("|");
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
                Console.Write("|");
                Console.WriteLine();
            }
            Console.Write("+");
            for (int b = startViewX; b < endViewX; b++)
            {
                Console.Write("-");
            }
            Console.Write("+");
            Console.WriteLine();
        }
        public void DrawToRenderer(char character, int x, int y)
        {
            renderer[x, y] = character;
        }
        public void DrawMapToRenderer(Map map)
        {
            for (int i = 0; i < map.mapData.Length; i++)
            {
                for (int d = 0; d < map.currMapLine.Length; d++)
                {
                    renderer[d, i] = map.map[d, i];
                }
            }
        }
    }
}
