using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Text_Based_RPG
{
    class Program
    {
       
        public static int LeftRight = 1;
        public static int UpDown = 2;
        static void Main(string[] args)
        {

            MainMenu mainMenu;
            mainMenu = new MainMenu();
            mainMenu.DisplayMainMenu();

            Console.ReadKey(true);
        }
        public static void GameEngine()
        {
            //Instantiation and declaration
            GameOver gameOver = new GameOver();
            Player player1 = new Player();
            Enemy enemy1 = new Enemy();
            Map map = new Map();

            //Game Loop
            while (true)
            {
                //clears console
                Console.Clear();
                //displays map
                map.displayMap();
                //implements health/fighting mechanics
                player1.HealthMech();
                //shows stats for 
                player1.Stats();
                //Controls so player doesn't get confused....
                player1.Controls();
                //spawns enemy
                enemy1.SpawnEnemy(UpDown);
                //gives control to player
                Console.SetCursorPosition(player1.PlayerX, player1.PlayerY);
                //spawns player
                player1.SpawnCharater();
                //what triggers game loss
                if (player1.health == 0)
                {
                    gameOver.Gameover = true;
                    break;
                }
                //what triggers game win
                //want to implement more enemies in the future maybe will determine game win by enemy death count
                if (Enemy.IsDead == true)
                {
                    gameOver.Gameover = false;
                    break;
                }

            }
            //gameover screen
            //display changes based on bool status
            gameOver.GameOverScreen();
            Console.ReadKey(true);
        
    }
    }
}
