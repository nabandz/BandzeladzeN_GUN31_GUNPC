namespace Game
{
    public class Casino
    {
        private readonly ISaveLoadService<string> _saveLoadService;
        private PlayerProfile _player;

        public Casino(ISaveLoadService<string> saveLoadService)
        {
            _saveLoadService = saveLoadService;
        }

        public void StartGame()
        {
            Console.WriteLine("Welcome to the Casino!");

            LoadOrCreateProfile();

            while (true)
            {
                Console.WriteLine("Choose a game: 1 - Blackjack, 2 - Dice Game");
                string choice = Console.ReadLine();

                CasinoGameBase game;
                if (choice == "1")
                {
                    game = new BlackjackGame(10);
                }
                else if (choice == "2")
                {
                    game = new DiceGame(2, 1, 6);
                }
                else
                {
                    Console.WriteLine("Invalid choice.");
                    continue;
                }

                game.OnWin += () => _player.WinBet(10);
                game.OnLoose += () => _player.LoseBet(10);
                game.OnDraw += () => Console.WriteLine("It's a draw!");

                game.PlayGame();
                SaveProfile();

                Console.WriteLine("Do you want to play again? (y/n)");
                if (Console.ReadLine() != "y") break;
            }

            Console.WriteLine("Goodbye!");
        }

        private void LoadOrCreateProfile()
        {
            string data = _saveLoadService.LoadData("playerProfile");
            if (data == null)
            {
                Console.WriteLine("No profile found. Please enter your name:");
                string name = Console.ReadLine();
                _player = new PlayerProfile(name, 100);
                SaveProfile();
            }
            else
            {
                _player = new PlayerProfile(data, 100);
                Console.WriteLine($"Welcome back, {_player.Name}!");
            }
        }

        private void SaveProfile()
        {
            _saveLoadService.SaveData(_player.Name, "playerProfile");
        }
    }
}
