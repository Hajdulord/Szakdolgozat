using HMF.Thesis.Interfaces;

namespace HMF.Thesis.Logic
{
    /// A class for objects that are damageable.
    public class DamageableCharacterLogic : IDamageable
    {
        private ICharacter _character; ///< The Character's health comes from here.

        /// public Constructor where I set the character's value.
        /*!
        \param character is a ICharacter, we need this to access the health of the Character.
        */
        public DamageableCharacterLogic(ICharacter character)
        {
            _character = character;
        }

        /// Reduces the Health of the Character by one.
        public void TakeDamage()
        {
            --_character.Health;
        }

        /// Reduces the Health of the Character by a set amount.
        /*!
        \param damage is the damage you substract from your health.
        */
        public void TakeDamage(float damage = 1)
        {
            _character.Health -= damage;
        }
    }
}
