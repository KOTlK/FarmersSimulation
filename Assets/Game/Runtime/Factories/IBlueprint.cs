using Game.Runtime.Resources;

namespace Game.Runtime.Factories
{
    public interface IBlueprint
    {
        bool CanBeCrafted(IResourceStorage storage);
        IResourcePack Craft(IResourceStorage incomeStorage);
    }
}