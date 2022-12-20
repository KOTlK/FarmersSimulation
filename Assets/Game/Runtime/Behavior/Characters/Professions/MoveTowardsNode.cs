using BananaParty.BehaviorTree;
using Game.Runtime.Behavior.Characters.Professions.Harvester;
using Game.Runtime.Characters;

namespace Game.Runtime.Behavior.Characters.Professions
{
    public class MoveTowardsNode : BehaviorNode
    {
        private readonly ICharacter _character;
        private readonly PathVariable _path;
        
        public MoveTowardsNode(ICharacter character, PathVariable path)
        {
            _character = character;
            _path = path;
        }

        public override BehaviorNodeStatus OnExecute(long time)
        {
            _path.Path.Next();
            
            if (_path.Path.Next())
            {
                var direction = _path.Path.Current - _character.Position;
                _character.Move(direction);
                return BehaviorNodeStatus.Running;
            }

            return BehaviorNodeStatus.Success;
        }

    }
}