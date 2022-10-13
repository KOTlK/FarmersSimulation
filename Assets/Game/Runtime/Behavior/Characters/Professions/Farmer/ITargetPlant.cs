using Game.Runtime.Environment.Crops;

namespace Game.Runtime.Behavior.Characters.Professions.Farmer
{
    public interface ITargetPlant : IPlant
    {
        bool HasTarget { get; }
        void NewTarget(IPlant plant);
        void Reset();
    }
}