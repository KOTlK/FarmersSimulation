using Game.Runtime.Characters;
using UnityEngine;

namespace Game.Runtime.Rendering.Characters
{
    [System.Serializable]
    public class CharacterPrefab
    {
        [field: SerializeField] public Profession Profession { get; private set; }
        [field: SerializeField] public Character Prefab { get; private set; }
    }
}