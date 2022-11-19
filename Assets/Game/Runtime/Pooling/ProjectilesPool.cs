using System.Collections.Generic;
using Game.Runtime.Characters.Weapons;
using UnityEngine;

namespace Game.Game.Runtime.Pooling
{
    public class ProjectilesPool : IObjectPool<IProjectile>
    {
        private readonly Projectile _prefab;
        private readonly Stack<IProjectile> _projectiles = new();
        private readonly GameObject _parent;

        public ProjectilesPool(Projectile prefab, int preparedCount)
        {
            _prefab = prefab;
            var parent = new GameObject(nameof(ProjectilesPool))
            {
                transform =
                {
                    position = Vector2.negativeInfinity
                }
            };

            for (var i = 0; i < preparedCount; i++)
            {
                var obj = Object.Instantiate(_prefab, parent.transform);
                _projectiles.Push(obj);
            }
        }

        public IProjectile Pop()
        {
            if (_projectiles.Count > 0)
                return _projectiles.Pop();

            var obj = Object.Instantiate(_prefab, _parent.transform);
            return obj;
        }

        public void Return(IProjectile obj)
        {
            _projectiles.Push(obj);
            obj.Position = Vector2.negativeInfinity;
        }
    }
}