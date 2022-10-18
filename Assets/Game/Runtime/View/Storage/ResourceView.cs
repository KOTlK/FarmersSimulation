using TMPro;
using UnityEngine;

namespace Game.Runtime.View.Storage
{
    public class ResourceView : MonoBehaviour
    {
        [SerializeField] private TMP_Text _count = null;
        
        public void Destroy()
        {
            Destroy(gameObject);
        }

        public void SetCount(int amount)
        {
            _count.text = amount.ToString();
        }
    }
}