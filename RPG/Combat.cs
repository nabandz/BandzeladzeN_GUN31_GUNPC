namespace RPG
{
    public struct Interval
    {
        public float Min { get; private set; }
        public float Max { get; private set; }

        public Interval(int minValue, int maxValue) : this((float)minValue, (float)maxValue) { }

        public Interval(float minValue, float maxValue)
        {
            if (minValue > maxValue)
            {
                Console.WriteLine("Некорректные параметры интервала, значения будут поменяны местами.");
                float temp = minValue;
                minValue = maxValue;
                maxValue = temp;
            }

            Min = minValue;
            Max = maxValue;
        }

        public Interval(float value) : this(value, value) { }

        public float Get()
        {
            Random rand = new Random();
            return (float)(rand.NextDouble() * (Max - Min) + Min);
        }

        public float Average => (Min + Max) / 2f;
    }

    public struct Rate
    {
        public Unit Unit { get; private set; }
        public float Damage { get; private set; }
        public float Health { get; private set; }

        public Rate(Unit unit, float damage, float health)
        {
            Unit = unit;
            Damage = MathF.Round(damage, 2);
            Health = MathF.Round(health, 2);
        }

        public override string ToString()
        {
            return $"Боец {Unit.Name} нанёс урон {Damage} и оставил {Health} здоровья.";
        }
    }

    public class Combat
    {
        private List<Rate> _rates;
        private Random _random;

        public Combat()
        {
            _rates = new List<Rate>();
            _random = new Random();
        }

        public void StartCombat(Unit unit1, Unit unit2)
        {
            Console.WriteLine("Начало боя!");
            while (unit1.Health > 0 && unit2.Health > 0)
            {
                int roll = _random.Next(1, 11);

                if (roll % 2 == 0)
                {
                    float damage = unit2.Damage;
                    if (unit1.SetDamage(damage))
                    {
                        Console.WriteLine($"{unit1.Name} был побеждён!");
                        break;
                    }
                    _rates.Add(new Rate(unit2, damage, unit1.Health));
                }
                else
                {
                    float damage = unit1.Damage;
                    if (unit2.SetDamage(damage))
                    {
                        Console.WriteLine($"{unit2.Name} был побеждён!");
                        break;
                    }
                    _rates.Add(new Rate(unit1, damage, unit2.Health));
                }
            }
            Console.WriteLine("Бой завершён!");
        }

        public void ShowResults()
        {
            foreach (var rate in _rates)
            {
                Console.WriteLine(rate);
            }
        }
    }
}
