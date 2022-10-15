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
        
        private int _capacity = 0;

        public Storage(int maxCapacity)
        {
            _maxCapacity = maxCapacity;
        }

        public bool IsFull => _capacity == _maxCapacity;

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

            _capacity++;
        }

        public TItem Take<TItem>()
        {
            var key = typeof(TItem);
            if (_items.ContainsKey(key) == false)
                throw new Exception($"Storage does not contains {typeof(TItem)}");

            var item = _items[key].Pop();
            
            if (_items[key].Count == 0)
                _items.Remove(key);

            _capacity--;
            return (TItem)item;
        }

        public void Visualize(IStorageView view)
        {
            var items = _items.Select(item => (item.Value.Last(), item.Value.Count));

            view.DisplayStorage(items);
        }
    }
}