using Game.Runtime.Rendering.Characters;
using UnityEngine;

namespace Game.Runtime.Rendering.Tiles
{
    public class RenderLibrary : MonoBehaviour, IRenderLibrary
    {
        [SerializeField] private TileMapRenderer _tileMapRenderer;
        [SerializeField] private CharacterRenderer _characterRenderer;
        
        public void Execute(long time)
        {
            throw new System.NotImplementedException();
        }

        public ITileMapRenderer TileMapRenderer => _tileMapRenderer;
        public ICharacterRenderer CharacterRenderer => _characterRenderer;
    }
}