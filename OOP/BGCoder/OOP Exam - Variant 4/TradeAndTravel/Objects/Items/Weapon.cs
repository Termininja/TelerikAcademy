using System.Collections.Generic;

namespace TradeAndTravel
{
    public class Weapon : Item
    {
        // Field
        const int GeneralWeaponValue = 10;

        // Constructor
        public Weapon(string name, Location location = null)
            : base(name, Weapon.GeneralWeaponValue, ItemType.Weapon, location) { }
    }
}
