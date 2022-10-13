using BananaParty.BehaviorTree;
using Game.Runtime.Characters;
using UnityEngine;

namespace Game.Runtime.Behavior.Characters
{
    public class MoveToRandomDirectionNode : BehaviorNode
    {
        private readonly IMovement _origin;
        
        private Vector2 _direction;

        public MoveToRandomDirectionNode(IMovement origin)
        {
            _origin = origin;
            _direction = Random.insideUnitCircle.normalized;
        }

        public override BehaviorNodeStatus OnExecute(long time)
        {
            _origin.Move(_direction);
            return BehaviorNodeStatus.Running;
        }

        public override void Reset()
        {
            base.Reset();
            _direction = Random.insideUnitCircle.normalized;
        }
    }
}