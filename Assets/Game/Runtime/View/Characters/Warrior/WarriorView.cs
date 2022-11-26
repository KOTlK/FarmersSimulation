using Game.Runtime.Characters.Weapons;
using Game.Runtime.View.Health;
using Game.Runtime.View.Weapons;
using UnityEngine;

namespace Game.Runtime.View.Characters.Warrior
{
    public class WarriorView : MonoBehaviour, IWarriorView
    {
        [SerializeField] private WeaponView _weaponView;
        [SerializeField] private HealthView _healthView;
        
        public void DisplayWeapon(IWeapon weapon) => _weaponView.DisplayWeapon(weapon);

        public void DisplayHealth(float amount, float max) => _healthView.DisplayHealth(amount, max);
    }
}