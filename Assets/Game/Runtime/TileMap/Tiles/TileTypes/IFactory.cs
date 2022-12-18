using Game.Runtime.Factories;
using Game.Runtime.Resources;
using Game.Runtime.Session;

namespace Game.Runtime.TileMap.Tiles.TileTypes
{
    public interface IFactory : ITile, IResourceFactory, IGameLoop
    {
        void InstallIncomeStorage(IResourceStorage storage);
        void InstallOutcomeStorage(IResourceStorage storage);
    }
}