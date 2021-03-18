using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Text_Based_RPG
{
    abstract class Enemy : GameCharacter
    {
        private int bounceCount = 1;

        public void LoadEnemy(int type, int X, int Y)
        {
            // epuals set x and y passed through function to actual x and y
            xLoc = X;
            yLoc = Y;

        }
        public void Update(Map map1, Player player, Item item)
        {
            Console.CursorVisible = false;
            //sets and updates position of enemy
            Console.SetCursorPosition(this.xLoc, this.yLoc);
            //displays enemy
            Console.WriteLine(Character);
            //checks for player
            player.IsPlayer(xLoc, yLoc);
            //when enemy dies.......
            if (health <= 0)
            {
                //when enemy dies 
                health = 0;
                Character = "X";
            }
            else
            {
                //else, alive behavior

                if (player.isPlayer == true)
                {
                    //checks if player is touching it and loses health if they are indeed colliding with enemy
                    health = health - 20;
                    //BUG supposed to stop when is player is true but enemy for some reason still moves....

                }

                else if (player.isPlayer == false)
                {

                    //goomba AI loop
                    map1.GetMapTile(this.xLoc, this.yLoc, item);
                    if (map1.isWall == true)
                    {
                        //if enemy hits this part of map the bounce count will be one
                        bounceCount = bounceCount + 1;
                    }
                    if (bounceCount == 1)
                    {

                        //if the bounce count is 1 the enemy will change direction
                        xLoc = xLoc + 1;
                    }

                    else if (bounceCount <= 2)
                    {

                        //if it bounces twice bounce count will go back to zero and start heading original direction
                        //hence infinite goomba loop
                        bounceCount = 0;
                        xLoc = xLoc - 1;
                    }
                }

            }
        }


    }
}
