using System;
using System.Collections.Generic;
using Game.Runtime.View.Storage;

namespace Game.Runtime.Resources
{
    public class ResourceStorage: IResourcesStorage
    {
        private readonly Dictionary<Resource, int> _resources = new();

        private readonly int _maxCapacity;
        private int _count = 0;

        public ResourceStorage(int maxCapacity)
        {
            _maxCapacity = maxCapacity;
        }

        public int Count(Resource resource)
        {
            if (HasResource(resource) == false)
                throw new ArgumentException();

            return _resources[resource];
        }

        public void Visualize(IResourceStorageView view)
        {
            view.DisplayStorage(_resources);
        }

        public bool EnoughSpace(int amount) => _count + amount <= _maxCapacity;

        public bool HasResource(Resource resource, int amount = 1)
        {
            if (_resources.ContainsKey(resource) == false) return false;
            
            return _resources[resource] >= amount;
        }

        public bool IsFull => _count >= _maxCapacity;
        
        public void Put(Resource resource, int amount = 1)
        {
            if (IsFull)
                throw new Exception($"Storage is full");
            
            if (_count + amount > _maxCapacity)
                throw new Exception($"Not enough space");
            
            if (_resources.ContainsKey(resource))
            {
                _resources[resource] += amount;
            }
            else
            {
                _resources.Add(resource, amount);
            }

            _count += amount;
        }

        public void Remove(Resource resource, int amount = 1)
        {
            if (HasResource(resource, amount) == false)
                throw new Exception($"Storage does not contains enough resource {nameof(resource)}");

            _resources[resource] -= amount;

            if (_resources[resource] == 0)
            {
                _resources.Remove(resource);
            }

            _count -= amount;
        }
    }
}