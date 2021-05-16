namespace HMF.Thesis.Interfaces
{
    /// The IOnterface for the StatusHandler
    public interface IStatusHandler
    {
        /// Add a status to be active.
        /*!
          \param status is the name of the status.
        */
        void AddStatus(string status);

        /// Removes all statuses.
        void RemoveAllStatuses();
    }
}
