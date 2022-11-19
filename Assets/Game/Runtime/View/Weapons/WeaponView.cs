using Game.Runtime.Characters.Weapons;
using Game.Runtime.Characters.Weapons.Melee;
using UnityEngine;

namespace Game.Runtime.View.Weapons
{
    public class WeaponView : MonoBehaviour, IWeaponView
    {
        [SerializeField] private SpriteRenderer _renderer;
        
        [SerializeField] private Sprite _unknownWeapon, _ironSword;
        
        
        public void DisplayWeapon(IWeapon weapon)
        {
            _renderer.sprite = weapon switch
            {
                IronSword => _ironSword,
                _ => _unknownWeapon
            };
        }
    }
}