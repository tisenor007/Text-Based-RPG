using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Text_Based_RPG
{
    class Enemy : GameCharacter
    {
       enum State
        {
            MovingLeft,
            MovingRight,
            MovingUp,
            MovingDown
        }
        private State state;
        private bool attackLocation;
        private bool isWall;
        private int eType;
        private Random rnd = new Random();
        private void SwitchState(State newstate)
        {
            state = newstate;

            switch(state){
                case State.MovingLeft:
                    xLoc = xLoc - 1;
                    break;
                case State.MovingRight:
                    xLoc = xLoc + 1;
                    break;
                case State.MovingUp:

                    break;
                case State.MovingDown:

                    break;

            }
        }
        public void LoadEnemy(int X, int Y, int type)
        {
            // epuals set x and y passed through function to actual x and y
            eType = type;
            xLoc = X;
            yLoc = Y;
            if (type <= 1)
            {
                Character = "E";
                health = 100;
               
            }
            else if (type == 2)
            {
                Character = "3";
                health = 50;
            }
            else if (type >= 3)
            {
                Character = "e";
                health = 25;
            }
        }
        
        public void Update(Map map, Player player)
        {
            Console.CursorVisible = false;
            //sets and updates position of enemy
            //Console.SetCursorPosition(xLoc, yLoc);
            
            if (health <= 0)
            {
                //when enemy dies 
                health = 0;
                Character = "X";
            }
            else
            {
                if (player.isPlayerAt(xLoc, yLoc - 1) == true)
                {

                    if (eType <= 1)
                    {
                        player.TakeDamage(5);
                        state = State.MovingRight;
                    }
                    if (eType == 2)
                    {
                        player.TakeDamage(10);
                    }
                    if (eType >= 3)
                    {
                        player.TakeDamage(2);
                    }

                }
                else if (player.isPlayerAt(xLoc - 1, yLoc) == true)
                {
                    if (true)
                    {
                        if (eType <= 1)
                        {
                            player.TakeDamage(5);
                        }
                        if (eType == 2)
                        {
                            player.TakeDamage(10);
                        }
                        if (eType >= 3)
                        {
                            player.TakeDamage(2);
                        }
                    }
                    else
                    {

                    }
                }
                else if (player.isPlayerAt(xLoc + 1, yLoc) == true)
                {
                    if (true)
                    {
                        if (eType <= 1)
                        {
                            player.TakeDamage(5);
                        }
                        if (eType == 2)
                        {
                            player.TakeDamage(10);
                        }
                        if (eType >= 3)
                        {
                            player.TakeDamage(2);
                        }
                    }
                    else
                    {

                    }
                }
                else if (player.isPlayerAt(xLoc, yLoc + 1) == true)
                {
                    if (true)
                    {
                        if (eType <= 1)
                        {
                            player.TakeDamage(5);
                        }
                        if (eType == 2)
                        {
                            player.TakeDamage(10);
                        }
                        if (eType >= 3)
                        {
                            player.TakeDamage(2);
                        }
                    }
                    else
                    {

                    }
                }
                else if (map.IsWallAt(xLoc - 1, yLoc) == true)
                {
                    xLoc = xLoc + 1;
                    yLoc = yLoc + 0;
                }
                else if (map.IsWallAt(xLoc + 1, yLoc) == true)
                {
                    xLoc = xLoc - 1;
                    yLoc = yLoc + 0;
                }
                else if (map.IsWallAt(xLoc, yLoc - 1) == true)
                {
                    xLoc = xLoc + 0;
                    yLoc = yLoc +1;
                }
                else if (map.IsWallAt(xLoc, yLoc + 1) == true)
                {
                    xLoc = xLoc + 0;
                    yLoc = yLoc - 1;
                }
                // if (state == State.MovingRight)
                //{
                //    xLoc = xLoc - 1;
                //    yLoc = yLoc + 1;
                //}
                //if (state == State.MovingLeft)
                //{
                //    xLoc = xLoc + 1;
                //    yLoc = yLoc + 1;
                //}
                //if (state == State.MovingUp)
                //{
                //    yLoc = yLoc - 1;

                //}
                //if (state == State.MovingDown)
                //{
                //    yLoc = yLoc + 1;
                //}
                else
                {
                    int pos = rnd.Next(1, 6);
                    if (eType <= 1)
                    {
                      
                        if (pos == 1)
                        {
                            xLoc = xLoc + 1;
                        }
                        else if (pos == 2)
                        {
                            xLoc = xLoc - 1;
                        }
                        
                   }
                   else if (eType == 2)
                   {
                        
                        if (pos == 1)
                        {
                            yLoc = yLoc + 1;
                        }
                        else if (pos == 2)
                        {
                            yLoc = yLoc - 1;
                        }
                    }
                    else if (eType >= 3)
                    {

                        if (pos == 1)
                        {
                            xLoc = xLoc + 1;
                        }
                        else if (pos == 2)
                        {
                            xLoc = xLoc - 1;
                        }
                        else if (pos == 3)
                        {
                            yLoc = yLoc + 1;
                        }
                        else if (pos >= 4)
                        {
                            yLoc = yLoc - 1;
                        }
                    }
                }
               

            }
        }
       
        
    }

    
}
