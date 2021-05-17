using HMF.Thesis.Interfaces;

namespace HMF.Thesis.Logic
{
    /// The Logic behind healing.
    public class HealableLogic : IHealable
    {
        private ICharacter _character; ///< The character's data. 

        /// Constructor to set _character;
        public HealableLogic(ICharacter character)
        {
            _character = character;
        }

        /// Heals by given amount.
        /*!
          \param healAmount is the value to heal, defaults to 1.
        */
        public void Heal(float healAmount = 1)
        {
            _character.Health += healAmount;
        }
    }
}
