using UnityEngine;
using HMF.HMFUtilities.DesignPatterns.StatePattern;

namespace HMF.Thesis.Player.PlayerStates
{
    public class Death : IState
    {
        private Animator _animator;

        public Death(Animator animator)
        {
            _animator = animator;
        }

        public void OnEnter()
        {
            Debug.Log("Dead");
            _animator.SetBool("IsDead", true);
            //_playerStateMachine.Respawn();
        }

        public void OnExit()
        {
            _animator.SetBool("IsDead", false);
        }

        public void Tick()
        {

        }
    }
}
