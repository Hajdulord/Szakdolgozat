namespace HMF.Thesis.Status
{
    /// Abstract class for Statuses.
    public abstract class StatusBase
    {
        /// The getter for the name of the status.
        public abstract string Name {get;}

        /// The getter for the lifetime of the status.
        public abstract float LifeTime {get;}

        /// The getter for the interval of affecting.
        public abstract float EffectInterval {get;}

        /// Affect an object according to the status.
       public abstract void Affect();
    }
}
