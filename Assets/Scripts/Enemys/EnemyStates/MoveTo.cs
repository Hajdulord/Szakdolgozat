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

        public MoveTo(IMove move, IEnemyStateMachine stateMachine)
        {
            _move = move;
            _stateMachine = stateMachine;
        }

        public void OnEnter()
        {
            Debug.Log("Enemy MoveTo");
            _stateMachine.ThisGameObject.transform.right = new Vector3(
                HMFutilities.DirectionTo(_stateMachine.ThisGameObject.transform.position.x, _stateMachine.Target.transform.position.x), 
                0, 
                0);
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
