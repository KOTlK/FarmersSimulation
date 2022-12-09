using Game.Runtime.Resources;

namespace Game.Game.Runtime.Factories
{
    public interface IBlueprint
    {
        bool CanBeCrafted(IResourceStorage storage);
        IResourcePack Craft(IResourceStorage incomeStorage);
    }
}