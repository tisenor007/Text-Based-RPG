using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Text_Based_RPG
{
    class Item
    {
        private string icon;
        private int iType;
        private int xLoc;
        private int yLoc;
        
        public void Load(int X, int Y, int type)
        {
            xLoc = X;
            yLoc = Y;
            type = iType;
            if (type <= 1)
            {
                icon = "+";
               
            }
            else if (type == 2)
            {
                icon = "#";
                
            }
            else if (type >= 3)
            {
                icon = "b";
               
            }
        }
        public void Update(Player player)
        {
            Console.SetCursorPosition(xLoc, yLoc);
        }
        public void Draw()
        {
            Console.WriteLine(icon);
        }
    }
}
