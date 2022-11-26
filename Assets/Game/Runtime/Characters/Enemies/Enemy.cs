using System;
using System.Linq;
using Game.Runtime.Characters.Enemies.DamageResistance;
using Game.Runtime.Characters.HP;
using Game.Runtime.Characters.Weapons;
using UnityEngine;

namespace Game.Runtime.Characters.Enemies
{
    public class Enemy : Character, IEnemy
    {
        [SerializeField] private float _minHp = 0f;
        [SerializeField] private float _maxHp = 100f;
        [SerializeField] private float _damageResistance = 2f;
        [SerializeField] private float _damage = 10f;
        [SerializeField] private WeaponTargets _targets;
        
        private IHealth _health;

        private void Start()
        {
            _health = new Armor(
                new Health(
                    _minHp, 
                    _maxHp), 
                _damageResistance);
        }

        public Party Party => Party.Enemy;

        public bool IsDead => _health.IsOver;

        public void ApplyDamage(float amount)
        {
            if (amount < 0)
                throw new ArgumentException(nameof(amount));

            _health.Lose(amount);
        }

        public void Attack()
        {
            _targets.TargetsInRange.First(target => target.Party != Party.Enemy).ApplyDamage(_damage);
        }
    }
}