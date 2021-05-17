using System.Collections.Generic;
using UnityEngine;

namespace HMF.Thesis.Music
{
    // This class handles the audioclip distribution.
    public class MusicHandler : MonoBehaviour
    {
        [SerializeField] private List<AudioClip> _deaths = null!; ///< List of death souds.
        [SerializeField] private List<AudioClip> _swords = null!; ///< List of sword clashes.
        [SerializeField] private List<AudioClip> _attacks = null!; ///< List of battlecys.
        [SerializeField] public AudioClip jumpLand = null!; ///< Sound of landing.
        [SerializeField] public AudioClip playerStep = null!; ///< Sound of the player stepping.
        [SerializeField] public AudioClip enemyStep = null!; ///< Sound of the enemys stepping.

        /// Singleton instance.
        public static MusicHandler Instance {get; private set;} = null;

        /// Sets the singleton instance.
        private void Awake() 
        {
            if (Instance == null)
            {
                Instance = this;
            }
        }

        /// Serves a random sound from the requested category.
        /*!
          \param category is Category of the sound requested.
        */
        public AudioClip Serve(Category category)
        {
            int index;
            switch (category)
            {
                case Category.Deaths:
                    index = Random.Range(0, _deaths.Count);
                    return _deaths[index];

                case Category.Swords:
                    index = Random.Range(0, _swords.Count);
                    return _swords[index];

                case Category.Attacks:
                    index = Random.Range(0, _attacks.Count);
                    return _attacks[index];

                default:
                    return null;
            }
        }

        /// Clears the singleton instance.
        private void OnDestroy() 
        {
            Instance = null;    
        }
    }

    /// Enum for the sound categories.
    public enum Category
    {
        Deaths,
        Swords,
        Attacks
    }
}
