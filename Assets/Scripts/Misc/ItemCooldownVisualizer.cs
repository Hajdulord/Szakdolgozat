using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace HMF.Thesis.Misc
{
    /// A Class for showing the cooldown of items.
    public class ItemCooldownVisualizer : MonoBehaviour
    {
        [SerializeField] private List<TMP_Text> _texts = null!; ///< Reference for the textFiled where the cooldown is showned.
        [SerializeField] private List<GameObject> _holder = null!; ///< Reference for the Cooldown's parent object.

        private Dictionary<int, Coroutine> _coroutines = new Dictionary<int, Coroutine>();  ///< Dictionary of coroutines for the cooldown counters.

        /// Singleton instance.
        public static ItemCooldownVisualizer Instance {get; private set; }

        /// Sets the singleton instance.
        private void Awake() 
        {
            if (Instance == null)
            {    
                Instance = this;
            }
        }

        /// Starts the cooldwon by satrting a coroutine.
        /*!
          \param index is items index in the inUse inventory.
          \param time is cooldowns time.
        */
        public void StartCooldown(int index, int time)
        {
            _coroutines.Add(index ,StartCoroutine(CooldownCorutine(index, time)));
        }

        /// Starts a coroutine with the cooldown.
        /*!
          \param index is items index in the inUse inventory.
          \param time is cooldowns time.
        */
        private IEnumerator CooldownCorutine(int index, int time)
        {
            _holder[index].SetActive(true);

            var currentTime = time;
            
            // every second decreases and updates the time 
            while (currentTime > 0)
            {
                _texts[index].text = currentTime.ToString();

                yield return new WaitForSeconds(1);

                --currentTime;
            }

            _coroutines.Remove(index);

            _holder[index].SetActive(false);
        }

        /// Stops all coroutines and deactivates the cooldown.
        public void ResetAll()
        {
            StopAllCoroutines();
            foreach(var item in _holder)
            {
                item.SetActive(false);
            }
            _coroutines.Clear();
        }

        /// Stops a specific coroutine.
        /*!
          \param index is the index of the corutin in _coroutines.
        */
        public void StopCountdown(int index)
        {
            if(_coroutines.TryGetValue(index, out Coroutine coroutine))
            {
                StopCoroutine(coroutine);
                _holder[index].SetActive(false);
                _coroutines.Remove(index);
            }
        }

        /// Free the singleton instance.
        private void OnDestroy() 
        {
            Instance = null;    
        }

    }
}
