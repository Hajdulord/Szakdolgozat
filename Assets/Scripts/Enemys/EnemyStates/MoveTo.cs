using HMF.HMFUtilities.DesignPatterns.StatePattern;
using HMF.HMFUtilities.Utilities;
using HMF.Thesis.Interfaces;
using UnityEngine;

namespace HMF.Thesis.Enemys.EnemyStates
{
    /// The state for moving to the player.
    public class MoveTo : IState
    {
        private IMove _move; ///< The move Logic.
        private IEnemyStateMachine _stateMachine; ///< The enemy's statemachine.
        private Animator _animator; ///< The animator for playing animations.

        /// Constructor.
        /*!
          \param move is the enemy's movelogic.
          \param stateMachine is the enemy's stateMachine.
          \param animator is the animator.
        */
        public MoveTo(IMove move, IEnemyStateMachine stateMachine, Animator animator)
        {
            _move = move;
            _stateMachine = stateMachine;
            _animator = animator;
        }

        /// Setup for the state's proper working.
        public void OnEnter()
        {
            //Debug.Log("Enemy MoveTo");

            // makes the direction a unit
            var dir = HMFutilities.DirectionTo(_stateMachine.ThisGameObject.transform.position.x, _stateMachine.Target.transform.position.x);

            if (dir >= 0)
            {
                dir = 1f;
            }
            else
            {
                dir = -1f;
            }

            // sets the look direction
            _stateMachine.ThisGameObject.transform.right = new Vector3(dir,  0,  0);

            // starts move anim
            _animator.SetFloat("Speed", Mathf.Abs(dir));
        }

        /// Closes the state 
        public void OnExit()
        {
            var rigidbody = _stateMachine.ThisGameObject.GetComponent<Rigidbody2D>();
            rigidbody.velocity = new Vector2(0, rigidbody.velocity.y);
        }

        // Moves the enemy tovards the target.
        public void Tick()
        {
            var dir = HMFutilities.DirectionTo(_stateMachine.ThisGameObject.transform.position.x, _stateMachine.Target.transform.position.x);

            if (dir >= 0)
            {
                dir = 1f;
            }
            else
            {
                dir = -1f;
            }

            _stateMachine.ThisGameObject.transform.right = new Vector3(dir,  0,  0);

            _move.MoveToPoint(new Vector2(_stateMachine.Target.transform.position.x, _stateMachine.ThisGameObject.transform.position.y));
        }
    }
}
