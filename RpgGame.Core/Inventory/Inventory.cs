using System;
using System.Collections.Generic;
using System.Text;
using RpgGame.Core.Items;

namespace RpgGame.Core.Inventory
{
    public sealed class Inventory   // Inventory class
    {
        private readonly List<Item> _items = new();

        public IReadOnlyList<Item> Items => _items;

        public void Add(Item item) => _items.Add(item);        // Item add

        public bool TryRemoveAt(int index, out Item? item)  // Item remove
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
