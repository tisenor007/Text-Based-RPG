namespace Text_Based_RPG
{
    class Shopkeeper : GameCharacter
    {
        private Currency wallet;
        private string avatar = "C";
        private Player player;
        private Shop shop;

        public Shopkeeper(int x, int y, Player playerReference, Shop shopReference)
        {
            shop = shopReference;
            player = playerReference;
            characterTile.tileCharacter = 'C';
            xLoc = x;
            yLoc = y;
        }
        public override void Update()
        {
            switch(player.isPlayerAt(xLoc, yLoc))
            {
                case true:
                    shop.SellMenu();
                    break;
                case false:
                    break;
            }
        }

        public void Disappear()
        {
            xLoc = 0;
            yLoc = 0;
        }
    }
}
