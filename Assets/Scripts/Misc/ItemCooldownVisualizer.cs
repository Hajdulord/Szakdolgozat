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
            StartCoroutine(CooldownCorutine(index, time));
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

            _holder[index].SetActive(false);
        }

    }
}
