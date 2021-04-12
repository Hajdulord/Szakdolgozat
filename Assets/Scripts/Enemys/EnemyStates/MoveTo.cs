using HMF.HMFUtilities.DesignPatterns.StatePattern;
using HMF.Thesis.Interfaces;
using UnityEngine;

namespace HMF.Thesis.Enemys.EnemyStates
{
    public class MoveTo : IState
    {
        private IMove _move;
        private BasicEnemyStateMachine _stateMachine;

        public MoveTo(IMove move, BasicEnemyStateMachine stateMachine)
        {
            _move = move;
            _stateMachine = stateMachine;
        }

        public void OnEnter()
        {
            Debug.Log("Enemy MoveTo");
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
