namespace RPG
{
    public class Weapon
    {
        public string Name { get; }
        public Interval DamageRange { get; private set; }

        public Weapon(string name, float minDamage, float maxDamage)
        {
            Name = name;
            DamageRange = new Interval(minDamage, maxDamage);
        }

        public float GetDamage()
        {
            return DamageRange.Get();
        }
    }
}
