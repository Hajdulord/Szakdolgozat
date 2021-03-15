using HMF.Thesis.Interfaces;
using UnityEngine;
using System.Collections.Generic;

namespace HMF.Thesis.Magic
{
    public class MagicHandler : IMagicHandler
    {
        private GameObject _gameObject;

        private Dictionary<string, MagicBase> _magic;

        public MagicHandler(GameObject gameObject)
        {
            _gameObject = gameObject;
            _magic = new Dictionary<string, MagicBase>();
        }

        public void AddNewMagic(string magic)
        {
            if (_magic.ContainsKey(magic))
                return;
            
            var newMagic = MagicFactory.GetMagic(magic);

            if (newMagic != null)
            {
                _magic.Add(magic, newMagic);
            }
        }

        public void RemoveMagic(string magic)
        {
            if (_magic.ContainsKey(magic))
            {
                _magic.Remove(magic);
            }
        }

        public void UseMagic(string magic)
        {
            if (_magic.ContainsKey(magic))
            {
                _magic[magic].Use(_gameObject);
            }
        }
    }
}
