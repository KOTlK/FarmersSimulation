using UnityEngine;
using Vector2Int = Game.Runtime.Math.Vectors.Vector2Int;

namespace Game.Runtime.Rendering.Characters
{
    public class Character : MonoBehaviour
    {
        public void SetPosition(Vector2Int position)
        {
            transform.position = new Vector3(position.X, position.Y);
        }
    }
}