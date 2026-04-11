using RpgGame.Core.Combat;
using RpgGame.Core.Items.Equipping;

namespace RpgGame.Core.Items.Weapons
{
    public sealed class Wand : Weapon
    {
        public Wand() : base("Wand", 'w', damage: 4, defense: 1, category: new MagicalWeaponCategory(), handRequirement: new OneHandRequirement())
        {
        }
    }
}
