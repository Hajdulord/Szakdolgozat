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
using HMF.Thesis.Status;
using UnityEngine.InputSystem;

namespace HMF.Thesis.Player
{
    /// This class is used to manage the player's state. 
    public class PlayerStateMachine : MonoBehaviour, IPlayerStateMachine
    {
        [Header("LayerMasks")]
        [SerializeField] private LayerMask _jumpLayerMask; ///< Layermask for the ground.
        [SerializeField] private LayerMask _layersToTarget; ///< You can set it to the lyers you want to target. It makes the target finding faster, than just tag based identifying.
        [SerializeField] private LayerMask _pickUpLayers; ///< You can set it to the lyers you want to target for picking up items.

        [Header("Transforms")]
        [SerializeField] private Transform _groundCheck; ///< The transfor of the ground checker object.
        [SerializeField] private Transform _currentSpawnPoint = null!; ///< The transfor for the current SpawnPoint.

        [Header("Lists")]
        [SerializeField] private List<string> _tagsToTarget = new List<string>(); ///< List of tags to target.
        [SerializeField] private List<MagicFocusData> _magicFocusData = null!; ///< The list of magicfocusData.

        [Header("Gameobjects")]
        [SerializeField] private GameObject _enemys = null!; ///< Reference to the enemys.
        [SerializeField] private GameObject DeathCanvas = null!; ///< Reference to the Death menu.
        [SerializeField] private GameObject _dashDust = null!; ///< The gameObject for the dasDust animation.
        [SerializeField] private GameObject _swordPoint = null!; ///< The gameObject for the swordPoint.

        [Header("Audio")]
        [SerializeField] private AudioSource _audioSource = null; ///< AudioScource for movement based souns.
        [SerializeField] private AudioSource _audioSourceAttack = null; ///< AudioSource for sword clashes.
        [SerializeField] private AudioSource _audioSourceAttack2 = null; ///< AudioSource for screams.

        [Header("Other")]
        [SerializeField] private float _pushBackTime = 2f; ///< The time of the pushBack inmunity.
        [SerializeField] private ConsumableData _consumableData = null!; ///< The added Consumable's data.
        [SerializeField] public UseInventory inventoryUI = null!; ///< Reference to the UseInventory scipt.
 ///< 
        private StateMachine _stateMachine; ///< The statemachine is used to garantee the consistency of the players state.
        private IMoveComponent _moveComponent; ///< Component that wraps the move logic.
        private ICharacterComponent _characterComponent; ///< Component that wraps the caharacter logic.
        private IInventoryComponent _inventoryComponent; ///< Component that wraps the inventory logic.
        private IInputController _inputController; ///< Parses the player input.
        private IAttackComponent _attackComponent; ///< Component that wraps the attack logic.
        private IDamageableComponent _damageableComponent; ///< Component that wraps the damageable logic.
        private Rigidbody2D _rigidbody; ///< Rigidbody of the player.
        private Animator _animator; ///< Animator of the player.
        private float _distToGround; ///< Max distance to the ground.
        private MagicFocus _magicItem; ///< Added magicFocus.
        private MagicFocus _magicItem2; ///< Added magicFocus.
        private HealthPotion _consumableItem; ///< Added healthPotion.
        private float _pushBackInmunity = 0; ///< Time of the end of the immunity.

        /// The direction of the pushback.
        public float PushBackDir { get; set; }

        /// The direction of the movement.
        public int MoveDirection { get; internal set; } = 0;

        // Is the player Dashing.
        public bool IsDashing {get; set; } = false;

        /// Is the Player Jumping.
        public bool IsJumping {get; set; } = false;

        /// The Currently used Item.
        public IItem CurrentItem {get; set; } = null;

        /// The Inventory.
        public IInventory Inventory {get => _inventoryComponent.Inventory; }

        /// Property for _currentSpawnPoint.
        public Transform CurrentSpawnPoint { get => _currentSpawnPoint; set => _currentSpawnPoint = value; }

        /// Getter for _pushBackTime.
        public float PushBackTime { get => _pushBackTime;}

        /// Is the Player Stunned.
        public bool IsStunned { get; set;} = false;

        /// Property for the _pushBackInmunity;
        public float PushBackInmunity { get => _pushBackInmunity; set => _pushBackInmunity = value; }

        /// Property for _layersToTarget;
        public LayerMask LayersToTarget { get => _layersToTarget; set => _layersToTarget = value; }

        /// Property for _pickUpLayers.
        public LayerMask PickUpLayers { get => _pickUpLayers; set => _pickUpLayers = value; }

        /// The position of the player.
        public Vector3 TransformPosition {get => gameObject.transform.position; set => gameObject.transform.position = value; }
        
        /// Property for _dashDust.
        public GameObject DashDust { get => _dashDust; set => _dashDust = value; }
       
        /// Property for _swordPoint.
        public GameObject SwordPoint { get => _swordPoint; set => _swordPoint = value; }
        
        /// Property for _audioSource.
        public AudioSource AudioSource { get => _audioSource; set => _audioSource = value; }
        
        /// Property for _audioSourceAttack.
        public AudioSource AudioSourceAttack { get => _audioSourceAttack; set => _audioSourceAttack = value; }
        
        /// Property for _audioSourceAttack2.
        public AudioSource AudioSourceAttack2 { get => _audioSourceAttack2; set => _audioSourceAttack2 = value; }
        
        /// Getter for the player's gameObject.
        public GameObject ThisGameObject => gameObject;

        /// Inicializes the fields and sets up the statemachine states and transitions.
        private void Start()
        {
            Score.Instance.StartTimer();

            // field setup
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

            // value setup
            PushBackDir = 0f;

            SetupInventory();

            _moveComponent.Move.JumpSpeed = 400;
            _moveComponent.Move.DashRate = 0.5f;
            _moveComponent.Move.FallSpeed = 5f;
            _moveComponent.Move.PushBackSpeed = 5f;

            // state initializations
            var idle = new Idle(_rigidbody, _animator);
            var move = new Move(_moveComponent.Move, _animator, this);
            var jump = new Jump(_moveComponent.Move, _animator, this);
            var fall = new Fall(_moveComponent.Move, _animator, this);
            var pushBack = new PushBack(_moveComponent.Move, _animator, _rigidbody, this);
            var attack = new Attack(_attackComponent.Attack, _animator, _tagsToTarget.ToArray(), this, _moveComponent.Move);
            var death = new Death(_animator, this);

            // Transitions
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
            At(pushBack, fall, notPushedBack());

            At(idle, attack, isAttacking());
            At(move, attack, isAttacking());
            At(jump, attack, isAttacking());
            At(fall, attack, isAttacking());

            At(attack, idle, notAttackingAndIdle());
            At(attack, fall, notAttackingAndFalling());
            At(attack, pushBack, notAttackingAndPushedBack());

            At(death, idle, isAlive());
            _stateMachine.AddAnyTransition(death, isDead());

            // Tansition conditions
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
            Func<bool> notAttackingAndPushedBack() => () => CurrentItem == null && PushBackDir != 0f;
            Func<bool> isDead() => () => _characterComponent.Character.Health <= 0;
            Func<bool> isAlive() => () => _characterComponent.Character.Health > 0;

            void At(IState from, IState to, Func<bool> condition) => _stateMachine.AddTransition(from, to, condition);

            // default state set
            _stateMachine.SetState(idle);

            // data load
            var data = PersistentData.Instance.CurrentSave;

            if (data != null)
            {
                Load(data);
            }
        }

        /// Sets up default inventory.
        private void SetupInventory()
        {
            _magicItem = new MagicFocus(_magicFocusData[0]);
            _magicItem2 = new MagicFocus(_magicFocusData[1]);
            _consumableItem = new HealthPotion(_consumableData);

            _inventoryComponent.Inventory.AddItem(_magicItem, 1);
            _inventoryComponent.Inventory.AddItem(_magicItem2, 3);
            _inventoryComponent.Inventory.AddItem(_consumableItem, 2);

            _inventoryComponent.Inventory.SetUse(_magicItem);
            _inventoryComponent.Inventory.SetUse(_magicItem2);
            _inventoryComponent.Inventory.SetUse(_consumableItem);
        }

        /// Refills default inventory.
        private void RefillInventory()
        {

            if (_inventoryComponent.Inventory.InventoryShelf.ContainsKey(_magicItem2.Name))
            {
                var num = 10 - _inventoryComponent.Inventory.InventoryShelf[_magicItem2.Name].Quantity;
                _inventoryComponent.Inventory.AddItem(_magicItem2, num);
            }
            else
            {  
                _inventoryComponent.Inventory.AddItem(_magicItem2, 3);
                _inventoryComponent.Inventory.SetUse(_magicItem2);
            }
            
            if (_inventoryComponent.Inventory.InventoryShelf.ContainsKey(_consumableItem.Name))
            {
                var num = 4 - _inventoryComponent.Inventory.InventoryShelf[_consumableItem.Name].Quantity;
                _inventoryComponent.Inventory.AddItem(_consumableItem, num);
            }
            else
            {  
                _inventoryComponent.Inventory.AddItem(_consumableItem, 2);
                _inventoryComponent.Inventory.SetUse(_consumableItem);
            }
        }

        /// Runs the current state's Tick.
        private void Update() => _stateMachine?.Tick();
        
        /// First impact collision with enemy.
        private void OnCollisionEnter2D(Collision2D other) 
        {
            if (other.gameObject.tag == "Enemy")
            {
                PushBack(other.gameObject);
            }
        }
        
        /// Glitching into the enemy.
        private void OnCollisionStay2D(Collision2D other) 
        {
            if (other.gameObject.tag == "Enemy")
            {
                PushBack(other.gameObject);
            }
        }

        /// Pushes back from the oter entity.
        /*!
          \param other is entity you collided with.
        */
        public void PushBack(GameObject other)
        {
            if (Time.time >= _pushBackInmunity)
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
        }

        /// Checks if the player is grounded.
        internal bool GroundCheck()
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

        /// Resets values when player dies.
        public void Dead()
        {
            GetComponent<SpriteRenderer>().enabled = false;
            GetComponent<PlayerInput>().enabled = false;

            RefillInventory();

            inventoryUI.UpdateDisplay();

            GetComponent<InputController>().ResetTimes();

            Misc.ItemCooldownVisualizer.Instance.ResetAll();
        }

        /// Plays audio on step. 
        public void Step()
        {
            _audioSource.clip = MusicHandler.Instance.playerStep;
            _audioSource.Play();
        }

        /// Respawns the player.
        public IEnumerator Respawn()
        {
            DeathCanvas.SetActive(true);

            Score.Instance.StopTimer();
            Score.Instance.IncreaseDeaths();

            _enemys.SetActive(false);

            yield return new WaitForSeconds(5f);

            // reset values
            transform.position = _currentSpawnPoint.position;

            _characterComponent.Character.Health = _characterComponent.Character.MaxHealth;

            gameObject.GetComponent<IStatusHandlerComponent>().StatusHandler.RemoveAllStatuses();
            
            yield return new WaitForSeconds(2f);

            _enemys.SetActive(true);

            // reset default constrains
            _rigidbody.constraints = RigidbodyConstraints2D.None;
            _rigidbody.constraints = RigidbodyConstraints2D.FreezeRotation;

            // enables th visuals and the input of the player. 
            GetComponent<SpriteRenderer>().enabled = true;
            GetComponent<PlayerInput>().enabled = true;
            
            DeathCanvas.SetActive(false);

            Score.Instance.StartTimer();
        }

        /// Loads saved data.
        public void Load()
        {
            var data = PersistentData.Instance.CurrentSave;

            if (data != null)
            {
                Load(data);
            }
        }

        /// Loads saved data.
        /*!
          \param data is loaded gamedata.
        */
        private void Load(SaveData data)
        {
            transform.position = new Vector3(data.transform[0], data.transform[1], data.transform[2]);

            // score
            Score.Instance.ElapsedTime = data.time;
            Score.Instance.Kills = data.kills;
            Score.Instance.Deaths = data.deaths;
            Score.Instance.Name = data.name;

            _characterComponent.Character.Health = data.health;

            // inventory 
            _inventoryComponent.Inventory.RemoveAll();

            _inventoryComponent.Inventory.MainWeapon = ItemSorter(data.mainWeapon);

            for (int i = 0; i < data.inUseItems.Length; i++)
            {
                var item = ItemSorter(data.inUseItems[i]);

                if (item != null)
                {
                    _inventoryComponent.Inventory.AddItem(item, data.inUseItemsQuantity[i]);
                    _inventoryComponent.Inventory.SetUse(item);
                }
            }

            // enables th visuals and the input of the player. 
            gameObject.GetComponent<PlayerInput>().enabled = true;
            gameObject.GetComponent<Dummy>().enabled = true;

            gameObject.GetComponent<IStatusHandlerComponent>().StatusHandler.RemoveAllStatuses();

            // resets default constrains.
            _rigidbody.constraints = RigidbodyConstraints2D.None;
            _rigidbody.constraints = RigidbodyConstraints2D.FreezeRotation;

            inventoryUI.UpdateDisplay();
        }

        /// Gives the requested item by name.
        /*!
          \param name is the items name.
          \returns IItem.
        */
        private IItem ItemSorter(string name)
        {
            switch(name)
            {
                case "Katana":
                    return ItemFactory.GetItem(name, AllScriptableObjects.Instance.katana);

                case "Masamune":
                    return ItemFactory.GetItem(name, AllScriptableObjects.Instance.masamune);

                case "Muramasa":
                    return ItemFactory.GetItem(name, AllScriptableObjects.Instance.muramasa);

                case "Cure Potion":
                    return ItemFactory.GetItem(name, AllScriptableObjects.Instance.curePotion);

                case "Health Potion":
                    return ItemFactory.GetItem(name, AllScriptableObjects.Instance.healthPotion);

                case "Fire Burst":
                    return ItemFactory.GetItem(name, AllScriptableObjects.Instance.fireBurst);

                case "Ice Lance":
                    return ItemFactory.GetItem(name, AllScriptableObjects.Instance.iceLance);
                
                default:
                    return null;
            }
        }
        
    }
}
