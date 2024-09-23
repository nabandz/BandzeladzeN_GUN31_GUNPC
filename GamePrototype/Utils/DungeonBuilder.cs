using GamePrototype.Dungeon;
using GamePrototype.Items.EconomicItems;

namespace GamePrototype.Utils
{
    public static class DungeonBuilder
    {
        public static DungeonRoom BuildDungeon()
        {
            var enter = new DungeonRoom("Enter");
            var monsterRoom = new DungeonRoom("Monster", UnitFactoryDemo.CreateGoblinEnemy());
            var emptyRoom = new DungeonRoom("Empty");
            var lootRoom = new DungeonRoom("Loot1", new Gold());
            var lootStoneRoom = new DungeonRoom("Loot1", new Grindstone("Stone"));
            var finalRoom = new DungeonRoom("Final", new Grindstone("Stone1"));

            enter.TrySetDirection(Direction.Right, monsterRoom);
            enter.TrySetDirection(Direction.Left, emptyRoom);

            monsterRoom.TrySetDirection(Direction.Forward, lootRoom);
            monsterRoom.TrySetDirection(Direction.Left, emptyRoom);

            emptyRoom.TrySetDirection(Direction.Forward, lootStoneRoom);

            lootRoom.TrySetDirection(Direction.Forward, finalRoom);
            lootStoneRoom.TrySetDirection(Direction.Forward, finalRoom);

            return enter;
        }
    }

    public abstract class DungeonFactory
    {
        public abstract DungeonRoom CreateDungeon();
    }

    public class EasyDungeonFactory : DungeonFactory
    {
        public override DungeonRoom CreateDungeon()
        {
            UnitFactory factory = new EasyUnitFactory();

            var enter = new DungeonRoom("Enter");
            var emptyRoom = new DungeonRoom("Empty");
            var lootRoom = new DungeonRoom("Loot", new Gold());
            var monsterRoom = new DungeonRoom("Monster", factory.CreateGoblinEnemy());

            enter.TrySetDirection(Direction.Right, emptyRoom);
            emptyRoom.TrySetDirection(Direction.Forward, lootRoom);
            lootRoom.TrySetDirection(Direction.Forward, monsterRoom);

            return enter;
        }
    }

    public class HardDungeonFactory : DungeonFactory
    {
        public override DungeonRoom CreateDungeon()
        {
            UnitFactory factory = new HardUnitFactory();

            var enter = new DungeonRoom("Enter");
            var monsterRoom = new DungeonRoom("Monster", factory.CreateGoblinEnemy());
            var lootRoom = new DungeonRoom("Loot", new Gold());
            var finalRoom = new DungeonRoom("Final", new Grindstone("Grindstone"));

            enter.TrySetDirection(Direction.Right, monsterRoom);
            monsterRoom.TrySetDirection(Direction.Forward, lootRoom);
            lootRoom.TrySetDirection(Direction.Forward, finalRoom);

            return enter;
        }
    }
}
