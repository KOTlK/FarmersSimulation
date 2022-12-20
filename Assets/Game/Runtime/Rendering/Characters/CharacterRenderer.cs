using System.Collections.Generic;
using Game.Runtime.Characters;
using UnityEngine;

namespace Game.Runtime.Rendering.Characters
{
    public class CharacterRenderer : MonoBehaviour, ICharacterRenderer
    {
        [SerializeField] private Transform _parent;
        [SerializeField] private PrefabDictionary _prefabs;

        private readonly Dictionary<ICharacter, Character> _spawned = new();

        private void Awake()
        {
            _prefabs.Init();
        }

        public void Display(ICharacter character, Profession type)
        {
            if (_spawned.ContainsKey(character))
            {
                _spawned[character].SetPosition(character.Position);
            }
            else
            {
                var view = Instantiate(_prefabs.Get(type), _parent);
                view.SetPosition(character.Position);
                _spawned.Add(character, view);
            }
        }
    }
}