using System;
using System.Collections.Generic;
using System.Text;
using RpgGame.Core.Items;

namespace RpgGame.Core.Inventory
{
    public sealed class Inventory   // Inventory class
    {
        private readonly List<IItem> _items = new();

        public IReadOnlyList<IItem> Items => _items;

        public void Add(IItem item) => _items.Add(item);        // Item add

        public bool TryRemoveAt(int index, out IItem? item)  // Item remove
        {
            if (index < 0 || index >= _items.Count)
            {
                item = null;
                return false;
            }

            item = _items[index];
            _items.RemoveAt(index);
            return true;
        }
    }
}
