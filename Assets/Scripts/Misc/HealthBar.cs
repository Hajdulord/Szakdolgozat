using UnityEngine;
using UnityEngine.UI;
using HMF.Thesis.Interfaces;

namespace HMF.Thesis.Misc
{

    public class HealthBar : MonoBehaviour, IHealthBar
    {
        [SerializeField] private Slider _slider;

        public void SetMaxHealth(int health)
        {
            _slider.maxValue = health;
            _slider.value = health;
        }

        public void SetHealth(int health)
        {
            _slider.value = health;
        }
    }
}
