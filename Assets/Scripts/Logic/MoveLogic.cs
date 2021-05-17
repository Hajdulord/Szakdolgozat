using UnityEngine;
using HMF.Thesis.Interfaces;
using HMF.Thesis.ScriptableObjects;
using HMF.HMFUtilities.Utilities;

namespace HMF.Thesis.Logic
{
	/// Logic for the movement.
	public class MoveLogic : IMove
	{
		private CharacterData _character; ///< The data of a Character.
		private Rigidbody2D _rigidbody; ///< Used for physics.
		private Vector2 _movementVector; ///< The vector for the movement.
		private float _dashDistance = 5f; ///< The distance of the dash.
		private int _chachedDirection = 1; ///< The cached direction of the movement.
		private float _nextDashTime = 0f; ///< Time of the next possible dash.

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
		}

		/// Base speed of the object.
		public int BaseSpeed {get; set;}

		/// The current speed of the Character;
		public float Speed {get;set;}

		/// The speed of the Jump.
		public int JumpSpeed {get; set;}

		/// The speed of the pushback.
		public float PushBackSpeed { get; set; }

		/// The speed of the fall.
		public float FallSpeed { get; set; }

		/// The Rate that the Character can dash.
		public float DashRate {get; set;}

		/// Fast movement to a direction.
		public bool Dash()
		{
			if (Time.time >= _nextDashTime)
			{
				_rigidbody.MovePosition(_rigidbody.position + new Vector2(_chachedDirection, 0) *  _dashDistance);
				_nextDashTime = Time.time + 1f / DashRate;
				return true;
			}

			return false;
		}

		/// Moves to a specific poin.
		/*!
			\param to is the Vector2 that the object is moving towards.
		*/
		public void MoveToPoint(Vector2 to)
		{
			var dir = 0;
			if (HMFutilities.DirectionTo(_rigidbody.transform.position.x, to.x) >= 0)
			{
				dir = 1;
			}
			else
			{
				dir = -1;
			}
			_rigidbody.velocity = new Vector2(dir * Speed, _rigidbody.velocity.y );
		}

		/// Object is pushed back.
		/*!
			\param direction is the horizontal direction that the object follows when it is pushed back.
		*/
		public void PushBack(float direction)
		{
			_rigidbody.velocity = new Vector2(direction * PushBackSpeed, _rigidbody.velocity.y);
		}

		/// Moves to a direction.
		/*!
			\param direction is the direction of the movement.
		*/
		public void Move(int direction)
		{
			_movementVector.x = direction * Speed;
			_movementVector.y = _rigidbody.velocity.y;

			if (direction != 0)
			{
					_chachedDirection = direction;
					_rigidbody.gameObject.transform.right = new Vector3(direction, 0, 0);
			}

			_rigidbody.velocity = _movementVector;

		}

		/// Makes the object Jump.
		/*!
			\param direction is the horizontal direction of the movement.
		*/
		public void Jump()
		{
			_rigidbody.velocity = Vector2.zero;
			_rigidbody.AddForce(Vector2.up * JumpSpeed);
		}

		/// Makes the object fall.
		public void Fall()
		{
			_rigidbody.AddForce(Vector2.down * FallSpeed, ForceMode2D.Impulse);
		}

	}
}
