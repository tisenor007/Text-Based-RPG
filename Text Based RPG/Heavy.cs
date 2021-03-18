using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Text_Based_RPG
{
    class Heavy : Enemy
    {
        public bool isHeavy;
        public bool HeavyisClose;

        public void LoadHeavy(int X, int Y)
        {
            //sets position, icon and health
            xLoc = X;
            yLoc = Y;
            Character = "E";
            health = 100;

        }
        //checks for heavy position and when it is close
        public void CheckHeavy(int x, int y, Heavy heavy)
        {


            if (x == heavy.xLoc)
            {
                if (y == heavy.yLoc)
                {
                    isHeavy = true;
                }
                else
                {
                    isHeavy = false;
                }
            }

            else
            {
                isHeavy = false;
            }
            if (y <= heavy.yLoc + 2)
            {
                if (x >= heavy.xLoc - 2)
                {
                    HeavyisClose = true;
                }
                else
                {
                    HeavyisClose = false;
                }
            }
            else
            {
                HeavyisClose = false;
            }
        }
        //displays health when player gets close to it
        public void HUD()
        {
            if (HeavyisClose == true)
            {
                Console.WriteLine("'" + Character + "'" + " Health: " + health);
            }
            else if (HeavyisClose == false)
            {
                //nothing
            }
        }
    }
}
