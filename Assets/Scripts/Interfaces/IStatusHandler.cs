namespace HMF.Thesis.Interfaces
{
    public interface IStatusHandler
    {
        public void AddStatus(string status);

        public void RemoveStatus(string status);
        void RemoveAllStatuses();
    }
}
