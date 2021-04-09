using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Text_Based_RPG
{
    class ItemManager
    {
        private static int Max_Items = 26;
        public Item[] items = new Item[Max_Items];

        public void InitItems()
        {
            items[0] = new FirstAidKit(52, 11);
            items[1] = new FirstAidKit(44, 26);
            items[2] = new FirstAidKit(92, 28);
            items[3] = new FirstAidKit(128, 10);
            items[4] = new FirstAidKit(17, 16);
            items[5] = new FirstAidKit(170, 14);
            items[6] = new FirstAidKit(169, 21);
            items[7] = new FirstAidKit(213, 37);
            items[8] = new FirstAidKit(139, 44);
            items[9] = new FirstAidKit(81, 31);
            items[10] = new Key(96, 43);
            items[11] = new Shield(21, 19);
            items[12] = new Weapon(56, 25, 2);
            items[13] = new Shield(40, 11);
            items[14] = new Shield(185, 21);
            items[15] = new Weapon(128, 8, 3);
            items[16] = new Weapon(186, 14, 4);
            items[17] = new Weapon(223, 36, 5);
            items[18] = new Valuable(112, 56);
            items[19] = new Valuable(113, 56);
            items[20] = new Valuable(114, 56);
            items[21] = new Valuable(115, 56);
            items[22] = new Valuable(116, 56);
            items[23] = new Valuable(117, 56);
            items[24] = new Shield(97, 49);
            items[25] = new Shield(120, 23);
           
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
        public bool IsItemAt(int x, int y)
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
