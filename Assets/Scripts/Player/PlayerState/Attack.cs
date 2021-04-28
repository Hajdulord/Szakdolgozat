using HMF.HMFUtilities.DesignPatterns.StatePattern;
using UnityEngine;
using HMF.Thesis.Music;
using HMF.Thesis.Interfaces;
using HMF.Thesis.Items;

namespace HMF.Thesis.Player
{
    public class Attack : IState
    {
        private IAttack _attack;

        private string[] _tagsToTarget;

        private IPlayerStateMachine _playerStateMachine;

        private IMove _move;

        private Animator _animator;

        public Attack(IAttack attack, Animator animator, string[] tagsToTarget, IPlayerStateMachine playerStateMachine, IMove move)
        {
            _attack = attack;
            _tagsToTarget = tagsToTarget;
            _playerStateMachine = playerStateMachine;
            _move = move;
            _animator = animator;
            //_time = 0;
        }

        public void OnEnter()
        {
            //Debug.Log($"Attack with {_playerStateMachine.CurrentItem.Name}");

            _playerStateMachine.AudioSourceAttack2.clip = MusicHandler.Instance.Serve(Category.Attacks);
            _playerStateMachine.AudioSourceAttack2.Play();

            if(_playerStateMachine.CurrentItem is MagicFocus || _playerStateMachine.CurrentItem is Consumable)
            {
                _animator.SetBool("IsMagic", true);
                _attack.Origin = _playerStateMachine.ThisGameObject;

                if (_playerStateMachine.CurrentItem is MagicFocus)
                {
                    _playerStateMachine.AudioSourceAttack.clip = (_playerStateMachine.CurrentItem as MagicFocus).Clip;
                    _playerStateMachine.AudioSourceAttack.Play();
                }
                
            }
            else
            {
                _animator.SetBool("IsAttacking", true);
                _attack.Origin = _playerStateMachine.SwordPoint;

                //_playerStateMachine.audioSourceAttack.clip = _playerStateMachine.musicHandler.Serve(Music.Category.Swords);
                _playerStateMachine.AudioSourceAttack.clip = MusicHandler.Instance.Serve(Category.Swords);
                _playerStateMachine.AudioSourceAttack.Play();
            }
            
            
            _attack.Attack(_playerStateMachine.CurrentItem, _tagsToTarget, _playerStateMachine.LayersToTarget);
        }

        public void OnExit()
        {
            _playerStateMachine.IsJumping = false;
            _animator.SetBool("IsAttacking", false);
            _animator.SetBool("IsMagic", false);
        }

        public void Tick() => _playerStateMachine.CurrentItem = null;
    }
}
