using Game.Runtime.TileMap.Tiles;

namespace Game.Runtime.Market.Employers
{
    public interface IFarm : IEmployer
    {
        void AddField(ITile tile);
    }
}