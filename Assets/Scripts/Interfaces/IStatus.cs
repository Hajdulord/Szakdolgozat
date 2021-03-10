namespace HMF.Thesis.Interfaces
{
    /// Interface for Statuses.
    public interface IStatus
    {
        /// The getter for the name of the status.
        string Name {get;}

        /// The getter for the lifetime of the status.
        float LifeTime {get;}

        /// The getter for the interval of affecting.
        float EffectInterval {get;}

        /// Affect an object according to the status.
        void Affect();
    }
}
