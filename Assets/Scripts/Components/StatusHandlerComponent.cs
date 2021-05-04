using UnityEngine;
using HMF.Thesis.Status;
using HMF.Thesis.Interfaces;
using HMF.Thesis.Interfaces.ComponentInterfaces;

//! Needs Comments!
namespace HMF.Thesis.Components
{
    [RequireComponent(typeof(Dummy))]
    /// The wrapper component of the status handler.
    public class StatusHandlerComponent : MonoBehaviour, IStatusHandlerComponent
    {
        private IStatusHandler _statusHandler; ///< The status handler logic.

        /// Getter of the status handler.
        public IStatusHandler StatusHandler => _statusHandler;

        private void Awake() 
        {
            _statusHandler = new StatusHandler(gameObject);
        }

    }
}
