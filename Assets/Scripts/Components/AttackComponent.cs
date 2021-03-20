using HMF.Thesis.Interfaces.ComponentInterfaces;
using HMF.Thesis.Interfaces;
using HMF.Thesis.Logic;
using UnityEngine;

namespace HMF.Thesis.Components
{
    public class AttackComponent : IAttackComponent
    {
        [Header("Serializable Fields")]
        [SerializeField] private GameObject _origin = null!;

        private IAttack _attack;
        public IAttack Attack => _attack;

        private void Awake()
        {
            _attack = new AttackLogic(_origin);
        }
    }
}
