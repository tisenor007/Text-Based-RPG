using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Text_Based_RPG
{
    class Item
    {
        public Tile itemTile = new Tile(' ', ConsoleColor.White);
        //determines if they are picked up or not...
        public bool pickedUp;
        public bool dropped;
        public bool used;
        public int weaponBeingPickedUp;
        public string infoMessage; 
        //locations.....
        public int xLoc;
        public int yLoc;
        //what they are seen as
        
        public virtual void Update(Map map, Player player, Inventory inventory, Camera camera)
        {
            Console.SetCursorPosition(1, 1);
            Console.WriteLine(infoMessage);
        }
        //draw method for items
        public void Draw(Camera camera)
        {
            camera.DrawToRenderer(itemTile.tileCharacter, xLoc, yLoc);
        }
    }
}
