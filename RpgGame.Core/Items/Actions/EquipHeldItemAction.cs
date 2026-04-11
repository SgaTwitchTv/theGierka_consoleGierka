using RpgGame.Core.Entities;
using RpgGame.Core.Inventory.Actions;
using RpgGame.Core.Items.Equipping;

namespace RpgGame.Core.Items.Actions
{
    public sealed class EquipHeldItemAction : InventoryActionBase
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

        public override void Execute()
        {
            _player.Hands.EquipHeldItem(_item, _slot);
        }
    }
}
