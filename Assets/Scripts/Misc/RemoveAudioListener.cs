using UnityEngine;

namespace HMF.Thesis.Misc
{
    /// Class for disabling an audioListener.
    public class RemoveAudioListener : MonoBehaviour
    {
        [SerializeField] private AudioListener _listener = null!; ///< Reference to the audioListener.

        /// Diables the audioListener.
        public void RemoveListener()
        {
           _listener.enabled = false;
        }
    }
}
