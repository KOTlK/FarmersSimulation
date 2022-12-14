using Game.Runtime.Session;

namespace Game.Runtime.Rendering.Tiles
{
    public interface IRenderLibrary : IGameLoop
    {
        ITileMapRenderer TileMapRenderer { get; }
    }
}