using UnityEngine;

namespace HMF.Thesis.Player
{
    /// Class for disabling dust animation.
    public class DustAnimation : MonoBehaviour
    {
        /// Diasbles the dust's gameObject.
        public void DisableGameObject()
        {
            gameObject.SetActive(false);
        }
    }
}
