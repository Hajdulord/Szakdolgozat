using UnityEngine;
using HMF.Thesis.Interfaces;
using HMF.Thesis.ScriptableObjects;

namespace HMF.Thesis.Logic
{
    /// The Logic class for an Implementation of a Character.
    public class CharacterLogic : ICharacter
    {
        private int _health; ///< The Current health of the Character.
        private CharacterData _characterData = null; ///< The data of the Character.

        /// Basic constructor with CharacterData as data
        /*!
        \param character is a CharacterData that is Scriptable object.
        */
        public CharacterLogic(CharacterData character)
        {
            _characterData = character;
            _health = _characterData.maxHealth;
        }

        /// Propery for the current health of the Character. It clapms the health between 0 and MaxHealth.
        public int Health { get => Mathf.Max(0, _health); set => _health = Mathf.Min(Mathf.Max(0, value), MaxHealth); }

        /// Getter for MaxHealth.
        public int MaxHealth => _characterData.maxHealth;

        /// Getter for CharacterName.
        public string CharacterName => _characterData.characterName;

        /// Getter for CharacterSprite.
        public Sprite CharacterSprite => _characterData.sprite;
    }
}
