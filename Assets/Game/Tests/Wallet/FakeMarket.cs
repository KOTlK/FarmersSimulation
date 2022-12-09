using Game.Runtime.Market;
using Game.Runtime.Resources;

namespace Game.Tests.Wallet
{
    public class FakeMarket : IMarket
    {
        private readonly int _price;

        public FakeMarket(int price)
        {
            _price = price;
        }

        public int Price(Resource resource)
        {
            return _price;
        }
    }
}