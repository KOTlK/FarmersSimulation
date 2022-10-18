using Game.Runtime.Environment.Crops;
using Game.Runtime.Resources;
using Game.Runtime.View;
using Game.Runtime.View.Storage;

namespace Game.Runtime.Characters.Professions.Farmer
{
    public interface IFarmer : ICharacter, IVisualization<IResourceStorageView>
    {
        bool InventoryFull { get; }
        bool HasCollectedPlants { get; }
        void GatherPlant(ICollectable plant);
        void EmptyPockets(IResourcesStorage targetStorage);
    }
}