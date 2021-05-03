namespace HMF.Thesis.Interfaces
{
    /// An interface to access the healthbar.
    public interface IHealthBar
    {
        
        /// Set the healtBar to a specific number.
        /*!
          \param health is the value you set the healthBar.
        */
        void SetHealth(int health);

        /// Set's the healtBar's max health.
        /*!
          \param health is the max health.
        */
        void SetMaxHealth(int health);
    }
}
