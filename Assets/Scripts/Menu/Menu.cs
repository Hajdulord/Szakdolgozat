using UnityEngine;

namespace HMF.Thesis.Menu
{
    /// Menu interacctions.
    public class Menu : MonoBehaviour
    {
        [SerializeField] private GameObject _mainMenu = null; ///< Reference to the main menu.
        [SerializeField] private GameObject _endMenu = null; ///< Reference to the end menu.
        [SerializeField] private GameObject _pauseMenu = null; ///< Reference to the pause menu.
        public static bool isEnd = false; ///< Did the main menu sequence ended. Can go back to end menu.
        public static bool isPaused = false; ///< Is the game Paused.
        
        /// Closes the game.
        public void ExitGame() => Application.Quit();

        /// Switches back to the right menu.
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
        }

        /// Flips isEnd.
        public static void flipBool() => isEnd = !isEnd;

        /// Flips isPaused.
        public static void flipPausedBool() => isPaused = !isPaused;
    }
    
}
