using UnityEngine.InputSystem;

//! Needs Comments!
namespace HMF.Thesis.Interfaces
{
    public interface IInputController
    {
        void Jump(InputAction.CallbackContext callback);
        void Move(InputAction.CallbackContext callback);
        void Dash(InputAction.CallbackContext callback);
        void NormalMeleeAttack(InputAction.CallbackContext callback);
        void InventoryOne(InputAction.CallbackContext callback);
        void InventoryTwo(InputAction.CallbackContext callback);
        void InventoryThree(InputAction.CallbackContext callback);
        void InventoryFour(InputAction.CallbackContext callback);
        void Pause(InputAction.CallbackContext callback);
        void UnPause();
    }
}
