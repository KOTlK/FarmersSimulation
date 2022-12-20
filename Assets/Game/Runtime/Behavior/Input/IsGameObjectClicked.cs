using System.Collections.Generic;
using System.Linq;
using BananaParty.BehaviorTree;
using Game.Runtime.Input.Click;
using Game.Runtime.TileMap.Tiles;

namespace Game.Runtime.Behavior.Input
{
    public class IsGameObjectClicked<T> : BehaviorNode
    where T : ITransform
    {
        private readonly IEnumerable<T> _gameObjects;
        private readonly IMouse _mouse;

        public IsGameObjectClicked(IEnumerable<T> gameObjects, IMouse mouse)
        {
            _gameObjects = gameObjects;
            _mouse = mouse;
        }

        public override BehaviorNodeStatus OnExecute(long time)
        {
            if (_mouse.Clicked == false)
                return BehaviorNodeStatus.Failure;

            var obj = _gameObjects.FirstOrDefault(clicked => clicked.Position == _mouse.Position);

            if (obj == null)
                return BehaviorNodeStatus.Failure;

            return BehaviorNodeStatus.Success;
        }
    }
}