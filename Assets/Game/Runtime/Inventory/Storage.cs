using System;
using System.Collections.Generic;
using System.Linq;
using Game.Runtime.View.Storage;

namespace Game.Runtime.Inventory
{
    public class Storage : IStorage
    {
        private readonly Dictionary<Type, Stack<IItem>> _items = new();
        private readonly int _maxCapacity;

        public Storage(int maxCapacity)
        {
            _maxCapacity = maxCapacity;
        }

        public bool IsFull
        {
            get
            {
                var count = _items.Sum(item => item.Value.Count);
                return count >= _maxCapacity;
            }
        }

        public bool HasItem<TItem>() => _items.ContainsKey(typeof(TItem));

        public void Put<TItem>(IItem item)
        {
            if (IsFull)
                throw new Exception("Storage is already full");
            
            var key = typeof(TItem);

            if (_items.ContainsKey(key))
            {
                _items[key].Push(item);
            }
            else
            {
                _items.Add(key, new Stack<IItem>());
                _items[key].Push(item);
            }
        }

        public TItem Take<TItem>()
        {
            var key = typeof(TItem);
            if (_items.ContainsKey(key) == false)
                throw new Exception($"Storage does not contains {typeof(TItem)}");

            var item = _items[key].Pop();
            
            if (_items[key].Count == 0)
                _items.Remove(key);

            return (TItem)item;
        }

        public void Visualize(IStorageView view)
        {
            IEnumerable<IItem> items = new List<IItem>();

            items = _items.Aggregate(items, (current, item) => current.Concat(item.Value));

            view.DisplayStorage(items);
        }
    }
}