using Game.Runtime.Behavior.Characters.Professions.Harvester;
using UnityEngine;

namespace Game.Runtime.Environment.Mines
{
    public class MineStack : MonoBehaviour, IResourceStack<IMine>
    {
        private ResourceStack<IMine> _stack;

        private void Awake()
        {
            var mines = GetComponentsInChildren<Mine>();
            _stack = new ResourceStack<IMine>(mines);
        }

        private void OnDestroy()
        {
            _stack.Dispose();
        }

        public bool HasResource => _stack.HasResource;
        public IMine Pop() => _stack.Pop();
    }
}