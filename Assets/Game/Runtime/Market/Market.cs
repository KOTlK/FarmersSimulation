using System.Collections.Generic;
using Game.Runtime.Resources;

namespace Game.Runtime.Market
{
    public class Market : IMarket
    {
        private readonly Dictionary<Resource, int> _prices = new()
        {
            {Resource.Wheat, 10},
            {Resource.Bread, 15},
            {Resource.Copper, 15},
            {Resource.Iron, 25},
            {Resource.Silver, 35},
            {Resource.Gold, 50}
        };

        public int Price(Resource resource) => _prices[resource];
    }
}