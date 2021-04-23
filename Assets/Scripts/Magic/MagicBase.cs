using HMF.Thesis.ScriptableObjects;
using UnityEngine;

namespace HMF.Thesis.Magic
{
    public abstract class MagicBase
    {
        public abstract string Name {get;}

        public abstract void Use(string[] tagsToTarget, MagicFocusData magicFocus, Vector2 center, LayerMask layersToTarget, GameObject animaton, float dir = 0);
        
    }
}
