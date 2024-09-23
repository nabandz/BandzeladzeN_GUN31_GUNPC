using GamePrototype.Items.EquipItems;
using GamePrototype.Units;

namespace GamePrototype.Utils
{
    public abstract class UnitFactory
    {
        public abstract Unit CreatePlayer(string name);
        public abstract Unit CreateEnemy();
        public abstract Unit CreateGoblinEnemy();
    }
    public class EasyUnitFactory : UnitFactory
    {
        public override Unit CreatePlayer(string name)
        {
            var player = new Player(name, 30, 30, 6);
            player.AddItemToInventory(new Weapon(8, 10, "Basic Sword"));
            return player;
        }

        public override Unit CreateEnemy() => CreateGoblinEnemy();

        public override Unit CreateGoblinEnemy()
        {
            return new Goblin(GameConstants.Goblin, 15, 15, 2);
        }
    }

    public class HardUnitFactory : UnitFactory
    {
        public override Unit CreatePlayer(string name)
        {
            var player = new Player(name, 40, 40, 8);
            player.AddItemToInventory(new Weapon(15, 20, "Advanced Sword"));
            player.AddItemToInventory(new Armour(10, 20, "Hard Armour"));
            return player;
        }

        public override Unit CreateEnemy() => CreateGoblinEnemy();

        public override Unit CreateGoblinEnemy()
        {
            return new Goblin(GameConstants.Goblin, 25, 25, 4);
        }
    }
}
