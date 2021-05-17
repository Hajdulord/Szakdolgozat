using UnityEngine;
using HMF.Thesis.Interfaces;
using HMF.Thesis.Interfaces.ComponentInterfaces;
using HMF.Thesis.Magic;

namespace HMF.Thesis.Components
{
    /// The wrapper component of the magic handler.
    public class MagicHandlerComponent : MonoBehaviour, IMagicHandlerComponent
    {
        private IMagicHandler _magicHandler; ///< The data of the magic handler.

        /// Getter for the magic handler.
        public IMagicHandler MagicHandler => _magicHandler;

        private void Awake() 
        {
            _magicHandler = new MagicHandler();
        }
    }
}
