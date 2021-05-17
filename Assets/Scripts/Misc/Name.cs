using UnityEngine;
using TMPro;

namespace HMF.Thesis.Misc
{
    /// A calss for the players name input.
    public class Name : MonoBehaviour
    {
        [SerializeField] private TMP_InputField _field = null!; ///< Reference to the inputField.

        /// If there was a saved name loads it into the input field.
        private void Start() 
        {
            if (PlayerPrefs.HasKey("PlayerName"))
            {
                var name = PlayerPrefs.GetString("PlayerName");
                if (name != "Anonymus")
                {
                    _field.text = name;
                }
            }
        }

        /// Saves the new name.
        /*!
          \param inp is the input from the inputField.
        */
        public void Change(string inp)
        {
            if (inp == "Name" || inp == string.Empty)
            {
                Score.Instance.Name = "Anonymus";
            }
            else
            {
                Score.Instance.Name = inp;
            }
        }

        /// Saves the name to the PlayerPrefs.
        public void Save()
        {
            PlayerPrefs.SetString("PlayerName", Score.Instance.Name);
        }
    }
}
