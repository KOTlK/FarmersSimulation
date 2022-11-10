using System.Collections.Generic;

namespace Game.Runtime.Resources
{
    public interface IReadonlyResourceStorage
    {
        int Count(Resource resource);
        int Count(IEnumerable<Resource> resources);
        bool EnoughSpace(int amount);
    }
}