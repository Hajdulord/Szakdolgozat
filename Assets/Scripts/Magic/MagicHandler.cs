using HMF.Thesis.Interfaces;
using UnityEngine;
using System.Collections.Generic;
using HMF.Thesis.ScriptableObjects;

namespace HMF.Thesis.Magic
{
    /// Class for handling the casting of magic.
    public class MagicHandler : IMagicHandler
    {
        private Dictionary<string, (MagicBase magic, MagicFocusData magicFocus)> _magic; ///< Cache of the used magic.

        /// Constructor to initialize _magic dictionary.
        public MagicHandler()
        {
            _magic = new Dictionary<string, (MagicBase, MagicFocusData)>();
        }

        // Adds a new magic to _magic.
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

        /// Removes a magic from _magic
        public void RemoveMagic(string magic)
        {
            if (_magic.ContainsKey(magic))
            {
                _magic.Remove(magic);
            }
        }

        /// If a magic is in _magic cast that magic.
        /*!
          \param magic is the name of the magic.
          \param tagsToTarget is a string array that holds all the tags the attack will target.
          \param center is the center of the magic.
          \param layersToTarget is a LayerMask. You can set it to the lyers you want to target. It makes the target finding faster, than just tag based identifying.
          \param animation is ta animation to play.
          \param dir is the direction of the magic.
        */
        public void UseMagic(string magic, string[] tagsToTarget, Vector2 center, LayerMask layersToTarget, GameObject animation, float dir = 0)
        {
            if (_magic.ContainsKey(magic))
            {
                var magicFocus = _magic[magic].magicFocus;
                _magic[magic].magic.Use(tagsToTarget, magicFocus, center, layersToTarget, animation, dir);
            }
        }

        /// If magic is in _magic gets its MagicFocus.
        /*!
          \param magic is the name of the magic.
        */
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
