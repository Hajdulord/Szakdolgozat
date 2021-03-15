using UnityEngine;
using HMF.Thesis.Interfaces;
using HMF.Thesis.Interfaces.ComponentInterfaces;
using HMF.Thesis.Magic;

namespace HMF.Thesis.Components
{
    public class MagicHandlerComponent : MonoBehaviour, IMagicHandlerComponent
    {
        private IMagicHandler _magicHandler;
        public IMagicHandler MagicHandler => _magicHandler;

        private void Awake() 
        {
            _magicHandler = new MagicHandler(gameObject);
        }
    }
}
