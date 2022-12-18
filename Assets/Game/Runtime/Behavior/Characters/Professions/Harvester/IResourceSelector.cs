using Game.Runtime.Environment.Crops;
using Game.Runtime.TileMap.Tiles;
using Game.Runtime.View;

namespace Game.Runtime.Behavior.Characters.Professions.Harvester
{
    public interface IResourceSelector<in T> : ICollectable, ITransform
    {
        void Select(T newObject);
        void Reset();
    }
}