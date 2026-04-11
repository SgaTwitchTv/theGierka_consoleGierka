using RpgGame.Core.Entities;
using RpgGame.Core.Inventory.Actions;
using RpgGame.Core.Items.Equipping;

namespace RpgGame.Core.Items.Actions
{
    public sealed class EquipHeldItemAction : InventoryActionBase   // EquipHeldItemAction is a specific type of InventoryActionBase that allows a player to equip an item in either the left or right hand slot. It takes a Player object, an IItem object representing the item to be equipped, and a HandSlot enum indicating which hand to equip the item in. The Execute method calls the EquipHeldItem method on the player's Hands property, passing in the item and the specified hand slot.
    {
        private readonly Player _player;
        private readonly IItem _item;
        private readonly HandSlot _slot;

        public EquipHeldItemAction(Player player, IItem item, HandSlot slot) : base(slot == HandSlot.Left ? "Equip Left" : "Equip Right")
        {
            _player = player;
            _item = item;
            _slot = slot;
        }

        public override void Execute()  // The Execute method is overridden to perform the action of equipping the held item. It calls the EquipHeldItem method on the player's Hands property, passing in the item and the specified hand slot. This allows the player to equip the item in either the left or right hand, depending on the value of the _slot variable.
        {
            _player.Hands.EquipHeldItem(_item, _slot);
        }
    }
}
