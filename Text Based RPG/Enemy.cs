﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Text_Based_RPG
{
    class Enemy : GameCharacter
    {
       
        private bool attackLocation;
        private bool isWall;
        private int eType;

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
                if (attackLocation = player.IsPlayerUp(xLoc, yLoc))
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
                else if (attackLocation = player.IsPlayerLeft(xLoc, yLoc))
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
                else if (attackLocation = player.IsPlayerRight(xLoc, yLoc))
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
                else if (attackLocation = player.IsPlayerDown(xLoc, yLoc))
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
                else if (isWall = map.IsWallAt(xLoc - 1, yLoc))
                {
                    //do nothing
                }
                else if (isWall = map.IsWallAt(xLoc + 1, yLoc))
                {
                    //do nothing
                }
                else if (isWall = map.IsWallAt(xLoc, yLoc - 1))
                {
                    //do nothing
                }
                else if (isWall = map.IsWallAt(xLoc, yLoc + 1))
                {
                    //do nothing
                }

                else
                {
                    if (eType <= 1)
                    {
                        xLoc = xLoc + 1;
                    }
                    if (eType == 2)
                    {
                       
                    }
                    if (eType >= 3)
                    {
                        
                    }

                }
               

            }
        }
       
        
    }

    
}
