using UnityEngine;

namespace Game.Runtime.Characters.Weapons
{
    public class Projectile : MonoBehaviour, IProjectile
    {
        public Vector2 Position { get; set; }

        public void Shoot(Vector2 direction)
        {
            throw new System.NotImplementedException();
        }
    }
}