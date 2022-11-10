using Game.Runtime.Resources;

namespace Game.Game.Runtime.Factories
{
    public interface IBlueprint
    {
        bool CanBeCrafted(IResourcesStorage storage);
        IResourcePack Craft(IResourcesStorage incomeStorage);
    }
}