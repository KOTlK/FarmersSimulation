using System;

namespace Game.Runtime.Math.Vectors
{
    public class Vector2Int : IEquatable<Vector2Int>
    {
        public int X { get; }
        public int Y { get; }

        public Vector2Int(int x, int y)
        {
            X = x;
            Y = y;
        }

        public Vector2Int Normalized
        {
            get
            {
                var invertedLength = 1f / (float)System.Math.Sqrt(X * X + Y * Y);
                var x = Convert.ToInt32(X * invertedLength);
                var y = Convert.ToInt32(Y * invertedLength);
                return new Vector2Int(x, y);
            }
        }

        public override string ToString()
        {
            return $"Vector2Int({X}, {Y})";
        }

        public override bool Equals(object obj)
        {
            return Equals((Vector2Int) obj);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(X, Y);
        }

        public bool Equals(Vector2Int other)
        {
            return GetHashCode() == other.GetHashCode();
        }

        public static bool operator ==(Vector2Int first, Vector2Int second)
        {
            return first.Equals(second);
        }

        public static bool operator !=(Vector2Int first, Vector2Int second)
        {
            return !first.Equals(second);
        }
    }
}