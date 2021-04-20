using UnityEngine;

namespace HMF.Thesis.Enemys
{
    [RequireComponent(typeof(CircleCollider2D))]
    public class TargetSetter : MonoBehaviour
    {
        private IEnemyStateMachine _stateMachine = null!;

        private void Awake() 
        {
            _stateMachine = GetComponentInParent<IEnemyStateMachine>();
        }

        private void OnTriggerEnter2D(Collider2D other) 
        {
            if (other.gameObject.tag == "Player")
            {
                _stateMachine.Target = other.gameObject;
            }
        }

        private void OnTriggerExit2D(Collider2D other) 
        {
            if (other.gameObject.tag == "Player")
            {
                _stateMachine.Target = null;
            }
        }
    }
}
