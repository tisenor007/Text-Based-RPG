using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Text_Based_RPG
{
    //Game characters inherit the map so they can collide with it
    abstract class GameCharacter : Map
    {
        //fields
        public string name = "Trenton";
        //made enemy and player have seperate X and Y to make them comparable
        public int PlayerX = 56;
        public int PlayerY = 12;
        public int EnemyX = 92;
        public int EnemyY = 19;
        //default player health
        //was put in this class to possibly make health system for enemies
        public int health = 100;
        //Counts Enemy Death
        //feature for when multiple enemies work.......
        public static int EnemyDeathcount;
        //what controls gameover
        public bool Gameover;

        public void HealthMech()
        {
            //if enemy gets on player, player will take 10 damage every time the enemy is on them.
            if (PlayerX == EnemyX)
            {
                if (PlayerY == EnemyY)
                {
                    health = health - 10;
                    if (health <= 0)
                    {
                        //health cannot go below 0
                        health = 0;
                    }
                }

            }
            //if player dies, game loss
            if (health <= 0)
            {
                Gameover = true;
            }
        }

    }
}
