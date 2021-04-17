using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Text_Based_RPG
{
    class Item
    {
        //determines if they are picked up or not...
        public bool pickedUp;
        //locations.....
        public int xLoc;
        public int yLoc;
        //what they are seen as
        protected char icon;
        public virtual void Update(Map map, Player player, Inventory inventory)
        {
            //game will tell you, you will need to give an item definition, else it is meaningless.....
            Console.WriteLine("You must define your item!");
        }
        //draw method for items
        public void Draw(Camera camera)
        {
            camera.DrawToRenderer(icon, xLoc, yLoc);
        }
    }
}
