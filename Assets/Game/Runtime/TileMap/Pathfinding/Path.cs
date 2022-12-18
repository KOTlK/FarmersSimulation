using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Game.Runtime.Math.Vectors;
using Game.Runtime.View.TileGraph;

namespace Game.Runtime.TileMap.Pathfinding
{
    public class Path : IPath
    {
        private readonly Vector2Int[] _points;
        private readonly int _maxIndex;
        private int _index;

        public Path(IEnumerable<Vector2Int> points)
        {
            _points = points.ToArray();
            _maxIndex = _points.Length - 1;
            _index = 0;
        }
        
        public Vector2Int Current { get; private set; }

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
        
        public bool Next()
        {
            if (_index + 1 > _maxIndex)
                return false;

            Current = _points[++_index];
            return true;
        }
    }
}