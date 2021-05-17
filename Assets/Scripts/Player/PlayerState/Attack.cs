using HMF.HMFUtilities.DesignPatterns.StatePattern;
using UnityEngine;
using HMF.Thesis.Music;
using HMF.Thesis.Interfaces;
using HMF.Thesis.Items;

namespace HMF.Thesis.Player
{   
    /// The attack state of the Player.
    public class Attack : IState
    {
        private IAttack _attack; ///<  The attack logic of the player.

        private string[] _tagsToTarget; ///< the tags that are targeted.

        private IPlayerStateMachine _playerStateMachine; ///< The statemachine of the player.

        private IMove _move; ///< The move logic of the player.

        private Animator _animator;  ///< The Animator of the player.

        /// Constructor to set the private fields.
        public Attack(IAttack attack, Animator animator, string[] tagsToTarget, IPlayerStateMachine playerStateMachine, IMove move)
        {
            _attack = attack;
            _tagsToTarget = tagsToTarget;
            _playerStateMachine = playerStateMachine;
            _move = move;
            _animator = animator;
        }

        /// Makes an attack or uss an item and plays the matching sounds.
        public void OnEnter()
        {
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

                _playerStateMachine.AudioSourceAttack.clip = MusicHandler.Instance.Serve(Category.Swords);
                _playerStateMachine.AudioSourceAttack.Play();
            }
            
            _attack.Attack(_playerStateMachine.CurrentItem, _tagsToTarget, _playerStateMachine.LayersToTarget);
        }

        /// Sets state and animation variables.
        public void OnExit()
        {
            _playerStateMachine.IsJumping = false;
            _animator.SetBool("IsAttacking", false);
            _animator.SetBool("IsMagic", false);
            _playerStateMachine.IsDashing = false;
        }

        /// Sets the currentItem to null.
        public void Tick() => _playerStateMachine.CurrentItem = null;
    }
}
