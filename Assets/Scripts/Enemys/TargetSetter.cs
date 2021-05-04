using UnityEngine;

namespace HMF.Thesis.Enemys
{
    [RequireComponent(typeof(CircleCollider2D))]
    /// Sets the target if in attack range.
    public class TargetSetter : MonoBehaviour
    {
        private IEnemyStateMachine _stateMachine = null!; ///< The enemys statemachine.

        /// Setup.
        private void Awake() 
        {
            _stateMachine = GetComponentInParent<IEnemyStateMachine>();
        }

        /// On enter sets the target.
        private void OnTriggerEnter2D(Collider2D other) 
        {
            if (other.gameObject.tag == "Player")
            {
                _stateMachine.Target = other.gameObject;
            }
        }

        /// On exit sets the target to null.
        private void OnTriggerExit2D(Collider2D other) 
        {
            if (other.gameObject.tag == "Player")
            {
                _stateMachine.Target = null;
            }
        }
    }
}
