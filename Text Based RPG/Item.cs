using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Text_Based_RPG
{
    class Item
    {
        public bool pickedUp;
        private string icon;
        public int iType;
        public int xLoc;
        public int yLoc;
        
        public void Load(int X, int Y, int type)
        {
            pickedUp = false;
            xLoc = X;
            yLoc = Y;
            iType = type;
            if (type == 1)
            {
                icon = "+";
               
            }
            else if (type == 2)
            {
                icon = "&";
                
            }
            else if (type >= 3)
            {
                icon = "$";
               
            }
           
        }
       
        public void Update(Map map, Player player)
        {
            if (iType == 1)
            {
                if (pickedUp == true)
                {
                    player.Heal(10);
                    icon = " ";
                    xLoc = 0;
                    yLoc = 0;
                    pickedUp = false;
                }
                

            }
            else if (iType == 2)
            {
                if (pickedUp == true)
                {
                    map.openDoors = true;
                    icon = " ";
                    xLoc = 0;
                    yLoc = 0;
                    
                }
                    

            }
            else if (iType >= 3)
            {
                if (pickedUp == true)
                {
                    player.GetReward(100);
                    icon = " ";
                    xLoc = 0;
                    yLoc = 0;
                    pickedUp = false;
                }

            }
        }
        public void Draw()
        {
            Console.SetCursorPosition(xLoc, yLoc);
            Console.WriteLine(icon);
        }
    }
}
