using UnityEngine;
using Vector2Int = Game.Runtime.Math.Vectors.Vector2Int;

namespace Game.Runtime.View.TileGraph
{
    public class PathView : MonoBehaviour, ITileGraphView
    {
        [SerializeField] private bool _drawGraph;
        
        public void DisplayDirection(Vector2Int @from, Vector2Int to)
        {
            if (_drawGraph == false)
                return;

            Debug.DrawLine(transform.TransformPoint(new Vector3(from.X, from.Y)),
                           transform.TransformPoint(new Vector3(to.X, to.Y)),
                           Color.blue,
                           10f
            );
        }

    }
}