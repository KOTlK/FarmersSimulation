using Game.Runtime.TileMap.Tiles;

namespace Game.Runtime.TileMap.Pathfinding
{
    public interface ICost
    {
        double TileCost(ITile tile);
    }
}