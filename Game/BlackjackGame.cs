namespace Game
{
    public class BlackjackGame : CasinoGameBase
    {
        private Queue<Card> _deck;
        private List<Card> _playerHand;
        private List<Card> _computerHand;

        public BlackjackGame(int numberOfCards)
        {
            if (numberOfCards < 1) throw new ArgumentException("Number of cards must be greater than 0");

            FactoryMethod();
        }

        protected override void FactoryMethod()
        {
            _deck = new Queue<Card>();
            var suits = Enum.GetValues(typeof(CardSuit));
            var ranks = Enum.GetValues(typeof(CardRank));

            foreach (CardSuit suit in suits)
            {
                foreach (CardRank rank in ranks)
                {
                    _deck.Enqueue(new Card(suit, rank));
                }
            }

            Shuffle();
        }

        private void Shuffle()
        {
            var rnd = new Random();
            var deckArray = _deck.ToArray();
            _deck.Clear();

            foreach (var card in deckArray.OrderBy(x => rnd.Next()))
            {
                _deck.Enqueue(card);
            }
        }

        public override void PlayGame()
        {
            _playerHand = new List<Card> { _deck.Dequeue(), _deck.Dequeue() };
            _computerHand = new List<Card> { _deck.Dequeue(), _deck.Dequeue() };

            int playerScore = CalculateScore(_playerHand);
            int computerScore = CalculateScore(_computerHand);

            Console.WriteLine($"Player hand: {string.Join(", ", _playerHand)} - Score: {playerScore}");
            Console.WriteLine($"Computer hand: {string.Join(", ", _computerHand)} - Score: {computerScore}");

            if (playerScore > computerScore && playerScore <= 21)
            {
                OnWinInvoke();
            }
            else if (computerScore > playerScore && computerScore <= 21)
            {
                OnLooseInvoke();
            }
            else
            {
                OnDrawInvoke();
            }
        }

        private int CalculateScore(List<Card> hand)
        {
            int score = 0;
            foreach (var card in hand)
            {
                score += (int)card.Rank > 10 ? 10 : (int)card.Rank;
            }
            return score;
        }
    }
}
