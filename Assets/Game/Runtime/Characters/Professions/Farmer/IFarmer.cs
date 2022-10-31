using Game.Runtime.Environment.Crops;
using Game.Runtime.Resources;
using Game.Runtime.View;
using Game.Runtime.View.Storage;

namespace Game.Runtime.Characters.Professions.Farmer
{
    public interface IFarmer : ICharacter, IVisualization<IResourceStorageView>, IHarvester
    {
    }
}