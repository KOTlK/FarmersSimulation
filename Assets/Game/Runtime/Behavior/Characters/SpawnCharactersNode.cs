using System.Collections.Generic;
using BananaParty.BehaviorTree;
using Game.Runtime.Characters;
using Game.Runtime.Math.Vectors;
using Game.Runtime.Random;

namespace Game.Runtime.Behavior.Characters
{
    public class SpawnCharactersNode : BehaviorNode
    {
        private readonly int _count;
        private readonly List<ICharacter> _spawnedCharacters;
        private readonly IRandomGenerator<float> _randomAge;
        private readonly IRandomGenerator<string> _randomName;

        public SpawnCharactersNode(int count, List<ICharacter> spawnedCharacters, IRandomGenerator<float> randomAge, IRandomGenerator<string> randomName)
        {
            _count = count;
            _spawnedCharacters = spawnedCharacters;
            _randomAge = randomAge;
            _randomName = randomName;
        }

        public override BehaviorNodeStatus OnExecute(long time)
        {
            var spawnPosition = new Vector2Int(0, 0);
            for (var spawnedCount = 0; spawnedCount < _count; spawnedCount++)
            {
                var character = new Character(_randomName.Next(), _randomAge.Next(), spawnPosition);
                _spawnedCharacters.Add(character);
                spawnPosition = spawnPosition + new Vector2Int(1, 0);
            }

            return BehaviorNodeStatus.Success;
        }
    }
}