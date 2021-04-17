using HMF.HMFUtilities.DesignPatterns.StatePattern;
using HMF.HMFUtilities.Utilities;
using HMF.Thesis.Interfaces;
using UnityEngine;

namespace HMF.Thesis.Enemys.EnemyStates
{
    public class MoveTo : IState
    {
        private IMove _move;
        private IEnemyStateMachine _stateMachine;
        private Animator _animator;

        public MoveTo(IMove move, IEnemyStateMachine stateMachine, Animator animator)
        {
            _move = move;
            _stateMachine = stateMachine;
            _animator = animator;
        }

        public void OnEnter()
        {
            //Debug.Log("Enemy MoveTo");
            _stateMachine.ThisGameObject.transform.right = new Vector3(
                HMFutilities.DirectionTo(_stateMachine.ThisGameObject.transform.position.x, _stateMachine.Target.transform.position.x), 
                0, 
                0);
            _animator.SetFloat("Speed", Mathf.Abs(_stateMachine.ThisGameObject.transform.right.x));
        }

        public void OnExit()
        {
            
        }

        public void Tick()
        {
            _move.MoveToPoint(_stateMachine.Target.transform.position);
        }
    }
}
