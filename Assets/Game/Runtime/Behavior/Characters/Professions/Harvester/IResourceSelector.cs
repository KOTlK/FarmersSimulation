using Game.Runtime.Environment.Crops;
using Game.Runtime.View;

namespace Game.Runtime.Behavior.Characters.Professions.Harvester
{
    public interface IResourceSelector<in T> : ICollectable, ISceneObject
    {
        void Select(T newObject);
        void Reset();
    }
}