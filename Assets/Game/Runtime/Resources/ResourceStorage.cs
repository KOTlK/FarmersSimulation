using System;
using System.Collections.Generic;
using System.Linq;
using Game.Runtime.View.Storage;

namespace Game.Runtime.Resources
{
    public class ResourceStorage : IResourcesStorage
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
            return _resources.ContainsKey(resource) == false ? 0 : _resources[resource];
        }

        public int Count(IEnumerable<Resource> resources)
        {
            return resources.Sum(Count);
        }

        public void Visualize(IResourceStorageView view)
        {
            view.DisplayStorage(_resources);
        }

        public bool EnoughSpace(int amount) => _count + amount <= _maxCapacity;

        public void Put(Resource resource, int amount = 1)
        {
            if (_count >= _maxCapacity)
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

        public IResourcePack Take(Resource resource, bool removeAll = false, int amount = 1)
        {
            var pack = new List<(Resource, int)>();
            var count = Count(resource);
            
            if (count < amount)
                throw new Exception($"Storage does not contains enough resource {nameof(resource)}");
            
            if (removeAll)
            {
                _resources[resource] -= count;
                _count -= count;
            }
            else
            {
                _resources[resource] -= amount;
                _count -= amount;
            }

            if (_resources[resource] == 0)
            {
                _resources.Remove(resource);
            }
            
            pack.Add((resource, count));

            return new ResourcePack(pack);
        }

        public IResourcePack Take(IEnumerable<(Resource, int)> resources)
        {
            var pack = new List<(Resource, int)>();
            
            foreach (var (resource, amount) in resources)
            {
                if (Count(resource) < amount)
                    throw new ArgumentException(nameof(resources));

                _resources[resource] -= amount;
                pack.Add((resource, amount));
            }

            return new ResourcePack(pack);
        }

        public IResourcePack Take(IEnumerable<Resource> resources)
        {
            var pack = new List<(Resource, int)>();
            
            foreach (var resource in resources)
            {
                var count = Count(resource);
                
                if (count == 0)
                    continue;

                _resources[resource] -= count;
                pack.Add((resource, count));
            }

            return new ResourcePack(pack);
        }
    }
}