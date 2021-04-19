using UnityEngine;
using HMF.Thesis.Interfaces;

namespace HMF.Thesis.Misc
{
    public class SpawnPointSet : MonoBehaviour
    {
        private void OnTriggerEnter2D(Collider2D other) 
        {
            if (other.gameObject.tag == "Player")
            {
                var stateMachine = other.gameObject.GetComponent<IPlayerSateMachine>();

                stateMachine.CurrentSpawnPoint = transform;
            }
        }
    }
}
