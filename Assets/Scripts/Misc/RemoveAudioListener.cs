using UnityEngine;

namespace HMF.Thesis.Misc
{
    public class RemoveAudioListener : MonoBehaviour
    {
        [SerializeField] private AudioListener _listener = null!;

        public void RemoveListener()
        {
           Destroy(_listener);
        }
    }
}
