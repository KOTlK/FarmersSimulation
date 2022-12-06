using System;
using UnityEngine;

namespace Game.Runtime.Characters
{
    public abstract class Character : MonoBehaviour, ICharacter
    {
        [SerializeField] private float _speed = 5f;

        protected virtual void Update()
        {
            if (Direction != Vector2.zero)
                Move(Direction);
        }

        public Vector2 Direction { get; set; }
        public Vector2 Position => transform.position;

        private void Move(Vector2 direction)
        {
            if (direction.sqrMagnitude > 1.1f)
                throw new ArgumentException($"{nameof(direction)} should be normalized, now it's magnitude is {direction.sqrMagnitude}", nameof(direction));
            
            var deltaMovement = direction * _speed * Time.deltaTime;
            transform.position += (Vector3)deltaMovement;
        }
    }
}