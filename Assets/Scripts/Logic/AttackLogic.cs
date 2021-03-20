using UnityEngine;
using HMF.Thesis.Interfaces;

namespace HMF.Thesis.Logic
{
    public class AttackLogic : IAttack
    {
        private GameObject _origin;

        public AttackLogic(GameObject origin)
        {
            _origin = origin;
        }

        public void Attack(IItem item, string[] tagsToTarget)
        {
            item.Use(_origin, tagsToTarget);
        }
    }
}
