using UnityEngine;

namespace HMF.Thesis.Menu
{
    public class Menu : MonoBehaviour
    {
        [SerializeField] private GameObject _mainMenu = null;
        [SerializeField] private GameObject _endMenu = null;
        [SerializeField] private GameObject _pauseMenu = null;
        public static bool isEnd = false;
        public static bool isPaused = false;
        public void ExitGame() => Application.Quit();

        public void GoBack()
        {
            if (isEnd && !isPaused)
            {
                _endMenu.SetActive(true);
            }
            else if(!isEnd && !isPaused)
            {
                _mainMenu.SetActive(true);
            }
            else if(isEnd && isPaused)
            {
                _pauseMenu.SetActive(true);
            }

            //Debug.Log(isEnd + " " + isPaused);
        }

        public static void flipBool() => isEnd = !isEnd;

        public static void flipPausedBool() => isPaused = !isPaused;
    }
    
}
