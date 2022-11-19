using Game.Runtime.Characters.Weapons;
using Game.Runtime.Characters.Weapons.Melee;
using UnityEngine;

namespace Game.Tests.PlayModeTests.Damage
{
    public class Damager : MonoBehaviour
    {
        [SerializeField] private WeaponTargets _targets = null;

        private IWeapon _weapon;

        private void Start()
        {
            _weapon = new IronSword(_targets);
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                _weapon.Attack();
            }

            if (Input.GetKey(KeyCode.Mouse0))
            {
                var horizontal = Input.GetAxis("Mouse X");
                var vertical = Input.GetAxis("Mouse Y");

                transform.position += new Vector3(horizontal, vertical);
            }
        }
    }
}