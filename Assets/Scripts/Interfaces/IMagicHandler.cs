using UnityEngine;
namespace HMF.Thesis.Interfaces
{
    public interface IMagicHandler
    {
        void UseMagic(string magic, string[] tagsToIgnore, Vector2 center, LayerMask layersToTarget,GameObject animation, float dir = 0);
    }
}
