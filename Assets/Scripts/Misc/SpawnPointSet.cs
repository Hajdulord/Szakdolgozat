using UnityEngine;
using HMF.Thesis.Interfaces;

namespace HMF.Thesis.Misc
{
    /// Class for setting a new spawnpoint.
    public class SpawnPointSet : MonoBehaviour
    {
        /// If the player is in range sets new spawnpoint.
        private void OnTriggerEnter2D(Collider2D other) 
        {
            if (other.gameObject.tag == "Player")
            {
                var stateMachine = other.gameObject.GetComponent<IPlayerStateMachine>();

                stateMachine.CurrentSpawnPoint = transform;
            }
        }
    }
}
