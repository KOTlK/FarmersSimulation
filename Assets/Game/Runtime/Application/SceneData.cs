﻿using Game.Runtime.Characters;
using Game.Runtime.Characters.Professions;
using Game.Runtime.Environment;
using Game.Runtime.Environment.Crops;
using Game.Runtime.Environment.Mines;
using Game.Runtime.Input;
using Game.Runtime.Resources;
using UnityEngine;

namespace Game.Runtime.Application
{
    public struct SceneData
    {
        public FriendlyCharacter[] Characters { get; set; }
        public IClickQueue<IFriendlyCharacter> CharacterInputs { get; set; }
        public IResourceStack<IPlant> Plants { get; set; }
        public IResourceStack<IMine> Mines { get; set; }
        public IWorldStorage Storage { get; set; }
        public IClickQueue<IWorldStorage> StorageInputs { get; set; }
        public TextAsset Names { get; set; }
    }
}