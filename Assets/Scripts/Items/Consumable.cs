using UnityEngine;
using HMF.Thesis.Interfaces;

namespace HMF.Thesis.Items
{
    public abstract class Consumable : IItem
    {
        public abstract string Name {get; }

        public abstract bool Unique {get; }

        public abstract Sprite Sprite {get; }

        public abstract TargetType TargetType {get; }

        public abstract string Description {get; }

        public abstract float attackTime {get; }

        public abstract void Use(GameObject origin, string[] tagsToTarget, LayerMask layersToTarget);
    }
}
