using UnityEngine;
using HMF.Thesis.Interfaces;

namespace HMF.Thesis.Logic
{
    public class HealableLogic : IHealable
    {
        private ICharacter _character;

        public HealableLogic(ICharacter character)
        {
            _character = character;
        }

        public void Heal(float healAmount = 1)
        {
            _character.Health += healAmount;
        }
    }
}
