using UnityEngine;
using UnityEngine.Audio;
using System.Collections.Generic;
using UnityEngine.UI;

namespace HMF.Thesis.Music
{
    /// The class for setting the sliders in the settings menu.
    public class VolumeSlider : MonoBehaviour
    {
        [SerializeField] private AudioMixer _mixer = null!; ///< The current AudioMixer.
        [SerializeField] private List<Slider> _sliders = null; ///< The sliders for adjusting the volume.

        /// Sets the default values for the sliders.
        private void Start() 
        {
            _mixer.GetFloat("Volume", out float volume);
            _sliders[0].value = volume;

            _mixer.GetFloat("MusicVolume", out float musicVolume);
            _sliders[1].value = musicVolume;

            _mixer.GetFloat("SFXVolume", out float SFXVolume);
            _sliders[2].value = SFXVolume;
        }

        /// Sets the Main voulme.
        /*!
          \param volume is the current volume to set.
        */
        public void MainVolume(float volume)
        {
            _mixer.SetFloat("Volume", volume);
        }

        /// Sets the Music voulme.
        /*!
          \param volume is the current volume to set.
        */
        public void MusicVolume(float volume)
        {
            _mixer.SetFloat("MusicVolume", volume);
        }

        /// Sets the SFX voulme.
        /*!
          \param volume is the current volume to set.
        */
        public void SFXVolume(float volume)
        {
            _mixer.SetFloat("SFXVolume", volume);
        }
    }
}
