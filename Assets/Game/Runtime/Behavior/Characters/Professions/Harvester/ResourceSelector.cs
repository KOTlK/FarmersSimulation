using Game.Runtime.Environment.Crops;
using Game.Runtime.Resources;
using Game.Runtime.View;
using UnityEngine;

namespace Game.Runtime.Behavior.Characters.Professions.Harvester
{
    public class ResourceSelector<T> : IResourceSelector<T>
    where T : class, ISceneObject, ICollectable
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
        public void PickUp(IResourcesStorage storage) => _origin.PickUp(storage);
        public Vector2 Position => _origin.Position;
    }
}