using System;

namespace Game.Runtime.Math.Vectors
{
    public readonly struct Vector2Int : IEquatable<Vector2Int>
    {
        public Vector2Int(int x, int y)
        {
            X = x;
            Y = y;
        }

        public static Vector2Int Zero = new(0, 0);
        
        public int X { get; }
        public int Y { get; }

        public Vector2Int Normalized
        {
            get
            {
                var invertedLength = 1f / (float)System.Math.Sqrt(X * X + Y * Y);
                var x = (int)(X * invertedLength);
                var y = (int)(Y * invertedLength);
                return new Vector2Int(x, y);
            }
        }

        public static Vector2Int operator +(Vector2Int first, Vector2Int second)
        {
            return new Vector2Int(first.X + second.X, first.Y + second.Y);
        }

        public static Vector2Int operator -(Vector2Int first, Vector2Int second)
        {
            return new Vector2Int(first.X - second.X, first.Y - second.Y);
        }

        public static Vector2Int operator *(Vector2Int vector, int multiplier)
        {
            return new Vector2Int(vector.X * multiplier, vector.Y * multiplier);
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