using UnityEngine;
using HMF.HMFUtilities.DesignPatterns.StatePattern;
using System.Collections.Generic;
using System.Linq;

namespace HMF.Thesis.Enemys
{
    public class Dead : IState
    {
        private IEnemyStateMachine _stateMachine;
        private Animator _animator;

        public Dead(IEnemyStateMachine stateMachine, Animator animator)
        {
            _stateMachine = stateMachine;
            _animator = animator;
        }

        public void OnEnter()
        {
            //Debug.Log("Enemy Dead");
            //_stateMachine.ThisGameObject.SetActive(false);
            _animator.SetBool("IsDead", true);
            
            var colliders = new List<Collider2D>();

            _stateMachine.ThisGameObject.GetComponent<Rigidbody2D>()?.GetAttachedColliders(colliders);

            if (colliders.Any())
            {
                foreach (var collider in colliders)
                {
                    if (!collider.isTrigger)
                    {
                        collider.attachedRigidbody.gravityScale = 0;
                        collider.enabled = false;
                    }   
                }
            }
        }

        public void OnExit()
        {
            
        }

        public void Tick()
        {
            
        }
    }
}
