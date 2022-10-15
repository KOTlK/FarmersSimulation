﻿using System;
using Game.Runtime.Random;
using Game.Runtime.View.Characters;
using UnityEngine;

namespace Game.Runtime.Characters
{
    [RequireComponent(typeof(Rigidbody2D))]
    public abstract class Character : MonoBehaviour, ICharacter
    {
        [SerializeField] private string _name = "Bob";
        [SerializeField] private float _age = 18f;
        [SerializeField] private float _speed = 5f;

        private Rigidbody2D _rigidbody;

        public void Initialize(IRandomGenerator<string> randomName, IRandomGenerator<float> randomAge)
        {
            _name = randomName.Next();
            _age = randomAge.Next();
        }
        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody2D>();
        }

        public abstract Party Party { get; }
        public abstract Profession Profession { get; }
        public Vector2 Position => _rigidbody.position;

        public void Move(Vector2 direction)
        {
            if (direction.sqrMagnitude > 1.1f)
                throw new ArgumentException($"{nameof(direction)} should be normalized, now it's magnitude is {direction.sqrMagnitude}", nameof(direction));
            
            var deltaMovement = direction * _speed * Time.deltaTime;
            _rigidbody.MovePosition(_rigidbody.position + deltaMovement);
        }

        public void Visualize(ICharacterView view)
        {
            view.DisplayAge(_age);
            view.DisplayName(_name);
            view.DisplayProfession(Profession);
        }
    }
}