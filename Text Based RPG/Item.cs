using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Text_Based_RPG
{
    class Item
    {
        //fields..
        public bool isHealth;
        public bool isKey;
        public bool isMoney;
        public string icon;
        public int ItemLocX;
        public int ItemLocY;
        private int ItemType;

        public void LoadItem(int x, int y, int type)
        {
            //sets position and type
            ItemLocX = x;
            ItemLocY = y;
            ItemType = type;

            //different icon based on type
            if (type <= 1)
            {
                icon = "$";
            }
            if (type == 2)
            {
                icon = "+";
            }
            if (type >= 3)
            {
                icon = "&";
            }
        }
        public void DisplayItem()
        {
            if (isHealth == true)
            {
                //makes icon disapear and throws it out of bounds when picked up
                icon = "";
                ItemLocX = 0;
                ItemLocY = 0;
            }
            if (isKey == true)
            {
                //makes icon dissapear but doesn't remove it, no need
                icon = "";
            }
            if (isMoney == true)
            {
                //same as the first one.....
                icon = "";
                ItemLocX = 0;
                ItemLocY = 0;
            }
            else
            {
                //nothing
            }
            //sets position and draws it
            Console.SetCursorPosition(ItemLocX, ItemLocY);
            Console.WriteLine(icon);



        }
        public void GetItem(int x, int y)
        {
            //diferent bools/behavior for each type
            if (ItemType == 2)
            {
                if (x == ItemLocX)
                {
                    if (y == ItemLocY)
                    {
                        isHealth = true;
                    }
                    else
                    {
                        isHealth = false;
                    }
                }
                else
                {
                    isHealth = false;
                }
            }
            if (ItemType == 3)
            {
                if (x == ItemLocX)
                {
                    if (y == ItemLocY)
                    {
                        isKey = true;
                    }
                    else
                    {

                    }
                }
                else
                {

                }
            }
            if (ItemType == 1)
            {
                if (x == ItemLocX)
                {
                    if (y == ItemLocY)
                    {
                        isMoney = true;
                    }
                    else
                    {
                        isMoney = false;
                    }
                }
                else
                {
                    isMoney = false;
                }

            }
        }
    }
}
