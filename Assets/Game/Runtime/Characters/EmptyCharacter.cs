using BananaParty.BehaviorTree;
using Game.Runtime.Environment.Crops;
using Game.Runtime.Market;
using Game.Runtime.Resources;
using Game.Runtime.View.Characters;
using UnityEngine;

namespace Game.Runtime.Characters
{
    public class EmptyCharacter : ICharacter
    {
        public void Visualize(ICharacterView view)
        {
            view.DisplayAge(0);
            view.DisplayName(" ");
        }

        public Vector2 Position => Vector2.negativeInfinity;
        public void Visualize(ITreeGraph<IReadOnlyBehaviorNode> view)
        {
        }

        public void Execute(long time)
        {
        }

        public Profession Profession => Profession.Civilian;
        public bool InventoryFull => true;
        public bool HasResourceCollected => false;
        public void Harvest(ICollectable collectable)
        {
        }

        public void EmptyPockets(IResourceStorage targetStorage)
        {
        }

        public Vector2 Direction { get; set; } = Vector2.zero;
        public Vector3 Rotation { get; set; } = Vector3.zero;
        public int CalculateSalary(IMarket market)
        {
            return 0;
        }

        public void PaySalary(int salary)
        {
        }
    }
}