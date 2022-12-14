using Game.Runtime.TileMap.Tiles;
using Game.Runtime.Resources;
using Vector2Int = Game.Runtime.Math.Vectors.Vector2Int;

namespace Game.Runtime.Factories
{
    public class Factory : IResourceFactory
    {
        private readonly IBlueprint _blueprint;
        private readonly IResourceStorage _incomeStorage;
        private readonly IResourceStorage _outcomeStorage;

        public Factory(IBlueprint blueprint, IResourceStorage incomeStorage, IResourceStorage outcomeStorage, Vector2Int position)
        {
            _blueprint = blueprint;
            _incomeStorage = incomeStorage;
            _outcomeStorage = outcomeStorage;
            Position = position;
        }

        public Vector2Int Position { get; }

        public IResourcePack Create() => _blueprint.Craft(_incomeStorage);

        public void Execute(long time)
        {
            if (_blueprint.CanBeCrafted(_incomeStorage))
            {
                Create().Transfer(_outcomeStorage);
            }
        }
    }
}