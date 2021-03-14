using UnityEngine;
using HMF.Thesis.Status;
using HMF.Thesis.Interfaces;
using HMF.Thesis.Interfaces.ComponentInterfaces;

//! Needs Comments!
namespace HMF.Thesis.Components
{
    public class StatusHandlerComponent : MonoBehaviour, IStatusHandlerComponent
    {
        private IStatusHandler _statusHandler;

        public IStatusHandler StatusHandler => _statusHandler;

        private void Awake() 
        {
            _statusHandler = new StatusHandler(gameObject);
        }

        
        private void Update()
        {
            _statusHandler.CalculateStatusEffects();
        }
    }
}
