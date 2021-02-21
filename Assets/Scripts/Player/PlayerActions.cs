using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HMF.Thesis.Interfaces;

namespace HMF.Thesis.Player
{
    /// Class for Actions like Take damage and Reset.
    [RequireComponent(typeof(PlayerItems))]
    public class PlayerActions : MonoBehaviour, IDamageable
    {
        [Header("Serialized Fields")]
        [SerializeField] private PlayerItems _player = null!; ///< The Player's data.

        /// Reduces the Health of the Player by one.
        public void TakeDamage()
        {
            --_player.Health;
        }

        /// Reduces the Health of the Player by a set amount.
        /*!
          \param damage is the damage you substract from your health.
        */
        public void TakeDamage(int damage = 1)
        {
            _player.Health -= damage;
        }
    }
}
