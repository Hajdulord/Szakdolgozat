using UnityEngine;

namespace HMF.Thesis.Interfaces
{
    public interface IItem
    {
        string Name {get; set;}
        bool Unique {get; set;}
        Sprite Sprite {get; set;}
        TargetType TargetType {get; set;}

        void Use(GameObject target);
    }

    public enum TargetType
    {
        Self,
        Other
    }
}
