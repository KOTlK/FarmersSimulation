using Game.Runtime.Environment.Crops;
using Game.Runtime.Math.Vectors;
using Game.Runtime.Resources;
using Game.Runtime.TileMap.Tiles;

namespace Game.Runtime.Behavior.Characters.Professions.Harvester
{
    public class ResourceSelector<T> : IResourceSelector<T>
    where T : class, ITransform, ICollectable
    {
        private T _origin;

        public void Select(T newObject)
        {
            _origin = newObject;
        }

        public void Reset()
        {
            _origin = null;
        }

        public bool ReadyForGather => _origin.ReadyForGather;
        public void PickUp(IResourceStorage storage) => _origin.PickUp(storage);
        public Vector2Int Position => _origin.Position;
    }
}