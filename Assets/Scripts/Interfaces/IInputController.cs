using UnityEngine.InputSystem;

//! Needs Comments!
namespace HMF.Thesis.Interfaces
{
    public interface IInputController
    {
        public void Jump(InputAction.CallbackContext callback);
        public void Move(InputAction.CallbackContext callback);
        public void Dash(InputAction.CallbackContext callback);
        public void NormalMeleeAttack(InputAction.CallbackContext callback);
    }
}
