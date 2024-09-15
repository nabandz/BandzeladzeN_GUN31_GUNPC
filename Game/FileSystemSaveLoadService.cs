﻿namespace Game
{
    public class FileSystemSaveLoadService : ISaveLoadService<string>
    {
        private readonly string _path;

        public FileSystemSaveLoadService(string path)
        {
            _path = path;

            if (!Directory.Exists(_path))
            {
                Directory.CreateDirectory(_path);
            }
        }

        public void SaveData(string data, string identifier)
        {
            string filePath = Path.Combine(_path, $"{identifier}.txt");
            File.WriteAllText(filePath, data);
        }

        public string LoadData(string identifier)
        {
            string filePath = Path.Combine(_path, $"{identifier}.txt");
            return File.Exists(filePath) ? File.ReadAllText(filePath) : null;
        }
    }
}
