using System.Collections.Generic;

namespace Game.Runtime.Input
{
    public class ClickQueue<T> : IClickQueue<T>
    {
        private readonly Queue<T> _clickedCharacters = new();

        public ClickQueue(IEnumerable<IClickInput<T>> inputs)
        {
            foreach (var input in inputs)
            {
                input.Clicked += OnClick;
            }
        }

        public bool HasUnreadInput => _clickedCharacters.Count > 0;
        
        public T GetInput()
        {
            var character = _clickedCharacters.Dequeue();
            Clear();
            return character;
        }

        public void Clear()
        {
            _clickedCharacters.Clear();
        }

        private void OnClick(T target)
        {
            _clickedCharacters.Enqueue(target);
        }
    }
}