using System;
using System.Collections;
using Game.Runtime.Inventory;
using UnityEngine;

namespace Game.Runtime.Environment.Crops.MonoBehaviours
{
    public abstract class Plant<TItem> : MonoBehaviour, IPlant
    where TItem : IItem, new()
    {
        public event Action<Plant<TItem>> Grown;
        
        [SerializeField] private float _growsTime = 5f;
        [SerializeField] private Sprite _grownSprite = null;
        [SerializeField] private Sprite _undergrownSprite = null;
        [SerializeField] private ParticleSystem _particles = null;

        private SpriteRenderer _spriteRenderer;

        private void Awake()
        {
            _spriteRenderer = GetComponent<SpriteRenderer>();
            StartCoroutine(Growing(_growsTime));
        }

        public bool ReadyForGather { get; private set; }

        public Vector2 Position => transform.position;
        
        public void Gather(IStorage storage)
        {
            if (ReadyForGather == false)
                throw new Exception("Plant is not ready for gather");
            
            storage.Put<TItem>(new TItem());
            StartCoroutine(Growing(_growsTime));
        }

        private IEnumerator Growing(float growTime)
        {
            ReadyForGather = false;
            _spriteRenderer.sprite = _undergrownSprite;
            
            var timeElapsed = 0f;
            
            while (growTime > timeElapsed)
            {
                timeElapsed += Time.deltaTime;
                yield return null;
            }

            ReadyForGather = true;
            _spriteRenderer.sprite = _grownSprite;
            _particles.Play();
            Grown?.Invoke(this);
        }

    }
}