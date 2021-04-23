using UnityEngine;
using UnityEngine.Audio;

namespace HMF.Thesis.Music
{
    public class VolumeSlider : MonoBehaviour
    {
        [SerializeField] private AudioMixer _mixer = null!;

        public void MainVolume(float volume)
        {
            _mixer.SetFloat("Volume", volume);
        }

        public void MusicVolume(float volume)
        {
            _mixer.SetFloat("MusicVolume", volume);
        }

        public void SFXVolume(float volume)
        {
            _mixer.SetFloat("SFXVolume", volume);
        }
    }
}
