using UnityEngine;

namespace HMF.Thesis.ScriptableObjects
{
    public class Item : ScriptableObject
    {
        public string itemName;

        public string type;

        public string description;

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
