using UnityEngine;
using UnityEngine.UI;

namespace Game.Runtime.View.Health
{
    public class HealthView : MonoBehaviour, IHealthView
    {
        [SerializeField] private Image _image;

        public void DisplayHealth(float amount, float max)
        {
            var fillAmount = amount / max;
            Debug.Log($"{amount} / {max} = {fillAmount}");
            _image.fillAmount = fillAmount;
        }
    }
}