using HMF.Thesis.ScriptableObjects;
using UnityEngine;

namespace HMF.Thesis.Magic
{
    /// The Base class for all magics.
    public abstract class MagicBase
    {
        /// The Name of the magic.
        public abstract string Name {get;}

        /// Use the magic's effect.
        /*!
          \param tagsToTarget are the target tags.
          \param magicFocus is the data part of the magic.
          \param center is the center of the magic.
          \param layersToTarget are the target layers.
          \param animaton is the animation to play.
          \param dir is the direction of the magic.
        */
        public abstract void Use(string[] tagsToTarget, MagicFocusData magicFocus, Vector2 center, LayerMask layersToTarget, GameObject animaton, float dir = 0);
        
    }
}
