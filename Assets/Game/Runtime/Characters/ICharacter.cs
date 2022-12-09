﻿using Game.Runtime.Behavior.Characters.Professions;
using Game.Runtime.Characters.Professions;
using Game.Runtime.Environment.Crops;
using Game.Runtime.Resources;
using Game.Runtime.View;
using Game.Runtime.View.Characters;

namespace Game.Runtime.Characters
{
    public interface ICharacter : IMovement, ISceneObject, IWorker, IVisualization<ICharacterView>, IBehavior
    {
        Profession Profession { get; }
        bool InventoryFull { get; }
        bool HasResourceCollected { get; }
        void Harvest(ICollectable collectable);
        void EmptyPockets(IResourceStorage targetStorage);
    }
}