using System.Collections.Generic;
using System.Linq;
using Game.Runtime.Math.Vectors;

namespace Game.Runtime.TileMap.Pathfinding
{
    public class AStar : IAlgorithm
    {
        private readonly IHeuristic _heuristic;
        private readonly IGraph _tileGraph;

        private const int ConstantCost = 1;

        public AStar(IHeuristic heuristic, IGraph tileGraph)
        {
            _heuristic = heuristic;
            _tileGraph = tileGraph;
        }

        public IPath FindPath(Vector2Int @from, Vector2Int to)
        {
            var queue = new PriorityQueue<Vector2Int>();
            var path = new Dictionary<Vector2Int, Vector2Int>();
            var cost = new Dictionary<Vector2Int, double>();
            
            queue.Enqueue(from, 0);
            path[from] = from;
            cost[from] = 0;

            while (queue.Count > 0)
            {
                var current = queue.Dequeue();

                if (current == to)
                    break;

                foreach (var next in _tileGraph.Neighbours(current))
                {
                    var newCost = cost[current] + _tileGraph.Cost(current, next);

                    if (cost.ContainsKey(next) == false || newCost < cost[next])
                    {
                        cost[next] = newCost;
                        var priority = newCost + _heuristic.Value(next, to);
                        queue.Enqueue(next, priority);
                        path[next] = current;
                    }
                }
            }

            var calculatedPath = new List<Vector2Int>();
            var currentPoint = to;
            calculatedPath.Add(currentPoint);

            while (currentPoint != from)
            {
                currentPoint = path[currentPoint];
                calculatedPath.Add(currentPoint);
            }

            calculatedPath.Add(from);
            calculatedPath.Reverse();

            return new Path(calculatedPath);
        }
    }
}