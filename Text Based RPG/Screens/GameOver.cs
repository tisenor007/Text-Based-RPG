using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Text_Based_RPG
{
    class GameOver
    {
        public bool gameOverLoss;
        public bool gameOverWin;
        //what you see if you lose
        public void GameOverLossScreen()
        {
            string lossScreen = System.IO.File.ReadAllText("GameOverLossArt.txt");
            Console.SetCursorPosition(0, 0);
            Console.WriteLine(lossScreen);
            Console.WriteLine();
            Console.WriteLine("Press any button to exit...");
            Console.ReadKey(true);
        }
        //what you see if you win...
        public void GameOverWinScreen()
        {
            string winScreen = System.IO.File.ReadAllText("GameOverWinScreen.txt");
            Console.SetCursorPosition(0, 0);
            Console.WriteLine(winScreen);
            Console.WriteLine();
            Console.WriteLine("Press any button to exit...");
            Console.ReadKey(true);
        }
    }
}
