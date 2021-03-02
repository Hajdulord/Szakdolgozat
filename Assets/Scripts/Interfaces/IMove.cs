using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//! Needs corrections for parameters.
namespace HMF.Thesis.Interfaces
{
    /// Interface for Movement.
    public interface IMove
    {
        /// Base speed of the object.
        int BaseSpeed {get; set;}
        /// The current speed of the Character;
        int Speed {get;set;}
        /// Jump Force of the object.
        int JumpForce {get; set;}
        /// Basic movement logic.
        /*!
          \param direction is the direction of the movement.
        */
        void Move(int direction);
        /// Dashing logic.
        void Dash();
        /// Applying force to push back the object.
        /// Implementation of a jump.
        void Jump();
        void PushBack();
        /// Basic movement to a Vector to.
        /*!
          \param to is the palce to move towards.
        */
        void MoveToPoint(Vector2 to);
    }
}
