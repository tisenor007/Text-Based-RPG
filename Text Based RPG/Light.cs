using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Text_Based_RPG
{
    //light enemy type
    class Light : Enemy
    {
        public bool isLight;
        public bool LightisClose;

        public void LoadLight(int X, int Y)
        {
            //sets health, position and character
            xLoc = X;
            yLoc = Y;
            Character = "e";
            health = 20;

        }

        public void CheckLight(int x, int y, Light light)
        {
            //so player can use this method and ask if a light enemy is a light enemy

            if (x == light.xLoc)
            {
                if (y == light.yLoc)
                {
                    isLight = true;
                }
                else
                {
                    isLight = false;
                }
            }
            //detects when it is close for displaying its health
            else
            {
                isLight = false;
            }
            if (y <= light.yLoc + 2)
            {
                if (x >= light.xLoc - 2)
                {
                    LightisClose = true;
                }
                else
                {
                    LightisClose = false;
                }
            }
            else
            {
                LightisClose = false;
            }
        }
        //displays health when player or whatever is close
        public void HUD()
        {
            if (LightisClose == true)
            {
                Console.WriteLine("'" + Character + "'" + " Health: " + health);
            }
            else if (LightisClose == false)
            {
                //nothing
            }
        }
    }
}
