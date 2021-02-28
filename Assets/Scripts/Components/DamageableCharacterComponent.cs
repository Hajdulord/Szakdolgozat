using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HMF.Thesis.Interfaces;
using HMF.Thesis.Logic;

namespace HMF.Thesis.Components
{   
    /// A wrapper for DamageableCharacter.
    public class DamageableCharacterComponent : MonoBehaviour
    {
        private ICharacter _character = null!; ///< The Character's health comes from here.
        private IDamageable _damageable; ///< The logic behind this class.

        /// Getter for the Damageable logic.
        public IDamageable Damageable => _damageable;

        /// Gets the Character.
        private void Awake() 
        {
            _character = GetComponent<ICharacter>();
            _damageable = new DamageableCharacterLogic(_character);
        }
    }
}
