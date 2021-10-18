namespace Text_Based_RPG
{
    class Currency
    {
        private int amount;
        
        public void AddMoney(int addition)
        {
            amount += addition;
        }
        public void TakeMoney(int subtraction)
        {
            amount -= subtraction;
        }
        public int CheckMoney()
        {
            return amount;
        }
        public void SetMoney(int setMoney)
        {
            amount = setMoney;
        }
    }
}
