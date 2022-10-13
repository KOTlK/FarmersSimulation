using UnityEngine;

namespace Game.Runtime.Characters
{
    public interface IMovement
    {
        void Move(Vector2 direction);
    }
}