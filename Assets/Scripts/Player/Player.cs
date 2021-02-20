using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HMF.Thesis.Player
{
    public class Player : MonoBehaviour
    {
        [SerializeField] private int _health = 5;
        [SerializeField] private int _speed = 10;
        [SerializeField] private int _jumpForce = 5;

        public int Health
        {
            get{ return Mathf.Max(0, _health); }
            private set{ _health = Mathf.Max(0, value); }
        }
        
        public int Speed
        {
            get{ return Mathf.Max(0, _speed); }
            private set{ _speed = Mathf.Max(0, value); }
        }

        public int JumpForce
        {
            get{ return Mathf.Max(0, _jumpForce); }
            private set{ _speed = Mathf.Max(0, _jumpForce); }
        }
    }
}
