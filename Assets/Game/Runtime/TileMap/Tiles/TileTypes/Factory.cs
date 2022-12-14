using Game.Runtime.Factories;
using Game.Runtime.TileMap.Tiles;
using Game.Runtime.Math.Vectors;
using Game.Runtime.Rendering.Tiles;
using Game.Runtime.Resources;
using Game.Runtime.Session;

namespace Game.Runtime.TileMap.Tiles.TileTypes
{
    public sealed class Factory : ITile, IResourceFactory, IGameLoop
    {
        private readonly IResourceStorage _income;
        private readonly IResourceStorage _outcome;
        private readonly IBlueprint _blueprint;

        public Factory(Vector2Int position, IResourceStorage income, IResourceStorage outcome, IBlueprint blueprint)
        {
            Position = position;
            _income = income;
            _outcome = outcome;
            _blueprint = blueprint;
        }

        public void Execute(long time)
        {
            if (_blueprint.CanBeCrafted(_income))
            {
                Create().Transfer(_outcome);
            }
        }

        public bool Walkable { get; } = false;
        public Vector2Int Position { get; }

        public IResourcePack Create() => _blueprint.Craft(_income);
        public void Visualize(ITileMapRenderer view)
        {
            view.SwitchTileInPosition(Position, TileType.Factory);
        }
    }
}