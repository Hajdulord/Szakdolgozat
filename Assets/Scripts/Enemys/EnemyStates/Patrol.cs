using HMF.HMFUtilities.DesignPatterns.StatePattern;
using HMF.Thesis.Interfaces;
using UnityEngine;

namespace HMF.Thesis.Enemys
{
    public class Patrol : IState
    {
        private IMove _move;
        private PatrolEnemyStateMachine _stateMachine;
        private bool targetReached = false;

        public Patrol(IMove move, IEnemyStateMachine stateMachine)
        {
            _move = move;
            _stateMachine = stateMachine as PatrolEnemyStateMachine;
        }

        public void OnEnter()
        {
            Debug.Log("Enemy Patrol");
        }

        public void OnExit()
        {
            
        }

        public void Tick()
        {
            if (Vector2.Distance(_stateMachine.transform.position, _stateMachine.start.transform.position) >= 0.5f && !targetReached)
            {
                _move.MoveToPoint(_stateMachine.start.transform.position);
            }
            else
            {
                targetReached = true;
            }
            
            if (Vector2.Distance(_stateMachine.transform.position, _stateMachine.end.transform.position) >= 0.5f && targetReached)
            {
                _move.MoveToPoint(_stateMachine.end.transform.position);
            }
            else
            {
                targetReached = false;
            }

            
        }
    }
}
