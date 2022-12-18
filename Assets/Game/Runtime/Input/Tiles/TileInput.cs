using System;
using Game.Runtime.View.Field;
using UnityEngine;
using Vector2Int = Game.Runtime.Math.Vectors.Vector2Int;

namespace Game.Runtime.Input.Tiles
{
    public class TileInput : MonoBehaviour, IClickInput<Vector2Int>
    {
        public event Action<Vector2Int> Clicked = delegate {  };

        [SerializeField] private Tile _tile;

        private void OnMouseDown()
        {
            Clicked.Invoke(_tile.Position);
        }
    }
}