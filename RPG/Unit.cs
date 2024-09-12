namespace RPG
{
    public class Unit
    {
        public string Name { get; }
        private float _health;
        private Weapon _weapon;
        private Helm _helm;
        private Shell _shell;
        private Boots _boots;

        public float Health => _health;
        private const float BaseDamage = 5f;

        public float Damage
        {
            get
            {
                return (_weapon != null ? _weapon.GetDamage() : 0) + BaseDamage;
            }
        }

        public float Armor
        {
            get
            {
                float totalArmor = 0f;
                if (_helm != null) totalArmor += _helm.Armor;
                if (_shell != null) totalArmor += _shell.Armor;
                if (_boots != null) totalArmor += _boots.Armor;
                return MathF.Round(totalArmor, 2);
            }
        }

        public Unit() : this("Unknown Unit") { }

        public Unit(string name)
        {
            Name = name;
        }

        public float RealHealth => Health * (1f + Armor);

        public bool SetDamage(float damage)
        {
            float effectiveDamage = damage * (1f - Armor);
            if (effectiveDamage < 1f) effectiveDamage = 1f;

            _health -= effectiveDamage;

            return _health <= 0f;
        }

        public void EquipWeapon(Weapon weapon)
        {
            _weapon = weapon;
        }

        public void EquipHelm(Helm helm)
        {
            _helm = helm;
        }

        public void EquipShell(Shell shell)
        {
            _shell = shell;
        }

        public void EquipBoots(Boots boots)
        {
            _boots = boots;
        }

        public void SetHealth(float health)
        {
            _health = health;
        }
    }
}
