using Game.Runtime.Factories;
using Game.Runtime.Rendering.Tiles;
using Game.Runtime.Resources;

namespace Game.Runtime.TileMap.Tiles.TileTypes
{
    public sealed class Factory : Decorator, IFactory
    {
        private IResourceStorage _income;
        private IResourceStorage _outcome;
        private readonly IBlueprint _blueprint;

        public Factory(ITile origin, IBlueprint blueprint) : base(origin)
        {
            _blueprint = blueprint;
        }

        public void Execute(long time)
        {
            if (_income == null)
                return;
            
            if (_blueprint.CanBeCrafted(_income))
            {
                Create().Transfer(_outcome);
            }
        }

        public IResourcePack Create() => _blueprint.Craft(_income);
        
        public override void Visualize(ITileMapRenderer view)
        {
            view.SwitchTileInPosition(Position, TileType.Factory);
        }

        public void InstallIncomeStorage(IResourceStorage storage)
        {
            _income = storage;
        }

        public void InstallOutcomeStorage(IResourceStorage storage)
        {
            _outcome = storage;
        }
    }
}