using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Text_Based_RPG
{
    class Item
    {
        public enum ItemType
        {
            FirstAidKit,
            Shield,
            Key, 
            Valuable,
            Fist,
            BrassKnuckles,
            BaseballBat,
            Knife,
            Machete,
            Chainsaw
        }

        public ItemType itemType;
        public Tile itemTile = new Tile(' ', ConsoleColor.White);
        //determines if they are picked up or not...
        public bool pickingUp;
        public bool dropped;
        public bool used;
        public string infoMessage;
        //locations.....
        public int xLoc;
        public int yLoc;
        //what they are seen as
        public bool isShopItem = false;
        protected string name;
        private int price;
        private Shop shop;
        private Random rand = new Random(); 
        
        public Item()
        {
            SetPrice(rand.Next(Global.shopPriceMin, Global.shopPriceMax));
        }
        public virtual void Update(Map map, Player player, Inventory inventory, Camera camera, ItemManager itemManager)
        {
            if (isShopItem == true)
                itemTile.tileColour = ConsoleColor.Yellow;
            //Console.SetCursorPosition(1, 1);
            Console.WriteLine(infoMessage);
        }
        //draw method for items
        public void Draw(Camera camera)
        {
            camera.DrawToRenderer(itemTile.tileCharacter, xLoc, yLoc);
        }

        public bool IsShopItem()
        {
            return isShopItem;
        }
        public Shop GetShop()
        {
            return shop;
        }
        public void SetPrice(int priceToSet)
        {
            price = priceToSet;
        }
        public void SetShopItem(bool shopItemBoolean)
        {
            isShopItem = shopItemBoolean;
        }
        public int CheckPrice()
        {
            return price;
        }
        public void SetPosition(int x, int y)
        {
            xLoc = x;
            yLoc = y;
        }
        public void SetShop(Shop shopToSet)
        {
            shop = shopToSet;
        }
        public string CheckName()
        {
            return name;
        }

    }
}
