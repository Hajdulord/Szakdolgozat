namespace HMF.Thesis.Interfaces
{
    /// An Inerface for a healable class.
    public interface IHealable
    {
        /// Increases the Health of the target by a set amount.
        /*!
            \param healAmount is the amount you add to the health.
        */
        void Heal(float healAmount = 1);
    }
}
