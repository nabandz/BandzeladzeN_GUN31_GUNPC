using RPG;
using System.Reflection;

public class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Подготовка к бою:");

        Console.WriteLine("Введите имя бойца:");
        string unitName = Console.ReadLine();

        float health = GetValidatedInput("Введите начальное здоровье бойца (10-100):", 10f, 100f);

        float helmArmor = GetValidatedInput("Введите значение брони шлема от 0 до 1:", 0f, 1f);
        float shellArmor = GetValidatedInput("Введите значение брони кирасы от 0 до 1:", 0f, 1f);
        float bootsArmor = GetValidatedInput("Введите значение брони сапог от 0 до 1:", 0f, 1f);

        float minDamage = GetValidatedInput("Укажите минимальный урон оружия (0-20):", 0f, 20f);
        float maxDamage = GetValidatedInput("Укажите максимальный урон оружия (20-40):", 20f, 40f);

        Unit player = new Unit(unitName);
        player.SetHealth(health);

        Helm helm = new Helm { Armor = helmArmor };
        Shell shell = new Shell { Armor = shellArmor };
        Boots boots = new Boots { Armor = bootsArmor };

        player.EquipHelm(helm);
        player.EquipShell(shell);
        player.EquipBoots(boots);

        Weapon weapon = new Weapon("Sword", minDamage, maxDamage);
        player.EquipWeapon(weapon);

        Console.WriteLine($"Общий показатель брони равен: {player.Armor}");
        Console.WriteLine($"Фактическое значение здоровья равно: {player.RealHealth}");
    }

    // Метод для проверки ввода
    private static float GetValidatedInput(string message, float minValue, float maxValue)
    {
        float value = 0f;
        bool isValid = false;

        while (!isValid)
        {
            Console.WriteLine(message);
            string input = Console.ReadLine();
            if (float.TryParse(input, out value) && value >= minValue && value <= maxValue)
            {
                isValid = true;
            }
            else
            {
                Console.WriteLine($"Ошибка: введите корректное число в диапазоне от {minValue} до {maxValue}.");
            }
        }

        return value;
    }
}

