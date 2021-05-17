using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Linq;

namespace HMF.Thesis.Misc
{
    /// Class for updating the scoreboard.
    public class ScoreBoard : MonoBehaviour
    {
        [SerializeField] private List<TMP_Text> _easy = null!; ///< List of textFields for the easy scores.
        [SerializeField] private List<TMP_Text> _medium = null!; ///< List of textFields for the medium scores.
        [SerializeField] private List<TMP_Text> _hard = null!; ///< List of textFields for the hard scores.

        /// Updates the scores.
        public void UpdateScores()
        {
            var easy = Score.Instance.GetScoreBoard(0);
            var medium = Score.Instance.GetScoreBoard(1);
            var hard = Score.Instance.GetScoreBoard(2);

            // sets the name and score of the players in the textField.
            for (int i = 0; i < 10; i++)
            {
                var easyItem = easy.ElementAtOrDefault(i);
                if (easyItem != default)
                {
                    _easy[i].text = $"{easyItem.Name} - {easyItem.Score}";
                }
                else
                {
                    _easy[i].text = string.Empty;
                }

                var mediumItem = medium.ElementAtOrDefault(i);
                if (mediumItem != default)
                {
                    _medium[i].text = $"{mediumItem.Name} - {mediumItem.Score}";
                }
                else
                {
                    _medium[i].text = string.Empty;
                }

                var hardItem = hard.ElementAtOrDefault(i);
                if (hardItem != default)
                {
                    _hard[i].text = $"{hardItem.Name} - {hardItem.Score}";
                }
                else
                {
                    _hard[i].text = string.Empty;
                }
            }
        }
    }
}
