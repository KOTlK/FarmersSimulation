using UnityEngine;

namespace Game.Runtime.Characters.Weapons
{
    public interface IProjectile
    {
        Vector2 Position { get; set; }
        void Shoot(Vector2 direction);
    }
}