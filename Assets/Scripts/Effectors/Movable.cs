using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HMF.Thesis.Interfaces;

//! Implementation is needed!
namespace HMF.Thesis.Effectors
{
    /// A class for movig an object.
    public class Movable : MonoBehaviour, IMove
    {
        /// Fast movement to a direction.
        public void Dash()
        {
            throw new System.NotImplementedException();
        }

        /// Moves to a specific poin.
        /*!
          \param to is the Vector2 that the object is moving towards.
        */
        public void MoveToPoint(Vector2 to)
        {
            throw new System.NotImplementedException();
        }

        /// Object is pushed back.
        public void PushBack()
        {
            throw new System.NotImplementedException();
        }

        /// Moves to a direction.
        public void Move()
        {
            throw new System.NotImplementedException();
        }
    }
}
