using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Text_Based_RPG
{
    class Player : GameCharacter
    {


        public void SpawnCharater()
        {

            Console.WriteLine("@");
            ConsoleKeyInfo keyPressed = Console.ReadKey();

            //for every key pressed, it has a different movement and can detect whether or not it is allowed to walk based of the tile of map in fornt of their desired directon.
            if (keyPressed.Key == ConsoleKey.W)
            {
                if (map[PlayerY - 1, PlayerX] == ".")
                {
                    PlayerY = PlayerY - 1;
                }
                else if (map[PlayerY - 1, PlayerX] == "#")
                {
                    PlayerY = PlayerY - 1;
                }
                else
                {
                    //so the player will stop if not allowed to walk

                    //do nothing

                }
            }
            if (keyPressed.Key == ConsoleKey.A)
            {
                if (map[PlayerY, PlayerX - 1] == ".")
                {
                    PlayerX = PlayerX - 1;
                }
                else if (map[PlayerY, PlayerX - 1] == "#")
                {
                    PlayerX = PlayerX - 1;
                }
                else
                {
                    //do nothing
                }
            }
            if (keyPressed.Key == ConsoleKey.S)
            {
                if (map[PlayerY + 1, PlayerX] == ".")
                {
                    PlayerY = PlayerY + 1;
                }
                else if (map[PlayerY + 1, PlayerX] == "#")
                {
                    PlayerY = PlayerY + 1;
                }
                else
                {
                    //do nothing
                }
            }
            if (keyPressed.Key == ConsoleKey.D)
            {
                if (map[PlayerY, PlayerX + 1] == ".")
                {
                    PlayerX = PlayerX + 1;
                }
                else if (map[PlayerY, PlayerX + 1] == "#")
                {
                    PlayerX = PlayerX + 1;
                }
                else
                {
                    //do nothing
                }
            }


            //if enter is press and the player is front of the enemy, enemy will die
            if (keyPressed.Key == ConsoleKey.Enter)
            {
                if (PlayerX == EnemyX - 1)
                {

                    EnemyDeathcount = EnemyDeathcount + 1;
                    if (EnemyDeathcount == 1)
                    {
                        Enemy.IsDead = true;
                    }

                }

            }

            Console.WriteLine("@");
            Console.CursorVisible = false;

        }
        //shows stats
        public void Stats()
        {
            Console.WriteLine("Player: " + name + "  Health: " + health + " X: " + PlayerX + "," + " Y: " + PlayerY + " Enemies Killed: " + EnemyDeathcount);

        }
        //Controls
        public void Controls()
        {
            Console.WriteLine("Classic WASD controls, Enter to attack, but you have to be in front of the enemy.");
        }
    }
}
