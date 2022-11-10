using UnityEngine;

namespace Game.Runtime.Characters
{
    public interface IMovement
    {
        Vector2 Direction { get; set; }
    }
}