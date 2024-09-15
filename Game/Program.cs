namespace Game
{
    class Program
    {
        static void Main(string[] args)
        {
            string savePath = AppDomain.CurrentDomain.BaseDirectory;

            var saveLoadService = new FileSystemSaveLoadService(savePath);

            var casino = new Casino(saveLoadService);

            casino.StartGame();
        }
    }
}