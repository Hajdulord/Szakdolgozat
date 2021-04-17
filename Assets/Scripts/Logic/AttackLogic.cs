using UnityEngine;
using HMF.Thesis.Interfaces;

namespace HMF.Thesis.Logic
{
    public class AttackLogic : IAttack
    {
        public GameObject Origin {get; set;}

        public AttackLogic(GameObject origin)
        {
            Origin = origin;
        }

        public void Attack(IItem item, string[] tagsToTarget)
        {
            item.Use(Origin, tagsToTarget);
        }
    }
}
