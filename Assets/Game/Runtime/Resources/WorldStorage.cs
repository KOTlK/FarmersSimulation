using Game.Runtime.View.Storage;
using UnityEngine;

namespace Game.Runtime.Resources
{
    public class WorldStorage : MonoBehaviour, IWorldStorage
    {
        private readonly IResourcesStorage _storage = new ResourceStorage(int.MaxValue);

        public void Visualize(IResourceStorageView view) => _storage.Visualize(view);

        public bool HasResource(Resource resource, int amount = 1) => _storage.HasResource(resource, amount);

        public int Count(Resource resource) => _storage.Count(resource);

        public bool EnoughSpace(int amount) => _storage.EnoughSpace(amount);

        public bool IsFull => _storage.IsFull;
        public void Put(Resource resource, int amount = 1)
        {
            _storage.Put(resource, amount);
        }

        public void Remove(Resource resource, int amount = 1)
        {
            _storage.Remove(resource, amount);
        }

        public Vector2 Position => transform.position;
    }
}