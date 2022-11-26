using Game.Runtime.Characters.Professions.Warrior;
using Game.Runtime.Characters.Weapons;
using Game.Runtime.Characters.Weapons.Melee;
using Game.Runtime.View.Characters.Warrior;
using UnityEngine;

namespace Game.Tests.PlayModeTests.Damage
{
    public class Test : MonoBehaviour
    {
        [SerializeField] private WarriorView _secondWarriorView;
        [SerializeField] private Warrior _secondWarrior;
        [SerializeField] private Warrior _warrior;

        private IWeapon _weapon;

        private void Start()
        {
            _weapon = new IronSword();
            _warrior.EquipWeapon(_weapon);
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                _warrior.Attack();
            }

            if (Input.GetKey(KeyCode.Mouse0))
            {
                var horizontal = Input.GetAxis("Mouse X");
                var vertical = Input.GetAxis("Mouse Y");

                _warrior.transform.position += new Vector3(horizontal, vertical);
            }

            _secondWarrior.Visualize(_secondWarriorView);
        }
    }
}