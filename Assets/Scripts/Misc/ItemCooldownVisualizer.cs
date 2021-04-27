using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace HMF.Thesis.Misc
{
    public class ItemCooldownVisualizer : MonoBehaviour
    {
        [SerializeField] private List<TMP_Text> _texts = null!;
        [SerializeField] private List<GameObject> _holder = null!;

        private Dictionary<int, Coroutine> _coroutines = new Dictionary<int, Coroutine>();

        public static ItemCooldownVisualizer Instance {get; private set; }

        private void Awake() 
        {
            if (Instance == null)
            {    
                Instance = this;
            }
        }

        public void StartCooldown(int index, int time)
        {
            _coroutines.Add(index ,StartCoroutine(CooldownCorutine(index, time)));
        }

        private IEnumerator CooldownCorutine(int index, int time)
        {
            _holder[index].SetActive(true);

            var currentTime = time;

            while (currentTime > 0)
            {
                _texts[index].text = currentTime.ToString();

                yield return new WaitForSeconds(1);

                --currentTime;
            }

            _coroutines.Remove(index);

            _holder[index].SetActive(false);
        }

        public void ResetAll()
        {
            StopAllCoroutines();
            foreach(var item in _holder)
            {
                item.SetActive(false);
            }
            _coroutines.Clear();
        }

        public void StopCountdown(int index)
        {
            if(_coroutines.TryGetValue(index, out Coroutine coroutine))
            {
                StopCoroutine(coroutine);
                _holder[index].SetActive(false);
                _coroutines.Remove(index);
            }
        }

        private void OnDestroy() 
        {
            Instance = null;    
        }

    }
}
