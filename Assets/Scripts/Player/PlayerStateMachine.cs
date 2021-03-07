using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HMF.HMFUtilities.DesignPatterns.StatePattern;
using HMF.HMFUtilities.Utilities;
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
        [SerializeField] private Transform _groundCheck;
        private StateMachine _stateMachine; ///< The statemachine is used to garantee the consistency of the players state.
        private MoveComponent _moveComponent;
        private CharacterComponent _characterComponent;
        private InputController _inputController;
        private Rigidbody2D _rigidbody;
        private float _distToGround;

        public float PushBackDir { get; set; }
        public int MoveDirection { get; internal set; } = 0;
        public bool IsDashing {get; internal set; } = false;
        public bool IsJumping {get; internal set; } = false;

        /// Runs before the Start methode, this is used for the setting up the enviornment.
        private void Start() 
        {
            _stateMachine = new StateMachine();

            _distToGround = GetComponent<CapsuleCollider2D>().bounds.extents.y;
            _moveComponent = GetComponent<MoveComponent>();
            _characterComponent = GetComponent<CharacterComponent>();
            _inputController = GetComponent<InputController>();
            _rigidbody = GetComponent<Rigidbody2D>();

            PushBackDir = 0f;

            //! Need to implement this better.
            _moveComponent.Move.JumpSpeed = 400;
            _moveComponent.Move.DashRate = 0.5f;
            _moveComponent.Move.FallSpeed = 5f;
            _moveComponent.Move.PushBackSpeed = 5f;

            var idle = new Idle(_rigidbody);
            var move = new Move(_moveComponent.Move, this);
            var jump = new Jump(_moveComponent.Move, this);
            var fall = new Fall(_moveComponent.Move, this);
            var pushBack = new PushBack(_moveComponent.Move, _rigidbody, this);

            At(idle, move, isMoving());
            At(move, idle, isIdle());

            At(idle, jump, grundedAndReadyToJump());
            At(move, jump, grundedAndReadyToJump());

            At(jump, fall, falling());

            At(fall, idle, grunded());

            At(idle, pushBack, isPushedBack());
            At(move, pushBack, isPushedBack());
            At(jump, pushBack, isPushedBack());
            At(fall, pushBack, isPushedBack());

            At(pushBack, idle, notPushedBack());
            At(pushBack, move, notPushedBack());
            At(pushBack, jump, notPushedBack());
            At(pushBack, fall, notPushedBack());

            /*Func<bool> isIdle() => () => MoveDirection == 0 && Physics2D.Raycast(transform.position, Vector2.down, _distToGround + 0.05f, _jumpLayerMask);
            Func<bool> isMoving() => () => MoveDirection != 0 && Physics2D.Raycast(transform.position, Vector2.down, _distToGround + 0.05f, _jumpLayerMask);
            Func<bool> grundedAndReadyToJump() => () => IsJumping && Physics2D.Raycast(transform.position, Vector2.down, _distToGround + 0.05f, _jumpLayerMask);
            Func<bool> falling() => () => _rigidbody.velocity.y < 0f;
            Func<bool> grunded() => () => Physics2D.Raycast(transform.position, Vector2.down, _distToGround + 0.05f, _jumpLayerMask);
            Func<bool> isPushedBack() => () => PushBackDir != 0f;
            Func<bool> notPushedBack() => () => PushBackDir == 0f;*/

            Func<bool> isIdle() => () => MoveDirection == 0 && GroundCheck();
            Func<bool> isMoving() => () => MoveDirection != 0 && GroundCheck();
            Func<bool> grundedAndReadyToJump() => () => IsJumping && GroundCheck();
            Func<bool> falling() => () => _rigidbody.velocity.y < 0f;
            Func<bool> grunded() => () => GroundCheck();
            Func<bool> isPushedBack() => () => PushBackDir != 0f;
            Func<bool> notPushedBack() => () => PushBackDir == 0f;

            void At(IState from, IState to, Func<bool> condition) => _stateMachine.AddTransition(from, to, condition);
            
            _stateMachine.SetState(idle);
        }

        private void Update()
        {
            _stateMachine?.Tick();
        }

        private void OnCollisionEnter2D(Collision2D other) 
        {
            if (other.gameObject.tag == "Enemy")
            {
                PushBack(other.gameObject);
            }
        }

        private void OnCollisionStay2D(Collision2D other) 
        {
            if (other.gameObject.tag == "Enemy")
            {
                PushBack(other.gameObject);
            }
        }

        public void PushBack(GameObject other)
        {
            var dir = HMFutilities.DirectionTo(other.transform.position.x, transform.position.x);

            if (dir >= 0)
            {
                dir = 1;
            }else
            {
                dir = -1;
            }

            PushBackDir = dir;
        }

        private bool GroundCheck()
        {
            var output = false;

            Collider2D[] colliders = Physics2D.OverlapCircleAll(_groundCheck.position, .2f, _jumpLayerMask);
            for (int i = 0; i < colliders.Length; i++)
		{
			if (colliders[i].gameObject != gameObject)
			{
				output = true;
                return output;
			}
		}

            return output;
        }
    }
}
