using System;
using UnityEngine;

namespace Game.Runtime.Characters
{
    [RequireComponent(typeof(Rigidbody2D))]
    public abstract class Character : MonoBehaviour, ICharacter
    {
        [SerializeField] private float _speed = 5f;
        
        private Rigidbody2D _rigidbody;
        
        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody2D>();
        }

        protected virtual void FixedUpdate()
        {
            if (Direction != Vector2.zero)
                Move(Direction);
        }

        public Vector2 Direction { get; set; }
        public Vector2 Position => _rigidbody.position;

        private void Move(Vector2 direction)
        {
            if (direction.sqrMagnitude > 1.1f)
                throw new ArgumentException($"{nameof(direction)} should be normalized, now it's magnitude is {direction.sqrMagnitude}", nameof(direction));
            
            var deltaMovement = direction * _speed * Time.deltaTime;
            _rigidbody.MovePosition(_rigidbody.position + deltaMovement);
        }
    }
}