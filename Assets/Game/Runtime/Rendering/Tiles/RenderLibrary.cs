using UnityEngine;

namespace Game.Runtime.Rendering.Tiles
{
    public class RenderLibrary : MonoBehaviour, IRenderLibrary
    {
        [SerializeField] private TileMapRenderer _tileMapRenderer;
        public void Execute(long time)
        {
            throw new System.NotImplementedException();
        }

        public ITileMapRenderer TileMapRenderer => _tileMapRenderer;
    }
}