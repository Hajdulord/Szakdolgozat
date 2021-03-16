using UnityEngine;
namespace HMF.Thesis.Interfaces
{
    public interface IMagicHandler
    {
        void UseMagic(string magic, string[] tagsToIgnore, Vector2 center, float dir = 0);
    }
}
