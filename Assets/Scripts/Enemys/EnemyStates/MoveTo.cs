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

            _animator.SetFloat("Speed", Mathf.Abs(_stateMachine.ThisGameObject.transform.right.x));
        }

        public void OnExit()
        {
            
        }

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
