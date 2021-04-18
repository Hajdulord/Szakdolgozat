using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HMF.Thesis.Menu
{
    public class Menu : MonoBehaviour
    {
        [SerializeField] private GameObject _mainMenu = null;
        [SerializeField] private GameObject _endMenu = null;
        public bool isEnd = false;
        public void ExitGame() => Application.Quit();

        public void GoBack()
        {
            if (isEnd)
            {
                _endMenu.SetActive(true);
            }
            else
            {
                _mainMenu.SetActive(true);
            }
        }

        public void flipBool() => isEnd = !isEnd;
    }
    
}
