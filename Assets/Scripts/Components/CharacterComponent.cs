using UnityEngine;
using HMF.Thesis.Logic;
using HMF.Thesis.Interfaces;
using HMF.Thesis.Interfaces.ComponentInterfaces;
using HMF.Thesis.ScriptableObjects;
using HMF.Thesis.Misc;

namespace HMF.Thesis.Components
{
    /// Character Component that wraps the CharacterLogic class.
    [RequireComponent(typeof(SpriteRenderer))]
    public class CharacterComponent : MonoBehaviour, ICharacterComponent
    {
        [Header("Serialized Fields")]
        [SerializeField] private CharacterData _characterData = null!; ///< The data of the Character.
        [SerializeField] private HealthBar _healthBar = null; ///< The healtbar script.
        private ICharacter _character; ///< The Logic that this class wraps Character.

        /// Getter for the Character logic.
        public ICharacter Character => _character;

        /// Sets basic values.        
        private void Awake() 
        {
            _character = new CharacterLogic(_characterData, _healthBar);
            GetComponent<SpriteRenderer>().sprite = Character.CharacterSprite;
        }
    }
}
