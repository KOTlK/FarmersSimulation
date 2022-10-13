using Game.Runtime.View.Storage;
using UnityEngine;

namespace Game.Runtime.Inventory
{
    public class WorldStorage : MonoBehaviour, IWorldStorage
    {
        [SerializeField] private StorageView _debug;
        private readonly IStorage _storage = new Storage(int.MaxValue);

        public bool IsFull => _storage.IsFull;
        public Vector2 Position => transform.position;
        public void Visualize(IStorageView view) => _storage.Visualize(view);

        public bool HasItem<TItem>() => _storage.HasItem<TItem>();

        public void Put<TItem>(IItem item)
        {
            _storage.Put<TItem>(item);
            Visualize(_debug);
        }

        public TItem Take<TItem>() => _storage.Take<TItem>();
    }
}