using UnityEngine;

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
        public abstract void Affect(GameObject gameObject);

        /// Resets all restrictions/buffs that the status creates. Should run at the and of the lifetime of the status.
        public abstract void CloseUp(GameObject gameObject);

        /// Should do all the jobs to setup the status. Should run before the first effect is applied.
        public abstract void PrePhase(GameObject gameObject);
    }
}
