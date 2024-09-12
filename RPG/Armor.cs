namespace RPG
{
    public class Helm
    {
        public string Name { get; }

        private float _armor;
        public float Armor
        {
            get => _armor;
            set
            {
                if (value < 0f) _armor = 0f;
                else if (value > 1f) _armor = 1f;
                else _armor = value;
                Console.WriteLine($"Броня {Name} настроена на: {_armor}");
            }
        }

        public Helm()
        {
            Name = "Helm";
        }
    }

    public class Shell
    {
        public string Name { get; }
        private float _armor;
        public float Armor
        {
            get => _armor;
            set
            {
                if (value < 0f) _armor = 0f;
                else if (value > 1f) _armor = 1f;
                else _armor = value;
                Console.WriteLine($"Броня {Name} настроена на: {_armor}");
            }
        }

        public Shell()
        {
            Name = "Shell";
        }
    }

    public class Boots
    {
        public string Name { get; }
        private float _armor;
        public float Armor
        {
            get => _armor;
            set
            {
                if (value < 0f) _armor = 0f;
                else if (value > 1f) _armor = 1f;
                else _armor = value;
                Console.WriteLine($"Броня {Name} настроена на: {_armor}");
            }
        }

        public Boots()
        {
            Name = "Boots";
        }
    }

}
