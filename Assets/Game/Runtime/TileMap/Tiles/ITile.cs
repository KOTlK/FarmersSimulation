using Game.Runtime.Rendering.Tiles;
using Game.Runtime.View;

namespace Game.Runtime.TileMap.Tiles
{
    public interface ITile : ITransform, IVisualization<ITileMapRenderer>
    {
    }
}