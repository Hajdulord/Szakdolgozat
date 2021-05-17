using HMF.HMFUtilities.DesignPatterns.StatePattern;
using HMF.HMFUtilities.Utilities;
using HMF.Thesis.Interfaces;
using UnityEngine;

namespace HMF.Thesis.Enemys
{
    /// Patrol state for enemys.
    public class Patrol : IState
    {
        private IMove _move; ///< The move Logic.
        private PatrolEnemyStateMachine _stateMachine; ///< The enemy's statemachine.
        private bool targetReached = false; /// True if the target is within attack range.
        private Animator _animator; ///< The animator for playing animations.

        /// Constructor.
        /*!
          \param move is the enemy's movelogic.
          \param stateMachine is the enemy's stateMachine.
          \param animator is the animator.
        */
        public Patrol(IMove move, IEnemyStateMachine stateMachine, Animator animator)
        {
            _move = move;
            _stateMachine = stateMachine as PatrolEnemyStateMachine;
            _animator = animator;
        }

        /// Starts move animation.
        public void OnEnter()
        {
            //Debug.Log("Enemy Patrol");
            _animator.SetFloat("Speed", Mathf.Abs(_stateMachine.ThisGameObject.transform.right.x));
        }

        public void OnExit(){ }

        /// Moves between two points.
        public void Tick()
        {   
            // checks if target is reached then switches the target.
            if (Vector2.Distance(_stateMachine.transform.position, _stateMachine.start.transform.position) >= 0.5f && !targetReached)
            {
                _move.MoveToPoint(_stateMachine.start.transform.position);
            }
            else
            {
                targetReached = true;

                _stateMachine.ThisGameObject.transform.right = new Vector3(
                HMFutilities.DirectionTo(_stateMachine.ThisGameObject.transform.position.x, _stateMachine.end.transform.position.x), 
                0, 
                0);
            }
            
            if (Vector2.Distance(_stateMachine.transform.position, _stateMachine.end.transform.position) >= 0.5f && targetReached)
            {
                _move.MoveToPoint(_stateMachine.end.transform.position);
            }
            else
            {
                targetReached = false;
                
                _stateMachine.ThisGameObject.transform.right = new Vector3(
                HMFutilities.DirectionTo(_stateMachine.ThisGameObject.transform.position.x, _stateMachine.start.transform.position.x), 
                0, 
                0);
            }
        }
    }
}
