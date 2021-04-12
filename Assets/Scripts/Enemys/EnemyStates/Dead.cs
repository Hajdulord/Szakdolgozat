using HMF.HMFUtilities.DesignPatterns.StatePattern;

namespace HMF.Thesis.Enemys
{
    public class Dead : IState
    {
        private BasicEnemyStateMachine _stateMachine;


        public Dead(BasicEnemyStateMachine stateMachine)
        {
            _stateMachine = stateMachine;
        }

        public void OnEnter()
        {
            _stateMachine.gameObject.SetActive(false);
        }

        public void OnExit()
        {
            
        }

        public void Tick()
        {
            
        }
    }
}
