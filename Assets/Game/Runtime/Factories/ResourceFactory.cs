using Game.Runtime.Resources;
using Kotik.RequireInterface;
using UnityEngine;

namespace Game.Game.Runtime.Factories
{
    public abstract class ResourceFactory : MonoBehaviour, IResourceFactory
    {
        [RequireInterface(typeof(IWorldStorage)), SerializeField]
        private MonoBehaviour _incomeStorage, _outcomeStorage;
        
        [SerializeField] private float _cooldown = 3f;
        [SerializeField] private bool _work = true;
        [SerializeField] private Blueprint _blueprint;

        private IWorldStorage _income, _outcome;

        private float _time = 0;

        private void Awake()
        {
            _income = (IWorldStorage) _incomeStorage;
            _outcome = (IWorldStorage) _outcomeStorage;
        }

        private void FixedUpdate()
        {
            if (_work == false) return;
            
            _time += Time.deltaTime;
            if (_time >= _cooldown == false) return;

            if (_blueprint.CanBeCrafted(_income))
            {
                var pack = Create();
                pack.Transfer(_outcome);
                _time = 0;
            }
        }

        public IResourcePack Create() => _blueprint.Craft(_income);

        public Vector2 Position => transform.position;
        
    }
}