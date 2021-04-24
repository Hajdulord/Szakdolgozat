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

            Score.Instance.StartTimer();
        }

        public static void PauseGame()
        {
            Score.Instance.StopTimer();

            Debug.Log($"Name: {Score.Instance.Name}\nTime: {Score.Instance.ElapsedTime}\nKills: {Score.Instance.Kills}\nDeaths: {Score.Instance.Deaths}\nScore: {Score.Instance.CalculatedScore()}");

            Time.timeScale = 0f;

            gameIsPaused = true;
        }
    }
}
