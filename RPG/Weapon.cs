namespace RPG
{
    public class Weapon
    {
        public string Name { get; }
        private float _minDamage;
        private float _maxDamage;

        public Weapon(string name)
        {
            Name = name;
        }

        public Weapon(string name, float minDamage, float maxDamage) : this(name)
        {
            SetDamageParams(minDamage, maxDamage);
        }

        public void SetDamageParams(float minDamage, float maxDamage)
        {
            if (minDamage > maxDamage)
            {
                Console.WriteLine($"Некорректные параметры урона для {Name}, значения будут поменяны местами.");
                float temp = minDamage;
                minDamage = maxDamage;
                maxDamage = temp;
            }

            if (minDamage < 1f)
            {
                minDamage = 1f;
                Console.WriteLine($"Минимальный урон {Name} установлен на 1.");
            }

            if (maxDamage <= 1f)
            {
                maxDamage = 10f;
                Console.WriteLine($"Максимальный урон {Name} установлен на 10.");
            }

            _minDamage = minDamage;
            _maxDamage = maxDamage;
        }

        public float GetDamage()
        {
            return (_minDamage + _maxDamage) / 2f;
        }
    }
}
