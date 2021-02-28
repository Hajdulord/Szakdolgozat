using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HMF.Thesis.Interfaces;
using HMF.Thesis.Logic;

namespace HMF.Thesis
{   
    /// A wrapper for DamageableCharacter.
    public class DamageableCharacterComponent : MonoBehaviour
    {
        private ICharacter _character = null!; ///< The Character's health comes from here.
        private DamageableCharacterComponent _damageable; ///< The logic behind this class.

        /// Getter for the Damageable logic.
        public DamageableCharacterComponent Damageable => _damageable;

        /// Gets the Character.
        private void Awake() 
        {
            _character = GetComponent<ICharacter>();
        }
    }
}
