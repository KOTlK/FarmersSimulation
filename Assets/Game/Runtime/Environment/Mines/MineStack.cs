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
            Debug.Log(mines.Length);
        }

        public bool HasResource => _stack.HasResource;
        public IMine Pop() => _stack.Pop();
    }
}