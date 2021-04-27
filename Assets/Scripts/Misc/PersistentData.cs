using UnityEngine;

namespace HMF.Thesis.Misc
{
    public class PersistentData : MonoBehaviour
    {
        private SaveData _currentSave = null;

        private string _name = string.Empty;
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

        private void Awake() 
        {
            DontDestroyOnLoad(gameObject);

            if (Instance == null)
            {
                Instance = this;
            }
        }

        private void OnDestroy() 
        {
            Instance = null;    
        }
    }
}
