using UnityEngine;

namespace HMF.Thesis.ScriptableObjects
{
    public class Item : ScriptableObject
    {
        public string type;

        public Sprite sprite;

        public virtual void Use(GameObject gameObject)
        {

        }
    }

    public enum Status
    {
        None,
        Burning,
        Healing,
        Frozen,
        Bleeding,
        Stunned
    }
}
