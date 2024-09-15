namespace Game
{
    public class PlayerProfile
    {
        public string Name { get; set; }
        public decimal Bank { get; private set; }

        private const decimal MaxBank = 10000m;

        public PlayerProfile(string name, decimal initialBank)
        {
            Name = name;
            Bank = initialBank;
        }

        public bool CanPlaceBet(decimal bet)
        {
            return bet > 0 && bet <= Bank;
        }

        public void WinBet(decimal amount)
        {
            Bank += amount;
            if (Bank > MaxBank)
            {
                decimal excess = Bank - MaxBank;
                Bank = MaxBank;
                Console.WriteLine($"You broke the bank and took the excess {excess}.");
            }
        }

        public void LoseBet(decimal amount)
        {
            Bank -= amount;
        }
    }
}
