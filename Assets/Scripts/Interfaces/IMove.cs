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
        /// The height of the Jump.
        int JumpHeight {get; set;}
        /// The speed of the Jump.
        int JumpSpeed {get; set;}
        /// Maximu height of the current jump.
        float JumpMaxHeight{get; set;}
        /// Basic movement logic.
        /*!
          \param direction is the direction of the movement.
        */
        void Move(int direction);
        /// Dashing logic.
        void Dash();
        /// Sets the height of the jump.
        void JumpSet();
        /// Implementation of a jump.
        /*!
          \param direction is the horizontal direction of the movement.
        */
        void Jump(int direction);
        /// Resets the movementVector y;
        void ResetY();
        /// Applying force to push back the object.
        void PushBack();
        /// Basic movement to a Vector to.
        /*!
          \param to is the palce to move towards.
        */
        void MoveToPoint(Vector2 to);
    }
}
