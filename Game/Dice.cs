namespace Game
{
    public struct Dice
    {
        private readonly int _min;
        private readonly int _max;

        public int Number { get; }

        public Dice(int min, int max)
        {
            if (min < 1 || max > int.MaxValue || min >= max)
            {
                throw new WrongDiceNumberException(min, max);
            }

            _min = min;
            _max = max;
            Number = new Random().Next(_min, _max + 1);
        }
    }
}
