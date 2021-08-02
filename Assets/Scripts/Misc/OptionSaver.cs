using UnityEngine;
using UnityEngine.Audio;

namespace HMF.Thesis.Misc
{
    /// A class for saving and loading the options.
    public class OptionSaver : MonoBehaviour
    {
        [SerializeField] private AudioMixer _mixer = null!; ///< Reference to the audio mixer.

        /// Loads the settings.
        private void Start()
        {
            if (PlayerPrefs.HasKey("QualityLevel"))
                QualitySettings.SetQualityLevel(PlayerPrefs.GetInt("QualityLevel"));

            if (PlayerPrefs.HasKey("Volume"))
                _mixer.SetFloat("Volume", PlayerPrefs.GetFloat("Volume"));

            if (PlayerPrefs.HasKey("MusicVolume"))
                _mixer.SetFloat("MusicVolume", PlayerPrefs.GetFloat("MusicVolume"));

            if (PlayerPrefs.HasKey("SFXVolume"))
                _mixer.SetFloat("SFXVolume", PlayerPrefs.GetFloat("SFXVolume"));
        }

        /// Saves the settings.
        public void Save()
        {
            _mixer.GetFloat("Volume",out float volume);
            PlayerPrefs.SetFloat("Volume", volume);

            _mixer.GetFloat("MusicVolume",out float musicVolume);
            PlayerPrefs.SetFloat("MusicVolume", musicVolume);

            _mixer.GetFloat("SFXVolume",out float SFXVolume);
            PlayerPrefs.SetFloat("SFXVolume", SFXVolume);

            PlayerPrefs.SetInt("QualityLevel", QualitySettings.GetQualityLevel());

            PlayerPrefs.Save();
        }
    }
}