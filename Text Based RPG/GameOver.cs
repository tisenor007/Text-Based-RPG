using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Text_Based_RPG
{
    //inherits GameCharacter because game characters determine whether the game ends or not.
    class GameOver : GameCharacter
    {
        public void GameOverScreen()
        {
            //what displays if you win a game
            if (Gameover == false)
            {
                Console.Clear();
                string GameWin;
                GameWin = System.IO.File.ReadAllText("GameWinScreen.txt");
                Console.Write(GameWin);
                Console.WriteLine();

                Console.WriteLine("B - Quit");
                ConsoleKeyInfo keyPressed = Console.ReadKey();

                if (keyPressed.Key == ConsoleKey.B)
                {
                    System.Environment.Exit(1);
                }
                Console.ReadKey(true);
            }
            //what displays if you lose a game
            if (Gameover == true)
            {
                Console.Clear();
                string GameOver;
                GameOver = System.IO.File.ReadAllText("GameOverScreen.txt");
                Console.Write(GameOver);
                Console.WriteLine();

                Console.WriteLine("B - Quit");
                ConsoleKeyInfo keyPressed = Console.ReadKey();

                if (keyPressed.Key == ConsoleKey.B)
                {
                    System.Environment.Exit(1);
                }
                Console.ReadKey(true);
            }
        }
    }
}
