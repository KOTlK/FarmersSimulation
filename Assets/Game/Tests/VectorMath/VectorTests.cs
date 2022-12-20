using Game.Runtime.Math.Vectors;
using NUnit.Framework;

namespace Game.Tests.VectorMath
{
    public class VectorTests
    {
        [Test]
        public void VectorsWillBeEquals()
        {
            var first = Vector2Int.Zero;
            var second = Vector2Int.Zero;

            Assert.True(first == second);

            var third = new Vector2Int(10, 10);
            var fourth = new Vector2Int(10, 10);

            Assert.True(third == fourth);
        }

        [Test]
        public void VectorsWillSum()
        {
            var first = new Vector2Int(10, 10);
            var second = new Vector2Int(10, 10);

            var total = first + second;

            Assert.True(total == new Vector2Int(20, 20));
        }

        [Test]
        public void VectorWillMultiply()
        {
            var vector = new Vector2Int(10, 10);
            var multiplier = 2;

            var total = vector * multiplier;

            Assert.True(total == new Vector2Int(20, 20));
        }

        [Test]
        public void VectorWillSubtract()
        {
            var first = new Vector2Int(10, 10);
            var second = new Vector2Int(5, 5);

            var total = first - second;

            Assert.True(total.Equals(second));
        }
    }
}