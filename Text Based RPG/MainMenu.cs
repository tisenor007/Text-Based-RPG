using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Text_Based_RPG
{
    //inherits program to get access to GameEngine function in program
    class MainMenu : Program
    {
        public void DisplayMainMenu()
        {
            //Main Tile screen is displayed via ASCII art from a text file...
            Console.Clear();
            string Title;
            Title = System.IO.File.ReadAllText("MainTitle.txt");
            Console.Write(Title);
            Console.WriteLine();
            //starts game
            Console.WriteLine("A - New Game");
            //can quit from main menu
            Console.WriteLine("B - Quit");
            ConsoleKeyInfo keyPressed = Console.ReadKey();
            if (keyPressed.Key == ConsoleKey.A)
            {
                GameEngine();
            }
            if (keyPressed.Key == ConsoleKey.B)
            {
                System.Environment.Exit(1);
            }
            Console.ReadKey(true);
        }
    }
}
