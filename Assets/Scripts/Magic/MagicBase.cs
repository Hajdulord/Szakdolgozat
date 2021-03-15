using UnityEngine;

namespace HMF.Thesis.Magic
{
    public abstract class MagicBase
    {
        public abstract string Name {get;}

        public abstract void Use(GameObject gameObject);
        
    }
}
