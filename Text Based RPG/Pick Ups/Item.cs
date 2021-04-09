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
        protected char icon;
        public int xLoc;
        public int yLoc;
   
        public virtual void Update(Map map, Player player)
        {
            Console.WriteLine("You must define your item!");
        }
        public void Draw(Camera camera)
        {
            camera.DrawToRenderer(icon, xLoc, yLoc);
        }
    }
}
