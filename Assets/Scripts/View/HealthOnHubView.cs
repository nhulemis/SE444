using managers;
using UnityEngine;
using UnityEngine.UI;

namespace View
{
    public class HealthOnHubView : MonoBehaviour
    {
        [SerializeField] Slider healthSlider;

        private void OnHealthChanged(int newHealth)
        {
            healthSlider.value = newHealth;
        }
        
        private void Start()
        {
            HealthService.Instance.RegisterOnHealthChanged(OnHealthChanged);
        }
        
        private void OnDisable()
        {
            HealthService.Instance.UnregisterOnHealthChanged(OnHealthChanged);
        }
    }
}