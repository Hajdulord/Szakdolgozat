using UnityEngine;
using HMF.Thesis.Interfaces;
using HMF.Thesis.Logic;
using HMF.Thesis.ScriptableObjects;

namespace HMF.Thesis.Components
{
    /// A wrapper for the MoveLogic.
    [RequireComponent(typeof(CharacterController))]
    public class MoveComponent : MonoBehaviour
    {
        [Header("Serialized Fields")]
        [SerializeField] private CharacterData _character = null!; ///< The Character's data.
        private CharacterController _controller; ///< Needed for basic movement.
        private IMove _move; ///< The logic behind movement.

        /// Public getter for IMove.
        public IMove Move => _move;

        /// Sets the Controller and the Move logic.
        private void Awake() {
            _controller = GetComponent<CharacterController>();
            _move = new MoveLogic(_character, _controller);
        }
    }
}
