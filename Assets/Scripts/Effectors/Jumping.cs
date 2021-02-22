using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HMF.Thesis.Interfaces;

//! Need Implementation.
namespace HMF.Thesis.Effectors
{
    /// One Implementation of Jumping.
    public class Jumping : MonoBehaviour, IJump
    {
        /// The fore of the Jump that is applied to the object.
        public int JumpForce { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }
        
        /// Jump Command.
        public void Jump()
        {
            throw new System.NotImplementedException();
        }
    }
}
