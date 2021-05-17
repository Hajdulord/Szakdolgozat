using UnityEngine;

namespace HMF.Thesis.Misc
{
    /// A persistent data calss that is needed for scene switching.
    public class PersistentData : MonoBehaviour
    {
        private SaveData _currentSave = null; ///< The current saved gameData.
        private string _name = string.Empty; ///< The player's name.
        private bool _loaded = false; ///< Check if there was a scene load.

        /// Singleton instance.
        public static PersistentData Instance {get; private set;}

        /// Only gives the current save once, but can set any time.
        /*!
          \returns SaveData once after null.
        */
        public SaveData CurrentSave 
        {
             get 
             {
                var output = _currentSave;
                _currentSave = null;
                return output;
            }
            set => _currentSave = value;
        }

        /// Only gives the name once, but can set any time.
        /*!
          \returns string once after empty string.
        */
        public string Name 
        { 
            get
            {
                var output = _name;
                _name = string.Empty;
                return output;
            } 
            set => _name = value;
        }

        /// Only gives the loaded bool once, but can set any time.
        /*!
          \returns true once after false.
        */
        public bool Loaded 
        { 
            get
            {
                var output = _loaded;
                _loaded = false;
                return output;
            } 
            set => _loaded = value; 
        }

        /// Sets the singleton instance and makes the GameObject to not be destroyed when switching scenes.
        private void Awake() 
        {
            DontDestroyOnLoad(gameObject);

            if (Instance == null)
            {
                Instance = this;
            }
        }

        /// Free the singleton instance.
        private void OnDestroy() 
        {
            Instance = null;    
        }
    }
}
