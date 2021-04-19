using UnityEngine;
using System.Collections.Generic;
using HMF.HMFUtilities.DesignPatterns.StatePattern;
using HMF.HMFUtilities.Utilities;
using HMF.Thesis.Player.PlayerStates;
using HMF.Thesis.Interfaces.ComponentInterfaces;
using HMF.Thesis.Music;
using HMF.Thesis.Interfaces;
using HMF.Thesis.Misc;
using System;
using System.Collections;
using HMF.Thesis.ScriptableObjects;
using HMF.Thesis.Items;

//! Needs Unit Testing!
//! Needs Comments!
namespace HMF.Thesis.Player
{
    /// This class is used to manage the player's state. 
    public class PlayerStateMachine : MonoBehaviour
    {
        [Header("Serialized Private Fields")]
        [SerializeField] private LayerMask _jumpLayerMask;
        [SerializeField] private Transform _groundCheck;
        [SerializeField] private List<string> _tagsToTarget = new List<string>();
        [SerializeField] private List<MagicFocusData> _magicFocusData = null!;
        [SerializeField] private ConsumableData _consumableData = null!;
        [SerializeField] private GameObject DeathCanvas = null!;

        private StateMachine _stateMachine; ///< The statemachine is used to garantee the consistency of the players state.
        private IMoveComponent _moveComponent;
        private ICharacterComponent _characterComponent;
        private IInventoryComponent _inventoryComponent;
        private IInputController _inputController;
        private IAttackComponent _attackComponent;
        private IDamageableComponent _damageableComponent;
        private Rigidbody2D _rigidbody;
        private Animator _animator;
        private float _distToGround;

        [Header("Serialized Public Fields")]
        [SerializeField] public GameObject dashDust = null!;
        [SerializeField] public Transform currentSpawnPoint = null!; 
        [SerializeField] public GameObject swordPoint = null!;
        [SerializeField] public UseInventory inventoryUI = null!;
        [SerializeField] public AudioSource audioSource = null;
        [SerializeField] public AudioSource audioSourceAttack = null;
        [SerializeField] public AudioSource audioSourceAttack2 = null;
        [SerializeField] public MusicHandler musicHandler = null;

        public float PushBackDir { get; set; }
        public int MoveDirection { get; internal set; } = 0;
        public bool IsDashing {get; internal set; } = false;
        public bool IsJumping {get; internal set; } = false;
        public IItem CurrentItem {get; internal set; } = null;


        public IInventory Inventory {get => _inventoryComponent.Inventory; }

        /// Runs before the Start methode, this is used for the setting up the enviornment.
        private void Start()
        {
            _stateMachine = new StateMachine();

            _distToGround = GetComponent<CapsuleCollider2D>().bounds.extents.y;
            _moveComponent = GetComponent<IMoveComponent>();
            _characterComponent = GetComponent<ICharacterComponent>();
            _damageableComponent = GetComponent<IDamageableComponent>();
            _attackComponent = GetComponent<IAttackComponent>();
            _inventoryComponent = GetComponent<IInventoryComponent>();
            _inputController = GetComponent<IInputController>();
            _rigidbody = GetComponent<Rigidbody2D>();
            _animator = GetComponent<Animator>();

            PushBackDir = 0f;

            SetupInventory();

            //! Need to implement this better.
            _moveComponent.Move.JumpSpeed = 400;
            _moveComponent.Move.DashRate = 0.5f;
            _moveComponent.Move.FallSpeed = 5f;
            _moveComponent.Move.PushBackSpeed = 5f;

            var idle = new Idle(_rigidbody, _animator);
            var move = new Move(_moveComponent.Move, _animator, this);
            var jump = new Jump(_moveComponent.Move, _animator, this);
            var fall = new Fall(_moveComponent.Move, _animator, this);
            var pushBack = new PushBack(_moveComponent.Move, _animator, _rigidbody, this);
            var attack = new Attack(_attackComponent.Attack, _animator, _tagsToTarget.ToArray(), this, _moveComponent.Move);
            var death = new Death(_animator, this);

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

            At(idle, attack, isAttacking());
            At(move, attack, isAttacking());
            At(jump, attack, isAttacking());
            At(fall, attack, isAttacking());
            At(pushBack, attack, isAttacking());

            At(attack, idle, notAttackingAndIdle());
            At(attack, jump, notAttackingAndJumping());
            At(attack, fall, notAttackingAndFalling());
            At(attack, pushBack, notAttackingAndPushedBack());

            At(death, idle, isAlive());
            _stateMachine.AddAnyTransition(death, isDead());

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
            Func<bool> isAttacking() => () => CurrentItem != null;
            Func<bool> notAttackingAndIdle() => () => CurrentItem == null && MoveDirection == 0 && GroundCheck();
            Func<bool> notAttackingAndFalling() => () => CurrentItem == null && _rigidbody.velocity.y < 0f;
            Func<bool> notAttackingAndJumping() => () => CurrentItem == null && _rigidbody.velocity.y > 0f && IsJumping;
            Func<bool> notAttackingAndPushedBack() => () => CurrentItem == null && PushBackDir != 0f;
            Func<bool> isDead() => () => _characterComponent.Character.Health <= 0;
            Func<bool> isAlive() => () => _characterComponent.Character.Health > 0;

            void At(IState from, IState to, Func<bool> condition) => _stateMachine.AddTransition(from, to, condition);

            _stateMachine.SetState(idle);
        }

        private void SetupInventory()
        {
            var magicItem = new MagicFocus(_magicFocusData[0], GetComponent<IMagicHandlerComponent>().MagicHandler);
            var magicItem2 = new MagicFocus(_magicFocusData[1], GetComponent<IMagicHandlerComponent>().MagicHandler);

            var consumableItem = new HealthPotion(_consumableData);

            _inventoryComponent.Inventory.AddItem(magicItem, 1);
            _inventoryComponent.Inventory.AddItem(magicItem2, 10);
            _inventoryComponent.Inventory.AddItem(consumableItem, 2);

            _inventoryComponent.Inventory.SetUse(magicItem);
            _inventoryComponent.Inventory.SetUse(magicItem2);
            _inventoryComponent.Inventory.SetUse(consumableItem);
        }

        private void Update() => _stateMachine?.Tick();

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

            _damageableComponent.Damageable.TakeDamage();
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

        public void Dead()
        {
            GetComponent<SpriteRenderer>().enabled = false;
        }

        public void Step()
        {
            audioSource.clip = musicHandler.playerStep;
            audioSource.Play();
        }

        public IEnumerator Respawn()
        {
            DeathCanvas.SetActive(true);

            yield return new WaitForSeconds(5f);

            transform.position = currentSpawnPoint.position;

            _characterComponent.Character.Health = _characterComponent.Character.MaxHealth;
            
            yield return new WaitForSeconds(2f);

            GetComponent<SpriteRenderer>().enabled = true;
            
            DeathCanvas.SetActive(false);

        }
    }
}
