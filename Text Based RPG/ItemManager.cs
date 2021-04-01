using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Text_Based_RPG
{
    class ItemManager
    {
        private static int Max_Items = 10;
        public Item[] items = new Item[Max_Items];

        public void InitItems()
        {
            for (int i = 0; i < Max_Items; i++)
            {
                items[i] = new Item();
            }
           
           
        }
        public void LoadItems()
        {
            items[0].Load(94, 11, 2);
            items[1].Load(84, 20, 3);
            items[2].Load(21, 5, 1);
            items[3].Load(76, 16, 1);
            items[4].Load(36, 10, 1);
            items[5].Load(17, 19, 1);
            items[6].Load(42, 19, 1);
            items[7].Load(86, 20, 3);
            items[8].Load(88, 20, 3);
            items[9].Load(89, 4, 1);
        }
        public void UpdateItems(Map map, Player player)
        {
            for (int i = 0; i < Max_Items; i++)
            {
                items[i].Update(map, player);
            }
        }
        public void DrawItems(Camera camera)
        {
            for (int i = 0; i < Max_Items; i++)
            {
                items[i].Draw(camera);
            }
        }
        public void CheckItems(int x, int y)
        {
            for (int i = 0; i < Max_Items; i++)
            {
                if (x == items[i].xLoc)
                {
                    if (y == items[i].yLoc)
                    {
                      
                        items[i].pickedUp = true;
                       
                    }
                }
            }
        }
        public bool isItemAt(int x, int y)
        {
            for (int i = 0; i < Max_Items; i++)
            {
                if (x == items[i].xLoc)
                {
                    if (y == items[i].yLoc)
                    {
                        return true;
                    }
                }
            }
            return false;
        }
    }
}
