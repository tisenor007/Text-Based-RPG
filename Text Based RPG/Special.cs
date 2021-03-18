using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Text_Based_RPG
{
    class Special : Enemy
    {

        public bool isSpecial;
        public bool SpecialisClose;

        public void LoadSpecial(int X, int Y)
        {
            //sets position, health and icon
            xLoc = X;
            yLoc = Y;
            Character = "3";
            health = 50;

        }
        //checks where special is and if it is close
        public void CheckSpecial(int x, int y, Special special)
        {


            if (x == special.xLoc)
            {
                if (y == special.yLoc)
                {
                    isSpecial = true;
                }
                else
                {
                    isSpecial = false;
                }
            }

            else
            {
                isSpecial = false;
            }
            if (y <= special.yLoc + 2)
            {
                if (x >= special.xLoc - 2)
                {
                    SpecialisClose = true;
                }
                else
                {
                    SpecialisClose = false;
                }
            }
            else
            {
                SpecialisClose = false;
            }
        }
        //displays health when you get close
        public void HUD()
        {
            if (SpecialisClose == true)
            {
                Console.WriteLine("'" + Character + "'" + " Health: " + health);
            }
            else if (SpecialisClose == false)
            {
                //nothing
            }
        }
    }
}
