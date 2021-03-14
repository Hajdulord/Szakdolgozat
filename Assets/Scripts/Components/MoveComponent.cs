using UnityEngine;
using HMF.Thesis.Interfaces;
using HMF.Thesis.Interfaces.ComponentInterfaces;
using HMF.Thesis.Logic;
using HMF.Thesis.ScriptableObjects;

namespace HMF.Thesis.Components
{
    /// A wrapper for the MoveLogic.
    [RequireComponent(typeof(Rigidbody2D))]
    [RequireComponent(typeof(CapsuleCollider2D))]
    public class MoveComponent : MonoBehaviour, IMoveComponent
    {
        [Header("Serialized Fields")]
        [SerializeField] private CharacterData _character = null!; ///< The Character's data.
        private Rigidbody2D _rigidbody = null!; ///< Needed for physics.
        private IMove _move = null!; ///< The logic behind movement.

        /// Public getter for IMove.
        public IMove Move => _move;

        /// Sets the Controller and the Move logic.
        private void Awake() 
        {
            _rigidbody = GetComponent<Rigidbody2D>();
            _move = new MoveLogic(_character, _rigidbody);
        }
    }
}
