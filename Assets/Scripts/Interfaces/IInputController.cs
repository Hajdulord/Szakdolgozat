using UnityEngine.InputSystem;

//! Needs Comments!
namespace HMF.Thesis.Interfaces
{
    /// The Interface that represents a Player's inputs.
    public interface IInputController
    {
        /// Parses the jump input.
        /*!
          \param callback holds the data from the input that triggered the action.
        */
        void Jump(InputAction.CallbackContext callback);

        /// Parses the move input.
        /*!
          \param callback holds the data from the input that triggered the action.
        */
        void Move(InputAction.CallbackContext callback);

        /// Parses the dash input.
        /*!
          \param callback holds the data from the input that triggered the action.
        */
        void Dash(InputAction.CallbackContext callback);

        /// Parses the normal melee attack input.
        /*!
          \param callback holds the data from the input that triggered the action.
        */
        void NormalMeleeAttack(InputAction.CallbackContext callback);

        /// Parses the first incentory input.
        /*!
          \param callback holds the data from the input that triggered the action.
        */
        void InventoryOne(InputAction.CallbackContext callback);

        /// Parses the second inventory input.
        /*!
          \param callback holds the data from the input that triggered the action.
        */
        void InventoryTwo(InputAction.CallbackContext callback);

        /// Parses the third inventory input.
        /*!
          \param callback holds the data from the input that triggered the action.
        */
        void InventoryThree(InputAction.CallbackContext callback);

        /// Parses the fourth inventory input.
        /*!
          \param callback holds the data from the input that triggered the action.
        */
        void InventoryFour(InputAction.CallbackContext callback);

        /// Pauses the game.
        void Pause();

        /// Unpauses the game.
        void UnPause();

        /// Parses the pause input.
        /*!
          \param callback holds the data from the input that triggered the action.
        */
        void PauseCall(InputAction.CallbackContext callback);

        /// Parses the pickup input.
        /*!
          \param callback holds the data from the input that triggered the action.
        */
        void PickUp(InputAction.CallbackContext callback);
    }
}
