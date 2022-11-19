using Game.Runtime.Characters.Professions.Warrior;
using UnityEngine;

namespace Game.Tests.PlayModeTests.Damage
{
    public class Damageable : MonoBehaviour, IDamageable
    {
        [SerializeField] private float _health = 10f;

        public bool IsDead => _health <= 0;
        public void ApplyDamage(float amount)
        {
            _health -= amount;
        }

        public void OnGUI()
        {
            var position = Camera.main.WorldToScreenPoint(transform.position);

            GUI.Label(
                new Rect(
                    position, 
                    new Vector2(50, 30)), 
                _health.ToString(), 
                new GUIStyle
            {
                fontSize = 30
            }
            );
        }
    }
}