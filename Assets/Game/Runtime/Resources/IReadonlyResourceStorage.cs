using System.Collections.Generic;
using Game.Runtime.Market;

namespace Game.Runtime.Resources
{
    public interface IReadonlyResourceStorage
    {
        int Count();
        int Count(Resource resource);
        int Count(IEnumerable<Resource> resources);
        bool EnoughSpace(int amount);
        int CalculateCost(IMarket market);
    }
}