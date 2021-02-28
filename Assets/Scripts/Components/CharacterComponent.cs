using UnityEngine;
using HMF.Thesis.Logic;
using HMF.Thesis.Interfaces;
using HMF.Thesis.ScriptableObjects;

namespace HMF.Thesis.Components
{
    /// Character Component that wraps the CharacterLogic class.
    [RequireComponent(typeof(SpriteRenderer))]
    public class CharacterComponent : MonoBehaviour
    {
        [Header("Serialized Fields")]
        [SerializeField] private CharacterData _characterData = null!; ///< The data of the Character.
        private ICharacter _character; ///< The Logic that this class wraps Character.

        /// Getter for the Character logic.
        public ICharacter Character => _character;

        /// Sets basic values.        
        private void Awake() 
        {
            _character = new CharacterLogic(_characterData);

            GetComponent<SpriteRenderer>().sprite = _character.CharacterSprite;
        }
    }
}
