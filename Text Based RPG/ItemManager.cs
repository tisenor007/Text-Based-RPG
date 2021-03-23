using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Text_Based_RPG
{
    class ItemManager : Item
    {
        public Item[] itemNum = new Item[10];

        public void InitItems()
        {
            itemNum[0] = new Item();
            itemNum[1] = new Item();
            itemNum[2] = new Item();
            itemNum[3] = new Item();
            itemNum[4] = new Item();
            itemNum[5] = new Item();
            itemNum[6] = new Item();
            itemNum[7] = new Item();
            itemNum[8] = new Item();
            itemNum[9] = new Item();
        }
        public void LoadItems()
        {
            itemNum[0].Load(14, 3, 1);
        }
        public void UpdateAndDraw(Player player)
        {
            itemNum[0].Update(player);
            itemNum[0].Draw();
        }
    }
}
