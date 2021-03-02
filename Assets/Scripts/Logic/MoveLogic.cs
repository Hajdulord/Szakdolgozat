using UnityEngine;
using HMF.Thesis.Interfaces;
using HMF.Thesis.ScriptableObjects;

//! Implementation needed.
namespace HMF.Thesis.Logic
{
    /// Logic fore the mocement.
    public class MoveLogic : IMove
    {
        private float GRAVITY;
        private CharacterData _character; ///< The thata of a Character.
        private Rigidbody2D _rigidbody; ///< Used for physics.
        private Vector2 _movementVector;

        /// The Constructor where we set the cahracterData and the characterController.
        /*!
          \param character is a CharacterData where we get the common data of a character.
          \param rigidbody is a Rigidbody2D that  we need for the movement.
        */
        public MoveLogic(CharacterData character, Rigidbody2D rigidbody)
        {
            _character = character;
            _rigidbody = rigidbody;
            BaseSpeed = _character.baseSpeed;
            Speed = BaseSpeed;
            _movementVector = Vector2.zero;

            GRAVITY = Physics2D.gravity.y;
        }

        /// Base speed of the object.
        public int BaseSpeed {get; set;}

        /// The current speed of the Character;
        public int Speed {get;set;}

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
        /*!
          \param direction is the direction of the movement.
        */
        public void Move(int direction)
        {
            _movementVector.x = direction;

            _rigidbody.MovePosition(_rigidbody.position + _movementVector * Time.deltaTime * Speed);
        }

        /// Makes the object Jump.
        public void Jump()
        {
            throw new System.NotImplementedException();
        }
    }
}
