using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HMF.Thesis.Interfaces;

namespace HMF.Thesis.Player
{
    /// This class is used for storing the player's data.
    public class PlayerItems : MonoBehaviour, IEntity 
    {
        [SerializeField] private int _health = 5; ///< The player's health.
        [SerializeField] private int _speed = 10; ///< The player's speed.
        [SerializeField] private int _jumpForce = 5; ///< The player's jump force.

        /// Public property for Health.
        public int Health
        {
            get{ return Mathf.Max(0, _health); }
            set{ _health = Mathf.Max(0, value); }
        }
        
        /// Public property for Speed.
        public int Speed
        {
            get{ return Mathf.Max(0, _speed); }
            set{ _speed = Mathf.Max(0, value); }
        }

        /// Public property for JumpForce.
        public int JumpForce
        {
            get{ return Mathf.Max(0, _jumpForce); }
            set{ _jumpForce = Mathf.Max(0, value); }
        }
    }
}
