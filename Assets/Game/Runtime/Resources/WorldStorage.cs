using System.Collections.Generic;
using Game.Runtime.View.Storage;
using UnityEngine;

namespace Game.Runtime.Resources
{
    public class WorldStorage : MonoBehaviour, IWorldStorage
    {
        private readonly IResourcesStorage _storage = new ResourceStorage(int.MaxValue);

        public void Visualize(IResourceStorageView view) => _storage.Visualize(view);

        public int Count(Resource resource) => _storage.Count(resource);
        public int Count(IEnumerable<Resource> resource) => _storage.Count(resource);

        public bool EnoughSpace(int amount) => _storage.EnoughSpace(amount);
        public void Put(Resource resource, int amount = 1)
        {
            _storage.Put(resource, amount);
        }

        public IResourcePack Take(Resource resource, int amount = 1)
        {
            return _storage.Take(resource, amount);
        }

        public IResourcePack Take(IEnumerable<(Resource, int)> resources) => _storage.Take(resources);
        public IResourcePack Take(IEnumerable<Resource> resources) => _storage.Take(resources);
        public IResourcePack Take() => _storage.Take();

        public Vector2 Position => transform.position;
    }
}