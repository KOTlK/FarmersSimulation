using Game.Runtime.TileMap.Tiles;
using UnityEngine;
using Vector2Int = Game.Runtime.Math.Vectors.Vector2Int;

namespace Game.Runtime.View.Field
{
    public class Tile : MonoBehaviour, ITileView
    {
        public bool Active
        {
            get => gameObject.activeSelf;
            set
            {
                if (gameObject.activeSelf == value)
                    return;
                
                gameObject.SetActive(value);
            }
        }

        [field: SerializeField] public TileType TileType { get; private set; }
        
        public Vector2Int Position { get; private set; }

        public void DisplayTile(Vector2Int position)
        {
            Position = position;
            transform.localPosition = new Vector3(position.X, position.Y);
        }

        public void Destroy()
        {
            Destroy(gameObject);
        }
    }
}