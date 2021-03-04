using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HMF.HMFUtilities.DesignPatterns.StatePattern;
using HMF.Thesis.Player.PlayerStates;
using HMF.Thesis.Components;
using System;

//! Needs Unit Testing!
//! Needs Comments!
namespace HMF.Thesis.Player
{
    /// This class is used to manage the player's state. 
    [RequireComponent(typeof(MoveComponent))]
    [RequireComponent(typeof(CharacterComponent))]
    [RequireComponent(typeof(InputController))]
    public class PlayerStateMachine : MonoBehaviour
    {
        [SerializeField] private LayerMask _jumpLayerMask;
        private StateMachine _stateMachine; ///< The statemachine is used to garantee the consistency of the players state.
        private MoveComponent _moveComponent;
        private CharacterComponent _characterComponent;
        private InputController _inputController;
        private float distToGround;
        public int MoveDirection { get; internal set; } = 0;

        public bool IsDashing {get; internal set; } = false;
        public bool IsJumping {get; internal set; } = false;

        /// Runs before the Start methode, this is used for the setting up the enviornment.
        private void Start() 
        {
            _stateMachine = new StateMachine();

            distToGround = GetComponent<CapsuleCollider2D>().bounds.extents.y;
            _moveComponent = GetComponent<MoveComponent>();
            _characterComponent = GetComponent<CharacterComponent>();
            _inputController = GetComponent<InputController>();

            //! Need to implement this better.
            _moveComponent.Move.JumpHeight = 5;
            _moveComponent.Move.JumpSpeed = 400;

            var idle = new Idle();
            var move = new Move(_moveComponent.Move, this);
            var jump = new Jump(_moveComponent.Move, this);

            At(idle, move, isMoving());
            At(move, idle, isIdle());

            At(idle, jump, grundedAndReadyToJump());
            At(move, jump, grundedAndReadyToJump());

            //At(jump, idle, grunded());

            Func<bool> isIdle() => () => MoveDirection == 0 && Physics2D.Raycast(transform.position, Vector2.down, distToGround + 0.5f, _jumpLayerMask);
            Func<bool> isMoving() => () => MoveDirection != 0 && Physics2D.Raycast(transform.position, Vector2.down, distToGround + 0.5f, _jumpLayerMask);
            Func<bool> grundedAndReadyToJump() => () => IsJumping && Physics2D.Raycast(transform.position, Vector2.down, distToGround + 0.5f, _jumpLayerMask);
            Func<bool> grunded() => () => Physics2D.Raycast(transform.position, Vector2.down, distToGround + 0.5f, _jumpLayerMask);

            void At(IState from, IState to, Func<bool> condition) => _stateMachine.AddTransition(from, to, condition);
            
            _stateMachine.SetState(idle);
        }

        private void Update()
        {
            _stateMachine?.Tick();
        }
    }
}
