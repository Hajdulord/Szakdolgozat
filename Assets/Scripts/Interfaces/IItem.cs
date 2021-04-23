using UnityEngine;

namespace HMF.Thesis.Interfaces
{
    public interface IItem
    {
        string Name {get;}
        bool Unique {get;}
        Sprite Sprite {get;}
        TargetType TargetType {get;}
        string Description {get;}
        float attackTime {get;}

        void Use(GameObject origin, string[] tagsToTarget, LayerMask layersToTarget);
    }

    public enum TargetType
    {
        Self,
        Other
    }
}
