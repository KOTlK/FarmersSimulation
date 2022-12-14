using System.Collections;
using System.Collections.Generic;
using Game.Runtime.Math.Vectors;
using Game.Runtime.View.TileGraph;

namespace Game.Runtime.TileMap.Pathfinding
{
    public class Path : IPath
    {
        private readonly IEnumerable<Vector2Int> _points;

        public Path(IEnumerable<Vector2Int> points)
        {
            _points = points;
        }

        public IEnumerator<Vector2Int> GetEnumerator() => _points.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => _points.GetEnumerator();
        public void Visualize(ITileGraphView view)
        {
            Vector2Int previous = new Zero();
            var zero = previous;
            
            foreach (var point in _points)
            {
                if (previous == zero)
                {
                    previous = point;
                    continue;
                }

                view.DisplayDirection(previous, point);
                previous = point;
            }
        }
    }
}