namespace HMF.Thesis.Interfaces
{
    public interface IStatusHandler
    {
        public void CalculateStatusEffects();
        
        public void AddStatus(string status);

        public void RemoveStatus(string status);
    }
}
