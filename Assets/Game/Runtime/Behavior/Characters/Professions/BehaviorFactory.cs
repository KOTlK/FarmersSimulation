using System;
using BananaParty.BehaviorTree;
using Game.Runtime.Behavior.Characters.Professions.Harvester;
using Game.Runtime.Characters;
using Game.Runtime.Environment;
using Game.Runtime.TileMap;
using Game.Runtime.TileMap.Tiles.TileTypes;

namespace Game.Runtime.Behavior.Characters.Professions
{
    public class BehaviorFactory : IBehaviorsFactory
    {
        private readonly IResourceStack<CollectableResource> _wheatStack;
        private readonly IResourceStack<CollectableResource> _minesStack;
        private readonly IChest _testChest;
        private readonly ITileMap _tileMap;

        public BehaviorFactory(IResourceStack<CollectableResource> wheatStack, IResourceStack<CollectableResource> minesStack, IChest testChest, ITileMap tileMap)
        {
            _wheatStack = wheatStack;
            _minesStack = minesStack;
            _testChest = testChest;
            _tileMap = tileMap;
        }

        public IBehaviorNode Create(Profession type, ICharacter target)
        {
            return type switch
            {
                Profession.Miner => new HarvesterBehavior(target, _minesStack, _testChest, _tileMap),
                Profession.Farmer => new HarvesterBehavior(target, _wheatStack, _testChest, _tileMap),
                Profession.Civilian => new CivilianBehavior(target, _tileMap),
                _ => throw new ArgumentOutOfRangeException(nameof(type), type, null)
            };
        }
    }
}