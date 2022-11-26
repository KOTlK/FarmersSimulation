using Game.Runtime.Environment.Crops;
using Game.Runtime.Resources;

namespace Game.Runtime.Characters.Professions.Farmer
{
    public interface IHarvester : IFriendlyCharacter
    {
        bool InventoryFull { get; }
        bool HasResourceCollected { get; }
        void Harvest(ICollectable collectable);
        void EmptyPockets(IResourcesStorage targetStorage);
    }
}