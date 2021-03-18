using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Text_Based_RPG
{
    class Enemy : GameCharacter
    {
        public int bounceCount = 1;
        //renders death
        public static bool IsDead;

        public void SpawnEnemy(int direction)//1 = left and right
        {

            Console.CursorVisible = false;

            if (IsDead == false)
            {
                Console.SetCursorPosition(EnemyX, EnemyY);

                Console.WriteLine("E");
                //simple goomba AI, made by yours, truely
                if (direction == 1)
                {

                    if (map[EnemyY, EnemyX] == "|")
                    {
                        //if enemy hits this part of map the bounce count will be one
                        bounceCount = bounceCount + 1;

                    }
                    if (map[EnemyY, EnemyX] == "#")
                    {
                        //or if it hits this
                        bounceCount = bounceCount + 1;

                    }
                    if (bounceCount == 1)
                    {
                        //if the bounce count is 1 the enemy will change direction
                        EnemyX = EnemyX + 1;
                    }
                    else if (bounceCount <= 2)
                    {
                        //if it bounces twice bounce count will go back to zero and start heading original direction
                        //this will finialize our infinite goomba loop
                        bounceCount = 0;
                        EnemyX = EnemyX - 1;
                    }
                }
                if (direction == 2)// 2 = up and down
                {
                    //same AI but if direction changes, AI will detect ceiling and floor tiles instead of wall tiles
                    //direction will also change with EnemyX going to EnemyY....
                    if (map[EnemyY, EnemyX] == "—")
                    {
                        bounceCount = bounceCount + 1;

                    }
                    if (map[EnemyY, EnemyX] == "#")
                    {

                        bounceCount = bounceCount + 1;

                    }
                    if (bounceCount == 1)
                    {
                        EnemyY = EnemyY + 1;
                    }
                    else if (bounceCount <= 2)
                    {
                        bounceCount = 0;
                        EnemyY = EnemyY - 1;
                    }
                }
            }
            //if enemy dies
            if (IsDead == true)
            {
                //for now this will cause a instant Game win but I want to create multiple Enemies so when that works, when they die, they should stop and be displayed as an X
                Console.SetCursorPosition(EnemyX, EnemyY);
                Console.WriteLine("X");
                //something I was trying so 1 enemy wouldn't kill all them
                //As I stated else where multiple enemies don't work right now.
                IsDead = false;
            }

            //if (health <= 0)
            //{
            //health = 0;
            //Enemycount = Enemycount - 1;
            //}  
            //if (Enemycount <= 0)
            //{
            //GameLoss = false;
            //}

        }

    }
}
