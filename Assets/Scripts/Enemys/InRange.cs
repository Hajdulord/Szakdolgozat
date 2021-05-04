using UnityEngine;


namespace HMF.Thesis.Enemys
{
    [RequireComponent(typeof(CircleCollider2D))]
    /// Component for  detecting if the player is in range.
    public class InRange : MonoBehaviour
    {
        [SerializeField] private CircleCollider2D _collider = null!; ///< The Collider for setting range for detection.
        
        private IEnemyStateMachine _stateMachine = null!; ///< The statemachine for the enemy.

        [SerializeField] public bool inRange = false; ///< if in range.

        /// Setup.
        private void Awake() 
        {
            _stateMachine = GetComponentInParent<IEnemyStateMachine>();
            _collider.radius = _stateMachine.WeaponData.attackRange / 4;
        }

        /// When player enters switches the inRange.
        private void OnTriggerEnter2D(Collider2D other) 
        {
            if (other.gameObject.tag == "Player")
            {
                inRange = true;
            }
        }
        
        /// When player leaves switches the inRange.
        private void OnTriggerExit2D(Collider2D other) 
        {
            if (other.gameObject.tag == "Player")
            {
                inRange = false;
            }
        }
    }
}
