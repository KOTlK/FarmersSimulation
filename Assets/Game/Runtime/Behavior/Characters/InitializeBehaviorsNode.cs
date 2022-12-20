using System.Collections.Generic;
using BananaParty.BehaviorTree;
using Game.Runtime.Behavior.Characters.Professions;
using Game.Runtime.Characters;

namespace Game.Runtime.Behavior.Characters
{
    public class InitializeBehaviorsNode : BehaviorNode
    {
        private readonly List<IBehaviorNode> _behaviors;
        private readonly List<ICharacter> _characters;
        private readonly IBehaviorsFactory _factory;
        private readonly System.Random _random = new();
        
        public InitializeBehaviorsNode(List<IBehaviorNode> behaviors, List<ICharacter> characters, IBehaviorsFactory factory)
        {
            _behaviors = behaviors;
            _characters = characters;
            _factory = factory;
        }

        public override BehaviorNodeStatus OnExecute(long time)
        {
            foreach (var character in _characters)
            {
                var behavior = _factory.Create(RandomProfession(), character);
                _behaviors.Add(behavior);
            }

            return BehaviorNodeStatus.Success;
        }

        private Profession RandomProfession()
        {
            var random = _random.Next(0, 100);

            return random switch
            {
                <= 50 => Profession.Farmer,
                _ => Profession.Miner
            };
        }
    }
}