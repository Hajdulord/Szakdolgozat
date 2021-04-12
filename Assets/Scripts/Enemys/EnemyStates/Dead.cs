using UnityEngine;
using HMF.HMFUtilities.DesignPatterns.StatePattern;

namespace HMF.Thesis.Enemys
{
    public class Dead : IState
    {
        private IEnemyStateMachine _stateMachine;


        public Dead(IEnemyStateMachine stateMachine)
        {
            _stateMachine = stateMachine;
        }

        public void OnEnter()
        {
            Debug.Log("Enemy Dead");
            _stateMachine.ThisGameObject.SetActive(false);
        }

        public void OnExit()
        {
            
        }

        public void Tick()
        {
            
        }
    }
}
