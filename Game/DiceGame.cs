namespace Game
{
    public class DiceGame : CasinoGameBase
    {
        private readonly List<Dice> _dices;

        public DiceGame(int diceCount, int min, int max)
        {
            if (diceCount < 1) throw new ArgumentException("Number of dice must be greater than 0");

            _dices = new List<Dice>();

            for (int i = 0; i < diceCount; i++)
            {
                _dices.Add(new Dice(min, max));
            }
        }

        protected override void FactoryMethod() { }

        public override void PlayGame()
        {
            int playerScore = RollDice();
            int computerScore = RollDice();

            Console.WriteLine($"Player score: {playerScore}");
            Console.WriteLine($"Computer score: {computerScore}");

            if (playerScore > computerScore)
            {
                OnWinInvoke();
            }
            else if (computerScore > playerScore)
            {
                OnLooseInvoke();
            }
            else
            {
                OnDrawInvoke();
            }
        }

        private int RollDice()
        {
            int score = 0;
            foreach (var dice in _dices)
            {
                score += dice.Number;
            }
            return score;
        }
    }
}
