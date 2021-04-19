using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HMF.Thesis.Misc
{
    public class StartParticle : MonoBehaviour
    {
        [SerializeField] private GameObject _particleToStop = null!;
        [SerializeField] private GameObject _particleToStart = null!;

        private void OnTriggerEnter2D(Collider2D other) 
        {
            if (other.gameObject.tag == "Player")
            {
                _particleToStop.SetActive(false);
                _particleToStart.SetActive(true);
            }
        }
    }
}
