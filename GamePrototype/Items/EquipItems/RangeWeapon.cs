using GamePrototype.Utils;

namespace GamePrototype.Items.EquipItems
{
    public class RangeWeapon : Weapon
    {
        public RangeWeapon(uint damage, uint durability, string name) : base(damage, durability, name)
        {
        }

        public override EquipSlot Slot => EquipSlot.Weapon;
    }
}
