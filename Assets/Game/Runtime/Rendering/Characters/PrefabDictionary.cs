using System;
using System.Collections.Generic;
using Game.Runtime.Characters;
using UnityEngine;

namespace Game.Runtime.Rendering.Characters
{
    [Serializable]
    public class PrefabDictionary
    {
        [field: SerializeField] private CharacterPrefab[] _prefabs;

        private readonly Dictionary<Profession, Character> _dictionary = new();

        public void Init()
        {
            foreach (var prefab in _prefabs)
            {
                _dictionary.Add(prefab.Profession, prefab.Prefab);
            }
        }

        public Character Get(Profession profession) => _dictionary[profession];
    }
}