using UnityEngine;

namespace HMF.Thesis.Misc
{
    /// Starts and stops particles.
    public class StartParticle : MonoBehaviour
    {
        [SerializeField] private GameObject _particleToStop = null!; ///< Reference to a particleSystem to stop.
        [SerializeField] private GameObject _particleToStart = null!; ///< Reference to a particleSystem to start.

        /// If the player is in range starts current particle system and stops previous.
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
