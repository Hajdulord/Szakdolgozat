using HMF.HMFUtilities.DesignPatterns.StatePattern;
using HMF.HMFUtilities.Utilities;
using HMF.Thesis.Interfaces;
using HMF.Thesis.Music;
using UnityEngine;

namespace HMF.Thesis.Enemys.EnemyStates
{
    /// Attack state for enemys.
    public class Attack : IState
    {
        private IAttack _attack; ///< The attack Logic.

        private string[] _tagsToTarget; ///< List of strings for tags to target.

        private IEnemyStateMachine _stateMachine; ///< The enemy's statemachine.

        private float _time = 0; ///< Next time to attack.
        private float _timeMagic = 0; ///< Next time to cast magic.
        private Animator _animator; ///< The animator for playing animations.

        /// Constructor.
        /*!
          \param move is the enemy's movelogic.
          \param stateMachine is the enemy's stateMachine.
          \param animator is the animator.
        */
        public Attack(IAttack attack, string[] tagsToTarget, IEnemyStateMachine stateMachine, Animator animator)
        {
            _attack = attack;
            _tagsToTarget = tagsToTarget;
            _stateMachine = stateMachine;
            _animator = animator;
        }

        /// Stops movement animation.
        public void OnEnter()
        {
            //Debug.Log("Enemy Attack");
            _animator.SetFloat("Speed", 0);
        }

        public void OnExit(){ }

        /// Attacks periodically.
        public void Tick()
        {
            // calculate attack direction
            var dir = HMFutilities.DirectionTo(_stateMachine.ThisGameObject.transform.position.x, _stateMachine.Target.transform.position.x);

            if (dir >= 0)
            {
                dir = 1f;
            }
            else
            {
                dir = -1f;
            }

            _stateMachine.ThisGameObject.transform.right = new Vector3(dir,0,0);

            // plays animation and sound while attacking
            if (Time.time >= _time)
            {
                _animator.SetBool("IsAttacking", true);

                _stateMachine.AudioSourceAttack2.clip = MusicHandler.Instance.Serve(Category.Attacks);
                _stateMachine.AudioSourceAttack2.Play();

                _attack.Origin = _stateMachine.SwordPoint;
                _attack.Attack(_stateMachine.Weapon, _tagsToTarget, _stateMachine.LayersToTarget);
                _time = Time.time + _stateMachine.WeaponData.attackTime;

                _stateMachine.AudioSourceAttack.clip = MusicHandler.Instance.Serve(Category.Swords);
                _stateMachine.AudioSourceAttack.Play();
            }
            else
            {
                _animator.SetBool("IsAttacking", false);
            }

            // plays animation and sound while casting magic
            if (_stateMachine.MagicFocusData != null && Time.time >= _timeMagic)
            {
                _animator.SetBool("IsMagic", true);

                _stateMachine.AudioSourceAttack2.clip = MusicHandler.Instance.Serve(Category.Attacks);
                _stateMachine.AudioSourceAttack2.Play();

                _attack.Origin = _stateMachine.ThisGameObject;
                _attack.Attack(_stateMachine.MagicFocus, _tagsToTarget, _stateMachine.LayersToTarget);
                _timeMagic = Time.time + _stateMachine.MagicFocus.attackTime;

                _stateMachine.AudioSourceAttack.clip = (_stateMachine.MagicFocus as HMF.Thesis.Items.MagicFocus).Clip;
                _stateMachine.AudioSourceAttack.Play();
            }
            else
            {
                _animator.SetBool("IsMagic", false);
            }
        }
    }
}
