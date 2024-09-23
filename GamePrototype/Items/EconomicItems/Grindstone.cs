using GamePrototype.Items.EquipItems;

namespace GamePrototype.Items.EconomicItems
{
    public class Grindstone : EconomicItem
    {
        public override bool Stackable => false;

        public Grindstone(string name) : base(name)
        {
        }

        public void RepairItem(EquipItem item)
        {
            item.Repair(5);
        }
    }
}
