using System.Collections.Generic;
using Game.Runtime.Characters.Professions.Warrior;
using UnityEngine;

namespace Game.Runtime.Characters.Weapons
{
    [RequireComponent(typeof(BoxCollider2D))]
    public class WeaponTargets : MonoBehaviour, IWeaponTargets
    {
        [SerializeField] private Transform _colliderLowestYBound;
        private readonly List<IDamageable> _targets = new();

        private BoxCollider2D _collider;

        private void Awake()
        {
            _collider = GetComponent<BoxCollider2D>();
            _collider.isTrigger = true;
            SetRange(_collider.size.y);
            SetWidth(_collider.size.x);
        }

        public IEnumerable<IDamageable> TargetsInRange => _targets;
        
        public void SetRange(float range)
        {
            var position = _colliderLowestYBound.localPosition;
            var size = _collider.size;
            size.y = range;
            _collider.size = size;
            position.y += range / 2;
            transform.localPosition = position;
        }

        public void SetWidth(float width)
        {
            var size = _collider.size;
            size.x = width;
            _collider.size = size;
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.TryGetComponent(out IDamageable target))
            {
                _targets.Add(target);
            }
        }

        private void OnTriggerExit2D(Collider2D other)
        {
            if (other.TryGetComponent(out IDamageable target))
            {
                _targets.Remove(target);
            }
        }
    }
}