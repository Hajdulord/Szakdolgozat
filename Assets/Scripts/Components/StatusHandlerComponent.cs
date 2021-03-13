using UnityEngine;
using HMF.Thesis.Status;

//! Needs Comments!
namespace HMF.Thesis.Components
{
    public class StatusHandlerComponent : MonoBehaviour
    {
        private StatusHandler _statusHandler;

        public StatusHandler StatusHandler => _statusHandler;

        private void Awake() 
        {
            _statusHandler = new StatusHandler();
        }

        
        private void Update()
        {
            _statusHandler.CalculateStatusEffects();
        }
    }
}
