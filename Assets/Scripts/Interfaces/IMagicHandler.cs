namespace HMF.Thesis.Interfaces
{
    public interface IMagicHandler
    {
        void AddNewMagic(string magic);

        void UseMagic(string magic);

        void RemoveMagic(string magic);
    }
}
