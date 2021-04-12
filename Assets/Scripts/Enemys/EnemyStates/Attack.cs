using HMF.HMFUtilities.DesignPatterns.StatePattern;
using HMF.Thesis.Interfaces;

namespace HMF.Thesis.Enemys.EnemyStates
{
    public class Attack : IState
    {
        private IAttack _attack;

        private string[] _tagsToTarget;

        private BasicEnemyStateMachine _stateMachine;

        public Attack(IAttack attack, string[] tagsToTarget, BasicEnemyStateMachine stateMachine)
        {
            _attack = attack;
            _tagsToTarget = tagsToTarget;
            _stateMachine = stateMachine;
        }

        public void OnEnter()
        {
            throw new System.NotImplementedException();
        }

        public void OnExit()
        {
            throw new System.NotImplementedException();
        }

        public void Tick()
        {
            _attack.Attack(_stateMachine.Weapon, _tagsToTarget);
        }
    }
}
