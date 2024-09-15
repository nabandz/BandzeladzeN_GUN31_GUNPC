namespace Game
{
    public class WrongDiceNumberException : Exception
    {
        public WrongDiceNumberException(int min, int max)
            : base($"Invalid dice range: {min} to {max}. The minimum must be greater than 0, and the maximum must be less than or equal to {int.MaxValue}.")
        {
        }
    }
}