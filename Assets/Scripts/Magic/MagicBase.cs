using HMF.Thesis.ScriptableObjects;
using UnityEngine;

namespace HMF.Thesis.Magic
{
    public abstract class MagicBase
    {
        public abstract string Name {get;}

        public abstract void Use(string[] tagsToIgnore, MagicFocusData magicFocus, Vector2 center, float dir = 0);
        
    }
}
