using System;
using System.Collections;
using Game.Runtime.Resources;
using UnityEngine;

namespace Game.Runtime.Environment.Mines
{
    public class Mine : MonoBehaviour, IMine
    {
        public event Action<IMine> Recovered = delegate { };
        
        [SerializeField] private Resource _resource = Resource.Copper;
        [SerializeField] private float _recoverTime = 2f;

        [field: SerializeField] public bool ReadyForGather { get; private set; } = false;

        private void Awake()
        {
            StartCoroutine(Waiting(_recoverTime));
        }
        
        public void PickUp(IResourceStorage storage)
        {
            if (storage.EnoughSpace(1) == false)
                throw new Exception($"{nameof(storage)} does not have enough space");
            
            storage.Put(_resource);
            StartCoroutine(Waiting(_recoverTime));
        }

        private IEnumerator Waiting(float time)
        {
            ReadyForGather = false;
            yield return new WaitForSeconds(time);
            Recovered.Invoke(this);
            ReadyForGather = true;
        }

        public Vector2 Position => transform.position;
    }
}