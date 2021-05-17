using UnityEngine;

namespace HMF.Thesis.Misc
{
    /// Class for starting ans stoping the music when in range.
    public class PlayMusic : MonoBehaviour
    {
        [SerializeField] private AudioSource _source = null; ///< Reference to the audioSource.

        /// If the player is in range starts plaing music.
        private void OnTriggerEnter2D(Collider2D other) 
        {
            if (other.gameObject.tag == "Player")
            {
                _source.Play();
            }
        }

        /// If the player is in range stops plaing music.
        private void OnTriggerExit2D(Collider2D other) 
        {
            if (other.gameObject.tag == "Player")
            {
                _source.Stop();
            }
        }
    }
}
