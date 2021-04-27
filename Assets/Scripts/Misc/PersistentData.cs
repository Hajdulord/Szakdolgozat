using UnityEngine;

namespace HMF.Thesis.Misc
{
    public class PersistentData : MonoBehaviour
    {
        private SaveData _currentSave = null;
        public static PersistentData Instance {get; private set;}
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

        private void Awake() 
        {
            DontDestroyOnLoad(gameObject);

            if (Instance == null)
            {
                Instance = this;
            }
        }
    }
}
