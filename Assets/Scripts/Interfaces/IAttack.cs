//! Needs Implementation!
using UnityEngine;

namespace HMF.Thesis.Interfaces
{
    public interface IAttack
    {
        GameObject Origin { get; set; }

        void Attack(IItem item, string[] tagsToTarget);
    }
}
