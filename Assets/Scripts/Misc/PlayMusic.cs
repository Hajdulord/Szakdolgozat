using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HMF.Thesis.Misc
{
    public class PlayMusic : MonoBehaviour
    {
        [SerializeField] private AudioSource _source = null;

        private void OnTriggerEnter2D(Collider2D other) 
        {
            if (other.gameObject.tag == "Player")
            {
                _source.Play();
            }
        }

        private void OnTriggerExit2D(Collider2D other) 
        {
            if (other.gameObject.tag == "Player")
            {
                _source.Stop();
            }
        }
    }
}
