namespace Text_Based_RPG
{
    class Shopkeeper : GameCharacter
    {
        private char avatar = 'C';
        private Player player;
        private Shop shop;

        public Shopkeeper(int x, int y, Player playerReference, Shop shopReference)
        {
            shop = shopReference;
            player = playerReference;
            characterTile.tileCharacter = avatar;
            characterTile.tileColour = System.ConsoleColor.Yellow;
            xLoc = x;
            yLoc = y;
        }
        public override void Update()
        {
            switch(player.isPlayerAt(xLoc, yLoc))
            {
                case true:
                    player.ReturnToLastPosition();
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
