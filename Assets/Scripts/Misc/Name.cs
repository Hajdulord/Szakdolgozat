using UnityEngine;
using TMPro;

namespace HMF.Thesis.Misc
{
    public class Name : MonoBehaviour
    {
        [SerializeField] private TMP_InputField _field = null!;

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

        public void Save()
        {
            PlayerPrefs.SetString("PlayerName", Score.Instance.Name);
        }
    }
}
