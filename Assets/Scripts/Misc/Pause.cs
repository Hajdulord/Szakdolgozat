using UnityEngine;

namespace HMF.Thesis.Misc
{
    /// A class for pausing and resuming the game.
    public class Pause : MonoBehaviour
    {
        public static bool gameIsPaused = false; ///< Holds if the game is paused.

        /// Resumes the game by setting the timeScale to 1;
        public static void Resume()
        {
            Time.timeScale = 1f;

            gameIsPaused = false;

            Score.Instance.StartTimer();
        }

        /// Pausing the game by setting the timeScale to 0;
        public static void PauseGame()
        {
            Score.Instance.StopTimer();

            Time.timeScale = 0f;

            gameIsPaused = true;
        }
    }
}
