using System.Collections.Generic;
using RpgGame.Core.Entities;
using RpgGame.Core.Inventory.Actions;
using RpgGame.Core.Items.Actions;
using RpgGame.Core.Items.Equipping;

namespace RpgGame.Core.Items
{
    public abstract class UnusableItem : Item
    {
        protected UnusableItem(string name, char symbol) : base(name, symbol) { }

        public override IEnumerable<IInventoryAction> GetInventoryActions(Player player)
        {
            yield return new EquipHeldItemAction(player, this, HandSlot.Left);
            yield return new EquipHeldItemAction(player, this, HandSlot.Right);
        }
    }
}
