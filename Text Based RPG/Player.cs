using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Text_Based_RPG
{
    class Player : GameCharacter
    {
        public bool isPlayer;
        private int Money;

        public void LoadPlayer(int X, int Y)
        {
            //loads player position, character, health
            xLoc = X;
            yLoc = Y;
            Character = "@";
            health = 100;


        }
        public void Update(Map map, Player player, Heavy heavy, Special special, Light light, Item item)
        {
            //makes cursor not visable 
            Console.CursorVisible = false;
            //sets position and draws character
            Console.SetCursorPosition(xLoc, yLoc);
            Console.WriteLine(Character);
            ConsoleKeyInfo keyPressed = Console.ReadKey();
            if (health <= 0)
            {
                //if player dies......
                health = 0;
                Character = "X";
            }
            else
            {

                //checks all enemies, items and the map
                heavy.CheckHeavy(player.xLoc, player.yLoc, heavy);
                special.CheckSpecial(player.xLoc, player.yLoc, special);
                light.CheckLight(player.xLoc, player.yLoc, light);
                item.GetItem(player.xLoc, player.yLoc);
                map.GetMapTile(player.xLoc, player.yLoc, item);

                if (item.isHealth == true)
                {
                    //if pickup health, gain unlimited health
                    if (item.icon == "+")
                    {
                        health = health + 20;
                    }
                }

                if (item.isMoney == true)
                {
                    //if money is picked up, money increases.....
                    Money = Money + 20;
                    item.isMoney = false;
                }
                else
                {
                    //nothing
                }
                if (special.isSpecial == true)
                {
                    //if they are dead, do no damage to player....
                    if (special.Character == "X")
                    {
                        //do no damage
                    }
                    //other wise do 15 points
                    else
                    {
                        player.health = player.health - 15;
                    }

                }
                //different enemys do different damage
                if (heavy.isHeavy == true)
                {

                    if (heavy.Character == "X")
                    {
                        //do no damage
                    }
                    else
                    {
                        player.health = player.health - 10;
                    }

                }
                if (light.isLight == true)
                {

                    if (light.Character == "X")
                    {
                        //do no damage
                    }
                    else
                    {
                        player.health = player.health - 5;
                    }
                }
                else
                {
                    //they are not there
                    special.isSpecial = false;
                    heavy.isHeavy = false;
                    light.isLight = false;
                }
                if (keyPressed.Key == ConsoleKey.W)
                {
                    //you are able to move unless there is a wall
                    map.GetMapTile(xLoc, yLoc - 1, item);

                    if (map.isWall == true)
                    {
                        //do nothing / stop
                    }
                    else
                    {
                        yLoc = yLoc - 1;
                    }

                }
                if (keyPressed.Key == ConsoleKey.A)
                {
                    map.GetMapTile(xLoc - 1, yLoc, item);
                    if (map.isWall == true)
                    {
                        //do nothing / stop
                    }

                    else
                    {
                        xLoc = xLoc - 1;
                    }

                }
                if (keyPressed.Key == ConsoleKey.S)
                {
                    map.GetMapTile(xLoc, yLoc + 1, item);
                    if (map.isWall == true)
                    {
                        //do nothing / stop
                    }
                    else
                    {
                        yLoc = yLoc + 1;
                    }
                }
                if (keyPressed.Key == ConsoleKey.D)
                {
                    map.GetMapTile(xLoc + 1, yLoc, item);
                    if (map.isWall == true)
                    {
                        //do nothing / stop
                    }
                    else
                    {
                        xLoc = xLoc + 1;
                    }
                }
            }
        }
        //method so enemy can check for player and damage it....
        public void IsPlayer(int x, int y)
        {
            if (y == yLoc)
            {
                if (x == xLoc)
                {
                    isPlayer = true;
                }
                else
                {
                    isPlayer = false;
                }
            }

            else
            {
                isPlayer = false;
            }
        }
        //player hud
        public void HUD(Item item)
        {
            Console.WriteLine("'" + Character + "'" + " Health: " + health + ", Money: " + Money + ", Door Acess: " + item.isKey);
        }
    }
}
