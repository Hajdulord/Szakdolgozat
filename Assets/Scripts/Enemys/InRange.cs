using UnityEngine;


namespace HMF.Thesis.Enemys
{
    [RequireComponent(typeof(CircleCollider2D))]
    public class InRange : MonoBehaviour
    {
        [SerializeField] private CircleCollider2D _collider = null!;
        
        private IEnemyStateMachine _stateMachine = null!;

        [SerializeField] public bool inRange = false;

        private void Awake() 
        {
            _stateMachine = GetComponentInParent<IEnemyStateMachine>();
            _collider.radius = _stateMachine.WeaponData.attackRange / 2;
        }

        private void OnTriggerEnter2D(Collider2D other) 
        {
            /*//_stateMachine.TriggerFromChild = true;
            if (other.gameObject.tag == "Player"  && _stateMachine.TriggerFromChild)
            {
                ++_stateMachine.TriggerCount;
                if (_stateMachine.TriggerCount == 2)
                {
                    inRange = true; 
                }
            }
            Debug.Log(_stateMachine.TriggerCount);*/

            if (other.gameObject.tag == "Player")
            {
                inRange = true;
            }

        }

        private void OnTriggerExit2D(Collider2D other) 
        {
            /*//_stateMachine.TriggerFromChild = true;
            if (other.gameObject.tag == "Player"  && _stateMachine.TriggerFromChild)
            {
                if (_stateMachine.TriggerCount == 2)
                {
                    inRange = false; 
                }
                --_stateMachine.TriggerCount;
            }
            
            Debug.Log(_stateMachine.TriggerCount);*/

            if (other.gameObject.tag == "Player")
            {
                inRange = false;
            }
        }
    }
}
