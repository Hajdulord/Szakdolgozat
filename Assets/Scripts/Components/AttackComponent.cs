using HMF.Thesis.Interfaces.ComponentInterfaces;
using HMF.Thesis.Interfaces;
using HMF.Thesis.Logic;
using UnityEngine;

namespace HMF.Thesis.Components
{
    /// The Component that wraps the Attack Logic.
    public class AttackComponent : MonoBehaviour, IAttackComponent
    {
        [Header("Serializable Fields")]
        [SerializeField] private GameObject _origin = null!; ///< The origin of the attack.

        private IAttack _attack; ///< The attack logic.

        /// Getter for attack logic.
        public IAttack Attack => _attack;

        private void Awake()
        {
            _attack = new AttackLogic(_origin);
        }
    }
}
