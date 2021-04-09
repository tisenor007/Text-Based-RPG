using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Text_Based_RPG
{
    class Camera
    {
        public char[,] renderer = new char[269, 63]; // same size as map 
        public int endViewY;
        public int offsetX;
        public int offsetY;
        private int startViewX = 0;
        private int startViewY = 0;
        private int endViewX;
        public Camera()
        {
            //can set size of camera
            endViewY = 10;
            endViewX = 35;
        }
        //attaches camera to player
        public void Update(Map map, Player player)
        {
            //math to always center the player in camera but only if X and Y start is 0
            offsetX = player.xLoc - endViewX / 2;
            offsetY = player.yLoc - endViewY / 2;
            //draws the on the renderer every update to prevent trails...
            map.DrawToRender(renderer);
        }
        public void Draw()
        {
            //always makes camera top left of screen.....
            Console.SetCursorPosition(0, 0);
            //border on camera, set to white....
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("+");
            for (int t = startViewX; t < endViewX; t++)
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write("-");
            }
            Console.Write("+");
            Console.WriteLine();
            for (int y = startViewY; y < endViewY; y++)
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write("|");
                for (int x = startViewX; x < endViewX; x++)
                {
                    try
                    {
                        SetColours(x, y);
                        Console.Write(renderer[x + offsetX, y + offsetY]);
                    }
                    catch
                    {
                        Console.Write(" ");
                    }   
                }
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write("|");
                Console.WriteLine();
            }
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("+");
            for (int b = startViewX; b < endViewX; b++)
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write("-");
            }
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("+");
            Console.WriteLine();
        }
        public void DrawToRenderer(char character, int x, int y)
        {
            //method to draw items to the renderer
            renderer[x, y] = character;
        }
        public void SetColours(int x, int y)
        {
            //sets all colours
            if (renderer[x + offsetX, y + offsetY] == '`') { Console.ForegroundColor = ConsoleColor.Green; }
            else if (renderer[x + offsetX, y + offsetY] == '~') { Console.ForegroundColor = ConsoleColor.Blue; }
            else if (renderer[x + offsetX, y + offsetY] == '7') { Console.ForegroundColor = ConsoleColor.DarkGray; }
            else if (renderer[x + offsetX, y + offsetY] == '^') { Console.ForegroundColor = ConsoleColor.DarkGray; }
            else if (renderer[x + offsetX, y + offsetY] == '-') { Console.ForegroundColor = ConsoleColor.Gray; }
            else if (renderer[x + offsetX, y + offsetY] == '|') { Console.ForegroundColor = ConsoleColor.Gray; }
            else if (renderer[x + offsetX, y + offsetY] == '=') { Console.ForegroundColor = ConsoleColor.DarkGray; }
            else if (renderer[x + offsetX, y + offsetY] == '@') { Console.ForegroundColor = ConsoleColor.Cyan; }
            else if (renderer[x + offsetX, y + offsetY] == 'e') { Console.ForegroundColor = ConsoleColor.Red; }
            else if (renderer[x + offsetX, y + offsetY] == 'E') { Console.ForegroundColor = ConsoleColor.Red; }
            else if (renderer[x + offsetX, y + offsetY] == '3') { Console.ForegroundColor = ConsoleColor.Red; }
            else if (renderer[x + offsetX, y + offsetY] == 'B') { Console.ForegroundColor = ConsoleColor.DarkRed; }
            else if (renderer[x + offsetX, y + offsetY] == '#') { Console.ForegroundColor = ConsoleColor.DarkMagenta; }
            else if (renderer[x + offsetX, y + offsetY] == '▓') { Console.ForegroundColor = ConsoleColor.Black; }
            
            else{ Console.ForegroundColor = ConsoleColor.White;}
        }
       
    }
}
