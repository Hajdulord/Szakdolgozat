using UnityEngine;
using UnityEngine.Audio;
using System.Collections.Generic;
using UnityEngine.UI;

namespace HMF.Thesis.Music
{
    public class VolumeSlider : MonoBehaviour
    {
        [SerializeField] private AudioMixer _mixer = null!;
        [SerializeField] private List<Slider> _sliders = null;

        private void Start() 
        {
            _mixer.GetFloat("Volume", out float volume);
            _sliders[0].value = volume;

            _mixer.GetFloat("MusicVolume", out float musicVolume);
            _sliders[1].value = musicVolume;

            _mixer.GetFloat("SFXVolume", out float SFXVolume);
            _sliders[2].value = SFXVolume;
        }

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
