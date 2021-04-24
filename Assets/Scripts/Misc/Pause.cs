using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HMF.Thesis.Misc
{
    public class Pause : MonoBehaviour
    {
        public static bool gameIsPaused = false;

        public static void Resume()
        {
            Time.timeScale = 1f;

            gameIsPaused = false;
        }

        public static void PauseGame()
        {
            Time.timeScale = 0f;

            gameIsPaused = true;
        }
    }
}
