using HMF.Thesis.Interfaces;
using UnityEngine;
using System.Collections.Generic;
using HMF.Thesis.ScriptableObjects;

namespace HMF.Thesis.Magic
{
    public class MagicHandler : IMagicHandler
    {
        private Dictionary<string, (MagicBase magic, MagicFocusData magicFocus)> _magic;

        public MagicHandler(GameObject gameObject)
        {
            _magic = new Dictionary<string, (MagicBase, MagicFocusData)>();
        }

        public void AddNewMagic(string magic, MagicFocusData magicFocus)
        {
            if (_magic.ContainsKey(magic))
                return;
            
            var newMagic = MagicFactory.GetMagic(magic);

            if (newMagic != null)
            {
                _magic.Add(magic, (newMagic, magicFocus));
            }
        }

        public void RemoveMagic(string magic)
        {
            if (_magic.ContainsKey(magic))
            {
                _magic.Remove(magic);
            }
        }

        public void UseMagic(string magic, string[] tagsToIgnore, Vector2 center, GameObject animation, float dir = 0)
        {
            if (_magic.ContainsKey(magic))
            {
                var magicFocus = _magic[magic].magicFocus;
                _magic[magic].magic.Use(tagsToIgnore, magicFocus, center, animation, dir);
            }
        }

        public MagicFocusData GetMagicFocus(string magic)
        {
            if (_magic.ContainsKey(magic))
            {
                return _magic[magic].magicFocus;
            }

            return null;
        }
    }
}
