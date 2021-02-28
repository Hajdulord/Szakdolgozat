using UnityEngine;
using HMF.Thesis.Interfaces;
using HMF.Thesis.ScriptableObjects;

//! Implementation needed.
namespace HMF.Thesis.Logic
{
    /// Logic fore the mocement.
    public class MoveLogic : IMove
    {
        private CharacterData _character; ///< The thata of a Character.

        private CharacterController _characterController; ///< Used for basic movement.

        /// The Constructor where we set the cahracterData and the characterController.
        /*!
          \param character is a CharacterData where we get the common data of a character.
          \param characterController is a CharacterController that  we need for the movement.
        */
        public MoveLogic(CharacterData character, CharacterController characterController)
        {
            _character = character;
            _characterController = characterController;
        }

        /// Base speed of the object.
        public int BaseSpeed {get; set;}

        /// The Jumpfore of the object.
        public int JumpForce { get; set;}

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

        /// Makes the object Jump.
        public void Jump()
        {
            throw new System.NotImplementedException();
        }
    }
}
