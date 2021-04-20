using System.Collections.Generic;
using UnityEngine;

namespace HMF.Thesis.Music
{
    public enum Category
    {
        Deaths,
        Swords,
        Attacks
    }

    public class MusicHandler : MonoBehaviour
    {
        [SerializeField] private List<AudioClip> _deaths = null!;
        [SerializeField] private List<AudioClip> _swords = null!;
        [SerializeField] private List<AudioClip> _attacks = null!;
        [SerializeField] public AudioClip jumpLand = null!;
        [SerializeField] public AudioClip playerStep = null!;
        [SerializeField] public AudioClip enemyStep = null!;

        public static MusicHandler Instance {get; private set;} = null;

        private void Awake() 
        {
            if (Instance == null)
            {
                Instance = this;
            }
        }

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
    }
}
