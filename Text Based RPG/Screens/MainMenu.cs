using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Text_Based_RPG
{
    class MainMenu
    {
        //what you see when game starts
        public void StartMainMenu()
        {
           string titleScreen = System.IO.File.ReadAllText("Art/MainMenuArt.txt");
            Console.WriteLine(titleScreen);
            Console.WriteLine("Original Made by Trenton");
            Console.WriteLine("Expanded by Jared");
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("Press any button - New Game");
            Console.WriteLine("Q - Quit");

            ConsoleKeyInfo keyPressed = Console.ReadKey(true);
            if (keyPressed.Key == ConsoleKey.Q)
            {
                System.Environment.Exit(1);
            }
            Console.Beep(2200, 100);
            return;
        }
        //info for backstory of game.....
        public void ShowInfoScreen()
        {
            Console.SetCursorPosition(0, 0);
            string beginningInfo = System.IO.File.ReadAllText("Art/MainMenuInfoScreenArt.txt");
            Console.WriteLine(beginningInfo);
            Console.WriteLine();
            Console.WriteLine("Press any button to continue...");
            Console.ReadKey(true);
            Console.Beep(2200, 100);
            return;
        }
    }
}
