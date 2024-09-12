using RPG;

public class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Подготовка к бою:");

        Unit player1 = new Unit("Воин");
        player1.SetHealth(100f);
        Weapon weapon1 = new Weapon("Меч", 10f, 30f);
        player1.EquipWeapon(weapon1);

        Unit player2 = new Unit("Орк");
        player2.SetHealth(100f);
        Weapon weapon2 = new Weapon("Топор", 15f, 25f);
        player2.EquipWeapon(weapon2);

        Console.WriteLine("Начало поединка!");

        Combat combat = new Combat();
        combat.StartCombat(player1, player2);

        Console.WriteLine("Результаты боя:");
        combat.ShowResults();
    }
}

