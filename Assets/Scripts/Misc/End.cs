using UnityEngine;
using UnityEngine.InputSystem;
using HMF.Thesis.Status;
using UnityEngine.SceneManagement;
using TMPro;

namespace HMF.Thesis.Misc
{
    /// Logic of the end segment.
    public class End : MonoBehaviour
    {
        [SerializeField] private GameObject _endMenu = null!; ///< Reference to the end menu.
        [SerializeField] private GameObject _enemys = null!; ///< The parent of the enemys.
        [SerializeField] private TMP_Text _score = null!; ///< The textField for the end score.

        /// Stops gameplay elements when in range.
        private void OnTriggerEnter2D(Collider2D other) 
        {
            if (other.gameObject.tag == "Player")
            {
                Score.Instance.StopTimer();

                Score.Instance.AddToScoreBoard(SceneManager.GetActiveScene().buildIndex);

                SaveSystem.SaveScore();

                _score.text = $"Your last score is {Score.Instance.CalculatedScore()}";

                Score.Instance.ResetData();

                // cannot move or attack while in the end menu
                other.gameObject.GetComponent<PlayerInput>().enabled = false;
                var dummy = other.gameObject.GetComponent<Dummy>();

                // clears statuses
                dummy?.StopAllCoroutines();
                dummy.enabled = false;

                _enemys.SetActive(false);
                _endMenu.SetActive(true);
            }
        }
    }
}
