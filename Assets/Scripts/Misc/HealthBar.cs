using UnityEngine;
using UnityEngine.UI;
using HMF.Thesis.Interfaces;

namespace HMF.Thesis.Misc
{
    /// A class that sets the health bar.
    public class HealthBar : MonoBehaviour, IHealthBar
    {
        [SerializeField] private Slider _slider; ///< health bar's slider.

        /// Sets the max value of the slider.
        public void SetMaxHealth(int health)
        {
            _slider.maxValue = health;
            _slider.value = health;
        }

        /// Sets current health.
        public void SetHealth(int health)
        {
            _slider.value = health;
        }
    }
}
