using RpgGame.Core.Entities;
using RpgGame.Core.Inventory.Actions;

namespace RpgGame.Core.Items.Modifiers
{
    public abstract class ItemModifier : Item   // Base class for item modifiers that wrap around on existing item and modify its behavior
    {
        protected IItem Inner { get; }

        protected ItemModifier(IItem inner, string modifierName) : base($"{inner.Name} ({modifierName})", inner.Symbol)
        {
            Inner = inner;
        }

        public override bool GoesToInventory => Inner.GoesToInventory;

        public override void OnPickUp(Player player)    // When the item is picked up, we can apply any special logic from the modifier, but we also want to call the inner item's OnPickUp in case it has any special behavior when picked up (like auto-collecting currency)
        {
            Inner.OnPickUp(player);
        }

        public override IEnumerable<IInventoryAction> GetInventoryActions(Player player)    // An interface for getting the inventory actions that this item provides when it's in the player's inventory. We want to combine the actions from the inner item with any additional actions provided by the modifier
        {
            return Inner.GetInventoryActions(player);
        }

        public override PlayerStatModifier GetStatModifier() => Inner.GetStatModifier();    // By default, the modifier does not change the stat modifier of the inner item, but specific modifiers can override this to provide additional stat modifications on top of the inner item

        public override string GetDescription() => $"{Name} - {Inner.GetDescription()}";    // The description of the modifier item includes the name of the modifier and the description of the inner item, so that players can see both the base item and the modifier's effect in the description.
    }
}
