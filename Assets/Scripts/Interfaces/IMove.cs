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
        float Speed {get;set;}

        /// The speed of the Jump.
        int JumpSpeed {get; set;}

        /// The speed of the pushback.
        float PushBackSpeed {get; set;}

        /// The speed of the fall.
        float FallSpeed {get; set;}

        /// The Rate that the Character can dash.
        float DashRate {get; set;}

        /// Basic movement logic.
        /*!
          \param direction is the direction of the movement.
        */
        void Move(int direction);

        /// Dashing logic.
        void Dash();

        /// Implementation of a jump.
        /*!
          \param direction is the horizontal direction of the movement.
        */
        void Jump(int direction);

        /// Applying force to push back the object.
        /*!
          \param direction is the horizontal direction that the object follows when it is pushed back.
        */
        void PushBack(float direction);

        /// Basic movement to a Vector to.
        /*!
          \param to is the palce to move towards.
        */
        void MoveToPoint(Vector2 to);

        /// Makes the object fall.
        void Fall();
    }
}
