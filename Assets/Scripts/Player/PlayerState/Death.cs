using UnityEngine;
using HMF.HMFUtilities.DesignPatterns.StatePattern;
using HMF.Thesis.Interfaces.ComponentInterfaces;

namespace HMF.Thesis.Player.PlayerStates
{
    public class Death : IState
    {
        private Animator _animator;
        private PlayerStateMachine _stateMachine;

        public Death(Animator animator, PlayerStateMachine stateMachine)
        {
            _animator = animator;
            _stateMachine = stateMachine;
        }

        public void OnEnter()
        {
            //Debug.Log("Dead");
            _animator.SetBool("IsDead", true);
            _stateMachine.audioSource.clip = _stateMachine.musicHandler.Serve(Music.Category.Deaths);
            _stateMachine.audioSource.Play();
            _stateMachine.gameObject.GetComponent<IStatusHandlerComponent>().StatusHandler.RemoveAllStatuses();
            //_stateMachine.gameObject.GetComponent<IStatusHandlerComponent>().DestroyThis();
            //_stateMachine.g
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
